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

    private bool _isCapturing;

    private bool _isFrontCamera = true;

    public override UIWindow? Window { get; set; }

        /// <summary>
        /// Create engine async.
        /// </summary>
    private async Task CreateEngineAsync()
    {
        try
        {
            _player = new VideoCaptureCoreX(_videoView as IVideoView);
            // VideoCaptureCoreX defaults Video_Play to false — without this the pipeline
            // runs (capture session is up, camera LED lights) but the video tee is never
            // connected to the renderer bound to _videoView, so preview stays black.
            _player.Video_Play = true;
            _player.OnError += PlayerOnError;
            _player.OnOutputStopped += async (sender, e) =>
            {
                // Async delay instead of Thread.Sleep — SDK rule forbids Thread.Sleep, and
                // the event may fire on either the main thread (freezing UI for 500 ms) or
                // on a GStreamer bus worker (blocking the bus and risking missed messages).
                // Wrap in try/catch because this handler is async void.
                try
                {
                    if (!string.IsNullOrEmpty(_filename))
                    {
                        await Task.Delay(500);

                        InvokeOnMainThread(() =>
                        {
                            SaveVideoToPhotoLibrary(_filename);
                            _filename = null;
                        });
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"OnOutputStopped handler failed: {ex.Message}");
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

            _player.Video_Source = videoSourceSettings;

            _player.Outputs_Clear();

            // configure audio source
            //_pipeline.Audio_Source = new IOSAudioSourceSettings();

            // configure encoders
            var videoEncoder = new AppleMediaH264EncoderSettings();
            // AVENCAAC is gst-libav-backed and isn't bundled on iOS — uncommenting would break
            // the build. Use VOAACEncoderSettings (portable) instead:
            //   var audioEncoder = new VOAACEncoderSettings();
            
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
        /// Add bottom control bar with icon-based camera-flip and record buttons.
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
            controlBar.HeightAnchor.ConstraintEqualTo(120f)
        });

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
            if (_player == null)
            {
                return;
            }

            // Previously: on a StopCaptureAsync/StartCaptureAsync throw, _isCapturing
            // stayed at its old value and UpdateCaptureButtonAppearance never fired, so
            // the big red button showed the wrong state. Assume success optimistically,
            // update the UI, and roll the flag + glyph back if the SDK call threw.
            _btStartCapture.Enabled = false;
            var wasCapturing = _isCapturing;
            try
            {
                if (wasCapturing)
                {
                    _isCapturing = false;
                    UpdateCaptureButtonAppearance();
                    await _player.StopCaptureAsync(0);
                }
                else
                {
                    GenerateFilename();
                    _isCapturing = true;
                    UpdateCaptureButtonAppearance();
                    await _player.StartCaptureAsync(0, _filename);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Capture toggle failed: {ex.Message}");
                _isCapturing = wasCapturing;
                UpdateCaptureButtonAppearance();
            }
            finally
            {
                _btStartCapture.Enabled = true;
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
            // Disable the button while the flip is in flight so rapid double-taps can't
            // interleave two Stop/Start sequences against the same _player / _cameraIndex.
            // try/catch is mandatory because this delegate is async void — an uncaught throw
            // from StopCamera/StartAsync would escape to the thread-pool and terminate the
            // process on the very next unhandled exception.
            _btSelectCamera.Enabled = false;
            try
            {
                if (_player != null)
                {
                    await StopCamera();
                }

                _isFrontCamera = !_isFrontCamera;

                // Map front/back preference to the device's actual index rather than hard-
                // coded 0/1 — iPads without a rear camera, external-cam rigs, and some
                // Multi-Cam setups enumerate in a different order and would otherwise open
                // the wrong camera (or throw IndexOutOfRange for an empty back slot).
                if (_cameras == null || _cameras.Length == 0)
                {
                    _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
                }
                _cameraIndex = FindCameraIndex(_cameras, preferFront: _isFrontCamera);

                _isCapturing = false;
                UpdateCaptureButtonAppearance();

                await StartAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Camera flip failed: {ex.Message}");
            }
            finally
            {
                _btSelectCamera.Enabled = true;
            }
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
        /// Resolve a front/back camera to its index in <paramref name="cameras"/> by querying
        /// <see cref="VideoCaptureDeviceInfo.IsFrontFacing"/> rather than hard-coded 0/1 slot
        /// assumptions. Falls back to the opposite-facing camera when the preferred one isn't
        /// available, and finally to the first device in the list.
        /// </summary>
    private static int FindCameraIndex(VideoCaptureDeviceInfo[] cameras, bool preferFront)
    {
        if (cameras == null || cameras.Length == 0)
        {
            return 0;
        }

        var preferred = preferFront ? VideoCaptureDeviceFacing.Front : VideoCaptureDeviceFacing.Back;
        for (var i = 0; i < cameras.Length; i++)
        {
            if (cameras[i].Facing == preferred)
            {
                return i;
            }
        }

        var fallback = preferFront ? VideoCaptureDeviceFacing.Back : VideoCaptureDeviceFacing.Front;
        for (var i = 0; i < cameras.Length; i++)
        {
            if (cameras[i].Facing == fallback)
            {
                return i;
            }
        }

        return 0;
    }

        /// <summary>
        /// Update the capture button's inner shape — red dot when idle, red square when recording.
        /// </summary>
    private void UpdateCaptureButtonAppearance()
    {
        // ToArray() snapshot — iterating _btStartCapture.Subviews directly while calling
        // RemoveFromSuperview mutates the underlying NSArray during enumeration (the next
        // element is skipped, or UIKit throws on some versions). Also Dispose the removed
        // subview so the managed UIView peer releases its CALayer + auto-layout constraints
        // right away instead of waiting for GC.
        foreach (var sub in _btStartCapture.Subviews.ToArray())
        {
            if (sub.Tag == 99)
            {
                sub.RemoveFromSuperview();
                sub.Dispose();
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

        // Install the VC into the window BEFORE building the subview hierarchy so
        // `vc.View.Bounds` is non-zero when VideoView/Metal initialises. Previously we
        // touched `vc.View` right after `new UIViewController()`, which fires loadView
        // on an orphan VC whose view has Bounds = CGRect.Empty. Metal drawables created
        // against a zero-sized layer don't gain a surface even after AutoresizingMask
        // later resizes the UIView — the camera records fine (LED on) but preview stays
        // black.
        Window.RootViewController = vc;
        Window.MakeKeyAndVisible();
        vc.View.LayoutIfNeeded();

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

        VisioForgeX.InitSDK();

        // start preview in UI thread — wrap the body in try/catch so permission denial, a
        // missing HD format, or a StartAsync throw surfaces as a log/toast instead of
        // terminating the app. Passing an async lambda to InvokeOnMainThread gives it
        // async-void semantics; without the catch, any throw escapes to UIKit's runloop.
        InvokeOnMainThread(async () =>
        {
            try
            {
                await StartAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Initial capture start failed: {ex}");
                var root = Window?.RootViewController;
                if (root != null)
                {
                    Toast.Show("Initial capture failed: " + ex.Message, root);
                }
            }
        });

        return true;
    }
}