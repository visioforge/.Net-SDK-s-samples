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
using Android.Content.Res;
using Android.Views;
using Android.Widget;

using System.Globalization;
using Xamarin.Essentials;
using Android;
using System.Diagnostics;
using System.Threading;
using Activity = Android.App.Activity;


namespace MediaPlayer
{
    /// <summary>
    /// The main activity.
    /// </summary>
    [Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar.Fullscreen", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class MainActivity : Activity
    {
        private const string TAG = "MainActivity";

        /// <summary>
        /// The video view.
        /// </summary>
        private VisioForge.Core.UI.Android.VideoViewTX videoView;

        /// <summary>
        /// The open file button.
        /// </summary>
        private ImageButton btOpenFile;

        /// <summary>
        /// The start button.
        /// </summary>
        private ImageButton btStart;

        /// <summary>
        /// The stop button.
        /// </summary>
        private ImageButton btStop;

        private View _panelView;

        private int _panelPaddingLeft;

        private int _panelPaddingTop;

        private int _panelPaddingRight;

        private int _panelPaddingBottom;

        private bool _isPlaying;
        private bool _isPaused;

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

        private int _timerBusy;

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
            LogVideoViewState("CreateEngine/Before");

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += _pipeline_OnError;
            _pipeline.OnStop += _pipeline_OnStop;
            _pipeline.OnStart += _pipeline_OnStart;

            _videoRenderer = new VideoRendererBlock(_pipeline, videoView);

            LogVideoViewState("CreateEngine/After");
        }

        private void LogVideoViewState(string prefix)
        {
            if (videoView == null)
            {
                Log.Debug(TAG, $"{prefix}: videoView=null, orientation={Resources?.Configuration?.Orientation}, playing={_isPlaying}, paused={_isPaused}");
                return;
            }

            Log.Debug(TAG, $"{prefix}: orientation={Resources?.Configuration?.Orientation}, view={videoView.Width}x{videoView.Height}, measured={videoView.MeasuredWidth}x{videoView.MeasuredHeight}, playing={_isPlaying}, paused={_isPaused}");
        }

        private void ConfigureSystemInsets()
        {
            var contentView = FindViewById<ViewGroup>(Android.Resource.Id.Content)?.GetChildAt(0);
            if (contentView == null || _panelView == null)
            {
                return;
            }

            _panelPaddingLeft = _panelView.PaddingLeft;
            _panelPaddingTop = _panelView.PaddingTop;
            _panelPaddingRight = _panelView.PaddingRight;
            _panelPaddingBottom = _panelView.PaddingBottom;

            contentView.SetOnApplyWindowInsetsListener(new SystemInsetsListener(this));
            contentView.RequestApplyInsets();
        }

        private void ApplySystemInsets(WindowInsets insets)
        {
            if (_panelView == null || insets == null)
            {
                return;
            }

            int leftInset;
            int rightInset;
            int bottomInset;

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.R)
            {
                var systemBarsInsets = insets.GetInsets(WindowInsets.Type.SystemBars());
                leftInset = systemBarsInsets.Left;
                rightInset = systemBarsInsets.Right;
                bottomInset = systemBarsInsets.Bottom;
            }
            else
            {
#pragma warning disable CA1422
                leftInset = insets.SystemWindowInsetLeft;
                rightInset = insets.SystemWindowInsetRight;
                bottomInset = insets.SystemWindowInsetBottom;
#pragma warning restore CA1422
            }

            _panelView.SetPadding(
                _panelPaddingLeft + leftInset,
                _panelPaddingTop,
                _panelPaddingRight + rightInset,
                _panelPaddingBottom + bottomInset);

            Log.Debug(TAG, $"ApplySystemInsets: left={leftInset}, right={rightInset}, bottom={bottomInset}");
        }

        private void RequestSystemInsets()
        {
            var contentView = FindViewById<ViewGroup>(Android.Resource.Id.Content)?.GetChildAt(0);
            contentView?.RequestApplyInsets();
        }

        private sealed class SystemInsetsListener : Java.Lang.Object, View.IOnApplyWindowInsetsListener
        {
            private readonly MainActivity _activity;

            public SystemInsetsListener(MainActivity activity)
            {
                _activity = activity;
            }

            public WindowInsets OnApplyWindowInsets(View view, WindowInsets insets)
            {
                _activity.ApplySystemInsets(insets);
                return view.OnApplyWindowInsets(insets);
            }
        }

