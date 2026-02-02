using AudioToolbox;
using Photos;
using System.Diagnostics;
using VisioForge.Core;
using VisioForge.Core.GStreamer.Helpers;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioProcessing;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.Special;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.UI.Apple;
using VisioForge.Core.VideoCaptureX;

namespace SimpleVideoCaptureMB;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    private VideoCaptureCoreX _player;

    private string _filename;

    private int _cameraIndex = 1;

    private VideoCaptureDeviceInfo[] _cameras;

    private UIView _videoView;

    private UIButton _btSelectCamera;

    private UIButton _btStartCapture;

    public override UIWindow? Window { get; set; }

        /// <summary>
        /// Create engine async.
        /// </summary>
    private async Task CreateEngineAsync()
    {
        try
        {
            _player = new VideoCaptureCoreX(_videoView as IVideoView);
            _player.OnError += PlayerOnError;
            _player.OnOutputStopped += (sender, e) =>
            {
                // we need to share video to Photos library
                if (!string.IsNullOrEmpty(_filename))
                {
                    Thread.Sleep(500);

                    InvokeOnMainThread(() =>
                    {
                        SaveVideoToPhotoLibrary(_filename);
                        _filename = null;
                    });
                }
            };

            // video source
            if (_cameras == null)
            {
                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
            }

            if (_cameras.Length == 0)
            {
                Toast.Show("No video sources found", Window.RootViewController);
                return;
            }

            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            if (_cameraIndex >= _cameras.Length)
            {
                _cameraIndex = 0;
            }

            var device = _cameras[_cameraIndex];
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

            if (videoSourceSettings == null)
            {
                Toast.Show("Unable to configure camera settings", Window.RootViewController);
                return;
            }

            videoSourceSettings.Orientation = IOSVideoSourceOrientation.LandscapeRight;

            _player.Video_Source = videoSourceSettings;

            _player.Outputs_Clear();

            // configure audio source
            //_pipeline.Audio_Source = new IOSAudioSourceSettings();

            // configure encoders
            var videoEncoder = new AppleMediaH264EncoderSettings();
           // var audioEncoder = new VOAACEncoderSettings();
            
            GenerateFilename();
            var mp4Output = new MP4Output(_filename, videoEncoder, null);//audioEncoder);

            _player.Outputs_Add(mp4Output, autostart:  false);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

        /// <summary>
        /// Request photo library permissions.
        /// </summary>
    private void RequestPhotoLibraryPermissions(Action<PHAuthorizationStatus> completionHandler)
    {
        PHPhotoLibrary.RequestAuthorization((status) => { completionHandler(status); });
    }

        /// <summary>
        /// Destroy engine async.
        /// </summary>
    private async Task DestroyEngineAsync()
    {
        if (_player != null)
        {
            _player.OnError -= PlayerOnError;

            await _player.DisposeAsync();
            _player = null;
        }
    }

        /// <summary>
        /// Player on error.
        /// </summary>
    private void PlayerOnError(object sender, ErrorsEventArgs e)
    {
        Debug.WriteLine(e.Message);
    }

        /// <summary>
        /// Add buttons.
        /// </summary>
    private void AddButtons(UIView parent)
    {
        // select camera
        _btSelectCamera = new UIButton(new CGRect(10, 0, 150, 50))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.All,
            VerticalAlignment = UIControlContentVerticalAlignment.Center,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Center
        };
        _btSelectCamera.SetTitle("FRONT", UIControlState.Normal);
        _btSelectCamera.TouchUpInside += async (sender, e) =>
        {
            if (_player != null)
            {
                await StopCamera();
            }

            if (_btSelectCamera.CurrentTitle == "BACK")
            {
                _cameraIndex = 1;
                _btSelectCamera.SetTitle("FRONT", UIControlState.Normal);
            }
            else
            {
                _cameraIndex = 0;
                _btSelectCamera.SetTitle("BACK", UIControlState.Normal);
            }

            _btStartCapture?.SetTitle("START CAPTURE", UIControlState.Normal);

            await StartAsync();
        };

        parent!.AddSubview(_btSelectCamera);

        // start capture
        _btStartCapture = new UIButton(new CGRect(170, 00, 200, 50))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.All,
            VerticalAlignment = UIControlContentVerticalAlignment.Center,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Center
        };
        _btStartCapture.SetTitle("START CAPTURE", UIControlState.Normal);
        _btStartCapture.TouchUpInside += async (sender, e) =>
        {
            if (_player == null)
            {
                return;
            }

            if (_btStartCapture.CurrentTitle == "STOP CAPTURE")
            {
                _btStartCapture.SetTitle("START CAPTURE", UIControlState.Normal);

                await _player.StopCaptureAsync(0);
            }
            else
            { 
                _btStartCapture.SetTitle("STOP CAPTURE", UIControlState.Normal);
                
                GenerateFilename();
                await _player.StartCaptureAsync(0, _filename);
            }
        };

        parent!.AddSubview(_btStartCapture);
    }

        /// <summary>
        /// Save video to photo library.
        /// </summary>
    private void SaveVideoToPhotoLibrary(string filePath)
    {
        PHPhotoLibrary.SharedPhotoLibrary.PerformChanges(() =>
        {
            PHAssetCreationRequest creationRequest = PHAssetCreationRequest.CreationRequestForAsset();
            creationRequest.AddResource(PHAssetResourceType.Video, NSUrl.FromFilename(filePath), null);
        }, (success, error) =>
        {
            if (success)
            {
                Debug.WriteLine("Video was successfully saved in the photo library");
            }
            else
            {
                // Handle errors here
            }
        });
    }

        /// <summary>
        /// Stop camera.
        /// </summary>
    private async Task StopCamera()
    {
        if (_player == null)
        {
            return;
        }

        if (_player.IsCaptureStarted(0))
        {
            await _player.StopCaptureAsync(0);
        }
        
        await _player.StopAsync();

        await DestroyEngineAsync();
    }

        /// <summary>
        /// Start async.
        /// </summary>
    private async Task StartAsync()
    {
        await StopCamera();

        await CreateEngineAsync();

        await _player.StartAsync();
    }

        /// <summary>
        /// Create video view.
        /// </summary>
    private void CreateVideoView(UIView view)
    {
        var rect = new CGRect(0, 0, Window!.Frame.Width, Window!.Frame.Height);
        _videoView = new VideoView(rect);

        view!.AddSubview(_videoView);
    }

        /// <summary>
        /// Generate filename.
        /// </summary>
    private void GenerateFilename()
    {
        // get the file name
        var libraryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..",
            "Library");
        if (!Directory.Exists(libraryPath))
        {
            Directory.CreateDirectory(libraryPath);
        }

        var fileName = $"video_{DateTime.Now.Ticks}.mp4";
        _filename = Path.Combine(libraryPath, fileName);
    }

        /// <summary>
        /// Finished launching.
        /// </summary>
    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        // create a UIViewController with a single UILabel
        var vc = new UIViewController();

        CreateVideoView(vc.View);

        AddButtons(vc.View);

        RequestPhotoLibraryPermissions((status) =>
        {
            if (status == PHAuthorizationStatus.Authorized)
            {
                // The app has permission to access the photo library
                // Proceed with saving the video or other tasks
            }
            else
            {
                // Handle the case where permission is denied
            }
        });

        Window.RootViewController = vc;

        Window.MakeKeyAndVisible();

        VisioForgeX.InitSDK();

        // start preview in UI thread
        InvokeOnMainThread(async () => { await StartAsync(); });

        return true;
    }
}