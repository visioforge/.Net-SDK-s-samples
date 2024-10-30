using System.Diagnostics;
using ObjCRuntime;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.Apple;

namespace SimpleMediaPlayerMBMac;

public partial class ViewController : NSViewController
{
    private MediaPlayerCoreX _player;

    private Timer _timer;

    private bool _timerFlag;

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
        if (_player == null) return;

        _timerFlag = true;

        var position = await _player.Position_GetAsync();
        var duration = await _player.DurationAsync();

        InvokeOnMainThread(() =>
        {
            slPosition.MaxValue = duration.TotalSeconds;

            // lbTimeX.StringValue = position.ToString("hh\\:mm\\:ss") + " | " + duration.ToString("hh\\:mm\\:ss");

            if (slPosition.MaxValue >= position.TotalSeconds)
            {
                slPosition.DoubleValue = position.TotalSeconds;
            }
        });

        _timerFlag = false;
    }

    private void ShowMessage(string text)
    {
        var alert = new NSAlert
        {
            AlertStyle = NSAlertStyle.Informational,
            InformativeText = text,
            MessageText = "Message"
        };
        alert.RunModal();
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

        _player = new MediaPlayerCoreX(_videoView);
        await _player.OpenAsync(sourceSettings);

        await _player.PlayAsync();

        _timer.Change(0, 1000);
    }

    private async Task StopAsync()
    {
        _timer.Change(0, Timeout.Infinite);

        if (_player == null) return;

        await _player.StopAsync();
        await _player.DisposeAsync();

        _player = null;
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
            if (!_timerFlag && _player != null)
            {
                await _player.Position_SetAsync(TimeSpan.FromSeconds(value));
            }
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