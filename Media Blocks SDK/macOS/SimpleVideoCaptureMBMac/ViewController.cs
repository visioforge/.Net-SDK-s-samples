using System.Diagnostics;
using AVFoundation;
using ObjCRuntime;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.Apple;

namespace SimpleVideoCaptureMB;

/// <summary>
/// The view controller.
/// </summary>
public partial class ViewController : NSViewController
{
    /// <summary>
    /// The audio renderer.
    /// </summary>
    private AudioRendererBlock _audioRenderer;

    /// <summary>
    /// The audio source.
    /// </summary>
    private SystemAudioSourceBlock _audioSource;

    /// <summary>
    /// The pipeline.
    /// </summary>
    private MediaBlocksPipeline _pipeline;

    /// <summary>
    /// The video renderer.
    /// </summary>
    private VideoRendererBlock _videoRenderer;

    /// <summary>
    /// The video source.
    /// </summary>
    private MediaBlock _videoSource;

    /// <summary>
    /// The video view.
    /// </summary>
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

        /// <summary>
        /// View did load.
        /// </summary>
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        // Do any additional setup after loading the view.
        AVCaptureDevice.RequestAccessForMediaType(AVAuthorizationMediaType.Video, granted =>
        {
            // Handle the response here. 'granted' is true if permission is given.
            Debug.WriteLine($"Camera access: {granted}");
        });

