using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.Avalonia;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Special;

using System.Threading;
using System.Linq;

#if __IOS__ && !__MACCATALYST__
using UIKit;
#endif

using VisioForge.Core.Helpers;


#if __ANDROID__
using Android.Content;
using Android.Database;
using Android.Provider;
#endif

namespace SimpleVideoCaptureMVVM.ViewModels
{
    /// <summary>
    /// Video Capture View Model.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The instance.
        /// </summary>
        public static MainViewModel Instance;

        /// <summary>
        /// Indicates whether the platform is mobile (Android or iOS).
        /// </summary>
        private readonly bool IsMobile = OperatingSystem.IsAndroid() || OperatingSystem.IsIOS();

        public ReactiveCommand<Unit, Unit> VolumeValueChangedCommand { get; }

        public IVideoView VideoViewIntf { get; set; }

        public TopLevel TopLevel { get; set; }

        /// <summary>
        /// The duration text.
        /// </summary>
        private string? _Duration = "00:00:00";

        public string? Duration
        {
            get => _Duration;
            set => this.RaiseAndSetIfChanged(ref _Duration, value);
        }

        /// <summary>
        /// The volume text.
        /// </summary>
        private string? _Volume;

        public string? Volume
        {
            get => _Volume;
            set => this.RaiseAndSetIfChanged(ref _Volume, value);
        }

        /// <summary>
        /// The volume value.
        /// </summary>
        private double _VolumeValue = 80;

        public double VolumeValue
        {
            get => _VolumeValue;
            set => this.RaiseAndSetIfChanged(ref _VolumeValue, value);
        }

        public ICommand SwitchCameraCommand { get; }

        public ICommand RecordCommand { get; }

        /// <summary>
        /// The record button text.
        /// </summary>
        private string? _RecordText = "START RECORD";

        public string? RecordText
        {
            get => _RecordText;
            set => this.RaiseAndSetIfChanged(ref _RecordText, value);
        }

        /// <summary>
        /// Indicates whether the record button is enabled.
        /// </summary>
        private bool _RecordEnabled = true;

        public bool RecordEnabled
        {
            get => _RecordEnabled;
            set => this.RaiseAndSetIfChanged(ref _RecordEnabled, value);
        }

        public ICommand PreviewCommand { get; }

        /// <summary>
        /// The preview button text.
        /// </summary>
        private string? _PreviewText = "START PREVIEW";

        public string? PreviewText
        {
            get => _PreviewText;
            set => this.RaiseAndSetIfChanged(ref _PreviewText, value);
        }

        /// <summary>
        /// Indicates whether the preview button is enabled.
        /// </summary>
        private bool _PreviewEnabled = true;

        public bool PreviewEnabled
        {
            get => _PreviewEnabled;
            set => this.RaiseAndSetIfChanged(ref _PreviewEnabled, value);
        }

        public ObservableCollection<string> VideoInputDevices { get; } = new ObservableCollection<string>();

        public ObservableCollection<string> AudioInputDevices { get; } = new ObservableCollection<string>();

        public ObservableCollection<string> AudioOutputDevices { get; } = new ObservableCollection<string>();

        /// <summary>
        /// The selected video input device.
        /// </summary>
        private string _videoInputDevice;

        public string VideoInputDevice
        {
            get => _videoInputDevice;
            set => this.RaiseAndSetIfChanged(ref _videoInputDevice, value);
        }

        /// <summary>
        /// The selected audio input device.
        /// </summary>
        private string _audioInputDevice;

        public string AudioInputDevice
        {
            get => _audioInputDevice;
            set => this.RaiseAndSetIfChanged(ref _audioInputDevice, value);
        }

        /// <summary>
        /// The selected audio output device.
        /// </summary>
        private string _audioOutputDevice;

        public string AudioOutputDevice
        {
            get => _audioOutputDevice;
            set => this.RaiseAndSetIfChanged(ref _audioOutputDevice, value);
        }

        public ReactiveCommand<Unit, Unit> WindowClosingCommand { get; }

        /// <summary>
        /// The recording timer.
        /// </summary>
        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private VideoRendererBlock _videoRenderer;

