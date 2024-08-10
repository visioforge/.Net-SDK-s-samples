
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
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.UI.Apple;

namespace SimpleVideoCaptureMB;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    private MediaBlocksPipeline _pipeline;

    private string _filename;

    private MediaBlock _videoRenderer;

    private MediaBlock _videoSource;

    private MediaBlock _audioSource;

    private MediaBlock _videoEncoder;

    private MediaBlock _audioEncoder;

    private MediaBlock _sink;

    private TeeBlock _videoTee;

    private int _cameraIndex = 0;

    private VideoCaptureDeviceInfo[] _cameras;

    private VideoView _videoView;

    public override UIWindow? Window { get; set; }

    private async Task CreateEngineAsync(bool capture)
    {
        _pipeline = new MediaBlocksPipeline();
        _pipeline.OnError += _pipeline_OnError;

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
            var formatItem = device.VideoFormats.First(x => x.Width == 1920 && x.Height == 1080);
            if (formatItem != null)
            {
                videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                {
                    Format = formatItem.ToFormat()
                };

                videoSourceSettings.Format.FrameRate = new VideoFrameRate(30);
            }
        }

        if (videoSourceSettings == null)
        {
            Toast.Show("Unable to configure camera settings", Window.RootViewController);
            return;
        }

        videoSourceSettings.Orientation = IOSVideoSourceOrientation.LandscapeRight;
        _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

        // create video tee
        _videoTee = new TeeBlock(2);

        // video renderer
        _videoRenderer = new VideoRendererBlock(_pipeline, _videoView as IVideoView);

        // connect video pads
        _pipeline.Connect(_videoSource.Output, _videoTee.Input);
        _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);

        // optional capture
        if (capture)
        {
            // video
            _videoEncoder = new H264EncoderBlock(new AppleMediaH264EncoderSettings());
            _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);

            var libraryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..",
                "Library");
            if (!Directory.Exists(libraryPath))
            {
                Directory.CreateDirectory(libraryPath);
            }

            var fileName = $"video_{DateTime.Now.Ticks}.mp4";
            _filename = Path.Combine(libraryPath, fileName);

            _sink = new MP4SinkBlock(new MP4SinkSettings(_filename));
            _pipeline.Connect(_videoEncoder.Output,(_sink as MP4SinkBlock).CreateNewInput(MediaBlockPadMediaType.Video));
        }
    }

    private void RequestPhotoLibraryPermissions(Action<PHAuthorizationStatus> completionHandler)
    {
        PHPhotoLibrary.RequestAuthorization((status) => { completionHandler(status); });
    }

    private async Task DestroyEngineAsync()
    {
        if (_pipeline != null)
        {
            _pipeline.OnError -= _pipeline_OnError;

            await _pipeline.DisposeAsync();
            _pipeline = null;
        }
    }

    private void _pipeline_OnError(object sender, ErrorsEventArgs e)
    {
        Debug.WriteLine(e.Message);
    }

    private void AddButtons(UIView parent)
    {
        // select camera
        var btSelectCamera = new UIButton(new CGRect(20, 20, 200, 70))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.All,
            VerticalAlignment = UIControlContentVerticalAlignment.Center,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Center
        };
        btSelectCamera.SetTitle("BACK", UIControlState.Normal);
        btSelectCamera.TouchUpInside += async (sender, e) =>
        {
            if (btSelectCamera.CurrentTitle == "BACK")
            {
                _cameraIndex = 1;
                btSelectCamera.SetTitle("FRONT", UIControlState.Normal);
            }
            else
            {
                _cameraIndex = 0;
                btSelectCamera.SetTitle("BACK", UIControlState.Normal);
            }
        };

        parent!.AddSubview(btSelectCamera);

        // start preview
        var btStartPreview = new UIButton(new CGRect(240, 20, 200, 70))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.All,
            VerticalAlignment = UIControlContentVerticalAlignment.Center,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Center
        };
        btStartPreview.SetTitle("START PREVIEW", UIControlState.Normal);
        btStartPreview.TouchUpInside += async (sender, e) =>
        {
            if (_pipeline != null)
            {
                await StopCamera();
                btStartPreview.SetTitle("START PREVIEW", UIControlState.Normal);
            }
            else
            {
                await StartPreview();
                btStartPreview.SetTitle("STOP PREVIEW", UIControlState.Normal);
            }
        };

        parent!.AddSubview(btStartPreview);

        // start capture
        var btStartCapture = new UIButton(new CGRect(460, 20, 200, 70))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.All,
            VerticalAlignment = UIControlContentVerticalAlignment.Center,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Center
        };
        btStartCapture.SetTitle("START CAPTURE", UIControlState.Normal);
        btStartCapture.TouchUpInside += async (sender, e) =>
        {
            if (_pipeline != null)
            {
                await StopCamera();
                btStartCapture.SetTitle("START CAPTURE", UIControlState.Normal);
            }
            else
            {
                await StartCapture();
                btStartCapture.SetTitle("STOP CAPTURE", UIControlState.Normal);
            }
        };

        parent!.AddSubview(btStartCapture);
    }

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

    private async Task StopCamera()
    {
        if (_pipeline == null)
        {
            return;
        }

        // var dot = _pipeline.Debug_GetPipeline();

        await _pipeline.StopAsync();

        await DestroyEngineAsync();

        // we need to share videoto Photos library
        if (!string.IsNullOrEmpty(_filename))
        {
            Thread.Sleep(1000);

            InvokeOnMainThread(() =>
            {
                SaveVideoToPhotoLibrary(_filename);
                _filename = null;
            });
        }
    }

    private async Task StartPreview()
    {
        await StopCamera();

        await CreateEngineAsync(false);

        await _pipeline.StartAsync();
    }

    private async Task StartCapture()
    {
        await StopCamera();

        await CreateEngineAsync(true);

        await _pipeline.StartAsync();
    }

    private void CreateVideoView(UIView view)
    {
        var rect = new CGRect(0, 0, Window!.Frame.Width, Window!.Frame.Height);
        _videoView = new VideoView(rect);

        view!.AddSubview(_videoView);
    }

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

        return true;
    }
}