        /// <summary>
        /// Starts playback using the current URL and optionally restores playback state.
        /// </summary>
        /// <param name="initialPosition">Optional playback position to restore after pipeline recreation.</param>
        /// <param name="startPaused">If set to <c>true</c>, playback will be paused immediately after start.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task StartPlaybackAsync(TimeSpan? initialPosition = null, bool startPaused = false)
        {
            Log.Debug(TAG, $"StartPlaybackAsync: url={edURL?.Text}, initialPosition={initialPosition}, startPaused={startPaused}");
            LogVideoViewState("StartPlaybackAsync/Entry");

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

            Log.Debug(TAG, $"StartPlaybackAsync: streams video={videoStream}, audio={audioStream}");

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

            LogVideoViewState("StartPlaybackAsync/AfterStart");

            if (initialPosition.HasValue && initialPosition.Value > TimeSpan.Zero)
            {
                await _pipeline.Position_SetAsync(initialPosition.Value);
                Log.Debug(TAG, $"StartPlaybackAsync: restored position={initialPosition.Value}");
            }

            tmPosition.Start();

            _isPlaying = true;
            _isPaused = false;

            if (startPaused)
            {
                await _pipeline.PauseAsync();
                _isPaused = true;
                btStart.SetImageResource(Resource.Drawable.ic_play);
                Log.Debug(TAG, "StartPlaybackAsync: pipeline paused after restore");
            }
            else
            {
                btStart.SetImageResource(Resource.Drawable.ic_pause);
            }

            LogVideoViewState("StartPlaybackAsync/Exit");
        }

        /// <summary>
        /// Asynchronously destroys the media blocks engine pipeline and releases resources.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                Log.Debug(TAG, "DestroyEngineAsync: disposing pipeline");
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
                LogVideoViewState("PipelineOnStart");
                var duration = await _pipeline.DurationAsync();
                sbTimeline.Max = (int)duration.TotalMilliseconds;
                Log.Debug(TAG, $"PipelineOnStart: duration={duration}");
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
                tmPosition.Stop();
                await DestroyEngineAsync();
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

            videoView = FindViewById<VisioForge.Core.UI.Android.VideoViewTX>(MediaPlayer.Resource.Id.videoView);

            tmPosition.Elapsed += tmPosition_Elapsed;

            btOpenFile = FindViewById<ImageButton>(MediaPlayer.Resource.Id.btOpenFile);
            btOpenFile.Click += btOpenFile_Click;

            btStart = FindViewById<ImageButton>(MediaPlayer.Resource.Id.btStart);
            btStart.Click += btStart_Click;

            btStop = FindViewById<ImageButton>(MediaPlayer.Resource.Id.btStop);
            btStop.Click += btStop_Click;

            _panelView = FindViewById<View>(MediaPlayer.Resource.Id.panel);

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

            ConfigureSystemInsets();

            LogVideoViewState("OnCreate/AfterFindViewById");
            videoView?.Post(() => LogVideoViewState("OnCreate/PostLayout"));
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
                if (isSeeking && _pipeline != null)
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
                await Task.Delay(200);

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

                _isPlaying = false;
                _isPaused = false;

                RunOnUiThread(() =>
                {
                    sbTimeline.Progress = 0;
                    btStart.SetImageResource(Resource.Drawable.ic_play);
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the play/pause toggle button click.
        /// </summary>
        private async void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isPlaying)
                {
                    if (string.IsNullOrWhiteSpace(edURL?.Text))
                    {
                        return;
                    }

                    // start playback
                    await StartPlaybackAsync();
                }
                else if (_pipeline == null)
                {
                    return;
                }
                else if (!_isPaused)
                {
                    // pause
                    await _pipeline.PauseAsync();
                    _isPaused = true;
                    btStart.SetImageResource(Resource.Drawable.ic_play);
                }
                else
                {
                    // resume
                    await _pipeline.ResumeAsync();
                    _isPaused = false;
                    btStart.SetImageResource(Resource.Drawable.ic_pause);
                }
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
        /// Called when the device configuration changes, such as orientation switches.
        /// Notifies the Android texture renderer about the new view geometry without rebuilding playback.
        /// </summary>
        /// <param name="newConfig">The new device configuration.</param>
        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            Log.Debug(TAG, $"OnConfigurationChanged: newOrientation={newConfig?.Orientation}, screenLayout={newConfig?.ScreenLayout}");
            LogVideoViewState("OnConfigurationChanged");

            RunOnUiThread(() =>
            {
                RequestSystemInsets();
                videoView?.InvokeVideoRendererUpdate();
            });
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
            if (Interlocked.CompareExchange(ref _timerBusy, 1, 0) != 0) return;
            try
            {
                if (isSeeking)
                {
                    return;
                }

                var pipeline = _pipeline;
                if (pipeline == null)
                {
                    return;
                }

                var duration = await pipeline.DurationAsync();
                var pos = await pipeline.Position_GetAsync();
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
            finally
            {
                Interlocked.Exchange(ref _timerBusy, 0);
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