        /// <summary>
        /// The audio renderer.
        /// </summary>
        private AudioRendererBlock _audioRenderer;

        /// <summary>
        /// The video source.
        /// </summary>
        private SystemVideoSourceBlock _videoSource;

        /// <summary>
        /// The audio source.
        /// </summary>
        private MediaBlock _audioSource;

        /// <summary>
        /// The MP4 output.
        /// </summary>
        private MP4OutputBlock _mp4Output;

        /// <summary>
        /// The video tee.
        /// </summary>
        private TeeBlock _videoTee;

        /// <summary>
        /// The audio tee.
        /// </summary>
        private TeeBlock _audioTee;
        
        
#if __IOS__ && !__MACCATALYST__
        private UIInterfaceOrientation _orientation;
#endif

        public MainViewModel()
        {
            Instance = this;
            
#if __IOS__ && !__MACCATALYST__
            // get device orientation in UI thread
            UIApplication.Notifications.ObserveDidChangeStatusBarOrientation((sender, args) =>
            {
                _orientation = UIApplication.SharedApplication.StatusBarOrientation;
            });
#endif

            RecordCommand = ReactiveCommand.CreateFromTask(RecordAsync);
            PreviewCommand = ReactiveCommand.CreateFromTask(PreviewAsync);
            SwitchCameraCommand = ReactiveCommand.CreateFromTask(SwitchCameraAsync);

            VolumeValueChangedCommand = ReactiveCommand.Create(OnVolumeValueChanged);

            this.WhenAnyValue(x => x.VolumeValue).Subscribe(_ => VolumeValueChangedCommand.Execute().Subscribe());

            WindowClosingCommand = ReactiveCommand.Create(OnWindowClosing);

            tmRecording.Elapsed += async (senderx, args) => { await UpdateRecordingTimeAsync(); };

            if (!Design.IsDesignMode)
            {
                InitAndLoad();
            }
        }

        /// <summary>
        /// Init and load.
        /// </summary>
        public void InitAndLoad()
        {
#if __MACOS__
        AVFoundation.AVCaptureDevice.RequestAccessForMediaType(AVFoundation.AVAuthorizationMediaType.Video, (bool granted) => {
            Debug.WriteLine($"Camera access: {granted}");
            // Handle the response here. 'granted' is true if permission is given.
        });
#endif
            
            VisioForgeX.InitSDK();

            // run in background
            new Thread(async () =>
            {
                // video inputs
                var videoInputs = await DeviceEnumerator.Shared.VideoSourcesAsync();
                foreach (var device in videoInputs)
                {
                    VideoInputDevices.Add(device.DisplayName);
                }

                if (VideoInputDevices.Count > 0)
                {
                    VideoInputDevice = VideoInputDevices[0];
                }

                // audio inputs
                var audioInputs = await DeviceEnumerator.Shared.AudioSourcesAsync();
                foreach (var device in audioInputs)
                {
                    AudioInputDevices.Add(device.DisplayName);
                }

                if (AudioInputDevices.Count > 0)
                {
                    AudioInputDevice = AudioInputDevices[0];
                }

                // audio outputs
                var audioOutputs = await DeviceEnumerator.Shared.AudioOutputsAsync();
                foreach (var audioOutputDevice in audioOutputs)
                {
                    AudioOutputDevices.Add(audioOutputDevice.DisplayName);
                }

                if (AudioOutputDevices.Count > 0)
                {
                    AudioOutputDevice = AudioOutputDevices[0];
                }

                if (IsMobile)
                {
                    await PreviewAsync();
                }
            }).Start();
        }

        /// <summary>
        /// Create engine async.
        /// </summary>
        private async Task CreateEngineAsync(bool capture)
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
            }

#if __IOS__ && !__MACCATALYST__
            await Dispatcher.UIThread.InvokeAsync((Action)(() =>
            {
                _orientation = UIApplication.SharedApplication.StatusBarOrientation;
            }));
