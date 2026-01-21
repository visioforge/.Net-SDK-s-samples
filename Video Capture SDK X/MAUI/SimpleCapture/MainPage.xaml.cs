#if (__IOS__ && !__MACCATALYST__) || __ANDROID__
#define MOBILE
#endif

using System;
using System.ComponentModel;
using System.Diagnostics;

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

namespace SimpleCapture
{
    /// <summary>
    /// Interaction logic for the MAUI Simple Capture demo's MainPage.
    /// Demonstrates how to configure video and audio sources, manage permissions, and perform video capture/recording using the X-engine.
    /// </summary>
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private VideoCaptureCoreX _core;


        private VideoCaptureDeviceInfo[] _cameras;

        private int _cameraSelectedIndex = 0;

        private AudioCaptureDeviceInfo[] _mics;

        private int _micSelectedIndex = 0;

        private AudioOutputDeviceInfo[] _speakers;

        private int _speakerSelectedIndex = 0;


        private Color _defaultButtonColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;

            this.BindingContext = this;
        }

        /// <summary>
        /// Handles the Unloaded event of the MainPage.
        /// Disposes of the video capture engine and destroys the SDK.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainPage_Unloaded(object? sender, EventArgs e)
        {
            // Dispose core object
            _core?.Dispose();
            _core = null;

            // Destroy SDK
            VisioForgeX.DestroySDK();
        }

#if __IOS__ && !__MACCATALYST__
        /// <summary>
        /// Request photo permission.
        /// </summary>
        private void RequestPhotoPermission()
        {
            Photos.PHPhotoLibrary.RequestAuthorization(status =>
            {
                if (status == Photos.PHAuthorizationStatus.Authorized)
                {
                    Debug.WriteLine("Photo library access granted.");
                }
            });
        }
#endif

        /// <summary>
        /// Asynchronously requests camera access permissions from the user.
        /// Displays an alert if permission is required but not yet granted.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task RequestCameraPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Camera>();

            // Check result from permission request. If it is allowed by the user, connect to scanner
            if (result == PermissionStatus.Granted)
            {
            }
            else
            {
                if (Permissions.ShouldShowRationale<Permissions.Camera>())
                {
                    if (await DisplayAlertAsync(null, "You need to allow access to the Camera", "OK", "Cancel"))
                        await RequestCameraPermissionAsync();
                }
            }
        }

        /// <summary>
        /// Asynchronously requests microphone access permissions from the user.
        /// Displays an alert if permission is required but not yet granted.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task RequestMicPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Microphone>();

            // Check result from permission request. If it is allowed by the user, connect to scanner
            if (result == PermissionStatus.Granted)
            {
            }
            else
            {
                if (Permissions.ShouldShowRationale<Permissions.Microphone>())
                {
                    if (await DisplayAlertAsync(null, "You need to allow access to the Microphone", "OK", "Cancel"))
                        await RequestMicPermissionAsync();
                }
            }
        }

#if __ANDROID__
        /// <summary>
        /// Request storage permission async.
        /// </summary>
        private async Task RequestStoragePermissionAsync()
        {
            // For Android 13+ (API 33+), we need to request media permissions
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Tiramisu)
            {
                // Android 13+ uses granular media permissions
                var result = await Permissions.RequestAsync<Permissions.Media>();
                
                if (result != PermissionStatus.Granted)
                {
                    if (Permissions.ShouldShowRationale<Permissions.Media>())
                    {
                        if (await DisplayAlertAsync(null, "You need to allow access to save videos", "OK", "Cancel"))
                            await RequestStoragePermissionAsync();
                    }
                }
            }
            else if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Q)
            {
                // Android 10-12 - No need for storage permissions when using app-specific directories
                // MediaStore access is granted by default
                return;
            }
            else
            {
                // Android 9 and below - Request storage permissions
                var result = await Permissions.RequestAsync<Permissions.StorageWrite>();
                
                if (result != PermissionStatus.Granted)
                {
                    if (Permissions.ShouldShowRationale<Permissions.StorageWrite>())
                    {
                        if (await DisplayAlertAsync(null, "You need to allow storage access to save videos", "OK", "Cancel"))
                            await RequestStoragePermissionAsync();
                    }
                }
            }
        }
