using System.ComponentModel;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.MediaPlayerX;

namespace VideoPlayerShort;

public partial class MainWindow : Window
{
    private MediaPlayerCoreX _player;

    private bool _ready;

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await VisioForgeX.InitSDKAsync();

        _player = new(VideoView1);
        _player.OnError += (_, e) =>
            Dispatcher.InvokeAsync(() =>
                MessageBox.Show(e.Message));

        var root = AppContext.BaseDirectory;
        var file = $"{root}video.mp4";
        if (await _player.OpenAsync(file))
            await _player.PlayAsync();

        _ready = true;
    }

    private void Window_Closing(object sender, CancelEventArgs e)
    {
        if (!_ready)
        {
            e.Cancel = true; // still opening
            return;
        }

        _player?.Dispose();
        VisioForgeX.DestroySDK();
    }
}
