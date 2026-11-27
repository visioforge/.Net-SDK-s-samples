using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;

namespace HlsWebcam;

public partial class Form1 : Form
{
    // The playlist, the segments and the viewer page: the sink's HTTP server serves this folder
    private readonly string hlsFolder = Path.Combine(AppContext.BaseDirectory, "hls");

    private MediaBlocksPipeline pipeline;

    private VideoCaptureDeviceInfo[] cameras = [];

    private AudioCaptureDeviceInfo[] microphones = [];

    // The port the running stream was started on: edPort can change meanwhile
    private int port;

    private string Address => $"Open http://localhost:{port}/ in a browser";

    public Form1()
    {
        InitializeComponent();
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        // The window takes no input, closing included, until the SDK and the device lists are ready
        try
        {
            await VisioForgeX.InitSDKAsync();

            cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
            if (cameras.Length == 0)
            {
                lbStatus.Text = "No camera found";
                return;
            }

            cbCamera.Items.AddRange(cameras.Select(c => c.DisplayName).ToArray());
            cbCamera.SelectedIndex = 0;

            // The first item streams video only
            microphones = await DeviceEnumerator.Shared.AudioSourcesAsync();
            cbMicrophone.Items.Add("No microphone");
            cbMicrophone.Items.AddRange(microphones.Select(m => m.DisplayName).ToArray());
            cbMicrophone.SelectedIndex = microphones.Length > 0 ? 1 : 0;

            // One pipeline for the app: Start adds the blocks, Stop clears them
            pipeline = new MediaBlocksPipeline();
            // While the stream runs, an error goes under the address
            pipeline.OnError += (_, args) => BeginInvoke(() => lbStatus.Text = btStop.Enabled ? $"{Address}{Environment.NewLine}{args.Message}" : args.Message);

            btStart.Enabled = true;
        }
        catch (Exception ex)
        {
            lbStatus.Text = ex.Message;
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

        var started = false;
        try
        {
            // The last run's segments and playlist go, so the page never plays an old stream
            Directory.CreateDirectory(hlsFolder);
            foreach (var file in Directory.GetFiles(hlsFolder, "*.ts")) File.Delete(file);
            var playlist = Path.Combine(hlsFolder, "playlist.m3u8");
            File.Delete(playlist);

            // The camera, split in two: the preview in the window, and the H.264 encoder
            var camera = new SystemVideoSourceBlock(new VideoCaptureDeviceSourceSettings(cameras[cbCamera.SelectedIndex]));
            var tee = new TeeBlock(2, MediaBlockPadMediaType.Video);
            var preview = new VideoRendererBlock(pipeline, VideoView1) { IsSync = false };
            var h264 = new H264EncoderBlock(); // the GPU encoder when there is one, OpenH264 otherwise

            port = (int)edPort.Value;

            // MPEG-TS segments of about 2 s, the last 5 in the playlist, 10 kept on disk
            var hls = new HLSSinkBlock(new HLSSinkSettings
            {
                Location = Path.Combine(hlsFolder, "segment_%05d.ts"),
                PlaylistLocation = playlist,
                TargetDuration = TimeSpan.FromSeconds(2),
                PlaylistLength = 5,
                MaxFiles = 10,
                Custom_HTTP_Server_Enabled = true,
                Custom_HTTP_Server_Port = port
            });

            pipeline.Connect(camera.Output, tee.Input);
            pipeline.Connect(tee.Outputs[0], preview.Input);
            pipeline.Connect(tee.Outputs[1], h264.Input);
            pipeline.Connect(h264.Output, hls.CreateNewInput(MediaBlockPadMediaType.Video));

            if (cbMicrophone.SelectedIndex > 0)
            {
                // The microphone, encoded to AAC, into the same segments
                var microphone = new SystemAudioSourceBlock(new AudioCaptureDeviceSourceSettings(microphones[cbMicrophone.SelectedIndex - 1]));
                var aac = new AACEncoderBlock();
                pipeline.Connect(microphone.Output, aac.Input);
                pipeline.Connect(aac.Output, hls.CreateNewInput(MediaBlockPadMediaType.Audio));
            }

            started = await pipeline.StartAsync();
        }
        catch (Exception ex)
        {
            lbStatus.Text = ex.Message;
        }

        // An SDK error posted during the start (the HTTP server's port taken, for one) stays on screen, under the address
        if (started)
        {
            btStop.Enabled = true;
            lbStatus.Text = lbStatus.Text == "Starting..." ? Address : $"{Address}{Environment.NewLine}{lbStatus.Text}";
            return;
        }

        if (lbStatus.Text == "Starting...") lbStatus.Text = "The stream did not start";
        await pipeline.StopAsync();
        pipeline.ClearBlocks();
        btStart.Enabled = true;
    }

    private async void btStop_Click(object sender, EventArgs e)
    {
        await StopAsync();
    }

    private async Task StopAsync()
    {
        btStop.Enabled = false;

        // Stops the camera and the encoders; ClearBlocks disposes the blocks, which frees the HTTP server's port
        await pipeline.StopAsync();
        pipeline.ClearBlocks();
        VideoView1.Invalidate();

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
