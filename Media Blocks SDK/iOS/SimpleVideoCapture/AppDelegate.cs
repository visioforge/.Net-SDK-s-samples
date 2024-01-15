using AVFoundation;
using Photos;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UIKit;
using VisioForge.Core;
using VisioForge.Core.GStreamer.Base;
using VisioForge.Core.GStreamer.Helpers;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioRendering;
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
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.UI.Apple;

namespace SimpleVideoCapture;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {

    private DeviceEnumerator _deviceEnumerator;

    private MediaBlocksPipeline _pipeline;

    private string _filename;

    private MediaBlock _videoRenderer;

    private MediaBlock _audioRenderer;

    private MediaBlock _videoSource;

    private MediaBlock _videoEffect;

    private MediaBlock _audioSource;

    private MediaBlock _videoEncoder;

    private MediaBlock _audioEncoder;

    private MediaBlock _sink;

    private TeeBlock _videoTee;

    private TeeBlock _audioTee;

    private BufferSinkBlock _videoSampleGrabberSink;

    private BufferSinkBlock _audioSampleGrabberSink;

    private int _cameraIndex = 0;

    private VideoCaptureDeviceInfo[] _cameras;

    private bool _isPreview;

    private VideoView _videoView;

   // private SoundRecorder _recorder;

    //private CustomImageView _videoView;

    private BufferSinkBlock _audioSampleGrabber;

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
        MediaBlocksPipeline.InitSDK();

        if (_deviceEnumerator == null)
        {
            _deviceEnumerator = new DeviceEnumerator();
        }

        _pipeline = new MediaBlocksPipeline();
        _pipeline.OnError += _pipeline_OnError;

        // video source
        if (_cameras == null)
        {
            _cameras = await _deviceEnumerator.VideoSourcesAsync();
        }

        if (_cameras.Length == 0)
        {
            ShowToast(Window, "No video sources found");
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
            var formatItem = device.GetHDOrAnyVideoFormatAndFrameRate(out var frameRate);
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
            ShowToast(Window, "Unable to configure camera settings");
            return;
        }

        _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

        // create video tee
        _videoTee = new TeeBlock(3);

        // video renderer
        _videoRenderer = new VideoRendererBlock(_pipeline, _videoView);

        // sample video effect
        _videoEffect = new GrayscaleBlock();

        // create video sample grabber
        _videoSampleGrabberSink = new BufferSinkBlock();
        _videoSampleGrabberSink.OnVideoFrameBuffer += _videoSampleGrabber_OnVideoFrameBuffer;

        // connect video pads
        _pipeline.Connect(_videoSource.Output, _videoEffect.Input);
        _pipeline.Connect(_videoEffect.Output, _videoTee.Input);
        _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
        _pipeline.Connect(_videoTee.Outputs[1], _videoSampleGrabberSink.Input);

        // audio source
        _audioSource = new SystemAudioSourceBlock(new IOSAudioSourceSettings());

        // create audio tee
        _audioTee = new TeeBlock(3);

        // audio renderer
        _audioRenderer = new IOSAudioSinkBlock(new VisioForge.Core.Types.X.AudioInfoX(VisioForge.Core.Types.X.AudioFormatX.S16LE, 44100, 2));

        // audio sample grabber
        _audioSampleGrabberSink = new BufferSinkBlock();
        _audioSampleGrabberSink.OnAudioFrameBuffer += _audioSampleGrabber_OnAudioFrameBuffer;

        _pipeline.Connect(_audioSource.Output, _audioTee.Input);
        _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);
        _pipeline.Connect(_audioTee.Outputs[1], _audioSampleGrabberSink.Input);

        // optional capture
        if (capture)
        {
            _videoEncoder = new H264EncoderBlock(new AppleMediaH264EncoderSettings());
            _pipeline.Connect(_videoTee.Outputs[2], _videoEncoder.Input);

            var libraryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library");
            if (!Directory.Exists(libraryPath))
            {
                Directory.CreateDirectory(libraryPath);
            }

            var fileName = $"video_{DateTime.Now.Ticks}.mp4";
            _filename = Path.Combine(libraryPath, fileName);

            _sink = new MP4SinkBlock(new MP4SinkSettings(_filename));
            _pipeline.Connect(_videoEncoder.Output, (_sink as MP4SinkBlock).CreateNewInput(MediaBlockPadMediaType.Video));

            _audioEncoder = new MP3EncoderBlock(new MP3EncoderSettings());
            _pipeline.Connect(_audioTee.Outputs[2], _audioEncoder.Input);
            _pipeline.Connect(_audioEncoder.Output, (_sink as MP4SinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio));
        }
    }

    private void _audioSampleGrabber_OnAudioFrameBuffer(object sender, AudioFrameBufferEventArgs e)
    {
        // received new audio frame
        var data = new byte[e.Frame.DataSize];
        Marshal.Copy(e.Frame.Data, data, 0, e.Frame.DataSize);
    }

    private void _videoSampleGrabber_OnVideoFrameBuffer(object sender, VideoFrameXBufferEventArgs e)
    {
        // received new video frame
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
        // start preview
        var btStartPreview = new UIButton(new CGRect(20, 20, 200, 50))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.All,
            VerticalAlignment = UIControlContentVerticalAlignment.Bottom,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Left
        };
        btStartPreview.SetTitle("START CAPTURE", UIControlState.Normal);
        btStartPreview.TouchUpInside += async (sender, e) => 
        {
            await StartCapture();
        };

        parent!.AddSubview(btStartPreview);

        // switch camera
        var btSwitchCamera = new UIButton(new CGRect(240, 20, 200, 50))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.All,
            VerticalAlignment = UIControlContentVerticalAlignment.Bottom,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Left
        };
        btSwitchCamera.SetTitle("SWITCH CAMERA", UIControlState.Normal);
        btSwitchCamera.TouchUpInside += async (sender, e) =>
        {
            if (_cameraIndex == 0)
            {
                _cameraIndex = 1;
            }
            else
            {
                _cameraIndex = 0;
            }

            await StartPreview();
        };

        parent!.AddSubview(btSwitchCamera);

        // test button camera
        var btTest = new UIButton(new CGRect(460, 20, 200, 50))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.All,
            VerticalAlignment = UIControlContentVerticalAlignment.Bottom,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Left
        };
        btTest.SetTitle("STOP", UIControlState.Normal);
        btTest.TouchUpInside += async (sender, e) =>
        {
            await StopCamera();
        };

        parent!.AddSubview(btTest);
    }

    private async Task TestAsync()
    {
        await _pipeline.StopAsync();

        //_player = new StreamAudioPlayer();
        //_player.Start();

        //var data = new byte[1024 * 1024];
        //Random.Shared.NextBytes(data);

        //_player.PushData(data);

        //_testPlayer = new AppSrcTest();
        //_testPlayer.Start();

      //    _testSource = new AudioSourceTest();
      //    await _testSource.StartAsync();

        //   _recorder = new SoundRecorder(48000, 2);
        //  _recorder.StartRecording();

        Thread.Sleep(1000);

        InvokeOnMainThread(() =>
        {
            SaveVideoToPhotoLibrary(_filename); 
        });        
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
        _videoView = new VideoView(rect);

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

        InvokeOnMainThread(async () =>
        {
            Thread.Sleep(500);

            await StartPreview();
        });

        return true;
    }
}

