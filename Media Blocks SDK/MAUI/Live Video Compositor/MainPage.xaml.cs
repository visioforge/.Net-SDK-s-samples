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

        // Set while DestroyEngine tears down the compositor so late OnRenderStatistics
        // callbacks that were already queued to the UI thread skip the lbRenderFps update
        // instead of racing with the page going away.
        private volatile bool _isDestroyed;

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
        private void Compositor_OnError(object? sender, ErrorsEventArgs e)
        {
            // Mirror Compositor_OnRenderStatistics: non-async-void so a throw in the synchronous
            // prologue can't tear down the process, and gated on _isDestroyed so a callback
            // already in flight when DestroyEngine ran can't post a stale update onto a UI that
            // has already been torn down. Re-check inside the BeginInvokeOnMainThread callback
            // because _isDestroyed may flip between the post and the run.
            if (_isDestroyed)
            {
                return;
            }

            try
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        if (_isDestroyed || mmLog == null)
                        {
                            return;
                        }

                        mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
                    }
                    catch (Exception inner)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error appending to log: {inner.Message}");
                    }
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error dispatching compositor error: {ex.Message}");
            }
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            // Clear the teardown gate so statistics callbacks from this new compositor are
            // accepted. DestroyEngine sets it to block late callbacks from the previous one.
            _isDestroyed = false;

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
            // Flip the gate BEFORE unhooking/disposing — the event handlers read this flag
            // to decide whether to touch UI. Setting it first closes the window where a
            // callback that fired on an SDK thread a moment ago can still slip through and
            // post a stale update onto the UI queue.
            _isDestroyed = true;

            if (_compositor != null)
            {
                _compositor.OnError -= Compositor_OnError;
                _compositor.OnRenderStatistics -= Compositor_OnRenderStatistics;
                _compositor.Dispose();
                _compositor = null;
            }
        }

        private void Compositor_OnRenderStatistics(object? sender, RenderStatisticsEventArgs e)
        {
            // SDK event fires off the UI thread; fire-and-forget onto the UI thread instead of
            // async void so exceptions from the synchronous prologue can't tear down the process.
            // Gate on _isDestroyed so a callback that arrived between DestroyEngine's handler
            // unhook and its Dispose doesn't post a stale update onto a teardown-in-progress UI.
            if (_isDestroyed)
            {
                return;
            }

            try
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        // Re-check under the UI queue: between posting and running, DestroyEngine
                        // may have flipped _isDestroyed and disposed the compositor.
                        if (_isDestroyed || lbRenderFps == null)
                        {
                            return;
                        }

                        lbRenderFps.Text = $"{e.ActualFps:F1} / {e.ConfiguredFps:F1}";
                    }
                    catch (Exception inner)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error updating render stats: {inner.Message}");
                    }
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error dispatching render stats: {ex.Message}");
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
            // Snapshot _compositor before the first await so a Window_Destroying → DestroyEngine
            // racing with this handler can't null the field out from under us mid-method. Bail
            // out if teardown has already started.
            var compositor = _compositor;
            if (compositor == null || _isDestroyed)
            {
                return;
            }

            try
            {
                compositor.Settings.VideoView = videoView.GetVideoView();

                if (cbAudioRenderer.SelectedIndex >= 0)
                {
                    var audioOutputs = await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.Default);
                    if (_isDestroyed)
                    {
                        return;
                    }

                    var selectedOutput = audioOutputs.FirstOrDefault(x => x.Name == cbAudioRenderer.SelectedItem?.ToString());
                    if (selectedOutput != null)
                    {
                        compositor.Settings.AudioOutput = new AudioRendererBlock(selectedOutput);
                    }
                }

                await compositor.StartAsync();
                if (_isDestroyed)
                {
                    return;
                }

                tmRecording.Start();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error starting compositor: {ex.Message}");
                if (!_isDestroyed)
                {
                    await DisplayAlertAsync("Error", $"Failed to start compositor: {ex.Message}", "OK");
                }
            }
        }

        /// <summary>
        /// Handles the bt stop clicked event.
        /// </summary>
        private async void btStop_Clicked(object? sender, EventArgs e)
        {
            var compositor = _compositor;
            if (compositor == null || _isDestroyed)
            {
                return;
            }

            try
            {
                tmRecording.Stop();
                await compositor.StopAsync();

                if (_isDestroyed)
                {
                    return;
                }

                DestroyEngine();
                CreateEngine();

                _outputs.Clear();
                _sources.Clear();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error stopping compositor: {ex.Message}");
                if (!_isDestroyed)
                {
                    await DisplayAlertAsync("Error", $"Failed to stop compositor: {ex.Message}", "OK");
                }
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
                    // VideoFormats[0] is string-sorted by "{W}x{H} {Format}", which picks
                    // a deterministic but often wrong format (e.g. Razer Kiyo Pro lands on
                    // "1280x720 BGRA", a UVC-simulated BGRA stream that avfvideosrc can
                    // enumerate but never actually start). Use the HD helper which prefers
                    // a real 1280x720@30 format and falls back to the first acceptable one.
                    var format = device.GetHDVideoFormatAndFrameRate(out var frameRate);
                    if (format == null)
                    {
                        format = device.VideoFormats[0];
                        frameRate = format.FrameRateList.Count > 0 ? format.FrameRateList[0] : VisioForge.Core.Types.VideoFrameRate.FPS_30;
                    }

                    var settings = new VideoCaptureDeviceSourceSettings(device)
                    {
                        Format = format.ToFormat()
                    };
                    settings.Format.FrameRate = frameRate;

                    var name = $"Camera [{device.DisplayName}]";
                    var rect = GetRectFromUI();
                    var videoInfo = new VideoFrameInfoX(settings.Format.Width, settings.Format.Height, settings.Format.FrameRate);

                    // Mirror AddScreenSourceAsync: own block + wrapper through try/finally so a
                    // throw from the LVCVideoInput ctor or Input_AddAsync doesn't leak either.
                    SystemVideoSourceBlock? block = null;
                    LVCVideoInput? src = null;
                    try
                    {
                        block = new SystemVideoSourceBlock(settings);
                        src = new LVCVideoInput(name, _compositor, block, videoInfo, rect, true);
                        block = null; // ownership transferred to LVCVideoInput
                        src.ZOrder = (uint)_compositor.Input_Count();

                        if (await _compositor.Input_AddAsync(src))
                        {
                            _sources.Add(name);
                            lbSources.SelectedItem = name;
                            src = null; // ownership transferred to the compositor
                        }
                    }
                    finally
                    {
                        src?.Dispose();
                        block?.Dispose();
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

                    // GetInfo() can return null for unsupported containers — calling
                    // .GetVideoInfo() / .GetAudioInfo() on null would NRE and leak the
                    // already-allocated UniversalSourceBlock + LVCVideoAudioInput wrapper.
                    var info = settings.GetInfo();
                    if (info == null)
                    {
                        await DisplayAlertAsync("Error", $"Could not read media info from {Path.GetFileName(filename)}.", "OK");
                        return;
                    }

                    UniversalSourceBlock? block = null;
                    LVCVideoAudioInput? src = null;
                    try
                    {
                        block = new UniversalSourceBlock(settings);
                        src = new LVCVideoAudioInput(name, _compositor, block,
                            info.GetVideoInfo(), info.GetAudioInfo(), rect,
                            autostart: true, live: false);
                        block = null; // ownership transferred to LVCVideoAudioInput
                        src.ZOrder = (uint)_compositor.Input_Count();

                        if (await _compositor.Input_AddAsync(src))
                        {
                            _sources.Add(name);
                            lbSources.SelectedItem = name;
                            src = null; // ownership transferred to the compositor
                        }
                    }
                    finally
                    {
                        src?.Dispose();
                        block?.Dispose();
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
                    // ScreenCaptureMacOSSourceSettings may be constructed with a default (empty)
                    // Rectangle / FrameRate if DisplayHelper failed upstream — fall back to a
                    // safe 1280x720@30 instead of feeding width=0,height=0 into VideoFrameInfoX,
                    // which would assert or produce a zero-sized Metal drawable downstream.
                    if (macSettings.Rectangle != null
                        && macSettings.Rectangle.Width > 0
                        && macSettings.Rectangle.Height > 0)
                    {
                        width = (int)macSettings.Rectangle.Width;
                        height = (int)macSettings.Rectangle.Height;
                    }

                    if (!macSettings.FrameRate.IsEmpty && macSettings.FrameRate.Value > 0)
                    {
                        frameRate = macSettings.FrameRate;
                    }
                }
#endif

                var name = $"Screen [{width}x{height}]";
                var rect = GetRectFromUI();
                var videoInfo = new VideoFrameInfoX(width, height, frameRate);

                // Own src through try/finally so a throw from Input_AddAsync (or anywhere
                // before it) doesn't leak the input wrapper and its underlying block.
                //
                // LVC Input_AddAsync contract: it only takes ownership of the wrapper on a
                // true return — on false, the caller keeps ownership and must Dispose. That
                // matches the only code path in LiveVideoCompositor that returns false (the
                // "input already exists" early-out, which never stored the wrapper). So
                // Dispose()'ing src in the failure path is safe, not a double-dispose.
                LVCVideoInput? src = null;
                try
                {
                    src = new LVCVideoInput(name, _compositor, block, videoInfo, rect, true);
                    src.ZOrder = (uint)_compositor.Input_Count();

                    if (await _compositor.Input_AddAsync(src))
                    {
                        _sources.Add(name);
                        lbSources.SelectedItem = name;
                        src = null; // ownership transferred to the compositor
                    }
                }
                finally
                {
                    src?.Dispose();
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

                    SystemAudioSourceBlock? block = null;
                    LVCAudioInput? src = null;
                    try
                    {
                        block = new SystemAudioSourceBlock(settings);
                        src = new LVCAudioInput(name, _compositor, block,
                            new AudioInfoX() { SampleRate = 44100, Channels = 2 }, true);
                        block = null; // ownership transferred to LVCAudioInput

                        if (await _compositor.Input_AddAsync(src))
                        {
                            _sources.Add(name);
                            lbSources.SelectedItem = name;
                            src = null; // ownership transferred to the compositor
                        }
                    }
                    finally
                    {
                        src?.Dispose();
                        block?.Dispose();
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
        /// Resolve a platform-appropriate directory for LVC output recordings. Private
        /// AppDataDirectory is invisible to end users on iOS and Android, so:
        ///   • iOS / MacCatalyst:  per-app Documents dir — surfaces in the Files app when
        ///     the app's Info.plist has <c>UIFileSharingEnabled=YES</c> and
        ///     <c>LSSupportsOpeningDocumentsInPlace=YES</c>.
        ///   • Android:  SpecialFolder.MyVideos (maps to the app-scoped Movies dir);
        ///     falls back to AppDataDirectory if empty (pre-scoped-storage devices).
        ///   • Desktop:  SpecialFolder.MyVideos (Videos library on Windows / ~/Movies on
        ///     macOS) with an AppDataDirectory fallback.
        /// Creates the directory if it doesn't exist.
        /// </summary>
        private static string GetRecordingsDirectory()
        {
#if __IOS__ || __MACCATALYST__
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
#else
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            if (string.IsNullOrEmpty(dir))
            {
                dir = FileSystem.AppDataDirectory;
            }
#endif

            try
            {
                Directory.CreateDirectory(dir);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"GetRecordingsDirectory: could not create '{dir}': {ex.Message}");
                // AppDataDirectory isn't guaranteed to exist either on first launch — ensure
                // it before handing it back, otherwise the output file open will fail with a
                // DirectoryNotFoundException and the user sees a spurious error after we've
                // already warned about the primary path failure.
                var fallback = FileSystem.AppDataDirectory;
                try
                {
                    Directory.CreateDirectory(fallback);
                }
                catch (Exception fallbackEx)
                {
                    Debug.WriteLine($"GetRecordingsDirectory: fallback '{fallback}' also failed: {fallbackEx.Message}");
                }
                return fallback;
            }

            return dir;
        }

        /// <summary>
        /// Add mp 4 output async.
        /// </summary>
        private async Task AddMP4OutputAsync()
        {
            var now = DateTime.Now;
            var name = $"output_{now:yyyy_MM_dd_HH_mm_ss}.mp4";
            var outputFile = Path.Combine(GetRecordingsDirectory(), name);

            // avenc_aac ships via gst-libav and isn't always present on mobile — probe first
            // and fall back to the portable VO-AAC encoder so the demo doesn't fail to start.
            IAACEncoderSettings aacSettings = AVENCAACEncoderSettings.IsAvailable()
                ? (IAACEncoderSettings)new AVENCAACEncoderSettings()
                : new VOAACEncoderSettings();

            MP4OutputBlock? mp4Output = null;
            LVCVideoAudioOutput? output = null;
            try
            {
                mp4Output = new MP4OutputBlock(new MP4SinkSettings(outputFile),
                    new OpenH264EncoderSettings(), aacSettings);
                output = new LVCVideoAudioOutput(outputFile, _compositor, mp4Output, autostart: true);
                mp4Output = null; // ownership transferred to LVCVideoAudioOutput

                if (await _compositor.Output_AddAsync(output))
                {
                    _outputs.Add(name);
                    lbOutputs.SelectedItem = name;
                    output = null; // ownership transferred to the compositor
                }
            }
            finally
            {
                output?.Dispose();
                mp4Output?.Dispose();
            }
        }

        /// <summary>
        /// Add web m output async.
        /// </summary>
        private async Task AddWebMOutputAsync()
        {
            var now = DateTime.Now;
            var name = $"output_{now:yyyy_MM_dd_HH_mm_ss}.webm";
            var outputFile = Path.Combine(GetRecordingsDirectory(), name);

            WebMOutputBlock? webmOutput = null;
            LVCVideoAudioOutput? output = null;
            try
            {
                webmOutput = new WebMOutputBlock(new WebMSinkSettings(outputFile),
                    new VP8EncoderSettings(), new VorbisEncoderSettings());
                output = new LVCVideoAudioOutput(outputFile, _compositor, webmOutput, false);
                webmOutput = null;

                if (await _compositor.Output_AddAsync(output))
                {
                    _outputs.Add(name);
                    lbOutputs.SelectedItem = name;
                    output = null;
                }
            }
            finally
            {
                output?.Dispose();
                webmOutput?.Dispose();
            }
        }

        /// <summary>
        /// Add mp 3 output async.
        /// </summary>
        private async Task AddMP3OutputAsync()
        {
            var now = DateTime.Now;
            var name = $"output_{now:yyyy_MM_dd_HH_mm_ss}.mp3";
            var outputFile = Path.Combine(GetRecordingsDirectory(), name);

            MP3OutputBlock? mp3Output = null;
            LVCAudioOutput? output = null;
            try
            {
                mp3Output = new MP3OutputBlock(outputFile, new MP3EncoderSettings());
                output = new LVCAudioOutput(outputFile, _compositor, mp3Output, false);
                mp3Output = null;

                if (await _compositor.Output_AddAsync(output))
                {
                    _outputs.Add(name);
                    lbOutputs.SelectedItem = name;
                    output = null;
                }
            }
            finally
            {
                output?.Dispose();
                mp3Output?.Dispose();
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
        /// Get rect from ui. Non-numeric Entry text falls back to 0 so bad input
        /// can't raise FormatException on the click handler. Bad fields are logged to
        /// Debug — the earlier design was to show a non-blocking alert, but fire-and-
        /// forget DisplayAlertAsync from a synchronous helper racing against the caller's
        /// own dialogs hung/crashed some MAUI+iOS versions, so the alert was intentionally
        /// dropped. See the in-body comment for the rationale.
        /// </summary>
        private Rect GetRectFromUI()
        {
            var invalid = new List<string>();

            int Parse(string text, string fieldName)
            {
                if (int.TryParse(text, out var value))
                {
                    return value;
                }

                invalid.Add(fieldName);
                Debug.WriteLine($"GetRectFromUI: '{fieldName}' = '{text}' is not a valid integer; using 0.");
                return 0;
            }

            var left = Parse(edRectLeft.Text, "Left");
            var top = Parse(edRectTop.Text, "Top");
            var right = Parse(edRectRight.Text, "Right");
            var bottom = Parse(edRectBottom.Text, "Bottom");
            var rect = new Rect(left, top, right - left, bottom - top);

            if (invalid.Count > 0)
            {
                // Log only. A fire-and-forget DisplayAlertAsync from a synchronous helper racing
                // against the caller's own dialogs has hung/crashed on some MAUI+iOS versions
                // when two modals are presented back-to-back, and swallowed-task exceptions made
                // the failure mode invisible. Per-field Debug.WriteLine above already flags bad
                // input to the developer; the user will see the resulting rectangle misbehave.
                Debug.WriteLine($"GetRectFromUI: invalid integer field(s) treated as 0: {string.Join(", ", invalid)}");
            }

            return rect;
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
