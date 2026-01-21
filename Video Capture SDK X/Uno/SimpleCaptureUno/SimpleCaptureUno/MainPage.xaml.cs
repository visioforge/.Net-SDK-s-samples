#if (__IOS__ && !__MACCATALYST__) || __ANDROID__
#define MOBILE
#endif

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.IO;
using SysDebug = System.Diagnostics.Debug;
using System.Linq;
using System.Threading.Tasks;
using VisioForge.Core;
using VisioForge.Core.Helpers;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoCapture;
using VisioForge.Core.VideoCaptureX;

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

namespace SimpleCaptureUno;

public sealed partial class MainPage : Page
{
    private VideoCaptureCoreX? _core;

    private VideoCaptureDeviceInfo[]? _cameras;

    private int _cameraSelectedIndex = 0;

    private AudioCaptureDeviceInfo[]? _mics;

    private int _micSelectedIndex = 0;

    private AudioOutputDeviceInfo[]? _speakers;

    private int _speakerSelectedIndex = 0;

    private SolidColorBrush? _defaultButtonBackground;

    /// <summary>
    /// Interaction logic for the Uno Platform Simple Capture demo's MainPage.
    /// Demonstrates how to handle video capture across different platforms (Windows, Android, iOS, macOS) using a unified codebase.
    /// </summary>
    public MainPage()
    {
        this.InitializeComponent();

        Loaded += MainPage_Loaded;
        Unloaded += MainPage_Unloaded;
    }

    /// <summary>
    /// Handles the Unloaded event of the MainPage.
    /// Safely disposes of the video capture core and destroys the SDK to release resources.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private async void MainPage_Unloaded(object sender, RoutedEventArgs e)
    {
        try
        {
            if (_core != null)
            {
                _core.OnError -= Core_OnError;
                await _core.StopAsync();
                _core.Dispose();
                _core = null;
            }
        }
        catch (Exception ex)
        {
            SysDebug.WriteLine($"Error during unload: {ex.Message}");
        }
        finally
        {
            VisioForgeX.DestroySDK();
        }
    }

#if __IOS__ || __MACCATALYST__
    /// <summary>
    /// Asynchronously requests video and audio permissions on iOS and MacCatalyst.
    /// </summary>
    /// <returns>True if permissions are granted; otherwise, false.</returns>
    private async Task<bool> EnsureApplePermissionsAsync()
    {
        var cameraStatus = AVCaptureDevice.GetAuthorizationStatus(AVAuthorizationMediaType.Video);
        if (cameraStatus != AVAuthorizationStatus.Authorized)
        {
            var granted = await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVAuthorizationMediaType.Video);
            if (!granted)
            {
                return false;
            }
        }

        var micStatus = AVCaptureDevice.GetAuthorizationStatus(AVAuthorizationMediaType.Audio);
        if (micStatus != AVAuthorizationStatus.Authorized)
        {
            var granted = await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVAuthorizationMediaType.Audio);
            if (!granted)
            {
                return false;
            }
        }

        return true;
    }
#endif

#if __ANDROID__
    /// <summary>
    /// Asynchronously requests camera and microphone permissions on Android.
    /// </summary>
    /// <returns>True if permissions are granted; otherwise, false.</returns>
    private async Task<bool> EnsureAndroidPermissionsAsync()
    {
        var activity = ContextHelper.Current as Android.App.Activity;
        if (activity == null)
        {
            return false;
        }

        var cameraPermission = ContextCompat.CheckSelfPermission(activity, Android.Manifest.Permission.Camera);
        var micPermission = ContextCompat.CheckSelfPermission(activity, Android.Manifest.Permission.RecordAudio);

        if (cameraPermission != Permission.Granted || micPermission != Permission.Granted)
        {
            var permissions = new[]
            {
                Android.Manifest.Permission.Camera,
                Android.Manifest.Permission.RecordAudio
            };

            ActivityCompat.RequestPermissions(activity, permissions, 1);

            // Wait a bit for the permission dialog
            await Task.Delay(1000);

            cameraPermission = ContextCompat.CheckSelfPermission(activity, Android.Manifest.Permission.Camera);
            micPermission = ContextCompat.CheckSelfPermission(activity, Android.Manifest.Permission.RecordAudio);

            return cameraPermission == Permission.Granted && micPermission == Permission.Granted;
        }

        return true;
    }
#endif

#if NET_WINDOWS
    /// <summary>
    /// Asynchronously ensures camera and microphone permissions on Windows.
    /// </summary>
    /// <returns>True if permissions are initialized successfully; otherwise, false.</returns>
    private async Task<bool> EnsureWindowsPermissionsAsync()
    {
        try
        {
            var settings = new MediaCaptureInitializationSettings
            {
                StreamingCaptureMode = StreamingCaptureMode.AudioAndVideo
            };

            var mediaCapture = new MediaCapture();
            await mediaCapture.InitializeAsync(settings);
            mediaCapture.Dispose();
            return true;
        }
        catch
        {
            return false;
        }
    }
