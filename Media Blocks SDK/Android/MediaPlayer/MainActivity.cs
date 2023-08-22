using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaInfoReaderX;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core;

using Android.Util;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Globalization;
using Xamarin.Essentials;
using Android;

namespace MediaPlayer
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private string TEST_URL = "http://test.visioforge.com/video.avi";

        private VisioForge.Core.UI.Android.VideoView videoView;

        private Button btOpenFile;

        private Button btStart;

        private Button btPause;

        private Button btStop;

        private EditText edURL;

        private SeekBar sbTimeline;

        private TextView lbPosition;

        private GridLayout pnScreen;

        private readonly System.Timers.Timer tmPosition = new System.Timers.Timer(500);

        private bool isSeeking = false;

        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private UniversalSourceBlock _fileSource;

        private DeviceEnumerator _deviceEnumerator;

        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline(this, false);
            //_pipeline.Debug_Dir = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "VisioForge");
            _pipeline.OnError += _pipeline_OnError;
            _pipeline.OnStop += _pipeline_OnStop;
            _pipeline.OnStart += _pipeline_OnStart;

            _deviceEnumerator = new DeviceEnumerator(this);

            _videoRenderer = new VideoRendererBlock(_pipeline, videoView);
        }

        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= _pipeline_OnError;
                _pipeline.OnStop -= _pipeline_OnStop;
                _pipeline.OnStart -= _pipeline_OnStart;

                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        private async void _pipeline_OnStart(object sender, EventArgs e)
        {
            var duration = await _pipeline.DurationAsync();
            sbTimeline.Max = (int)duration.TotalMilliseconds;
        }

        private void _pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Log.Error("MainActivity", e.Message);
        }

        private void _pipeline_OnStop(object sender, StopEventArgs e)
        {
            RunOnUiThread(() =>
            {
                sbTimeline.Progress = 0;
            });
        }

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            RequestPermissions(
                new String[]{
                        Manifest.Permission.Camera,
                        Manifest.Permission.Internet,
                        Manifest.Permission.RecordAudio,
                        Manifest.Permission.AccessNetworkState,
                        Manifest.Permission.AccessWifiState,
                        Manifest.Permission.ModifyAudioSettings}, 1004);

            videoView = FindViewById<VisioForge.Core.UI.Android.VideoView>(MediaPlayer.Resource.Id.videoView);

            tmPosition.Elapsed += tmPosition_Elapsed;

            btOpenFile = FindViewById<Button>(MediaPlayer.Resource.Id.btOpenFile);
            btOpenFile.Click += btOpenFile_Click;

            btStart = FindViewById<Button>(MediaPlayer.Resource.Id.btStart);
            btStart.Click += btStart_Click;

            btPause = FindViewById<Button>(MediaPlayer.Resource.Id.btPause);
            btPause.Click += btPause_Click;

            btStop = FindViewById<Button>(MediaPlayer.Resource.Id.btStop);
            btStop.Click += btStop_Click;

            sbTimeline = FindViewById<SeekBar>(MediaPlayer.Resource.Id.sbTimeline);
            sbTimeline.ProgressChanged += sbTimeline_ProgressChanged;

            sbTimeline.StartTrackingTouch += delegate (object sender, SeekBar.StartTrackingTouchEventArgs args)
            {
                isSeeking = true;
            };

            sbTimeline.StopTrackingTouch += delegate (object sender, SeekBar.StopTrackingTouchEventArgs args)
            {
                isSeeking = false;
            };

            lbPosition = FindViewById<TextView>(MediaPlayer.Resource.Id.lbPosition);
            pnScreen = FindViewById<GridLayout>(MediaPlayer.Resource.Id.pnScreen);
            edURL = FindViewById<EditText>(MediaPlayer.Resource.Id.edURL);
        }

        private async void sbTimeline_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            if (isSeeking)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromMilliseconds(e.Progress));
            }
        }

        private async void btOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                Thread.Sleep(200);

                var file = await FilePicker.PickAsync();
                if (file == null)
                    return; // user canceled file picking

                RunOnUiThread(() =>
                {
                    edURL.Text = file.FullPath;
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception choosing file: " + ex.ToString());
            }
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            if (_pipeline == null)
            {
                return;
            }

            tmPosition.Stop();

            await DestroyEngineAsync();

            RunOnUiThread(() =>
            {
                sbTimeline.Progress = 0;
            });

            videoView.Invalidate();

            // clear screen workaround
            pnScreen.RemoveView(videoView);
            pnScreen.AddView(videoView);
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            if (_pipeline == null)
            {
                return;
            }

            if (btPause.Text == "Pause")
            {
                await _pipeline.PauseAsync();
                btPause.Text = "Resume";
            }
            else
            {
                await _pipeline.ResumeAsync();
                btPause.Text = "Pause";
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            CreateEngine();

            isSeeking = false;

            var mediaInfo = new MediaInfoReaderX(this, context: null);
            bool videoStream = true;
            bool audioStream = true;
            if (await mediaInfo.OpenAsync(new Uri(edURL.Text)))
            {
                if (mediaInfo.Info.VideoStreams.Count == 0)
                {
                    videoStream = false;
                }

                if (mediaInfo.Info.AudioStreams.Count == 0)
                {
                    audioStream = false;
                }
            }

            _fileSource = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(this, edURL.Text, renderVideo: videoStream, renderAudio: audioStream));

            if (videoStream)
            {
                _pipeline.Connect(_fileSource.VideoOutput, _videoRenderer.Input);
            }

            if (audioStream)
            {
                _audioRenderer = new AudioRendererBlock(_deviceEnumerator);
                _pipeline.Connect(_fileSource.AudioOutput, _audioRenderer.Input);
            }

            await _pipeline.StartAsync();

            tmPosition.Start();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        private async void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (isSeeking)
            {
                return;
            }

            var duration = await _pipeline.DurationAsync();
            var pos = await _pipeline.Position_GetAsync();
            var progress = (int)pos.TotalMilliseconds;

            try
            {
                RunOnUiThread(() =>
                {
                    if (_pipeline == null)
                    {
                        return;
                    }

                    if (progress > sbTimeline.Max)
                    {
                        sbTimeline.Progress = sbTimeline.Max;
                    }
                    else
                    {
                        sbTimeline.Progress = progress;
                    }

                    // This is where the received data is passed
                    lbPosition.Text = $"{pos.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}/{duration.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";
                });
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        protected override void OnPause()
        {
            base.OnPause();

            //_pipeline.StopAsync();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}