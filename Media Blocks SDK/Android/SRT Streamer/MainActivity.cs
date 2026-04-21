using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core;
using VisioForge.Core.Types.Events;
using Android;
using Android.App;
using Android.Util;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.Types;
using System.Diagnostics;
using Activity = Android.App.Activity;

namespace SRT_Streamer
{
    [Activity(Label = "@string/app_name", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, Theme = "@android:style/Theme.NoTitleBar.Fullscreen")]
    public class MainActivity : Activity
    {
        private VisioForge.Core.UI.Android.VideoViewGL videoView;

        private ImageButton btStartStream;

        private ImageButton btSwitchCam;

        private ImageButton btSettings;

        private TextView tvErrors;

        private TextView tvStatus;

        private readonly System.Timers.Timer tmPosition = new System.Timers.Timer(500);

        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private SystemVideoSourceBlock _videoSource;

        private MediaBlock _audioSource;

        private H264EncoderBlock _videoEncoder;

        private AACEncoderBlock _audioEncoder;

        private SRTMPEGTSSinkBlock _srtSink;

        private TeeBlock _videoTee;

        private TeeBlock _audioTee;

        private int _cameraIndex = 1;

        private VideoCaptureDeviceInfo[] _cameras;

        private bool _isPreview;

        private bool _isStreaming;

        // SRT settings — persisted across dialog invocations.
        private string _srtUri = "srt://192.168.1.44:8890?streamid=publish:mobile";
        private int _srtLatencyMs = 750;
        private int _srtModeIndex; // 0 caller, 1 listener, 2 rendezvous

        // Re-entrancy gate for record / camera-flip taps. Both handlers mutate _pipeline and
        // SystemVideoSourceBlock; overlapping calls race on _videoSource / _pipeline fields.
        private int _busy;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            RequestPermissions(
               new string[]{
                        Manifest.Permission.Camera,
                        Manifest.Permission.Internet,
                        Manifest.Permission.RecordAudio,
                        Manifest.Permission.ModifyAudioSettings
               }, 1004);

            videoView = FindViewById<VisioForge.Core.UI.Android.VideoViewGL>(Resource.Id.videoView);

            btStartStream = FindViewById<ImageButton>(Resource.Id.btStartStream);
            btStartStream.Click += btStartStream_Click;

            btSwitchCam = FindViewById<ImageButton>(Resource.Id.btSwitchCam);
            btSwitchCam.Click += btSwitchCam_Click;

            btSettings = FindViewById<ImageButton>(Resource.Id.btSettings);
            btSettings.Click += btSettings_Click;

            tvErrors = FindViewById<TextView>(Resource.Id.tvErrors);
            tvStatus = FindViewById<TextView>(Resource.Id.tvStatus);

            // Fullscreen theme puts the app under the nav bar so video runs edge-to-edge.
            // Without a bottom inset the gesture pill / 3-button nav bar overlaps the Record /
            // Settings / Flip icons. Pad only the control bar by the system window inset so the
            // video surface stays edge-to-edge but the icons remain tappable.
            var controlBar = FindViewById<FrameLayout>(Resource.Id.controlBar);
            controlBar.SetOnApplyWindowInsetsListener(new NavBarInsetListener(controlBar));

            CheckPermissionsAndStartPreview();
        }

        /// <summary>
        /// Pads the control bar's bottom padding with the system navigation-bar inset so the
        /// icons don't collide with the gesture pill. Works on both gesture and 3-button nav:
        /// SystemWindowInsetBottom reports the correct reserved region in either mode.
        /// </summary>
        private sealed class NavBarInsetListener : Java.Lang.Object, View.IOnApplyWindowInsetsListener
        {
            private readonly View _target;
            private readonly int _basePaddingBottom;

            public NavBarInsetListener(View target)
            {
                _target = target;
                _basePaddingBottom = target.PaddingBottom;
            }

