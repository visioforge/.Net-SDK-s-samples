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

            _timer.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

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
            var dlg = new OpenFileDialog();
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
                _overlayManager.Video_Overlay_RemoveAt(lbOverlays.SelectedIndex);
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
            frameCounterCallback.OnDraw += (sender, e) =>
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
                    e.DrawImage(bitmap, 10, 10);
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
            timeOverlay.OnDraw += (sender, e) =>
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

                            string timeText = $"Time: {e.Timestamp:mm\\:ss\\.ff}";
                            canvas.DrawText(timeText, 10, 25, paint);
                        }
                    }

                    // Draw the bitmap at bottom right corner
                    e.DrawImage(bitmap, 260, 370);
                }
            };

            // Add to overlay manager
            _overlayManager.Video_Overlay_Add(timeOverlay);
            lbOverlays.Items.Add("[Callback] Time Display");
        }
    }
}
