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
using VisioForge.Core.UI.Skins;
using Stream = System.IO.Stream;
using System.Reflection;
using System.Drawing.Printing;
using VisioForge.Core.Types.X.Output;

#if ANDROID
using Android.Runtime;
using Android.Media;
#endif

namespace SkinnedPlayer_MAUI
{
    public partial class MainPage : ContentPage
    {
        private string SKIN_NAME = "Default.vfskin";

        private MediaPlayerCoreX _player;

#if ANDROID
        private const string DEFAULT_FILENAME = "http://test.visioforge.com/video.mp4";
#else
        private const string DEFAULT_FILENAME = @"c:\samples\!video.mp4";
#endif

        /// <summary>
        /// Loads this instance.
        /// </summary>
        private void LoadSkin()
        {
            var assembly = GetType().Assembly;
            var resources = assembly.GetManifestResourceNames();

            foreach (string resourceKey in resources)
            {
                if (resourceKey.Contains(SKIN_NAME))
                {
                    using (var stream = assembly.GetManifestResourceStream(resourceKey))
                    {
                        var data = new byte[stream.Length];
                        stream.Read(data, 0, data.Length);

                        SkinManager.LoadFromData("Default", data);
                    }
                }
            }
        }
        
        public MainPage()
        {
            LoadSkin();
            
            InitializeComponent();

            Loaded += MainPage_Loaded;

            //playlist.SkinName = "Default";
            //playerControls.SkinName = "Default";
        }

        private void Window_Destroying(object sender, EventArgs e)
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
#if __ANDROID__
            _player = new MediaPlayerCoreX(videoView, Microsoft.Maui.ApplicationModel.Platform.CurrentActivity);
#else
            var handler = videoView.Handler as VisioForge.Core.UI.MAUI.VideoViewXHandler;
            _player = new MediaPlayerCoreX(handler.VideoView);
#endif

            _player.OnError += _player_OnError;
            var audioOutputs = _player.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.Default).Result;
            if (audioOutputs.Length > 0)
            {
                _player.Audio_OutputDevice = audioOutputs[0];
            }

            pbPanel.Player = _player;

            //edFilename.Text = DEFAULT_FILENAME;

            Window.Destroying += Window_Destroying;
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