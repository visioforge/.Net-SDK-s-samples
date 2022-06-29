using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using System;

namespace Simple_Player_Demo
{
    using Android.Widget;
    using System.Globalization;
    using System.Threading;
    using VisioForge.Core.MediaPlayerGST;
    using Xamarin.Essentials;

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private string TEST_URL = "http://test.visioforge.com/video.avi";

        private MediaPlayerGST _player;

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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.main);

            tmPosition.Elapsed += tmPosition_Elapsed;

            videoView = FindViewById<VisioForge.Core.UI.Android.VideoView>(Resource.Id.videoView);

            _player = new MediaPlayerGST(videoView, JNIEnv.Handle, this);
            _player.OnStart += _player_OnStart;

            btOpenFile = FindViewById<Button>(Resource.Id.btOpenFile);
            btOpenFile.Click += btOpenFile_Click;

            btStart = FindViewById<Button>(Resource.Id.btStart);
            btStart.Click += btStart_Click;

            btPause = FindViewById<Button>(Resource.Id.btPause);
            btPause.Click += btPause_Click;

            btStop = FindViewById<Button>(Resource.Id.btStop);
            btStop.Click += btStop_Click;

            sbTimeline = FindViewById<SeekBar>(Resource.Id.sbTimeline);
            sbTimeline.ProgressChanged += sbTimeline_ProgressChanged;

            sbTimeline.StartTrackingTouch += delegate (object sender, SeekBar.StartTrackingTouchEventArgs args)
            {
                isSeeking = true;
            };

            sbTimeline.StopTrackingTouch += delegate (object sender, SeekBar.StopTrackingTouchEventArgs args)
            {
                isSeeking = false;
            };

            lbPosition = FindViewById<TextView>(Resource.Id.lbPosition);

            pnScreen = FindViewById<GridLayout>(Resource.Id.pnScreen);

            edURL = FindViewById<EditText>(Resource.Id.edURL);
            edURL.Text = TEST_URL;
        }

        private void _player_OnStart(object sender, EventArgs e)
        {
            sbTimeline.Max = (int)_player.Duration().TotalMilliseconds;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void sbTimeline_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            if (isSeeking)
            {
                _player.Position_Set(TimeSpan.FromMilliseconds(e.Progress));
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
            tmPosition.Stop();

            await _player.StopAsync();

            // clear screen workaround
            pnScreen.RemoveView(videoView);
            pnScreen.AddView(videoView);
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            if (_player == null)
            {
                return;
            }

            if (btPause.Text == "Pause")
            {
                await _player.PauseAsync();
                btPause.Text = "Resume";
            }
            else
            {
                await _player.ResumeAsync();
                btPause.Text = "Pause";
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            isSeeking = false;

            await _player.OpenAsync(new Uri(edURL.Text));
            await _player.PlayAsync();

            tmPosition.Start();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        private void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (isSeeking)
            {
                return;
            }

            var pos = _player.Position_Get();
            var progress = (int)pos.TotalMilliseconds;
            if (progress > sbTimeline.Max)
            {
                sbTimeline.Progress = sbTimeline.Max;
            }
            else
            {
                sbTimeline.Progress = progress;
            }

            try
            {
                RunOnUiThread(() =>
                {
                    if (_player == null)
                    {
                        return;
                    }

                    // This is where the received data is passed
                    lbPosition.Text = $"{pos.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}/{_player.Duration().ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";
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

            _player.StopAsync();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
