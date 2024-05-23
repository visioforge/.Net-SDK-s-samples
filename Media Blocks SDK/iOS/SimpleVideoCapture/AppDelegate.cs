using Photos;
using System.Diagnostics;
using System.Runtime.InteropServices;

using VisioForge.Core;
using VisioForge.Core.GStreamer.Helpers;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.UI.Apple;

namespace SimpleVideoCapture;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {

    private MediaBlocksPipeline _pipeline;

    private string _filename;

    private MediaBlock _videoRenderer;

    private MediaBlock _audioRenderer;

    private MediaBlock _videoSource;

    private MediaBlock _audioSource;

    private MediaBlock _videoEncoder;

    private MediaBlock _audioEncoder;

    private MediaBlock _sink;

    private TeeBlock _videoTee;

    private TeeBlock _audioTee;

    private int _cameraIndex = 0;

    private VideoCaptureDeviceInfo[] _cameras;

    private UIView _videoView;

    public override UIWindow? Window {
		get;
		set;
	}

    private void ShowToast(UIView view, string message)
    {
        UIView residualView = view.ViewWithTag(1989);
        if (residualView != null)
            residualView.RemoveFromSuperview();

        var viewBack = new UIView(new CoreGraphics.CGRect(83, 0, 300, 100));
        viewBack.BackgroundColor = UIColor.Black;
        viewBack.Tag = 1989;
        UILabel lblMsg = new UILabel(new CoreGraphics.CGRect(0, 20, 300, 60));
        lblMsg.Lines = 2;
        lblMsg.Text = message;
        lblMsg.TextColor = UIColor.White;
        lblMsg.TextAlignment = UITextAlignment.Center;
        viewBack.Center = view.Center;
        viewBack.AddSubview(lblMsg);
        view.AddSubview(viewBack);
        UIView.BeginAnimations("Toast");
        UIView.SetAnimationDuration(3.0f);
        viewBack.Alpha = 0.0f;
        UIView.CommitAnimations();
    }

    private async Task CreateEngineAsync(bool capture)
    {
        //var elements = ElementEnumerator.GetAllElements();
        //foreach (var el in elements)
        //{
        //    Debug.WriteLine(el.Item1 + " | " + el.Item2);
        //}

        _pipeline = new MediaBlocksPipeline(true);
        _pipeline.OnError += _pipeline_OnError;

        // video source
        if (_cameras == null)
        {
            _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
        }

        if (_cameras.Length == 0)
        {
            ShowToast(Window, "No video sources found");
            return;
        }

        VideoCaptureDeviceSourceSettings videoSourceSettings = null;

        if (_cameraIndex >= _cameras.Length)
        {
            _cameraIndex = 1;
        }

        var device = _cameras[_cameraIndex];
        if (device != null)
        {
            var formatItem = device.VideoFormats.First(x => x.Width == 1920);
            if (formatItem != null)
            {
                videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                {
                    Format = formatItem.ToFormat()
                };

                videoSourceSettings.Format.FrameRate = new VideoFrameRate(60);
            }
        }

        if (videoSourceSettings == null)
        {
            ShowToast(Window, "Unable to configure camera settings");
            return;
        }

        videoSourceSettings.Orientation = IOSVideoSourceOrientation.Portrait;
        _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

        // create video tee
        _videoTee = new TeeBlock(2);

        // video renderer
        _videoRenderer = new VideoRendererBlock(_pipeline, _videoView as IVideoView);
           
        // connect video pads
        _pipeline.Connect(_videoSource.Output, _videoTee.Input);
        _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);

        // audio source
        _audioSource = new SystemAudioSourceBlock(new IOSAudioSourceSettings());

        // create audio tee
        _audioTee = new TeeBlock(2);

        // audio renderer
        _audioRenderer = new IOSAudioSinkBlock(new VisioForge.Core.Types.X.AudioInfoX(VisioForge.Core.Types.X.AudioFormatX.S16LE, 44100, 2));
        
        _pipeline.Connect(_audioSource.Output, _audioTee.Input);
        _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);

        // optional capture
        if (capture)
        {
            _videoEncoder = new H264EncoderBlock(new AppleMediaH264EncoderSettings());
            _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);

            var libraryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library");
            if (!Directory.Exists(libraryPath))
            {
                Directory.CreateDirectory(libraryPath);
            }

            var fileName = $"video_{DateTime.Now.Ticks}.mp4";
            _filename = Path.Combine(libraryPath, fileName);

            _sink = new MP4SinkBlock(new MP4SinkSettings(_filename));
            _pipeline.Connect(_videoEncoder.Output, (_sink as MP4SinkBlock).CreateNewInput(MediaBlockPadMediaType.Video));

            // _audioEncoder = new MP3EncoderBlock(new MP3EncoderSettings());
            _audioEncoder = new OPUSEncoderBlock(new OPUSEncoderSettings());
            _pipeline.Connect(_audioTee.Outputs[1], _audioEncoder.Input);
            _pipeline.Connect(_audioEncoder.Output, (_sink as MP4SinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio));
        }
    }

    private void RequestPhotoLibraryPermissions(Action<PHAuthorizationStatus> completionHandler)
    {
        PHPhotoLibrary.RequestAuthorization((status) =>
        {
            completionHandler(status);
        });
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
        var btSelectCamera = new UIButton(new CGRect(20, 20, 200, 50))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.All,
            VerticalAlignment = UIControlContentVerticalAlignment.Bottom,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Left
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
        var btStartPreview = new UIButton(new CGRect(240, 20, 200, 50))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.All,
            VerticalAlignment = UIControlContentVerticalAlignment.Bottom,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Left
        };
        btStartPreview.SetTitle("START PREVIEW", UIControlState.Normal);
        btStartPreview.TouchUpInside += async (sender, e) =>
        {
            await StartPreview();
        };

        parent!.AddSubview(btStartPreview);

        // start capture
        var btStartCapture = new UIButton(new CGRect(460, 20, 200, 50))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.All,
            VerticalAlignment = UIControlContentVerticalAlignment.Bottom,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Left
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

    public void SaveVideoToPhotoLibrary(string filePath)
    {
        PHPhotoLibrary.SharedPhotoLibrary.PerformChanges(() =>
        {
            PHAssetCreationRequest creationRequest = PHAssetCreationRequest.CreationRequestForAsset();
            creationRequest.AddResource(PHAssetResourceType.Video, NSUrl.FromFilename(filePath), null);
        }, (success, error) =>
        {
            if (success)
            {
                // Video was successfully saved in the photo library
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
        if (_videoView != null)
        {
            _videoView.RemoveFromSuperview();
            _videoView.Dispose();
            _videoView = null;
        }

        var rect = new CGRect(0, 50, Window!.Frame.Width, Window!.Frame.Height - 50);
        _videoView = new VideoViewGL(rect);

        view!.AddSubview(_videoView);
    }

    public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
		// create a new window instance based on the screen size
		Window = new UIWindow (UIScreen.MainScreen.Bounds);

		// create a UIViewController with a single UILabel
		var vc = new UIViewController ();

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

        //InvokeOnMainThread(async () =>
        //{
        //    Thread.Sleep(500);

        //    await StartPreview();
        //});

        return true;
    }
}

