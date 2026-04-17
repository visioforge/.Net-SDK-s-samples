using System;
using System.Linq;
using Microsoft.Maui.Controls;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types;
using Rect = VisioForge.Core.Types.Rect;
using VisioForge.Core.LiveVideoCompositorV2;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.VideoEncoders;
using System.IO;
using System.Threading.Tasks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X;
using VisioForge.Core.Helpers;
using System.Collections.ObjectModel;
using System.Timers;
using System.Diagnostics;

namespace Live_Video_Compositor_MB_MAUI
{
    public partial class MainPage : ContentPage
    {
        private LiveVideoCompositor _compositor;
        private int _videoWidth = 1280;
        private int _videoHeight = 720;
        private VideoFrameRate _videoFrameRate = new VideoFrameRate(30);
        private LVCMixerType _mixerType = LVCMixerType.CPU;
        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);
        
        private ObservableCollection<string> _sources = new ObservableCollection<string>();
        private ObservableCollection<string> _outputs = new ObservableCollection<string>();

        public MainPage()
        {
            InitializeComponent();
            
            lbSources.ItemsSource = _sources;
            lbOutputs.ItemsSource = _outputs;
        }

        /// <summary>
        /// On appearing.
        /// </summary>
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();

                await InitializeAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// On disappearing.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Window window = this.Window;
            if (window != null)
            {
                window.Destroying += Window_Destroying;
            }
        }

        /// <summary>
        /// Window destroying.
        /// </summary>
        private async void Window_Destroying(object? sender, EventArgs e)
        {
            try
            {
                await DisposeAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error during cleanup: {ex.Message}");
            }
        }

        /// <summary>
        /// Initialize async.
        /// </summary>
        private async Task InitializeAsync()
        {
            // Show resolution selection dialog
            bool result = await DisplayAlertAsync("Video Settings", 
                "Select video resolution", 
                "1280x720 @ 30fps", 
                "1920x1080 @ 30fps");
            
            if (result)
            {
                _videoWidth = 1280;
                _videoHeight = 720;
            }
            else
            {
                _videoWidth = 1920;
                _videoHeight = 1080;
            }

            lbResolution.Text = $"Video: {_videoWidth}x{_videoHeight}@{_videoFrameRate}fps";

            CreateEngine();

            Title = $"Live Video Compositor (SDK v{MediaBlocksPipeline.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

            DeviceEnumerator.Shared.OnAudioSinkAdded += Shared_OnAudioSinkAdded;
            await DeviceEnumerator.Shared.StartAudioSinkMonitorAsync();

            // Set up audio renderer options
            var audioOutputs = await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.Default);
            foreach (var output in audioOutputs)
            {
                cbAudioRenderer.Items.Add(output.Name);
            }
            if (cbAudioRenderer.Items.Count > 0)
            {
                cbAudioRenderer.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Shared on audio sink added.
        /// </summary>
        private async void Shared_OnAudioSinkAdded(object? sender, AudioOutputDeviceInfo e)
        {
            try
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    if (!cbAudioRenderer.Items.Contains(e.Name))
                    {
                        cbAudioRenderer.Items.Add(e.Name);
                    }

                    if (cbAudioRenderer.SelectedIndex == -1 && cbAudioRenderer.Items.Count > 0)
                    {
                        cbAudioRenderer.SelectedIndex = 0;
                    }
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding audio sink: {ex.Message}");
            }
        }

        /// <summary>
        /// Compositor on error.
        /// </summary>
        private async void Compositor_OnError(object? sender, ErrorsEventArgs e)
        {
            try
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error handling compositor error: {ex.Message}");
            }
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            var settings = new LiveVideoCompositorSettings(_videoWidth, _videoHeight, _videoFrameRate);
            settings.MixerType = _mixerType;
            settings.AudioEnabled = true;

            _compositor = new LiveVideoCompositor(settings);
            _compositor.OnError += Compositor_OnError;
            _compositor.OnRenderStatistics += Compositor_OnRenderStatistics;
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (_compositor != null)
            {
                _compositor.OnError -= Compositor_OnError;
                _compositor.OnRenderStatistics -= Compositor_OnRenderStatistics;
                _compositor.Dispose();
                _compositor = null;
            }
        }

        private async void Compositor_OnRenderStatistics(object? sender, RenderStatisticsEventArgs e)
        {
            try
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    lbRenderFps.Text = $"{e.ActualFps:F1} / {e.ConfiguredFps:F1}";
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating render stats: {ex.Message}");
            }
        }

        /// <summary>
        /// Update recording time.
        /// </summary>
        private async void UpdateRecordingTime()
        {
            try
            {
                var ts = await _compositor.DurationAsync();

                if (Math.Abs(ts.TotalMilliseconds) < 0.01)
                {
                    return;
                }

                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    lbTimestamp.Text = ts.ToString(@"hh\:mm\:ss");
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating recording time: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the bt start clicked event.
        /// </summary>
        private async void btStart_Clicked(object? sender, EventArgs e)
        {
            try
            {
                _compositor.Settings.VideoView = videoView.GetVideoView();
                
                if (cbAudioRenderer.SelectedIndex >= 0)
                {
                    var audioOutputs = await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.Default);
                    var selectedOutput = audioOutputs.FirstOrDefault(x => x.Name == cbAudioRenderer.SelectedItem.ToString());
                    if (selectedOutput != null)
                    {
                        _compositor.Settings.AudioOutput = new AudioRendererBlock(selectedOutput);
                    }
                }

                await _compositor.StartAsync();
                tmRecording.Start();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error starting compositor: {ex.Message}");
                await DisplayAlertAsync("Error", $"Failed to start compositor: {ex.Message}", "OK");
            }
        }

        /// <summary>
        /// Handles the bt stop clicked event.
        /// </summary>
        private async void btStop_Clicked(object? sender, EventArgs e)
        {
            try
            {
                tmRecording.Stop();
                await _compositor.StopAsync();
                
                DestroyEngine();
                CreateEngine();

                _outputs.Clear();
                _sources.Clear();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error stopping compositor: {ex.Message}");
                await DisplayAlertAsync("Error", $"Failed to stop compositor: {ex.Message}", "OK");
            }
        }

        /// <summary>
        /// Handles the bt add source clicked event.
        /// </summary>
        private async void btAddSource_Clicked(object? sender, EventArgs e)
        {
            try
            {
                string action = await DisplayActionSheetAsync("Add Source", "Cancel", null, "Camera", "File", "Screen", "Audio Device");

                switch (action)
                {
                    case "Camera":
                        await AddCameraSourceAsync();
                        break;
                    case "File":
                        await AddFileSourceAsync();
                        break;
                    case "Screen":
                        await AddScreenSourceAsync();
                        break;
                    case "Audio Device":
                        await AddAudioDeviceSourceAsync();
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding source: {ex.Message}");
                await DisplayAlertAsync("Error", $"Failed to add source: {ex.Message}", "OK");
            }
        }

        /// <summary>
        /// Add camera source async.
        /// </summary>
        private async Task AddCameraSourceAsync()
        {
            var videoSources = await DeviceEnumerator.Shared.VideoSourcesAsync();
            if (videoSources.Length == 0)
            {
                await DisplayAlertAsync("Error", "No camera devices found", "OK");
                return;
            }

            var sourceNames = videoSources.Select(x => x.DisplayName).ToArray();
            var selectedSource = await DisplayActionSheetAsync("Select Camera", "Cancel", null, sourceNames);
            
            if (selectedSource != null && selectedSource != "Cancel")
            {
                var device = videoSources.FirstOrDefault(x => x.DisplayName == selectedSource);
                if (device != null && device.VideoFormats.Count > 0)
                {
                    var format = device.VideoFormats[0];
                    var settings = new VideoCaptureDeviceSourceSettings(device)
                    {
                        Format = format.ToFormat()
                    };

                    var name = $"Camera [{device.DisplayName}]";
                    var rect = GetRectFromUI();
                    var videoInfo = new VideoFrameInfoX(settings.Format.Width, settings.Format.Height, settings.Format.FrameRate);
                    var src = new LVCVideoInput(name, _compositor, new SystemVideoSourceBlock(settings), videoInfo, rect, true);
                    src.ZOrder = (uint)_compositor.Input_Count();

                    if (await _compositor.Input_AddAsync(src))
                    {
                        _sources.Add(name);
                        lbSources.SelectedItem = name;
                    }
                    else
                    {
                        src.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Add file source async.
        /// </summary>
        private async Task AddFileSourceAsync()
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Select a video file",
                    FileTypes = FilePickerFileType.Videos
                });

                if (result != null)
                {
                    var filename = result.FullPath;
                    var name = $"File [{Path.GetFileName(filename)}]";
                    var rect = GetRectFromUI();
#if __IOS__ && !__MACCATALYST__
                    var nsUrl = new Foundation.NSUrl(filename);
                    var settings = await UniversalSourceSettings.CreateAsync(nsUrl);
#else
                    var settings = await UniversalSourceSettings.CreateAsync(filename);
#endif
                    var src = new LVCVideoAudioInput(name, _compositor, new UniversalSourceBlock(settings), 
                        settings.GetInfo().GetVideoInfo(), settings.GetInfo().GetAudioInfo(), rect, 
                        autostart: true, live: false);
                    src.ZOrder = (uint)_compositor.Input_Count();

                    if (await _compositor.Input_AddAsync(src))
                    {
                        _sources.Add(name);
                        lbSources.SelectedItem = name;
                    }
                    else
                    {
                        src.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Error", $"Failed to add file source: {ex.Message}", "OK");
            }
        }

        /// <summary>
        /// Add screen source async.
        /// </summary>
        private async Task AddScreenSourceAsync()
        {
#if __MACCATALYST__ || __MACOS__ || NET_WINDOWS
            try
            {
#if __MACCATALYST__
                if (!OperatingSystem.IsMacCatalystVersionAtLeast(18, 2))
                {
                    await DisplayAlertAsync(
                        "Not supported",
                        "Screen capture on Mac Catalyst requires macOS 15.2 or later (Mac Catalyst 18.2).",
                        "OK");
                    return;
                }

                // Nudge the TCC prompt now so first-run users see it before the pipeline starts.
                // Not a gate: ScreenCaptureKit validates permission itself when SCStream starts.
                PermissionsHelper.RequestScreenRecordingPermission();
#elif __MACOS__
                var status = PermissionsHelper.CheckScreenRecordingPermission();
                if (status != ScreenRecordingPermissionStatus.Granted
                    && status != ScreenRecordingPermissionStatus.NotApplicable)
                {
                    PermissionsHelper.RequestScreenRecordingPermission();
                    await DisplayAlertAsync(
                        "Screen Recording permission required",
                        "Grant Screen Recording access for this app in System Settings → Privacy & Security → Screen & System Audio Recording, then quit and relaunch the app.",
                        "OK");
                    return;
                }
#endif

                var block = new ScreenSourceBlock();
                var screenSettings = block.Settings;

                int width = 1280;
                int height = 720;
                VideoFrameRate frameRate = new VideoFrameRate(30, 1);

#if __MACCATALYST__ || __MACOS__
                if (screenSettings is ScreenCaptureMacOSSourceSettings macSettings)
                {
                    width = (int)macSettings.Rectangle.Width;
                    height = (int)macSettings.Rectangle.Height;
                    frameRate = macSettings.FrameRate;
                }
#endif

                var name = $"Screen [{width}x{height}]";
                var rect = GetRectFromUI();
                var videoInfo = new VideoFrameInfoX(width, height, frameRate);
                var src = new LVCVideoInput(name, _compositor, block, videoInfo, rect, true);
                src.ZOrder = (uint)_compositor.Input_Count();

                if (await _compositor.Input_AddAsync(src))
                {
                    _sources.Add(name);
                    lbSources.SelectedItem = name;
                }
                else
                {
                    src.Dispose();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Error", $"Failed to add screen source: {ex.Message}", "OK");
            }
#else
            await DisplayAlertAsync("Info", "Screen capture is not available on this platform", "OK");
#endif
        }

        /// <summary>
        /// Add audio device source async.
        /// </summary>
        private async Task AddAudioDeviceSourceAsync()
        {
            var audioSources = await DeviceEnumerator.Shared.AudioSourcesAsync();
            if (audioSources.Length == 0)
            {
                await DisplayAlertAsync("Error", "No audio devices found", "OK");
                return;
            }

            var sourceNames = audioSources.Select(x => x.DisplayName).ToArray();
            var selectedSource = await DisplayActionSheetAsync("Select Audio Device", "Cancel", null, sourceNames);
            
            if (selectedSource != null && selectedSource != "Cancel")
            {
                var device = audioSources.FirstOrDefault(x => x.DisplayName == selectedSource);
                if (device != null)
                {
#if __IOS__ || __MACCATALYST__
                    var settings = new AudioCaptureDeviceSourceSettings(AudioCaptureDeviceAPI.CoreAudio, device, new AudioCaptureDeviceFormat() { SampleRate = 44100, Channels = 2 });
#elif __ANDROID__
                    var settings = new AudioCaptureDeviceSourceSettings(AudioCaptureDeviceAPI.OpenSLES, device, new AudioCaptureDeviceFormat() { SampleRate = 44100, Channels = 2 });
#else
                    var settings = new AudioCaptureDeviceSourceSettings(AudioCaptureDeviceAPI.DirectSound, device, new AudioCaptureDeviceFormat() { SampleRate = 44100, Channels = 2 });
#endif
                    var name = $"Audio [{device.Name}]";
                    var src = new LVCAudioInput(name, _compositor, new SystemAudioSourceBlock(settings), 
                        new AudioInfoX() { SampleRate = 44100, Channels = 2 }, true);

                    if (await _compositor.Input_AddAsync(src))
                    {
                        _sources.Add(name);
                        lbSources.SelectedItem = name;
                    }
                    else
                    {
                        src.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Handles the bt remove source clicked event.
        /// </summary>
        private async void btRemoveSource_Clicked(object? sender, EventArgs e)
        {
            try
            {
                if (lbSources.SelectedItem is string selectedItem)
                {
                    int index = _sources.IndexOf(selectedItem);
                    if (index >= 0)
                    {
                        var input = _compositor.Input_Get(index);
                        if (input != null)
                        {
                            await _compositor.Input_RemoveAsync(input.ID);
                        }
                        _sources.RemoveAt(index);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt update source clicked event.
        /// </summary>
        private void btUpdateSource_Clicked(object? sender, EventArgs e)
        {
            if (lbSources.SelectedItem is string selectedItem)
            {
                int index = _sources.IndexOf(selectedItem);
                if (index != -1)
                {
                    var rect = GetRectFromUI();
                    var zOrder = Convert.ToUInt32(edZOrder.Text);

                    var input = _compositor.Input_Get(index);
                    if (input == null)
                    {
                        return;
                    }

                    // Update rectangles
                    if (input is LVCVideoAudioInput vai)
                    {
                        vai.Rectangle = rect;
                    }
                    else if (input is LVCVideoInput vi)
                    {
                        vi.Rectangle = rect;
                    }

                    // Update live stream if available
                    var stream = _compositor.Input_VideoStream_Get(input);
                    if (stream != null)
                    {
                        stream.Rectangle = rect;
                        stream.ZOrder = zOrder;
                        _compositor.Input_VideoStream_Update(stream);
                    }
                }
            }
        }

        /// <summary>
        /// Lb sources selection changed.
        /// </summary>
        private void lbSources_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is string selectedItem)
            {
                int index = _sources.IndexOf(selectedItem);
                if (index >= 0)
                {
                    var input = _compositor.Input_Get(index);
                    if (input != null)
                    {
                        Rect rect = new Rect(0, 0, 640, 480);
                        uint zOrder = 0;

                        if (input is LVCVideoAudioInput vai)
                        {
                            rect = vai.Rectangle;
                            zOrder = vai.ZOrder;
                        }
                        else if (input is LVCVideoInput vi)
                        {
                            rect = vi.Rectangle;
                            zOrder = vi.ZOrder;
                        }

                        edRectLeft.Text = rect.Left.ToString();
                        edRectTop.Text = rect.Top.ToString();
                        edRectRight.Text = rect.Right.ToString();
                        edRectBottom.Text = rect.Bottom.ToString();
                        edZOrder.Text = zOrder.ToString();

                        // Enable seeking for file sources
                        tbSeeking.IsEnabled = false; // Live status not exposed in API
                    }
                }
            }
        }

        /// <summary>
        /// Tb seeking value changed.
        /// </summary>
        private async void tbSeeking_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            try
            {
                if (lbSources.SelectedItem is string selectedItem)
                {
                    int index = _sources.IndexOf(selectedItem);
                    if (index >= 0)
                    {
                        var input = _compositor.Input_Get(index);
                        if (input is LVCVideoAudioInput vai)
                        {
                            // Seeking functionality would need to be implemented differently
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
        /// Handles the bt add output clicked event.
        /// </summary>
        private async void btAddOutput_Clicked(object? sender, EventArgs e)
        {
            try
            {
                string action = await DisplayActionSheetAsync("Add Output", "Cancel", null, "MP4 File", "WebM File", "MP3 File");

                switch (action)
                {
                    case "MP4 File":
                        await AddMP4OutputAsync();
                        break;
                    case "WebM File":
                        await AddWebMOutputAsync();
                        break;
                    case "MP3 File":
                        await AddMP3OutputAsync();
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Add mp 4 output async.
        /// </summary>
        private async Task AddMP4OutputAsync()
        {
            var now = DateTime.Now;
            var name = $"output_{now:yyyy_MM_dd_HH_mm_ss}.mp4";
            var outputFile = Path.Combine(FileSystem.AppDataDirectory, name);
            var mp4Output = new MP4OutputBlock(new MP4SinkSettings(outputFile), 
                new OpenH264EncoderSettings(), new AVENCAACEncoderSettings());

            var output = new LVCVideoAudioOutput(outputFile, _compositor, mp4Output, autostart: true);

            if (await _compositor.Output_AddAsync(output))
            {
                _outputs.Add(name);
                lbOutputs.SelectedItem = name;
            }
            else
            {
                output.Dispose();
            }
        }

        /// <summary>
        /// Add web m output async.
        /// </summary>
        private async Task AddWebMOutputAsync()
        {
            var now = DateTime.Now;
            var name = $"output_{now:yyyy_MM_dd_HH_mm_ss}.webm";
            var outputFile = Path.Combine(FileSystem.AppDataDirectory, name);
            var webmOutput = new WebMOutputBlock(new WebMSinkSettings(outputFile), 
                new VP8EncoderSettings(), new VorbisEncoderSettings());
            var output = new LVCVideoAudioOutput(outputFile, _compositor, webmOutput, false);

            if (await _compositor.Output_AddAsync(output))
            {
                _outputs.Add(name);
                lbOutputs.SelectedItem = name;
            }
            else
            {
                output.Dispose();
            }
        }

        /// <summary>
        /// Add mp 3 output async.
        /// </summary>
        private async Task AddMP3OutputAsync()
        {
            var now = DateTime.Now;
            var name = $"output_{now:yyyy_MM_dd_HH_mm_ss}.mp3";
            var outputFile = Path.Combine(FileSystem.AppDataDirectory, name);
            var mp3Output = new MP3OutputBlock(outputFile, new MP3EncoderSettings());
            var output = new LVCAudioOutput(outputFile, _compositor, mp3Output, false);

            if (await _compositor.Output_AddAsync(output))
            {
                _outputs.Add(name);
                lbOutputs.SelectedItem = name;
            }
            else
            {
                output.Dispose();
            }
        }

        /// <summary>
        /// Handles the bt remove output clicked event.
        /// </summary>
        private async void btRemoveOutput_Clicked(object? sender, EventArgs e)
        {
            try
            {
                if (lbOutputs.SelectedItem is string selectedItem)
                {
                    int index = _outputs.IndexOf(selectedItem);
                    if (index >= 0)
                    {
                        var output = _compositor.Output_Get(index);
                        if (output != null)
                        {
                            await _compositor.Output_RemoveAsync(output.ID);
                        }
                        _outputs.RemoveAt(index);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt start output clicked event.
        /// </summary>
        private async void btStartOutput_Clicked(object? sender, EventArgs e)
        {
            try
            {
                if (lbOutputs.SelectedItem is string selectedItem)
                {
                    int index = _outputs.IndexOf(selectedItem);
                    if (index >= 0)
                    {
                        var output = _compositor.Output_Get(index);
                        if (output != null)
                        {
                            await output.StartAsync();
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
        /// Handles the bt stop output clicked event.
        /// </summary>
        private async void btStopOutput_Clicked(object? sender, EventArgs e)
        {
            try
            {
                if (lbOutputs.SelectedItem is string selectedItem)
                {
                    int index = _outputs.IndexOf(selectedItem);
                    if (index >= 0)
                    {
                        var output = _compositor.Output_Get(index);
                        if (output != null)
                        {
                            await output.StopAsync();
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
        /// Get rect from ui.
        /// </summary>
        private Rect GetRectFromUI()
        {
            return new Rect(
                Convert.ToInt32(edRectLeft.Text),
                Convert.ToInt32(edRectTop.Text),
                Convert.ToInt32(edRectRight.Text),
                Convert.ToInt32(edRectBottom.Text));
        }

        /// <summary>
        /// Dispose async.
        /// </summary>
        private async Task DisposeAsync()
        {
            tmRecording?.Stop();
            tmRecording?.Dispose();

            if (_compositor != null)
            {
                await _compositor.StopAsync();
                DestroyEngine();
            }

            DeviceEnumerator.Shared.OnAudioSinkAdded -= Shared_OnAudioSinkAdded;

            VisioForgeX.DestroySDK();
        }
    }
}
