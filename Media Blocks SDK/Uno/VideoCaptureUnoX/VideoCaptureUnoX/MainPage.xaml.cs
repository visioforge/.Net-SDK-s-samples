#if (__IOS__ && !__MACCATALYST__) || __ANDROID__
#define MOBILE
#endif

using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using System;
using System.IO;
using System.Threading.Tasks;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core;
using System.Linq;

#if __IOS__ || __MACCATALYST__
using AVFoundation;
#endif

#if __IOS__ && !__MACCATALYST__
using Foundation;
#endif
#if __ANDROID__
using Android.Widget;
using Android.Content.PM;
using AndroidX.Core.Content;
using AndroidX.Core.App;
#endif
#if NET_WINDOWS
using Windows.Media.Capture;
#endif
using DebugLogger = System.Diagnostics.Debug;

namespace VideoCaptureUnoX;

public sealed partial class MainPage : Page
{
    private MediaBlocksPipeline? _pipeline;

    private SystemVideoSourceBlock? _videoSource;

    private MediaBlock? _audioSource;

#if !MOBILE
    private AudioRendererBlock? _audioOutput;
#endif

    private MediaBlock? _videoRenderer;

    private TeeBlock? _videoTee;

    private TeeBlock? _audioTee;

    private MP4SinkBlock? _mp4Sink;

    private H264EncoderBlock? _videoEncoder;

    private AACEncoderBlock? _audioEncoder;

    private VideoCaptureDeviceInfo[]? _cameras;

    private int _cameraSelectedIndex = 0;

    private AudioCaptureDeviceInfo[]? _mics;

    private int _micSelectedIndex = 0;

    private AudioOutputDeviceInfo[]? _speakers;

    private int _speakerSelectedIndex = 0;

    public MainPage()
    {
        this.InitializeComponent();

        Loaded += MainPage_Loaded;
        Unloaded += MainPage_Unloaded;

        VisioForgeX.InitSDK();
    }

        /// <summary>
        /// Main page unloaded.
        /// </summary>
    private async void MainPage_Unloaded(object sender, RoutedEventArgs e)
    {
        try
        {
            await StopAllAsync();
        }
        catch (Exception ex)
        {
            DebugLogger.WriteLine($"Error during unload: {ex.Message}");
        }
        finally
        {
            VisioForgeX.DestroySDK();
        }
    }

        /// <summary>
        /// Create engine.
        /// </summary>
    private void CreateEngine()
    {
        try
        {
            _pipeline = new MediaBlocksPipeline();

            _videoRenderer = new VideoRendererBlock(_pipeline, videoView) { IsSync = false };

            _pipeline.OnError += Core_OnError;
        }
        catch (Exception ex)
        {
            DebugLogger.WriteLine($"Error creating engine: {ex.Message}");
            _pipeline?.Dispose();
            _pipeline = null;
            _videoRenderer?.Dispose();
            _videoRenderer = null;
            throw;
        }
    }

        /// <summary>
        /// Main page loaded.
        /// </summary>
    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
#if __IOS__ || __MACCATALYST__
            var permissionsOk = await EnsureApplePermissionsAsync();
#elif __ANDROID__
            var permissionsOk = await EnsureAndroidPermissionsAsync();
#elif NET_WINDOWS
            var permissionsOk = await EnsureWindowsPermissionsAsync();
#else
            var permissionsOk = true;
#endif
            if (!permissionsOk)
            {
                await ShowMessageAsync("Permissions", "Camera and microphone permissions are required. Please enable them in Settings.");
                return;
            }

#if __IOS__ || __MACCATALYST__

            // Use DeviceEnumerator for device enumeration
            _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
            if (_cameras != null && _cameras.Length > 0)
            {
                btCamera.Content = _cameras[0].DisplayName;
                DebugLogger.WriteLine($"Found {_cameras.Length} cameras via DeviceEnumerator");
            }
            else
            {
                DebugLogger.WriteLine("No cameras found via DeviceEnumerator");
            }

            // mics
            _mics = await DeviceEnumerator.Shared.AudioSourcesAsync(null);
            if (_mics != null && _mics.Length > 0)
            {
                btMic.Content = _mics[0].DisplayName;
            }

