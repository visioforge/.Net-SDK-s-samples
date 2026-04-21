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
        private UIButton _btBroadcast;

        private NSTimer _durationTimer;
        private DateTime _pipelineStartedAt;
        private bool _isRecording;

        // Re-entrancy guard for the record-toggle button. The handler is async void and
        // awaits StopPipelineAsync — without the guard, rapid taps would re-enter
        // StopPipelineAsync against a pipeline still mid-startup on the Task.Run branch.
        private int _recordToggleBusy;

        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var vc = new UIViewController();
            vc.View!.BackgroundColor = UIColor.Black;

            AddVideoView(vc.View);
            AddControls(vc.View);

            // Request Photos add-only access (iOS 14+): we only need to save a recording
            // into the library, not read it back. The full-library overload
            // (PHPhotoLibrary.RequestAuthorization(Action<PHAuthorizationStatus>)) requires
            // the NSPhotoLibraryUsageDescription key and triggers a heavier consent prompt;
            // in some app configurations the OS aborts with SIGABRT if the key is missing.
            PHPhotoLibrary.RequestAuthorization(PHAccessLevel.AddOnly, _ => { });

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
            // Init() only returns once the first frame arrives — that requires the user to pick
            // our app in the broadcast picker and hit "Start". Pinning the pipeline-start task for
            // 10 minutes was operationally unpleasant: on backgrounding the task kept the socket
            // open, and if the user never started a broadcast we waited the full duration before
            // any cleanup could run. 2 minutes is the upper bound of "user intended to start and
            // is still fiddling"; longer waits are almost always user-abandoned sessions.
            //
            // A proper fix would thread a CancellationToken through IOSBroadcastSourceSettings /
            // IOSBroadcastSourceX and cancel on UIApplicationWillResignActive / user cancel —
            // tracked separately because it requires an SDK-surface change.
            settings.FirstFrameTimeout = TimeSpan.FromMinutes(2);

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
                    // StopPipelineAsync invalidates the timer asynchronously via
                    // InvokeOnMainThread, so a tick scheduled earlier can still fire
                    // after _pipeline is gone. Guard against stale _pipelineStartedAt /
                    // disposed _lbDuration.
                    var label = _lbDuration;
                    if (_pipeline == null || label == null || label.Handle == IntPtr.Zero)
                    {
                        return;
                    }

                    var elapsed = DateTime.Now - _pipelineStartedAt;
                    label.Text = elapsed.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture);
                });
            });
        }

        private async Task StopPipelineAsync()
        {
            // UIApplication.InvokeOnMainThread is performSelectorOnMainThread:waitUntilDone:YES —
            // it blocks this Task.Run thread until the invalidate block finishes, so by the time
            // this returns the timer is guaranteed to be off the runloop and _durationTimer is
            // null. A tick already in-flight on the main thread is bounded by its own guards
            // (_pipeline null-check and _lbDuration.Handle validity).
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                _durationTimer?.Invalidate();
                _durationTimer = null;
            });

            if (_pipeline != null)
            {
                // StopAsync can raise bus errors (EOS/error during shutdown) — keep the
                // OnError handler subscribed across StopAsync so we see them. Detach only
                // after the pipeline has reached NULL state, right before Dispose.
                await _pipeline.StopAsync(force: false);
                _pipeline.OnError -= Pipeline_OnError;
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            var saved = _recordingFilename;
            _recordingFilename = null;

            if (!string.IsNullOrEmpty(saved))
            {
                // File.Exists is rechecked inside SaveVideoToPhotoLibrary on the UI thread;
                // this avoids a background-task race where the muxer's final flush hasn't
                // yet made the file visible.
                UIApplication.SharedApplication.InvokeOnMainThread(() => SaveVideoToPhotoLibrary(saved));
            }
        }

        /// <summary>
        /// Probe whether a broadcast-upload extension with the given bundle id is packaged in
        /// the main app bundle's PlugIns directory. Returns false if the extension bundle is
        /// missing so callers can fall back to an "all extensions" picker instead of silently
        /// showing an empty list.
        /// </summary>
        private static bool IsBroadcastExtensionInstalled(string bundleId)
        {
            if (string.IsNullOrEmpty(bundleId))
            {
                return false;
            }

            try
            {
                var plugIns = NSBundle.MainBundle.BuiltInPluginsUrl;
                if (plugIns == null || !System.IO.Directory.Exists(plugIns.Path))
                {
                    return false;
                }

                foreach (var entry in System.IO.Directory.EnumerateDirectories(plugIns.Path, "*.appex"))
                {
                    var bundle = NSBundle.FromPath(entry);
                    if (bundle?.BundleIdentifier == bundleId)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"IsBroadcastExtensionInstalled({bundleId}) threw: {ex}");
            }

            return false;
        }

        /// <summary>
        /// Show a toast only if we have a root view controller to anchor it to. Toast.Show
        /// dereferences controller.View.Frame.Size.Height without a null-check, and Photos
        /// completion callbacks can fire after the app has been backgrounded or the root VC
        /// has gone — in which case Window.RootViewController is null and the bare call
        /// would NRE. Must be called on the main thread.
        /// </summary>
        private void ShowToastIfPresentable(string message)
        {
            var root = Window?.RootViewController;
            if (root == null)
            {
                Debug.WriteLine($"Toast suppressed (no root VC): {message}");
                return;
            }

            Toast.Show(message, root);
        }

        private void SaveVideoToPhotoLibrary(string path)
        {
            // #140: the File.Exists check used to run on the background stop-task immediately
            // after StopAsync — moov-atom finalisation could still be flushing, so the file
            // intermittently appeared missing. Re-checking here (on the UI thread right
            // before PerformChanges) closes that window.
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                Debug.WriteLine($"SaveVideoToPhotoLibrary: file missing at '{path}'");
                InvokeOnMainThread(() => ShowToastIfPresentable("Recording file was not produced."));
                return;
            }

            // Bail out quietly if the user denied Photos access earlier — PerformChanges
            // would otherwise call back with a not-authorised error on every stop.
            var status = PHPhotoLibrary.GetAuthorizationStatus(PHAccessLevel.AddOnly);
            if (status != PHAuthorizationStatus.Authorized && status != PHAuthorizationStatus.Limited)
            {
                Debug.WriteLine($"SaveVideoToPhotoLibrary: Photos access not granted ({status})");
                InvokeOnMainThread(() => ShowToastIfPresentable("Grant Photos access to save recordings."));
                return;
            }

            PHPhotoLibrary.SharedPhotoLibrary.PerformChanges(() =>
            {
                var req = PHAssetCreationRequest.CreationRequestForAsset();
                req.AddResource(PHAssetResourceType.Video, NSUrl.FromFilename(path), null);
            }, (success, error) =>
            {
                if (success)
                {
                    InvokeOnMainThread(() => ShowToastIfPresentable("Saved to Photos"));
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
                // The bus thread can raise OnError concurrently with teardown. Null-check
                // isn't enough: the UILabel's managed peer can be alive (reference held)
                // while its native NSObject has been released — setting .Text then crashes.
                // Handle == IntPtr.Zero catches that window.
                var lbl = _lbStatus;
                if (lbl != null && lbl.Handle != IntPtr.Zero)
                {
                    lbl.Text = "Error: " + e.Message;
                }
            });
        }

        /// <summary>
        /// Full-screen Metal VideoView, pinned with Auto Layout to match the rest of the UI.
        /// Mixing autoresizing with the Auto-Layout control bar produced layout warnings on
        /// rotation and inconsistent drawing order.
        /// </summary>
        private void AddVideoView(UIView parent)
        {
            _videoView = new VideoView(parent.Bounds)
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                BackgroundColor = UIColor.Black,
                DisableAspectRatioResize = true
            };
            parent.AddSubview(_videoView);

            NSLayoutConstraint.ActivateConstraints(new[]
            {
                _videoView.LeadingAnchor.ConstraintEqualTo(parent.LeadingAnchor),
                _videoView.TrailingAnchor.ConstraintEqualTo(parent.TrailingAnchor),
                _videoView.TopAnchor.ConstraintEqualTo(parent.TopAnchor),
                _videoView.BottomAnchor.ConstraintEqualTo(parent.BottomAnchor)
            });
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
                // Drop the tap if a previous toggle is still running: otherwise we'd enter
                // StopPipelineAsync while the background Task.Run was still bringing a new
                // pipeline up, which NRE's on half-initialised _pipeline.
                if (System.Threading.Interlocked.CompareExchange(ref _recordToggleBusy, 1, 0) != 0)
                {
                    return;
                }

                _btRecord.Enabled = false;
                try
                {
                    // Always-record model: tapping the big button finalises the MP4 and copies to
                    // Photos. To start again, user taps the red broadcast icon (which stops any
                    // active broadcast and re-starts it — iOS picker handles the second tap).
                    //
                    // After StopPipelineAsync the continuation resumes on a GStreamer bus
                    // worker — mutating _isRecording and calling UpdateRecordButton (which
                    // touches UIView + NSLayoutConstraints) from there is UIKit-undefined
                    // and can race/corrupt the UI. Marshal the state write and the button
                    // update together with the status-label set.
                    await StopPipelineAsync();
                    UIApplication.SharedApplication.InvokeOnMainThread(() =>
                    {
                        _isRecording = false;
                        UpdateRecordButton();
                        _lbStatus.Text = "Stopped. Tap broadcast icon to start again.";
                    });

                    // Re-arm a fresh socket listener for the next broadcast session. Run the
                    // re-arm inline on this async-void path so _recordToggleBusy/_btRecord
                    // are released only after the new pipeline is either up or has errored
                    // — avoids a window where the user can tap again and race teardown with
                    // the in-flight start.
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
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Record toggle failed: " + ex);
                    UIApplication.SharedApplication.InvokeOnMainThread(() => _lbStatus.Text = "Stop error: " + ex.Message);
                }
                finally
                {
                    _btRecord.Enabled = true;
                    System.Threading.Interlocked.Exchange(ref _recordToggleBusy, 0);
                }
            };

            // RPSystemBroadcastPickerView — the red broadcast icon that launches the extension.
            // Apple renders this as an internal UIButton that often doesn't respond to taps
            // through the UIView wrapper alone. We hide the wrapper and route taps from our own
            // visible button into the picker's internal button via UIControl.SendActions.
            //
            // PreferredExtension is only set when the bundle is actually present in the main
            // app's Plug-Ins directory. Pointing PreferredExtension at a non-existent bundle
            // leaves the picker showing an empty list with no error surfaced to the user —
            // leaving it null shows all extensions so the user can at least see what's
            // installed and we log a diagnostic instead of silently misbehaving.
            _broadcastPicker = new RPSystemBroadcastPickerView(new CGRect(0, 0, 64, 64))
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                ShowsMicrophoneButton = false,
                Hidden = true
            };

            if (IsBroadcastExtensionInstalled(ExtensionBundleId))
            {
                _broadcastPicker.PreferredExtension = ExtensionBundleId;
            }
            else
            {
                Debug.WriteLine($"Broadcast extension '{ExtensionBundleId}' not found in PlugIns — leaving PreferredExtension unset so the picker shows all installed extensions.");
            }
            controlBar.AddSubview(_broadcastPicker);

            _btBroadcast = new UIButton(UIButtonType.Custom)
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                BackgroundColor = UIColor.SystemRed,
                TintColor = UIColor.White
            };
            _btBroadcast.Layer.CornerRadius = 32f;
            var bcConfig = UIImageSymbolConfiguration.Create(26f, UIImageSymbolWeight.Semibold);
            _btBroadcast.SetImage(UIImage.GetSystemImage("dot.radiowaves.left.and.right", bcConfig), UIControlState.Normal);
            _btBroadcast.TouchUpInside += (s, e) => TriggerBroadcastPicker();
            controlBar.AddSubview(_btBroadcast);

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

                // Pin _btBroadcast on top of _broadcastPicker (same slot) instead of
                // re-stating identical constraints against the control bar — the two
                // coordinate systems used to drift apart if one side was tweaked.
                _btBroadcast.CenterXAnchor.ConstraintEqualTo(_broadcastPicker.CenterXAnchor),
                _btBroadcast.CenterYAnchor.ConstraintEqualTo(_broadcastPicker.CenterYAnchor),
                _btBroadcast.WidthAnchor.ConstraintEqualTo(_broadcastPicker.WidthAnchor),
                _btBroadcast.HeightAnchor.ConstraintEqualTo(_broadcastPicker.HeightAnchor)
            });
        }

        /// <summary>
        /// Walk the RPSystemBroadcastPickerView's subview tree to find the internal UIButton
        /// Apple renders, and programmatically send it a TouchUpInside event. This is the
        /// established workaround — the picker's outer UIView doesn't forward taps reliably.
        /// Apple's private subview layout is not guaranteed across iOS releases, so if no
        /// UIButton is found we un-hide the picker as a fallback and show a toast instructing
        /// the user to tap it directly.
        /// </summary>
        private void TriggerBroadcastPicker()
        {
            if (_broadcastPicker == null)
            {
                return;
            }

            // Recurse through the subview tree. RPSystemBroadcastPickerView nested the
            // internal UIButton two levels deep up through iOS 16, then three levels deep
            // on iOS 17+ — a fixed two-level walk fell through to the fallback path every
            // tap on modern iOS and made the custom red button disappear.
            var button = FindDescendantButton(_broadcastPicker);
            if (button != null)
            {
                button.SendActionForControlEvents(UIControlEvent.TouchUpInside);
                return;
            }

            // Fallback: on iOS versions where the picker's internal layout changes, make
            // the native picker visible and move our proxy button out of the way so the
            // user can tap the picker directly. This is one-shot — once the fallback
            // path triggers, we leave the picker exposed for the rest of the session.
            _broadcastPicker.Hidden = false;
            if (_btBroadcast != null)
            {
                _btBroadcast.Hidden = true;
            }
            ShowToastIfPresentable("Tap the red broadcast icon to start.");
        }

        /// <summary>
        /// Depth-first search for a UIButton descendant. Used to locate
        /// RPSystemBroadcastPickerView's private trigger button, which Apple has moved
        /// around the view tree between iOS releases.
        /// </summary>
        private static UIButton? FindDescendantButton(UIView view)
        {
            if (view is UIButton btn)
            {
                return btn;
            }

            foreach (var sub in view.Subviews)
            {
                var r = FindDescendantButton(sub);
                if (r != null)
                {
                    return r;
                }
            }

            return null;
        }

        private void UpdateRecordButton()
        {
            // RemoveFromSuperview detaches but doesn't release the managed peer. Toggling
            // record state repeatedly would otherwise accumulate orphaned UIViews with
            // their NSObject peers pinned alive — real memory leak over long sessions.
            if (_recordInner != null)
            {
                _recordInner.RemoveFromSuperview();
                _recordInner.Dispose();
                _recordInner = null;
            }

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
