using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEncoders;

namespace WebrtcWhip;

public partial class Form1 : Form
{
    // 127.0.0.1 serves this computer only; with "0.0.0.0" other computers open http://<this PC's IP>:8090/?signalling=8443
    private const string Host = "127.0.0.1";
    private const int WebPort = 8090;
    private const int SignallingPort = 8443;

    private MediaBlocksPipeline pipeline;

    private VideoCaptureDeviceInfo[] cameras = [];

    private string whipUrl = string.Empty;

    private int viewers;

    public Form1()
    {
        InitializeComponent();
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        // The window takes no input, closing included, until the SDK and the camera list are ready
        try
        {
            await VisioForgeX.InitSDKAsync();

            if (!WebRTCSinkBlock.IsAvailable() || !WHIPSinkBlock.IsAvailable())
            {
                lbStatus.Text = "Add the VisioForge.CrossPlatform.Core.Windows.Adds.x64 package";
                return;
            }

            cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
            if (cameras.Length == 0)
            {
                lbStatus.Text = "No camera found";
                return;
            }

            cbCamera.Items.AddRange(cameras.Select(c => c.DisplayName).ToArray());
            cbCamera.SelectedIndex = 0;

            // One pipeline for the app: Start adds the blocks, Stop clears them
            pipeline = new MediaBlocksPipeline();
            pipeline.OnError += (_, args) => BeginInvoke(() => lbStatus.Text = args.Message);

            btStart.Enabled = true;
        }
        finally
        {
            Enabled = true;
        }
    }

    private async void btStart_Click(object sender, EventArgs e)
    {
        btStart.Enabled = false;
        lbStatus.Text = "Starting...";

        // A viewer page left open reconnects while the stream starts: count it
        viewers = 0;

        var started = false;
        try
        {
            var camera = new SystemVideoSourceBlock(new VideoCaptureDeviceSourceSettings(cameras[cbCamera.SelectedIndex]));

            // The app serves the viewer page and runs the signalling: no media server
            var webrtc = new WebRTCSinkBlock(new WebRTCSinkSettings
            {
                SignallingServerHost = Host,
                SignallingServerPort = SignallingPort,
                WebServerDirectory = Path.Combine(AppContext.BaseDirectory, "wwwroot"),
                WebServerAddress = $"http://{Host}:{WebPort}/"
            });

            // Raised on a GStreamer thread: BeginInvoke moves to the UI thread
            webrtc.ConsumerAdded += (_, _) => BeginInvoke(() => ShowViewers(viewers + 1));
            webrtc.ConsumerRemoved += (_, _) => BeginInvoke(() => ShowViewers(viewers - 1));

            whipUrl = edWhipUrl.Text.Trim();
            if (whipUrl.Length == 0)
            {
                // Raw video: the sink encodes VP8 for each viewer
                pipeline.Connect(camera.Output, webrtc.CreateNewInput(MediaBlockPadMediaType.Video));
            }
            else
            {
                // One camera, two outputs: the browsers and the media server
                var tee = new TeeBlock(2, MediaBlockPadMediaType.Video);
                pipeline.Connect(camera.Output, tee.Input);
                pipeline.Connect(tee.Outputs[0], webrtc.CreateNewInput(MediaBlockPadMediaType.Video));

                // WHIP takes H.264, encoded once: the server serves every viewer
                var h264 = new H264EncoderBlock(new OpenH264EncoderSettings());
                var whip = new WHIPSinkBlock(new WHIPSinkSettings { Location = whipUrl });
                pipeline.Connect(tee.Outputs[1], h264.Input);
                pipeline.Connect(h264.Output, whip.CreateNewInput(MediaBlockPadMediaType.Video));
            }

            started = await pipeline.StartAsync();
        }
        catch (Exception ex)
        {
            lbStatus.Text = ex.Message;
        }

        if (started)
        {
            btStop.Enabled = true;
            ShowViewers(viewers);
            return;
        }

        // An SDK error posted during the start stays on screen
        if (lbStatus.Text == "Starting...") lbStatus.Text = "The stream did not start";
        await pipeline.StopAsync();
        pipeline.ClearBlocks();
        btStart.Enabled = true;
    }

    private void ShowViewers(int count)
    {
        viewers = count;

        // Counted while it starts, shown once it streams
        if (!btStop.Enabled) return;

        lbStatus.Text = $"Open http://localhost:{WebPort}/?signalling={SignallingPort}{Environment.NewLine}Viewers: {viewers}";
        if (whipUrl.Length > 0) lbStatus.Text += $"{Environment.NewLine}WHIP: {whipUrl}";
    }

    private async void btStop_Click(object sender, EventArgs e)
    {
        await StopAsync();
    }

    private async Task StopAsync()
    {
        btStop.Enabled = false;

        // Ends every viewer's session and, for WHIP, the session on the server
        await pipeline.StopAsync();
        pipeline.ClearBlocks();

        lbStatus.Text = "Stopped";
        btStart.Enabled = true;
    }

    private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (pipeline == null)
        {
            VisioForgeX.DestroySDK(); // disposed below, or there was nothing to stream
            return;
        }

        e.Cancel = true;
        if (!btStart.Enabled && !btStop.Enabled) return; // starting, stopping or closing: close again after it

        // Stop and dispose first, then close
        if (btStop.Enabled) await StopAsync();
        btStart.Enabled = false;
        await pipeline.DisposeAsync();
        pipeline = null;
        BeginInvoke(Close);
    }
}