            public WindowInsets OnApplyWindowInsets(View v, WindowInsets insets)
            {
                _target.SetPadding(
                    _target.PaddingLeft,
                    _target.PaddingTop,
                    _target.PaddingRight,
                    _basePaddingBottom + insets.SystemWindowInsetBottom);
                return insets;
            }
        }

        protected override async void OnDestroy()
        {
            try
            {
                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    await _pipeline.DisposeAsync();
                    _pipeline = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            VisioForgeX.DestroySDK();

            base.OnDestroy();
        }

        private void CheckPermissionsAndStartPreview()
        {
            if (CheckSelfPermission(Manifest.Permission.Camera) != Android.Content.PM.Permission.Granted)
            {
                return;
            }

            if (CheckSelfPermission(Manifest.Permission.RecordAudio) != Android.Content.PM.Permission.Granted)
            {
                return;
            }


            Task.Run(async () =>
            {
                if (_isPreview)
                {
                    return;
                }

                _isPreview = true;

                await StartPreviewAsync();
            });
        }

        private async Task CreateEngineAsync(bool forStreaming)
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
                RunOnUiThread(() => Toast.MakeText(this, "No video sources found", ToastLength.Long).Show());
                return;
            }

            if (_cameraIndex >= _cameras.Length)
            {
                _cameraIndex = 0;
            }

            var videoSourceSettings = BuildVideoSourceSettings(_cameras[_cameraIndex]);
            if (videoSourceSettings == null)
            {
                RunOnUiThread(() => Toast.MakeText(this, "Unable to configure camera settings", ToastLength.Long).Show());
                return;
            }

