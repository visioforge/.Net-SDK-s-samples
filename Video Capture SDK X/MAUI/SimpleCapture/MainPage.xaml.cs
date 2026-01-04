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

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;

            this.BindingContext = this;
        }

        private void MainPage_Unloaded(object? sender, EventArgs e)
        {
            // Dispose core object
            _core?.Dispose();
            _core = null;

            // Destroy SDK
            VisioForgeX.DestroySDK();
        }

#if __IOS__ && !__MACCATALYST__
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

        private void Core_OnError(object? sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

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

        private void slVolume_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            if (_core != null)
            {
                _core.Audio_OutputDevice_Volume = e.NewValue / 100.0;
            }
        }

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
