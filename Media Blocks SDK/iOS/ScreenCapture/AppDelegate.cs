using Photos;
using ReplayKit;
using System.Diagnostics;
using System.Globalization;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Apple.Sources;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.UI.Apple;

namespace ScreenCapture
{
    /// <summary>
    /// System-wide screen capture demo. Uses a paired Broadcast Upload Extension that feeds
    /// NV12 frames over a Unix domain socket inside a shared App Group container. When the
    /// user taps the red RPSystemBroadcastPickerView, iOS launches the extension and it
    /// connects to our SDK's IOSBroadcastSourceX listener — preview + optional MP4 recording
    /// flow through the normal GStreamer MediaBlocks pipeline.
    /// </summary>
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        private const string AppGroupId = "group.com.visioforge.screencapture";
        private const string ExtensionBundleId = "com.visioforge.screencapture.extension";

        private MediaBlocksPipeline _pipeline;
        private string _recordingFilename;

        private MediaBlock _videoRenderer;
        private ScreenSourceBlock _videoSource;
        private MediaBlock _videoEncoder;
        private MediaBlock _sink;
        private TeeBlock _videoTee;

        private VideoView _videoView;

        private UIButton _btRecord;
        private UIView _recordInner;
        private UILabel _lbDuration;
        private UILabel _lbStatus;
        private RPSystemBroadcastPickerView _broadcastPicker;

        private NSTimer _durationTimer;
        private DateTime _pipelineStartedAt;
        private bool _isRecording;

        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var vc = new UIViewController();
            vc.View!.BackgroundColor = UIColor.Black;

            AddVideoView(vc.View);
            AddControls(vc.View);

            PHPhotoLibrary.RequestAuthorization(_ => { });

            Window.RootViewController = vc;
            Window.MakeKeyAndVisible();

            VisioForgeX.InitSDK();

            // Set the helpful prompt BEFORE we kick off the pipeline. StartPipelineAsync blocks
            // until the extension connects and sends the first frame, which only happens after
            // the user taps the broadcast picker — so updating status after would deadlock the
            // UI on "Initializing...".
            _lbStatus.Text = "Tap the red broadcast icon and pick ScreenCaptureExtension.";

            // Kick off the pipeline — socket listener starts waiting for the extension to connect.
            // Run fully on a background Task so the UI thread stays responsive.
            _ = Task.Run(async () =>
            {
                try
                {
                    await StartPipelineAsync(record: true);
                    UIApplication.SharedApplication.InvokeOnMainThread(() =>
                    {
                        _isRecording = true;
                        UpdateRecordButton();
                        _lbStatus.Text = "Receiving frames from extension.";
                    });
                }
                catch (Exception ex)
                {
                    UIApplication.SharedApplication.InvokeOnMainThread(() => _lbStatus.Text = "Pipeline error: " + ex.Message);
                }
            });