#endif
         
            _pipeline = new MediaBlocksPipeline();

            // video source
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            var deviceName = VideoInputDevice;
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    var formatItem = device.GetVideoFormatAndFrameRate(1920, 1080, out var framerate);
                    if (formatItem != null)
                    {
                        videoSourceSettings = new VideoCaptureDeviceSourceSettings(device, formatItem.ToFormat());
                        videoSourceSettings.Format.FrameRate = framerate;
                    }
                }
            }
            
            if (videoSourceSettings == null)
            {
                VideoViewIntf.ShowMessage("Unable to detect video source default format.");
                return;
            }

#if __IOS__ && !__MACCATALYST__
            switch (_orientation)
            {
                case UIInterfaceOrientation.Portrait:
                    videoSourceSettings.Orientation = IOSVideoSourceOrientation.Portrait;
                    break;
                case UIInterfaceOrientation.PortraitUpsideDown:
                    videoSourceSettings.Orientation = IOSVideoSourceOrientation.PortratUpsideDown;
                    break;
                case UIInterfaceOrientation.LandscapeLeft:
                    videoSourceSettings.Orientation = IOSVideoSourceOrientation.LandscapeLeft;
                    break;
                case UIInterfaceOrientation.LandscapeRight:
                    videoSourceSettings.Orientation = IOSVideoSourceOrientation.LandscapeRight;
                    break;
            }
#endif

//#if __ANDROID__
//        videoSourceSettings.Orientation = VideoCaptureOrientation.Landscape;
//#endif

            _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

            // audio source
            IAudioCaptureDeviceSourceSettings audioSourceSettings = null;

            deviceName = AudioInputDevice;
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    audioSourceSettings = device.CreateSourceSettings();
                }
            }

            _audioSource = new SystemAudioSourceBlock(audioSourceSettings);

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoViewIntf) { IsSync = false };

            // audio renderer
            _audioRenderer = new AudioRendererBlock();

            // connect blocks
            if (capture)
            {
                _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
                _pipeline.Connect(_videoSource, _videoTee);

                _mp4Output = new MP4OutputBlock(GenerateFilename());
                _pipeline.Connect(_videoTee, _mp4Output);
                _pipeline.Connect(_videoTee, _videoRenderer);

                _audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);
                _pipeline.Connect(_audioSource, _audioTee);

                _pipeline.Connect(_audioTee, _mp4Output);
                _pipeline.Connect(_audioTee, _audioRenderer);
            }
            else
            {
                _pipeline.Connect(_videoSource, _videoRenderer);
                _pipeline.Connect(_audioSource, _audioRenderer);
            }

            await _pipeline.StartAsync();
        }

        /// <summary>
        /// Generate filename.
        /// </summary>
        private string GenerateFilename()
        {
            DateTime now = DateTime.Now;
#if __ANDROID__
            var filename = Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim).AbsolutePath, "Camera", $"visioforge_{now.Hour}_{now.Minute}_{now.Second}.mp4");
