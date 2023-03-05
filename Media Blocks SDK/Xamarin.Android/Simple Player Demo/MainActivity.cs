using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using System;

namespace Simple_Player_Demo
{
    using Android;
    using Android.Util;
    using Android.Widget;
    using AndroidX.Core.App;
    using System.Globalization;
    using System.Threading;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.AudioRendering;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.Special;
    using VisioForge.Core.MediaBlocks.VideoRendering;
    using VisioForge.Core.MediaInfoReaderX;
    using VisioForge.Core.Types.Events;
    using Xamarin.Essentials;

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
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

        private FileSourceBlock _fileSource;

        private StreamSourceBlock _memorySource;

        private DecodeBinBlock _decodeBin;

        private void DestroyEngine()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= _pipeline_OnError;
                _pipeline.OnStop -= _pipeline_OnStop;
                _pipeline.OnStart -= _pipeline_OnStart;

                _pipeline.Dispose();
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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Simple_Player_Demo_MP.Resource.Layout.main);

            ActivityCompat.RequestPermissions(this,
                new String[]{
                        Manifest.Permission.Camera,
                        Manifest.Permission.Internet,
                        Manifest.Permission.RecordAudio,
                        Manifest.Permission.AccessNetworkState,
                        Manifest.Permission.AccessWifiState,
                        Manifest.Permission.ModifyAudioSettings}, 1004);

            videoView = FindViewById<VisioForge.Core.UI.Android.VideoView>(Simple_Player_Demo_MP.Resource.Id.videoView);

            _pipeline = new MediaBlocksPipeline(this, true);
            //_pipeline.Debug_Dir = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "VisioForge");
            _pipeline.OnError += _pipeline_OnError;
            _pipeline.OnStop += _pipeline_OnStop;
            _pipeline.OnStart += _pipeline_OnStart;

            _videoRenderer = new VideoRendererBlock(_pipeline, videoView);

            tmPosition.Elapsed += tmPosition_Elapsed;

            btOpenFile = FindViewById<Button>(Simple_Player_Demo_MP.Resource.Id.btOpenFile);
            btOpenFile.Click += btOpenFile_Click;

            btStart = FindViewById<Button>(Simple_Player_Demo_MP.Resource.Id.btStart);
            btStart.Click += btStart_Click;

            btPause = FindViewById<Button>(Simple_Player_Demo_MP.Resource.Id.btPause);
            btPause.Click += btPause_Click;

            btStop = FindViewById<Button>(Simple_Player_Demo_MP.Resource.Id.btStop);
            btStop.Click += btStop_Click;

            sbTimeline = FindViewById<SeekBar>(Simple_Player_Demo_MP.Resource.Id.sbTimeline);
            sbTimeline.ProgressChanged += sbTimeline_ProgressChanged;

            sbTimeline.StartTrackingTouch += delegate (object sender, SeekBar.StartTrackingTouchEventArgs args)
            {
                isSeeking = true;
            };

            sbTimeline.StopTrackingTouch += delegate (object sender, SeekBar.StopTrackingTouchEventArgs args)
            {
                isSeeking = false;
            };

            lbPosition = FindViewById<TextView>(Simple_Player_Demo_MP.Resource.Id.lbPosition);

            pnScreen = FindViewById<GridLayout>(Simple_Player_Demo_MP.Resource.Id.pnScreen);

            edURL = FindViewById<EditText>(Simple_Player_Demo_MP.Resource.Id.edURL);
            edURL.Text = TEST_URL;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Simple_Player_Demo_MP.Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Simple_Player_Demo_MP.Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
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

            await _pipeline.StopAsync();

            RunOnUiThread(() =>
            {
                sbTimeline.Progress = 0;
            });

            videoView.Invalidate();

            //DestroyEngine();

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
            //var src = new VirtualVideoSourceBlock(new VirtualVideoSourceSettings());
            //var src = new AndroidVideoSourceBlock(new AndroidVideoSourceSettings());

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

            //var data = System.IO.File.ReadAllBytes(edURL.Text);
            //_memorySource = new StreamSourceBlock(new MemorySourceSettings(data));

            //_decodeBin = new DecodeBinBlock(true, true, false);
            //_pipeline.Connect(_memorySource.Output, _decodeBin.Input);

            _fileSource = new FileSourceBlock(edURL.Text, renderVideo: videoStream, renderAudio: audioStream);

            if (videoStream)
            {
                _pipeline.Connect(_fileSource.VideoOutput, _videoRenderer.Input);
            }

            if (audioStream)
            {
                _audioRenderer = new AudioRendererBlock();
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

            _pipeline.StopAsync();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
