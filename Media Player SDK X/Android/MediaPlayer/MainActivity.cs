using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Globalization;
using VisioForge.Core;
using VisioForge.Core.MediaPlayerX;
using Xamarin.Essentials;

namespace MediaPlayer
{
    /// <summary>
    /// The main activity class.
    /// </summary>
    [Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar.Fullscreen", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class MainActivity : Activity
    {
        /// <summary>
        /// The media player instance.
        /// </summary>
        private MediaPlayerCoreX _player;

        /// <summary>
        /// Seeking flag.
        /// </summary>
        private volatile bool _isSeeking;

        private bool _isPlaying;

        private bool _isPaused;

        /// <summary>
        /// The video view.
        /// </summary>
        private VisioForge.Core.UI.Android.VideoViewTX videoView;

        /// <summary>
        /// The open file button.
        /// </summary>
        private ImageButton btOpenFile;

        /// <summary>
        /// The start/pause toggle button.
        /// </summary>
        private ImageButton btStart;

        /// <summary>
        /// The stop button.
        /// </summary>
        private ImageButton btStop;

        /// <summary>
        /// The URL edit text.
        /// </summary>
        private EditText edURL;

        /// <summary>
        /// The timeline seek bar.
        /// </summary>
        private SeekBar sbTimeline;

        /// <summary>
        /// The position text view.
        /// </summary>
        private TextView lbPosition;

        /// <summary>
        /// The position timer.
        /// </summary>
        private readonly System.Timers.Timer tmPosition = new System.Timers.Timer(500);

        private View _panelView;

        private int _panelPaddingLeft;
        private int _panelPaddingTop;
        private int _panelPaddingRight;
        private int _panelPaddingBottom;

        /// <summary>
        /// On create.
        /// </summary>
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            Platform.Init(this, savedInstanceState);

            tmPosition.Elapsed += tmPosition_Elapsed;

            videoView = FindViewById<VisioForge.Core.UI.Android.VideoViewTX>(Resource.Id.videoView);

            _player = new MediaPlayerCoreX(videoView);
            _player.OnStart += _player_OnStart;

            btOpenFile = FindViewById<ImageButton>(Resource.Id.btOpenFile);
            btOpenFile.Click += btOpenFile_Click;

            btStart = FindViewById<ImageButton>(Resource.Id.btStart);
            btStart.Click += btStart_Click;

            btStop = FindViewById<ImageButton>(Resource.Id.btStop);
            btStop.Click += btStop_Click;

            sbTimeline = FindViewById<SeekBar>(Resource.Id.sbTimeline);
            sbTimeline.ProgressChanged += sbTimeline_ProgressChanged;

            sbTimeline.StartTrackingTouch += delegate (object sender, SeekBar.StartTrackingTouchEventArgs args)
            {
                _isSeeking = true;
            };

            sbTimeline.StopTrackingTouch += delegate (object sender, SeekBar.StopTrackingTouchEventArgs args)
            {
                _isSeeking = false;
            };

            lbPosition = FindViewById<TextView>(Resource.Id.lbPosition);
            edURL = FindViewById<EditText>(Resource.Id.edURL);

            _panelView = FindViewById<View>(Resource.Id.panel);
            ConfigureSystemInsets();
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
        /// On destroy.
        /// </summary>
        protected override async void OnDestroy()
        {
            tmPosition.Stop();

            if (_player != null)
            {
                _player.OnStart -= _player_OnStart;
                await _player.StopAsync();
                await _player.DisposeAsync();
                _player = null;
            }

            VisioForgeX.DestroySDK();

            base.OnDestroy();
        }

        /// <summary>
        /// Handles the player on start event.
        /// </summary>
        private void _player_OnStart(object sender, EventArgs e)
        {
            var duration = (int)_player.Duration().TotalMilliseconds;
            RunOnUiThread(() => sbTimeline.Max = duration);
        }

        /// <summary>
        /// Sb timeline progress changed.
        /// </summary>
        private void sbTimeline_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            if (e.FromUser && _isSeeking && _player != null)
            {
                _player.Position_Set(TimeSpan.FromMilliseconds(e.Progress));
            }
        }

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
                    return;

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
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            tmPosition.Stop();

            if (_player != null)
            {
                await _player.StopAsync();
            }

            _isPlaying = false;
            _isPaused = false;

            RunOnUiThread(() =>
            {
                sbTimeline.Progress = 0;
                btStart.SetImageResource(Resource.Drawable.ic_play);
            });
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

                    _isSeeking = false;

                    await _player.OpenAsync(new Uri(edURL.Text));
                    await _player.PlayAsync();

                    tmPosition.Start();

                    _isPlaying = true;
                    _isPaused = false;
                    btStart.SetImageResource(Resource.Drawable.ic_pause);
                }
                else if (!_isPaused)
                {
                    await _player.PauseAsync();
                    _isPaused = true;
                    btStart.SetImageResource(Resource.Drawable.ic_play);
                }
                else
                {
                    await _player.ResumeAsync();
                    _isPaused = false;
                    btStart.SetImageResource(Resource.Drawable.ic_pause);
                }
            }
            catch (Exception ex)
            {
                Android.Util.Log.Error("MainActivity", ex.ToString());
            }
        }

        /// <summary>
        /// On resume.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
        }

        /// <summary>
        /// Tm position elapsed.
        /// </summary>
        private void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_isSeeking)
            {
                return;
            }

            var player = _player;
            if (player == null)
            {
                return;
            }

            var pos = player.Position_Get();
            var duration = player.Duration();
            var progress = (int)pos.TotalMilliseconds;
            var durationMs = (int)duration.TotalMilliseconds;

            try
            {
                RunOnUiThread(() =>
                {
                    if (_player == null)
                    {
                        return;
                    }

                    if (durationMs > 0)
                    {
                        sbTimeline.Max = durationMs;
                    }

                    if (progress > sbTimeline.Max)
                    {
                        sbTimeline.Progress = sbTimeline.Max;
                    }
                    else
                    {
                        sbTimeline.Progress = progress;
                    }

                    lbPosition.Text = $"{pos.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}/{_player.Duration().ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";
                });
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        /// <summary>
        /// On pause.
        /// </summary>
        protected override async void OnPause()
        {
            base.OnPause();

            if (_player != null)
            {
                await _player.StopAsync();
            }
        }

        /// <summary>
        /// On request permissions result.
        /// </summary>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
