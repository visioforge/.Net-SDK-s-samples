using System.ComponentModel;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.X.Sources;

namespace WhepPlayerWpf;

public partial class MainWindow : Window
{
    private MediaBlocksPipeline _pipeline;

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await VisioForgeX.InitSDKAsync();

        if (!WHEPSourceBlock.IsAvailable())
        {
            Title = "No WHEP source: add the VisioForge.CrossPlatform.Core.Windows.Adds.x64 package";
            btStart.IsEnabled = false;
            cbAudio.IsEnabled = false;
        }

        IsEnabled = true;
    }

    private async void btStart_Click(object sender, RoutedEventArgs e)
    {
        Title = "WHEP Player";
        IsEnabled = false; // no clicks, and no close, until it has started

        _pipeline = new MediaBlocksPipeline();

        // Show SDK errors in the title bar, also those the server sends after Start (a wrong path, a refused track)
        _pipeline.OnError += (_, args) => Dispatcher.InvokeAsync(() => Title = args.Message);

        // Video is always asked for; audio only when the stream has it: the server refuses a track it does not send
        var audio = cbAudio.IsChecked == true;
        var source = new WHEPSourceBlock(new WHEPSourceSettings
        {
            Location = edURL.Text.Trim(),
            AudioEnabled = audio,
        });

        // IsSync = false: play each frame the moment it arrives, the lowest latency, at the cost of lip sync
        var video = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };
        _pipeline.Connect(source.VideoOutput, video.Input);

        if (audio)
        {
            var speakers = new AudioRendererBlock { IsSync = false };
            _pipeline.Connect(source.AudioOutput, speakers.Input);
        }

        var started = await _pipeline.StartAsync();
        if (!started) await StopAsync();

        btStart.IsEnabled = !started;
        cbAudio.IsEnabled = !started;
        btStop.IsEnabled = started;
        IsEnabled = true;
    }

    private async Task StopAsync()
    {
        await _pipeline.StopAsync();
        await _pipeline.DisposeAsync();
        _pipeline = null;
    }

    private async void btStop_Click(object sender, RoutedEventArgs e)
    {
        IsEnabled = false;
        await StopAsync();
        btStop.IsEnabled = false;
        btStart.IsEnabled = true;
        cbAudio.IsEnabled = true;
        IsEnabled = true;
    }

    private async void Window_Closing(object sender, CancelEventArgs e)
    {
        if (IsEnabled && _pipeline == null)
        {
            VisioForgeX.DestroySDK();
            return;
        }

        e.Cancel = true; // busy, or still playing: stop first
        if (!IsEnabled) return; // loading, starting or stopping: close again after
        IsEnabled = false;

        if (_pipeline != null) await StopAsync();

        IsEnabled = true;
        await Dispatcher.InvokeAsync(Close); // not Close(): WPF throws inside Closing
    }
}
