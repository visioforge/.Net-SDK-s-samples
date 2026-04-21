using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using SkiaSharp;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;
using System.Collections.Generic;
using VisioForge.Core.Types.X.VideoEncoders;

namespace VideoOverlayRecorderMB
{
    public partial class MainPage : ContentPage
    {
        private MediaBlocksPipeline _pipeline;
        private UniversalSourceBlock _fileSource;
        private OverlayManagerBlock _overlayManager;
        private List<IOverlayManagerElement> _overlayElements = new List<IOverlayManagerElement>();
        private VideoRendererBlock _videoRenderer;
        private AudioRendererBlock _audioRenderer;
        private TeeBlock _videoTee;
        private TeeBlock _audioTee;
        private MP4OutputBlock _mp4Output;
        private System.Timers.Timer _positionTimer;
        private volatile bool _isTimerUpdate;
        private bool _isRecording;
        private long _frameCounter = 0;
        private string _currentFilename;

        // Track SkiaSharp disposable resources (cached fonts/paints for overlay callbacks)
        private List<IDisposable> _skiaResources = new List<IDisposable>();

        public MainPage()
        {
            InitializeComponent();
            
            _positionTimer = new System.Timers.Timer(500);
            _positionTimer.Elapsed += PositionTimer_Elapsed;
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
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Initialize async.
        /// </summary>
        private async Task InitializeAsync()
        {
            // Initialize SDK
            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
            
            // Initialize overlay manager
            _overlayManager = new OverlayManagerBlock();
            
            UpdateStatus("Ready. Please select a video file.");
        }

        /// <summary>
        /// Dispose async.
        /// </summary>
        private async Task DisposeAsync()
        {
            _positionTimer?.Stop();
            _positionTimer?.Dispose();
            
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await DestroyEngineAsync();
            }

            // Dispose cached SkiaSharp resources (fonts, paints for overlay callbacks)
            foreach (var resource in _skiaResources)
            {
                resource?.Dispose();
            }
            _skiaResources.Clear();
            
            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Create engine async.
        /// </summary>
        private async Task CreateEngineAsync()
        {
            if (_pipeline != null)
            {
                await DestroyEngineAsync();
            }

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
            _pipeline.OnStart += Pipeline_OnStart;
            
            // Create source from file
            _fileSource = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(new Uri(_currentFilename)));
            
            // Create video renderer
            var vv = videoView.GetVideoView();
            _videoRenderer = new VideoRendererBlock(_pipeline, vv);
            
            // Create audio renderer
            var audioOutputs = await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.Default);
            if (audioOutputs.Length > 0)
            {
                _audioRenderer = new AudioRendererBlock(audioOutputs[0]);
            }
            
            // Connect pipeline for preview
            _pipeline.Connect(_fileSource.VideoOutput, _overlayManager.Input);
            _pipeline.Connect(_overlayManager.Output, _videoRenderer.Input);
            
            if (_audioRenderer != null)
            {
                _pipeline.Connect(_fileSource.AudioOutput, _audioRenderer.Input);
            }
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
                _pipeline.OnStart -= Pipeline_OnStart;
                
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
            
            _fileSource?.Dispose();
            _videoRenderer?.Dispose();
            _audioRenderer?.Dispose();
            _videoTee?.Dispose();
            _audioTee?.Dispose();
            _mp4Output?.Dispose();
            
            // Clear overlay elements from the block and the UI list so state doesn't
            // leak into the next pipeline lifecycle.
            _overlayManager?.Video_Overlay_Clear();
            _overlayElements?.Clear();
            