            // audio outputs
            _speakers = await DeviceEnumerator.Shared.AudioOutputsAsync(null);
            if (_speakers != null && _speakers.Length > 0)
            {
                btSpeakers.Content = _speakers[0].DisplayName;
            }
#else
            // cameras
            _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
            if (_cameras.Length > 0)
            {
                btCamera.Content = _cameras[0].DisplayName;
            }

            // mics
            _mics = await DeviceEnumerator.Shared.AudioSourcesAsync(null);
            if (_mics.Length > 0)
            {
                btMic.Content = _mics[0].DisplayName;
            }

            // audio outputs
            _speakers = await DeviceEnumerator.Shared.AudioOutputsAsync(null);
            if (_speakers.Length > 0)
            {
                btSpeakers.Content = _speakers[0].DisplayName;
            }
#endif
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error loading page: {ex.Message}");
            await ShowMessageAsync("Error", $"Failed to initialize devices: {ex.Message}");
        }
    }

#if __IOS__ || __MACCATALYST__
        /// <summary>
        /// Ensure apple permissions async.
        /// </summary>
    private async Task<bool> EnsureApplePermissionsAsync()
    {
        try
        {
            var cameraGranted = true;
            var cameraStatus = AVCaptureDevice.GetAuthorizationStatus(AVAuthorizationMediaType.Video);
            if (cameraStatus == AVAuthorizationStatus.NotDetermined)
            {
                // On Apple platforms the permission prompt must be dispatched to the main thread.
                cameraGranted = await RunOnUIThreadAsync(() => AVCaptureDevice.RequestAccessForMediaTypeAsync(AVAuthorizationMediaType.Video));
            }
            else
            {
                cameraGranted = cameraStatus == AVAuthorizationStatus.Authorized;
            }

            var micPermission = AVAudioSession.SharedInstance().RecordPermission;
            bool micGranted;
            if (micPermission == AVAudioSessionRecordPermission.Undetermined)
            {
                micGranted = await RequestRecordPermissionAsync();
            }
            else
            {
                micGranted = micPermission == AVAudioSessionRecordPermission.Granted;
            }

            return cameraGranted && micGranted;
        }
        catch (Exception ex)
        {
            DebugLogger.WriteLine($"Permission check failed: {ex.Message}");
            return false;
        }
    }

        /// <summary>
        /// Request record permission async.
        /// </summary>
    private Task<bool> RequestRecordPermissionAsync()
    {
        var tcs = new TaskCompletionSource<bool>();
        // AVAudioSession permission prompt must run on the main thread.
        _ = RunOnUIThreadAsync(() =>
        {
            AVAudioSession.SharedInstance().RequestRecordPermission(granted => tcs.TrySetResult(granted));
            return Task.FromResult(true);
        });

        return tcs.Task;
    }
#endif

#if __ANDROID__
    private const int PERMISSION_REQUEST_CODE = 100;
    private static TaskCompletionSource<bool>? _permissionTcs;

    /// <summary>
    /// Called from MainActivity.OnRequestPermissionsResult to signal permission result.
    /// </summary>
    public static void OnPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
    {
        if (requestCode != PERMISSION_REQUEST_CODE || _permissionTcs == null)
        {
            return;
        }

        var allGranted = grantResults.Length > 0 && grantResults.All(r => r == Permission.Granted);
        _permissionTcs.TrySetResult(allGranted);
    }

        /// <summary>
        /// Ensure android permissions async.
        /// </summary>
    private async Task<bool> EnsureAndroidPermissionsAsync()
    {
        try
        {
            var activity = (Android.App.Activity)Uno.UI.ContextHelper.Current;
            if (activity == null)
            {
                return false;
            }

            var permissions = new[] 
            {
                Android.Manifest.Permission.Camera,
                Android.Manifest.Permission.RecordAudio
            };

            var permissionsToRequest = new System.Collections.Generic.List<string>();
            
            foreach (var permission in permissions)
            {
                if (ContextCompat.CheckSelfPermission(activity, permission) != Permission.Granted)
                {
                    permissionsToRequest.Add(permission);
                }
            }

            if (permissionsToRequest.Count > 0)
            {
                // Create TaskCompletionSource to wait for permission result
                _permissionTcs = new TaskCompletionSource<bool>();
                
                ActivityCompat.RequestPermissions(activity, permissionsToRequest.ToArray(), PERMISSION_REQUEST_CODE);
                
                // Wait for user to respond (no timeout - wait indefinitely)
                var granted = await _permissionTcs.Task;
                _permissionTcs = null;
                
                return granted;
            }

            return true;
        }
        catch (Exception ex)
        {
            DebugLogger.WriteLine($"Android permission check failed: {ex.Message}");
            return false;
        }
    }
