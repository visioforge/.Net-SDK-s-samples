using System.Diagnostics;
using System.Globalization;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.Types.Events;

namespace Simple_Player_MB_MAUI
{
    /// <summary>
    /// The main page of the application.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline? _pipeline;

        /// <summary>
        /// The source.
        /// </summary>
        private UniversalSourceBlock? _source;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private MediaBlock? _videoRenderer;

        /// <summary>
        /// The audio renderer.
        /// </summary>
        private AudioRendererBlock? _audioRenderer;

        /// <summary>
        /// The filename.
        /// </summary>
        private string? _filename;

        /// <summary>
        /// The seeking flag.
        /// </summary>
        private volatile bool _isTimerUpdate;

        /// <summary>
        /// The position timer.
        /// </summary>
        private System.Timers.Timer _tmPosition = new System.Timers.Timer(500);

        /// <summary>
        /// Set when Window_Destroying starts the teardown sequence so async-void handlers
        /// suspended on awaits can bail out before touching the about-to-be-disposed pipeline.
        /// </summary>
        private volatile bool _isTearingDown;

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            
            _tmPosition.Elapsed += tmPosition_Elapsed;
        }

        /// <summary>
        /// Create engine async.
        /// </summary>
        /// <param name="iosScopedUrl">iOS only: security-scoped NSUrl from UIDocumentPicker.
        /// When provided, the SDK uses it directly so the sandbox grant (held open by the caller
        /// via StartAccessingSecurityScopedResource) reaches GStreamer's filesrc. When null
        /// (e.g. gallery path — file already in app sandbox cache), we fall back to
        /// NSUrl.FromFilename(_filename).</param>
        private async Task CreateEngineAsync(
#if IOS && !MACCATALYST
            Foundation.NSUrl? iosScopedUrl = null
#endif
        )
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync(true);
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            // Dispose leftover blocks from a previous playback before overwriting the fields
            // below — gallery→open sequences call CreateEngineAsync twice and each MediaBlock
            // owns an unmanaged GStreamer element that isn't finalized automatically.
            _videoRenderer?.Dispose();
            _videoRenderer = null;
            _audioRenderer?.Dispose();
            _audioRenderer = null;
            _source?.Dispose();
            _source = null;

            _pipeline = new MediaBlocksPipeline();

            _pipeline.OnError += _player_OnError;
            _pipeline.OnStart += _player_OnStart;
            _pipeline.OnStop += _player_OnStop;

            // Use the string overload so the SDK's FilenameHelper.SafeCreateFileUri normalizes
            // the path (platform-native absolute paths -> file:// URIs, existence check, etc.)
            // rather than relying on the default new Uri(string) constructor behaviour.
            // On iOS the SDK only exposes the NSUrl overload (string overload is gated out by
            // #if __IOS__ && !__MACCATALYST__), so wrap the path in NSUrl explicitly using
            // FromFilename — `new NSUrl(absPath)` doesn't set the file:// scheme and the SDK's
            // URI.Scheme.Equals check then throws NRE.
#if IOS && !MACCATALYST
            var settings = iosScopedUrl != null
                ? await UniversalSourceSettings.CreateAsync(iosScopedUrl)
                : await UniversalSourceSettings.CreateAsync(Foundation.NSUrl.FromFilename(_filename!));
#else
            var settings = await UniversalSourceSettings.CreateAsync(_filename!);
