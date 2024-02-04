using System.Diagnostics;
using AVFoundation;
using ObjCRuntime;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.Apple;

namespace SimpleVideoCaptureMBMac;

public partial class ViewController : NSViewController {

    private MediaBlocksPipeline _pipeline;

    private VideoViewGL _videoView;

    private VideoRendererBlock _videoRenderer;

    private AudioRendererBlock _audioRenderer;

    private SystemVideoSourceBlock _videoSource;

    private SystemAudioSourceBlock _audioSource;

    private Timer _timer;

    private bool _timerFlag = false;

    protected ViewController (NativeHandle handle) : base (handle)
	{
		// This constructor is required if the view controller is loaded from a xib or a storyboard.
		// Do not put any initialization here, use ViewDidLoad instead.
	}

	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();

        // Do any additional setup after loading the view.
        //_videoView = new VideoViewGL(new CGRect(0, 0, videoViewHost.Bounds.Width, videoViewHost.Bounds.Height));
        //this.videoViewHost.AddSubview(_videoView);

        AVCaptureDevice.RequestAccessForMediaType(AVAuthorizationMediaType.Video, (bool granted) => {
            // Handle the response here. 'granted' is true if permission is given.
            Debug.WriteLine($"Camera access: {granted}");
        });

        //_deviceEnumerator = new DeviceEnumerator();

        //InvokeOnMainThread((Action)(async () =>
        //{
        //    await LoadDevicesAsync();
        //}));

