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
using System.Diagnostics;
using Activity = Android.App.Activity;

namespace RTSP_Client
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private string TEST_URL = "rtsp://camera-ip:554/stream";

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

        /// <summary>
        /// Asynchronously destroys the media blocks engine pipeline and releases resources.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
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
        /// Handles the OnError event of the pipeline.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void _pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Log.Error("MainActivity", e.Message);
        }

        /// <summary>
        /// Called when the activity is being destroyed.
        /// </summary>
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

        /// <summary>
        /// Called when the activity is starting.
        /// </summary>
        /// <param name="savedInstanceState">If the activity is being re-initialized after previously being shut down then this Bundle contains the data it most recently supplied in <see cref="M:Android.App.Activity.OnSaveInstanceState(Android.OS.Bundle)"/>.  <format type="text/html"><a href="https://developer.android.com/reference/android/app/Activity.html#onCreate(android.os.Bundle)" target="_blank">[C# document]</a></format></param>
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

            videoView = FindViewById<VisioForge.Core.UI.Android.VideoViewTX>(RTSP_Client.Resource.Id.videoView)!;

            btStart = FindViewById<Button>(RTSP_Client.Resource.Id.btStart)!;
            btStart.Click += btStart_Click;

            btPause = FindViewById<Button>(RTSP_Client.Resource.Id.btPause)!;
            btPause.Click += btPause_Click;

            btStop = FindViewById<Button>(RTSP_Client.Resource.Id.btStop)!;
            btStop.Click += btStop_Click;

            edURL = FindViewById<EditText>(RTSP_Client.Resource.Id.edURL)!;
            edURL.Text = TEST_URL;

            edLogin = FindViewById<EditText>(RTSP_Client.Resource.Id.edLogin)!;
            edLogin.Text = "admin";

            edPassword = FindViewById<EditText>(RTSP_Client.Resource.Id.edPassword)!;
            edPassword.Text = "";
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (_pipeline == null)
                {
                    return;
                }

                await _pipeline.StopAsync();

                videoView.Invalidate();

                await DestroyEngineAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the btPause control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Called when the activity has detected the user's query for the result from a permission request.
        /// </summary>
        /// <param name="requestCode">The request code passed in <see cref="M:Android.App.Activity.RequestPermissions(System.String[],System.Int32)" />.</param>
        /// <param name="permissions">The requested permissions. Never null.</param>
        /// <param name="grantResults">The grant results for the corresponding permissions which is either <see cref="F:Android.Content.PM.Permission.Granted" /> or <see cref="F:Android.Content.PM.Permission.Denied" />. Never null.</param>
        /// <summary>
        /// On request permissions result.
        /// </summary>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
