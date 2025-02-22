using System.Diagnostics;
using System.Globalization;
using System.Timers;
using ObjCRuntime;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.UI.Apple;
using Timer = System.Timers.Timer;

namespace ScreenCaptureMB;

public partial class ViewController : NSViewController
{
    /// <summary>
    ///     The position timer.
    /// </summary>
    private readonly Timer _tmPosition = new(500);

    private H264EncoderBlock _h264Encoder;

    private MP4SinkBlock _mp4Sink;

    private MediaBlocksPipeline _pipeline;

    private MediaBlock _source;

    private MediaBlock _videoRenderer;

    private TeeBlock _videoTee;

    private VideoResizeBlock _videoResize;

    private VideoView _videoView;

    protected ViewController(NativeHandle handle) : base(handle)
    {
        // This constructor is required if the view controller is loaded from a xib or a storyboard.
        // Do not put any initialization here, use ViewDidLoad instead.
    }

    public override NSObject RepresentedObject
    {
        get => base.RepresentedObject;
        set => base.RepresentedObject = value;
        // Update the view, if already loaded.
    }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        // Do any additional setup after loading the view.
        InvokeOnMainThread(() =>
        {
            //View.Window.Delegate = new CustomWindowDelegate();
        });

        _tmPosition.Elapsed += tmPosition_Elapsed;

        ScreenSourceBlock.AskPermissions();

        VisioForgeX.InitSDK();
    }

    private string GenerateFilename()
    {
        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            $"capture_{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.mp4");
    }

    private async Task CreateEngineAsync()
    {
        if (_pipeline != null)
        {
            await _pipeline.StopAsync();
            await _pipeline.DisposeAsync();
        }

        _pipeline = new MediaBlocksPipeline();

        _videoView = new VideoView(new CGRect(0, 0, pnVideoViewX.Bounds.Width, pnVideoViewX.Bounds.Height));
        pnVideoViewX.AddSubview(_videoView);

        _pipeline.OnError += _pipeline_OnError;

        _source = new ScreenSourceBlock();

        _videoRenderer = new VideoRendererBlock(_pipeline, _videoView);

        _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

        _videoResize = new VideoResizeBlock(1920, 1080);

        var filename = GenerateFilename();

        _mp4Sink = new MP4SinkBlock(new MP4SinkSettings(filename));
        _h264Encoder = new H264EncoderBlock();

        _videoRenderer = new VideoRendererBlock(_pipeline, _videoView);

        _pipeline.Connect(_source.Output, _videoResize.Input);
        _pipeline.Connect(_videoResize.Output, _videoTee.Input);

        _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
        _pipeline.Connect(_videoTee.Outputs[1], _h264Encoder.Input);

        _pipeline.Connect(_h264Encoder.Output, _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Video));
    }

    private async void OnStop(object sender, EventArgs e)
    {
        if (_pipeline != null)
        {
            _pipeline.OnError -= _pipeline_OnError;
            await _pipeline.StopAsync();
        }
    }

    private void _pipeline_OnError(object sender, ErrorsEventArgs e)
    {
        Debug.WriteLine(e.Message);
    }

    private async Task StopAllAsync()
    {
        if (_pipeline == null) return;

        _tmPosition.Stop();

        if (_pipeline != null) await _pipeline.StopAsync();
    }

    /// <summary>
    ///     Handles the Elapsed event of the tmPosition control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs" /> instance containing the event data.</param>
    private async void tmPosition_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (_pipeline == null) return;

        try
        {
            InvokeOnMainThread(async () =>
            {
                if (_pipeline == null) return;

                lbDurationX.StringValue =
                    $"{(await _pipeline.Position_GetAsync()).ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";
            });
        }
        catch (Exception exception)
        {
            Debug.WriteLine(exception);
        }
    }

    partial void btStartClickX(NSObject sender)
    {
        InvokeOnMainThread(async () =>
        {
            await CreateEngineAsync();

            await _pipeline.StartAsync();

            _tmPosition.Start();
        });
    }

    partial void btStopClickX(NSObject sender)
    {
        InvokeOnMainThread(async () => { await StopAllAsync(); });
    }
}

// Custom Window delegate to close the SDK
public class CustomWindowDelegate : NSWindowDelegate
{
    public override bool WindowShouldClose(NSObject sender)
    {
        VisioForgeX.DestroySDK();

        // Return true to allow the window to close, false to cancel.
        return true;
    }
}