using VisioForge.Core.UI.MAUI;
using System.Diagnostics;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using System.Globalization;
using VisioForge.Core.MediaPlayerX;

#if ANDROID
using Android.Runtime;
#endif

namespace Simple_Player_MAUI
{
    public partial class MainPage : ContentPage
    {
        private MediaPlayerCoreX _player;

#if ANDROID
        private const string DEFAULT_FILENAME = "http://test.visioforge.com/video.mp4";
#else
        private const string DEFAULT_FILENAME = @"c:\samples\!video.mp4";
#endif

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;

            pbPanel.OnPreparePlayClick += PlaybackPanel_OnPreparePlayClick;
        }

        private void MainPage_Loaded(object sender, EventArgs e)
        {
#if ANDROID
            //var view = (Android.Views.ViewGroup)this.Handler.PlatformView;
            //var context = view.Context;
            var activity = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity; //(Android.App.Activity)context;
            _player = new MediaPlayerCoreX(imgVideo, activity, VisioForge.Core.Types.PlatformType.Android);
#else
            _player = new MediaPlayerCoreX(imgVideo);
#endif
            _player.OnError += _player_OnError;

            pbPanel.Player = _player;
        }

        private void PlaybackPanel_OnPreparePlayClick(object sender, EventArgs e)
        {
            pbPanel.Filename = edFilename.Text;
        }

        private void OnStop(object sender, EventArgs e)
        {
            if (_player != null)
            {
                _player.OnError -= _player_OnError;
                _player.Stop();
            }
        }

        private async void OnSelectFile(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.Default.PickAsync();
                if (result != null)
                {
                    edFilename.Text = result.FullPath;
                }
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }
        }

        private void _player_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            edFilename.Text = DEFAULT_FILENAME;
        }
    }
}