            _fileSource = null;
            _videoRenderer = null;
            _audioRenderer = null;
            _videoTee = null;
            _audioTee = null;
            _mp4Output = null;
        }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void Pipeline_OnError(object? sender, ErrorsEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                edLog.Text += $"Error: {e.Message}{Environment.NewLine}";
                UpdateStatus($"Error: {e.Message}");
            });
        }

        /// <summary>
        /// Pipeline on stop.
        /// </summary>
        private void Pipeline_OnStop(object? sender, StopEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                slPosition.Value = 0;
                lbTime.Text = "00:00:00 / 00:00:00";
                btPlay.IsEnabled = true;
                btPause.IsEnabled = false;
                UpdateStatus("Stopped");
            });
        }

        /// <summary>
        /// Pipeline on start.
        /// </summary>
        private void Pipeline_OnStart(object? sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (_pipeline != null)
                {
                    var duration = await _pipeline.DurationAsync();
                    slPosition.Maximum = duration.TotalSeconds;
                    UpdateStatus("Playing");
                }
            });
        }

        /// <summary>
        /// Position timer elapsed.
        /// </summary>
        private async void PositionTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            try
            {
                if (_pipeline == null || _pipeline.State != PlaybackState.Play)
                {
                    return;
                }

                var position = await _pipeline.Position_GetAsync();
                var duration = await _pipeline.DurationAsync();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    _isTimerUpdate = true;

                    if (position.TotalSeconds <= slPosition.Maximum)
                    {
                        slPosition.Value = position.TotalSeconds;
                    }

                    lbTime.Text = $"{position:hh\\:mm\\:ss} / {duration:hh\\:mm\\:ss}";

                    _isTimerUpdate = false;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Update status.
        /// </summary>
        private void UpdateStatus(string status)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                lbStatus.Text = $"Status: {status}";
            });
        }

        // UI Event Handlers
        /// <summary>
        /// Handles the bt select file clicked event.
        /// </summary>
        private async void btSelectFile_Clicked(object? sender, EventArgs e)
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
                    _currentFilename = result.FullPath;
                    lbFilename.Text = Path.GetFileName(_currentFilename);
                    
                    // Stop current playback
                    await StopPlaybackAsync();
                    
                    // Enable play button
                    btPlay.IsEnabled = true;
                    UpdateStatus("File loaded. Ready to play.");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Error", $"Failed to load file: {ex.Message}", "OK");
            }
        }

        /// <summary>
        /// Handles the bt play clicked event.
        /// </summary>
        private async void btPlay_Clicked(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_currentFilename))
                {
                    await DisplayAlertAsync("Error", "Please select a video file first", "OK");
                    return;
                }

                await CreateEngineAsync();
                await _pipeline.StartAsync();

                _positionTimer.Start();

                btPlay.IsEnabled = false;
                btPause.IsEnabled = true;
                btStop.IsEnabled = true;
                btStartRecording.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt pause clicked event.
        /// </summary>
        private async void btPause_Clicked(object? sender, EventArgs e)
        {
            try
            {
                if (_pipeline != null && _pipeline.State == PlaybackState.Play)
                {
                    await _pipeline.PauseAsync();
                    btPlay.IsEnabled = true;
                    btPause.IsEnabled = false;
                    UpdateStatus("Paused");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt stop clicked event.
        /// </summary>
        private async void btStop_Clicked(object? sender, EventArgs e)
        {
            try
            {
                await StopPlaybackAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Stop playback async.
        /// </summary>
        private async Task StopPlaybackAsync()
        {
            _positionTimer.Stop();
            
            if (_isRecording)
            {
                await StopRecordingAsync();
            }
            
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
            }
            
            btPlay.IsEnabled = true;
            btPause.IsEnabled = false;
            btStop.IsEnabled = false;
            btStartRecording.IsEnabled = false;
        }

        /// <summary>
        /// Sl position value changed.
        /// </summary>
        private async void slPosition_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            try
            {
                if (!_isTimerUpdate && _pipeline != null && _pipeline.State != PlaybackState.Free)
                {
                    await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(e.NewValue));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        // Recording Methods
        /// <summary>
        /// Handles the bt start recording clicked event.
        /// </summary>
        private async void btStartRecording_Clicked(object? sender, EventArgs e)
        {
            try
            {
                if (_isRecording)
                {
                    return;
                }

                await StartRecordingAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Start recording async.
        /// </summary>
        private async Task StartRecordingAsync()
        {
            try
            {
                // Recreate pipeline with recording configuration
                await _pipeline.StopAsync();
                await CreateEngineWithRecordingAsync();
                
                await _pipeline.StartAsync();
                _positionTimer.Start();
                
                _isRecording = true;
                btStartRecording.IsEnabled = false;
                btStopRecording.IsEnabled = true;
                lbRecordingStatus.Text = "Recording...";
                lbRecordingStatus.TextColor = Colors.Red;
                
                UpdateStatus("Recording in progress...");
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Error", $"Failed to start recording: {ex.Message}", "OK");
            }
        }

        /// <summary>
        /// Create engine with recording async.
        /// </summary>
        private async Task CreateEngineWithRecordingAsync()
        {
            if (_pipeline != null)
            {
                await DestroyEngineAsync();
            }

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
            _pipeline.OnStart += Pipeline_OnStart;
            
            // Create source
            _fileSource = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(new Uri(_currentFilename)));
            
            // Create tees for splitting the pipeline
            _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
            _audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);
            
            // Video path: Source -> OverlayManager -> Tee -> Renderer & Encoder
            _pipeline.Connect(_fileSource.VideoOutput, _overlayManager.Input);
            _pipeline.Connect(_overlayManager.Output, _videoTee.Input);
            
            // Connect video renderer
            var vv = videoView.GetVideoView();
            _videoRenderer = new VideoRendererBlock(_pipeline, vv);
            _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
            
            // Audio path: Source -> Tee -> Renderer & Encoder
            _pipeline.Connect(_fileSource.AudioOutput, _audioTee.Input);
            
            // Connect audio renderer
            var audioOutputs = await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.Default);
            if (audioOutputs.Length > 0)
            {
                _audioRenderer = new AudioRendererBlock(audioOutputs[0]);
                _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);
            }
            
            // Create MP4 output
            var outputFilename = GenerateOutputFilename();
            var mp4Settings = new MP4SinkSettings(outputFilename);
            var h264Settings = new OpenH264EncoderSettings
            {
                Bitrate = 2000,
                MaxBitrate = 4000,
                // RateControl is not a property of OpenH264EncoderSettings
                Profile = OpenH264Profile.Main
            };
            // avenc_aac ships via gst-libav and isn't always present on mobile — probe first
            // and fall back to the portable VO-AAC encoder so the demo doesn't fail to start.
            IAACEncoderSettings aacSettings = AVENCAACEncoderSettings.IsAvailable()
                ? (IAACEncoderSettings)new AVENCAACEncoderSettings { Bitrate = 128 }
                : new VOAACEncoderSettings { Bitrate = 128 };

            _mp4Output = new MP4OutputBlock(mp4Settings, h264Settings, aacSettings);
            
            // Connect to MP4 output using dynamic inputs
            _pipeline.Connect(_videoTee.Outputs[1], _mp4Output.CreateNewInput(MediaBlockPadMediaType.Video));
            _pipeline.Connect(_audioTee.Outputs[1], _mp4Output.CreateNewInput(MediaBlockPadMediaType.Audio));
            
            edLog.Text += $"Recording to: {Path.GetFileName(outputFilename)}{Environment.NewLine}";
        }

        /// <summary>
        /// Generate output filename.
        /// </summary>
        private string GenerateOutputFilename()
        {
            var timestamp = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            var filename = $"overlay_recording_{timestamp}.mp4";
            
#if __ANDROID__
            // For Android 10+ (API 29+), use app-specific external storage
            // This avoids scoped storage issues and ensures proper file access
            string path;
            var context = Platform.CurrentActivity ?? Android.App.Application.Context;
            var externalDir = context.GetExternalFilesDir(Android.OS.Environment.DirectoryMovies);
            
            if (externalDir != null)
            {
                // Create app-specific subdirectory for our recordings
                var appDir = new Java.IO.File(externalDir, "VideoOverlayRecorder");
                if (!appDir.Exists())
                {
                    appDir.Mkdirs();
                }
                path = Path.Combine(appDir.AbsolutePath, filename);
            }
            else
            {
                // Fallback to internal storage if external is not available
                var internalDir = context.FilesDir;
                var appDir = new Java.IO.File(internalDir, "VideoOverlayRecorder");
                if (!appDir.Exists())
                {
                    appDir.Mkdirs();
                }
                path = Path.Combine(appDir.AbsolutePath, filename);
            }
#elif __IOS__ && !__MACCATALYST__
            // Resolve ~/Library directly instead of hopping through MyDocuments + "..".
            // The traversal path worked when opening the file via NSURL, but it's a literal
            // string as far as .NET APIs are concerned — Directory.CreateDirectory and
            // Path.GetDirectoryName handle it inconsistently across iOS versions, and some
            // sandboxed paths reject the "/.." segment outright.
            var libraryDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(libraryDir, filename);
#else
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), filename);
#endif
            
#if !__ANDROID__
            // Ensure directory exists for non-Android platforms
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
#endif
            
            return path;
        }

        /// <summary>
        /// Handles the bt stop recording clicked event.
        /// </summary>
        private async void btStopRecording_Clicked(object? sender, EventArgs e)
        {
            try
            {
                await StopRecordingAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Stop recording async.
        /// </summary>
        private async Task StopRecordingAsync()
        {
            if (!_isRecording)
            {
                return;
            }
            
            _isRecording = false;
            btStartRecording.IsEnabled = true;
            btStopRecording.IsEnabled = false;
            lbRecordingStatus.Text = "Ready";
            lbRecordingStatus.TextColor = Colors.Gray;
            
            await StopPlaybackAsync();
            
            UpdateStatus("Recording stopped");
            await DisplayAlertAsync("Recording Complete", "Video has been saved successfully.", "OK");
        }

        // Overlay Management
        /// <summary>
        /// Handles the bt add text clicked event.
        /// </summary>
        private void btAddText_Clicked(object? sender, EventArgs e)
        {
            var text = new OverlayManagerText(edTextOverlay.Text, 50, 50);
            text.Color = SKColors.White;
            text.Font.Size = 32;
            text.Font.Name = "Arial";
            text.Background = new OverlayManagerBackgroundRectangle { Color = new SKColor(0, 0, 0, 128), Fill = true }; // Semi-transparent background
            
            _overlayManager.Video_Overlay_Add(text);
            _overlayElements.Add(text);
            lbOverlays.ItemsSource = null;
            lbOverlays.ItemsSource = GetOverlayDescriptions();
            
            edLog.Text += $"Added text overlay: {edTextOverlay.Text}{Environment.NewLine}";
        }

        /// <summary>
        /// Handles the bt add image clicked event.
        /// </summary>
        private async void btAddImage_Clicked(object? sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Select an image",
                    FileTypes = FilePickerFileType.Images
                });
                
                if (result != null)
                {
                    var image = new OverlayManagerImage(result.FullPath, 100, 100);
                    image.Width = 200;
                    image.Height = 150;
                    
                    _overlayManager.Video_Overlay_Add(image);
                    _overlayElements.Add(image);
                    lbOverlays.ItemsSource = null;
                    lbOverlays.ItemsSource = GetOverlayDescriptions();
                    
                    edLog.Text += $"Added image overlay: {Path.GetFileName(result.FullPath)}{Environment.NewLine}";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Error", $"Failed to add image: {ex.Message}", "OK");
            }
        }

        /// <summary>
        /// Handles the bt add rectangle clicked event.
        /// </summary>
        private void btAddRectangle_Clicked(object? sender, EventArgs e)
        {
            var rect = new OverlayManagerRectangle(new SKRect(200, 200, 400, 300));
            rect.Color = SKColors.Red;
            // Rectangle uses Fill property, not StrokeWidth/Filled
            rect.Fill = false;
            
            _overlayManager.Video_Overlay_Add(rect);
            _overlayElements.Add(rect);
            lbOverlays.ItemsSource = null;
            lbOverlays.ItemsSource = GetOverlayDescriptions();
            
            edLog.Text += $"Added rectangle overlay{Environment.NewLine}";
        }

        /// <summary>
        /// Handles the bt add circle clicked event.
        /// </summary>
        private void btAddCircle_Clicked(object? sender, EventArgs e)
        {
            var circle = new OverlayManagerCircle(new SKPoint(300, 300), 50);
            circle.Color = SKColors.Blue;
            // Circle uses Fill property
            circle.Fill = true;
            circle.Opacity = 0.5f;
            
            _overlayManager.Video_Overlay_Add(circle);
            _overlayElements.Add(circle);
            lbOverlays.ItemsSource = null;
            lbOverlays.ItemsSource = GetOverlayDescriptions();
            
            edLog.Text += $"Added circle overlay{Environment.NewLine}";
        }

        /// <summary>
        /// Handles the bt add line clicked event.
        /// </summary>
        private void btAddLine_Clicked(object? sender, EventArgs e)
        {
            var line = new OverlayManagerLine(new SKPoint(50, 400), new SKPoint(500, 450));
            line.Color = SKColors.Green;
            // Line doesn't have StrokeWidth property, color defines appearance
            
            _overlayManager.Video_Overlay_Add(line);
            _overlayElements.Add(line);
            lbOverlays.ItemsSource = null;
            lbOverlays.ItemsSource = GetOverlayDescriptions();
            
            edLog.Text += $"Added line overlay{Environment.NewLine}";
        }

        /// <summary>
        /// Handles the bt add timestamp clicked event.
        /// </summary>
        private void btAddTimestamp_Clicked(object? sender, EventArgs e)
        {
            var timestampCallback = new OverlayManagerCallback
            {
                Name = "Timestamp",
                Enabled = true,
                ZIndex = 100
            };
            
            // Cache only immutable/thread-safe Skia objects (typeface/font/paint) across frames.
            // The SKBitmap/SKCanvas MUST be per-frame: SKCanvas is not thread-safe, and
            // args.DrawImage may retain the bitmap reference past the lambda — sharing one
            // would let frame N+1's Clear mutate the pixels while frame N is still being
            // consumed. Per-frame scope with `using` keeps allocation cost bounded and correct.
            var tsTypeface = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold);
            var tsFont = new SKFont(tsTypeface, 20);
            var tsPaint = new SKPaint { Color = SKColors.Yellow, IsAntialias = true };
            _skiaResources.Add(tsTypeface);
            _skiaResources.Add(tsFont);
            _skiaResources.Add(tsPaint);

            timestampCallback.OnDraw += (sender, args) =>
            {
                using var tsBitmap = new SKBitmap(250, 40);
                using var tsCanvas = new SKCanvas(tsBitmap);
                tsCanvas.Clear(new SKColor(0, 0, 0, 200));
                var timeText = $"Time: {args.Timestamp:mm\\:ss\\.ff}";
                tsCanvas.DrawText(timeText, 10, 25, tsFont, tsPaint);
                args.DrawImage(tsBitmap, 10, 10);
            };
            
            _overlayManager.Video_Overlay_Add(timestampCallback);
            _overlayElements.Add(timestampCallback);
            lbOverlays.ItemsSource = null;
            lbOverlays.ItemsSource = GetOverlayDescriptions();
            
            edLog.Text += $"Added timestamp overlay{Environment.NewLine}";
        }

        /// <summary>
        /// Handles the bt add frame counter clicked event.
        /// </summary>
        private void btAddFrameCounter_Clicked(object? sender, EventArgs e)
        {
            _frameCounter = 0;
            
            var frameCounterCallback = new OverlayManagerCallback
            {
                Name = "FrameCounter",
                Enabled = true,
                ZIndex = 99
            };
            
            // Cache only immutable/thread-safe Skia objects (typeface/font/paint) across frames.
            // See timestamp overlay above for the rationale — SKBitmap/SKCanvas are per-frame.
            var fcTypeface = SKTypeface.FromFamilyName("Arial");
            var fcFont = new SKFont(fcTypeface, 18);
            var fcPaint = new SKPaint { Color = SKColors.White, IsAntialias = true };
            _skiaResources.Add(fcTypeface);
            _skiaResources.Add(fcFont);
            _skiaResources.Add(fcPaint);

            frameCounterCallback.OnDraw += (sender, args) =>
            {
                // OnDraw fires on a GStreamer streaming thread; if the overlay ever fans out
                // to multiple frame pads, two threads could run this concurrently. Bare ++
                // on a long isn't atomic (torn read on 32-bit ARM, read-modify-write race
                // anywhere), so use Interlocked.Increment and reuse its return value for the
                // text too — reading _frameCounter a second time would race with a sibling
                // increment and show the wrong number.
                var n = System.Threading.Interlocked.Increment(ref _frameCounter);
                using var fcBitmap = new SKBitmap(200, 40);
                using var fcCanvas = new SKCanvas(fcBitmap);
                fcCanvas.Clear(new SKColor(0, 0, 0, 128));
                var text = $"Frame: {n}";
                fcCanvas.DrawText(text, 10, 25, fcFont, fcPaint);
                args.DrawImage(fcBitmap, 10, 60);
            };
            
            _overlayManager.Video_Overlay_Add(frameCounterCallback);
            _overlayElements.Add(frameCounterCallback);
            lbOverlays.ItemsSource = null;
            lbOverlays.ItemsSource = GetOverlayDescriptions();
            
            edLog.Text += $"Added frame counter overlay{Environment.NewLine}";
        }

        /// <summary>
        /// Handles the bt remove overlay clicked event.
        /// </summary>
        private void btRemoveOverlay_Clicked(object? sender, EventArgs e)
        {
            if (lbOverlays.SelectedItem != null)
            {
                var index = lbOverlays.ItemsSource.Cast<string>().ToList().IndexOf(lbOverlays.SelectedItem.ToString());
                if (index >= 0 && index < _overlayElements.Count)
                {
                    _overlayManager.Video_Overlay_RemoveAt(index);
                    _overlayElements.RemoveAt(index);
                    lbOverlays.ItemsSource = null;
                    lbOverlays.ItemsSource = GetOverlayDescriptions();
                    
                    edLog.Text += $"Removed overlay at index {index}{Environment.NewLine}";
                }
            }
        }

        private string[] GetOverlayDescriptions()
        {
            return _overlayElements.Select((overlay, index) =>
            {
                return overlay switch
                {
                    OverlayManagerText text => $"[{index}] Text: {text.Text}",
                    OverlayManagerImage image => $"[{index}] Image",
                    OverlayManagerRectangle rect => $"[{index}] Rectangle",
                    OverlayManagerCircle circle => $"[{index}] Circle",
                    OverlayManagerLine line => $"[{index}] Line",
                    OverlayManagerCallback callback => $"[{index}] {callback.Name}",
                    _ => $"[{index}] Unknown"
                };
            }).ToArray();
        }
    }
}
