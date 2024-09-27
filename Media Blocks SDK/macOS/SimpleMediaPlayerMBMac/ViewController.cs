using System.Diagnostics;
using ObjCRuntime;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.Apple;

namespace SimpleMediaPlayerMBMac;

public partial class ViewController : NSViewController
{
    private AudioRendererBlock _audioRenderer;
    private MediaBlocksPipeline _pipeline;

    private UniversalSourceBlock _source;

    private Timer _timer;

    private bool _timerFlag;

    private VideoRendererBlock _videoRenderer;

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

        _videoView = new VideoView(new CGRect(0, 0, videoViewHost.Bounds.Width, videoViewHost.Bounds.Height));
        videoViewHost.AddSubview(_videoView);

        VisioForgeX.InitSDK();

        edFilename.StringValue = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "video.mp4");

        _timer = new Timer(OnTimer);
    }

    public async void OnTimer(object stateInfo)
    {
        if (_pipeline == null) return;

        _timerFlag = true;

        var position = await _pipeline.Position_GetAsync();
        var duration = await _pipeline.DurationAsync();

        InvokeOnMainThread(() =>
        {
            slPosition.MaxValue = duration.TotalSeconds;

            // lbTimeX.StringValue = position.ToString("hh\\:mm\\:ss") + " | " + duration.ToString("hh\\:mm\\:ss");

            if (slPosition.MaxValue >= position.TotalSeconds) slPosition.DoubleValue = position.TotalSeconds;
        });

        _timerFlag = false;
    }

    private void ShowMessage(string text)
    {
        InvokeOnMainThread(async () =>
        {
            var alert = new NSAlert
            {
                AlertStyle = NSAlertStyle.Informational,
                InformativeText = text,
                MessageText = "Message"
            };
            alert.RunModal();
        });
    }

    private async Task StartAsync()
    {
        if (View.Window.Delegate == null)
        {
            View.Window.Delegate = new CustomWindowDelegate();
        }

        if (!File.Exists(edFilename.StringValue))
        {
            Debug.WriteLine("Input file is not found!");
            return;
        }

        var sourceSettings = await UniversalSourceSettings.CreateAsync(edFilename.StringValue);
        if (sourceSettings == null)
        {
            Debug.WriteLine("Unable to create source!");
            return;
        }

        _pipeline = new MediaBlocksPipeline();

        _source = new UniversalSourceBlock(sourceSettings);

        if (sourceSettings.RenderVideo)
        {
            _videoRenderer = new VideoRendererBlock(_pipeline, _videoView);
            _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);
        }

        if (sourceSettings.RenderAudio)
        {
            _audioRenderer = new AudioRendererBlock();
            _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
        }

        await _pipeline.StartAsync();

        _timer.Change(0, 1000);
    }

    private async Task StopAsync()
    {
        _timer.Change(0, Timeout.Infinite);

        if (_pipeline == null) return;

        await _pipeline.StopAsync();
        await _pipeline.DisposeAsync();

        _pipeline = null;
    }

    partial void btStart_Click(NSObject sender)
    {
        InvokeOnMainThread(async () => { await StartAsync(); });
    }

    partial void btStop_Click(NSObject sender)
    {
        InvokeOnMainThread(async () => { await StopAsync(); });
    }

    partial void btOpen_Click(NSObject sender)
    {
        var dlg = NSOpenPanel.OpenPanel;
        dlg.CanChooseFiles = true;
        dlg.CanChooseDirectories = false;
        dlg.AllowedFileTypes = new[] { "mp4", "mov", "webm", "mkv", "mp3", "m4a", "ogg", "wav" };

        if (dlg.RunModal() == 1)
        {
            // Nab the first file
            var url = dlg.Urls[0].Path;

            if (url != null) edFilename.StringValue = url;
        }
    }

    partial void slPositionChanged(NSObject sender)
    {
        var value = (sender as NSSlider).FloatValue;

        InvokeOnMainThread(async () =>
        {
            if (!_timerFlag && _pipeline != null) await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(value));
        });
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