#endif

#if NET_WINDOWS
        /// <summary>
        /// Ensure windows permissions async.
        /// </summary>
    private async Task<bool> EnsureWindowsPermissionsAsync()
    {
        try
        {
            // Request camera access
            var cameraAccess = await MediaCapture.RequestAccessAsync(Windows.Media.Capture.StreamingCaptureMode.VideoAndAudio);
            
            if (cameraAccess != Windows.Media.Capture.MediaCaptureAccessStatus.Allowed)
            {
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            DebugLogger.WriteLine($"Windows permission check failed: {ex.Message}");
            return false;
        }
    }
#endif

    private Task<T> RunOnUIThreadAsync<T>(Func<Task<T>> action)
    {
        if (DispatcherQueue.HasThreadAccess)
        {
            return action();
        }

        var tcs = new TaskCompletionSource<T>();

        var enqueued = DispatcherQueue.TryEnqueue(async () =>
        {
            try
            {
                var result = await action();
                tcs.TrySetResult(result);
            }
            catch (Exception ex)
            {
                tcs.TrySetException(ex);
            }
        });

        if (!enqueued)
        {
            tcs.TrySetException(new InvalidOperationException("Failed to enqueue to UI thread."));
        }

        return tcs.Task;
    }

        /// <summary>
        /// Core on error.
        /// </summary>
    private void Core_OnError(object? sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
    {
        DebugLogger.WriteLine(e.Message);
    }

        /// <summary>
        /// Stop all async.
        /// </summary>
    private async Task StopAllAsync()
    {
        if (_pipeline == null)
        {
            return;
        }

        try
        {
            // Proper GStreamer disposal sequence
            await _pipeline.StopAsync();
            await _pipeline.DisposeAsync();
        }
        catch (Exception ex)
        {
            DebugLogger.WriteLine($"Error stopping pipeline: {ex.Message}");
        }
        finally
        {
            _pipeline = null;

            // Dispose blocks after pipeline is disposed
            _videoEncoder?.Dispose();
            _videoEncoder = null;

            _mp4Sink?.Dispose();
            _mp4Sink = null;

            _videoSource?.Dispose();
            _videoSource = null;

            _audioSource?.Dispose();
            _audioSource = null;

            _videoTee?.Dispose();
            _videoTee = null;

            _audioTee?.Dispose();
            _audioTee = null;

            _audioEncoder?.Dispose();
            _audioEncoder = null;

            _videoRenderer?.Dispose();
            _videoRenderer = null;

#if !MOBILE
            _audioOutput?.Dispose();
            _audioOutput = null;
#endif
        }
    }

#if __IOS__ && !__MACCATALYST__
        /// <summary>
        /// Add video to photos library.
        /// </summary>
    private void AddVideoToPhotosLibrary(string filePath)
    {
        var fileUrl = Foundation.NSUrl.FromFilename(filePath);

        Photos.PHPhotoLibrary.RequestAuthorization(status =>
        {
            if (status == Photos.PHAuthorizationStatus.Authorized)
            {
                Photos.PHPhotoLibrary.SharedPhotoLibrary.PerformChanges(() =>
                {
                    // This line differs from the previous example
                    Photos.PHAssetChangeRequest.FromVideo(fileUrl);
                }, (success, error) =>
                {
                    if (success)
                    {
                        DebugLogger.WriteLine("Video saved to Photos library.");
                    }
                    else
                    {
                        DebugLogger.WriteLine($"Error saving video: {error?.LocalizedDescription}");
                    }
                });
            }
        });
    }
#endif

        /// <summary>
        /// Handles the bt stop clicked event.
        /// </summary>
    private async void btStop_Clicked(object sender, RoutedEventArgs e)
    {
        try
        {
#if __IOS__ && !__MACCATALYST__
            bool capture = _mp4Sink != null;
            string filename = null;
            if (capture)
            {
                filename = _mp4Sink.GetFilenameOrURL();
            }
#endif

            await StopAllAsync();

            // save video to iOS photo library
#if __IOS__ && !__MACCATALYST__
            if (capture)
            {
                AddVideoToPhotosLibrary(filename);
            }
#endif

            DispatcherQueue.TryEnqueue(() =>
            {
                btStartPreview.Content = "PREVIEW";
                btStartCapture.Content = "CAPTURE";
            });
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error stopping capture: {ex.Message}");
            await ShowMessageAsync("Error", $"Failed to stop capture: {ex.Message}");
        }
    }

        /// <summary>
        /// Handles the bt camera clicked event.
        /// </summary>
    private void btCamera_Clicked(object sender, RoutedEventArgs e)
    {
        if (_cameras == null || _cameras.Length == 0)
        {
            return;
        }

        _cameraSelectedIndex++;

        if (_cameraSelectedIndex >= _cameras.Length)
        {
            _cameraSelectedIndex = 0;
        }

        btCamera.Content = _cameras[_cameraSelectedIndex].DisplayName;
    }

        /// <summary>
        /// Handles the bt mic clicked event.
        /// </summary>
    private void btMic_Clicked(object sender, RoutedEventArgs e)
    {
        if (_mics == null || _mics.Length == 0)
        {
            return;
        }

        _micSelectedIndex++;

        if (_micSelectedIndex >= _mics.Length)
        {
            _micSelectedIndex = 0;
        }

        btMic.Content = _mics[_micSelectedIndex].DisplayName;
    }

        /// <summary>
        /// Handles the bt speakers clicked event.
        /// </summary>
    private void btSpeakers_Clicked(object sender, RoutedEventArgs e)
    {
        if (_speakers == null || _speakers.Length == 0)
        {
            return;
        }

        _speakerSelectedIndex++;

        if (_speakerSelectedIndex >= _speakers.Length)
        {
            _speakerSelectedIndex = 0;
        }

        btSpeakers.Content = _speakers[_speakerSelectedIndex].DisplayName;
    }

        /// <summary>
        /// Configure preview async.
        /// </summary>
    private async Task ConfigurePreviewAsync(bool connect)
    {
#if !MOBILE
        // audio output
        if (_speakers == null || _speakers.Length == 0)
        {
            await ShowMessageAsync("Error", "No audio output devices available");
            return;
        }

        _audioOutput = new AudioRendererBlock(_speakers.First(device => device.DisplayName == (string)btSpeakers.Content)) { IsSync = false };
#endif

        // video source
        VideoCaptureDeviceSourceSettings? videoSourceSettings = null;

        var deviceName = (string)btCamera.Content;
        if (!string.IsNullOrEmpty(deviceName) && _cameras != null)
        {
            var device = _cameras.FirstOrDefault(x => x.DisplayName == deviceName);
            if (device != null)
            {
                var formatItem = device.GetVideoFormatAndFrameRate(1280, 720, out var frameRate);
                if (formatItem != null)
                {
                    videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                    {
                        Format = formatItem.ToFormat()
                    };

                    videoSourceSettings.Format.FrameRate = frameRate;
                }
            }
        }

        if (videoSourceSettings == null)
        {
            await ShowMessageAsync("Error", "Unable to configure camera settings");
            return;
        }

#if __IOS__ && !__MACCATALYST__
        videoSourceSettings.Orientation = IOSVideoSourceOrientation.LandscapeRight;
#endif

        _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

        // audio source
        IAudioCaptureDeviceSourceSettings? audioSourceSettings = null;

        deviceName = (string)btMic.Content;
        if (!string.IsNullOrEmpty(deviceName))
        {
            var devices = await DeviceEnumerator.Shared.AudioSourcesAsync();
            var device = devices?.FirstOrDefault(x => x.DisplayName == deviceName);
            if (device != null)
            {
                var formatItem = device.GetDefaultFormat();
                audioSourceSettings = device.CreateSourceSettings(formatItem);
            }
        }

        if (audioSourceSettings == null)
        {
            await ShowMessageAsync("Error", "Unable to configure audio source settings");
            return;
        }

        //_audioSource = new VirtualAudioSourceBlock(new VirtualAudioSourceSettings());
        _audioSource = new SystemAudioSourceBlock(audioSourceSettings);

        if (connect)
        {
            if (_pipeline == null || _videoSource == null || _audioSource == null || _videoRenderer == null)
            {
                await ShowMessageAsync("Error", "Pipeline components not initialized");
                return;
            }

            _pipeline.Connect(_videoSource.Output, _videoRenderer.Input);

#if !MOBILE
            if (_audioOutput != null)
            {
                _pipeline.Connect(_audioSource.Output, _audioOutput.Input);
            }
#endif
        }
    }

        /// <summary>
        /// Generate filename.
        /// </summary>
    private string GenerateFilename()
    {
        DateTime now = DateTime.Now;
#if __ANDROID__
        // For Android 10+ (API 29+), we use app-specific external storage
        // which doesn't require special permissions and works with scoped storage
        string filename;
        
        if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Q)
        {
            // Android 10+ - Use app's external files directory for videos
            // This will be accessible by the app and can be added to gallery
            var context = Android.App.Application.Context;
            var moviesDir = context.GetExternalFilesDir(Android.OS.Environment.DirectoryMovies);
            
            if (moviesDir != null && !moviesDir.Exists())
            {
                moviesDir.Mkdirs();
            }
            
            filename = Path.Combine(moviesDir?.AbsolutePath ?? context.FilesDir.AbsolutePath, 
                $"visioforge_{now.Hour}_{now.Minute}_{now.Second}.mp4");
        }
        else
        {
            // Android 9 and below - Try to use public DCIM directory
            var dcimDir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim);
            var cameraDir = new Java.IO.File(dcimDir, "Camera");
            
            // Create the directory if it doesn't exist
            if (!cameraDir.Exists())
            {
                cameraDir.Mkdirs();
            }
            
            filename = Path.Combine(cameraDir.AbsolutePath, $"visioforge_{now.Hour}_{now.Minute}_{now.Second}.mp4");
        }
#elif __IOS__ && !__MACCATALYST__
        var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..",
            "Library", $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#elif __MACCATALYST__
        // Sandbox disabled - save directly to ~/Movies
        var moviesFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Movies");
        if (!Directory.Exists(moviesFolder))
        {
            Directory.CreateDirectory(moviesFolder);
        }
        var filename = Path.Combine(moviesFolder, $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#else
        var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#endif

        return filename;
    }

        /// <summary>
        /// Configure capture.
        /// </summary>
    private void ConfigureCapture()
    {
        if (_pipeline == null || _videoSource == null || _audioSource == null || _videoRenderer == null)
        {
            throw new InvalidOperationException("Pipeline components not initialized");
        }

        try
        {
            // add tee and connect
            _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
            _audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);

            _pipeline.Connect(_videoSource.Output, _videoTee.Input);
            _pipeline.Connect(_audioSource.Output, _audioTee.Input);

            // add preview
            _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);

#if !MOBILE
            if (_audioOutput != null)
            {
                _pipeline.Connect(_audioTee.Outputs[0], _audioOutput.Input);
            }
#endif

            // add video encoder
            _videoEncoder = new H264EncoderBlock(H264EncoderBlock.GetDefaultSettings());
            _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);

            // add audio encoder
            _audioEncoder = new AACEncoderBlock(AACEncoderBlock.GetDefaultSettings());
            _pipeline.Connect(_audioTee.Outputs[1], _audioEncoder.Input);

            // add sink
            var filename = GenerateFilename();
            DebugLogger.WriteLine($"Capture filename: {filename}");
            var sinkSettings = new MP4SinkSettings(filename);
            _mp4Sink = new MP4SinkBlock(sinkSettings);

            _pipeline.Connect(_videoEncoder.Output, _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Video));
            _pipeline.Connect(_audioEncoder.Output, _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Audio));
        }
        catch (Exception ex)
        {
            DebugLogger.WriteLine($"Error configuring capture: {ex.Message}");
            DebugLogger.WriteLine($"Stack trace: {ex.StackTrace}");
            
            // Clean up on error
            _videoTee?.Dispose();
            _videoTee = null;
            _audioTee?.Dispose();
            _audioTee = null;
            _videoEncoder?.Dispose();
            _videoEncoder = null;
            _audioEncoder?.Dispose();
            _audioEncoder = null;
            _mp4Sink?.Dispose();
            _mp4Sink = null;
            
            throw;
        }
    }

        /// <summary>
        /// Handles the bt start preview clicked event.
        /// </summary>
    private async void btStartPreview_Clicked(object sender, RoutedEventArgs e)
    {
        try
        {
            await StopAllAsync();

            CreateEngine();

            if (_pipeline == null)
            {
                await ShowMessageAsync("Error", "Failed to initialize pipeline");
                return;
            }

            switch (_pipeline.State)
            {
                case PlaybackState.Play:
                {
                    await _pipeline.PauseAsync();

                    DispatcherQueue.TryEnqueue(() => btStartPreview.Content = "PREVIEW");
                }

                    break;
                case PlaybackState.Pause:
                {
                    await _pipeline.ResumeAsync();

                    DispatcherQueue.TryEnqueue(() => btStartPreview.Content = "PAUSE");
                }

                    break;
                case PlaybackState.Free:
                {
                    if (_pipeline == null)
                    {
                        return;
                    }

                    if (_pipeline.State == PlaybackState.Play || _pipeline.State == PlaybackState.Pause)
                    {
                        return;
                    }

                    await ConfigurePreviewAsync(true);

                    if (_pipeline != null)
                    {
                        // start
                        await _pipeline.StartAsync();

                        DispatcherQueue.TryEnqueue(() => btStartPreview.Content = "PAUSE");
                    }
                }

                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error starting preview: {ex.Message}");
            await ShowMessageAsync("Error", $"Failed to start preview: {ex.Message}");
            DispatcherQueue.TryEnqueue(() => btStartPreview.Content = "PREVIEW");
        }
    }

        /// <summary>
        /// Handles the bt start capture clicked event.
        /// </summary>
    private async void btStartCapture_Clicked(object sender, RoutedEventArgs e)
    {
        try
        {
            await StopAllAsync();

            CreateEngine();

            if (_pipeline == null)
            {
                await ShowMessageAsync("Error", "Failed to initialize pipeline");
                return;
            }

            switch (_pipeline.State)
            {
                case PlaybackState.Play:
                {
                    await _pipeline.PauseAsync();

                    DispatcherQueue.TryEnqueue(() => btStartCapture.Content = "CAPTURE");
                }

                    break;
                case PlaybackState.Pause:
                {
                    await _pipeline.ResumeAsync();

                    DispatcherQueue.TryEnqueue(() => btStartCapture.Content = "PAUSE");
                }

                    break;
                case PlaybackState.Free:
                {
                    if (_pipeline == null)
                    {
                        return;
                    }

                    if (_pipeline.State == PlaybackState.Play || _pipeline.State == PlaybackState.Pause)
                    {
                        return;
                    }

                    await ConfigurePreviewAsync(false);

                    if (_pipeline != null && _videoSource != null && _audioSource != null)
                    {
                        ConfigureCapture();

                        // start
                        await _pipeline.StartAsync();

                        DispatcherQueue.TryEnqueue(() => btStartCapture.Content = "PAUSE");
                    }
                }

                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error starting capture: {ex.Message}");
            await ShowMessageAsync("Error", $"Failed to start capture: {ex.Message}");
            DispatcherQueue.TryEnqueue(() => btStartCapture.Content = "CAPTURE");
        }
    }

        /// <summary>
        /// Show message async.
        /// </summary>
    private async Task ShowMessageAsync(string title, string message)
    {
#if __ANDROID__
        Toast.MakeText(Android.App.Application.Context, $"{title}: {message}", ToastLength.Long)?.Show();
        await Task.CompletedTask;
#else
        if (DispatcherQueue.HasThreadAccess)
        {
            await ShowDialogOnUIThreadAsync(title, message);
        }
        else
        {
            var tcs = new TaskCompletionSource<bool>();
            DispatcherQueue.TryEnqueue(async () =>
            {
                try
                {
                    await ShowDialogOnUIThreadAsync(title, message);
                    tcs.SetResult(true);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });
            await tcs.Task;
        }
#endif
    }

#if !__ANDROID__
        /// <summary>
        /// Show dialog on ui thread async.
        /// </summary>
    private async Task ShowDialogOnUIThreadAsync(string title, string message)
    {
        try
        {
            var dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = "OK"
            };

            // Set XamlRoot if available
            if (this.XamlRoot != null)
            {
                dialog.XamlRoot = this.XamlRoot;
            }

            await dialog.ShowAsync();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error showing dialog: {ex.Message}");
        }
    }
#endif
}
