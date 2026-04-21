using System;
using System.Linq;
using System.Windows;

using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types;
using VisioForge.Core.UI.WPF.Dialogs.Sources;

using Rect = VisioForge.Core.Types.Rect;

using VisioForge.Core.LiveVideoCompositorV2;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.VideoEncoders;
using System.IO;
using System.Windows.Controls;
using System.Threading.Tasks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core;
using Microsoft.Win32;
using VisioForge.Core.MediaBlocks.Decklink;
using VisioForge.Core.UI.WPF.Dialogs.Decklink;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X;
using VisioForge.Core.Helpers;
using VisioForge.Core.GStreamer;
using System.Diagnostics;

namespace Live_Video_Compositor_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LiveVideoCompositor _compositor;

        private LVCVideoViewOutput _videoRendererOutput;

        private LVCAudioOutput _audioRendererOutput;

        private int _videoWidth;

        private int _videoHeight;

        private VideoFrameRate _videoFrameRate;

        private LVCMixerType _mixerType;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        // Guard flag for the two-phase Window_Closing pattern. Because DisposeAsync is async, we
        // cancel the first close, await disposal, then re-invoke Close() which fires Window_Closing
        // again; the flag lets the second invocation fall through without cancelling.
        private bool _isClosing;

        // True while the user is actively dragging the tbSeeking thumb. Suppresses the torrent of
        // ValueChanged ticks that would otherwise fire Position_SetAsync on every pixel of drag.
        private bool _isDraggingSeek;

        // Flag flipped on/off around programmatic writes to tbSeeking (Maximum / Value). Decouples
        // "this is an app-originated change, ignore in ValueChanged" from `_timelineSeeking`, whose
        // semantics are about whether user seeks are allowed at all. Without a dedicated flag, a
        // future refactor of `_timelineSeeking` would silently re-arm programmatic writes as seeks.
        private bool _isProgrammaticSliderWrite;

        // Monotonic counter bumped on every UpdateSourceSelectionAsync entry. Lets a stale
        // invocation (whose selection got replaced mid-await) detect that a newer run owns the
        // `_timelineSeeking` flag and skip the finally-restore, so it doesn't flip the flag back
        // on while the newer run is still mid-critical-section.
        private int _updateSourceSelectionGeneration;

        public MainWindow()
        {
            InitializeComponent();            
        }
                
        /// <summary>
        /// Compositor on error.
        /// </summary>
        private void Compositor_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private void Compositor_OnAudioVUMeter(object sender, VUMeterXEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                if (e.MeterData == null || e.MeterData.ChannelsCount == 0)
                    return;

                volumeMeterL.Amplitude = (float)e.MeterData.Peak[0];
                volumeMeterL.Update();

                if (e.MeterData.ChannelsCount > 1)
                {
                    volumeMeterR.Amplitude = (float)e.MeterData.Peak[1];
                    volumeMeterR.Update();
                }
            }));
        }

        private void Compositor_OnRenderStatistics(object sender, RenderStatisticsEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                lbRenderFps.Content = $"{e.ActualFps:F1} / {e.ConfiguredFps:F1}";
            }));
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            var settings =
                new LiveVideoCompositorSettings(_videoWidth, _videoHeight, _videoFrameRate);
            settings.MixerType = _mixerType;
            settings.AudioEnabled = true;

            _compositor = new LiveVideoCompositor(settings);
            _compositor.OnError += Compositor_OnError;
            _compositor.OnAudioVUMeter += Compositor_OnAudioVUMeter;
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
                _compositor.OnAudioVUMeter -= Compositor_OnAudioVUMeter;
                _compositor.OnRenderStatistics -= Compositor_OnRenderStatistics;

                // Clear the VideoView reference out of Settings before disposing so the old
                // compositor cannot leave any native rendering handles attached to VideoView1.
                // The WPF VideoView has no explicit Detach() API — it's re-bindable by design,
                // so subsequent `Settings.VideoView = VideoView1` on a fresh compositor is safe.
                // CallRefresh forces the control to repaint its empty state after detach.
                try { _compositor.Settings.VideoView = null; } catch { /* settings may be torn down */ }

                _compositor.Dispose();
                _compositor = null;

                try { VideoView1?.CallRefresh(); } catch { /* view may be unloaded during shutdown */ }
            }
        }

        /// <summary>
        /// Parse an int from a TextBox, falling back to <paramref name="defaultValue"/> on bad input.
        /// Used in place of Convert.ToInt32 to avoid a FormatException crashing the WPF dispatcher
        /// when the user types non-numeric text into the rect / z-order fields.
        /// </summary>
        private static int ParseIntOrDefault(TextBox tb, int defaultValue)
        {
            return int.TryParse(tb?.Text, out var n) ? n : defaultValue;
        }

        /// <summary>
        /// Parse a uint from a TextBox, falling back to <paramref name="defaultValue"/> on bad input.
        /// </summary>
        private static uint ParseUIntOrDefault(TextBox tb, uint defaultValue)
        {
            return uint.TryParse(tb?.Text, out var n) ? n : defaultValue;
        }

        /// <summary>
        /// Build a Rect from the edRectLeft/Top/Right/Bottom TextBoxes, falling back to the
        /// XAML defaults (0,0,640,480) for any unparseable field. <see cref="Rect"/>'s
        /// constructor signature is <c>(int left, int top, int right, int bottom)</c> — verified
        /// in <see cref="Rect.Rect(int, int, int, int)"/>; this matches
        /// <c>UpdateSourceSelectionAsync</c>'s usage of <c>input.Rectangle.Right/Bottom</c>. If a
        /// field parses to produce a degenerate rect (right ≤ left, bottom ≤ top) we force the
        /// corresponding side to <c>side+1</c> so downstream code doesn't get a zero/negative-
        /// area rectangle, which the mixer interprets as "hide this input" rather than "default".
        /// </summary>
        private Rect ReadRect()
        {
            int left = ParseIntOrDefault(edRectLeft, 0);
            int top = ParseIntOrDefault(edRectTop, 0);
            int right = ParseIntOrDefault(edRectRight, 640);
            int bottom = ParseIntOrDefault(edRectBottom, 480);

            if (right <= left)
            {
                right = left + 1;
            }

            if (bottom <= top)
            {
                bottom = top + 1;
            }

            return new Rect(left, top, right, bottom);
        }

        /// <summary>
        /// Compute the next unused ZOrder value as (max existing ZOrder) + 1. Using
        /// Input_Count() alone is insufficient because after a Remove + Add cycle the new
        /// index-based value can collide with a previously-assigned ZOrder still held by
        /// another input — two sources with the same ZOrder make stacking order undefined.
        /// </summary>
        private uint GetNextZOrder()
        {
            // Bail cleanly if the compositor isn't ready (InitSDK/CreateEngine failed). Without
            // this guard, Input_Count throws NRE and the outer menu catch surfaces it as a
            // confusing "Object reference not set" MessageBox.
            if (_compositor == null)
            {
                return 0;
            }

            uint maxZ = 0;
            bool any = false;
            var used = new System.Collections.Generic.HashSet<uint>();
            int count = _compositor.Input_Count();
            for (int i = 0; i < count; i++)
            {
                var input = _compositor.Input_Get(i);
                uint z;
                if (input is LVCVideoAudioInput vai)
                {
                    z = vai.ZOrder;
                }
                else if (input is LVCVideoInput vi)
                {
                    z = vi.ZOrder;
                }
                else
                {
                    // Non-video inputs (e.g. pure audio) don't participate in Z-stacking.
                    continue;
                }

                used.Add(z);
                if (!any || z > maxZ)
                {
                    maxZ = z;
                }
                any = true;
            }

            if (!any)
            {
                return 0;
            }

            // Normal path: max+1. If maxZ is already uint.MaxValue (only reachable after a very
            // long session of Add/Remove cycles on a compositor that never resets ZOrders), scan
            // for the first unused slot instead of overflowing to 0 and silently colliding with
            // an existing input.
            if (maxZ != uint.MaxValue)
            {
                return maxZ + 1;
            }

            for (uint candidate = 0; candidate < uint.MaxValue; candidate++)
            {
                if (!used.Contains(candidate))
                {
                    return candidate;
                }
            }

            // Compositor supports at most uint.MaxValue inputs in practice; if we got here every
            // slot is taken and the caller's Input_Add will fail anyway. Return 0 as a last
            // resort rather than overflowing the loop counter.
            return 0;
        }

        /// <summary>
        /// Add camera source async.
        /// </summary>
        private async Task AddCameraSourceAsync()
        {
            var dlg = new VideoCaptureSourceDialog();
            if (dlg.ShowDialog() == true)
            {
                VideoCaptureDeviceSourceSettings settings = null;

                var deviceName = dlg.Device;
                var format = dlg.Format;
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                    if (device != null)
                    {
                        var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                        if (formatItem != null)
                        {
                            settings = new VideoCaptureDeviceSourceSettings(device)
                            {
                                Format = formatItem.ToFormat()
                            };

                            settings.Format.FrameRate = dlg.FrameRate;
                        }
                    }
                }

                if (settings == null)
                {
                    MessageBox.Show(this, "Unable to configure video capture device.");
                    return;
                }

                var name = $"Camera [{dlg.Device}]";
                var rect = ReadRect();
                var videoInfo = new VideoFrameInfoX(settings.Format.Width, settings.Format.Height, settings.Format.FrameRate);
                var src = new LVCVideoInput(name, _compositor, new SystemVideoSourceBlock(settings), videoInfo, rect, true);
                try
                {
                    src.ZOrder = GetNextZOrder();

                    if (await _compositor.Input_AddAsync(src))
                    {
                        lbSources.Items.Add(name);
                        lbSources.SelectedIndex = lbSources.Items.Count - 1;
                    }
                    else
                    {
                        src.Dispose();
                    }
                }
                catch
                {
                    // Dispose the native input if anything between construction and successful
                    // Input_AddAsync throws — the compositor never took ownership, so the native
                    // resources would otherwise leak.
                    src.Dispose();
                    throw;
                }
            }
        }

        /// <summary>
        /// Add file source async.
        /// </summary>
        private async Task AddFileSourceAsync()
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                var filename = dlg.FileName;
                var name = $"File [{filename}]";
                var rect = ReadRect();
                var settings = await UniversalSourceSettings.CreateAsync(filename);

                // Extract the source-block creation + LVCVideoAudioInput ctor into a separate
                // try/catch. If LVCVideoAudioInput's ctor throws (bad info, mismatched streams)
                // the UniversalSourceBlock instance would otherwise leak — it's already
                // instantiated as an argument expression but never referenced again.
                UniversalSourceBlock sourceBlock = null;
                LVCVideoAudioInput src;
                try
                {
                    sourceBlock = new UniversalSourceBlock(settings);
                    src = new LVCVideoAudioInput(name, _compositor, sourceBlock, settings.GetInfo().GetVideoInfo(), settings.GetInfo().GetAudioInfo(), rect, autostart: true, live: false);
                }
                catch
                {
                    sourceBlock?.Dispose();
                    throw;
                }

                try
                {
                    src.ZOrder = GetNextZOrder();

                    if (await _compositor.Input_AddAsync(src))
                    {
                        lbSources.Items.Add(name);
                        lbSources.SelectedIndex = lbSources.Items.Count - 1;
                    }
                    else
                    {
                        src.Dispose();
                    }
                }
                catch
                {
                    src.Dispose();
                    throw;
                }
            }
        }

        /// <summary>
        /// Add screen source async.
        /// </summary>
        private async Task AddScreenSourceAsync()
        {
            var dlg = new ScreenSourceDialog();
            if (dlg.ShowDialog() == true)
            {
                // Fail fast on a zero-area capture region. An empty rectangle propagates to the
                // native ScreenCapture element as a 0x0 capture surface, which either crashes
                // the capture thread or streams empty frames that negotiate no caps downstream.
                if (dlg.Rectangle.Width <= 0 || dlg.Rectangle.Height <= 0)
                {
                    MessageBox.Show(this, $"Screen capture rectangle must have positive width and height (got {dlg.Rectangle.Width}x{dlg.Rectangle.Height}).", "Screen Source", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var settings = new ScreenCaptureDX9SourceSettings();
                settings.CaptureCursor = dlg.GrabMouseCursor;
                settings.Monitor = dlg.DisplayIndex;
                settings.FrameRate = dlg.FrameRate;
                settings.Rectangle = dlg.Rectangle;

                var rect = ReadRect();
                var name = $"Screen [{dlg.DisplayIndex}] {dlg.Rectangle.Width}x{dlg.Rectangle.Height}";
                var info = new VideoFrameInfoX(dlg.Rectangle.Width, dlg.Rectangle.Height, dlg.FrameRate);
                var src = new LVCVideoInput(name, _compositor, new ScreenSourceBlock(settings), info, rect, true);
                try
                {
                    src.ZOrder = GetNextZOrder();

                    if (await _compositor.Input_AddAsync(src))
                    {
                        lbSources.Items.Add(name);
                        lbSources.SelectedIndex = lbSources.Items.Count - 1;
                    }
                    else
                    {
                        src.Dispose();
                    }
                }
                catch
                {
                    src.Dispose();
                    throw;
                }
            }
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var resDialog = new ResolutionDialog();
                resDialog.Owner = this;
                resDialog.ShowDialog();

                _videoWidth = resDialog.GetWidth();
                _videoHeight = resDialog.GetHeight();
                _videoFrameRate = resDialog.GetFrameRate();
                _mixerType = resDialog.GetMixerType();

                lbResolution.Content = $"Video: {_videoWidth}x{_videoHeight}@{_videoFrameRate}fps";

                // We have to initialize the engine on start
                Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                this.IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                this.IsEnabled = true;
                Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

                CreateEngine();

                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                tmRecording.Elapsed += TmRecording_Elapsed;

                DeviceEnumerator.Shared.OnAudioSinkAdded += Shared_OnAudioSinkAdded;
                await DeviceEnumerator.Shared.StartAudioSinkMonitorAsync();

                VideoView1.SetNativeRendering(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Shared on audio sink added.
        /// </summary>
        private void Shared_OnAudioSinkAdded(object sender, AudioOutputDeviceInfo e)
        {
            if (Dispatcher.HasShutdownStarted || Dispatcher.HasShutdownFinished)
            {
                // Unsubscribe happens on Window_Closing, but this event may still be in-flight on
                // the enumerator's thread; bail so we don't post into a dead dispatcher.
                return;
            }

            Dispatcher.BeginInvoke((Action)(() =>
            {
                if (e.API == AudioOutputDeviceAPI.WASAPI2)
                {
                    cbAudioRenderer.Items.Add(e.Name);
                }

                // Only auto-select on the very first add so a later hot-plug (headset, HDMI
                // monitor) doesn't silently overwrite the user's chosen renderer.
                if (cbAudioRenderer.SelectedIndex == -1 && cbAudioRenderer.Items.Count > 0)
                {
                    cbAudioRenderer.SelectedIndex = 0;
                }
            }));
        }

        /// <summary>
        /// Named handler for the recording timer Elapsed event so it can be unsubscribed
        /// during window teardown to avoid leaking the closure (which holds `this`).
        /// </summary>
        private void TmRecording_Elapsed(object senderx, System.Timers.ElapsedEventArgs args)
        {
            UpdateRecordingTime();
        }

        /// <summary>
        /// Update recording time.
        /// </summary>
        private async void UpdateRecordingTime()
        {
            // Capture _compositor into a local to avoid racing with btStop_Click / Window_Closing,
            // which null out the field while an in-flight tick is awaiting DurationAsync.
            var c = _compositor;
            if (c == null || _isClosing)
            {
                return;
            }

            try
            {
                var ts = await c.DurationAsync();

                if (Math.Abs(ts.TotalMilliseconds) < 0.01)
                {
                    return;
                }

                // The dispatcher may have begun shutdown between the await and this post — posting
                // into a shutting-down dispatcher either no-ops or throws InvalidOperationException.
                // The explicit check avoids the noise of a caught-and-logged exception per tick.
                if (_isClosing || Dispatcher.HasShutdownStarted || Dispatcher.HasShutdownFinished)
                {
                    return;
                }

                Dispatcher.BeginInvoke((Action)(() =>
                {
                    lbTimestamp.Content = ts.ToString(@"hh\:mm\:ss");
                }));
            }
            catch (ObjectDisposedException)
            {
                // Compositor was disposed between the null-check and the await — safe to swallow.
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            // No compositor means Window_Loaded's InitSDKAsync / CreateEngine() failed.
            // Bail before touching _compositor.Settings so the user sees a disabled feature
            // instead of a silently-swallowed NRE.
            if (_compositor == null)
            {
                return;
            }

            // Disable both buttons to prevent re-entrant Start / premature Stop while the
            // StartAsync pipeline transition is still in flight.
            btStart.IsEnabled = false;
            btStop.IsEnabled = false;
            try
            {
                _compositor.Settings.VideoView = VideoView1;

                // Use FirstOrDefault so a disconnected / missing device name doesn't throw
                // InvalidOperationException and get swallowed by the outer catch — which would
                // leave the user staring at a silent failure with no feedback.
                var audioRenderer = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.WASAPI2))
                    .FirstOrDefault(x => x.Name == cbAudioRenderer.Text);
                if (audioRenderer == null)
                {
                    MessageBox.Show($"Audio output '{cbAudioRenderer.Text}' is not available. Please select another device.");
                    return;
                }

                // Dispose the previous AudioRendererBlock before replacing it. If StartAsync
                // previously threw and the user clicked Start again, the prior instance would
                // otherwise be orphaned (DestroyEngine is only called from Stop). Local var makes
                // the ownership transfer explicit for the reader.
                var previousAudioOutput = _compositor.Settings.AudioOutput;
                _compositor.Settings.AudioOutput = new AudioRendererBlock(audioRenderer);
                (previousAudioOutput as IDisposable)?.Dispose();

                await _compositor.StartAsync();

                volumeMeterL.Start();
                volumeMeterR.Start();
                // tmRecording may have been disposed+nulled by Window_Closing before a queued click arrives.
                tmRecording?.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                btStart.IsEnabled = true;
                btStop.IsEnabled = true;
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            // No compositor means SDK init never completed; the buttons should stay enabled for
            // diagnostics and we should not NRE on _compositor.StopAsync().
            if (_compositor == null)
            {
                return;
            }

            // Disable both buttons to prevent re-entrant Stop / premature Start while the
            // StopAsync pipeline transition is still in flight.
            btStart.IsEnabled = false;
            btStop.IsEnabled = false;
            try
            {
                // tmRecording may have been disposed+nulled by Window_Closing before a queued click arrives.
                tmRecording?.Stop();

                volumeMeterL.Stop();
                volumeMeterL.Clear();
                volumeMeterR.Stop();
                volumeMeterR.Clear();

                try
                {
                    await _compositor.StopAsync();
                }
                finally
                {
                    // Always tear down + recreate and clear the lists even if StopAsync throws,
                    // otherwise the UI is left referencing a half-stopped compositor and the source/
                    // output listboxes show stale items that no longer map to any real input/output.
                    DestroyEngine();
                    CreateEngine();

                    lbOutputs.Items.Clear();
                    lbSources.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                btStart.IsEnabled = true;
                btStop.IsEnabled = true;
            }
        }

        /// <summary>
        /// Handles the bt update source click event.
        /// </summary>
        private void btUpdateSource_Click(object sender, RoutedEventArgs e)
        {
            // Button is enabled during the brief Stop→DestroyEngine→CreateEngine window where
            // _compositor is briefly null; guard explicitly so a stale click doesn't NRE.
            if (_compositor == null)
            {
                return;
            }

            int index = lbSources.SelectedIndex;
            if (index != -1)
            {
                var rect = ReadRect();

                // Show an explicit error on unparseable ZOrder rather than silently defaulting
                // to 0, which would hide the source behind every other input with no feedback.
                if (!uint.TryParse(edZOrder?.Text, out var zOrder))
                {
                    MessageBox.Show(this, $"Invalid ZOrder value '{edZOrder?.Text}'. Enter a non-negative integer.", "Update Source", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

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
                    // we have playback started and can change the rect
                    stream.Rectangle = rect;
                    stream.ZOrder = zOrder;
                    _compositor.Input_VideoStream_Update(stream);
                }
            }
        }

        /// <summary>
        /// Add mp 4 output async.
        /// </summary>
        private async Task AddMP4OutputAsync()
        {
            var now = System.DateTime.Now;
            var name = $"output_{now.Year}_{now.Month}_{now.Day}_{now.Hour}_{now.Minute}_{now.Second}.mp4";
            var outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), name);
            var mp4Output = new MP4OutputBlock(new MP4SinkSettings(outputFile), new OpenH264EncoderSettings(), new MFAACEncoderSettings());

            var output = new LVCVideoAudioOutput(outputFile, _compositor, mp4Output, autostart: true);

            if (await _compositor.Output_AddAsync(output))
            {
                lbOutputs.Items.Add(outputFile);
                lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
            }
            else
            {
                output.Dispose();
            }
        }

        /// <summary>
        /// Add decklink video output async.
        /// </summary>
        private async Task AddDecklinkVideoOutputAsync()
        {
            // Decklink video output
            var dlg = new DecklinkVideoOutputDialog();
            if (dlg.ShowDialog() == true)
            {
                var rect = ReadRect();

               DecklinkVideoAudioSinkBlock _decklinkOutputBlock;

                var videoSettings = await dlg.GetVideoDeviceSettingsAsync();
                var audioSettings = await dlg.GetAudioDeviceSettingsAsync();
                var name = $"Decklink Out V{dlg.VideoDevice}:A{dlg.AudioDevice}";

                _decklinkOutputBlock = new DecklinkVideoAudioSinkBlock(videoSettings, audioSettings);

                var decklinkOutput = new LVCVideoAudioOutput(name, _compositor, _decklinkOutputBlock, autostart: true);


                if (await _compositor.Output_AddAsync(decklinkOutput))
                {
                    lbOutputs.Items.Add(name);
                    lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
                }
                else
                {
                    decklinkOutput.Dispose();
                }
            }
        }

        /// <summary>
        /// Add web m output async.
        /// </summary>
        private async Task AddWebMOutputAsync()
        {
            var now = System.DateTime.Now;
            var name = $"output_{now.Year}_{now.Month}_{now.Day}_{now.Hour}_{now.Minute}_{now.Second}.webm";
            var outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), name);
            var webmOutput = new WebMOutputBlock(new WebMSinkSettings(outputFile), new VP8EncoderSettings(), new VorbisEncoderSettings());
            var output = new LVCVideoAudioOutput(outputFile, _compositor, webmOutput, false);

            if (await _compositor.Output_AddAsync(output))
            {
                lbOutputs.Items.Add(outputFile);
                lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
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
            var now = System.DateTime.Now;
            var name = $"output_{now.Year}_{now.Month}_{now.Day}_{now.Hour}_{now.Minute}_{now.Second}.mp3";
            var outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), name);
            var mp3Output = new MP3OutputBlock(outputFile, new MP3EncoderSettings());
            var output = new LVCAudioOutput(outputFile, _compositor, mp3Output, false);

            if (await _compositor.Output_AddAsync(output))
            {
                lbOutputs.Items.Add(outputFile);
                lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
            }
            else
            {
                output.Dispose();
            }
        }

        private async Task AddYouTubeOutputAsync()
        {
            var dlg = new StreamingKeyDialog("YouTube Live");
            if (dlg.ShowDialog() == true)
            {
                // StreamingKeyDialog.Key can be null/empty when the user OKs an untouched text
                // box — the original code called Substring on that and NRE'd, surfacing as a
                // confusing "Object reference not set" MessageBox from the menu-level catch.
                if (string.IsNullOrEmpty(dlg.Key))
                {
                    MessageBox.Show(this, "YouTube stream key is required.", "YouTube Live", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var name = $"YouTube [{dlg.Key.Substring(0, Math.Min(8, dlg.Key.Length))}...]";
                var outputBlock = new YouTubeOutputBlock(
                    new YouTubeSinkSettings(dlg.Key),
                    new OpenH264EncoderSettings(),
                    new MFAACEncoderSettings());
                var output = new LVCVideoAudioOutput(name, _compositor, outputBlock, autostart: true);

                if (await _compositor.Output_AddAsync(output))
                {
                    lbOutputs.Items.Add(name);
                    lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
                }
                else
                {
                    output.Dispose();
                }
            }
        }

        private async Task AddFacebookLiveOutputAsync()
        {
            var dlg = new StreamingKeyDialog("Facebook Live");
            if (dlg.ShowDialog() == true)
            {
                if (string.IsNullOrEmpty(dlg.Key))
                {
                    MessageBox.Show(this, "Facebook stream key is required.", "Facebook Live", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var name = $"Facebook [{dlg.Key.Substring(0, Math.Min(8, dlg.Key.Length))}...]";
                var outputBlock = new FacebookLiveOutputBlock(
                    new FacebookLiveSinkSettings(dlg.Key),
                    new OpenH264EncoderSettings(),
                    new MFAACEncoderSettings());
                var output = new LVCVideoAudioOutput(name, _compositor, outputBlock, autostart: true);

                if (await _compositor.Output_AddAsync(output))
                {
                    lbOutputs.Items.Add(name);
                    lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
                }
                else
                {
                    output.Dispose();
                }
            }
        }

        private async Task AddVirtualCameraOutputAsync()
        {
            var vcSettings = new VirtualCameraSinkSettings();
            var vcBlock = new VirtualCameraSinkBlock(vcSettings);
            var name = "Virtual Camera";
            var output = new LVCVideoAudioOutput(name, _compositor, vcBlock, autostart: true);

            if (await _compositor.Output_AddAsync(output))
            {
                lbOutputs.Items.Add(name);
                lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
            }
            else
            {
                output.Dispose();
            }
        }

        /// <summary>
        /// Add audio source async.
        /// </summary>
        private const AudioCaptureDeviceAPI _audioSourceApi = AudioCaptureDeviceAPI.WASAPI2;

        private async Task AddAudioSourceAsync()
        {
            var dlg = new AudioCaptureSourceDialog(_audioSourceApi);
            if (dlg.ShowDialog() == true)
            {
                IAudioCaptureDeviceSourceSettings settings = null;
                AudioCaptureDeviceFormat deviceFormat = null;

                var deviceName = dlg.Device;
                var format = dlg.Format;
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = (await DeviceEnumerator.Shared.AudioSourcesAsync(_audioSourceApi)).FirstOrDefault(x => x.DisplayName == deviceName);
                    if (device != null)
                    {
                        var formatItem = device.Formats.FirstOrDefault(x => x.Name == format);
                        if (formatItem != null)
                        {
                            deviceFormat = formatItem.ToFormat();
                            settings = device.CreateSourceSettings(deviceFormat);
                        }
                    }
                }

                if (settings == null)
                {
                    MessageBox.Show(this, "Unable to configure audio capture device.");
                    return;
                }

                var name = $"Audio source [{dlg.Device}]";
                var info = new AudioInfoX(deviceFormat.Format, deviceFormat.SampleRate, deviceFormat.Channels);
                var src = new LVCAudioInput(name, _compositor, new SystemAudioSourceBlock(settings), info, true);
                try
                {
                    if (await _compositor.Input_AddAsync(src))
                    {
                        lbSources.Items.Add(name);
                        lbSources.SelectedIndex = lbSources.Items.Count - 1;
                    }
                    else
                    {
                        src.Dispose();
                    }
                }
                catch
                {
                    src.Dispose();
                    throw;
                }
            }
        }

        /// <summary>
        /// Add audio virtual async.
        /// </summary>
        private async Task AddAudioVirtualAsync()
        {
            var name = "Audio source [Virtual]";
            var settings = new VirtualAudioSourceSettings();
            var info = new AudioInfoX(settings.Format, settings.SampleRate, settings.Channels);
            var src = new LVCAudioInput(name, _compositor, new VirtualAudioSourceBlock(settings), info, true);
            try
            {
                if (await _compositor.Input_AddAsync(src))
                {
                    lbSources.Items.Add(name);
                    lbSources.SelectedIndex = lbSources.Items.Count - 1;
                }
                else
                {
                    src.Dispose();
                }
            }
            catch
            {
                src.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Add video virtual async.
        /// </summary>
        private async Task AddVideoVirtualAsync()
        {
            var rect = ReadRect();

            var name = $"Video source [Virtual] {_compositor.Input_Count()}";
            var settings = new VirtualVideoSourceSettings();
            var info = new VideoFrameInfoX(settings.Width, settings.Height, settings.FrameRate);
            var src = new LVCVideoInput(name, _compositor, new VirtualVideoSourceBlock(settings), info, rect, true);
            try
            {
                src.ZOrder = GetNextZOrder();

                if (await _compositor.Input_AddAsync(src))
                {
                    lbSources.Items.Add(name);
                    lbSources.SelectedIndex = lbSources.Items.Count - 1;
                }
                else
                {
                    src.Dispose();
                }
            }
            catch
            {
                src.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Add video static image async.
        /// </summary>
        private async Task AddVideoStaticImageAsync()
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (dlg.ShowDialog(this) == true)
            {
                var rect = ReadRect();

                var name = $"Video source [Static image] {_compositor.Input_Count()}";
                var settings = new ImageVideoSourceSettings(dlg.FileName);
                var info = new VideoFrameInfoX(settings.Width, settings.Height, settings.FrameRate);
                var src = new LVCVideoInput(name, _compositor, new ImageVideoSourceBlock(settings), info, rect, true);
                try
                {
                    src.ZOrder = GetNextZOrder();

                    if (await _compositor.Input_AddAsync(src))
                    {
                        lbSources.Items.Add(name);
                        lbSources.SelectedIndex = lbSources.Items.Count - 1;
                    }
                    else
                    {
                        src.Dispose();
                    }
                }
                catch
                {
                    src.Dispose();
                    throw;
                }
            }
        }

        /// <summary>
        /// Add decklink video source async.
        /// </summary>
        private async Task AddDecklinkVideoSourceAsync()
        {
            // Decklink video source
            var dlg = new DecklinkVideoSourceDialog();
            if (dlg.ShowDialog() == true)
            {
                var rect = ReadRect();

                var videoSettings = await dlg.GetVideoDeviceSettingsAsync();
                videoSettings.DisableVideoConversion = true;

                var audioSettings = await dlg.GetAudioDeviceSettingsAsync();
                audioSettings.DisableAudioConversion = true;

                var name = $"Decklink source [{videoSettings.DeviceNumber}]";

                var sourceBlock = new DecklinkVideoAudioSourceBlock(videoSettings, audioSettings);

                DecklinkHelper.GetVideoInfoFromMode(videoSettings.Mode, out int width, out int height, out VideoFrameRate frameRate);
                var videoInfo = new VideoFrameInfoX(width, height, frameRate);
                var audioInfo = new AudioInfoX(DecklinkHelper.ToFormat(audioSettings.Format), audioSettings.SampleRate, (int)audioSettings.Channels);
                var videoSrc = new LVCVideoAudioInput(name, _compositor, sourceBlock, videoInfo, audioInfo, rect, true);
                try
                {
                    videoSrc.ZOrder = GetNextZOrder();

                    if (await _compositor.Input_AddAsync(videoSrc))
                    {
                        lbSources.Items.Add(name);
                        lbSources.SelectedIndex = lbSources.Items.Count - 1;
                    }
                    else
                    {
                        videoSrc.Dispose();
                    }
                }
                catch
                {
                    videoSrc.Dispose();
                    throw;
                }
            }
        }

        /// <summary>
        /// Add RTSP source async.
        /// </summary>
        private async Task AddRTSPSourceAsync()
        {
            var dlg = new RTSPSourceDialog();
            dlg.Owner = this;
            if (dlg.ShowDialog() == true)
            {
                var rect = ReadRect();

                this.IsEnabled = false;
                var originalTitle = this.Title;
                this.Title = $"{originalTitle} - Connecting to RTSP source...";

                try
                {
                    var rtspSettings = await RTSPSourceSettings.CreateAsync(
                        new Uri(dlg.URL),
                        dlg.Login,
                        dlg.Password,
                        dlg.AudioEnabled);

                    if (rtspSettings == null)
                    {
                        MessageBox.Show(this, "Unable to connect to RTSP source. Please check the URL and credentials.", "RTSP Source Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var info = rtspSettings.GetInfo();
                    if (info == null || info.VideoStreams.Count == 0)
                    {
                        MessageBox.Show(this, "RTSP source does not contain video streams.", "RTSP Source Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var name = $"RTSP [{dlg.URL}]";
                    var sourceBlock = new RTSPSourceBlock(rtspSettings);
                    var videoInfo = info.GetVideoInfo();

                    if (dlg.AudioEnabled && info.AudioStreams.Count > 0)
                    {
                        var audioInfo = info.GetAudioInfo();
                        var src = new LVCVideoAudioInput(name, _compositor, sourceBlock, videoInfo, audioInfo, rect, autostart: true, live: true);
                        try
                        {
                            src.ZOrder = GetNextZOrder();

                            if (await _compositor.Input_AddAsync(src))
                            {
                                lbSources.Items.Add(name);
                                lbSources.SelectedIndex = lbSources.Items.Count - 1;
                            }
                            else
                            {
                                src.Dispose();
                            }
                        }
                        catch
                        {
                            src.Dispose();
                            throw;
                        }
                    }
                    else
                    {
                        var src = new LVCVideoInput(name, _compositor, sourceBlock, videoInfo, rect, autostart: true);
                        try
                        {
                            src.ZOrder = GetNextZOrder();

                            if (await _compositor.Input_AddAsync(src))
                            {
                                lbSources.Items.Add(name);
                                lbSources.SelectedIndex = lbSources.Items.Count - 1;
                            }
                            else
                            {
                                src.Dispose();
                            }
                        }
                        catch
                        {
                            src.Dispose();
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"Error connecting to RTSP source: {ex.Message}", "RTSP Source Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    this.IsEnabled = true;
                    this.Title = originalTitle;
                }
            }
        }

        /// <summary>
        /// Add ndi source async.
        /// </summary>
        private async Task AddNDISourceAsync()
        {
            var dlg = new NDISourceDialog();
            dlg.Owner = this;
            if (dlg.ShowDialog() == true && dlg.SelectedSource != null)
            {
                var rect = ReadRect();

                // Show progress while retrieving NDI source info
                this.IsEnabled = false;
                var originalTitle = this.Title;
                this.Title = $"{originalTitle} - Connecting to NDI source...";

                try
                {
                    // Create a temporary context for NDI source info retrieval
                    var context = new ContextX();
                    var ndiSettings = await NDISourceSettings.CreateAsync(context, dlg.SelectedSource);
                    
                    if (ndiSettings == null || !ndiSettings.IsValid())
                    {
                        MessageBox.Show(this, "Selected NDI source is not valid or not available. Please ensure the NDI source is active and streaming.", "NDI Source Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                var name = $"NDI [{dlg.SelectedSource.Name}]";
                var sourceBlock = new NDISourceBlock(ndiSettings);
                
                var info = ndiSettings.GetInfo();
                if (info != null && info.VideoStreams.Count > 0)
                {
                    var videoInfo = info.GetVideoInfo();
                    AudioInfoX audioInfo = null;
                    
                    if (info.AudioStreams.Count > 0)
                    {
                        audioInfo = info.GetAudioInfo();
                    }

                    if (audioInfo != null)
                    {
                        var src = new LVCVideoAudioInput(name, _compositor, sourceBlock, videoInfo, audioInfo, rect, autostart: true, live: true);
                        try
                        {
                            src.ZOrder = GetNextZOrder();

                            if (await _compositor.Input_AddAsync(src))
                            {
                                lbSources.Items.Add(name);
                                lbSources.SelectedIndex = lbSources.Items.Count - 1;
                            }
                            else
                            {
                                src.Dispose();
                            }
                        }
                        catch
                        {
                            src.Dispose();
                            throw;
                        }
                    }
                    else
                    {
                        var src = new LVCVideoInput(name, _compositor, sourceBlock, videoInfo, rect, autostart: true);
                        try
                        {
                            src.ZOrder = GetNextZOrder();

                            if (await _compositor.Input_AddAsync(src))
                            {
                                lbSources.Items.Add(name);
                                lbSources.SelectedIndex = lbSources.Items.Count - 1;
                            }
                            else
                            {
                                src.Dispose();
                            }
                        }
                        catch
                        {
                            src.Dispose();
                            throw;
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, "NDI source does not contain video streams.", "NDI Source Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                }
                finally
                {
                    // Restore window state regardless of outcome. Exception propagation is handled
                    // by RunAddSourceGuardedAsync's catch, matching the other Add*SourceAsync
                    // helpers (single MessageBox instead of the previous double-dialog for NDI).
                    this.IsEnabled = true;
                    this.Title = originalTitle;
                }
            }
        }

        /// <summary>
        /// Handles the bt add source click event.
        /// </summary>
        // Guard flag preventing two Add-source operations from running against the same
        // compositor concurrently. Set at the top of each menu click handler, cleared in finally.
        private bool _addSourceInFlight;

        /// <summary>
        /// Wraps an Add*SourceAsync invocation with the <see cref="_addSourceInFlight"/> guard so
        /// rapid double-clicks on menu items can't race two Input_AddAsync calls against the
        /// compositor.
        /// </summary>
        private async Task RunAddSourceGuardedAsync(Func<Task> addAction)
        {
            if (_addSourceInFlight)
            {
                return;
            }

            _addSourceInFlight = true;
            try
            {
                await addAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _addSourceInFlight = false;
            }
        }

        // Cached Add-source context menu. Rebuilt once lazily on first click; every rebuild
        // costs a fresh ContextMenu + MenuItem closures that each capture `this`, and the click
        // wiring is immutable once the engine is up, so reuse is a straight win for churn and
        // for making the handler callable before InitSDK finishes.
        private ContextMenu _addSourceContextMenu;

        private ContextMenu BuildAddSourceContextMenu()
        {
            var ctx = new ContextMenu();

            var miScreen = new MenuItem() { Header = "Screen source" };
            miScreen.Click += async (senderm, args) => await RunAddSourceGuardedAsync(AddScreenSourceAsync);

            var miCamera = new MenuItem() { Header = "Camera source" };
            miCamera.Click += async (senderm, args) => await RunAddSourceGuardedAsync(AddCameraSourceAsync);

            var miFile = new MenuItem() { Header = "File source" };
            miFile.Click += async (senderm, args) => await RunAddSourceGuardedAsync(AddFileSourceAsync);

            var miAudioSource = new MenuItem() { Header = "Audio source" };
            miAudioSource.Click += async (senderm, args) => await RunAddSourceGuardedAsync(AddAudioSourceAsync);

            var miAudioVirtual = new MenuItem() { Header = "Virtual audio" };
            miAudioVirtual.Click += async (senderm, args) => await RunAddSourceGuardedAsync(AddAudioVirtualAsync);

            var miVideoVirtual = new MenuItem() { Header = "Virtual video" };
            miVideoVirtual.Click += async (senderm, args) => await RunAddSourceGuardedAsync(AddVideoVirtualAsync);

            var miStaticImage = new MenuItem() { Header = "Static image" };
            miStaticImage.Click += async (senderm, args) => await RunAddSourceGuardedAsync(AddVideoStaticImageAsync);

            var miDecklinkSource = new MenuItem() { Header = "Decklink source" };
            miDecklinkSource.Click += async (senderm, args) => await RunAddSourceGuardedAsync(AddDecklinkVideoSourceAsync);

            var miNDISource = new MenuItem() { Header = "NDI source" };
            miNDISource.Click += async (senderm, args) => await RunAddSourceGuardedAsync(AddNDISourceAsync);

            var miRTSPSource = new MenuItem() { Header = "RTSP source" };
            miRTSPSource.Click += async (senderm, args) => await RunAddSourceGuardedAsync(AddRTSPSourceAsync);

            ctx.Items.Add(miScreen);
            ctx.Items.Add(miCamera);
            ctx.Items.Add(miFile);
            ctx.Items.Add(miVideoVirtual);
            ctx.Items.Add(miStaticImage);
            ctx.Items.Add(new Separator());
            ctx.Items.Add(miAudioSource);
            ctx.Items.Add(miAudioVirtual);
            ctx.Items.Add(new Separator());
            ctx.Items.Add(miDecklinkSource);
            ctx.Items.Add(miNDISource);
            ctx.Items.Add(miRTSPSource);
            return ctx;
        }

        private void btAddSource_Click(object sender, RoutedEventArgs e)
        {
            // Refuse to open the menu if the engine isn't up yet — every Add* handler dereferences
            // _compositor unconditionally. Keeping the button disabled until Loaded is the proper
            // UX fix; this is a defensive backstop.
            if (_compositor == null)
            {
                return;
            }

            if (_addSourceContextMenu == null)
            {
                _addSourceContextMenu = BuildAddSourceContextMenu();
            }

            var ctx = _addSourceContextMenu;
            ctx.PlacementTarget = sender as Button;
            ctx.IsOpen = true;
        }

        /// <summary>
        /// Handles the bt remove source click event.
        /// </summary>
        private async void btRemoveSource_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbSources.SelectedIndex != -1)
                {
                    var index = lbSources.SelectedIndex;
                    var input = _compositor.Input_Get(index);
                    if (input != null)
                    {
                        await _compositor.Input_RemoveAsync(input.ID);
                    }
                    lbSources.Items.RemoveAt(index);

                    // If the list is now empty, SelectionChanged fires with -1 and
                    // UpdateSourceSelectionAsync bails early — leaving btPauseResume, tbSeeking,
                    // and the rect/zorder TextBoxes showing stale values for the removed source.
                    // Reset them explicitly so the UI reflects "no source selected".
                    if (lbSources.Items.Count == 0)
                    {
                        btPauseResume.IsEnabled = false;
                        icPauseResume.Kind = MaterialDesignThemes.Wpf.PackIconKind.Pause;

                        tbSeeking.IsEnabled = false;
                        _isProgrammaticSliderWrite = true;
                        try
                        {
                            tbSeeking.Value = 0;
                        }
                        finally
                        {
                            _isProgrammaticSliderWrite = false;
                        }

                        edRectLeft.Text = string.Empty;
                        edRectTop.Text = string.Empty;
                        edRectRight.Text = string.Empty;
                        edRectBottom.Text = string.Empty;
                        edZOrder.Text = string.Empty;
                        edRectLeft.IsEnabled = edRectTop.IsEnabled = edRectRight.IsEnabled = edRectBottom.IsEnabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Update source selection async.
        /// </summary>
        private async Task UpdateSourceSelectionAsync()
        {
            if (lbSources.SelectedIndex == -1)
            {
                return;
            }

            // Capture selection at entry so we can abort if the user selects a different
            // source while the async duration/position queries are in flight — otherwise
            // we would mutate UI (icon, slider) to reflect a source that is no longer selected.
            int capturedIndex = lbSources.SelectedIndex;
            int capturedGeneration = ++_updateSourceSelectionGeneration;

            _timelineSeeking = false;
            try
            {
                var inputSource = _compositor.Input_Get(capturedIndex);
                if (inputSource == null)
                {
                    // Input_Get returns null when the index is out of range, which happens after a
                    // concurrent Remove. Input_VideoStream_Get(null) dereferences input.ID on the
                    // SDK side and NREs, so bail before the call instead of letting the catch in
                    // lbSources_SelectionChanged swallow the exception (which leaves the UI in a
                    // half-updated state: seeking flag flipped, rect textboxes not populated).
                    return;
                }

                var input = _compositor.Input_VideoStream_Get(inputSource);

                bool isVideo = inputSource is LVCVideoAudioInput || inputSource is LVCVideoInput;
                edRectLeft.IsEnabled = edRectTop.IsEnabled = edRectRight.IsEnabled = edRectBottom.IsEnabled = isVideo;

                if (input != null)
                {
                    edRectLeft.Text = input.Rectangle.Left.ToString();
                    edRectTop.Text = input.Rectangle.Top.ToString();
                    edRectRight.Text = input.Rectangle.Right.ToString();
                    edRectBottom.Text = input.Rectangle.Bottom.ToString();
                    edZOrder.Text = input.ZOrder.ToString();
                }

                if (inputSource != null && inputSource.IsSeekable)
                {
                    // Prefer the cached MediaFileInfo duration populated by
                    // UniversalSourceSettings.CreateAsync — it is authoritative for the whole
                    // file and available BEFORE the input sub-pipeline has finished prerolling.
                    // Querying the live pipeline (DurationAsync) races with preroll and
                    // frequently returns 0 / GST_CLOCK_TIME_NONE right after Input_AddAsync,
                    // which left tbSeeking.Maximum stuck at 0 and broke seek.
                    TimeSpan duration = TimeSpan.Zero;
                    if (inputSource.MainBlock is UniversalSourceBlock usb)
                    {
                        var container = usb.Settings?.GetInfo()?.Container;
                        if (container != null && container.Duration > TimeSpan.Zero)
                        {
                            duration = container.Duration;
                        }
                    }

                    if (duration <= TimeSpan.Zero)
                    {
                        duration = await inputSource.Pipeline.DurationAsync();
                        if (lbSources.SelectedIndex != capturedIndex || _updateSourceSelectionGeneration != capturedGeneration)
                        {
                            // Selection changed mid-flight — abort without mutating the icon.
                            return;
                        }
                    }

                    var position = await inputSource.Pipeline.Position_GetAsync();
                    if (lbSources.SelectedIndex != capturedIndex || _updateSourceSelectionGeneration != capturedGeneration)
                    {
                        return;
                    }

                    tbSeeking.IsEnabled = true;

                    // Wrap the programmatic writes in `_isProgrammaticSliderWrite` so the
                    // ValueChanged handler can positively identify and skip them. Setting Maximum
                    // can coerce Value into range, which also fires ValueChanged; that's why
                    // both writes sit inside the same guarded region.
                    _isProgrammaticSliderWrite = true;
                    try
                    {
                        // Live/unknown durations report GST_CLOCK_TIME_NONE as a negative TimeSpan.
                        // WPF Slider throws ArgumentException on negative Maximum, and a NaN
                        // Position slips through identically. Clamp both to [0, Maximum].
                        double durationSec = duration.TotalSeconds;
                        double positionSec = position.TotalSeconds;
                        double max = !double.IsNaN(durationSec) && !double.IsInfinity(durationSec) && durationSec > 0 ? durationSec : 0;
                        tbSeeking.Maximum = max;
                        tbSeeking.Value = !double.IsNaN(positionSec) && !double.IsInfinity(positionSec) && positionSec >= 0
                            ? Math.Min(positionSec, max)
                            : 0;
                    }
                    finally
                    {
                        _isProgrammaticSliderWrite = false;
                    }

                    btPauseResume.IsEnabled = true;
                    icPauseResume.Kind = inputSource.Pipeline.State == PlaybackState.Pause
                        ? MaterialDesignThemes.Wpf.PackIconKind.Play
                        : MaterialDesignThemes.Wpf.PackIconKind.Pause;
                }
                else
                {
                    tbSeeking.IsEnabled = false;

                    _isProgrammaticSliderWrite = true;
                    try
                    {
                        tbSeeking.Value = 0;
                    }
                    finally
                    {
                        _isProgrammaticSliderWrite = false;
                    }

                    btPauseResume.IsEnabled = false;
                    icPauseResume.Kind = MaterialDesignThemes.Wpf.PackIconKind.Pause;
                }
            }
            finally
            {
                // Only restore the seeking flag if we're still the latest invocation. If a newer
                // SelectionChanged fired and reset the generation, that newer run has taken
                // ownership of `_timelineSeeking` and will restore it itself; flipping it here
                // would set it true while the newer run is still mid-critical-section.
                if (_updateSourceSelectionGeneration == capturedGeneration)
                {
                    _timelineSeeking = true;
                }
            }
        }

        /// <summary>
        /// Bt pause/resume click.
        /// </summary>
        private async void btPauseResume_Click(object sender, RoutedEventArgs e)
        {
            if (_compositor == null)
            {
                return;
            }

            // Guard against re-entrancy while the async pause/resume is still in flight.
            btPauseResume.IsEnabled = false;
            int capturedIndex = lbSources.SelectedIndex;
            LVCInput inputSource = null;
            try
            {
                if (capturedIndex == -1)
                {
                    return;
                }

                inputSource = _compositor.Input_Get(capturedIndex);
                // Pipeline can be null for certain input types or during state transitions; guard
                // the direct access below to avoid NRE from a stale/removed input.
                if (inputSource == null || !inputSource.IsSeekable || inputSource.Pipeline == null)
                {
                    return;
                }

                // Gate: only Pause when actually playing, only Resume when actually paused.
                var preState = inputSource.Pipeline.State;
                if (preState == PlaybackState.Pause)
                {
                    await inputSource.ResumeAsync();
                }
                else if (preState == PlaybackState.Play)
                {
                    await inputSource.PauseAsync();
                }
            }
            catch (Exception ex)
            {
                // Do not mutate the icon on failure; the finally block will re-query actual state.
                Debug.WriteLine(ex);
            }
            finally
            {
                // Selection may have changed (or the input been removed/disposed) while awaiting;
                // don't touch the icon for a source that's no longer selected, and don't force the
                // button enabled for a non-seekable source — UpdateSourceSelectionAsync owns that.
                //
                // Re-query Input_Get on the still-valid capturedIndex rather than reusing the
                // stashed `inputSource` local: if the user removed the input between the pre-state
                // read and this finally, the stashed reference points at a disposed LVCInput
                // whose Pipeline.State access throws ObjectDisposedException. The re-query gives
                // us either a fresh live reference or null (compositor replaced / index gone).
                if (_compositor != null && lbSources.SelectedIndex == capturedIndex)
                {
                    LVCInput current = null;
                    try { current = _compositor.Input_Get(capturedIndex); } catch { /* compositor torn down mid-await */ }

                    if (current != null && current.IsSeekable && current.Pipeline != null)
                    {
                        try
                        {
                            // Reflect the actual post-await state rather than the optimistic pre-await guess.
                            icPauseResume.Kind = current.Pipeline.State == PlaybackState.Pause
                                ? MaterialDesignThemes.Wpf.PackIconKind.Play
                                : MaterialDesignThemes.Wpf.PackIconKind.Pause;
                        }
                        catch (Exception ex2)
                        {
                            Debug.WriteLine(ex2);
                        }

                        btPauseResume.IsEnabled = true;
                    }
                    // Non-seekable, removed, or Pipeline-less: leave the button disabled; the next
                    // selection change will ask UpdateSourceSelectionAsync to re-enable it properly.
                }
            }
        }

        /// <summary>
        /// Lb sources selection changed.
        /// </summary>
        private async void lbSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                await UpdateSourceSelectionAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt add output click event.
        /// </summary>
        // Cached Add-output context menu; see _addSourceContextMenu for rationale.
        private ContextMenu _addOutputContextMenu;

        private ContextMenu BuildAddOutputContextMenu()
        {
            var ctx = new ContextMenu();

            var miMP4 = new MenuItem() { Header = "MP4 file" };
            miMP4.Click += async (senderm, args) => await RunAddOutputGuardedAsync(AddMP4OutputAsync);

            var miWebM = new MenuItem() { Header = "WebM file" };
            miWebM.Click += async (senderm, args) => await RunAddOutputGuardedAsync(AddWebMOutputAsync);

            var miMP3 = new MenuItem() { Header = "MP3 file" };
            miMP3.Click += async (senderm, args) => await RunAddOutputGuardedAsync(AddMP3OutputAsync);

            var miDecklink = new MenuItem() { Header = "Decklink device" };
            miDecklink.Click += async (senderm, args) => await RunAddOutputGuardedAsync(AddDecklinkVideoOutputAsync);

            var miYouTube = new MenuItem() { Header = "YouTube Live" };
            miYouTube.Click += async (senderm, args) => await RunAddOutputGuardedAsync(AddYouTubeOutputAsync);

            var miFacebook = new MenuItem() { Header = "Facebook Live" };
            miFacebook.Click += async (senderm, args) => await RunAddOutputGuardedAsync(AddFacebookLiveOutputAsync);

            ctx.Items.Add(miMP4);
            ctx.Items.Add(miWebM);
            ctx.Items.Add(miMP3);
            ctx.Items.Add(new Separator());
            ctx.Items.Add(miDecklink);
            ctx.Items.Add(new Separator());
            ctx.Items.Add(miYouTube);
            ctx.Items.Add(miFacebook);
            ctx.Items.Add(new Separator());

            var miVirtualCamera = new MenuItem() { Header = "Virtual Camera" };
            miVirtualCamera.Click += async (senderm, args) => await RunAddOutputGuardedAsync(AddVirtualCameraOutputAsync);
            ctx.Items.Add(miVirtualCamera);

            return ctx;
        }

        /// <summary>
        /// Null-checks the compositor and surfaces exceptions via a single MessageBox. Mirrors
        /// <see cref="RunAddSourceGuardedAsync"/> so every Add-output path has the same guardrails
        /// regardless of whether the menu was opened before <c>Window_Loaded</c> finished.
        /// </summary>
        private async Task RunAddOutputGuardedAsync(Func<Task> addAction)
        {
            if (_compositor == null)
            {
                return;
            }

            try
            {
                await addAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btAddOutput_Click(object sender, RoutedEventArgs e)
        {
            // Same rationale as btAddSource_Click — Add* handlers dereference _compositor.
            if (_compositor == null)
            {
                return;
            }

            if (_addOutputContextMenu == null)
            {
                _addOutputContextMenu = BuildAddOutputContextMenu();
            }

            var ctx = _addOutputContextMenu;
            ctx.PlacementTarget = sender as Button;
            ctx.IsOpen = true;
        }

        /// <summary>
        /// Handles the bt remove output click event.
        /// </summary>
        private async void btRemoveOutput_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbOutputs.SelectedIndex != -1)
                {
                    var index = lbOutputs.SelectedIndex;
                    var output = _compositor.Output_Get(index);
                    if (output != null)
                    {
                        await _compositor.Output_RemoveAsync(output.ID);
                    }
                    lbOutputs.Items.RemoveAt(index);
                    // Keep the selection near where the user was pointing: the item that slid
                    // into `index`, or the new last item if we just removed the tail. Previously
                    // this unconditionally jumped to the last item, which surprised users that
                    // removed a middle or first entry.
                    lbOutputs.SelectedIndex = Math.Min(index, lbOutputs.Items.Count - 1);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // async void + Close() race: WPF's shutdown path doesn't await us, so the compositor
            // could outlive the window and race with pipeline teardown. Cancel the initial close,
            // dispose asynchronously, then re-invoke Close() on the dispatcher. The second
            // invocation sees _isClosing=true and falls through so the window actually closes.
            if (_isClosing || _compositor == null)
            {
                return;
            }

            e.Cancel = true;
            _isClosing = true;
            // Disable the window so queued/in-flight UI events can't re-enter handlers that
            // touch _compositor while DisposeAsync is running (btPauseResume, btStart, etc.
            // would otherwise race with the dispose and either NRE or hit a half-disposed pipeline).
            this.IsEnabled = false;

            try
            {
                // DeviceEnumerator.Shared is a process-wide singleton that outlives the window.
                // The handler delegate captures `this`, so failing to unsubscribe keeps the window
                // alive past close AND lets a later hot-plug fire Dispatcher.BeginInvoke into a
                // shutting-down dispatcher.
                DeviceEnumerator.Shared.OnAudioSinkAdded -= Shared_OnAudioSinkAdded;

                // Tear down the recording timer before disposing the compositor so that a
                // late Elapsed tick can't re-enter UpdateRecordingTime on a disposed compositor.
                if (tmRecording != null)
                {
                    try { tmRecording.Stop(); } catch { /* ignore */ }
                    tmRecording.Elapsed -= TmRecording_Elapsed;
                    tmRecording.Dispose();
                    tmRecording = null;
                }

                await _compositor.DisposeAsync();

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                // Never block shutdown on a dispose failure — the user wants out.
                Debug.WriteLine(ex);
            }

            try
            {
                // BeginInvoke can throw if the dispatcher has already begun shutdown from an
                // external signal (process termination, parent app unloading). A thrown exception
                // here would bubble out of async void into the WPF unhandled-exception handler —
                // better to log and let the window die naturally.
                Dispatcher.BeginInvoke(new Action(() => Close()));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                // If BeginInvoke failed, the second Close() never fires, so `_isClosing=true`
                // would leave the window un-closable (every subsequent Alt-F4 hits the early
                // return at the top). Reset the flag and re-enable the window so the user can
                // try again manually — dispose is already done, so a second pass is cheap.
                _isClosing = false;
                this.IsEnabled = true;
            }
        }

        /// <summary>
        /// Handles the bt start output click event.
        /// </summary>
        private async void btStartOutput_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbOutputs.SelectedIndex != -1)
                {
                    var output = _compositor.Output_Get(lbOutputs.SelectedIndex);
                    if (output == null)
                    {
                        // The selected index can become stale relative to the compositor's actual
                        // output list after Output_Remove / teardown; guard against the null return.
                        return;
                    }

                    await output.StartAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt stop output click event.
        /// </summary>
        private async void btStopOutput_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbOutputs.SelectedIndex != -1)
                {
                    var output = _compositor.Output_Get(lbOutputs.SelectedIndex);
                    if (output == null)
                    {
                        return;
                    }

                    await output.StopAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private bool _timelineSeeking = true;

        /// <summary>
        /// Tb seeking value changed.
        /// </summary>
        private async void tbSeeking_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                // Programmatic updates (UpdateSourceSelectionAsync writing Maximum/Value) must not
                // trigger a seek; check this first so the flag's intent is clear even if a future
                // refactor rearranges `_timelineSeeking`.
                if (_isProgrammaticSliderWrite)
                {
                    return;
                }

                if (!_timelineSeeking)
                {
                    return;
                }

                // Suppress the torrent of value-changed ticks that fire while the user is dragging
                // the thumb — we only want to seek once on mouse-up (see tbSeeking_PreviewMouseLeftButtonUp).
                if (_isDraggingSeek)
                {
                    return;
                }

                int index = lbSources.SelectedIndex;
                if (index != -1)
                {
                    // Reject non-finite/negative values before constructing a TimeSpan — matches
                    // prior hardening in commits e97db18 / e885397. A NaN value here would throw
                    // OverflowException from TimeSpan.FromSeconds; a negative value would seek
                    // backwards past zero and some demuxers interpret that as "seek to end".
                    double newValue = e.NewValue;
                    if (double.IsNaN(newValue) || double.IsInfinity(newValue) || newValue < 0)
                    {
                        return;
                    }

                    var fileInput = _compositor.Input_VideoAudio_Get(index);
                    // Avoid `await x?.Pipeline?.Position_SetAsync(...)` — if either member is null
                    // the null-conditional evaluates to a null Task and `await null` throws NRE.
                    var pipeline = fileInput?.Pipeline;
                    if (pipeline == null)
                    {
                        return;
                    }

                    await pipeline.Position_SetAsync(TimeSpan.FromSeconds(newValue));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Mark the start of an interactive seek drag. Blocks value-change-driven seeks until mouse-up.
        /// </summary>
        private void tbSeeking_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _isDraggingSeek = true;
        }

        /// <summary>
        /// Reset the drag flag when the slider loses mouse capture (Alt-Tab, popup, focus steal).
        /// Without this, a drag that never sees MouseUp leaves `_isDraggingSeek` stuck at true,
        /// which permanently suppresses programmatic seeks from UpdateSourceSelectionAsync.
        /// </summary>
        private void tbSeeking_LostMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _isDraggingSeek = false;
        }

        /// <summary>
        /// End of interactive seek drag: issue a single Position_SetAsync with the final thumb value.
        /// </summary>
        private async void tbSeeking_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!_isDraggingSeek)
            {
                return;
            }

            _isDraggingSeek = false;

            try
            {
                if (!_timelineSeeking)
                {
                    return;
                }

                int index = lbSources.SelectedIndex;
                if (index == -1)
                {
                    return;
                }

                var fileInput = _compositor.Input_VideoAudio_Get(index);
                var pipeline = fileInput?.Pipeline;
                if (pipeline == null)
                {
                    return;
                }

                // Same non-finite / negative guard as tbSeeking_ValueChanged. On mouse-up the
                // final value comes from the Slider's current Value, which can be NaN if
                // Maximum was NaN from a prior live-source interaction.
                double seekSec = tbSeeking.Value;
                if (double.IsNaN(seekSec) || double.IsInfinity(seekSec) || seekSec < 0)
                {
                    return;
                }

                await pipeline.Position_SetAsync(TimeSpan.FromSeconds(seekSec));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
