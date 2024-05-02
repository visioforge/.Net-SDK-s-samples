﻿using Microsoft.UI;
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
        private MediaPlayerCoreX MediaPlayer1;

        //timer
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        private volatile byte _timerTag = 0;

        public MainWindow()
        {
            this.InitializeComponent();

            this.Closed += MainWindow_Closed;

            edFilename.Text = @"c:\samples\!video.mp4";

            MediaPlayer1 = new MediaPlayerCoreX(videoView);
            MediaPlayer1.Audio_Play = true;
            MediaPlayer1.OnError += MediaPlayer1_OnError;
            Title = $"Media Player SDK .Net - Simple Media Player for WinUI 3 Desktop (SDK v{MediaPlayerCoreX.SDK_Version})";

            // SetIcon();

            IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this); // m_window in App.cs
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
            AppWindow appWindow = AppWindow.GetFromWindowId(windowId);

            var size = new Windows.Graphics.SizeInt32();
            size.Width = 1920;
            size.Height = 1000;

            appWindow.Resize(size);

            InitTimer();
        }

        private async void MainWindow_Closed(object sender, WindowEventArgs args)
        {
            await MediaPlayer1.StopAsync();

            await MediaPlayer1.DisposeAsync();
        }

        private void SetIcon()
        {
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
            var appWindow = AppWindow.GetFromWindowId(windowId);
            appWindow.SetIcon(Path.Combine(Package.Current.InstalledLocation.Path, "Assets", "visioforge_main_icon.ico"));
        }

#pragma warning disable S3168 // "async" methods should not return "void"
        private async void _timer_Tick(object sender, object e)
#pragma warning restore S3168 // "async" methods should not return "void"
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
            var audioOutputDevice = (await MediaPlayer1.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound)).First();
            MediaPlayer1.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);

            var fileSource = await UniversalSourceSettings.CreateAsync(edFilename.Text);
            await MediaPlayer1.OpenAsync(fileSource);

            await MediaPlayer1.PlayAsync();

            _timer.Start();
        }

        private async void slPosition_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (_timerTag == 0)
            {
                await MediaPlayer1.Position_SetAsync(TimeSpan.FromSeconds(slPosition.Value));
            }
        }
    }
}
