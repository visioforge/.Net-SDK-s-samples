using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core;
using VisioForge.Core.Types.Events;
using Android;
using Android.Util;
using Android.Runtime;
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

        private EditText edSrtUri;

        private Spinner spSrtMode;

        private EditText edLatency;

        private Button btStartStream;

        private Button btSwitchCam;

        private TextView tvErrors;

        private readonly System.Timers.Timer tmPosition = new System.Timers.Timer(500);

        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private MediaBlock _videoSource;

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

        private string _lastSrtUri;
        private int _lastLatencyMs;
        private int _lastModeIndex;

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
            edSrtUri = FindViewById<EditText>(Resource.Id.edSrtUri);
            spSrtMode = FindViewById<Spinner>(Resource.Id.spSrtMode);
            edLatency = FindViewById<EditText>(Resource.Id.edLatency);

            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.srt_modes, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spSrtMode.Adapter = adapter;

            btStartStream = FindViewById<Button>(Resource.Id.btStartStream);
            btStartStream.Click += btStartStream_Click;

            tvErrors = FindViewById<TextView>(Resource.Id.tvErrors);

            btSwitchCam = FindViewById<Button>(Resource.Id.btSwitchCam);
            btSwitchCam.Click += btSwitchCam_Click;

            CheckPermissionsAndStartPreview();
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

            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            if (_cameraIndex >= _cameras.Length)
            {
                _cameraIndex = 0;
            }

            var device = _cameras[_cameraIndex];
            if (device != null)
            {
                // Use 1080p format
                var formatItem = device.GetVideoFormatAndFrameRate(1920, 1080, out var frameRate);

                // Fallback to HD or any available format
                formatItem ??= device.GetHDOrAnyVideoFormatAndFrameRate(out frameRate);

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
            try
            {
                var wasStreaming = _isStreaming;

                await StopAsync();

                if (_cameraIndex == 0)
                {
                    _cameraIndex = 1;
                }
                else
                {
                    _cameraIndex = 0;
                }

                if (wasStreaming)
                {
                    await StartStreamAsync(_lastSrtUri, _lastLatencyMs, _lastModeIndex);
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

            videoView.Invalidate();
        }

        private async Task StartPreviewAsync()
        {
            await StopAsync();

            await CreateEngineAsync(forStreaming: false);

            await _pipeline.StartAsync();

            tmPosition.Start();
        }

        private async Task StartStreamAsync(string uri, int latencyMs, int modeIndex)
        {
            if (string.IsNullOrEmpty(uri))
            {
                Toast.MakeText(this, "Please set the SRT URI", ToastLength.Long).Show();
                return;
            }

            _lastSrtUri = uri;
            _lastLatencyMs = latencyMs;
            _lastModeIndex = modeIndex;

            Log.Info("MainActivity", "StartStreamAsync: stopping preview...");

            // stop preview
            await StopAsync();

            Log.Info("MainActivity", "StartStreamAsync: creating engine...");

            // create engine
            await CreateEngineAsync(forStreaming: true);

            Log.Info("MainActivity", "StartStreamAsync: creating H264 encoder (auto-detect)...");

            // video encoder — auto-detect best encoder for platform
            _videoEncoder = new H264EncoderBlock();
            Log.Info("MainActivity", $"StartStreamAsync: H264 encoder settings type = {_videoEncoder.Settings.GetType().Name}");

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

            Log.Info("MainActivity", $"StartStreamAsync: SRT MPEG-TS available = {SRTMPEGTSSinkBlock.IsAvailable()}");

            // connect video encoding path
            _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);
            _pipeline.Connect(_videoEncoder.Output, _srtSink.CreateNewInput(MediaBlockPadMediaType.Video));

            Log.Info("MainActivity", "StartStreamAsync: video path connected");

            // audio encoder
            _audioEncoder = new AACEncoderBlock();
            Log.Info("MainActivity", $"StartStreamAsync: AAC encoder settings type = {_audioEncoder.Settings.GetType().Name}");
            Log.Info("MainActivity", $"StartStreamAsync: AAC encoder available = {AACEncoderBlock.IsAvailable(_audioEncoder.Settings)}");

            // connect audio encoding path
            _pipeline.Connect(_audioTee.Outputs[1], _audioEncoder.Input);
            _pipeline.Connect(_audioEncoder.Output, _srtSink.CreateNewInput(MediaBlockPadMediaType.Audio));

            Log.Info("MainActivity", "StartStreamAsync: audio path connected, starting pipeline...");

            // start pipeline
            await _pipeline.StartAsync();

            Log.Info("MainActivity", "StartStreamAsync: pipeline started!");

            _isStreaming = true;

            btStartStream.Text = "Stop SRT";
        }

        private async Task StopStreamAsync()
        {
            await StopAsync();

            _isStreaming = false;

            btStartStream.Text = "Start SRT";

            await StartPreviewAsync();
        }

        private async void btStartStream_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isStreaming)
                {
                    await StopStreamAsync();
                }
                else
                {
                    var uri = edSrtUri.Text;
                    var latencyMs = int.TryParse(edLatency.Text, out var lat) ? lat : 750;
                    var modeIndex = spSrtMode.SelectedItemPosition;

                    await StartStreamAsync(uri, latencyMs, modeIndex);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                tvErrors.Visibility = Android.Views.ViewStates.Visible;
                tvErrors.Text = ex.Message;
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
