using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Graphics.Canvas;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using Windows.Storage.Pickers;
using Windows.UI;
using VisioForge.Core.UI.WinUI;
using VisioForge.Core;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Simple_Media_Player_WinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        /// <summary>
        /// The media player instance.
        /// </summary>
        private MediaPlayerCoreX MediaPlayer1;

        /// <summary>
        /// The position timer.
        /// </summary>
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        /// <summary>
        /// The video view.
        /// </summary>
        private VideoView _videoView;

        /// <summary>
        /// Timer tag flag.
        /// </summary>
        private volatile byte _timerTag = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            this.Closed += MainWindow_Closed;

            edFilename.Text = string.Empty;

            _videoView = new VideoView(canvasControl);
            MediaPlayer1 = new MediaPlayerCoreX(_videoView);
            MediaPlayer1.Audio_Play = true;
            MediaPlayer1.OnError += MediaPlayer1_OnError;
            Title = $"Media Player SDK .Net - Simple Media Player for WinUI 3 Desktop (SDK v{MediaPlayerCoreX.SDK_Version})";

            IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this); // m_window in App.cs
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
            AppWindow appWindow = AppWindow.GetFromWindowId(windowId);

            var size = new Windows.Graphics.SizeInt32();
            size.Width = 1920;
            size.Height = 1000;

            appWindow.Resize(size);

            InitTimer();
        }

        /// <summary>
        /// Main window closed.
        /// </summary>
        private async void MainWindow_Closed(object sender, WindowEventArgs args)
        {
            try
            {
                await MediaPlayer1.StopAsync();

                await MediaPlayer1.DisposeAsync();

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Window closed error: {ex.Message}");
            }
        }

#pragma warning disable S3168 // "async" methods should not return "void"
        /// <summary>
        /// Handles the timer tick event.
        /// </summary>
        private async void _timer_Tick(object sender, object e)
#pragma warning restore S3168 // "async" methods should not return "void"
        {
            try
            {
                _timerTag = 1;
                var dur = await MediaPlayer1.DurationAsync();
                slPosition.Maximum = (int)dur.TotalSeconds;

                var pos = await MediaPlayer1.Position_GetAsync();
                int value = (int)pos.TotalSeconds;
                if ((value > 0) && (value < slPosition.Maximum))
                {
                    slPosition.Value = value;
                }

                lbPosition.Text = pos.ToString(@"hh\:mm\:ss") + "/" + dur.ToString(@"hh\:mm\:ss");

                _timerTag = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Timer error: {ex.Message}");
            }
        }

        /// <summary>
        /// Init timer.
        /// </summary>
        private void InitTimer()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(500);
            _timer.Tick += _timer_Tick;
        }

        /// <summary>
        /// Media player 1 on error.
        /// </summary>
        private void MediaPlayer1_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        /// <summary>
        /// Handles the bt open file click event.
        /// </summary>
        private async void btOpenFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileOpenPicker open = new FileOpenPicker();
                open.SuggestedStartLocation = PickerLocationId.VideosLibrary;
                open.FileTypeFilter.Add("*");

                var m_hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
                WinRT.Interop.InitializeWithWindow.Initialize(open, m_hwnd);

                var file = await open.PickSingleFileAsync();
                if (file != null)
                {
                    edFilename.Text = file.Path;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Open file error: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await MediaPlayer1.StopAsync();

                _timer.Stop();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Stop error: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //canvasControl.Invalidate();
                await MediaPlayer1.ResumeAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Resume error: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await MediaPlayer1.PauseAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Pause error: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the bt play click event.
        /// </summary>
        private async void btPlay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var audioOutputDevice = (await MediaPlayer1.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound)).FirstOrDefault();
                if (audioOutputDevice == null)
                {
                    Debug.WriteLine("No audio output devices available");
                    return;
                }
                MediaPlayer1.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);

                var fileSource = await UniversalSourceSettings.CreateAsync(edFilename.Text);
                await MediaPlayer1.OpenAsync(fileSource);

                await MediaPlayer1.PlayAsync();

                _timer.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Play error: {ex.Message}");
            }
        }

        /// <summary>
        /// Sl position value changed.
        /// </summary>
        private async void slPosition_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            try
            {
                if (_timerTag == 0)
                {
                    await MediaPlayer1.Position_SetAsync(TimeSpan.FromSeconds(slPosition.Value));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Seek error: {ex.Message}");
            }
        }
    }
}