#endif

    /// <summary>
    /// Updates the status label on the UI thread with a specified message and color.
    /// </summary>
    /// <param name="message">The status message to display.</param>
    /// <param name="color">The hex color string for the text color (default is green).</param>
    private void ShowStatus(string message, string color = "#00FF00")
    {
        SysDebug.WriteLine($"ShowStatus: {message}");
        
        DispatcherQueue.TryEnqueue(() =>
        {
            lblStatus.Text = message;
            lblStatus.Foreground = new SolidColorBrush(GetColorFromHex(color));
        });
    }

    private static Windows.UI.Color GetColorFromHex(string hex)
    {
        hex = hex.Replace("#", string.Empty);
        byte a = 255;
        byte r = Convert.ToByte(hex.Substring(0, 2), 16);
        byte g = Convert.ToByte(hex.Substring(2, 2), 16);
        byte b = Convert.ToByte(hex.Substring(4, 2), 16);
        return Windows.UI.Color.FromArgb(a, r, g, b);
    }

    /// <summary>
    /// Clears the status label message on the UI thread.
    /// </summary>
    private void HideStatus()
    {
        DispatcherQueue.TryEnqueue(() =>
        {
            lblStatus.Text = "";
        });
    }

    /// <summary>
    /// Handles the Loaded event of the MainPage.
    /// Initializes SDK, checks permissions, constructs the video capture core, and populates device lists.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            _defaultButtonBackground = btStartCapture.Background as SolidColorBrush;

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
                ShowStatus("Permissions required", "#FF0000");
                return;
            }

            await VisioForgeX.InitSDKAsync();

            // Create core object with IVideoView interface (VideoView implements IVideoView directly)
            _core = new VideoCaptureCoreX(videoView);

            // Add event handlers
            _core.OnError += Core_OnError;

            // Enumerate cameras
            _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
            if (_cameras.Length > 0)
            {
                btCamera.Content = _cameras[0].DisplayName;
            }

            // Enumerate microphones and other audio sources
            _mics = await DeviceEnumerator.Shared.AudioSourcesAsync(null);
            if (_mics.Length > 0)
            {
                btMic.Content = _mics[0].DisplayName;
            }

            // Enumerate audio outputs
            _speakers = await DeviceEnumerator.Shared.AudioOutputsAsync(null);
            if (_speakers.Length > 0)
            {
                btSpeakers.Content = _speakers[0].DisplayName;
            }

#if __ANDROID__ || (__IOS__ && !__MACCATALYST__)
            // Select second camera if available for mobile platforms
            if (_cameras.Length > 1)
            {
                btCamera.Content = _cameras[1].DisplayName;
                _cameraSelectedIndex = 1;
            }

            // Start preview
            btStartCapture.IsEnabled = true;
            await StartPreview();
#elif __MACCATALYST__
            ShowStatus("Ready");
#endif
        }
        catch (Exception ex)
        {
            SysDebug.WriteLine($"Error during initialization: {ex.Message}");
            ShowStatus("Init failed", "#FF0000");
        }
    }

    /// <summary>
    /// Handles the OnError event of the video capture core.
    /// Logs error messages to the debug output.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="VisioForge.Core.Types.Events.ErrorsEventArgs"/> instance containing the error information.</param>
    private void Core_OnError(object? sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
    {
        SysDebug.WriteLine(e.Message);
    }

    /// <summary>
    /// Asynchronously stops the current video capture session.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    private async Task StopAllAsync()
    {
        if (_core == null)
        {
            return;
        }

        await _core.StopAsync();
    }

#if __IOS__ && !__MACCATALYST__
    /// <summary>
    /// Adds the recorded video file to the iOS Photos library.
    /// </summary>
    /// <param name="filePath">The path to the video file.</param>
    private void AddVideoToPhotosLibrary(string filePath)
    {
        var fileUrl = NSUrl.FromFilename(filePath);

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
                        Console.WriteLine("Video saved to Photos library.");
                    }
                    else
                    {
                        Console.WriteLine($"Error saving video: {error?.LocalizedDescription}");
                    }
                });
            }
        });
    }
