using System.ComponentModel;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.X.Sources;

namespace NdiWpf;

public partial class MainWindow : Window
{
    private MediaBlocksPipeline sendPipeline;

    private MediaBlocksPipeline receivePipeline;

    private VideoCaptureDeviceInfo[] cameras;

    private AudioCaptureDeviceInfo[] microphones;

    private NDISourceInfo[] ndiSources;

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await VisioForgeX.InitSDKAsync();

        cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
        foreach (var device in cameras)
            cbCamera.Items.Add(device.DisplayName);

        microphones = await DeviceEnumerator.Shared.AudioSourcesAsync();
        foreach (var device in microphones)
            cbMicrophone.Items.Add(device.DisplayName);

        if (cbCamera.Items.Count > 0) cbCamera.SelectedIndex = 0;
        if (cbMicrophone.Items.Count > 0) cbMicrophone.SelectedIndex = 0;

        IsEnabled = true;
    }

    private MediaBlocksPipeline CreatePipeline()
    {
        var pipeline = new MediaBlocksPipeline();

        // Show SDK errors in the title bar
        pipeline.OnError += (_, args) => Dispatcher.InvokeAsync(() => Title = args.Message);

        return pipeline;
    }

    private async void btSend_Click(object sender, RoutedEventArgs e)
    {
        if (cbCamera.SelectedIndex < 0)
        {
            Title = "No camera";
            return;
        }

        if (string.IsNullOrWhiteSpace(edName.Text))
        {
            Title = "Enter the NDI name";
            return;
        }

        Title = "NDI Send and Receive";
        btSend.IsEnabled = false;

        sendPipeline = CreatePipeline();

        // The camera goes to the preview and to NDI through a tee
        var camera = new SystemVideoSourceBlock(
            new VideoCaptureDeviceSourceSettings(cameras[cbCamera.SelectedIndex]));
        var tee = new TeeBlock(2, MediaBlockPadMediaType.Video);
        var preview = new VideoRendererBlock(sendPipeline, VideoView1);
        var ndiSink = new NDISinkBlock(edName.Text.Trim());

        sendPipeline.Connect(camera.Output, tee.Input);
        sendPipeline.Connect(tee.Outputs[0], preview.Input);
        sendPipeline.Connect(tee.Outputs[1], ndiSink.CreateNewInput(MediaBlockPadMediaType.Video));

        // No microphone: send video only
        if (cbMicrophone.SelectedIndex >= 0)
        {
            var microphone = new SystemAudioSourceBlock(
                microphones[cbMicrophone.SelectedIndex].CreateSourceSettings());
            sendPipeline.Connect(microphone.Output, ndiSink.CreateNewInput(MediaBlockPadMediaType.Audio));
        }

        if (await sendPipeline.StartAsync())
        {
            btStopSend.IsEnabled = true;
            return;
        }

        await StopSendAsync();
        btSend.IsEnabled = true;
    }

    private async Task StopSendAsync()
    {
        var pipeline = sendPipeline;
        sendPipeline = null;
        await pipeline.StopAsync();
        await pipeline.DisposeAsync();
    }

    private async void btStopSend_Click(object sender, RoutedEventArgs e)
    {
        btStopSend.IsEnabled = false;
        await StopSendAsync();
        btSend.IsEnabled = true;
    }

    private async void btRefresh_Click(object sender, RoutedEventArgs e)
    {
        btRefresh.IsEnabled = false;

        // Every NDI sender on the network, this app's own one included
        ndiSources = await DeviceEnumerator.Shared.NDISourcesAsync();
        cbSource.Items.Clear();
        foreach (var source in ndiSources)
            cbSource.Items.Add(source.Name);

        if (cbSource.Items.Count > 0) cbSource.SelectedIndex = 0;

        btRefresh.IsEnabled = true;
        btReceive.IsEnabled = cbSource.Items.Count > 0 && receivePipeline == null;
    }

    private async void btReceive_Click(object sender, RoutedEventArgs e)
    {
        Title = "NDI Send and Receive";
        btReceive.IsEnabled = false;

        receivePipeline = CreatePipeline();

        // Connects to the sender and reads its video and audio formats
        var settings = await NDISourceSettings.CreateAsync(
            receivePipeline.GetContext(), ndiSources[cbSource.SelectedIndex]);

        if (settings != null)
        {
            var ndiSource = new NDISourceBlock(settings);
            var video = new VideoRendererBlock(receivePipeline, VideoView2);
            receivePipeline.Connect(ndiSource.VideoOutput, video.Input);

            if (settings.GetInfo().AudioStreams.Count > 0)
            {
                var speakers = new AudioRendererBlock();
                receivePipeline.Connect(ndiSource.AudioOutput, speakers.Input);
            }

            if (await receivePipeline.StartAsync())
            {
                btStopReceive.IsEnabled = true;
                return;
            }
        }

        await StopReceiveAsync();
        btReceive.IsEnabled = true;
    }

    private async Task StopReceiveAsync()
    {
        var pipeline = receivePipeline;
        receivePipeline = null;
        await pipeline.StopAsync();
        await pipeline.DisposeAsync();
    }

    private async void btStopReceive_Click(object sender, RoutedEventArgs e)
    {
        btStopReceive.IsEnabled = false;
        await StopReceiveAsync();
        btReceive.IsEnabled = cbSource.Items.Count > 0;
    }

    private async void Window_Closing(object sender, CancelEventArgs e)
    {
        if (IsEnabled && sendPipeline == null && receivePipeline == null)
        {
            VisioForgeX.DestroySDK();
            return;
        }

        e.Cancel = true; // still loading, or still sending or receiving: stop first
        if (!IsEnabled) return; // loading or already stopping
        IsEnabled = false;

        if (sendPipeline != null) await StopSendAsync();
        if (receivePipeline != null) await StopReceiveAsync();

        IsEnabled = true;
        await Dispatcher.InvokeAsync(Close); // not Close(): WPF throws inside Closing
    }
}