        InvokeOnMainThread(async () =>
        {
            await LoadDevicesAsync();

            View.Window.Delegate = new CustomWindowDelegate();

            _videoView = new VideoView(new CGRect(0, 0, videoViewHost.Bounds.Width, videoViewHost.Bounds.Height));
            videoViewHost.AddSubview(_videoView);
        });
    }

        /// <summary>
        /// Show message.
        /// </summary>
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

        /// <summary>
        /// Load devices async.
        /// </summary>
    private async Task LoadDevicesAsync()
    {
        // video sources
        var videoSources = await DeviceEnumerator.Shared.VideoSourcesAsync();
        cbVideoSource.RemoveAll();

        foreach (var item in videoSources) cbVideoSource.Add(new NSString(item.DisplayName));

        if (videoSources.Length > 0) cbVideoSource.Select(new NSString(videoSources[0].DisplayName));

        cbVideoSource.SelectionChanged += cbVideoSource_SelectionChanged;
        cbVideoFormat.SelectionChanged += cbVideoFormat_SelectionChanged;

        cbVideoSource_SelectionChanged(cbVideoSource, EventArgs.Empty);

        // audio sources
        var audioSources = await DeviceEnumerator.Shared.AudioSourcesAsync();
        cbAudioSource.RemoveAll();

        foreach (var item in audioSources) cbAudioSource.Add(new NSString(item.DisplayName));

        if (audioSources.Length > 0) cbAudioSource.Select(new NSString(audioSources[0].DisplayName));

        cbAudioSource.SelectionChanged += cbAudioSource_SelectionChanged;

        cbAudioSource_SelectionChanged(cbAudioSource, EventArgs.Empty);

        // audio outputs
        var audioOutputs = await DeviceEnumerator.Shared.AudioOutputsAsync();
        cbAudioOutput.RemoveAll();

        foreach (var item in audioOutputs) cbAudioOutput.Add(new NSString(item.DisplayName));

        if (audioOutputs.Length > 0) cbAudioOutput.Select(new NSString(audioOutputs[0].DisplayName));
    }

        /// <summary>
        /// Handles the cb video format selection changed event.
        /// </summary>
    private async void cbVideoFormat_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            cbVideoFrameRate.RemoveAll();

            if (cbVideoSource.SelectedIndex != -1 && e != null)
            {
                var deviceName = cbVideoSource.SelectedValue.ToString();
                var format = cbVideoFormat.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device =
                        (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x =>
                            x.DisplayName == deviceName);
                    if (device != null)
                    {
                        var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                        if (formatItem != null)
                        {
                            // build int range from tuple (min, max)    
                            var frameRateList = formatItem.GetFrameRateRangeAsStringList();
                            foreach (var item in frameRateList) cbVideoFrameRate.Add(new NSString(item));

                            if (frameRateList.Length > 0) cbVideoFrameRate.Select(new NSString(frameRateList[0]));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

        /// <summary>
        /// Handles the cb audio source selection changed event.
        /// </summary>
    private async void cbAudioSource_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            if (cbAudioSource.SelectedIndex != -1 && e != null)
            {
                var deviceName = cbAudioSource.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(deviceName))
                {
                    cbAudioFormat.RemoveAll();

                    var device =
                        (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x =>
                            x.DisplayName == deviceName);
                    if (device != null)
                    {
                        foreach (var format in device.Formats) cbAudioFormat.Add(new NSString(format.Name));

                        if (device.Formats.Count > 0) cbAudioFormat.Select(new NSString(device.Formats[0].Name));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

        /// <summary>
        /// Handles the cb video source selection changed event.
        /// </summary>
    private async void cbVideoSource_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            if (cbVideoSource.SelectedIndex != -1)
            {
                var deviceName = cbVideoSource.SelectedValue.ToString();

                if (!string.IsNullOrEmpty(deviceName))
                {
                    cbVideoFormat.RemoveAll();

                    var device =
                        (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x =>
                            x.DisplayName == deviceName);
                    if (device != null)
                    {
                        foreach (var item in device.VideoFormats) cbVideoFormat.Add(new NSString(item.Name));

                        if (device.VideoFormats.Count > 0) cbVideoFormat.Select(new NSString(device.VideoFormats[0].Name));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

        /// <summary>
        /// Start async.
        /// </summary>
    private async Task StartAsync()
    {
        // Do any additional setup after loading the view.
        AVCaptureDevice.RequestAccessForMediaType(AVAuthorizationMediaType.Video, granted =>
        {
            if (!granted)
            {
                ShowMessage("Please allow camera access.");
            }
        });

        _pipeline = new MediaBlocksPipeline();

        // video source
        VideoCaptureDeviceSourceSettings videoSourceSettings = null;

        var deviceName = cbVideoSource.StringValue;
        var format = cbVideoFormat.StringValue;
        if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
        {
            var device =
                (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
            if (device != null)
            {
                var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                if (formatItem != null)
                {
                    videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                    {
                        Format = formatItem.ToFormat()
                    };

                    videoSourceSettings.Format.FrameRate =
                        new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.StringValue));
                }
            }
        }

        _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

        // audio source
        IAudioCaptureDeviceSourceSettings audioSourceSettings = null;

        deviceName = cbAudioSource.StringValue;
        format = cbAudioFormat.StringValue;
        if (!string.IsNullOrEmpty(deviceName))
        {
            var device =
                (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
            if (device != null)
            {
                var formatItem = device.Formats.FirstOrDefault(x => x.Name == format);
                if (formatItem != null) audioSourceSettings = device.CreateSourceSettings(formatItem.ToFormat());
            }
        }

        _audioSource = new SystemAudioSourceBlock(audioSourceSettings);

        // video renderer
        _videoRenderer = new VideoRendererBlock(_pipeline, _videoView as IVideoView) { IsSync = false };

        // audio renderer
        _audioRenderer = new AudioRendererBlock((await DeviceEnumerator.Shared.AudioOutputsAsync())
                .Where(device => device.DisplayName == cbAudioOutput.StringValue).First())
            { IsSync = false };

        // connect all
        _pipeline.Connect(_audioSource.Output, _audioRenderer.Input);
        _pipeline.Connect(_videoSource.Output, _videoRenderer.Input);

        // start
        await _pipeline.StartAsync();
    }

        /// <summary>
        /// Stop async.
        /// </summary>
    private async Task StopAsync()
    {
        if (_pipeline == null) return;

        await _pipeline.StopAsync();
        await _pipeline.DisposeAsync();

        _pipeline = null;
    }

    /// <summary>
    /// Handles the Click event of the btStart button.
    /// </summary>
    partial void btStartClick(NSObject sender)
    {
        InvokeOnMainThread(async () => { await StartAsync(); });
    }

    /// <summary>
    /// Handles the Click event of the btStop button.
    /// </summary>
    partial void btStopClick(NSObject sender)
    {
        InvokeOnMainThread(async () => { await StopAsync(); });
    }
}

/// <summary>
/// Custom Window delegate to close the SDK
/// </summary>
public class CustomWindowDelegate : NSWindowDelegate
{
        /// <summary>
        /// Window should close.
        /// </summary>
    public override bool WindowShouldClose(NSObject sender)
    {
        if (_pipeline != null)
        {
            _pipeline.StopAsync().GetAwaiter().GetResult();
            _pipeline.DisposeAsync().GetAwaiter().GetResult();
            _pipeline = null;
        }

        VisioForgeX.DestroySDK();

        // Return true to allow the window to close, false to cancel.
        return true;
    }
}