#endif
            // Auto-rotate portrait phone recordings via videoflip inside the source block;
            // no FlipRotateBlock needed in the pipeline.
            settings.VideoFlipRotate = VideoFlipRotateMethod.Automatic;
            var info = settings.GetInfo();
            _source = new UniversalSourceBlock(settings);

            // If we couldn't read the media info (unsupported container, damaged file),
            // we can't trust VideoStreams/AudioStreams to decide what to wire up — degrade
            // to connecting both pads (the original behaviour) so the pipeline at least
            // surfaces the demuxer's own error, and alert the user that we're going to try
            // anyway rather than silently spinning forever on an un-wired pipeline.
            var hasVideo = info?.VideoStreams?.Count > 0;
            var hasAudio = info?.AudioStreams?.Count > 0;
            var unknown = info == null;

            if (unknown)
            {
                Console.WriteLine("[SimplePlayer] CreateEngineAsync: GetInfo() returned null — connecting both pads defensively");
            }

            // Construct each renderer only if we're going to connect it, so an audio-only or
            // video-only file doesn't allocate an unused block (and when GetInfo returned
            // null we build both, matching the fallback above).
            var vv = videoView.GetVideoView();
            if (hasVideo || unknown)
            {
                _videoRenderer = new VideoRendererBlock(_pipeline, vv);
                _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);
            }

            if (hasAudio || unknown)
            {
                _audioRenderer = new AudioRendererBlock();
                _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
            }
        }

        /// <summary>
        /// Player on stop.
        /// </summary>
        private async void _player_OnStop(object? sender, StopEventArgs e)
        {
            try
            {
                await StopAllAsync();

                // update UI controls using invoke
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    btSpeed.Text = "1X";
                    slSeeking.Value = 0;
                    lbDuration.Text = "00:00:00";
                    lbPosition.Text = "00:00:00";
                    SetPlayingUIState(false);
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in OnStop: {ex.Message}");
            }
        }

        /// <summary>
        /// Toggles the Open/Gallery vs Stop button group so only the currently valid actions
        /// remain tappable: while a file is playing, Open and Gallery are disabled (picking a
        /// new file would race against the live pipeline); while nothing is playing, Stop is
        /// disabled because there's nothing to stop.
        /// </summary>
        private void SetPlayingUIState(bool playing)
        {
            btOpen.IsEnabled = !playing;
            btGallery.IsEnabled = !playing;
            btStop.IsEnabled = playing;
        }

        /// <summary>
        /// Main page loaded.
        /// </summary>
        private void MainPage_Loaded(object? sender, EventArgs e)
        {
            Window.Destroying += Window_Destroying;
        }

        /// <summary>
        /// Player on start.
        /// </summary>
        private async void _player_OnStart(object? sender, EventArgs e)
        {
            try
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    if (_pipeline == null)
                    {
                        return;
                    }

                    slSeeking.Maximum = (await _pipeline.DurationAsync()).TotalMilliseconds;
                });
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine($"Error in OnStart: {exception.Message}");
            }                      
        }

        /// <summary>
        /// Window destroying.
        /// </summary>
        private async void Window_Destroying(object? sender, EventArgs e)
        {
            try
            {
                // Mark teardown in progress so btGallery_Clicked / btOpen_Clicked bail
                // out instead of touching a pipeline we're about to dispose. Without this,
                // an in-flight Start that was suspended on an await can resume after Dispose
                // and throw ObjectDisposedException.
                _isTearingDown = true;

                if (_pipeline != null)
                {
                    // Unhook ALL three handlers before StopAsync — OnStop / OnStart can fire
                    // synchronously during StopAsync and then call StopAllAsync / touch UI on
                    // a pipeline that's about to be disposed.
                    _pipeline.OnError -= _player_OnError;
                    _pipeline.OnStart -= _player_OnStart;
                    _pipeline.OnStop -= _player_OnStop;
                    await _pipeline.StopAsync(true);

                    _pipeline.Dispose();
                    _pipeline = null;
                }

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error during cleanup: {ex.Message}");
            }
        }

        /// <summary>
        /// Player on error.
        /// </summary>
        private void _player_OnError(object? sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
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

            _tmPosition.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync(true);
            }
        }

        /// <summary>
        /// Handles the Elapsed event of the tmPosition control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Tm position elapsed.
        /// </summary>
        private async void tmPosition_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (_pipeline == null)
                {
                    return;
                }

                try
                {
                    var pos = await _pipeline.Position_GetAsync();
                    var progress = (int)pos.TotalMilliseconds;

                    await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        if (_pipeline == null)
                        {
                            return;
                        }

                        _isTimerUpdate = true;

                        slSeeking.Maximum = (await _pipeline.DurationAsync()).TotalMilliseconds;

                        if (progress > slSeeking.Maximum)
                        {
                            slSeeking.Value = slSeeking.Maximum;
                        }
                        else
                        {
                            slSeeking.Value = progress;
                        }

                        // This is where the received data is passed
                        lbPosition.Text = $"{pos.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";
                        lbDuration.Text = $"{(await _pipeline.DurationAsync()).ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";

                        _isTimerUpdate = false;
                    });
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine($"Error in timer update: {exception.Message}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Sl seeking value changed.
        /// </summary>
        private async void slSeeking_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            try
            {
                if (!_isTimerUpdate && _pipeline != null)
                {
                    await _pipeline.Position_SetAsync(TimeSpan.FromMilliseconds(e.NewValue));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error setting position: {ex.Message}");
            }
        }

        /// <summary>
        /// Sl volume value changed.
        /// </summary>
        private void slVolume_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            if (_pipeline != null && _audioRenderer != null)
            {
                _audioRenderer.Volume = e.NewValue / 100.0;
            }
        }

        /// <summary>
        /// Handles the bt open clicked event.
        /// </summary>
        private async void btOpen_Clicked(object? sender, EventArgs e)
        {
            try
            {
#if IOS && !MACCATALYST
                // Native UIDocumentPickerViewController in asCopy:true mode — iOS hardlinks
                // the picked file into our sandbox Inbox and hands back a plain file URL.
                // No security-scoped bookmark to juggle, and the Xamarin NSUrl wrapper stays
                // valid after picker dismissal (that was the problem with asCopy:false — the
                // handle got released by ObjC before AVAsset.FromUrl ran).
                var nsUrl = await Platforms.iOS.DocumentPickerHelper.PickVideoAsync();
                if (nsUrl == null)
                {
                    return;
                }

                await StopAllAsync();
                _filename = nsUrl.Path;

                if (_isTearingDown)
                {
                    return;
                }

                await CreateEngineAsync(nsUrl);
                await _pipeline!.StartAsync();
#else
                var result = await FilePicker.Default.PickAsync();
                if (result == null)
                {
                    return;
                }

                await StopAllAsync();

                _filename = result.FullPath;

                if (_isTearingDown)
                {
                    return;
                }

                await CreateEngineAsync();
                await _pipeline!.StartAsync();
#endif

                _tmPosition.Start();
                SetPlayingUIState(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SimplePlayer] EXC btOpen: {ex.GetType().Name}: {ex.Message}");
                Console.WriteLine(ex.StackTrace ?? "(no stack)");
                if (!_isTearingDown)
                {
                    await DisplayAlertAsync("Open", $"{ex.GetType().Name}: {ex.Message}", "OK");
                }
            }
        }

        /// <summary>
        /// Handles the bt gallery clicked event — picks a video from the device photo library.
        /// </summary>
        private async void btGallery_Clicked(object? sender, EventArgs e)
        {
            try
            {
                var result = await MediaPicker.Default.PickVideoAsync();
                if (result == null)
                {
                    return;
                }

                await StopAllAsync();

                // Android: MediaPicker already copies to a cache path, so FullPath is
                // absolute and usable. iOS: PHPicker hands us an NSItemProvider and MAUI
                // only exposes the original filename in FullPath, so we have to copy the
                // stream into our cache to get a real filesystem path.
                if (Path.IsPathRooted(result.FullPath) && File.Exists(result.FullPath))
                {
                    _filename = result.FullPath;
                }
                else
                {
                    // Sanitize the picker-supplied name: strip any path separators (iOS/macOS
                    // PHPicker occasionally returns names containing "/" from source asset paths,
                    // which would escape the cache directory with Path.Combine), then prefix a
                    // GUID so repeated picks of the same video don't collide and overwrite a
                    // file we may still be streaming from.
                    var rawName = result.FileName ?? "video";
                    var leaf = Path.GetFileName(rawName);
                    if (string.IsNullOrEmpty(leaf))
                    {
                        leaf = "video";
                    }

                    // Replace any character any of our target hosts would reject. We can't
                    // rely on Path.GetInvalidFileNameChars() alone — on iOS it only flags
                    // '/' and '\0', so a filename like "12:34 clip.mov" coming from
                    // PHPicker would pass through unchanged and then fail when that same
                    // file name is later touched on a macOS HFS+ volume, a Windows MAUI
                    // share, or any sync target that disallows colons. Use an explicit
                    // union that covers POSIX + HFS + NTFS in one pass.
                    var invalid = new[] { '/', '\\', ':', '*', '?', '"', '<', '>', '|', '\0' };
                    if (leaf.IndexOfAny(invalid) >= 0)
                    {
                        var sb = new System.Text.StringBuilder(leaf.Length);
                        foreach (var ch in leaf)
                        {
                            sb.Append(Array.IndexOf(invalid, ch) >= 0 ? '_' : ch);
                        }
                        leaf = sb.ToString();
                    }

                    var ext = Path.GetExtension(leaf);
                    var stem = Path.GetFileNameWithoutExtension(leaf);
                    var safeName = $"{stem}_{Guid.NewGuid():N}{ext}";
                    var cachePath = Path.Combine(FileSystem.Current.CacheDirectory, safeName);

                    using (var src = await result.OpenReadAsync())
                    using (var dst = File.Create(cachePath))
                    {
                        await src.CopyToAsync(dst);
                    }

                    _filename = cachePath;
                }

                if (_isTearingDown)
                {
                    return;
                }

                await CreateEngineAsync();

                // Snapshot the pipeline reference and re-check the teardown gate: if
                // Window_Destroying fired while CreateEngineAsync was suspended on its
                // own awaits, _pipeline may have been disposed under us. The snapshot
                // alone is not enough — pipeline.StartAsync on a disposed pipeline throws
                // ObjectDisposedException — so we also bail on _isTearingDown and catch ODE
                // as a last line of defence for the narrow window between the check and
                // StartAsync's first native call.
                var pipeline = _pipeline;
                if (pipeline == null || _isTearingDown)
                {
                    Console.WriteLine("[SimplePlayer] btGallery: pipeline disposed/tearing down before start, bailing");
                    return;
                }

                try
                {
                    await pipeline.StartAsync();
                }
                catch (ObjectDisposedException)
                {
                    Console.WriteLine("[SimplePlayer] btGallery: pipeline disposed during StartAsync, bailing");
                    return;
                }

                if (_isTearingDown)
                {
                    return;
                }

                _tmPosition.Start();
                SetPlayingUIState(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SimplePlayer] EXC btGallery: {ex.GetType().Name}: {ex.Message}");
                Console.WriteLine(ex.StackTrace ?? "(no stack)");
                if (!_isTearingDown)
                {
                    await DisplayAlertAsync("Gallery", $"{ex.GetType().Name}: {ex.Message}", "OK");
                }
            }
        }

        /// <summary>
        /// Handles the bt speed clicked event.
        /// </summary>
        private async void btSpeed_Clicked(object? sender, EventArgs e)
        {
            try
            {
                if (btSpeed.Text == "1X")
                {
                    // set 2x
                    btSpeed.Text = "2X";
                    await _pipeline!.Rate_SetAsync(2.0);
                }
                else if (btSpeed.Text == "2X")
                {
                    // set 0.5x
                    btSpeed.Text = "0.5X";
                    await _pipeline!.Rate_SetAsync(0.5);
                }
                else if (btSpeed.Text == "0.5X")
                {
                    // set 1x
                    btSpeed.Text = "1X";
                    await _pipeline!.Rate_SetAsync(1.0);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error setting speed: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the bt stop clicked event.
        /// </summary>
        private async void btStop_Clicked(object? sender, EventArgs e)
        {
            try
            {
                await StopAllAsync();

                btSpeed.Text = "1X";
                slSeeking.Value = 0;
                lbDuration.Text = "00:00:00";
                lbPosition.Text = "00:00:00";
                SetPlayingUIState(false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error stopping playback: {ex.Message}");
            }
        }
    }
}
