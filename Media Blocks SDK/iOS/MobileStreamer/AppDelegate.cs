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
    // Persisted per-protocol user input (NSUserDefaults keys).
    private const string PREF_SRT_URL   = "pref_srt_url";
    private const string PREF_YT_KEY    = "pref_youtube_key";
    private const string PREF_FB_KEY    = "pref_facebook_key";

    // Default shown in the SRT prompt on first launch: listen on port 8888.
    private const string DEFAULT_SRT_URL = "srt://:8888";

    // Remembered between stream starts; filled via the prompt.
    private string _srtUrl;
    private string _youTubeKey;
    private string _facebookKey;

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

    private VideoView _videoView;

    public override UIWindow? Window { get; set; }

        /// <summary>
        /// Get local ip address.
        /// </summary>
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

        /// <summary>
        /// Add srt sink.
        /// </summary>
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
        _sink = new SRTMPEGTSSinkBlock(new SRTSinkSettings() { Uri = _srtUrl });
        _pipeline.Connect(_videoEncoder.Output,
            (_sink as SRTMPEGTSSinkBlock).CreateNewInput(MediaBlockPadMediaType.Video));
        _pipeline.Connect(_audioEncoder.Output,
            (_sink as SRTMPEGTSSinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio));
    }

        /// <summary>
        /// Add facebook sink.
        /// </summary>
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
        _sink = new FacebookLiveSinkBlock(new FacebookLiveSinkSettings(_facebookKey));
        _pipeline.Connect(_videoEncoder.Output, (_sink as FacebookLiveSinkBlock).CreateNewInput(MediaBlockPadMediaType.Video));
        _pipeline.Connect(_audioEncoder.Output, (_sink as FacebookLiveSinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio));
    }
    
        /// <summary>
        /// Add you tube sink.
        /// </summary>
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
        _sink = new YouTubeSinkBlock(new YouTubeSinkSettings(_youTubeKey));
        _pipeline.Connect(_videoEncoder.Output, (_sink as YouTubeSinkBlock).CreateNewInput(MediaBlockPadMediaType.Video));
        _pipeline.Connect(_audioEncoder.Output, (_sink as YouTubeSinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio));
    }

        /// <summary>
        /// Create engine async.
        /// </summary>
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

        /// <summary>
        /// Destroy engine async.
        /// </summary>
    private async Task DestroyEngineAsync()
    {
        if (_pipeline != null)
        {
            _pipeline.OnError -= _pipeline_OnError;

            await _pipeline.DisposeAsync();
            _pipeline = null;
        }
    }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
    private void _pipeline_OnError(object sender, ErrorsEventArgs e)
    {
        Debug.WriteLine(e.Message);
    }

    private UIButton _btFlip;
    private UIView _btSRT;
    private UIView _btYouTube;
    private UIView _btFacebook;

    private enum StreamKind { None, SRT, YouTube, Facebook }
    private StreamKind _active = StreamKind.None;

        /// <summary>
        /// Build a pill-shaped view with an SF Symbol icon stacked above a caption.
        /// Uses a vertical UIStackView inside a rounded container so centering is correct.
        /// </summary>
    private UIView MakePill(string symbolName, string caption, Action onTap)
    {
        var container = new UIView
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            BackgroundColor = UIColor.FromWhiteAlpha(1f, 0.12f),
            UserInteractionEnabled = true
        };
        container.Layer.CornerRadius = 16f;

        var config = UIImageSymbolConfiguration.Create(22f, UIImageSymbolWeight.Regular);
        var iv = new UIImageView(UIImage.GetSystemImage(symbolName, config))
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            ContentMode = UIViewContentMode.ScaleAspectFit,
            TintColor = UIColor.White
        };

        var lbl = new UILabel
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            Text = caption,
            TextColor = UIColor.White,
            TextAlignment = UITextAlignment.Center,
            Font = UIFont.SystemFontOfSize(11f, UIFontWeight.Semibold)
        };

        var stack = new UIStackView(new UIView[] { iv, lbl })
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            Axis = UILayoutConstraintAxis.Vertical,
            Alignment = UIStackViewAlignment.Center,
            Spacing = 3f,
            UserInteractionEnabled = false
        };
        container.AddSubview(stack);

        NSLayoutConstraint.ActivateConstraints(new[]
        {
            stack.CenterXAnchor.ConstraintEqualTo(container.CenterXAnchor),
            stack.CenterYAnchor.ConstraintEqualTo(container.CenterYAnchor),
            iv.HeightAnchor.ConstraintEqualTo(26f),
            iv.WidthAnchor.ConstraintEqualTo(32f)
        });

        var tap = new UITapGestureRecognizer(() => onTap());
        container.AddGestureRecognizer(tap);

        return container;
    }

        /// <summary>
        /// Add bottom control bar: camera-flip icon on the left + three protocol pill buttons (SRT, YouTube, Facebook).
        /// </summary>
    private void AddButtons(UIView parent)
    {
        var controlBar = new UIView
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            BackgroundColor = UIColor.FromWhiteAlpha(0f, 0.35f)
        };
        parent.AddSubview(controlBar);

        NSLayoutConstraint.ActivateConstraints(new[]
        {
            controlBar.LeadingAnchor.ConstraintEqualTo(parent.LeadingAnchor),
            controlBar.TrailingAnchor.ConstraintEqualTo(parent.TrailingAnchor),
            controlBar.BottomAnchor.ConstraintEqualTo(parent.BottomAnchor),
            controlBar.HeightAnchor.ConstraintEqualTo(140f)
        });

        // camera flip — leading
        var flipConfig = UIImageSymbolConfiguration.Create(26f, UIImageSymbolWeight.Regular);
        var flipImage = UIImage.GetSystemImage("arrow.triangle.2.circlepath.camera.fill", flipConfig);

        _btFlip = new UIButton(UIButtonType.System)
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            TintColor = UIColor.White
        };
        _btFlip.SetImage(flipImage, UIControlState.Normal);
        _btFlip.TouchUpInside += async (sender, e) =>
        {
            if (_active != StreamKind.None)
            {
                Toast.Show("Stop streaming first to flip camera.", Window.RootViewController);
                return;
            }
            _cameraIndex = _cameraIndex == 0 ? 1 : 0;
            await StartPreviewAsync();
        };
        controlBar.AddSubview(_btFlip);

        NSLayoutConstraint.ActivateConstraints(new[]
        {
            _btFlip.LeadingAnchor.ConstraintEqualTo(controlBar.SafeAreaLayoutGuide.LeadingAnchor, 20f),
            _btFlip.CenterYAnchor.ConstraintEqualTo(controlBar.SafeAreaLayoutGuide.BottomAnchor, -54f),
            _btFlip.WidthAnchor.ConstraintEqualTo(50f),
            _btFlip.HeightAnchor.ConstraintEqualTo(50f)
        });

        // protocol pills — trailing stack
        _btSRT      = MakePill("antenna.radiowaves.left.and.right", "SRT",      async () => await ToggleStreamAsync(StreamKind.SRT));
        _btYouTube  = MakePill("play.rectangle.fill",               "YouTube",  async () => await ToggleStreamAsync(StreamKind.YouTube));
        _btFacebook = MakePill("f.cursive.circle.fill",             "Facebook", async () => await ToggleStreamAsync(StreamKind.Facebook));

        var stack = new UIStackView(new UIView[] { _btSRT, _btYouTube, _btFacebook })
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            Axis = UILayoutConstraintAxis.Horizontal,
            Spacing = 10f,
            Distribution = UIStackViewDistribution.FillEqually,
            Alignment = UIStackViewAlignment.Fill
        };
        controlBar.AddSubview(stack);

        NSLayoutConstraint.ActivateConstraints(new[]
        {
            stack.LeadingAnchor.ConstraintEqualTo(_btFlip.TrailingAnchor, 16f),
            stack.TrailingAnchor.ConstraintEqualTo(controlBar.SafeAreaLayoutGuide.TrailingAnchor, -20f),
            stack.CenterYAnchor.ConstraintEqualTo(_btFlip.CenterYAnchor),
            stack.HeightAnchor.ConstraintEqualTo(62f)
        });
    }

        /// <summary>
        /// Prompt the user for a string value, prefilled with a previously saved one.
        /// </summary>
    private Task<string> PromptAsync(string title, string message, string prefill, string placeholder)
    {
        var tcs = new TaskCompletionSource<string>();

        var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
        alert.AddTextField(tf =>
        {
            tf.Text = prefill ?? string.Empty;
            tf.Placeholder = placeholder;
            tf.AutocorrectionType = UITextAutocorrectionType.No;
            tf.AutocapitalizationType = UITextAutocapitalizationType.None;
        });
        alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, _ => tcs.TrySetResult(null)));
        alert.AddAction(UIAlertAction.Create("OK",     UIAlertActionStyle.Default, _ => tcs.TrySetResult(alert.TextFields![0].Text ?? string.Empty)));

        Window?.RootViewController?.PresentViewController(alert, true, null);
        return tcs.Task;
    }

        /// <summary>
        /// Toggle a stream — start if nothing running, stop if the same protocol is active, otherwise refuse.
        /// </summary>
    private async Task ToggleStreamAsync(StreamKind kind)
    {
        try
        {
            if (_active == kind)
            {
                await StartPreviewAsync();
                _active = StreamKind.None;
                UpdatePillState(null);
                return;
            }

            if (_active != StreamKind.None)
            {
                Toast.Show("Another stream is active. Stop it first.", Window.RootViewController);
                return;
            }

            var defaults = NSUserDefaults.StandardUserDefaults;

            switch (kind)
            {
                case StreamKind.SRT:
                {
                    var saved = defaults.StringForKey(PREF_SRT_URL) ?? DEFAULT_SRT_URL;
                    var value = await PromptAsync("SRT URL", "Enter the SRT URI. Use srt://:PORT for listener mode.", saved, "srt://:8888");
                    if (string.IsNullOrWhiteSpace(value)) return;
                    _srtUrl = value.Trim();
                    defaults.SetString(_srtUrl, PREF_SRT_URL);
                    break;
                }
                case StreamKind.YouTube:
                {
                    var saved = defaults.StringForKey(PREF_YT_KEY) ?? string.Empty;
                    var value = await PromptAsync("YouTube Live Key", "Paste the stream key from YouTube Studio.", saved, "xxxx-xxxx-xxxx-xxxx");
                    if (string.IsNullOrWhiteSpace(value)) return;
                    _youTubeKey = value.Trim();
                    defaults.SetString(_youTubeKey, PREF_YT_KEY);
                    break;
                }
                case StreamKind.Facebook:
                {
                    var saved = defaults.StringForKey(PREF_FB_KEY) ?? string.Empty;
                    var value = await PromptAsync("Facebook Live Key", "Paste the stream key from Facebook Live Producer.", saved, "FB-xxx-xxx");
                    if (string.IsNullOrWhiteSpace(value)) return;
                    _facebookKey = value.Trim();
                    defaults.SetString(_facebookKey, PREF_FB_KEY);
                    break;
                }
            }

            await CreateEngineAsync();

            switch (kind)
            {
                case StreamKind.SRT:      AddSRTSink(); break;
                case StreamKind.YouTube:  AddYouTubeSink(); break;
                case StreamKind.Facebook: AddFacebookSink(); break;
            }

            await _pipeline.StartAsync();

            _active = kind;
            UpdatePillState(kind);

            if (kind == StreamKind.SRT && _srtUrl.Contains(":8888") && !_srtUrl.Contains("@"))
            {
                // Listener mode — surface the IP so a remote client knows where to connect.
                var ip = GetLocalIpAddress();
                if (!string.IsNullOrEmpty(ip))
                {
                    Toast.Show("SRT URL: srt://" + ip + ":8888", Window.RootViewController);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            Toast.Show("Stream error: " + ex.Message, Window.RootViewController);
        }
    }

        /// <summary>
        /// Highlight the active protocol pill; dim the others.
        /// </summary>
    private void UpdatePillState(StreamKind? active)
    {
        var red = UIColor.SystemRed;
        var idle = UIColor.FromWhiteAlpha(1f, 0.12f);

        _btSRT.BackgroundColor      = active == StreamKind.SRT      ? red : idle;
        _btYouTube.BackgroundColor  = active == StreamKind.YouTube  ? red : idle;
        _btFacebook.BackgroundColor = active == StreamKind.Facebook ? red : idle;
    }

        /// <summary>
        /// Stop camera.
        /// </summary>
    private async Task StopCamera()
    {
        if (_pipeline == null)
        {
            return;
        }

        await _pipeline.StopAsync(true);

        await DestroyEngineAsync();
    }

        /// <summary>
        /// Start preview-only pipeline (video source → tee → renderer). No sink, no encoders.
        /// </summary>
    private async Task StartPreviewAsync()
    {
        await StopCamera();
        await CreateEngineAsync();
        if (_pipeline != null)
        {
            await _pipeline.StartAsync();
        }
    }

        /// <summary>
        /// Add video view that fills its parent using autoresizing.
        /// </summary>
    private void AddVideoView(UIView view)
    {
        _videoView = new VideoView(view.Bounds)
        {
            AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight,
            BackgroundColor = UIColor.Black,
            DisableAspectRatioResize = true
        };

        view!.AddSubview(_videoView);
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

        AddVideoView(vc.View);

        AddButtons(vc.View);

        Window.RootViewController = vc;

        Window.MakeKeyAndVisible();

        VisioForgeX.InitSDK();

        InvokeOnMainThread(async () =>
        {
            await StartPreviewAsync();
        });

        return true;
    }
}