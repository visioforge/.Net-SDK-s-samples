using Android;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;

using System;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;

namespace RTSP_Client
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private string TEST_URL = "rtsp://";

        private VisioForge.Core.UI.Android.VideoViewTX videoView;

        private Button btStart;

        private Button btPause;

        private Button btStop;

        private EditText edURL;

        private EditText edLogin;

        private EditText edPassword;

        //private readonly System.Timers.Timer tmPosition = new System.Timers.Timer(500);

        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private RTSPSourceBlock _source;

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
        }

        protected override void OnDestroy()
        {
            VisioForgeX.DestroySDK();

            base.OnDestroy();
        }

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            RequestPermissions(
                new String[]{
                        Manifest.Permission.Internet,
                        Manifest.Permission.AccessNetworkState,
                        Manifest.Permission.AccessWifiState},
                1004);

            videoView = FindViewById<VisioForge.Core.UI.Android.VideoViewTX>(RTSP_Client.Resource.Id.videoView);

            btStart = FindViewById<Button>(RTSP_Client.Resource.Id.btStart);
            btStart.Click += btStart_Click;

            btPause = FindViewById<Button>(RTSP_Client.Resource.Id.btPause);
            btPause.Click += btPause_Click;

            btStop = FindViewById<Button>(RTSP_Client.Resource.Id.btStop);
            btStop.Click += btStop_Click;

            edURL = FindViewById<EditText>(RTSP_Client.Resource.Id.edURL);
            edURL.Text = TEST_URL;

            edLogin = FindViewById<EditText>(RTSP_Client.Resource.Id.edLogin);
            edLogin.Text = "admin";

            edPassword = FindViewById<EditText>(RTSP_Client.Resource.Id.edPassword);
            edPassword.Text = "";
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            if (_pipeline == null)
            {
                return;
            }

            await _pipeline.StopAsync();

            videoView.Invalidate();

            await DestroyEngineAsync();
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
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += _pipeline_OnError;

            var rtspSource = await RTSPSourceSettings.CreateAsync(new System.Uri(edURL.Text), edLogin.Text, edPassword.Text, audioEnabled: true);
            
            // Enable low latency mode by default for Android real-time surveillance (60-120ms latency)
            rtspSource.LowLatencyMode = true;

            _source = new RTSPSourceBlock(rtspSource);

            if (_source.Settings.IsVideoAvailable())
            {
                _videoRenderer = new VideoRendererBlock(_pipeline, videoView) { IsSync = false };
                _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);
            }

            if (_source.Settings.IsAudioAvailable())
            {
                _audioRenderer = new AudioRendererBlock();
                _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
            }

            await _pipeline.StartAsync();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}