            return true;
        }

        /// <summary>
        /// Bring up the GStreamer pipeline with a ScreenSourceBlock wrapping IOSBroadcastSourceX.
        /// When <paramref name="record"/> is true the tee also feeds an H264/MP4 sink writing to
        /// the app's Library directory.
        /// </summary>
        private async Task StartPipelineAsync(bool record)
        {
            await StopPipelineAsync();

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;

            var settings = new IOSBroadcastSourceSettings(AppGroupId);
            // No timeout: Init() returns after the first frame, which only arrives once the user
            // starts a broadcast. Using a long timeout + running on a background task avoids
            // blocking the main thread.
            settings.FirstFrameTimeout = TimeSpan.FromMinutes(10);

            _videoSource = new ScreenSourceBlock(settings);

            _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
            _videoRenderer = new VideoRendererBlock(_pipeline, _videoView) { IsSync = false };

            _pipeline.Connect(_videoSource.Output, _videoTee.Input);
            _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);

            if (record)
            {
                _videoEncoder = new H264EncoderBlock(new AppleMediaH264EncoderSettings());
                _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);

                var libraryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library");
                Directory.CreateDirectory(libraryPath);
                _recordingFilename = Path.Combine(libraryPath, $"screen_{DateTime.Now:yyyyMMdd_HHmmss}.mp4");

                _sink = new MP4SinkBlock(new MP4SinkSettings(_recordingFilename));
                _pipeline.Connect(_videoEncoder.Output, (_sink as MP4SinkBlock).CreateNewInput(MediaBlockPadMediaType.Video));
            }

            // StartAsync blocks inside ScreenSourceBlock.Build → IOSBroadcastSourceX.Init until
            // the first frame arrives from the extension. Run it off the main thread.
            await Task.Run(async () => await _pipeline.StartAsync());

            _pipelineStartedAt = DateTime.Now;

            // Every UIKit touch here must be on the main thread — we're called from a background
            // Task in FinishedLaunching / from the record-toggle handler.
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                _lbDuration.Text = "00:00:00";
                _durationTimer?.Invalidate();
                _durationTimer = NSTimer.CreateRepeatingScheduledTimer(TimeSpan.FromSeconds(1), _ =>
                {
                    var elapsed = DateTime.Now - _pipelineStartedAt;
                    _lbDuration.Text = elapsed.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture);
                });
            });
        }

        private async Task StopPipelineAsync()
        {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                _durationTimer?.Invalidate();
                _durationTimer = null;
            });

            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                await _pipeline.StopAsync(force: false);
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            var saved = _recordingFilename;
            _recordingFilename = null;

            if (!string.IsNullOrEmpty(saved) && File.Exists(saved))
            {
                // StopAsync(force:false) already propagated EOS and waited for the muxer to
                // write the moov atom, so we can copy straight away.
                UIApplication.SharedApplication.InvokeOnMainThread(() => SaveVideoToPhotoLibrary(saved));
            }
        }

        private void SaveVideoToPhotoLibrary(string path)
        {
            PHPhotoLibrary.SharedPhotoLibrary.PerformChanges(() =>
            {
                var req = PHAssetCreationRequest.CreationRequestForAsset();
                req.AddResource(PHAssetResourceType.Video, NSUrl.FromFilename(path), null);
            }, (success, error) =>
            {
                if (success)
                {
                    InvokeOnMainThread(() => Toast.Show("Saved to Photos", Window.RootViewController));
                }
                else
                {
                    Debug.WriteLine($"Save failed: {error?.LocalizedDescription}");
                }
            });
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine("[Pipeline] " + e.Message);
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                if (_lbStatus != null) _lbStatus.Text = "Error: " + e.Message;
            });
        }

        /// <summary>
        /// Full-screen Metal VideoView.
        /// </summary>
        private void AddVideoView(UIView parent)
        {
            _videoView = new VideoView(parent.Bounds)
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight,
                BackgroundColor = UIColor.Black,
                DisableAspectRatioResize = true
            };
            parent.AddSubview(_videoView);
        }

        /// <summary>
        /// Bottom control bar: status label + duration + record toggle + broadcast picker icon.
        /// </summary>
        private void AddControls(UIView parent)
        {
            var controlBar = new UIView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                BackgroundColor = UIColor.FromWhiteAlpha(0f, 0.45f)
            };
            parent.AddSubview(controlBar);

            NSLayoutConstraint.ActivateConstraints(new[]
            {
                controlBar.LeadingAnchor.ConstraintEqualTo(parent.LeadingAnchor),
                controlBar.TrailingAnchor.ConstraintEqualTo(parent.TrailingAnchor),
                controlBar.BottomAnchor.ConstraintEqualTo(parent.BottomAnchor),
                controlBar.HeightAnchor.ConstraintEqualTo(170f)
            });

            _lbStatus = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                TextColor = UIColor.White,
                Font = UIFont.SystemFontOfSize(12f, UIFontWeight.Regular),
                TextAlignment = UITextAlignment.Center,
                Text = "Initializing...",
                Lines = 2,
                LineBreakMode = UILineBreakMode.TailTruncation
            };
            controlBar.AddSubview(_lbStatus);

            _lbDuration = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                TextColor = UIColor.White,
                Font = UIFont.SystemFontOfSize(15f, UIFontWeight.Semibold),
                TextAlignment = UITextAlignment.Center,
                Text = "00:00:00"
            };
            controlBar.AddSubview(_lbDuration);

            // Record toggle — toggles the H264/MP4 sink branch; does NOT start/stop broadcast.
            _btRecord = new UIButton(UIButtonType.Custom)
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                BackgroundColor = UIColor.Clear
            };
            _btRecord.Layer.CornerRadius = 32f;
            _btRecord.Layer.BorderWidth = 4f;
            _btRecord.Layer.BorderColor = UIColor.White.CGColor;
            controlBar.AddSubview(_btRecord);
            UpdateRecordButton();

            _btRecord.TouchUpInside += async (s, e) =>
            {
                // Always-record model: tapping the big button finalises the MP4 and copies to
                // Photos. To start again, user taps the red broadcast icon (which stops any
                // active broadcast and re-starts it — iOS picker handles the second tap).
                await StopPipelineAsync();
                _isRecording = false;
                UpdateRecordButton();
                UIApplication.SharedApplication.InvokeOnMainThread(() =>
                {
                    _lbStatus.Text = "Stopped. Tap broadcast icon to start again.";
                });
                // Re-arm a fresh socket listener for the next broadcast session.
                _ = Task.Run(async () =>
                {
                    try
                    {
                        await StartPipelineAsync(record: true);
                        UIApplication.SharedApplication.InvokeOnMainThread(() =>
                        {
                            _isRecording = true;
                            UpdateRecordButton();
                            _lbStatus.Text = "Receiving frames from extension.";
                        });
                    }
                    catch (Exception ex)
                    {
                        UIApplication.SharedApplication.InvokeOnMainThread(() => _lbStatus.Text = "Pipeline error: " + ex.Message);
                    }
                });
            };

            // RPSystemBroadcastPickerView — the red broadcast icon that launches the extension.
            // Apple renders this as an internal UIButton that often doesn't respond to taps
            // through the UIView wrapper alone. We hide the wrapper and route taps from our own
            // visible button into the picker's internal button via UIControl.SendActions.
            _broadcastPicker = new RPSystemBroadcastPickerView(new CGRect(0, 0, 64, 64))
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                PreferredExtension = ExtensionBundleId,
                ShowsMicrophoneButton = false,
                Hidden = true
            };
            controlBar.AddSubview(_broadcastPicker);

            var btBroadcast = new UIButton(UIButtonType.Custom)
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                BackgroundColor = UIColor.SystemRed,
                TintColor = UIColor.White
            };
            btBroadcast.Layer.CornerRadius = 32f;
            var bcConfig = UIImageSymbolConfiguration.Create(26f, UIImageSymbolWeight.Semibold);
            btBroadcast.SetImage(UIImage.GetSystemImage("dot.radiowaves.left.and.right", bcConfig), UIControlState.Normal);
            btBroadcast.TouchUpInside += (s, e) => TriggerBroadcastPicker();
            controlBar.AddSubview(btBroadcast);

            NSLayoutConstraint.ActivateConstraints(new[]
            {
                _lbStatus.LeadingAnchor.ConstraintEqualTo(controlBar.SafeAreaLayoutGuide.LeadingAnchor, 20f),
                _lbStatus.TrailingAnchor.ConstraintEqualTo(controlBar.SafeAreaLayoutGuide.TrailingAnchor, -20f),
                _lbStatus.TopAnchor.ConstraintEqualTo(controlBar.TopAnchor, 10f),

                _lbDuration.CenterXAnchor.ConstraintEqualTo(controlBar.CenterXAnchor),
                _lbDuration.TopAnchor.ConstraintEqualTo(_lbStatus.BottomAnchor, 4f),

                _btRecord.CenterYAnchor.ConstraintEqualTo(controlBar.SafeAreaLayoutGuide.BottomAnchor, -44f),
                _btRecord.TrailingAnchor.ConstraintEqualTo(controlBar.CenterXAnchor, -20f),
                _btRecord.WidthAnchor.ConstraintEqualTo(64f),
                _btRecord.HeightAnchor.ConstraintEqualTo(64f),

                _broadcastPicker.CenterYAnchor.ConstraintEqualTo(_btRecord.CenterYAnchor),
                _broadcastPicker.LeadingAnchor.ConstraintEqualTo(controlBar.CenterXAnchor, 20f),
                _broadcastPicker.WidthAnchor.ConstraintEqualTo(64f),
                _broadcastPicker.HeightAnchor.ConstraintEqualTo(64f),

                btBroadcast.CenterYAnchor.ConstraintEqualTo(_btRecord.CenterYAnchor),
                btBroadcast.LeadingAnchor.ConstraintEqualTo(controlBar.CenterXAnchor, 20f),
                btBroadcast.WidthAnchor.ConstraintEqualTo(64f),
                btBroadcast.HeightAnchor.ConstraintEqualTo(64f)
            });
        }

        /// <summary>
        /// Walk the RPSystemBroadcastPickerView's subview tree to find the internal UIButton
        /// Apple renders, and programmatically send it a TouchUpInside event. This is the
        /// established workaround — the picker's outer UIView doesn't forward taps reliably.
        /// </summary>
        private void TriggerBroadcastPicker()
        {
            if (_broadcastPicker == null)
            {
                return;
            }

            foreach (var sub in _broadcastPicker.Subviews)
            {
                if (sub is UIButton button)
                {
                    button.SendActionForControlEvents(UIControlEvent.TouchUpInside);
                    return;
                }

                foreach (var innerSub in sub.Subviews)
                {
                    if (innerSub is UIButton innerBtn)
                    {
                        innerBtn.SendActionForControlEvents(UIControlEvent.TouchUpInside);
                        return;
                    }
                }
            }
        }

        private void UpdateRecordButton()
        {
            _recordInner?.RemoveFromSuperview();

            _recordInner = new UIView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                BackgroundColor = UIColor.SystemRed,
                UserInteractionEnabled = false
            };
            _recordInner.Layer.CornerRadius = _isRecording ? 6f : 24f;

            _btRecord.AddSubview(_recordInner);

            var size = _isRecording ? 28f : 48f;
            NSLayoutConstraint.ActivateConstraints(new[]
            {
                _recordInner.CenterXAnchor.ConstraintEqualTo(_btRecord.CenterXAnchor),
                _recordInner.CenterYAnchor.ConstraintEqualTo(_btRecord.CenterYAnchor),
                _recordInner.WidthAnchor.ConstraintEqualTo(size),
                _recordInner.HeightAnchor.ConstraintEqualTo(size)
            });
        }
    }
}
