using System;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.Events;
using Microsoft.Win32;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core;
using VisioForge.Core.Types.X.Sources;
using System.Threading;
using SkiaSharp;
using System.Collections.Generic;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Decklink;
using VisioForge.Core.MediaBlocks.Decklink;
using MessageBoxResult = System.Windows.MessageBoxResult;

namespace Overlay_Manager_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Timers.Timer _timer;

        private volatile bool _timerFlag;

        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private UniversalSourceBlock _fileSource;

        private OverlayManagerBlock _overlayManager;

        private long _frameCounter = 0;

        private List<OverlayManagerVideo> _videoOverlays = new List<OverlayManagerVideo>();

        private List<OverlayManagerDecklinkVideo> _decklinkOverlays = new List<OverlayManagerDecklinkVideo>();

        private List<OverlayManagerNDIVideo> _ndiOverlays = new List<OverlayManagerNDIVideo>();

        private List<OverlayManagerGroup> _overlayGroups = new List<OverlayManagerGroup>();

        // Dictionary to track external VideoView windows for video overlays
        private Dictionary<OverlayManagerVideo, VideoOverlayViewWindow> _videoOverlayWindows = new Dictionary<OverlayManagerVideo, VideoOverlayViewWindow>();

        private List<OverlayManagerImageSequence> _imageSequenceOverlays = new List<OverlayManagerImageSequence>();

        // Zoom/Pan overlay references
        private OverlayManagerZoom _currentZoom = null;
        private List<OverlayManagerPan> _panOverlays = new List<OverlayManagerPan>();
        private List<OverlayManagerFade> _fadeOverlays = new List<OverlayManagerFade>();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            _overlayManager = new OverlayManagerBlock();
        }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                edLog.Text = edLog.Text + e.Message + Environment.NewLine;
            }));
        }

        /// <summary>
        /// Pipeline on stop.
        /// </summary>
        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                tbTimeline.Value = 0;
            }));
        }

        /// <summary>
        /// Create engine async.
        /// </summary>
        private async Task CreateEngineAsync()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
            _pipeline.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            _fileSource = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(new Uri(edFilename.Text)));

            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            _pipeline.Connect(_fileSource.VideoOutput, _overlayManager.Input);
            _pipeline.Connect(_overlayManager.Output, _videoRenderer.Input);

            var audioOutputs = await AudioRendererBlock.GetDevicesAsync(AudioOutputDeviceAPI.DirectSound);
            _audioRenderer = new AudioRendererBlock(audioOutputs[0]);
            _pipeline.Connect(_fileSource.AudioOutput, _audioRenderer.Input);
        }

        /// <summary>
        /// Timer elapsed.
        /// </summary>
        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timerFlag = true;

            var position = await _pipeline.Position_GetAsync();
            var duration = await _pipeline.DurationAsync();

            Dispatcher.Invoke((Action)(() =>
            {
                tbTimeline.Maximum = (int)duration.TotalSeconds;

                lbTime.Text = position.ToString("hh\\:mm\\:ss") + " | " + duration.ToString("hh\\:mm\\:ss");

                if (tbTimeline.Maximum >= position.TotalSeconds)
                {
                    tbTimeline.Value = (int)position.TotalSeconds;
                }
            }));

            _timerFlag = false;
        }

        /// <summary>
        /// Destroy engine async.
        /// </summary>
        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        /// <summary>
        /// Handles the bt select file click event.
        /// </summary>
        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                edFilename.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// Tb timeline value changed.
        /// </summary>
        private async void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_timerFlag)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            edLog.Clear();

            await CreateEngineAsync();

            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;

            await _pipeline.StartAsync();

            // Start any video overlays that were added before the main pipeline started
            foreach (var videoOverlay in _videoOverlays)
            {
                videoOverlay.Play();
            }

            // Start any Decklink overlays that were added before the main pipeline started
            foreach (var decklinkOverlay in _decklinkOverlays)
            {
                decklinkOverlay.Play();
            }

            // Start any overlay groups that were added before the main pipeline started
            foreach (var overlayGroup in _overlayGroups)
            {
                overlayGroup.Play();
            }

            _timer.Start();
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            // Pause all video overlays when stopping main pipeline
            foreach (var videoOverlay in _videoOverlays)
            {
                videoOverlay.Pause();
            }

            // Pause all Decklink overlays when stopping main pipeline
            foreach (var decklinkOverlay in _decklinkOverlays)
            {
                decklinkOverlay.Pause();
            }

            // Pause all overlay groups when stopping main pipeline
            foreach (var overlayGroup in _overlayGroups)
            {
                overlayGroup.Pause();
            }

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
            }

            tbTimeline.Value = 0;
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();

            Thread.Sleep(100);

            // Dispose video overlays
            foreach (var videoOverlay in _videoOverlays)
            {
                videoOverlay?.Dispose();
            }
            _videoOverlays.Clear();

            // Close all external VideoView windows
            foreach (var window in _videoOverlayWindows.Values)
            {
                window?.ForceClose();
            }
            _videoOverlayWindows.Clear();

            // Dispose Decklink overlays
            foreach (var decklinkOverlay in _decklinkOverlays)
            {
                decklinkOverlay?.Dispose();
            }
            _decklinkOverlays.Clear();

            // Dispose NDI overlays
            foreach (var ndiOverlay in _ndiOverlays)
            {
                ndiOverlay?.Dispose();
            }
            _ndiOverlays.Clear();

            // Dispose overlay groups
            foreach (var overlayGroup in _overlayGroups)
            {
                overlayGroup?.Dispose();
            }
            _overlayGroups.Clear();

            // Clear image sequence overlays
            _imageSequenceOverlays.Clear();

            // Clear zoom/pan/fade overlays
            _currentZoom = null;
            _panOverlays.Clear();
            _fadeOverlays.Clear();

            if (_pipeline != null)
            {
                _pipeline.OnStop -= Pipeline_OnStop;
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.Stop();
            }

            await DestroyEngineAsync();

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Handles the bt add image click event.
        /// </summary>
        private void btAddImage_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog()
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp, *.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };
            if (dlg.ShowDialog() == true)
            {
                if (dlg.FileName.ToLowerInvariant().EndsWith(".gif"))
                {
                    _overlayManager.Video_Overlay_Add(new OverlayManagerGIF(dlg.FileName, new SkiaSharp.SKPoint(150, 150)));
                    lbOverlays.Items.Add($"[GIF] {dlg.FileName}");
                }
                else
                {
                    _overlayManager.Video_Overlay_Add(new OverlayManagerImage(dlg.FileName, 100, 100));
                    lbOverlays.Items.Add($"[Image] {dlg.FileName}");
                }
            }
        }

        /// <summary>
        /// Handles the bt add image sequence click event.
        /// </summary>
        private void btAddImageSequence_Click(object sender, RoutedEventArgs e)
        {
            var optionsWindow = new ImageSequenceOptionsWindow();
            if (optionsWindow.ShowDialog() == true)
            {
                var imageSequence = new OverlayManagerImageSequence(
                    optionsWindow.Items,
                    optionsWindow.X, optionsWindow.Y,
                    optionsWindow.SequenceWidth, optionsWindow.SequenceHeight)
                {
                    Loop = optionsWindow.Loop,
                    Opacity = optionsWindow.OpacityLevel,
                    ZIndex = 5,
                    Name = $"ImgSeq_{_imageSequenceOverlays.Count + 1}"
                };

                _imageSequenceOverlays.Add(imageSequence);
                _overlayManager.Video_Overlay_Add(imageSequence);
                lbOverlays.Items.Add($"[ImgSeq] {imageSequence.Name} ({imageSequence.FrameCount} frames)");
            }
        }

        /// <summary>
        /// Handles the bt add text click event.
        /// </summary>
        private void btAddText_Click(object sender, RoutedEventArgs e)
        {
            var text = new OverlayManagerText("Hello world!", 100, 100);
            text.Color = SkiaSharp.SKColors.Red;
            text.Font.Size = 32;
            _overlayManager.Video_Overlay_Add(text);
            lbOverlays.Items.Add($"[Text] {text.Text}");
        }

        /// <summary>
        /// Handles the bt add scrolling text click event.
        /// </summary>
        private void btAddScrollingText_Click(object sender, RoutedEventArgs e)
        {
            var optionsWindow = new ScrollingTextOptionsWindow();
            if (optionsWindow.ShowDialog() == true)
            {
                var scrollingText = new OverlayManagerScrollingText(
                    optionsWindow.ScrollText,
                    optionsWindow.X,
                    optionsWindow.Y,
                    optionsWindow.Speed,
                    optionsWindow.Direction)
                {
                    Width = optionsWindow.AreaWidth,
                    Height = optionsWindow.AreaHeight,
                    DefaultWidth = optionsWindow.AreaWidth > 0 ? optionsWindow.AreaWidth : 1920,
                    Infinite = optionsWindow.Loop,
                    Color = optionsWindow.TextColor,
                    BackgroundTransparent = optionsWindow.TransparentBackground,
                    BackgroundColor = optionsWindow.BackgroundColor,
                    ZIndex = 10
                };

                scrollingText.Font.Size = optionsWindow.FontSize;
                scrollingText.Font.Style = optionsWindow.FontStyle;
                scrollingText.Font.Weight = optionsWindow.FontWeight;
                scrollingText.Font.Underline = optionsWindow.Underline;

                // Add shadow if enabled
                if (optionsWindow.EnableShadow)
                {
                    scrollingText.Shadow = new OverlayManagerShadowSettings
                    {
                        Enabled = true,
                        Color = SKColors.Black,
                        Opacity = 0.7,
                        BlurRadius = 3,
                        Depth = 3,
                        Direction = 45
                    };
                }

                _overlayManager.Video_Overlay_Add(scrollingText);

                // Truncate text for display if too long
                var displayText = optionsWindow.ScrollText.Length > 30
                    ? optionsWindow.ScrollText.Substring(0, 30) + "..."
                    : optionsWindow.ScrollText;
                lbOverlays.Items.Add($"[Scrolling] {displayText}");
            }
        }

        /// <summary>
        /// Handles the bt add line click event.
        /// </summary>
        private void btAddLine_Click(object sender, RoutedEventArgs e)
        {
            var line = new OverlayManagerLine(new SkiaSharp.SKPoint(100, 100), new SkiaSharp.SKPoint(200, 200));
            line.Color = SkiaSharp.SKColors.Red;
            _overlayManager.Video_Overlay_Add(line);
            lbOverlays.Items.Add($"[Line] {line.Start.X}x{line.Start.Y} - {line.End.X}x{line.End.Y}");
        }

        /// <summary>
        /// Handles the bt add rectangle click event.
        /// </summary>
        private void btAddRectangle_Click(object sender, RoutedEventArgs e)
        {
            var rect = new OverlayManagerRectangle(new SkiaSharp.SKRect(100, 100, 200, 200));
            rect.Color = SkiaSharp.SKColors.Red;
            _overlayManager.Video_Overlay_Add(rect);
            lbOverlays.Items.Add($"[Rectangle] {rect.Rectangle.Left}x{rect.Rectangle.Top} - {rect.Rectangle.Right}x{rect.Rectangle.Bottom}");
        }

        /// <summary>
        /// Handles the bt add circle click event.
        /// </summary>
        private void btAddCircle_Click(object sender, RoutedEventArgs e)
        {
            var circle = new OverlayManagerCircle(new SkiaSharp.SKPoint(150, 150), 50);
            circle.Color = SkiaSharp.SKColors.Red;
            _overlayManager.Video_Overlay_Add(circle);
            lbOverlays.Items.Add($"[Circle] {circle.Center.X}x{circle.Center.Y} - {circle.Radius}");
        }

        /// <summary>
        /// Handles the bt remove click event.
        /// </summary>
        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbOverlays.SelectedIndex != -1)
            {
                // Check if this is a video overlay and dispose it properly
                var selectedItem = lbOverlays.Items[lbOverlays.SelectedIndex] as string;
                if (selectedItem != null && (selectedItem.StartsWith("[Video]") || selectedItem.StartsWith("[Video+View]")))
                {
                    // Find the video overlay
                    var videoOverlay = _videoOverlays.Find(v => selectedItem.Contains(v.Name));
                    if (videoOverlay != null)
                    {
                        videoOverlay.Stop();

                        // Close external window if exists
                        if (_videoOverlayWindows.TryGetValue(videoOverlay, out var externalWindow))
                        {
                            externalWindow.ForceClose();
                            _videoOverlayWindows.Remove(videoOverlay);
                        }

                        _videoOverlays.Remove(videoOverlay);
                        // Don't dispose here - let overlay manager handle disposal
                    }

                    // Remove from overlay manager - this will also dispose the overlay
                    _overlayManager.Video_Overlay_RemoveAt(lbOverlays.SelectedIndex);
                }
                else if (selectedItem != null && selectedItem.StartsWith("[Decklink]"))
                {
                    // Find the Decklink overlay
                    var decklinkOverlay = _decklinkOverlays.Find(v => selectedItem.Contains(v.Name));
                    if (decklinkOverlay != null)
                    {
                        decklinkOverlay.Stop();
                        _decklinkOverlays.Remove(decklinkOverlay);
                        // Don't dispose here - let overlay manager handle disposal
                    }

                    // Remove from overlay manager - this will also dispose the overlay
                    _overlayManager.Video_Overlay_RemoveAt(lbOverlays.SelectedIndex);
                }
                else if (selectedItem != null && selectedItem.StartsWith("[NDI]"))
                {
                    // Find the NDI overlay
                    var ndiOverlay = _ndiOverlays.Find(v => selectedItem.Contains(v.Name));
                    if (ndiOverlay != null)
                    {
                        ndiOverlay.Stop();
                        _ndiOverlays.Remove(ndiOverlay);
                        // Don't dispose here - let overlay manager handle disposal
                    }

                    // Remove from overlay manager - this will also dispose the overlay
                    _overlayManager.Video_Overlay_RemoveAt(lbOverlays.SelectedIndex);
                }
                else if (selectedItem != null && selectedItem.StartsWith("[GROUP]"))
                {
                    // Find the overlay group
                    var overlayGroup = _overlayGroups.Find(g => selectedItem.Contains(g.Name));
                    if (overlayGroup != null)
                    {
                        overlayGroup.Stop();
                        _overlayGroups.Remove(overlayGroup);

                        // Also remove any Decklink overlays that were in this group from tracking
                        foreach (var overlay in overlayGroup.Overlays)
                        {
                            if (overlay is OverlayManagerDecklinkVideo decklink)
                            {
                                _decklinkOverlays.Remove(decklink);
                            }
                        }
                    }

                    // Remove from overlay manager - this will also dispose the group and its overlays
                    _overlayManager.Video_Overlay_RemoveAt(lbOverlays.SelectedIndex);
                }
                else if (selectedItem != null && selectedItem.StartsWith("[Zoom]"))
                {
                    // Remove zoom overlay
                    if (_currentZoom != null)
                    {
                        _overlayManager.Video_Overlay_Remove(_currentZoom);
                        _currentZoom = null;
                        cbZoomEnabled.IsChecked = false;
                    }
                }
                else if (selectedItem != null && selectedItem.StartsWith("[Pan]"))
                {
                    // Find and remove the pan overlay
                    var panOverlay = _panOverlays.Find(p => selectedItem.Contains(p.Name));
                    if (panOverlay != null)
                    {
                        _overlayManager.Video_Overlay_Remove(panOverlay);
                        _panOverlays.Remove(panOverlay);
                    }
                }
                else if (selectedItem != null && (selectedItem.StartsWith("[FadeIn]") || selectedItem.StartsWith("[FadeOut]")))
                {
                    // Find and remove the fade overlay
                    var fadeOverlay = _fadeOverlays.Find(f => selectedItem.Contains(f.Name));
                    if (fadeOverlay != null)
                    {
                        _overlayManager.Video_Overlay_Remove(fadeOverlay);
                        _fadeOverlays.Remove(fadeOverlay);
                    }
                }
                else if (selectedItem != null && selectedItem.StartsWith("[ImgSeq]"))
                {
                    // Find and remove the image sequence overlay
                    var seqOverlay = _imageSequenceOverlays.Find(s => selectedItem.Contains(s.Name));
                    if (seqOverlay != null)
                    {
                        _imageSequenceOverlays.Remove(seqOverlay);
                    }

                    _overlayManager.Video_Overlay_RemoveAt(lbOverlays.SelectedIndex);
                }
                else
                {
                    _overlayManager.Video_Overlay_RemoveAt(lbOverlays.SelectedIndex);
                }

                lbOverlays.Items.RemoveAt(lbOverlays.SelectedIndex);
            }
        }

        /// <summary>
        /// Handles the bt add frame counter click event.
        /// </summary>
        private void btAddFrameCounter_Click(object sender, RoutedEventArgs e)
        {
            // Reset frame counter
            _frameCounter = 0;

            // Create callback overlay for frame counter
            var frameCounterCallback = new OverlayManagerCallback
            {
                Name = "FrameCounter",
                Enabled = true,
                ZIndex = 100 // On top
            };

            // Subscribe to the OnDraw event
            frameCounterCallback.OnDraw += (senderx, ex) =>
            {
                // Increment frame counter
                _frameCounter++;

                // Create a bitmap with the frame counter text
                using (var bitmap = new SKBitmap(200, 50))
                {
                    using (var canvas = new SKCanvas(bitmap))
                    {
                        // Clear with semi-transparent background
                        canvas.Clear(new SKColor(0, 0, 0, 128));

                        // Draw frame counter text
                        using (var paint = new SKPaint())
                        {
                            paint.Color = SKColors.White;
                            paint.TextSize = 24;
                            paint.IsAntialias = true;
                            paint.Typeface = SKTypeface.FromFamilyName("Arial");

                            string text = $"Frame: {_frameCounter}";
                            canvas.DrawText(text, 10, 30, paint);
                        }
                    }

                    // Draw the bitmap at position (10, 10)
                    ex.DrawImage(bitmap, 10, 10);
                }
            };

            // Add to overlay manager
            _overlayManager.Video_Overlay_Add(frameCounterCallback);
            lbOverlays.Items.Add("[Callback] Frame Counter");
        }

        /// <summary>
        /// Handles the bt add time overlay click event.
        /// </summary>
        private void btAddTimeOverlay_Click(object sender, RoutedEventArgs e)
        {
            // Create callback overlay for time display
            var timeOverlay = new OverlayManagerCallback
            {
                Name = "TimeOverlay",
                Enabled = true,
                ZIndex = 99,
                Opacity = 0.9
            };

            // Subscribe to the OnDraw event
            timeOverlay.OnDraw += (senderx, ex) =>
            {
                // Create a bitmap with the current time
                using (var bitmap = new SKBitmap(250, 40))
                {
                    using (var canvas = new SKCanvas(bitmap))
                    {
                        // Clear with semi-transparent dark background
                        canvas.Clear(new SKColor(0, 0, 0, 200));

                        // Draw border
                        using (var borderPaint = new SKPaint())
                        {
                            borderPaint.Color = SKColors.LightGray;
                            borderPaint.Style = SKPaintStyle.Stroke;
                            borderPaint.StrokeWidth = 2;
                            borderPaint.IsAntialias = true;
                            canvas.DrawRect(1, 1, bitmap.Width - 2, bitmap.Height - 2, borderPaint);
                        }

                        // Draw current time text
                        using (var paint = new SKPaint())
                        {
                            paint.Color = SKColors.Yellow;
                            paint.TextSize = 20;
                            paint.IsAntialias = true;
                            paint.Typeface = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold);

                            string timeText = $"Time: {ex.Timestamp:mm\\:ss\\.ff}";
                            canvas.DrawText(timeText, 10, 25, paint);
                        }
                    }

                    // Draw the bitmap at bottom right corner
                    ex.DrawImage(bitmap, 260, 370);
                }
            };

            // Add to overlay manager
            _overlayManager.Video_Overlay_Add(timeOverlay);
            lbOverlays.Items.Add("[Callback] Time Display");
        }

        /// <summary>
        /// Handles the bt add video click event.
        /// </summary>
        private async void btAddVideo_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog()
            {
                Filter = "Video files (*.mp4, *.avi, *.mov, *.mkv, *.wmv)|*.mp4;*.avi;*.mov;*.mkv;*.wmv|All files (*.*)|*.*",
                Title = "Select Video File for Overlay"
            };

            if (dlg.ShowDialog() == true)
            {
                // Show options dialog
                var optionsWindow = new VideoOverlayOptionsWindow();
                if (optionsWindow.ShowDialog() == true)
                {
                    VideoOverlayViewWindow externalWindow = null;

                    // Create external VideoView window if requested
                    if (optionsWindow.UseExternalVideoView)
                    {
                        externalWindow = new VideoOverlayViewWindow($"Video Overlay - {System.IO.Path.GetFileName(dlg.FileName)}");
                        externalWindow.Show();
                    }

                    // Create video overlay with specified options
                    var videoOverlay = new OverlayManagerVideo(
                        source: dlg.FileName,
                        x: optionsWindow.X,
                        y: optionsWindow.Y,
                        width: optionsWindow.VideoWidth,
                        height: optionsWindow.VideoHeight
                    )
                    {
                        Loop = optionsWindow.Loop,
                        Opacity = optionsWindow.OpacityLevel,
                        StretchMode = optionsWindow.VideoWidth > 0 && optionsWindow.VideoHeight > 0
                            ? optionsWindow.StretchMode
                            : OverlayManagerImageStretchMode.None,  // Use None only if no dimensions specified
                        ZIndex = 5,
                        Name = $"VideoOverlay_{System.IO.Path.GetFileName(dlg.FileName)}",
                        VideoView = externalWindow?.VideoView  // Assign external VideoView if created
                    };

                    // Add shadow if enabled
                    if (optionsWindow.EnableShadow)
                    {
                        videoOverlay.Shadow = new OverlayManagerShadowSettings
                        {
                            Enabled = true,
                            Color = SKColors.Black,
                            Opacity = 0.5,
                            BlurRadius = 5,
                            Depth = 5,
                            Direction = 45
                        };
                    }

                    // Set audio output device if enabled
                    if (optionsWindow.EnableAudio)
                    {
                        try
                        {
                            var audioOutputs = await AudioRendererBlock.GetDevicesAsync(AudioOutputDeviceAPI.DirectSound);
                            if (audioOutputs != null && audioOutputs.Length > optionsWindow.SelectedAudioDeviceIndex
                                && optionsWindow.SelectedAudioDeviceIndex >= 0)
                            {
                                videoOverlay.AudioOutput = audioOutputs[optionsWindow.SelectedAudioDeviceIndex];
                            }
                        }
                        catch (Exception ex)
                        {
                            // Log error but continue - video overlay will still work without audio
                            edLog.Text += $"Warning: Failed to set audio output device for video overlay: {ex.Message}{Environment.NewLine}";
                        }
                    }

                    // Check if main pipeline is already running
                    bool mainPipelineRunning = _pipeline != null && _pipeline.State == PlaybackState.Play;

                    // Initialize the video overlay
                    // Initialize with autoStart based on main pipeline state
                    bool initialized = videoOverlay.Initialize(autoStart: mainPipelineRunning);

                    if (initialized)
                    {
                        // Keep track of video overlays for proper disposal
                        _videoOverlays.Add(videoOverlay);

                        // Track external window if created
                        if (externalWindow != null)
                        {
                            _videoOverlayWindows[videoOverlay] = externalWindow;
                        }

                        // Add to overlay manager
                        _overlayManager.Video_Overlay_Add(videoOverlay);

                        string displayName = externalWindow != null
                            ? $"[Video+View] {videoOverlay.Name}"
                            : $"[Video] {videoOverlay.Name}";
                        if (videoOverlay.AudioOutput != null)
                        {
                            displayName += " [Audio]";
                        }
                        lbOverlays.Items.Add(displayName);
                    }
                    else
                    {
                        MessageBox.Show("Failed to initialize video overlay. Please check if the file is valid and GStreamer has the required codecs.",
                            "Initialization Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        videoOverlay.Dispose();

                        // Close external window if it was created
                        if (externalWindow != null)
                        {
                            externalWindow.ForceClose();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the bt add picture in picture click event.
        /// </summary>
        private void btAddPictureInPicture_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog()
            {
                Filter = "Video files (*.mp4, *.avi, *.mov, *.mkv)|*.mp4;*.avi;*.mov;*.mkv|All files (*.*)|*.*",
                Title = "Select Video for Picture-in-Picture"
            };

            if (dlg.ShowDialog() == true)
            {
                // Create a small PiP video in the corner
                var pipVideo = new OverlayManagerVideo(
                    source: dlg.FileName,
                    x: 20,     // 20px from left
                    y: 20,     // 20px from top
                    width: 240,  // Small size
                    height: 135  // 16:9 aspect ratio
                )
                {
                    Loop = true,
                    Opacity = 0.9,
                    StretchMode = OverlayManagerImageStretchMode.Letterbox,
                    ZIndex = 100,  // On top of everything
                    Name = $"PiP_{System.IO.Path.GetFileName(dlg.FileName)}",

                    // Add border effect with shadow
                    Shadow = new OverlayManagerShadowSettings
                    {
                        Enabled = true,
                        Color = SKColors.DarkGray,
                        Opacity = 0.7,
                        BlurRadius = 8,
                        Depth = 3,
                        Direction = 45
                    }
                };

                // Check if main pipeline is already running
                bool mainPipelineRunning = _pipeline != null && _pipeline.State == PlaybackState.Play;

                // Initialize the PiP video overlay
                bool initialized = pipVideo.Initialize(autoStart: mainPipelineRunning);

                if (initialized)
                {
                    // Keep track of video overlays
                    _videoOverlays.Add(pipVideo);

                    // Add to overlay manager
                    _overlayManager.Video_Overlay_Add(pipVideo);
                    lbOverlays.Items.Add($"[Video-PiP] {pipVideo.Name}");
                }
                else
                {
                    MessageBox.Show("Failed to initialize PiP video overlay.", "Initialization Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    pipVideo.Dispose();
                }
            }
        }

        /// <summary>
        /// Handles the bt add stream overlay click event.
        /// </summary>
        private void btAddStreamOverlay_Click(object sender, RoutedEventArgs e)
        {
            // Create a simple input dialog for stream URL
            var inputWindow = new StreamUrlInputWindow();
            if (inputWindow.ShowDialog() == true)
            {
                string streamUrl = inputWindow.StreamUrl;

                // Create stream overlay
                var streamOverlay = new OverlayManagerVideo(
                    source: streamUrl,
                    x: 400,
                    y: 50,
                    width: 320,
                    height: 240
                )
                {
                    Loop = false,  // Don't loop streams
                    Opacity = 1.0,
                    StretchMode = OverlayManagerImageStretchMode.Letterbox,
                    ZIndex = 10,
                    Name = $"Stream_{new Uri(streamUrl).Host}"
                };

                // Check if main pipeline is already running
                bool mainPipelineRunning = _pipeline != null && _pipeline.State == PlaybackState.Play;

                // Initialize the stream overlay
                bool initialized = streamOverlay.Initialize(autoStart: mainPipelineRunning);

                if (initialized)
                {
                    // Keep track of video overlays
                    _videoOverlays.Add(streamOverlay);

                    // Add to overlay manager
                    _overlayManager.Video_Overlay_Add(streamOverlay);
                    lbOverlays.Items.Add($"[Stream] {streamOverlay.Name}");
                }
                else
                {
                    MessageBox.Show($"Failed to initialize stream overlay. Please check if the URL is accessible: {streamUrl}",
                        "Initialization Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    streamOverlay.Dispose();
                }
            }
        }

        /// <summary>
        /// Handles the bt add decklink click event.
        /// </summary>
        private async void btAddDecklink_Click(object sender, RoutedEventArgs e)
        {
            // Show custom Decklink options dialog
            var optionsWindow = new DecklinkOverlayOptionsWindow();
            if (optionsWindow.ShowDialog() == true)
            {
                // Create Decklink video source settings with user-selected parameters
                var decklinkSettings = new DecklinkVideoSourceSettings(optionsWindow.SelectedDevice.DeviceNumber)
                {
                    Mode = optionsWindow.SelectedMode,
                    Connection = optionsWindow.SelectedConnection,
                    EnableAutoDeinterlacing = optionsWindow.AutoDeinterlace,
                    BufferSize = optionsWindow.BufferSize
                };

                // Create Decklink video overlay with specified options
                var decklinkOverlay = new OverlayManagerDecklinkVideo(
                    settings: decklinkSettings,
                    x: optionsWindow.X,
                    y: optionsWindow.Y,
                    width: optionsWindow.VideoWidth,
                    height: optionsWindow.VideoHeight
                )
                {
                    Opacity = optionsWindow.OpacityLevel,
                    StretchMode = optionsWindow.StretchMode,
                    ZIndex = 5,
                    Name = $"DecklinkOverlay_{optionsWindow.SelectedDevice.ModelName}"
                };

                // Add shadow if enabled
                if (optionsWindow.EnableShadow)
                {
                    decklinkOverlay.Shadow = new OverlayManagerShadowSettings
                    {
                        Enabled = true,
                        Color = SKColors.Black,
                        Opacity = 0.5,
                        BlurRadius = 5,
                        Depth = 5,
                        Direction = 45
                    };
                }

                // Set audio output device if enabled
                if (optionsWindow.EnableAudio)
                {
                    try
                    {
                        var audioOutputs = await AudioRendererBlock.GetDevicesAsync(AudioOutputDeviceAPI.DirectSound);
                        if (audioOutputs != null && audioOutputs.Length > optionsWindow.SelectedAudioDeviceIndex
                            && optionsWindow.SelectedAudioDeviceIndex >= 0)
                        {
                            decklinkOverlay.AudioOutput = audioOutputs[optionsWindow.SelectedAudioDeviceIndex];
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log error but continue - video overlay will still work without audio
                        edLog.Text += $"Warning: Failed to set audio output device for Decklink overlay: {ex.Message}{Environment.NewLine}";
                    }
                }

                // Check if main pipeline is already running
                bool mainPipelineRunning = _pipeline != null && _pipeline.State == PlaybackState.Play;

                // Initialize the Decklink overlay
                bool initialized = decklinkOverlay.Initialize(autoStart: mainPipelineRunning);

                if (initialized)
                {
                    // Keep track of Decklink overlays for proper disposal
                    _decklinkOverlays.Add(decklinkOverlay);

                    // Add to overlay manager
                    _overlayManager.Video_Overlay_Add(decklinkOverlay);

                    string displayName = $"[Decklink] {decklinkOverlay.Name}";
                    if (decklinkOverlay.AudioOutput != null)
                    {
                        displayName += " [Audio]";
                    }
                    lbOverlays.Items.Add(displayName);
                }
                else
                {
                    MessageBox.Show("Failed to initialize Decklink overlay. Please check if the device is connected and has an active input signal.",
                        "Initialization Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    decklinkOverlay.Dispose();
                }
            }
        }

        /// <summary>
        /// Handles the bt add click event.
        /// </summary>
        private async void btAddNDI_Click(object sender, RoutedEventArgs e)
        {
            // Show custom NDI options dialog
            var optionsWindow = new NDIOverlayOptionsWindow();
            if (optionsWindow.ShowDialog() == true)
            {
                try
                {
                    // Create NDI source settings
                    var ndiSettings = await NDISourceSettings.CreateAsync(
                        null,
                        optionsWindow.SelectedSource.Name,
                        optionsWindow.SelectedSource.URL);

                    // Create NDI video overlay with specified options
                    var ndiOverlay = new OverlayManagerNDIVideo(
                        settings: ndiSettings,
                        x: optionsWindow.X,
                        y: optionsWindow.Y,
                        width: optionsWindow.VideoWidth,
                        height: optionsWindow.VideoHeight
                    )
                    {
                        Opacity = optionsWindow.OpacityLevel,
                        StretchMode = optionsWindow.StretchMode,
                        ZIndex = 5,
                        Name = $"NDIOverlay_{optionsWindow.SelectedSource.Name}"
                    };

                    // Add shadow if enabled
                    if (optionsWindow.EnableShadow)
                    {
                        ndiOverlay.Shadow = new OverlayManagerShadowSettings
                        {
                            Enabled = true,
                            Color = SKColors.Black,
                            Opacity = 0.5,
                            BlurRadius = 5,
                            Depth = 5,
                            Direction = 45
                        };
                    }

                    // Check if main pipeline is already running
                    bool mainPipelineRunning = _pipeline != null && _pipeline.State == PlaybackState.Play;

                    // Initialize the NDI overlay
                    bool initialized = ndiOverlay.Initialize(autoStart: mainPipelineRunning);

                    if (initialized)
                    {
                        // Keep track of NDI overlays for proper disposal
                        _ndiOverlays.Add(ndiOverlay);

                        // Add to overlay manager
                        _overlayManager.Video_Overlay_Add(ndiOverlay);
                        lbOverlays.Items.Add($"[NDI] {ndiOverlay.Name}");
                    }
                    else
                    {
                        MessageBox.Show("Failed to initialize NDI overlay. Please check if the NDI source is available and the GStreamer NDI plugin is installed.",
                            "Initialization Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        ndiOverlay.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating NDI overlay: {ex.Message}",
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Handles the bt add sync group click event.
        /// </summary>
        private async void btAddSyncGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 1. Show info dialog
                var result = MessageBox.Show(
                    "This will create a synchronized group with:\n" +
                    "- One video file overlay\n" +
                    "- One Decklink capture overlay\n\n" +
                    "Both sources will start playing at the same time.\n\n" +
                    "Continue?",
                    "Create Synchronized Group",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes)
                    return;

                // 2. Select video file and configure via dialog
                var fileDlg = new OpenFileDialog()
                {
                    Filter = "Video files (*.mp4, *.avi, *.mov, *.mkv, *.wmv)|*.mp4;*.avi;*.mov;*.mkv;*.wmv|All files (*.*)|*.*",
                    Title = "Select Video File for Synchronized Group"
                };

                if (fileDlg.ShowDialog() != true)
                    return;

                var videoOptionsWindow = new VideoOverlayOptionsWindow();
                if (videoOptionsWindow.ShowDialog() != true)
                    return;

                // 3. Configure Decklink source via dialog
                var decklinkOptionsWindow = new DecklinkOverlayOptionsWindow();
                if (decklinkOptionsWindow.ShowDialog() != true)
                    return;

                // 4. Create the synchronized group
                var overlayGroup = new OverlayManagerGroup("SyncGroup_" + (_overlayGroups.Count + 1));

                // 5. Create video file overlay with dialog settings
                // Note: If dimensions are set but StretchMode is None, use Stretch mode instead
                // because StretchMode.None ignores width/height and renders at original size
                var effectiveStretchMode = videoOptionsWindow.StretchMode;
                if (effectiveStretchMode == OverlayManagerImageStretchMode.None
                    && videoOptionsWindow.VideoWidth > 0 && videoOptionsWindow.VideoHeight > 0)
                {
                    effectiveStretchMode = OverlayManagerImageStretchMode.Stretch;
                }

                var videoOverlay = new OverlayManagerVideo(
                    source: fileDlg.FileName,
                    x: videoOptionsWindow.X,
                    y: videoOptionsWindow.Y,
                    width: videoOptionsWindow.VideoWidth,
                    height: videoOptionsWindow.VideoHeight
                )
                {
                    Loop = videoOptionsWindow.Loop,
                    Opacity = videoOptionsWindow.OpacityLevel,
                    StretchMode = effectiveStretchMode,
                    ZIndex = 10,
                    Name = $"GroupVideo_{System.IO.Path.GetFileName(fileDlg.FileName)}"
                };

                // Add shadow if enabled
                if (videoOptionsWindow.EnableShadow)
                {
                    videoOverlay.Shadow = new OverlayManagerShadowSettings
                    {
                        Enabled = true,
                        Color = SKColors.Black,
                        Opacity = 0.5,
                        BlurRadius = 5,
                        Depth = 5,
                        Direction = 45
                    };
                }

                // Set audio output device if enabled
                if (videoOptionsWindow.EnableAudio)
                {
                    try
                    {
                        var audioOutputs = await AudioRendererBlock.GetDevicesAsync(AudioOutputDeviceAPI.DirectSound);
                        if (audioOutputs != null && audioOutputs.Length > videoOptionsWindow.SelectedAudioDeviceIndex
                            && videoOptionsWindow.SelectedAudioDeviceIndex >= 0)
                        {
                            videoOverlay.AudioOutput = audioOutputs[videoOptionsWindow.SelectedAudioDeviceIndex];
                        }
                    }
                    catch (Exception ex)
                    {
                        edLog.Text += $"Warning: Failed to set audio output device for video overlay: {ex.Message}{Environment.NewLine}";
                    }
                }

                // 6. Create Decklink overlay with dialog settings
                // Note: Apply same StretchMode fix as video overlay
                var decklinkEffectiveStretchMode = decklinkOptionsWindow.StretchMode;
                if (decklinkEffectiveStretchMode == OverlayManagerImageStretchMode.None
                    && decklinkOptionsWindow.VideoWidth > 0 && decklinkOptionsWindow.VideoHeight > 0)
                {
                    decklinkEffectiveStretchMode = OverlayManagerImageStretchMode.Stretch;
                }

                var decklinkSettings = new DecklinkVideoSourceSettings(decklinkOptionsWindow.SelectedDevice.DeviceNumber)
                {
                    Mode = decklinkOptionsWindow.SelectedMode,
                    Connection = decklinkOptionsWindow.SelectedConnection,
                    EnableAutoDeinterlacing = decklinkOptionsWindow.AutoDeinterlace,
                    BufferSize = decklinkOptionsWindow.BufferSize
                };

                var decklinkOverlay = new OverlayManagerDecklinkVideo(
                    settings: decklinkSettings,
                    x: decklinkOptionsWindow.X,
                    y: decklinkOptionsWindow.Y,
                    width: decklinkOptionsWindow.VideoWidth,
                    height: decklinkOptionsWindow.VideoHeight
                )
                {
                    Opacity = decklinkOptionsWindow.OpacityLevel,
                    StretchMode = decklinkEffectiveStretchMode,
                    ZIndex = 11,
                    Name = $"GroupDecklink_{decklinkOptionsWindow.SelectedDevice.ModelName}"
                };

                // Add shadow if enabled
                if (decklinkOptionsWindow.EnableShadow)
                {
                    decklinkOverlay.Shadow = new OverlayManagerShadowSettings
                    {
                        Enabled = true,
                        Color = SKColors.Black,
                        Opacity = 0.5,
                        BlurRadius = 5,
                        Depth = 5,
                        Direction = 45
                    };
                }

                // Set Decklink audio output if enabled
                if (decklinkOptionsWindow.EnableAudio)
                {
                    try
                    {
                        var audioOutputs = await AudioRendererBlock.GetDevicesAsync(AudioOutputDeviceAPI.DirectSound);
                        if (audioOutputs != null && audioOutputs.Length > decklinkOptionsWindow.SelectedAudioDeviceIndex
                            && decklinkOptionsWindow.SelectedAudioDeviceIndex >= 0)
                        {
                            decklinkOverlay.AudioOutput = audioOutputs[decklinkOptionsWindow.SelectedAudioDeviceIndex];
                        }
                    }
                    catch (Exception ex)
                    {
                        edLog.Text += $"Warning: Failed to set audio output device for Decklink overlay: {ex.Message}{Environment.NewLine}";
                    }
                }

                // 7. Initialize Decklink overlay manually (OverlayManagerGroup doesn't handle Decklink overlays)
                bool decklinkInitialized = decklinkOverlay.Initialize(autoStart: false);
                if (!decklinkInitialized)
                {
                    MessageBox.Show("Failed to initialize Decklink overlay. Please check if the device is connected and has an active input signal.",
                        "Initialization Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                // 8. Add overlays to the group
                overlayGroup.Add(videoOverlay);
                overlayGroup.Add(decklinkOverlay);

                // Track Decklink overlay for proper lifecycle management
                _decklinkOverlays.Add(decklinkOverlay);

                // 9. Add group to overlay manager
                _overlayManager.Video_Overlay_Add(overlayGroup);
                _overlayGroups.Add(overlayGroup);

                // 10. Add to list
                lbOverlays.Items.Add($"[GROUP] {overlayGroup.Name} (Video + Decklink)");

                // 11. Show success message
                MessageBox.Show(
                    $"Synchronized overlay group created with:\n" +
                    $"- Video: {System.IO.Path.GetFileName(fileDlg.FileName)}\n" +
                    $"- Decklink: {decklinkOptionsWindow.SelectedDevice.ModelName}\n\n" +
                    "Both sources will start playing synchronously when you start the pipeline.",
                    "Group Created",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                // 12. Start group and Decklink overlay if pipeline is running
                if (_pipeline != null && _pipeline.State == PlaybackState.Play)
                {
                    overlayGroup.Play();
                    decklinkOverlay.Play();  // Must start Decklink manually since group doesn't handle it
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating synchronized overlay group: {ex.Message}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #region Zoom/Pan Controls

        /// <summary>
        /// Sl zoom value changed.
        /// </summary>
        private void slZoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Update labels
            if (lbZoomX != null) lbZoomX.Text = slZoomX.Value.ToString("F1");
            if (lbZoomY != null) lbZoomY.Text = slZoomY.Value.ToString("F1");
            if (lbShiftX != null) lbShiftX.Text = ((int)slShiftX.Value).ToString();
            if (lbShiftY != null) lbShiftY.Text = ((int)slShiftY.Value).ToString();

            // Update zoom if enabled
            if (cbZoomEnabled != null && cbZoomEnabled.IsChecked == true && _currentZoom != null)
            {
                _currentZoom.ZoomX = slZoomX.Value;
                _currentZoom.ZoomY = slZoomY.Value;
                _currentZoom.ShiftX = (int)slShiftX.Value;
                _currentZoom.ShiftY = (int)slShiftY.Value;
            }
        }

        /// <summary>
        /// Handles the cb zoom enabled checked changed event.
        /// </summary>
        private void cbZoomEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (cbZoomEnabled.IsChecked == true)
            {
                // Add zoom effect
                if (_currentZoom == null)
                {
                    _currentZoom = new OverlayManagerZoom(
                        slZoomX.Value,
                        slZoomY.Value,
                        (int)slShiftX.Value,
                        (int)slShiftY.Value,
                        true,
                        "Zoom");
                    _overlayManager.Video_Overlay_Add(_currentZoom);
                    lbOverlays.Items.Add("[Zoom] Video Transform");
                }
                else
                {
                    _currentZoom.Enabled = true;
                }
            }
            else
            {
                // Disable zoom effect
                if (_currentZoom != null)
                {
                    _currentZoom.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Handles the bt zoom reset click event.
        /// </summary>
        private void btZoomReset_Click(object sender, RoutedEventArgs e)
        {
            slZoomX.Value = 1.0;
            slZoomY.Value = 1.0;
            slShiftX.Value = 0;
            slShiftY.Value = 0;

            if (_currentZoom != null)
            {
                _currentZoom.ZoomX = 1.0;
                _currentZoom.ZoomY = 1.0;
                _currentZoom.ShiftX = 0;
                _currentZoom.ShiftY = 0;
            }
        }

        /// <summary>
        /// Handles the bt pan add click event.
        /// </summary>
        private void btPanAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int startX = int.Parse(edPanStartX.Text);
                int startY = int.Parse(edPanStartY.Text);
                int startW = int.Parse(edPanStartW.Text);
                int startH = int.Parse(edPanStartH.Text);
                int stopX = int.Parse(edPanStopX.Text);
                int stopY = int.Parse(edPanStopY.Text);
                int stopW = int.Parse(edPanStopW.Text);
                int stopH = int.Parse(edPanStopH.Text);
                double duration = double.Parse(edPanDuration.Text);

                // Get easing type
                OverlayManagerPanEasing easing = OverlayManagerPanEasing.Linear;
                switch (cbPanEasing.SelectedIndex)
                {
                    case 1: easing = OverlayManagerPanEasing.EaseIn; break;
                    case 2: easing = OverlayManagerPanEasing.EaseOut; break;
                    case 3: easing = OverlayManagerPanEasing.EaseInOut; break;
                }

                // Create pan effect
                var pan = new OverlayManagerPan(
                    startX, startY, startW, startH,
                    stopX, stopY, stopW, stopH,
                    TimeSpan.Zero, TimeSpan.FromSeconds(duration),
                    true, $"Pan_{_panOverlays.Count + 1}")
                {
                    Easing = easing
                };

                _panOverlays.Add(pan);
                _overlayManager.Video_Overlay_Add(pan);
                lbOverlays.Items.Add($"[Pan] {pan.Name} ({duration}s)");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating pan effect: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Handles the bt pan preset 1 click event.
        /// </summary>
        private void btPanPreset1_Click(object sender, RoutedEventArgs e)
        {
            // Preset: Zoom In (Full frame to center crop)
            edPanStartX.Text = "0";
            edPanStartY.Text = "0";
            edPanStartW.Text = "0";  // Full width
            edPanStartH.Text = "0";  // Full height
            edPanStopX.Text = "160";
            edPanStopY.Text = "90";
            edPanStopW.Text = "320";
            edPanStopH.Text = "180";
            edPanDuration.Text = "5";
        }

        /// <summary>
        /// Handles the bt pan preset 2 click event.
        /// </summary>
        private void btPanPreset2_Click(object sender, RoutedEventArgs e)
        {
            // Preset: Zoom Out (Center crop to full frame)
            edPanStartX.Text = "160";
            edPanStartY.Text = "90";
            edPanStartW.Text = "320";
            edPanStartH.Text = "180";
            edPanStopX.Text = "0";
            edPanStopY.Text = "0";
            edPanStopW.Text = "0";  // Full width
            edPanStopH.Text = "0";  // Full height
            edPanDuration.Text = "5";
        }

        #endregion

        #region Fade Effects

        /// <summary>
        /// Get fade easing.
        /// </summary>
        private OverlayManagerPanEasing GetFadeEasing()
        {
            return cbFadeEasing.SelectedIndex switch
            {
                1 => OverlayManagerPanEasing.EaseIn,
                2 => OverlayManagerPanEasing.EaseOut,
                3 => OverlayManagerPanEasing.EaseInOut,
                _ => OverlayManagerPanEasing.Linear
            };
        }

        /// <summary>
        /// Handles the bt fade in click event.
        /// </summary>
        private async void btFadeIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double duration = double.Parse(edFadeDuration.Text);
                var easing = GetFadeEasing();

                // Get current position as the base time
                var currentPosition = await _pipeline.Position_GetAsync();

                var fade = new OverlayManagerFade(
                    OverlayManagerFadeType.FadeIn,
                    currentPosition,
                    currentPosition + TimeSpan.FromSeconds(duration),
                    true,
                    $"FadeIn_{_fadeOverlays.Count + 1}")
                {
                    Easing = easing
                };

                _fadeOverlays.Add(fade);
                _overlayManager.Video_Overlay_Add(fade);
                lbOverlays.Items.Add($"[FadeIn] {fade.Name} ({duration}s)");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating fade in effect: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Handles the bt fade out click event.
        /// </summary>
        private async void btFadeOut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double duration = double.Parse(edFadeDuration.Text);
                var easing = GetFadeEasing();

                // Get current position as the base time
                var currentPosition = await _pipeline.Position_GetAsync();

                var fade = new OverlayManagerFade(
                    OverlayManagerFadeType.FadeOut,
                    currentPosition,
                    currentPosition + TimeSpan.FromSeconds(duration),
                    true,
                    $"FadeOut_{_fadeOverlays.Count + 1}")
                {
                    Easing = easing
                };

                _fadeOverlays.Add(fade);
                _overlayManager.Video_Overlay_Add(fade);
                lbOverlays.Items.Add($"[FadeOut] {fade.Name} ({duration}s)");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating fade out effect: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}