        //_timer = new Timer(OnTimer);
    }

    private async Task LoadDevicesAsync()
    {
        // video sources
        var videoSources = await DeviceEnumerator.Shared.VideoSourcesAsync();
        cbVideoSource.RemoveAll();

        foreach (var item in videoSources)
        {
            cbVideoSource.Add(new NSString(item.DisplayName));
        }

        if (videoSources.Length > 0)
        {
            cbVideoSource.Select(new NSString(videoSources[0].DisplayName));
        }

        cbVideoSource.SelectionChanged += cbVideoSource_SelectionChanged;
        cbVideoFormat.SelectionChanged += cbVideoFormat_SelectionChanged;

        cbVideoSource_SelectionChanged(cbVideoSource, EventArgs.Empty);

        // audio sources
        var audioSources = await DeviceEnumerator.Shared.AudioSourcesAsync();
        cbAudioSource.RemoveAll();

        foreach (var item in audioSources)
        {
            cbAudioSource.Add(new NSString(item.DisplayName));
        }

        if (audioSources.Length > 0)
        {
            cbAudioSource.Select(new NSString(audioSources[0].DisplayName));
        }

        cbAudioSource.SelectionChanged += cbAudioSource_SelectionChanged;

        cbAudioSource_SelectionChanged(cbAudioSource, EventArgs.Empty);

        // audio outputs
        var audioOutputs = await DeviceEnumerator.Shared.AudioOutputsAsync();
        cbAudioOutput.RemoveAll();

        foreach (var item in audioOutputs)
        {
            cbAudioOutput.Add(new NSString(item.DisplayName));
        }

        if (audioOutputs.Length > 0)
        {
            cbAudioOutput.Select(new NSString(audioOutputs[0].DisplayName));
        }
    }

    private async void cbVideoFormat_SelectionChanged(object sender, EventArgs e)
    {
        cbVideoFrameRate.RemoveAll();

        if (cbVideoSource.SelectedIndex != -1 && e != null)
        {
            var deviceName = cbVideoSource.SelectedValue.ToString();
            var format = cbVideoFormat.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
            {
                var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                    if (formatItem != null)
                    {
                        // build int range from tuple (min, max)    
                        var frameRateList = formatItem.GetFrameRateRangeAsStringList();
                        foreach (var item in frameRateList)
                        {
                            cbVideoFrameRate.Add(new NSString(item));
                        }

                        if (frameRateList.Length > 0)
                        {
                            cbVideoFrameRate.Select(new NSString(frameRateList[0]));
                        }
                    }
                }
            }
        }
    }

    private async void cbAudioSource_SelectionChanged(object sender, EventArgs e)
    {
        if (cbAudioSource.SelectedIndex != -1 && e != null)
        {
            var deviceName = cbAudioSource.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(deviceName))
            {
                cbAudioFormat.RemoveAll();

                var device = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    foreach (var format in device.Formats)
                    {
                        cbAudioFormat.Add(new NSString(format.Name));
                    }

                    if (device.Formats.Count > 0)
                    {
                        cbAudioFormat.Select(new NSString(device.Formats[0].Name));
                    }
                }
            }
        }
    }

    private async void cbVideoSource_SelectionChanged(object sender, EventArgs e)
    {
        if (cbVideoSource.SelectedIndex != -1)
        {
            var deviceName = cbVideoSource.SelectedValue.ToString();

            if (!string.IsNullOrEmpty(deviceName))
            {
                cbVideoFormat.RemoveAll();

                var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    foreach (var item in device.VideoFormats)
                    {
                        cbVideoFormat.Add(new NSString(item.Name));
                    }

                    if (device.VideoFormats.Count > 0)
                    {
                        cbVideoFormat.Select(new NSString(device.VideoFormats[0].Name));
                    }
                }
            }
        }
    }

    public async void OnTimer(Object stateInfo)
    {
        if (_pipeline == null)
        {
            return;
        }

        _timerFlag = true;

        var position = await _pipeline.Position_GetAsync();
        var duration = await _pipeline.DurationAsync();

        InvokeOnMainThread((Action)(() =>
        {
           // slPosition.MaxValue = duration.TotalSeconds;

            // lbTimeX.StringValue = position.ToString("hh\\:mm\\:ss") + " | " + duration.ToString("hh\\:mm\\:ss");

            //if (slPosition.MaxValue >= position.TotalSeconds)
            //{
            //    slPosition.DoubleValue = position.TotalSeconds;
            //}
        }));

        _timerFlag = false;
    }

    public override NSObject RepresentedObject {
		get => base.RepresentedObject;
		set {
			base.RepresentedObject = value;

			// Update the view, if already loaded.
		}
	}

    private async Task StartAsync()
    {
        _pipeline = new MediaBlocksPipeline(true);

        _videoView = new VideoViewGL(new CGRect(0, 0, videoViewHost.Bounds.Width, videoViewHost.Bounds.Height));
        this.videoViewHost.AddSubview(_videoView);

        bool capture = false; // cbOutputFormat.SelectedIndex > 0;

        //mmLog.Clear();

        //if (cbVideoInput.SelectedIndex < 0)
        //{
        //    MessageBox.Show(this, "Select video input device");
        //    return;
        //}

        // video source
        VideoCaptureDeviceSourceSettings videoSourceSettings = null;

        var deviceName = cbVideoSource.StringValue;
        var format = cbVideoFormat.StringValue;
        if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
        {
            var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
            if (device != null)
            {
                var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                if (formatItem != null)
                {
                    videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                    {
                        Format = formatItem.ToFormat()
                    };

                    videoSourceSettings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.StringValue));
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
            var device = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
            if (device != null)
            {
                var formatItem = device.Formats.FirstOrDefault(x => x.Name == format);
                if (formatItem != null)
                {
                    audioSourceSettings = device.CreateSourceSettings(formatItem.ToFormat());
                }
            }
        }

        _audioSource = new SystemAudioSourceBlock(audioSourceSettings);

        // video renderer
        _videoRenderer = new VideoRendererBlock(_pipeline, _videoView);

        // audio renderer
        _audioRenderer = new AudioRendererBlock((await DeviceEnumerator.Shared.AudioOutputsAsync()).Where(device => device.DisplayName == cbAudioOutput.StringValue).First());

        // capture
        if (capture)
        {
            //_videoTee = new TeeBlock(2);
            //_audioTee = new TeeBlock(2);
            //_h264Encoder = new H264EncoderBlock(new MFH264EncoderSettings());
            //_aacEncoder = new AACEncoderBlock(new MFAACEncoderSettings());
            //_mp4Muxer = new MP4SinkBlock(new MP4SinkSettings(edFilename.Text));
        }

        // connect all
        if (capture)
        {
            //_pipeline.Connect(_videoSource.Output, _videoTee.Input);
            //_pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
            //_pipeline.Connect(_videoTee.Outputs[1], _h264Encoder.Input);
            //_pipeline.Connect(_h264Encoder.Output, _mp4Muxer.CreateNewInput(MediaBlockPadMediaType.Video));

            //_pipeline.Connect(_audioSource.Output, _audioTee.Input);
            //_pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);
            //_pipeline.Connect(_audioTee.Outputs[1], _aacEncoder.Input);
            //_pipeline.Connect(_aacEncoder.Output, _mp4Muxer.CreateNewInput(MediaBlockPadMediaType.Audio));
        }
        else
        {
            _pipeline.Connect(_audioSource.Output, _audioRenderer.Input);
            _pipeline.Connect(_videoSource.Output, _videoRenderer.Input);
        }

        // start
        await _pipeline.StartAsync();

        _timer.Change(0, 1000);
    }

    private async Task StopAsync()
    {
        _timer.Change(0, Timeout.Infinite);

        if (_pipeline == null)
        {
            return;
        }

        await _pipeline.StopAsync();
        await _pipeline.DisposeAsync();

        _pipeline = null;
    }

    partial void btStartClick(Foundation.NSObject sender)
	{
        InvokeOnMainThread(async () => {
            await StartAsync();
        });
    }

    partial void btStopClick(Foundation.NSObject sender)
	{
        InvokeOnMainThread(async () => {
            await StopAsync();
        });
    }
}

