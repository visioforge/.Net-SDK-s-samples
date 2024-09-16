using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;

using VisioForge.Core;
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
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.UI.Apple;

namespace MobileStreamer;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    private const string SRT_URL = "srt://:8888";

    private string FACEBOOK_LIVE_KEY = "";

    private string YOUTUBE_LIVE_KEY = "";

    private MediaBlocksPipeline _pipeline;

    private VideoRendererBlock _videoRenderer;

    private MediaBlock _videoSource;

    private MediaBlock _audioSource;

    private H264EncoderBlock _videoEncoder;

    private MediaBlock _audioEncoder;

    private MediaBlock _sink;

    private TeeBlock _videoTee;

    private int _cameraIndex = 1;

    private VideoCaptureDeviceInfo[] _cameras;

    private VideoViewGL _videoView;

    public override UIWindow? Window { get; set; }

    public string GetLocalIpAddress()
    {
        foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
            {
                foreach (var addressInfo in networkInterface.GetIPProperties().UnicastAddresses)
                {
                    if (addressInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return addressInfo.Address.ToString();
                    }
                }
            }
        }

        return string.Empty;
    }

    private void AddSRTSink()
    {
        // video encoder
        _videoEncoder = new H264EncoderBlock(new AppleMediaH264EncoderSettings());
        _videoEncoder.Settings.ParseStream = false; // we have to disable parsing for SRT for H264 and HEVC encoders
        _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);

        // audio encoder
        _audioEncoder = new OPUSEncoderBlock(new OPUSEncoderSettings());
        _pipeline.Connect(_audioSource.Output, _audioEncoder.Input);

        // sink
        _sink = new SRTMPEGTSSinkBlock(new SRTSinkSettings() { Uri = SRT_URL });
        _pipeline.Connect(_videoEncoder.Output,
            (_sink as SRTMPEGTSSinkBlock).CreateNewInput(MediaBlockPadMediaType.Video));
        _pipeline.Connect(_audioEncoder.Output,
            (_sink as SRTMPEGTSSinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio));
    }

    private void AddFacebookSink()
    {
        // video encoder
        _videoEncoder = new H264EncoderBlock(new AppleMediaH264EncoderSettings());
        _videoEncoder.Settings.ParseStream = false; // we have to disable parsing for SRT for H264 and HEVC encoders
        _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);

        // audio encoder
        _audioEncoder = new AACEncoderBlock();
        _pipeline.Connect(_audioSource.Output, _audioEncoder.Input);

        // sink
        _sink = new FacebookLiveSinkBlock(new FacebookLiveSinkSettings(FACEBOOK_LIVE_KEY));
        _pipeline.Connect(_videoEncoder.Output, (_sink as FacebookLiveSinkBlock).CreateNewInput(MediaBlockPadMediaType.Video));
        _pipeline.Connect(_audioEncoder.Output, (_sink as FacebookLiveSinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio));
    }
    
    private void AddYouTubeSink()
    {
        // video encoder
        _videoEncoder = new H264EncoderBlock(new AppleMediaH264EncoderSettings());
        _videoEncoder.Settings.ParseStream = false; // we have to disable parsing for SRT for H264 and HEVC encoders
        _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);

        // audio encoder
        _audioEncoder = new AACEncoderBlock();
        _pipeline.Connect(_audioSource.Output, _audioEncoder.Input);

        // sink
        _sink = new YouTubeSinkBlock(new YouTubeSinkSettings(YOUTUBE_LIVE_KEY));
        _pipeline.Connect(_videoEncoder.Output, (_sink as YouTubeSinkBlock).CreateNewInput(MediaBlockPadMediaType.Video));
        _pipeline.Connect(_audioEncoder.Output, (_sink as YouTubeSinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio));
    }

    private async Task CreateEngineAsync()
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
        _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

        // video renderer
        _videoRenderer = new VideoRendererBlock(_pipeline, _videoView as IVideoView) { IsSync = false };
        _videoRenderer.IsSync = false;

        // connect video pads
        _pipeline.Connect(_videoSource.Output, _videoTee.Input);
        _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);

        // audio source
        _audioSource = new SystemAudioSourceBlock(new IOSAudioSourceSettings());
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

        // start Facebook
        var btStartFacebook = new UIButton(new CGRect(240, 20, 200, 50))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.All,
            VerticalAlignment = UIControlContentVerticalAlignment.Center,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Center
        };
        btStartFacebook.SetTitle("START FACEBOOK", UIControlState.Normal);
        btStartFacebook.TouchUpInside += async (sender, e) =>
        {
            if (_pipeline != null)
            {
                await StopCamera();
                btStartFacebook.SetTitle("START FACEBOOK", UIControlState.Normal);
            }
            else
            {
                if (string.IsNullOrEmpty(FACEBOOK_LIVE_KEY))
                {
                    Toast.Show("Facebook Live Key is empty. Please set it in code.", Window.RootViewController);
                    return;
                }
            
                await CreateEngineAsync();
            
                AddFacebookSink();
            
                await _pipeline.StartAsync();
            
                btStartFacebook.SetTitle("STOP FACEBOOK", UIControlState.Normal);
            }
        };

        parent!.AddSubview(btStartFacebook);
        
        // start YouTube 
        var btStartYouTube = new UIButton(new CGRect(460, 20, 200, 50))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.All,
            VerticalAlignment = UIControlContentVerticalAlignment.Center,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Center
        };
        btStartYouTube.SetTitle("START YOUTUBE", UIControlState.Normal);
        btStartYouTube.TouchUpInside += async (sender, e) =>
        {
            if (_pipeline != null)
            {
                await StopCamera();
                btStartYouTube.SetTitle("START YOUTUBE", UIControlState.Normal);
            }
            else
            {
                if (string.IsNullOrEmpty(YOUTUBE_LIVE_KEY))
                {
                    Toast.Show("YouTube Live Key is empty. Please set it in code.", Window.RootViewController);
                    return;
                }

                await CreateEngineAsync();

                AddYouTubeSink();

                await _pipeline.StartAsync();

                btStartYouTube.SetTitle("STOP YOUTUBE", UIControlState.Normal);
            }
        };

        parent!.AddSubview(btStartYouTube);

        // start SRT
        var btStartSRT = new UIButton(new CGRect(680, 20, 200, 50))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.All,
            VerticalAlignment = UIControlContentVerticalAlignment.Center,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Center
        };
        btStartSRT.SetTitle("START SRT", UIControlState.Normal);
        btStartSRT.TouchUpInside += async (sender, e) =>
        {
            if (_pipeline != null)
            {
                await StopCamera();
                btStartSRT.SetTitle("START SRT", UIControlState.Normal);
            }
            else
            {
                await CreateEngineAsync();

                AddSRTSink();

                await _pipeline.StartAsync();

                var ip = GetLocalIpAddress();
                if (!string.IsNullOrEmpty(ip))
                {
                    var msg = "SRT URL: srt://" + ip + ":8888";
                    Debug.WriteLine(msg);
                    Toast.Show(msg, Window.RootViewController);
                }

                btStartSRT.SetTitle("STOP SRT", UIControlState.Normal);
            }
        };

        parent!.AddSubview(btStartSRT);
    }

    private async Task StopCamera()
    {
        if (_pipeline == null)
        {
            return;
        }

        await _pipeline.StopAsync(true);

        await DestroyEngineAsync();
    }

    private void AddVideoView(UIView view)
    {
        var rect = new CGRect(0, 0, Window!.Frame.Width, Window!.Frame.Height);
        _videoView = new VideoViewGL(rect);

        view!.AddSubview(_videoView);
    }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        // create a UIViewController with a single UILabel
        var vc = new UIViewController();

        AddVideoView(vc.View);

        AddButtons(vc.View);

        Window.RootViewController = vc;

        Window.MakeKeyAndVisible();

        VisioForgeX.InitSDK();

        return true;
    }
}