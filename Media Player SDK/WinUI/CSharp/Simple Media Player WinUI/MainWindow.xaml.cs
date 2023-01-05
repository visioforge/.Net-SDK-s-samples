using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media;
using System;
using System.Diagnostics;
using System.IO;
using VisioForge.Core.MediaPlayer;
using Windows.ApplicationModel;
using Windows.Storage.Pickers;
using Windows.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Simple_Media_Player_WinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private MediaPlayerCore MediaPlayer1;

        private Color _videoViewBackgroud;

        //timer
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        private volatile byte _timerTag = 0;

        public MainWindow()
        {
            this.InitializeComponent();

            edFilename.Text = @"c:\samples\!video.mp4";

            MediaPlayer1 = new MediaPlayerCore(videoView);
            MediaPlayer1.OnError += MediaPlayer1_OnError;

            Title = $"Media Player SDK .Net - Simple Media Player for WinUI 3 Desktop (SDK v{MediaPlayer1.SDK_Version()})";

            _videoViewBackgroud = ((SolidColorBrush)videoView.Background).Color;

            SetIcon();

            InitTimer();
        }

        private void SetIcon()
        {
            try
            {
                IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(this);
                WindowId windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
                var appWindow = AppWindow.GetFromWindowId(windowId);
                appWindow.SetIcon(Path.Combine(Package.Current.InstalledLocation.Path, "Assets", "visioforge_main_icon.ico"));
            }
            catch 
            {                
            }            
        }

#pragma warning disable S3168 // "async" methods should not return "void"
        private async void _timer_Tick(object sender, object e)
#pragma warning restore S3168 // "async" methods should not return "void"
        {
            _timerTag = 1;
            slPosition.Maximum = (int)(await MediaPlayer1.Duration_TimeAsync()).TotalSeconds;

            int value = (int)(await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds;
            if ((value > 0) && (value < slPosition.Maximum))
            {
                slPosition.Value = value;
            }

            lbPosition.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted((int)slPosition.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted((int)slPosition.Maximum);

            _timerTag = 0;
        }

        private void InitTimer()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(500);
            _timer.Tick += _timer_Tick;
        }

        private void MediaPlayer1_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private async void btOpenFile_Click(object sender, RoutedEventArgs e)
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

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await MediaPlayer1.StopAsync();

            videoView.Background = new SolidColorBrush(_videoViewBackgroud);

            _timer.Stop();
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await MediaPlayer1.ResumeAsync();
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await MediaPlayer1.PauseAsync();
        }

        private async void btPlay_Click(object sender, RoutedEventArgs e)
        {
            videoView.Background = new SolidColorBrush(new Color { A = 0, R = 0, G = 0, B = 0 });

            MediaPlayer1.Playlist_Clear();
            MediaPlayer1.Playlist_Add(edFilename.Text);

            await MediaPlayer1.PlayAsync();

            _timer.Start();
        }

        private async void slPosition_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (_timerTag == 0)
            {
                await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(slPosition.Value));
            }
        }
    }
}
