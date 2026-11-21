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
    private MediaBlocksPipeline _sendPipeline;

    private MediaBlocksPipeline _receivePipeline;

    private VideoCaptureDeviceInfo[] _cameras;

    private AudioCaptureDeviceInfo[] _microphones;

    private NDISourceInfo[] _ndiSources;

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await VisioForgeX.InitSDKAsync();

        _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
        foreach (var device in _cameras)
            cbCamera.Items.Add(device.DisplayName);

        _microphones = await DeviceEnumerator.Shared.AudioSourcesAsync();
        foreach (var device in _microphones)
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
        IsEnabled = false; // no clicks until it has started; Window_Closing waits too

        _sendPipeline = CreatePipeline();

        // The camera goes to the preview and to NDI through a tee
        var camera = new SystemVideoSourceBlock(
            new VideoCaptureDeviceSourceSettings(_cameras[cbCamera.SelectedIndex]));
        var tee = new TeeBlock(2, MediaBlockPadMediaType.Video);
        var preview = new VideoRendererBlock(_sendPipeline, VideoView1);
        var ndiSink = new NDISinkBlock(edName.Text.Trim());

        _sendPipeline.Connect(camera.Output, tee.Input);
        _sendPipeline.Connect(tee.Outputs[0], preview.Input);
        _sendPipeline.Connect(tee.Outputs[1], ndiSink.CreateNewInput(MediaBlockPadMediaType.Video));

        // No microphone: send video only
        if (cbMicrophone.SelectedIndex >= 0)
        {
            var microphone = new SystemAudioSourceBlock(
                _microphones[cbMicrophone.SelectedIndex].CreateSourceSettings());
            _sendPipeline.Connect(microphone.Output, ndiSink.CreateNewInput(MediaBlockPadMediaType.Audio));
        }

        var started = await _sendPipeline.StartAsync();
        if (!started) await StopSendAsync();

        btSend.IsEnabled = !started;
        btStopSend.IsEnabled = started;
        IsEnabled = true;
    }

    private async Task StopSendAsync()
    {
        await _sendPipeline.StopAsync();
        await _sendPipeline.DisposeAsync();
        _sendPipeline = null;
    }

    private async void btStopSend_Click(object sender, RoutedEventArgs e)
    {
        IsEnabled = false;
        await StopSendAsync();
        btStopSend.IsEnabled = false;
        btSend.IsEnabled = true;
        IsEnabled = true;
    }

    private async void btRefresh_Click(object sender, RoutedEventArgs e)
    {
        IsEnabled = false;

        // Every NDI sender on the network, this app's own one included
        _ndiSources = await DeviceEnumerator.Shared.NDISourcesAsync();
        cbSource.Items.Clear();
        foreach (var source in _ndiSources)
            cbSource.Items.Add(source.Name);

        if (cbSource.Items.Count > 0) cbSource.SelectedIndex = 0;

        btReceive.IsEnabled = cbSource.Items.Count > 0 && _receivePipeline == null;
        IsEnabled = true;
    }

    private async void btReceive_Click(object sender, RoutedEventArgs e)
    {
        Title = "NDI Send and Receive";
        IsEnabled = false;

        _receivePipeline = CreatePipeline();

        // Connects to the sender and reads its video and audio formats
        var settings = await NDISourceSettings.CreateAsync(
            _receivePipeline.GetContext(), _ndiSources[cbSource.SelectedIndex]);

        var started = false;
        if (settings != null)
        {
            var ndiSource = new NDISourceBlock(settings);

            if (settings.GetInfo().VideoStreams.Count > 0)
            {
                var video = new VideoRendererBlock(_receivePipeline, VideoView2);
                _receivePipeline.Connect(ndiSource.VideoOutput, video.Input);
            }

            // Off for this app's own sender: the microphone would come back out of the speakers
            if (settings.GetInfo().AudioStreams.Count > 0 && cbPlayAudio.IsChecked == true)
            {
                var speakers = new AudioRendererBlock();
                _receivePipeline.Connect(ndiSource.AudioOutput, speakers.Input);
            }

            started = await _receivePipeline.StartAsync();
        }

        if (!started) await StopReceiveAsync();

        btReceive.IsEnabled = !started;
        btStopReceive.IsEnabled = started;
        IsEnabled = true;
    }

    private async Task StopReceiveAsync()
    {
        await _receivePipeline.StopAsync();
        await _receivePipeline.DisposeAsync();
        _receivePipeline = null;
    }

    private async void btStopReceive_Click(object sender, RoutedEventArgs e)
    {
        IsEnabled = false;
        await StopReceiveAsync();
        btStopReceive.IsEnabled = false;
        btReceive.IsEnabled = cbSource.Items.Count > 0;
        IsEnabled = true;
    }

    private async void Window_Closing(object sender, CancelEventArgs e)
    {
        if (IsEnabled && _sendPipeline == null && _receivePipeline == null)
        {
            VisioForgeX.DestroySDK();
            return;
        }

        e.Cancel = true; // busy, or still sending or receiving: stop first
        if (!IsEnabled) return; // loading, starting or stopping: close again after
        IsEnabled = false;

        if (_sendPipeline != null) await StopSendAsync();
        if (_receivePipeline != null) await StopReceiveAsync();

        IsEnabled = true;
        await Dispatcher.InvokeAsync(Close); // not Close(): WPF throws inside Closing
    }
}
