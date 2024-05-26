using Photos;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using VisioForge.Core;
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

namespace MobileStreamer;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    private const string SRT_URL = "srt://:8888";
    
    private string RTMP_URL = "";
    
    private MediaBlocksPipeline _pipeline;

    private MediaBlock _videoRenderer;

    private MediaBlock _videoSource;

    private MediaBlock _audioSource;

    private H264EncoderBlock _videoEncoder;

    private MediaBlock _audioEncoder;

    private MediaBlock _sink;

    private TeeBlock _videoTee;

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

        var viewBack = new UIView(new CGRect(83, 0, 300, 100));
        viewBack.BackgroundColor = UIColor.Black;
        viewBack.Tag = 1989;
        UILabel lblMsg = new UILabel(new CGRect(0, 20, 300, 60));
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
        _pipeline.Connect(_videoEncoder.Output, (_sink as SRTMPEGTSSinkBlock).CreateNewInput(MediaBlockPadMediaType.Video));
        _pipeline.Connect(_audioEncoder.Output, (_sink as SRTMPEGTSSinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio));
    }
    
    private void AddRTMPSink()
    {
        // video encoder
        _videoEncoder = new H264EncoderBlock(new AppleMediaH264EncoderSettings());
        _videoEncoder.Settings.ParseStream = false; // we have to disable parsing for SRT for H264 and HEVC encoders
        _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);
        
        // audio encoder
        _audioEncoder = new MP3EncoderBlock(new MP3EncoderSettings());
        _pipeline.Connect(_audioSource.Output, _audioEncoder.Input);
        
        // sink
        _sink = new RTMPSinkBlock(new RTMPSinkSettings() { Location = RTMP_URL });
        _pipeline.Connect(_videoEncoder.Output, (_sink as RTMPSinkBlock).CreateNewInput(MediaBlockPadMediaType.Video));
        _pipeline.Connect(_audioEncoder.Output, (_sink as RTMPSinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio));
    }

    private async Task CreateEngineAsync()
    {
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
        
                videoSourceSettings.Format.FrameRate = new VideoFrameRate(120);
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

        // start RTMP
        var btStartRTMP = new UIButton(new CGRect(240, 20, 200, 70))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.All,
            VerticalAlignment = UIControlContentVerticalAlignment.Bottom,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Left
        };
        btStartRTMP.SetTitle("START RTMP", UIControlState.Normal);
        btStartRTMP.TouchUpInside += async (sender, e) =>
        {
            if (_pipeline != null)
            {
                await StopCamera();
                btStartRTMP.SetTitle("START RTMP", UIControlState.Normal);
            }
            else
            {
                RTMP_URL = "rtmp://localhost/live/stream";
                if (string.IsNullOrEmpty(RTMP_URL))
                {
                    ShowToast(this.Window, "RTMP URL is empty. Please set it in code.");
                    return;
                }
                
                await CreateEngineAsync();
                
                AddRTMPSink();

                await _pipeline.StartAsync();
                
                btStartRTMP.SetTitle("STOP RTMP", UIControlState.Normal);
            }
        };

        parent!.AddSubview(btStartRTMP);

        // start SRT
        var btStartSRT = new UIButton(new CGRect(460, 20, 200, 70))
        {
            BackgroundColor = UIColor.Gray,
            AutoresizingMask = UIViewAutoresizing.All,
            VerticalAlignment = UIControlContentVerticalAlignment.Bottom,
            HorizontalAlignment = UIControlContentHorizontalAlignment.Left
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
                    ShowToast(Window, msg);
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

        await _pipeline.StopAsync();

        await DestroyEngineAsync();
    }

    private void CreateVideoView(UIView view)
    {
        if (_videoView != null)
        {
            _videoView.RemoveFromSuperview();
            _videoView.Dispose();
            _videoView = null;
        }

        var rect = new CGRect(0, 100, Window!.Frame.Width, Window!.Frame.Height );
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

        Window.RootViewController = vc;

        Window.MakeKeyAndVisible();

        VisioForgeX.InitSDK();

        return true;
    }
}

