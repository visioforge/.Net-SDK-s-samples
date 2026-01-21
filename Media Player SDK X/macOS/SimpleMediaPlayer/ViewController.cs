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

/// <summary>
/// The view controller.
/// </summary>
public partial class ViewController : NSViewController
{
    /// <summary>
    /// The media player instance.
    /// </summary>
    private MediaPlayerCoreX _player;

    /// <summary>
    /// The timer.
    /// </summary>
    private Timer _timer;

    /// <summary>
    /// Flag to indicate if the timer is update.
    /// </summary>
    private bool _timerFlag;

    /// <summary>
    /// The video view.
    /// </summary>
    private VideoView _videoView;

    /// <summary>
    /// Initializes a new instance of the <see cref="ViewController"/> class.
    /// </summary>
    /// <param name="handle">The handle.</param>
    protected ViewController(NativeHandle handle) : base(handle)
    {
        // This constructor is required if the view controller is loaded from a xib or a storyboard.
        // Do not put any initialization here, use ViewDidLoad instead.
    }

    /// <summary>
    /// Gets or sets the represented object.
    /// </summary>
    public override NSObject RepresentedObject
    {
        get => base.RepresentedObject;
        set => base.RepresentedObject = value;
        // Update the view, if already loaded.
    }

        /// <summary>
        /// View did load.
        /// </summary>
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        _videoView = new VideoView(new CGRect(0, 0, videoViewHost.Bounds.Width, videoViewHost.Bounds.Height));
        videoViewHost.AddSubview(_videoView);

        VisioForgeX.InitSDK();

        edFilename.StringValue = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "video.mp4");

        _timer = new Timer(OnTimer);
    }

        /// <summary>
        /// On timer.
        /// </summary>
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

        /// <summary>
        /// Show message.
        /// </summary>
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

        /// <summary>
        /// Start async.
        /// </summary>
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

        /// <summary>
        /// Stop async.
        /// </summary>
    private async Task StopAsync()
    {
        _timer.Change(0, Timeout.Infinite);

        if (_player == null) return;

        await _player.StopAsync();
        await _player.DisposeAsync();

        _player = null;
    }

    /// <summary>
    /// Bt start click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    partial void btStart_Click(NSObject sender)
    {
        InvokeOnMainThread(async () => { await StartAsync(); });
    }

    /// <summary>
    /// Bt stop click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    partial void btStop_Click(NSObject sender)
    {
        InvokeOnMainThread(async () => { await StopAsync(); });
    }

    /// <summary>
    /// Bt open click.
    /// </summary>
    /// <param name="sender">The sender.</param>
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

    /// <summary>
    /// Sl position changed.
    /// </summary>
    /// <param name="sender">The sender.</param>
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

/// <summary>
/// Custom Window delegate to close the SDK.
/// </summary>
public class CustomWindowDelegate : NSWindowDelegate
{
        /// <summary>
        /// Window should close.
        /// </summary>
    public override bool WindowShouldClose(NSObject sender)
    {
        VisioForgeX.DestroySDK();

        // Return true to allow the window to close, false to cancel.
        return true;
    }
}