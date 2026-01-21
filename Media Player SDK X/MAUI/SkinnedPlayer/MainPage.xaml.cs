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
using VisioForge.Core;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.AudioRenderers;


#if ANDROID
using Android.Runtime;
using Android.Media;
#endif

namespace SkinnedPlayer_MAUI
{
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// The skin files.
        /// </summary>
        private readonly string[] SKIN_FILES = { "Default.vfskin", "Violet.vfskin" };

        /// <summary>
        /// The skin names.
        /// </summary>
        private readonly string[] SKIN_NAMES = { "Default", "Violet" };

        /// <summary>
        /// The current skin index.
        /// </summary>
        private int _currentSkinIndex = 0;

        /// <summary>
        /// The media player instance.
        /// </summary>
        private MediaPlayerCoreX _player;

        /// <summary>
        /// The default filename.
        /// </summary>
#if ANDROID
        private const string DEFAULT_FILENAME = "http://test.visioforge.com/video.mp4";
#else
        private const string DEFAULT_FILENAME = @"c:\samples\!video.mp4";
#endif

        /// <summary>
        /// Loads all available skins from embedded resources.
        /// </summary>
        private void LoadAllSkins()
        {
            var assembly = GetType().Assembly;
            var resources = assembly.GetManifestResourceNames();

            foreach (var skinFile in SKIN_FILES)
            {
                foreach (string resourceKey in resources)
                {
                    if (resourceKey.Contains(skinFile))
                    {
                        using (var stream = assembly.GetManifestResourceStream(resourceKey))
                        {
                            var data = new byte[stream.Length];
                            stream.Read(data, 0, data.Length);

                            // Extract skin name from file name (remove .vfskin)
                            var skinName = skinFile.Replace(".vfskin", "");
                            SkinManager.LoadFromData(skinName, data);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the skin selection button click to toggle between available skins.
        /// </summary>
        private void OnSkinSelectClicked(object sender, EventArgs e)
        {
            // Cycle to next skin
            _currentSkinIndex = (_currentSkinIndex + 1) % SKIN_NAMES.Length;
            var skinName = SKIN_NAMES[_currentSkinIndex];

            // Update UI
            pbPanel.SkinName = skinName;
            btSkinSelect.Text = skinName;

            // Update button color based on skin
            if (skinName == "Violet")
            {
                btSkinSelect.BackgroundColor = Color.FromArgb("#9B59B6");
            }
            else
            {
                btSkinSelect.BackgroundColor = Color.FromArgb("#512BD4");
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            LoadAllSkins();
            
            InitializeComponent();

            Loaded += MainPage_Loaded;

            //playlist.SkinName = "Default";
            //playerControls.SkinName = "Default";
        }

        /// <summary>
        /// Window destroying.
        /// </summary>
        private void Window_Destroying(object? sender, EventArgs e)
        {
            if (_player != null)
            {
                _player.OnError -= _player_OnError;
                _player.Stop();

                _player.Dispose();
                _player = null;
            }

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Main page loaded.
        /// </summary>
        private async void MainPage_Loaded(object? sender, EventArgs e)
        {
            IVideoView vv = videoView.GetVideoView();

            _player = new MediaPlayerCoreX(vv);

            _player.OnError += _player_OnError;

#if !__IOS__ && !__MACCATALYST__
            var audioOutputs = await _player.Audio_OutputDevicesAsync();
            if (audioOutputs.Length > 0)
            {
                _player.Audio_OutputDevice = new AudioRendererSettings(audioOutputs[0]);
            }
#endif

            pbPanel.Player = _player;

            //edFilename.Text = DEFAULT_FILENAME;

            Window.Destroying += Window_Destroying;
        }

        /// <summary>
        /// On stop.
        /// </summary>
        private void OnStop(object? sender, EventArgs e)
        {
            if (_player != null)
            {
                _player.OnError -= _player_OnError;
                _player.Stop();
            }
        }

        /// <summary>
        /// Player on error.
        /// </summary>
        private void _player_OnError(object? sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }
    }
}
