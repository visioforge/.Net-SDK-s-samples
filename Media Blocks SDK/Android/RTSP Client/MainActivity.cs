using Android;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;

using System;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;

namespace RTSP_Client
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private string TEST_URL = "rtsp://admin:dancer23@192.168.50.64:554/Streaming/Channels/101?transportmode=unicast&profile=Profile_1";

        private VisioForge.Core.UI.Android.VideoView videoView;

        private Button btStart;

        private Button btPause;

        private Button btStop;

        private EditText edURL;

        private EditText edLogin;

        private EditText edPassword;

        private GridLayout pnScreen;

        //private readonly System.Timers.Timer tmPosition = new System.Timers.Timer(500);

        private bool isSeeking = false;

        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        //private AudioRendererBlock _audioRenderer;

        private RTSPSourceBlock _source;

        private void DestroyEngine()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= _pipeline_OnError;
                // _pipeline.OnStop -= _pipeline_OnStop;
                //_pipeline.OnStart -= _pipeline_OnStart;

                _pipeline.Dispose();
                _pipeline = null;
            }
        }

        //private async void _pipeline_OnStart(object sender, EventArgs e)
        //{
        //}

        private void _pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Log.Error("MainActivity", e.Message);
        }

        //private void _pipeline_OnStop(object sender, StopEventArgs e)
        //{
        //}

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            RequestPermissions(
                new String[]{
                        Manifest.Permission.Camera,
                        Manifest.Permission.Internet,
                        Manifest.Permission.RecordAudio,
                        Manifest.Permission.AccessNetworkState,
                        Manifest.Permission.AccessWifiState,
                        Manifest.Permission.ModifyAudioSettings}, 1004);

             videoView = FindViewById<VisioForge.Core.UI.Android.VideoView>(RTSP_Client.Resource.Id.videoView);

            _pipeline = new MediaBlocksPipeline(this, true);
            //_pipeline.Debug_Dir = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "VisioForge");
            _pipeline.OnError += _pipeline_OnError;
            // _pipeline.OnStop += _pipeline_OnStop;
            // _pipeline.OnStart += _pipeline_OnStart;

            _videoRenderer = new VideoRendererBlock(_pipeline, videoView);

            btStart = FindViewById<Button>(RTSP_Client.Resource.Id.btStart);
            btStart.Click += btStart_Click;

            btPause = FindViewById<Button>(RTSP_Client.Resource.Id.btPause);
            btPause.Click += btPause_Click;

            btStop = FindViewById<Button>(RTSP_Client.Resource.Id.btStop);
            btStop.Click += btStop_Click;

            pnScreen = FindViewById<GridLayout>(RTSP_Client.Resource.Id.pnScreen);

            edURL = FindViewById<EditText>(RTSP_Client.Resource.Id.edURL);
            edURL.Text = TEST_URL;

            edLogin = FindViewById<EditText>(RTSP_Client.Resource.Id.edLogin);
            edLogin.Text = "admin";

            edPassword = FindViewById<EditText>(RTSP_Client.Resource.Id.edPassword);
            edPassword.Text = "dancer23";
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            if (_pipeline == null)
            {
                return;
            }

            await _pipeline.StopAsync();

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

            //var mediaInfo = new MediaInfoReaderX(context: null, this);
            //bool videoStream = true;
            //bool audioStream = true;
            //if (await mediaInfo.OpenAsync(new Uri(edURL.Text)))
            //{
            //    if (mediaInfo.Info.VideoStreams.Count == 0)
            //    {
            //        videoStream = false;
            //    }

            //    if (mediaInfo.Info.AudioStreams.Count == 0)
            //    {
            //        audioStream = false;
            //    }
            //}

            //var data = System.IO.File.ReadAllBytes(edURL.Text);
            //_memorySource = new StreamSourceBlock(new MemorySourceSettings(data));

            //_decodeBin = new DecodeBinBlock(true, true, false);
            //_pipeline.Connect(_memorySource.Output, _decodeBin.Input);

            var rtspSource = new RTSPSourceSettings(new System.Uri(edURL.Text), true);
            rtspSource.Login = "admin";
            rtspSource.Password = "dancer23";

            _source = new RTSPSourceBlock(rtspSource);

            // if (videoStream)
            //{
            _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);
            // }

            //if (audioStream)
            // {
            // _audioRenderer = new AudioRendererBlock();
            // _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
            // }

            await _pipeline.StartAsync();
        }

        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Menu.menu_main, menu);
        //    return true;
        //}

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    int id = item.ItemId;
        //    if (id == Resource.Id.action_settings)
        //    {
        //        return true;
        //    }

        //    return base.OnOptionsItemSelected(item);
        //}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}