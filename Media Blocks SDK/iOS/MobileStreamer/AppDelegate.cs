using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;

using AVFoundation;
using CoreFoundation;
using Foundation;
using Photos;
using Security;

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
    // Persisted per-protocol user input.
    // SRT URL is not a credential → NSUserDefaults is fine.
    // YouTube / Facebook stream keys ARE credentials (grant live-broadcast on behalf of the user
    // until revoked) and must live in the Keychain, not in NSUserDefaults (which is plaintext in
    // unencrypted iTunes/Finder backups and readable via the app's plist bundle).
    private const string PREF_SRT_URL   = "pref_srt_url";
    private const string KC_YT_KEY      = "mobilestreamer.youtube.key";
    private const string KC_FB_KEY      = "mobilestreamer.facebook.key";

    // Keychain Service string — DON'T key off NSBundle.MainBundle.BundleIdentifier: a free↔
    // paid dev cert flip or an App Store vs TestFlight bundle-id change would orphan every
    // previously-saved stream key. Hardcoding a stable identifier keeps items addressable
    // across re-signings (still per-app because the Keychain ACL is scoped to the signing
    // identity / team).
    private const string KC_SERVICE     = "com.visioforge.MobileStreamer";

    // Default shown in the SRT prompt on first launch: listen on port 8888.
    private const string DEFAULT_SRT_URL = "srt://:8888";

    // Remembered between stream starts; filled via the prompt.
    private string _srtUrl;
    private string _youTubeKey;
    private string _facebookKey;

    // Re-entrancy guard for ToggleStreamAsync: blocks second taps while a prompt is open
    // or the pipeline is being torn down/rebuilt. Cleared in a finally block so crashes don't
    // leave the UI permanently locked.
    //
    // Interlocked int, not volatile bool: the volatile-bool "check then set" pattern is NOT
    // atomic. Two threads (main-thread taps + a synthetic auto-stop) can both read false and
    // both enter the body. Interlocked.CompareExchange gives us the atomic test-and-set the
    // pattern actually needs. 0 = free, 1 = busy.
    private int _toggleBusy;

    // Tracks whether the initial preview has been started from the root VC's ViewDidAppear,
    // so rotation / re-appear events don't kick off another concurrent StartPreviewAsync.
    private bool _initialPreviewStarted;

    // Tracks whether the camera + microphone permission prompts have been fired.
    // We request both up front rather than waiting for the GStreamer pipeline to lazily
    // trigger them from its audio source element: the mic prompt only fires when the
    // audio source transitions to PLAYING (i.e. on the first SRT/YT/FB start), and that
    // runs on a GStreamer bus worker thread. iOS pops the permission alert from an
    // unexpected context, the user sees a blocked pipeline or an immediate crash. Asking
    // on the main thread from ViewDidAppear avoids both issues.
    private bool _permissionsRequested;

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

    // Reverted from VideoView (Metal) back to VideoViewGL per the project policy that
    // video-view type switches require explicit user approval. If Metal adoption is desired,
    // flip this (and the AddVideoView ctor below) in a dedicated commit that records the
    // approval.
    private VideoViewGL _videoView;

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
        /// Add srt sink. The sink muxes into MPEG-TS which only accepts AAC/AC3/MP3 for
        /// audio — Opus is not a valid MPEG-TS elementary stream, so using OPUSEncoderBlock
        /// here would wedge the pipeline in StartAsync waiting for an audio pad it can't
        /// accept. Use AACEncoderBlock for MPEG-TS compatibility.
        /// </summary>
    private void AddSRTSink()
    {
        // video encoder
        _videoEncoder = new H264EncoderBlock(new AppleMediaH264EncoderSettings());
        _videoEncoder.Settings.ParseStream = false; // we have to disable parsing for SRT for H264 and HEVC encoders
        _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);

        // audio encoder — MPEG-TS requires AAC, not Opus
        _audioEncoder = new AACEncoderBlock();
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
        /// Create engine async. Returns true on success; on failure tears down any partially-
        /// constructed pipeline so a subsequent call starts from a clean slate and _pipeline
        /// never lingers in a state where _videoTee / _videoSource are null.
        /// </summary>
    private async Task<bool> CreateEngineAsync()
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
            ShowToastOnMain("No video sources found");
            await DestroyEngineAsync();
            return false;
        }

        VideoCaptureDeviceSourceSettings videoSourceSettings = null;

        if (_cameraIndex >= _cameras.Length)
        {
            _cameraIndex = 0;
        }

        var device = _cameras[_cameraIndex];
        if (device != null)
        {
            var formatItem = device.VideoFormats.FirstOrDefault(x => x.Width == 1920 && x.Height == 1080);
            if (formatItem != null)
            {
                videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                {
                    Format = formatItem.ToFormat()
                };

                videoSourceSettings.Format.FrameRate = new VideoFrameRate(30);

                // Refresh orientation at engine-creation time from the live device orientation.
                // The VideoCaptureDeviceSourceSettings ctor already samples UIDevice orientation,
                // but that read can return Unknown very early in the app lifecycle (before the
                // accelerometer has reported) — fall through to a portrait default, then override
                // if a concrete orientation is now available. Matches the behaviour that used to
                // be hard-coded as LandscapeRight so captured frames aren't rotated 90° on re-flip.
                videoSourceSettings.Orientation = ResolveCurrentOrientation(videoSourceSettings.Orientation);
            }
        }

        if (videoSourceSettings == null)
        {
            ShowToastOnMain("Unable to configure camera settings");
            await DestroyEngineAsync();
            return false;
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

        return true;
    }

    /// <summary>
    /// Pick an <see cref="IOSVideoSourceOrientation"/> that matches the current device pose.
    /// Falls back to the provided default when the device reports Unknown/FaceUp/FaceDown.
    /// </summary>
    private static IOSVideoSourceOrientation ResolveCurrentOrientation(IOSVideoSourceOrientation fallback)
    {
        switch (UIDevice.CurrentDevice.Orientation)
        {
            case UIDeviceOrientation.Portrait:           return IOSVideoSourceOrientation.Portrait;
            case UIDeviceOrientation.PortraitUpsideDown: return IOSVideoSourceOrientation.PortratUpsideDown;
            case UIDeviceOrientation.LandscapeLeft:      return IOSVideoSourceOrientation.LandscapeLeft;
            case UIDeviceOrientation.LandscapeRight:     return IOSVideoSourceOrientation.LandscapeRight;
            default:                                     return fallback;
        }
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

        // VideoViewGL holds a back-reference to the GstGLSink element the renderer wired to
        // it during Connect. Pipeline.DisposeAsync sets the element to NULL, but the surface
        // tie-in is only released when the renderer's drawing loop next sees the abandoned
        // sink — CallRefresh forces that repaint immediately and drops the stale ref. Without
        // this the next CreateEngineAsync can observe a dangling GstElement and leak one
        // sink per start/stop cycle.
        _videoView?.CallRefresh();

        // Null the MediaBlock references too — Pipeline.DisposeAsync tears down the native
        // elements, but the managed wrappers stay reachable until GC. Clearing them here
        // prevents the next CreateEngineAsync from overwriting live references and makes
        // stale access fail fast with NRE instead of touching half-disposed blocks.
        _videoSource = null;
        _audioSource = null;
        _videoTee = null;
        _videoRenderer = null;
        _videoEncoder = null;
        _audioEncoder = null;
        _sink = null;
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
    private UIView MakePill(string symbolName, string caption, Func<Task> onTap)
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

        // Wrap the Func<Task> in a guarded, non-reentrant handler so:
        //  - exceptions escaping the task are caught instead of crashing the process
        //    (the previous `() => onTap()` pattern turned every tap into async-void fire-and-forget),
        //  - rapid taps don't kick off overlapping ToggleStreamAsync runs.
        var tap = new UITapGestureRecognizer(() => _ = InvokeTapAsync(onTap));
        container.AddGestureRecognizer(tap);

        return container;
    }

    private async Task InvokeTapAsync(Func<Task> onTap)
    {
        try
        {
            await onTap();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Pill tap handler threw: {ex}");
            ShowToastOnMain($"Error: {ex.Message}");
        }
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
            try
            {
                if (_active != StreamKind.None)
                {
                    ShowToastOnMain("Stop streaming first to flip camera.");
                    return;
                }
                _cameraIndex = _cameraIndex == 0 ? 1 : 0;
                await StartPreviewAsync();
            }
            catch (Exception ex)
            {
                // async void handler: unhandled exceptions escape to the thread pool and
                // crash the app. Swallow and surface to the user instead.
                Debug.WriteLine(ex);
                ShowToastOnMain($"Camera flip failed: {ex.Message}");
            }
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
        _btSRT      = MakePill("antenna.radiowaves.left.and.right", "SRT",      () => ToggleStreamAsync(StreamKind.SRT));
        _btYouTube  = MakePill("play.rectangle.fill",               "YouTube",  () => ToggleStreamAsync(StreamKind.YouTube));
        _btFacebook = MakePill("f.cursive.circle.fill",             "Facebook", () => ToggleStreamAsync(StreamKind.Facebook));

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
        alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, _ =>
        {
            // Defence in depth: AddTextField is synchronous and AlertController.TextFields
            // is always populated by the time the OK action fires, but a null/empty check
            // keeps us from NRE'ing on any future UIKit behaviour change at no real cost.
            var fields = alert.TextFields;
            var text = (fields != null && fields.Length > 0) ? fields[0].Text ?? string.Empty : string.Empty;
            tcs.TrySetResult(text);
        }));

        // Walk up the presentation chain to find the topmost VC that can present a modal.
        // If another alert/action sheet is already on screen, PresentViewController silently
        // fails and no action closure ever fires — ToggleStreamAsync would hang forever.
        var presenter = TopmostPresenter();
        if (presenter == null)
        {
            tcs.TrySetResult(null);
            return tcs.Task;
        }

        try
        {
            presenter.PresentViewController(alert, true, null);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"PromptAsync: PresentViewController failed: {ex.Message}");
            tcs.TrySetResult(null);
        }

        return tcs.Task;
    }

    /// <summary>
    /// Find the topmost currently-presented view controller so PromptAsync can attach its
    /// alert to it. Returns null when there is no window/root view controller.
    /// </summary>
    private UIViewController TopmostPresenter()
    {
        var vc = ResolvePresentingRoot();
        while (vc?.PresentedViewController != null)
        {
            vc = vc.PresentedViewController;
        }
        return vc;
    }

    /// <summary>
    /// Resolve the root view controller to use for alerts/toasts.
    ///
    /// On scene-managed apps (UIApplicationSceneManifest in Info.plist), <see cref="Window"/>
    /// on AppDelegate is a distinct object from the scene's window and is frequently null —
    /// so a bare <c>Window.RootViewController</c> call NREs. We walk UIApplication's
    /// connected scenes, pick the foreground-active UIWindowScene, grab its key window, and
    /// fall back to the AppDelegate's own window only if no scene has one yet.
    /// </summary>
    /// <summary>
    /// Show a toast, null-checking the presenting root and marshalling to the main thread.
    ///
    /// Toast.Show dereferences controller.View.Frame.Size.Height without a null-check, so a
    /// call with a null root (cold-start, scene not yet attached) would NRE. UIKit and
    /// UIApplication.ConnectedScenes are also main-thread-only, but async continuations here
    /// can resume on a GStreamer bus worker or thread-pool slot — so every toast site that
    /// runs after an <c>await</c> has to hop back explicitly. This helper funnels all call
    /// sites through both guards.
    /// </summary>
    private void ShowToastOnMain(string message)
    {
        if (NSThread.IsMain)
        {
            var root = ResolvePresentingRoot();
            if (root == null)
            {
                Debug.WriteLine($"ShowToastOnMain suppressed (no root VC): {message}");
                return;
            }

            Toast.Show(message, root);
            return;
        }

        InvokeOnMainThread(() =>
        {
            var root = ResolvePresentingRoot();
            if (root == null)
            {
                Debug.WriteLine($"ShowToastOnMain suppressed (no root VC): {message}");
                return;
            }

            Toast.Show(message, root);
        });
    }

    private UIViewController? ResolvePresentingRoot()
    {
        // UIApplication.ConnectedScenes and UIScene / UIWindow are documented main-thread
        // only. Async continuations here resume on GStreamer bus workers / thread-pool
        // slots, so the unguarded call could SIGTRAP under Thread Sanitizer, deadlock, or
        // return stale state. Hop to the main thread synchronously if we aren't there.
        if (!NSThread.IsMain)
        {
            UIViewController? result = null;
            InvokeOnMainThread(() => result = ResolvePresentingRoot());
            return result;
        }

        try
        {
            foreach (var scene in UIApplication.SharedApplication.ConnectedScenes)
            {
                if (scene is UIWindowScene ws && ws.ActivationState == UISceneActivationState.ForegroundActive)
                {
                    foreach (var w in ws.Windows)
                    {
                        if (w.IsKeyWindow && w.RootViewController != null)
                        {
                            return w.RootViewController;
                        }
                    }

                    foreach (var w in ws.Windows)
                    {
                        if (w.RootViewController != null)
                        {
                            return w.RootViewController;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"ResolvePresentingRoot: scene enumeration failed: {ex.Message}");
        }

        return Window?.RootViewController;
    }

    /// <summary>
    /// Determine whether the SRT URL is a listener-mode endpoint (host component empty) and
    /// if so return the port. Previously the code used a fragile substring match on ':8888'
    /// which mis-identified caller URLs like 'srt://example.com:8888/path'.
    /// </summary>
    private static bool IsSrtListenerUrl(string srtUrl, out int port)
    {
        port = 0;
        if (string.IsNullOrWhiteSpace(srtUrl))
        {
            return false;
        }

        // Regex fallback first: for unregistered schemes like srt://, some .NET Uri parsers
        // surface Port = -1 / the full authority in Host — so the Uri.TryCreate path below
        // can miss a perfectly valid listener URL. Matching srt://:NNNN directly is the most
        // reliable way to detect the listener form and extract the port.
        var m = System.Text.RegularExpressions.Regex.Match(
            srtUrl.Trim(),
            @"^srt://:(\d+)(?:[/?].*)?$",
            System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        if (m.Success && int.TryParse(m.Groups[1].Value, out var parsedPort) && parsedPort > 0)
        {
            port = parsedPort;
            return true;
        }

        if (!Uri.TryCreate(srtUrl, UriKind.Absolute, out var uri))
        {
            return false;
        }

        // Listener URLs look like "srt://:8888" or "srt://:8888?mode=listener" — host is empty.
        if (!string.IsNullOrEmpty(uri.Host))
        {
            return false;
        }

        port = uri.Port > 0 ? uri.Port : 0;
        return port > 0;
    }

        /// <summary>
        /// Toggle a stream — start if nothing running, stop if the same protocol is active, otherwise refuse.
        /// </summary>
    private async Task ToggleStreamAsync(StreamKind kind)
    {
        // Reject overlapping invocations: a second tap while the first is still awaiting a
        // modal (PromptAsync) or tearing down / rebuilding the pipeline would spawn concurrent
        // CreateEngineAsync calls and leak native resources.
        if (System.Threading.Interlocked.CompareExchange(ref _toggleBusy, 1, 0) != 0)
        {
            return;
        }

        try
        {
            if (_active == kind)
            {
                // Clear the state BEFORE awaiting StartPreviewAsync. If the await throws
                // (camera permission revoked mid-session, format probe fails), the old stop
                // path left _active pointing at the now-dead kind — the next tap then hit
                // the "Another stream is active" branch and refused to do anything. Clearing
                // first means the UI returns to the idle state even on a failed stop.
                _active = StreamKind.None;
                UpdatePillState(null);
                await StartPreviewAsync();
                return;
            }

            if (_active != StreamKind.None)
            {
                ShowToastOnMain("Another stream is active. Stop it first.");
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
                    var saved = KeychainLoad(KC_YT_KEY) ?? string.Empty;
                    var value = await PromptAsync("YouTube Live Key", "Paste the stream key from YouTube Studio.", saved, "xxxx-xxxx-xxxx-xxxx");
                    if (string.IsNullOrWhiteSpace(value)) return;
                    _youTubeKey = value.Trim();
                    KeychainSave(KC_YT_KEY, _youTubeKey);
                    break;
                }
                case StreamKind.Facebook:
                {
                    var saved = KeychainLoad(KC_FB_KEY) ?? string.Empty;
                    var value = await PromptAsync("Facebook Live Key", "Paste the stream key from Facebook Live Producer.", saved, "FB-xxx-xxx");
                    if (string.IsNullOrWhiteSpace(value)) return;
                    _facebookKey = value.Trim();
                    KeychainSave(KC_FB_KEY, _facebookKey);
                    break;
                }
            }

            // Tear down the preview pipeline before building the streaming one. Without this
            // step, _pipeline is simply overwritten and the prior native pipeline leaks until GC.
            await StopCamera();

            if (!await CreateEngineAsync())
            {
                // CreateEngineAsync already toasted the reason and disposed the pipeline.
                return;
            }

            switch (kind)
            {
                case StreamKind.SRT:      AddSRTSink(); break;
                case StreamKind.YouTube:  AddYouTubeSink(); break;
                case StreamKind.Facebook: AddFacebookSink(); break;
            }

            await _pipeline.StartAsync();

            _active = kind;
            UpdatePillState(kind);

            if (kind == StreamKind.SRT && IsSrtListenerUrl(_srtUrl, out var listenerPort))
            {
                // Listener mode — surface the IP so a remote client knows where to connect.
                var ip = GetLocalIpAddress();
                if (!string.IsNullOrEmpty(ip))
                {
                    ShowToastOnMain($"SRT URL: srt://{ip}:{listenerPort}");
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            ShowToastOnMain("Stream error: " + ex.Message);
        }
        finally
        {
            System.Threading.Interlocked.Exchange(ref _toggleBusy, 0);
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
    /// Ask the user for every sensitive permission the streamer will need (camera, microphone,
    /// photo library, local network) up front, on the main thread, from ViewDidAppear.
    ///
    /// Why all of them together: any permission prompt that fires later from a GStreamer worker
    /// thread (mic when the audio source goes PLAYING, local-network when srtsink calls
    /// connect() on a 192.168/10.x address) has been observed to either deadlock or crash the
    /// SRT start. iOS 14+ also terminates the process when an app without
    /// NSLocalNetworkUsageDescription touches a local address, so missing the local-network
    /// prompt is an outright crash. Requesting all of them on the main thread, before the
    /// pipeline is constructed, gives the user a deterministic prompt sequence and makes every
    /// later access re-use a cached grant/denial.
    ///
    /// Results are not checked: if the user declines any one, the matching source/sink elements
    /// simply fail to probe later, which the pipeline's OnError handler already toasts.
    /// </summary>
    private Task RequestMediaPermissionsAsync()
    {
        if (_permissionsRequested)
        {
            return Task.CompletedTask;
        }
        _permissionsRequested = true;

        var camTcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        try
        {
            AVCaptureDevice.RequestAccessForMediaType(AVAuthorizationMediaType.Video, granted => camTcs.TrySetResult(granted));
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"RequestAccessForMediaType(Video) threw: {ex}");
            camTcs.TrySetResult(false);
        }

        var micTcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        try
        {
            AVAudioSession.SharedInstance().RequestRecordPermission(granted => micTcs.TrySetResult(granted));
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"RequestRecordPermission threw: {ex}");
            micTcs.TrySetResult(false);
        }

        var photoTcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        try
        {
            // AddOnly is the minimum privilege we need to persist recordings to the Photos
            // app; gated on iOS 14+ because the overload was added then.
            if (UIDevice.CurrentDevice.CheckSystemVersion(14, 0))
            {
                PHPhotoLibrary.RequestAuthorization(PHAccessLevel.AddOnly, status => photoTcs.TrySetResult(status == PHAuthorizationStatus.Authorized));
            }
            else
            {
                PHPhotoLibrary.RequestAuthorization(status => photoTcs.TrySetResult(status == PHAuthorizationStatus.Authorized));
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"RequestAuthorization(Photo) threw: {ex}");
            photoTcs.TrySetResult(false);
        }

        // Local Network (iOS 14+). There's no public API to "request" this synchronously —
        // the system shows the alert the first time the app touches a multicast address or
        // opens a socket to a local-subnet IP. A very short NSNetServiceBrowser search is the
        // canonical way to trigger that prompt under our control, well before srtsink tries
        // to connect() to 192.168.x.x (which, without Info.plist's NSLocalNetworkUsageDescription
        // + a prior prompt, crashes the app outright). Service type must match an entry in
        // NSBonjourServices to avoid an iOS TCC violation in release builds.
        try
        {
            var browser = new NSNetServiceBrowser();
            browser.SearchForServices("_visioforge-streamer._tcp", "local.");
            // Stop after 1.5s — enough to trigger the system prompt, not long enough to
            // matter for anything else. Retain the browser via the closure so ARC doesn't
            // free it before Stop fires.
            NSTimer.CreateScheduledTimer(1.5, _ =>
            {
                try { browser.Stop(); browser.Dispose(); }
                catch (Exception ex) { Debug.WriteLine($"LocalNetwork browser Stop threw: {ex}"); }
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"LocalNetwork Bonjour probe threw: {ex}");
        }

        return Task.WhenAll(camTcs.Task, micTcs.Task, photoTcs.Task);
    }

        /// <summary>
        /// Start preview-only pipeline (video source → tee → renderer). No sink, no encoders.
        /// Returns after the pipeline is running; failures are toasted and swallowed so callers
        /// on UI paths don't need their own try/catch.
        /// </summary>
    private async Task StartPreviewAsync()
    {
        try
        {
            await StopCamera();
            if (!await CreateEngineAsync())
            {
                return;
            }

            await _pipeline.StartAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            ShowToastOnMain("Preview error: " + ex.Message);
        }
    }

        /// <summary>
        /// Add video view that fills its parent using autoresizing.
        /// </summary>
    private void AddVideoView(UIView view)
    {
        // Pinned back to VideoViewGL (see the field declaration comment). VideoViewGL doesn't
        // expose DisableAspectRatioResize — the GL renderer already preserves the source aspect
        // ratio without extra suppression, so dropping that flag is a no-op here.
        _videoView = new VideoViewGL(view.Bounds)
        {
            AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight,
            BackgroundColor = UIColor.Black
        };

        view!.AddSubview(_videoView);
    }

        /// <summary>
        /// Finished launching.
        ///
        /// Preview startup is deferred to <see cref="RootVC.ViewDidAppear"/> rather than
        /// kicked off inline here: at FinishedLaunching the UIWindow has been made key but
        /// the view has not yet laid out, so <c>view.Bounds</c> is frequently empty. Starting
        /// the VideoView / Metal drawable against a zero-sized bounds has been observed to
        /// drop the first frames and, on some drivers, trigger layer-size assertions.
        /// </summary>
    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        var vc = new RootVC(this);
        Window.RootViewController = vc;
        Window.MakeKeyAndVisible();

        VisioForgeX.InitSDK();

        return true;
    }

    /// <summary>
    /// Root view controller that owns the preview layout. Starts the pipeline in
    /// <see cref="ViewDidAppear"/> once iOS has laid out the view hierarchy, so the
    /// VideoView has a non-zero bounds before the Metal drawable is created.
    /// </summary>
    private sealed class RootVC : UIViewController
    {
        private readonly AppDelegate _app;

        public RootVC(AppDelegate app)
        {
            _app = app;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _app.AddVideoView(View);
            _app.AddButtons(View);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (_app._initialPreviewStarted)
            {
                return;
            }
            _app._initialPreviewStarted = true;

            // Kick off preview on the next runloop turn — we're already on the main thread,
            // but yielding lets UIKit finish any pending layout pass before we start Metal.
            DispatchQueue.MainQueue.DispatchAsync(async () =>
            {
                try
                {
                    // Prompt for camera + mic up front so the later SRT/YT/FB start doesn't
                    // trigger the mic permission prompt from a GStreamer worker thread.
                    await _app.RequestMediaPermissionsAsync();
                    await _app.StartPreviewAsync();
                }
                catch (Exception ex)
                {
                    // Fire-and-forget on the main queue — without this catch, exceptions from
                    // StartPreviewAsync would propagate into the main dispatch as async-void
                    // and terminate the app.
                    Debug.WriteLine($"Initial preview start failed: {ex}");
                    _app.ShowToastOnMain("Initial preview failed: " + ex.Message);
                }
            });
        }
    }

    // ---- Keychain helpers ---------------------------------------------------------------
    //
    // Stream keys grant live-broadcast on behalf of the signed-in user and must not live in
    // NSUserDefaults (plaintext in iTunes backups and in the app's plist bundle). We stash
    // them as kSecClassGenericPassword items scoped to this app's bundle id so iOS encrypts
    // them at rest and excludes them from unencrypted backups.
    private static void KeychainSave(string account, string value)
    {
        try
        {
            // Delete any existing record before inserting — SecKeyChain.Add fails with
            // DuplicateItem if we try to overwrite.
            var existing = new SecRecord(SecKind.GenericPassword)
            {
                Service = KC_SERVICE,
                Account = account
            };
            SecKeyChain.Remove(existing);

            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            var rec = new SecRecord(SecKind.GenericPassword)
            {
                Service = KC_SERVICE,
                Account = account,
                ValueData = NSData.FromString(value, NSStringEncoding.UTF8),
                // Anchor the key to this device so iCloud Keychain doesn't sync the live
                // stream key to the user's other devices — each device should have its own
                // (or none). Default is kSecAttrAccessibleWhenUnlocked which DOES sync.
                Accessible = SecAccessible.WhenUnlockedThisDeviceOnly
            };

            var status = SecKeyChain.Add(rec);
            if (status != SecStatusCode.Success && status != SecStatusCode.DuplicateItem)
            {
                Debug.WriteLine($"KeychainSave({account}) failed: {status}");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"KeychainSave({account}) threw: {ex}");
        }
    }

    private static string KeychainLoad(string account)
    {
        try
        {
            var query = new SecRecord(SecKind.GenericPassword)
            {
                Service = KC_SERVICE,
                Account = account
            };

            var result = SecKeyChain.QueryAsRecord(query, out var status);
            if (status != SecStatusCode.Success || result?.ValueData == null)
            {
                return null;
            }

            return NSString.FromData(result.ValueData, NSStringEncoding.UTF8)?.ToString();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"KeychainLoad({account}) threw: {ex}");
            return null;
        }
    }
}