            _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, videoView) { IsSync = false };

            if (forStreaming)
            {
                _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
                _pipeline.Connect(_videoSource.Output, _videoTee.Input);
                _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
            }
            else
            {
                // preview only: direct connection, no tee
                _pipeline.Connect(_videoSource.Output, _videoRenderer.Input);
            }

            // audio source
            _audioSource = new SystemAudioSourceBlock(new AndroidAudioSourceSettings());

            // audio renderer
            var audioSinks = await DeviceEnumerator.Shared.AudioOutputsAsync();
            if (forStreaming)
            {
                _audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);
                _pipeline.Connect(_audioSource.Output, _audioTee.Input);

                if (audioSinks.Length > 0)
                {
                    _audioRenderer = new AudioRendererBlock(audioSinks[0]) { IsSync = false };
                    _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);
                }
            }
            else
            {
                // preview only: direct connection or skip audio
                if (audioSinks.Length > 0)
                {
                    _audioRenderer = new AudioRendererBlock(audioSinks[0]) { IsSync = false };
                    _pipeline.Connect(_audioSource.Output, _audioRenderer.Input);
                }
            }
        }

        /// <summary>
        /// Picks the camera's 1080p@30 (or HD fallback) format and wraps it in
        /// VideoCaptureDeviceSourceSettings. Shared by CreateEngineAsync and the live-switch
        /// path so both sides pick identical format negotiation.
        /// </summary>
        private static VideoCaptureDeviceSourceSettings BuildVideoSourceSettings(VideoCaptureDeviceInfo device)
        {
            if (device == null)
            {
                return null;
            }

            var formatItem = device.GetVideoFormatAndFrameRate(1920, 1080, out var frameRate);
            formatItem ??= device.GetHDOrAnyVideoFormatAndFrameRate(out frameRate);
            if (formatItem == null)
            {
                return null;
            }

            var settings = new VideoCaptureDeviceSourceSettings(device)
            {
                Format = formatItem.ToFormat()
            };
            settings.Format.FrameRate = frameRate;
            return settings;
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
            Log.Error("MainActivity", e.Message);

            RunOnUiThread(() =>
            {
                tvErrors.Visibility = Android.Views.ViewStates.Visible;
                tvErrors.Text = e.Message;
            });
        }

        private async void btSwitchCam_Click(object sender, EventArgs e)
        {
            // Rapid flips pre-fix stacked StopAsync/StartPreview calls that raced on _pipeline;
            // Interlocked gate collapses repeated taps into a single transition.
            if (System.Threading.Interlocked.CompareExchange(ref _busy, 1, 0) != 0)
            {
                return;
            }

            btSwitchCam.Enabled = false;
            try
            {
                if (_cameras == null || _cameras.Length < 2)
                {
                    RunOnUiThread(() => Toast.MakeText(this, "Only one camera available", ToastLength.Short).Show());
                    return;
                }

                var newIndex = (_cameraIndex == 0) ? 1 : 0;
                if (newIndex >= _cameras.Length)
                {
                    return;
                }

                // Fast path: swap the capture device in-place on the live SystemVideoSourceBlock
                // so the rest of the pipeline (tee, encoder, SRT sink) keeps running without a
                // stop/rebuild. Matches the VCX SimpleVideoCapture flow: if the new device can
                // negotiate the current resolution/fps, the swap is nearly instant.
                if (_videoSource != null)
                {
                    var newSettings = BuildVideoSourceSettings(_cameras[newIndex]);
                    if (newSettings != null)
                    {
                        var switched = await Task.Run(() => _videoSource.SwitchCamera(newSettings));
                        if (switched)
                        {
                            _cameraIndex = newIndex;
                            return;
                        }
                        Log.Warn("MainActivity", "Fast camera switch failed; falling back to full restart.");
                    }
                }

                // Slow path: tear down and rebuild. Preserves streaming state.
                var wasStreaming = _isStreaming;
                await StopAsync();
                _cameraIndex = newIndex;
                if (wasStreaming)
                {
                    await StartStreamAsync(_srtUri, _srtLatencyMs, _srtModeIndex);
                }
                else
                {
                    await StartPreviewAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                System.Threading.Interlocked.Exchange(ref _busy, 0);
                RunOnUiThread(() => btSwitchCam.Enabled = true);
            }
        }

        private void btSettings_Click(object sender, EventArgs e)
        {
            var view = LayoutInflater.Inflate(Resource.Layout.dialog_srt_settings, null);

            var dlgUri = view.FindViewById<EditText>(Resource.Id.dlgSrtUri);
            var dlgMode = view.FindViewById<Spinner>(Resource.Id.dlgSrtMode);
            var dlgLatency = view.FindViewById<EditText>(Resource.Id.dlgLatency);

            dlgUri.Text = _srtUri;
            dlgLatency.Text = _srtLatencyMs.ToString();

            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.srt_modes, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            dlgMode.Adapter = adapter;
            dlgMode.SetSelection(_srtModeIndex);

            new AlertDialog.Builder(this)
                .SetTitle("SRT Settings")
                .SetView(view)
                .SetPositiveButton("Save", (_, _) =>
                {
                    _srtUri = dlgUri.Text?.Trim() ?? string.Empty;
                    _srtModeIndex = dlgMode.SelectedItemPosition;
                    _srtLatencyMs = int.TryParse(dlgLatency.Text, out var lat) ? lat : 750;
                })
                .SetNegativeButton("Cancel", (_, _) => { })
                .Show();
        }

        private async Task StopAsync()
        {
            if (_pipeline == null)
            {
                return;
            }

            await _pipeline.StopAsync();

            tmPosition.Stop();

            await DestroyEngineAsync();

            // PostInvalidate (not Invalidate) — the bus/streaming thread may call Stop off the UI
            // thread, and Android view invalidation from a non-UI thread throws. Fix #75.
            videoView.PostInvalidate();
        }

        private async Task StartPreviewAsync()
        {
            await StopAsync();

            await CreateEngineAsync(forStreaming: false);

            if (_pipeline == null)
            {
                return;
            }

            await _pipeline.StartAsync();

            tmPosition.Start();

            RunOnUiThread(() =>
            {
                tvStatus.Visibility = Android.Views.ViewStates.Gone;
                tvErrors.Visibility = Android.Views.ViewStates.Gone;
            });
        }

        private async Task StartStreamAsync(string uri, int latencyMs, int modeIndex)
        {
            if (string.IsNullOrEmpty(uri))
            {
                Toast.MakeText(this, "Open Settings and set the SRT URI", ToastLength.Long).Show();
                return;
            }

            Log.Info("MainActivity", "StartStreamAsync: stopping preview...");

            // stop preview
            await StopAsync();

            Log.Info("MainActivity", "StartStreamAsync: creating engine...");

            // create engine
            await CreateEngineAsync(forStreaming: true);

            if (_pipeline == null)
            {
                return;
            }

            Log.Info("MainActivity", "StartStreamAsync: creating H264 encoder (auto-detect)...");

            // video encoder — auto-detect best encoder for platform
            _videoEncoder = new H264EncoderBlock();

            var srtSettings = new SRTSinkSettings
            {
                Uri = uri,
                Latency = TimeSpan.FromMilliseconds(latencyMs),
                AutoReconnect = true
            };

            srtSettings.Mode = modeIndex switch
            {
                0 => SRTConnectionMode.Caller,
                1 => SRTConnectionMode.Listener,
                2 => SRTConnectionMode.Rendezvous,
                _ => SRTConnectionMode.Caller
            };

            Log.Info("MainActivity", $"StartStreamAsync: creating SRT sink, URI={uri}, mode={srtSettings.Mode}");

            // create SRT sink
            _srtSink = new SRTMPEGTSSinkBlock(srtSettings);

            // connect video encoding path
            _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);
            _pipeline.Connect(_videoEncoder.Output, _srtSink.CreateNewInput(MediaBlockPadMediaType.Video));

            // audio encoder
            _audioEncoder = new AACEncoderBlock();

            // connect audio encoding path
            _pipeline.Connect(_audioTee.Outputs[1], _audioEncoder.Input);
            _pipeline.Connect(_audioEncoder.Output, _srtSink.CreateNewInput(MediaBlockPadMediaType.Audio));

            Log.Info("MainActivity", "StartStreamAsync: audio path connected, starting pipeline...");

            // start pipeline
            await _pipeline.StartAsync();

            Log.Info("MainActivity", "StartStreamAsync: pipeline started!");

            _isStreaming = true;

            RunOnUiThread(() =>
            {
                // Swap the icon, not the background — the red circle stays, and ic_stop (white
                // square) overlays it so the button reads as a classic "stop" control.
                btStartStream.SetImageResource(Resource.Drawable.ic_stop);
                tvStatus.Text = "LIVE";
                tvStatus.Visibility = Android.Views.ViewStates.Visible;
                tvErrors.Visibility = Android.Views.ViewStates.Gone;
            });
        }

        private async Task StopStreamAsync()
        {
            await StopAsync();

            _isStreaming = false;

            RunOnUiThread(() =>
            {
                btStartStream.SetImageResource(Resource.Drawable.ic_record);
                tvStatus.Visibility = Android.Views.ViewStates.Gone;
            });

            await StartPreviewAsync();
        }

        private async void btStartStream_Click(object sender, EventArgs e)
        {
            // Same re-entrancy gate as the flip handler — Start/Stop both mutate _pipeline.
            if (System.Threading.Interlocked.CompareExchange(ref _busy, 1, 0) != 0)
            {
                return;
            }

            btStartStream.Enabled = false;
            try
            {
                if (_isStreaming)
                {
                    await StopStreamAsync();
                }
                else
                {
                    await StartStreamAsync(_srtUri, _srtLatencyMs, _srtModeIndex);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                RunOnUiThread(() =>
                {
                    tvErrors.Visibility = Android.Views.ViewStates.Visible;
                    tvErrors.Text = ex.Message;
                });
            }
            finally
            {
                System.Threading.Interlocked.Exchange(ref _busy, 0);
                RunOnUiThread(() => btStartStream.Enabled = true);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            CheckPermissionsAndStartPreview();
        }
    }
}
