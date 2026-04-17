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
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.Special;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.UI.Apple;

namespace SimpleVideoCaptureMB;

/// <summary>
/// The application delegate.
/// </summary>
[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    /// <summary>
    /// The pipeline.
    /// </summary>
    private MediaBlocksPipeline _pipeline;

    /// <summary>
    /// The filename.
    /// </summary>
    private string _filename;

    /// <summary>
    /// The video renderer.
    /// </summary>
    private MediaBlock _videoRenderer;

    /// <summary>
    /// The video source.
    /// </summary>
    private MediaBlock _videoSource;

    /// <summary>
    /// The audio source.
    /// </summary>
    private MediaBlock _audioSource;

    /// <summary>
    /// The video encoder.
    /// </summary>
    private MediaBlock _videoEncoder;

    /// <summary>
    /// The audio encoder.
    /// </summary>
    private MediaBlock _audioEncoder;

    /// <summary>
    /// The sink block.
    /// </summary>
    private MediaBlock _sink;

    /// <summary>
    /// The video tee.
    /// </summary>
    private TeeBlock _videoTee;

    /// <summary>
    /// The camera index.
    /// </summary>
    private int _cameraIndex = 1;

    /// <summary>
    /// The cameras.
    /// </summary>
    private VideoCaptureDeviceInfo[] _cameras;

    /// <summary>
    /// The video view.
    /// </summary>
    private UIView _videoView;

    /// <summary>
    /// The select camera button.
    /// </summary>
    private UIButton _btSelectCamera;

    /// <summary>
    /// The start capture button.
    /// </summary>
    private UIButton _btStartCapture;

    /// <summary>
    /// Is capture currently active.
    /// </summary>
    private bool _isCapturing;

    /// <summary>
    /// Is front camera currently selected (matches initial _cameraIndex = 1 → FRONT).
    /// </summary>
    private bool _isFrontCamera = true;

    public override UIWindow? Window { get; set; }

        /// <summary>
        /// Create engine async.
        /// </summary>
    private async Task CreateEngineAsync(bool capture)
    {
        try
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

            _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

            // create video tee
            _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, _videoView as IVideoView) { IsSync = false };

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
                _pipeline.Connect(_videoEncoder.Output,
                    (_sink as MP4SinkBlock).CreateNewInput(MediaBlockPadMediaType.Video));

                // audio source
                _audioSource = new SystemAudioSourceBlock(new IOSAudioSourceSettings());
                _audioEncoder = new AACEncoderBlock();
                _pipeline.Connect(_audioSource.Output, _audioEncoder.Input);
                _pipeline.Connect(_audioEncoder.Output,
                    (_sink as MP4SinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio));
            }
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

        /// <summary>
        /// Add bottom control bar with icon-based camera-flip and record buttons.
        /// </summary>
    private void AddButtons(UIView parent)
    {
        // control bar — pinned to the bottom safe area, translucent dark panel
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
            controlBar.HeightAnchor.ConstraintEqualTo(120f)
        });

        // record button — large circular, centered horizontally on the safe-area bottom edge
        _btStartCapture = new UIButton(UIButtonType.Custom)
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            BackgroundColor = UIColor.Clear
        };
        _btStartCapture.Layer.CornerRadius = 34f;
        _btStartCapture.Layer.BorderWidth = 4f;
        _btStartCapture.Layer.BorderColor = UIColor.White.CGColor;
        UpdateCaptureButtonAppearance();

        _btStartCapture.TouchUpInside += async (sender, e) =>
        {
            if (_pipeline != null)
            {
                await StopCamera();
            }

            if (_isCapturing)
            {
                _isCapturing = false;
                UpdateCaptureButtonAppearance();
                await StartPreview();
            }
            else
            {
                await StartCapture();
                _isCapturing = true;
                UpdateCaptureButtonAppearance();
            }
        };

        controlBar.AddSubview(_btStartCapture);

        NSLayoutConstraint.ActivateConstraints(new[]
        {
            _btStartCapture.CenterXAnchor.ConstraintEqualTo(controlBar.CenterXAnchor),
            _btStartCapture.CenterYAnchor.ConstraintEqualTo(controlBar.SafeAreaLayoutGuide.BottomAnchor, -44f),
            _btStartCapture.WidthAnchor.ConstraintEqualTo(68f),
            _btStartCapture.HeightAnchor.ConstraintEqualTo(68f)
        });

        // camera flip — SF Symbol icon, positioned to the right of the record button
        var flipConfig = UIImageSymbolConfiguration.Create(26f, UIImageSymbolWeight.Regular);
        var flipImage = UIImage.GetSystemImage("arrow.triangle.2.circlepath.camera.fill", flipConfig);

        _btSelectCamera = new UIButton(UIButtonType.System)
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            TintColor = UIColor.White
        };
        _btSelectCamera.SetImage(flipImage, UIControlState.Normal);
        _btSelectCamera.TouchUpInside += async (sender, e) =>
        {
            if (_pipeline != null)
            {
                await StopCamera();
            }

            _isFrontCamera = !_isFrontCamera;
            _cameraIndex = _isFrontCamera ? 1 : 0;

            _isCapturing = false;
            UpdateCaptureButtonAppearance();

            await StartPreview();
        };

        controlBar.AddSubview(_btSelectCamera);

        NSLayoutConstraint.ActivateConstraints(new[]
        {
            _btSelectCamera.CenterYAnchor.ConstraintEqualTo(_btStartCapture.CenterYAnchor),
            _btSelectCamera.LeadingAnchor.ConstraintEqualTo(_btStartCapture.TrailingAnchor, 48f),
            _btSelectCamera.WidthAnchor.ConstraintEqualTo(44f),
            _btSelectCamera.HeightAnchor.ConstraintEqualTo(44f)
        });
    }

        /// <summary>
        /// Update the capture button's inner shape — red dot when idle, white square when recording.
        /// </summary>
    private void UpdateCaptureButtonAppearance()
    {
        foreach (var sub in _btStartCapture.Subviews)
        {
            if (sub.Tag == 99)
            {
                sub.RemoveFromSuperview();
            }
        }

        var inner = new UIView
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            UserInteractionEnabled = false,
            Tag = 99
        };

        if (_isCapturing)
        {
            inner.BackgroundColor = UIColor.SystemRed;
            inner.Layer.CornerRadius = 6f;
        }
        else
        {
            inner.BackgroundColor = UIColor.SystemRed;
            inner.Layer.CornerRadius = 26f;
        }

        _btStartCapture.AddSubview(inner);

        NSLayoutConstraint.ActivateConstraints(new[]
        {
            inner.CenterXAnchor.ConstraintEqualTo(_btStartCapture.CenterXAnchor),
            inner.CenterYAnchor.ConstraintEqualTo(_btStartCapture.CenterYAnchor),
            inner.WidthAnchor.ConstraintEqualTo(_isCapturing ? 28f : 52f),
            inner.HeightAnchor.ConstraintEqualTo(_isCapturing ? 28f : 52f)
        });
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
        if (_pipeline == null)
        {
            return;
        }

        await _pipeline.StopAsync();

        await DestroyEngineAsync();

        // we need to share video to Photos library
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

        /// <summary>
        /// Start preview.
        /// </summary>
    private async Task StartPreview()
    {
        await StopCamera();

        await CreateEngineAsync(false);

        await _pipeline.StartAsync();
    }

        /// <summary>
        /// Start capture.
        /// </summary>
    private async Task StartCapture()
    {
        await StopCamera();

        await CreateEngineAsync(true);

        await _pipeline.StartAsync();
    }

        /// <summary>
        /// Create video view that fills its parent using auto-layout.
        /// </summary>
    private void CreateVideoView(UIView view)
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
        InvokeOnMainThread(async () =>
        {
            await StartPreview();
        });

        return true;
    }
}