#elif __IOS__ && !__MACCATALYST__
            var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..",
                "Library", $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#elif __MACCATALYST__
            var filename = Path.Combine("/tmp", $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#else
            var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#endif

            return filename;
        }

        /// <summary>
        /// On window closing.
        /// </summary>
        private void OnWindowClosing()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= _player_OnError;
                _pipeline.Stop();

                _pipeline.Dispose();
                _pipeline = null;
            }

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Record async.
        /// </summary>
        private async Task RecordAsync()
        {
            // stop the preview?
            if (_pipeline != null && _pipeline.State == PlaybackState.Play && _mp4Output == null)
            {
                await StopAllAsync();
            }

            // START
            if (_pipeline == null || _pipeline.State == PlaybackState.Free)
            {
                await StopAllAsync();

                await CreateEngineAsync(true);

                tmRecording.Start();

                RecordText = "STOP RECORD";

                PreviewEnabled = false;
            }
            else
            {
#if __IOS__ && !__MACCATALYST__ || __ANDROID__
                bool capture = _mp4Output != null;
                string filename = null;
                if (capture)
                {
                    filename = _mp4Output.GetFilenameOrURL();
                }
#endif

                await StopAllAsync();

                // save video to gallery
#if __IOS__ && !__MACCATALYST__ || __ANDROID__
                if (capture)
                {
                    await PhotoGalleryHelper.AddVideoToGalleryAsync(filename);
                }
#endif
                PreviewText = "START PREVIEW";
                RecordText = "START RECORD";

                PreviewEnabled = true;
                RecordEnabled = true;

                if (IsMobile)
                {
                    await PreviewAsync();
                }
            }
        }

        /// <summary>
        /// Switch camera async.
        /// </summary>
        private async Task SwitchCameraAsync()
        {
#if __ANDROID__
            if (VideoInputDevices.Count < 2 || _videoSource == null)
            {
                return;
            }

            var newDeviceName = VideoInputDevice == VideoInputDevices[0]
                ? VideoInputDevices[1]
                : VideoInputDevices[0];

            var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == newDeviceName);
            if (device == null)
            {
                return;
            }

            var formatItem = device.GetVideoFormatAndFrameRate(1920, 1080, out var framerate);
            if (formatItem == null)
            {
                return;
            }

            var newSettings = new VideoCaptureDeviceSourceSettings(device, formatItem.ToFormat());
            newSettings.Format.FrameRate = framerate;

            // Save recording filename before switch if recording
            bool wasRecording = _mp4Output != null;
            string filename = wasRecording ? _mp4Output.GetFilenameOrURL() : null;

            if (_videoSource.SwitchCamera(newSettings))
            {
                VideoInputDevice = newDeviceName;

                // Save to gallery if recording was in progress
                if (wasRecording && !string.IsNullOrEmpty(filename))
                {
                    await PhotoGalleryHelper.AddVideoToGalleryAsync(filename);
                }
            }
            else
            {
                // Fallback: full pipeline restart
                VideoInputDevice = newDeviceName;
                await StopAllAsync();
                await PreviewAsync();
            }
#else
            if (VideoInputDevice == VideoInputDevices[0])
            {
                VideoInputDevice = VideoInputDevices[1];
            }
            else
            {
                VideoInputDevice = VideoInputDevices[0];
            }

            await StopAllAsync();

            await PreviewAsync();
#endif
        }

        /// <summary>
        /// Preview async.
        /// </summary>
        private async Task PreviewAsync()
        {
            // START
            if (_pipeline == null || _pipeline.State == PlaybackState.Free)
            {
                await StopAllAsync();

                await CreateEngineAsync(false);

                tmRecording.Start();

                PreviewText = "STOP PREVIEW";

                RecordEnabled = false;
            }
            else
            {
#if __IOS__ && !__MACCATALYST__ || __ANDROID__
                bool capture = _mp4Output != null;
                string filename = null;
                if (capture)
                {
                    filename = _mp4Output.GetFilenameOrURL();
                }
#endif

                await StopAllAsync();

                // save video to iOS photo library
#if __IOS__ && !__MACCATALYST__ || __ANDROID__
                if (capture)
                {
                    await PhotoGalleryHelper.AddVideoToGalleryAsync(filename);
                }
#endif

                PreviewText = "START PREVIEW";
                RecordText = "START RECORD";

                PreviewEnabled = true;
                RecordEnabled = true;
            }
        }

        /// <summary>
        /// Player on error.
        /// </summary>
        private void _player_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        /// <summary>
        /// Stop all async.
        /// </summary>
        private async Task StopAllAsync()
        {
            if (_pipeline == null)
            {
                return;
            }

            tmRecording.Stop();

            bool isCapture = _mp4Output != null;
            if (isCapture)
            {
                await _pipeline.StopAsync();
            }
            else
            {
                await _pipeline.StopAsync(true);
            }

            _mp4Output = null;
        }

        /// <summary>
        /// Update recording time async.
        /// </summary>
        private async Task UpdateRecordingTimeAsync()
        {
            if (_pipeline == null)
            {
                return;
            }

            var pos = await _pipeline.Position_GetAsync();

            if (Math.Abs(pos.TotalMilliseconds) < 0.01)
            {
                return;
            }

            await Dispatcher.UIThread.InvokeAsync((Action)(() =>
            {
                Duration = pos.ToString(@"hh\:mm\:ss");
            }));
        }

        /// <summary>
        /// On volume value changed.
        /// </summary>
        private void OnVolumeValueChanged()
        {
            if (_pipeline != null && _audioRenderer != null)
            {
                _audioRenderer.Volume = VolumeValue / 100.0;
            }
        }
    }
}
