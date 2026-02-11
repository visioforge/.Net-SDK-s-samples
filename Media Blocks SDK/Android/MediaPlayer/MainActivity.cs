using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;

using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaInfoReaderX;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core;

using Android.Util;
using Android.Runtime;

using System.Globalization;
using Xamarin.Essentials;
using Android;
using System.Diagnostics;
using Activity = Android.App.Activity;


namespace MediaPlayer
{
    /// <summary>
    /// The main activity.
    /// </summary>
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        /// <summary>
        /// The video view.
        /// </summary>
        private VisioForge.Core.UI.Android.VideoViewGL videoView;

        /// <summary>
        /// The open file button.
        /// </summary>
        private Button btOpenFile;

        /// <summary>
        /// The start button.
        /// </summary>
        private Button btStart;

        /// <summary>
        /// The pause button.
        /// </summary>
        private Button btPause;

        /// <summary>
        /// The stop button.
        /// </summary>
        private Button btStop;

        /// <summary>
        /// The URL edit text.
        /// </summary>
        private EditText edURL;

        /// <summary>
        /// The timeline seek bar.
        /// </summary>
        private SeekBar sbTimeline;

        /// <summary>
        /// The position label.
        /// </summary>
        private TextView lbPosition;

        /// <summary>
        /// The position timer.
        /// </summary>
        private readonly System.Timers.Timer tmPosition = new System.Timers.Timer(500);

        /// <summary>
        /// Indicates whether the user is currently seeking.
        /// </summary>
        private bool isSeeking = false;

        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private VideoRendererBlock _videoRenderer;

        /// <summary>
        /// The audio renderer.
        /// </summary>
        private AudioRendererBlock _audioRenderer;

        /// <summary>
        /// The file source.
        /// </summary>
        private UniversalSourceBlock _fileSource;

        /// <summary>
        /// Creates the media blocks engine pipeline and initializes the video renderer.
        /// </summary>
        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += _pipeline_OnError;
            _pipeline.OnStop += _pipeline_OnStop;
            _pipeline.OnStart += _pipeline_OnStart;

            _videoRenderer = new VideoRendererBlock(_pipeline, videoView);
        }

        /// <summary>
        /// Asynchronously destroys the media blocks engine pipeline and releases resources.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
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

        /// <summary>
        /// Handles the OnStart event of the pipeline.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Handles the pipeline on start event.
        /// </summary>
        private async void _pipeline_OnStart(object sender, EventArgs e)
        {
            try
            {
                var duration = await _pipeline.DurationAsync();
                sbTimeline.Max = (int)duration.TotalMilliseconds;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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
        /// Handles the OnStop event of the pipeline.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="StopEventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Pipeline on stop.
        /// </summary>
        private void _pipeline_OnStop(object sender, StopEventArgs e)
        {
            RunOnUiThread(() =>
            {
                sbTimeline.Progress = 0;
            });
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

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            RequestPermissions(
                new String[]{
                        Manifest.Permission.Camera,
                        Manifest.Permission.Internet,
                        Manifest.Permission.RecordAudio,
                        Manifest.Permission.AccessNetworkState,
                        Manifest.Permission.AccessWifiState,
                        Manifest.Permission.ModifyAudioSettings}, 1004);

            videoView = FindViewById<VisioForge.Core.UI.Android.VideoViewGL>(MediaPlayer.Resource.Id.videoView);

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
            edURL = FindViewById<EditText>(MediaPlayer.Resource.Id.edURL);
        }

        /// <summary>
        /// Handles the ProgressChanged event of the sbTimeline control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SeekBar.ProgressChangedEventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Sb timeline progress changed.
        /// </summary>
        private async void sbTimeline_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            try
            {
                if (isSeeking)
                {
                    await _pipeline.Position_SetAsync(TimeSpan.FromMilliseconds(e.Progress));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the btOpenFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Handles the bt open file click event.
        /// </summary>
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

                tmPosition.Stop();

                await DestroyEngineAsync();

                RunOnUiThread(() =>
                {
                    sbTimeline.Progress = 0;
                });
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
                CreateEngine();

                isSeeking = false;

                var mediaInfo = new MediaInfoReaderX();
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

                _fileSource = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(edURL.Text, renderVideo: videoStream, renderAudio: audioStream));

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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Called when the activity is resumed.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
        }

        /// <summary>
        /// Handles the Elapsed event of the tmPosition timer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Tm position elapsed.
        /// </summary>
        private async void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
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

                        sbTimeline.Max = (int)duration.TotalMilliseconds;

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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Called when the activity is paused.
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();

            //_pipeline.StopAsync();
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
