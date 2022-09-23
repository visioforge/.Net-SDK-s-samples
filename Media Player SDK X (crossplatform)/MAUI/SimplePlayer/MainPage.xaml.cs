//using VisioForge.Core.UI.MAUI;
using System.Diagnostics;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using System.Globalization;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks;

using VisioForge.Core.MediaBlocks.VideoRendering;

using VisioForge.Core.MediaPlayerX;

#if ANDROID
using Android.Runtime;
using Android.Media;
#endif

namespace Simple_Media_Player_MAUI
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
            Unloaded += MainPage_Unloaded;

            //pbPanel.OnPreparePlayClick += PlaybackPanel_OnPreparePlayClick;
        }

        private void MainPage_Unloaded(object sender, EventArgs e)
        {
            if (_player != null)
            {
                _player.OnError -= _player_OnError;
                _player.Stop();

                _player.Dispose();
                _player = null;
            }
        }

        private void MainPage_Loaded(object sender, EventArgs e)
        {
#if ANDROID
            //var view = (Android.Views.ViewGroup)this.Handler.PlatformView;
            //var context = view.Context;
            var activity = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity; //(Android.App.Activity)context;
            //_player = new MediaPlayerCoreX(imgVideo, activity, VisioForge.Core.Types.PlatformType.Android);
#else
            //_player = new MediaPlayerCoreX(imgVideo);
#endif
            //_player.OnError += _player_OnError;

            //pbPanel.Player = _player;

            //edFilename.Text = DEFAULT_FILENAME;
        }

        private void PlaybackPanel_OnPreparePlayClick(object sender, EventArgs e)
        {
            //pbPanel.Filename = edFilename.Text;
        }

        private void OnStop(object sender, EventArgs e)
        {
            if (_player != null)
            {
                _player.OnError -= _player_OnError;
                _player.Stop();
            }
        }

        private void _player_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }
    }
}