#endif

    /// <summary>
    /// Asynchronously stops the active recording and updates the UI status.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    private async Task StopCaptureAsync()
    {
        if (_core == null) return;

        SysDebug.WriteLine("Stop capture");
        
        string? filename = null;
        var output = _core.Outputs_Get(0);
        filename = output?.GetFilename();
        
        await _core.StopCaptureAsync(0);
        btStartCapture.Background = _defaultButtonBackground;
        btStartCapture.Content = "CAPTURE";

        // save video to photo library or show file path
#if __ANDROID__ || (__IOS__ && !__MACCATALYST__)
        if (!string.IsNullOrEmpty(filename))
        {
            await PhotoGalleryHelper.AddVideoToGalleryAsync(filename);
        }
#endif
        ShowStatus($"Saved: {filename}");
    }

    /// <summary>
    /// Handles the Click event of the Camera button.
    /// Cycles through available camera devices and restarts the preview.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private async void btCamera_Clicked(object sender, RoutedEventArgs e)
    {
        if (_cameras == null || _cameras.Length < 2)
        {
            return;
        }

        _cameraSelectedIndex++;

        if (_cameraSelectedIndex >= _cameras.Length)
        {
            _cameraSelectedIndex = 0;
        }

        btCamera.Content = _cameras[_cameraSelectedIndex].DisplayName;

#if __ANDROID__ || (__IOS__ && !__MACCATALYST__)
        await StopAllAsync();
        await StartPreview();
#endif
    }

    /// <summary>
    /// Handles the Click event of the Microphone button.
    /// Cycles through available audio input devices.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btMic_Clicked(object sender, RoutedEventArgs e)
    {
        if (_mics == null || _mics.Length < 2)
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
    /// Handles the Click event of the Speakers button.
    /// Cycles through available audio output devices.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btSpeakers_Clicked(object sender, RoutedEventArgs e)
    {
        if (_speakers == null || _speakers.Length < 2)
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
    /// Configures and starts the camera preview with the selected devices.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    private async Task StartPreview()
    {
        if (_core == null) return;

        if (_core.State == PlaybackState.Play || _core.State == PlaybackState.Pause)
        {
            return;
        }

        // audio output
#if MOBILE
        _core.Audio_Play = false;
#else
        var speakerName = btSpeakers.Content?.ToString();
        if (!string.IsNullOrEmpty(speakerName))
        {
            var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync()).FirstOrDefault(device => device.DisplayName == speakerName);
            if (audioOutputDevice != null)
            {
                _core.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);
                _core.Audio_Play = true;
            }
        }
#endif

        // video source
        VideoCaptureDeviceSourceSettings? videoSourceSettings = null;

        var deviceName = btCamera.Content?.ToString();
        if (!string.IsNullOrEmpty(deviceName))
        {
            var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
            if (device != null)
            {
                var formatItem = device.GetHDVideoFormatAndFrameRate(out var frameRate);
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

        _core.Video_Source = videoSourceSettings;

#if __IOS__ && !__MACCATALYST__
        if (videoSourceSettings != null)
        {
            videoSourceSettings.Orientation = IOSVideoSourceOrientation.LandscapeRight;
        }
#endif

        if (videoSourceSettings == null)
        {
            ShowStatus("Camera error", "#FF0000");
            return;
        }

        // audio source
        IVideoCaptureBaseAudioSourceSettings? audioSourceSettings = null;

        var micName = btMic.Content?.ToString();
        if (!string.IsNullOrEmpty(micName))
        {
            var device = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == micName);
            if (device != null)
            {
                var formatItem = device.GetDefaultFormat();
                audioSourceSettings = device.CreateSourceSettingsVC(formatItem);
            }
        }

        _core.Audio_Source = audioSourceSettings;

        // configure capture
        _core.Audio_Record = true;

        _core.Outputs_Clear();
        _core.Outputs_Add(new MP4Output(GenerateFilename(), H264EncoderBlock.GetDefaultSettings(), new MP3EncoderSettings()), false);

        // start
        await _core.StartAsync();

        btStartPreview.Content = "STOP";
        ShowStatus("Preview");
    }

    /// <summary>
    /// Generates a unique filename for the recording based on the platform and current time.
    /// </summary>
    /// <returns>The full path to the generated filename.</returns>
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
            
            filename = Path.Combine(moviesDir?.AbsolutePath ?? context.FilesDir!.AbsolutePath, 
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
    /// Handles the Click event of the Start/Stop Preview button.
    /// Toggles the camera preview state.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private async void btStartPreview_Clicked(object sender, RoutedEventArgs e)
    {
        if (_core == null)
        {
            return;
        }

        switch (_core.State)
        {
            case PlaybackState.Play:
                {
                    await StopAllAsync();

                    btStartPreview.Content = "PREVIEW";
                    btStartCapture.IsEnabled = false;
                    ShowStatus("Stopped");
                }

                break;
            case PlaybackState.Free:
                {
                    if (_core.State == PlaybackState.Play || _core.State == PlaybackState.Pause)
                    {
                        return;
                    }

                    await StartPreview();
                    btStartCapture.IsEnabled = true;
                }

                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Handles the Click event of the Start/Stop Capture button.
    /// Starts recording to a file or stops the current recording.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private async void btStartCapture_Clicked(object sender, RoutedEventArgs e)
    {
        if (_core == null || _core.State != PlaybackState.Play)
        {
            return;
        }

        var currentBrush = btStartCapture.Background as SolidColorBrush;
        if (currentBrush == null || currentBrush.Color != Microsoft.UI.Colors.Red)
        {
            SysDebug.WriteLine("Start capture");
            await _core.StartCaptureAsync(0, GenerateFilename());
            btStartCapture.Background = new SolidColorBrush(Microsoft.UI.Colors.Red);
            btStartCapture.Content = "STOP";
            ShowStatus("Recording", "#FF0000");
        }
        else
        {
            await StopCaptureAsync();
        }
    }
}
