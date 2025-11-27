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
        
        public MainWindow()
        {
            InitializeComponent();
        }

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

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                edLog.Text = edLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                tbTimeline.Value = 0;
            }));
        }

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

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                edFilename.Text = dialog.FileName;
            }
        }

        private async void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_timerFlag)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

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

            _timer.Start();
        }

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

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
            }

            tbTimeline.Value = 0;
        }

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

            if (_pipeline != null)
            {
                _pipeline.OnStop -= Pipeline_OnStop;
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.Stop();
            }

            await DestroyEngineAsync();

            VisioForgeX.DestroySDK();
        }

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

        private void btAddText_Click(object sender, RoutedEventArgs e)
        {
            var text = new OverlayManagerText("Hello world!", 100, 100);
            text.Color = SkiaSharp.SKColors.Red;
            text.Font.Size = 32;
            _overlayManager.Video_Overlay_Add(text);
            lbOverlays.Items.Add($"[Text] {text.Text}");
        }

        private void btAddLine_Click(object sender, RoutedEventArgs e)
        {
            var line = new OverlayManagerLine(new SkiaSharp.SKPoint(100, 100), new SkiaSharp.SKPoint(200, 200));
            line.Color = SkiaSharp.SKColors.Red;
            _overlayManager.Video_Overlay_Add(line);
            lbOverlays.Items.Add($"[Line] {line.Start.X}x{line.Start.Y} - {line.End.X}x{line.End.Y}");
        }

        private void btAddRectangle_Click(object sender, RoutedEventArgs e)
        {
            var rect = new OverlayManagerRectangle(new SkiaSharp.SKRect(100, 100, 200, 200));
            rect.Color = SkiaSharp.SKColors.Red;
            _overlayManager.Video_Overlay_Add(rect);
            lbOverlays.Items.Add($"[Rectangle] {rect.Rectangle.Left}x{rect.Rectangle.Top} - {rect.Rectangle.Right}x{rect.Rectangle.Bottom}");
        }

        private void btAddCircle_Click(object sender, RoutedEventArgs e)
        {
            var circle = new OverlayManagerCircle(new SkiaSharp.SKPoint(150, 150), 50);
            circle.Color = SkiaSharp.SKColors.Red;
            _overlayManager.Video_Overlay_Add(circle);
            lbOverlays.Items.Add($"[Circle] {circle.Center.X}x{circle.Center.Y} - {circle.Radius}");
        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbOverlays.SelectedIndex != -1)
            {
                // Check if this is a video overlay and dispose it properly
                var selectedItem = lbOverlays.Items[lbOverlays.SelectedIndex] as string;
                if (selectedItem != null && (selectedItem.StartsWith("[Video]") || selectedItem.StartsWith("[Video+View]")))
                {
                    // Find and dispose the video overlay
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
                        videoOverlay.Dispose();
                    }

                    _overlayManager.Video_Overlay_RemoveAt(lbOverlays.SelectedIndex);
                }
                else if (selectedItem != null && selectedItem.StartsWith("[Decklink]"))
                {
                    // Find and dispose the Decklink overlay
                    var decklinkOverlay = _decklinkOverlays.Find(v => selectedItem.Contains(v.Name));
                    if (decklinkOverlay != null)
                    {
                        decklinkOverlay.Stop();

                        _decklinkOverlays.Remove(decklinkOverlay);
                        decklinkOverlay.Dispose();
                    }

                    _overlayManager.Video_Overlay_RemoveAt(lbOverlays.SelectedIndex);
                }
                else if (selectedItem != null && selectedItem.StartsWith("[NDI]"))
                {
                    // Find and dispose the NDI overlay
                    var ndiOverlay = _ndiOverlays.Find(v => selectedItem.Contains(v.Name));
                    if (ndiOverlay != null)
                    {
                        ndiOverlay.Stop();

                        _ndiOverlays.Remove(ndiOverlay);
                        ndiOverlay.Dispose();
                    }

                    _overlayManager.Video_Overlay_RemoveAt(lbOverlays.SelectedIndex);
                }
                else if (selectedItem != null && selectedItem.StartsWith("[GROUP]"))
                {
                    // Find and dispose the overlay group
                    var overlayGroup = _overlayGroups.Find(g => selectedItem.Contains(g.Name));
                    if (overlayGroup != null)
                    {
                        overlayGroup.Stop();

                        _overlayGroups.Remove(overlayGroup);
                        overlayGroup.Dispose();
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

        private void btAddSyncGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create a synchronized overlay group
                var overlayGroup = new OverlayManagerGroup("SyncGroup_" + (_overlayGroups.Count + 1));

                // Prompt user for video files to add to the group
                var result = MessageBox.Show(
                    "This demo will create a synchronized group with:\n" +
                    "• Two video overlays (you'll select the files)\n" +
                    "• One text overlay\n" +
                    "• One image overlay (optional)\n\n" +
                    "All overlays in the group will start playing at the same time.\n\n" +
                    "Continue?",
                    "Create Synchronized Overlay Group",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes)
                    return;

                // Select first video
                var dlg1 = new OpenFileDialog()
                {
                    Filter = "Video files (*.mp4, *.avi, *.mov, *.mkv, *.wmv)|*.mp4;*.avi;*.mov;*.mkv;*.wmv|All files (*.*)|*.*",
                    Title = "Select First Video for Group"
                };

                if (dlg1.ShowDialog() != true)
                    return;

                // Select second video
                var dlg2 = new OpenFileDialog()
                {
                    Filter = "Video files (*.mp4, *.avi, *.mov, *.mkv, *.wmv)|*.mp4;*.avi;*.mov;*.mkv;*.wmv|All files (*.*)|*.*",
                    Title = "Select Second Video for Group"
                };

                if (dlg2.ShowDialog() != true)
                    return;

                // Create first video overlay (top-left, quarter size)
                var video1 = new OverlayManagerVideo(
                    source: dlg1.FileName,
                    x: 10,
                    y: 10,
                    width: 320,
                    height: 240
                )
                {
                    Loop = true,
                    ZIndex = 10,
                    Name = $"GroupVideo1_{System.IO.Path.GetFileName(dlg1.FileName)}"
                };

                // Create second video overlay (top-right, quarter size)
                var video2 = new OverlayManagerVideo(
                    source: dlg2.FileName,
                    x: 340,
                    y: 10,
                    width: 320,
                    height: 240
                )
                {
                    Loop = true,
                    ZIndex = 10,
                    Name = $"GroupVideo2_{System.IO.Path.GetFileName(dlg2.FileName)}"
                };

                // Create text overlay
                var text = new OverlayManagerText("SYNCHRONIZED GROUP", 10, 260)
                {
                    Color = SKColors.Yellow,
                    Font = new FontSettings
                    {
                        Name = "Arial",
                        Size = 24,
                    },
                    ZIndex = 11
                };

                // Add all overlays to the group
                overlayGroup.Add(video1);
                overlayGroup.Add(video2);
                overlayGroup.Add(text);

                // Optionally add an image overlay
                var imageResult = MessageBox.Show(
                    "Do you want to add an image overlay to the group?",
                    "Add Image",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (imageResult == MessageBoxResult.Yes)
                {
                    var imageDlg = new OpenFileDialog()
                    {
                        Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
                    };

                    if (imageDlg.ShowDialog() == true)
                    {
                        var imageOverlay = new OverlayManagerImage(imageDlg.FileName, 670, 10)
                        {
                            ZIndex = 11
                        };
                        overlayGroup.Add(imageOverlay);
                    }
                }

                // Add the group to the overlay manager
                // This automatically initializes all video overlays to PAUSED state
                _overlayManager.Video_Overlay_Add(overlayGroup);
                _overlayGroups.Add(overlayGroup);

                // Add to the list
                lbOverlays.Items.Add($"[GROUP] {overlayGroup.Name} ({overlayGroup.Overlays.Count} overlays)");

                // Show info message
                MessageBox.Show(
                    $"Synchronized overlay group created with {overlayGroup.Overlays.Count} overlays.\n\n" +
                    "The videos are now preloaded and paused.\n" +
                    "They will start playing when you start the pipeline.\n\n" +
                    "All overlays in the group will begin at exactly the same time!",
                    "Group Created",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                // Start the group (this makes videos start playing synchronously)
                overlayGroup.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating synchronized overlay group: {ex.Message}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
