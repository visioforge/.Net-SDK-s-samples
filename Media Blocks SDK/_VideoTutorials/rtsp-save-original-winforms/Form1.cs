using System.Diagnostics;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;

namespace RtspSaveOriginal;

public partial class Form1 : Form
{
    private MediaBlocksPipeline pipeline;

    private string outputFile = string.Empty;

    private readonly Stopwatch clock = new();

    private TimeSpan lastCpuTime;

    private TimeSpan lastClockTime;

    private bool failed;

    public Form1()
    {
        InitializeComponent();
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        await VisioForgeX.InitSDKAsync();
        btStart.Enabled = true;
    }

    private async void btStart_Click(object sender, EventArgs e)
    {
        if (!Uri.TryCreate(edURL.Text, UriKind.Absolute, out var url))
        {
            Text = "Enter the camera URL";
            return;
        }

        Text = "Connecting...";
        btStart.Enabled = false;

        var started = false;
        try
        {
            // Reads the stream info: the codecs are whatever the camera sends
            var rtsp = await RTSPRAWSourceSettings.CreateAsync(url, edLogin.Text, edPassword.Text, audioEnabled: true);

            // Over TCP the file keeps the camera's own frame timing
            rtsp.AllowedProtocols = RTSPSourceProtocol.TCP;

            failed = false;
            pipeline = new MediaBlocksPipeline();
            pipeline.OnError += (_, args) => BeginInvoke(() =>
            {
                failed = true;
                Text = args.Message;
            });

            var source = new RTSPRAWSourceBlock(rtsp);

            outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), $"camera_{DateTime.Now:yyyyMMdd_HHmmss}.mp4");
            var mp4 = new MP4SinkBlock(new MP4SinkSettings(outputFile));

            // The video goes into the file as the camera sent it: no decoder, no encoder
            pipeline.Connect(source.VideoOutput, mp4.CreateNewInput(MediaBlockPadMediaType.Video));

            var audio = rtsp.GetInfo()?.AudioStreams.FirstOrDefault();
            if (audio != null)
            {
                var audioInput = mp4.CreateNewInput(MediaBlockPadMediaType.Audio);
                // The RTP name of the codec: MPEG4-GENERIC and MP4A-LATM carry AAC
                var codec = audio.Codec?.ToUpperInvariant() ?? string.Empty;
                if (codec is "MPEG4-GENERIC" or "MP4A-LATM")
                {
                    // AAC fits MP4 as it is
                    pipeline.Connect(source.AudioOutput, audioInput);
                }
                else
                {
                    // G.711 or any other codec: only the sound is encoded, to AAC
                    var decoder = new DecodeBinBlock(renderVideo: false, renderAudio: true, renderSubtitle: false);
                    var aac = new AACEncoderBlock();
                    pipeline.Connect(source.AudioOutput, decoder.Input);
                    pipeline.Connect(decoder.AudioOutput, aac.Input);
                    pipeline.Connect(aac.Output, audioInput);
                }
            }

            started = await pipeline.StartAsync();
        }
        catch (Exception ex)
        {
            Text = ex.Message;
        }

        // An SDK error posted during the start stays in the title
        if (Text == "Connecting...") Text = started ? "Recording..." : "The recording did not start";

        if (started)
        {
            clock.Restart();
            lastClockTime = TimeSpan.Zero;
            using var app = Process.GetCurrentProcess();
            lastCpuTime = app.TotalProcessorTime;
            timer1.Start();
        }
        else if (pipeline != null)
        {
            await pipeline.DisposeAsync();
            pipeline = null;
        }

        btStop.Enabled = started;
        btStart.Enabled = !started;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        // The app's CPU time since the last tick, as a share of all cores, like Task Manager
        using var app = Process.GetCurrentProcess();
        var cpuTime = app.TotalProcessorTime;
        var elapsed = clock.Elapsed;
        var cpu = (cpuTime - lastCpuTime).TotalMilliseconds / (elapsed - lastClockTime).TotalMilliseconds / Environment.ProcessorCount * 100;
        lastCpuTime = cpuTime;
        lastClockTime = elapsed;

        var size = File.Exists(outputFile) ? new FileInfo(outputFile).Length / 1048576.0 : 0;
        lbStatus.Text = $"{(int)elapsed.TotalHours:00}:{elapsed:mm\\:ss}   {size:0.0} MB   CPU {cpu:0.0}%";
    }

    private async void btStop_Click(object sender, EventArgs e)
    {
        await StopAsync();
    }

    private async Task StopAsync()
    {
        btStop.Enabled = false;
        timer1.Stop();

        // Writes the MP4 index: the file is complete and plays everywhere
        var stopped = await pipeline.StopAsync();
        await pipeline.DisposeAsync();
        pipeline = null;

        // An error posted while recording stays in the title, next to the file
        if (failed) Text = $"{Text} | {outputFile}";
        else Text = (stopped ? "Saved: " : "Not finished: ") + outputFile;
        btStart.Enabled = true;
    }

    private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!btStart.Enabled && !btStop.Enabled)
        {
            e.Cancel = true; // loading, starting or stopping: wait for it
            return;
        }

        if (btStop.Enabled)
        {
            e.Cancel = true; // recording: finish the MP4 first
            await StopAsync();
            BeginInvoke(Close);
            return;
        }

        VisioForgeX.DestroySDK();
    }
}