#endif

        /// <summary>
        /// Handles the Loaded event of the MainPage.
        /// Requests necessary permissions and initializes the video capture engine, devices, and UI.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void MainPage_Loaded(object? sender, EventArgs e)
        {
            // Ask for permissions
#if __ANDROID__ || __MACOS__ || __MACCATALYST__ || __IOS__
            await RequestCameraPermissionAsync();
            await RequestMicPermissionAsync();
#endif

#if __ANDROID__
            await RequestStoragePermissionAsync();
#endif

#if __IOS__ && !__MACCATALYST__
            RequestPhotoPermission();
#endif

            // Get IVideoView interface
            IVideoView vv = videoView.GetVideoView();

            // Create core object with IVideoView interface
            _core = new VideoCaptureCoreX(vv);

            // Add event handlers
            _core.OnError += Core_OnError;

            // Enumerate cameras
            _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
            if (_cameras.Length > 0)
            {                
                btCamera.Text = _cameras[0].DisplayName;
            }

            // Enumerate microphones and other audio sources
            _mics = await DeviceEnumerator.Shared.AudioSourcesAsync(null);
            if (_mics.Length > 0)
            {      
                btMic.Text = _mics[0].DisplayName;
            }
            Window.Destroying += Window_Destroying;

            // Enumerate audio outputs
            _speakers = await DeviceEnumerator.Shared.AudioOutputsAsync(null);
            if (_speakers.Length > 0)
            {                
                btSpeakers.Text = _speakers[0].DisplayName;
            }

            // Add Destroying event handler
            Window.Destroying += Window_Destroying;

#if __ANDROID__ || (__IOS__ && !__MACCATALYST__)
            // Select second camera if available for mobile platforms
            if (_cameras.Length > 1)
            {
                btCamera.Text = _cameras[1].DisplayName;
                _cameraSelectedIndex = 1;
            }

            // Start preview
            btStartCapture.IsEnabled = true;
            await StartPreview();
#endif
        }

        /// <summary>
        /// Handles the Destroying event of the Window.
        /// Properly stops and disposes of the video capture core.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Window_Destroying(object? sender, EventArgs e)
        {
            if (_core != null)
            {
                _core.OnError -= Core_OnError;
                await _core.StopAsync();

                _core?.Dispose();
                _core = null;
            }

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Handles the OnError event of the video capture core.
        /// Logs error messages to the debug output.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VisioForge.Core.Types.Events.ErrorsEventArgs"/> instance containing the error information.</param>
        private void Core_OnError(object? sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        /// <summary>
        /// Asynchronously stops the current capture or preview session.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task StopAllAsync()
        {
            if (_core == null)
            {
                return;
            }

            if (_core != null)
            {
                await _core.StopAsync();
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the volume slider.
        /// Updates the audio output volume.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ValueChangedEventArgs"/> instance containing the event data.</param>
        private void slVolume_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            if (_core != null)
            {
                _core.Audio_OutputDevice_Volume = e.NewValue / 100.0;
            }
        }

#if __IOS__ && !__MACCATALYST__
        /// <summary>
        /// Adds a recorded video file to the iOS Photos library.
        /// </summary>
        /// <param name="filePath">The path to the video file to add.</param>
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
        /// Asynchronously stops the video capture recording.
        /// Saves the recorded video to the device's photo gallery on supported platforms.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task StopCaptureAsync()
        {
            System.Diagnostics.Debug.WriteLine("Stop capture");
            await _core.StopCaptureAsync(0);
            btStartCapture.BackgroundColor = _defaultButtonColor;
            btStartCapture.Text = "CAPTURE";

            // save video to photo library
#if __ANDROID__ || (__IOS__ && !__MACCATALYST__)
            string filename = null;
            var output = _core.Outputs_Get(0);
            filename = output.GetFilename();
            await PhotoGalleryHelper.AddVideoToGalleryAsync(filename);
#endif
        }

        /// <summary>
        /// Handles the Click event of the camera selection button.
        /// Cycles through available camera devices and restarts the preview.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btCamera_Clicked(object? sender, System.EventArgs e)
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

            btCamera.Text = _cameras[_cameraSelectedIndex].DisplayName;

#if __ANDROID__ || (__IOS__ && !__MACCATALYST__)
            await StopAllAsync();
            await StartPreview();
#endif
        }

        /// <summary>
        /// Handles the Click event of the microphone selection button.
        /// Cycles through available audio input devices.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btMic_Clicked(object? sender, System.EventArgs e)
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

            btMic.Text = _mics[_micSelectedIndex].DisplayName;
        }

        /// <summary>
        /// Handles the Click event of the speakers selection button.
        /// Cycles through available audio output devices.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btSpeakers_Clicked(object? sender, System.EventArgs e)
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

            btSpeakers.Text = _speakers[_speakerSelectedIndex].DisplayName;
        }

        /// <summary>
        /// Configures and starts the camera preview with the selected video and audio settings.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task StartPreview()
        {
            if (_core.State == PlaybackState.Play || _core.State == PlaybackState.Pause)
            {
                return;
            }

            // audio output
#if MOBILE
            _core.Audio_Play = false;
#else
            
            var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync()).Where(device => device.DisplayName == btSpeakers.Text).First();
            _core.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);
            _core.Audio_Play = true;
#endif

            // video source
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            var deviceName = btCamera.Text;
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
            videoSourceSettings.Orientation = IOSVideoSourceOrientation.LandscapeRight;
#endif

            if (videoSourceSettings == null)
            {
                await DisplayAlertAsync("Error", "Unable to configure camera settings", "OK");
            }

            // audio source
            IVideoCaptureBaseAudioSourceSettings audioSourceSettings = null;

            deviceName = btMic.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
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

            btStartPreview.Text = "STOP";
        }

        /// <summary>
        /// Generates a unique filename for the new video recording based on the current timestamp and platform-specific storage paths.
        /// </summary>
        /// <returns>The full path to the new video file.</returns>
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
            var filename = Path.Combine("/tmp", $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
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
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStartPreview_Clicked(object? sender, EventArgs e)
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

                        btStartPreview.Text = "PREVIEW";
                        btStartCapture.IsEnabled = false;
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
        /// Starts recording using the configured settings or stops the active recording.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStartCapture_Clicked(object? sender, EventArgs e)
        {
            if (_core == null || _core.State != PlaybackState.Play)
            {
                return;
            }

            if (btStartCapture.BackgroundColor != Colors.Red)
            {               
                System.Diagnostics.Debug.WriteLine("Start capture");
                await _core.StartCaptureAsync(0, GenerateFilename());
                btStartCapture.BackgroundColor = Colors.Red;
                btStartCapture.Text = "STOP";
            }
            else
            {
                await StopCaptureAsync();
            }
        }
    }
}
