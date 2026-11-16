using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Decklink;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Decklink;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;

// Aliases to avoid ambiguity
using VFRect = VisioForge.Core.Types.Rect;
using WinRect = System.Windows.Rect;
using VFSize = VisioForge.Core.Types.Size;
using WinSize = System.Windows.Size;

namespace DecklinkFillKeyDemo
{
    /// <summary>
    /// Main window for Decklink Fill+Key broadcast demonstration
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;
        private PushVideoSourceBlock _graphicsSource;
        private int _debugFrameCount;

        // One render target, converter and frame for all ticks: a new 1080p bitmap per frame forces constant full GCs
        private readonly RenderTargetBitmap _renderBitmap = new RenderTargetBitmap(1920, 1080, 96, 96, PixelFormats.Pbgra32);
        private readonly FormatConvertedBitmap _straightBitmap;
        private readonly VideoFrameX _frame = VideoFrameX.Alloc(1920, 1080, 1920 * 4, VideoFormatX.BGRA);
        private DecklinkVideoSinkBlock _decklinkSink;
        private UniversalSourceBlock _backgroundSource;
        private VideoMixerBlock _videoMixer;
        private VideoRendererBlock _previewRenderer;
        private TeeBlock _outputTee;

        private DispatcherTimer _captureTimer;
        private DispatcherTimer _clockTimer;
        private System.Timers.Timer _positionTimer;

        private UserControl _graphicsOverlay;
        private bool _isRunning = false;
        private bool _graphicsVisible = true;
        private DateTime _startTime;

        public MainWindow()
        {
            InitializeComponent();
            _straightBitmap = new FormatConvertedBitmap(_renderBitmap, PixelFormats.Bgra32, null, 0);
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize SDK
            Title += " [Initializing SDK...]";
            IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            IsEnabled = true;
            Title = $"Media Blocks SDK .Net - Decklink Fill+Key Broadcast Demo (SDK v{MediaBlocksPipeline.SDK_Version})";

            // Setup timers
            _captureTimer = new DispatcherTimer();
            _captureTimer.Tick += CaptureTimer_Tick;

            _clockTimer = new DispatcherTimer();
            _clockTimer.Interval = TimeSpan.FromSeconds(1);
            _clockTimer.Tick += ClockTimer_Tick;

            _positionTimer = new System.Timers.Timer(500);
            _positionTimer.Elapsed += PositionTimer_Elapsed;

            // Load devices
            await LoadDecklinkDevices();

            // Create initial graphics overlay
            CreateGraphicsOverlay();

            // Set default video mode
            cbVideoMode.SelectedIndex = 0; // HD1080p25

            Log("Application initialized. Ready to broadcast.");
        }

        private async System.Threading.Tasks.Task LoadDecklinkDevices()
        {
            try
            {
                // Load output devices
                var outputDevices = await DecklinkVideoSinkBlock.GetDevicesAsync();
                cbDecklinkDevice.Items.Clear();

                if (outputDevices.Length > 0)
                {
                    foreach (var device in outputDevices)
                    {
                        cbDecklinkDevice.Items.Add($"{device.DeviceNumber}: {device.Name}");
                    }
                    cbDecklinkDevice.SelectedIndex = 0;
                    Log($"Found {outputDevices.Length} Decklink output device(s)");
                }
                else
                {
                    Log("WARNING: No Decklink output devices found!");
                    MessageBox.Show("No Decklink devices found. Please check your hardware.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                // Load input devices for background source
                var inputDevices = await DecklinkVideoSourceBlock.GetDevicesAsync();
                cbDecklinkInput.Items.Clear();

                if (inputDevices.Length > 0)
                {
                    foreach (var device in inputDevices)
                    {
                        cbDecklinkInput.Items.Add($"{device.DeviceNumber}: {device.Name}");
                    }
                    cbDecklinkInput.SelectedIndex = 0;
                }

                // Load input modes
                cbInputMode.Items.Clear();
                foreach (DecklinkMode mode in Enum.GetValues(typeof(DecklinkMode)))
                {
                    cbInputMode.Items.Add(mode.ToString());
                }
                cbInputMode.SelectedIndex = Array.IndexOf(Enum.GetValues(typeof(DecklinkMode)), DecklinkMode.HD1080p25);
            }
            catch (Exception ex)
            {
                Log($"Error loading devices: {ex.Message}");
            }
        }

        /// <summary>
        /// Create graphics overlay.
        /// </summary>
        private void CreateGraphicsOverlay()
        {
            _graphicsOverlay = new UserControl
            {
                Width = 1920,
                Height = 1080,
                Background = Brushes.Transparent
            };

            UpdateGraphicsContent();

            // Add to preview
            OverlayViewbox.Child = _graphicsOverlay;
        }

        /// <summary>
        /// Update graphics content.
        /// </summary>
        private void UpdateGraphicsContent()
        {
            if (_graphicsOverlay == null) return;

            var grid = new Grid();

            // Create lower third container
            var lowerThird = new Grid();

            // Position based on selection
            switch (cbPosition.SelectedIndex)
            {
                case 0: // Bottom Left
                    lowerThird.HorizontalAlignment = HorizontalAlignment.Left;
                    lowerThird.VerticalAlignment = VerticalAlignment.Bottom;
                    lowerThird.Margin = new Thickness(50, 0, 0, 100);
                    break;
                case 1: // Bottom Center
                    lowerThird.HorizontalAlignment = HorizontalAlignment.Center;
                    lowerThird.VerticalAlignment = VerticalAlignment.Bottom;
                    lowerThird.Margin = new Thickness(0, 0, 0, 100);
                    break;
                case 2: // Bottom Right
                    lowerThird.HorizontalAlignment = HorizontalAlignment.Right;
                    lowerThird.VerticalAlignment = VerticalAlignment.Bottom;
                    lowerThird.Margin = new Thickness(0, 0, 50, 100);
                    break;
                case 3: // Top Left
                    lowerThird.HorizontalAlignment = HorizontalAlignment.Left;
                    lowerThird.VerticalAlignment = VerticalAlignment.Top;
                    lowerThird.Margin = new Thickness(50, 100, 0, 0);
                    break;
                case 4: // Top Center
                    lowerThird.HorizontalAlignment = HorizontalAlignment.Center;
                    lowerThird.VerticalAlignment = VerticalAlignment.Top;
                    lowerThird.Margin = new Thickness(0, 100, 0, 0);
                    break;
                case 5: // Top Right
                    lowerThird.HorizontalAlignment = HorizontalAlignment.Right;
                    lowerThird.VerticalAlignment = VerticalAlignment.Top;
                    lowerThird.Margin = new Thickness(0, 100, 50, 0);
                    break;
            }

            // Create background with gradient
            var backgroundBorder = new Border
            {
                Width = 800,
                Height = 150,
                CornerRadius = new CornerRadius(5)
            };

            var gradient = new LinearGradientBrush();
            gradient.StartPoint = new Point(0, 0);
            gradient.EndPoint = new Point(1, 0);
            gradient.GradientStops.Add(new GradientStop(Color.FromArgb(230, 0, 50, 100), 0));
            gradient.GradientStops.Add(new GradientStop(Color.FromArgb(200, 0, 70, 140), 1));
            backgroundBorder.Background = gradient;

            // Add content stack panel
            var contentStack = new StackPanel
            {
                Orientation = Orientation.Vertical,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(30, 20, 30, 20)
            };

            // Title
            var titleText = new TextBlock
            {
                Text = tbTitle.Text,
                Foreground = Brushes.White,
                FontSize = 42,
                FontWeight = FontWeights.Bold,
                FontFamily = new FontFamily("Segoe UI"),
                Effect = new System.Windows.Media.Effects.DropShadowEffect
                {
                    Color = Colors.Black,
                    Direction = 315,
                    ShadowDepth = 2,
                    Opacity = 0.5
                }
            };

            // Subtitle
            var subtitleText = new TextBlock
            {
                Text = tbSubtitle.Text,
                Foreground = new SolidColorBrush(Color.FromRgb(220, 220, 220)),
                FontSize = 24,
                FontWeight = FontWeights.Normal,
                FontFamily = new FontFamily("Segoe UI"),
                Margin = new Thickness(0, 5, 0, 0)
            };

            contentStack.Children.Add(titleText);
            contentStack.Children.Add(subtitleText);
            backgroundBorder.Child = contentStack;
            lowerThird.Children.Add(backgroundBorder);

            // Add accent bar
            var accentBar = new System.Windows.Shapes.Rectangle
            {
                Width = 5,
                Height = 150,
                Fill = new SolidColorBrush(Color.FromRgb(255, 100, 0)),
                HorizontalAlignment = HorizontalAlignment.Left
            };
            lowerThird.Children.Add(accentBar);

            grid.Children.Add(lowerThird);

            // Add clock if enabled
            if (cbShowClock.IsChecked == true)
            {
                var clockBorder = new Border
                {
                    Background = new SolidColorBrush(Color.FromArgb(200, 30, 30, 30)),
                    CornerRadius = new CornerRadius(3),
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(0, 50, 50, 0),
                    Padding = new Thickness(15, 8, 15, 8)
                };

                var clockText = new TextBlock
                {
                    Name = "ClockText",
                    Text = DateTime.Now.ToString("HH:mm:ss"),
                    Foreground = Brushes.White,
                    FontSize = 28,
                    FontWeight = FontWeights.Medium,
                    FontFamily = new FontFamily("Consolas")
                };

                clockBorder.Child = clockText;
                grid.Children.Add(clockBorder);
            }

            // Add logo if enabled
            if (cbShowLogo.IsChecked == true)
            {
                var logoBorder = new Border
                {
                    Width = 150,
                    Height = 50,
                    Background = new SolidColorBrush(Color.FromArgb(180, 255, 255, 255)),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(50, 50, 0, 0),
                    CornerRadius = new CornerRadius(3)
                };

                var logoText = new TextBlock
                {
                    Text = "LOGO",
                    Foreground = new SolidColorBrush(Color.FromRgb(50, 50, 50)),
                    FontSize = 24,
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                logoBorder.Child = logoText;
                grid.Children.Add(logoBorder);
            }

            // Apply animation
            if (cbAnimation.SelectedIndex > 0 && _graphicsVisible)
            {
                ApplyAnimation(lowerThird);
            }

            _graphicsOverlay.Content = grid;
        }

        /// <summary>
        /// Apply animation.
        /// </summary>
        private void ApplyAnimation(FrameworkElement element)
        {
            switch (cbAnimation.SelectedIndex)
            {
                case 1: // Slide In
                    var slideTransform = new TranslateTransform();
                    element.RenderTransform = slideTransform;
                    var slideAnimation = new DoubleAnimation
                    {
                        From = -1000,
                        To = 0,
                        Duration = TimeSpan.FromSeconds(0.5),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
                    };
                    slideTransform.BeginAnimation(TranslateTransform.XProperty, slideAnimation);
                    break;

                case 2: // Fade In
                    var fadeAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.8)
                    };
                    element.BeginAnimation(UIElement.OpacityProperty, fadeAnimation);
                    break;

                case 3: // Wipe
                    var wipeTransform = new ScaleTransform(0, 1);
                    element.RenderTransform = wipeTransform;
                    element.RenderTransformOrigin = new Point(0, 0.5);
                    var wipeAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 1,
                        Duration = TimeSpan.FromSeconds(0.4),
                        EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                    };
                    wipeTransform.BeginAnimation(ScaleTransform.ScaleXProperty, wipeAnimation);
                    break;
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbDecklinkDevice.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a Decklink output device.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                btStart.IsEnabled = false;
                cbVideoMode.IsEnabled = false;
                lbStatus.Text = "Initializing...";
                lbStatus.Foreground = Brushes.Orange;

                await StartBroadcast();

                btStart.IsEnabled = false;
                btStop.IsEnabled = true;
                lbStatus.Text = "Broadcasting";
                lbStatus.Foreground = Brushes.Red;
                _startTime = DateTime.Now;

                Log("Broadcast started successfully");
            }
            catch (Exception ex)
            {
                Log($"Error starting broadcast: {ex.Message}");
                MessageBox.Show($"Failed to start broadcast: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
                cbVideoMode.IsEnabled = true;
                lbStatus.Text = "Error";
                lbStatus.Foreground = Brushes.Red;
            }
        }

        private async System.Threading.Tasks.Task StartBroadcast()
        {
            // Create pipeline
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;

            if (_pipeline.Debug_Mode)
            {
                _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "DecklinkFillKey");
                Directory.CreateDirectory(_pipeline.Debug_Dir);
            }

            // Configure graphics push source (1920x1080 BGRA with alpha)
            var pushSettings = new PushVideoSourceSettings(
                1920,
                1080,
                GetSelectedFrameRate(),
                VideoFormatX.BGRA);
            _graphicsSource = new PushVideoSourceBlock(pushSettings);

            // Keying needs ARGB and the card's one-sub-device full-duplex profile (the card keeps it after exit)
            var keyerMode = (DecklinkKeyerMode)cbKeyerMode.SelectedIndex;
            bool keyerOn = keyerMode != DecklinkKeyerMode.Off;
            Log($"Configuring Decklink output, keyer: {keyerMode}{(keyerOn ? ", format: ARGB 8-bit" : "")}...");

            var decklinkSettings = new DecklinkVideoSinkSettings((uint)cbDecklinkDevice.SelectedIndex, GetSelectedDecklinkMode())
            {
                VideoFormat = keyerOn ? DecklinkVideoFormat.ARGB_8bit : GetSelectedVideoFormat(),
                KeyerMode = keyerMode,
                KeyerLevel = (int)slKeyerLevel.Value,
                Profile = keyerOn ? DecklinkProfileID.OneSubDeviceFull : DecklinkProfileID.Default,
                IsSync = true
            };
            _decklinkSink = new DecklinkVideoSinkBlock(decklinkSettings);

            _pipeline.AddBlock(_graphicsSource);
            _pipeline.AddBlock(_decklinkSink);
            _outputTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
            _pipeline.AddBlock(_outputTee);

            // Keyer on: the card gets the graphics alone, the background goes to the preview only
            MediaBlockPad overlay = _graphicsSource.Output;
            if (keyerOn)
            {
                _pipeline.Connect(_graphicsSource.Output, _outputTee.Input);
                _pipeline.Connect(_outputTee.Outputs[0], _decklinkSink.Input);
                overlay = _outputTee.Outputs[1];
            }

            // Build pipeline based on background source
            MediaBlockPad program = overlay;

            if (rbFileBackground.IsChecked == true && !string.IsNullOrEmpty(edVideoFile.Text))
            {
                // Add file background
                var sourceSettings = await UniversalSourceSettings.CreateAsync(edVideoFile.Text);
                _backgroundSource = new UniversalSourceBlock(sourceSettings);

                // Create video mixer with 2 inputs for background and overlay
                var mixerSettings = new VideoMixerBaseSettings(1920, 1080, GetSelectedFrameRate());
                mixerSettings.Background = VideoMixerBackground.Transparent;

                // Add stream for background (full screen)
                mixerSettings.AddStream(new VideoMixerStream(
                    new VFRect(0, 0, 1920, 1080), // Full screen
                    0)); // Z-order 0 (background)

                // Add stream for graphics overlay (full screen with alpha)
                mixerSettings.AddStream(new VideoMixerStream(
                    new VFRect(0, 0, 1920, 1080), // Full screen
                    1)); // Z-order 1 (foreground)

                _videoMixer = new VideoMixerBlock(mixerSettings);

                _pipeline.AddBlock(_backgroundSource);
                _pipeline.AddBlock(_videoMixer);

                // Connect: background -> mixer input 0
                // Connect: graphics -> mixer input 1 (overlay with alpha)
                _pipeline.Connect(_backgroundSource.Output, _videoMixer.Inputs[0]);
                _pipeline.Connect(overlay, _videoMixer.Inputs[1]);

                program = _videoMixer.Output;
            }
            else if (rbDecklinkInput.IsChecked == true && cbDecklinkInput.SelectedIndex >= 0)
            {
                // Add Decklink input as background
                var inputSettings = new DecklinkVideoSourceSettings((uint)cbDecklinkInput.SelectedIndex)
                {
                    Mode = (DecklinkMode)Enum.Parse(typeof(DecklinkMode), cbInputMode.SelectedItem.ToString())
                };
                var decklinkInput = new DecklinkVideoSourceBlock(inputSettings);

                // Create video mixer
                var mixerSettings = new VideoMixerBaseSettings(1920, 1080, GetSelectedFrameRate());
                mixerSettings.Background = VideoMixerBackground.Transparent;
                mixerSettings.AddStream(new VideoMixerStream(new VFRect(0, 0, 1920, 1080), 0)); // Background
                mixerSettings.AddStream(new VideoMixerStream(new VFRect(0, 0, 1920, 1080), 1)); // Overlay

                _videoMixer = new VideoMixerBlock(mixerSettings);

                _pipeline.AddBlock(decklinkInput);
                _pipeline.AddBlock(_videoMixer);

                _pipeline.Connect(decklinkInput.Output, _videoMixer.Inputs[0]);
                _pipeline.Connect(overlay, _videoMixer.Inputs[1]);

                program = _videoMixer.Output;
            }
            else if (rbTestPattern.IsChecked == true)
            {
                // Add test pattern as background
                var testPattern = new VirtualVideoSourceBlock(new VirtualVideoSourceSettings
                {
                    Width = 1920,
                    Height = 1080,
                    Pattern = VirtualVideoSourcePattern.SMPTE,
                    FrameRate = GetSelectedFrameRate(),
                    Format = VideoFormatX.RGBA  // Ensure RGBA format for compatibility with VideoMixer
                });

                // Create video mixer
                var mixerSettings = new VideoMixerBaseSettings(1920, 1080, GetSelectedFrameRate());
                mixerSettings.Background = VideoMixerBackground.Transparent;
                mixerSettings.AddStream(new VideoMixerStream(new VFRect(0, 0, 1920, 1080), 0)); // Background
                mixerSettings.AddStream(new VideoMixerStream(new VFRect(0, 0, 1920, 1080), 1)); // Overlay

                _videoMixer = new VideoMixerBlock(mixerSettings);

                _pipeline.AddBlock(testPattern);
                _pipeline.AddBlock(_videoMixer);

                _pipeline.Connect(testPattern.Output, _videoMixer.Inputs[0]);
                _pipeline.Connect(overlay, _videoMixer.Inputs[1]);

                program = _videoMixer.Output;
            }

            if (!keyerOn)
            {
                // Without the keyer, the card and the preview get the same mixed picture
                _pipeline.Connect(program, _outputTee.Input);
                _pipeline.Connect(_outputTee.Outputs[0], _decklinkSink.Input);
                program = _outputTee.Outputs[1];
            }

            // Add preview renderer
            var videoView = (VisioForge.Core.UI.WPF.VideoView)this.FindName("VideoViewBackground");
            if (videoView != null)
            {
                _previewRenderer = new VideoRendererBlock(_pipeline, videoView);
                _pipeline.AddBlock(_previewRenderer);
                _pipeline.Connect(program, _previewRenderer.Input);
            }

            // Start pipeline
            await _pipeline.StartAsync();
            _isRunning = true;

            // Start capture timer at the selected frame rate
            ClockTimer_Tick(this, EventArgs.Empty);
            _captureTimer.Interval = GetFrameDuration();
            _captureTimer.Start();
            _clockTimer.Start();
            _positionTimer.Start();
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await StopBroadcast();
        }

        private async System.Threading.Tasks.Task StopBroadcast()
        {
            try
            {
                _isRunning = false;
                _captureTimer.Stop();
                _clockTimer.Stop();
                _positionTimer.Stop();

                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    await _pipeline.DisposeAsync();
                    _pipeline = null;
                }

                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
                cbVideoMode.IsEnabled = true;
                lbStatus.Text = "Stopped";
                lbStatus.Foreground = Brushes.Green;
                lbTime.Text = "00:00:00";

                Log("Broadcast stopped");
            }
            catch (Exception ex)
            {
                Log($"Error stopping broadcast: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the capture timer tick event.
        /// </summary>
        private void CaptureTimer_Tick(object sender, EventArgs e)
        {
            if (!_isRunning || _graphicsSource == null || _graphicsOverlay == null)
                return;

            try
            {
                // Capture UserControl to frame
                CaptureUserControlToFrame(_graphicsOverlay);
                _graphicsSource.PushFrame(_frame);

                // Save frame for debugging if enabled
                if (cbSaveFrames.IsChecked == true)
                {
                    SaveDebugFrame(_frame);
                }
            }
            catch (Exception ex)
            {
                Log($"Capture error: {ex.Message}");
            }
        }

        /// <summary>
        /// Capture user control to frame.
        /// </summary>
        private void CaptureUserControlToFrame(UserControl control)
        {
            // Ensure proper layout
            control.Measure(new WinSize(1920, 1080));
            control.Arrange(new WinRect(0, 0, 1920, 1080));
            control.UpdateLayout();

            // Clear with transparent background
            _renderBitmap.Clear();

            // Render the control
            if (_graphicsVisible)
            {
                _renderBitmap.Render(control);
            }

            // Convert alpha if needed: WPF converts pre-multiplied to straight natively
            BitmapSource source = _renderBitmap;
            if (cbStraightAlpha.IsChecked == true && !cbPremultipliedAlpha.IsChecked == true)
            {
                source = _straightBitmap;
            }

            // Copy the pixels straight into the frame's buffer; PushFrame takes its own copy
            source.CopyPixels(new Int32Rect(0, 0, 1920, 1080), _frame.Data, _frame.DataSize, _frame.Stride);
        }

        /// <summary>
        /// Save debug frame.
        /// </summary>
        private void SaveDebugFrame(VideoFrameX frame)
        {
            // Save frames for debugging (limited to avoid disk space issues)
            int index = _debugFrameCount++;
            if (index % 100 == 0) // Save every 100th frame; after 100 files the oldest is overwritten
            {
                string debugDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "VisioForge", "DecklinkFillKey", "Frames");
                Directory.CreateDirectory(debugDir);

                string filename = Path.Combine(debugDir, $"frame_{index / 100 % 100:D2}.raw");

                File.WriteAllBytes(filename, frame.ToArray());
            }
        }

        /// <summary>
        /// Update clock.
        /// </summary>
        private void UpdateClock()
        {
            Dispatcher.Invoke(() =>
            {
                // Find and update clock text in the overlay
                if (_graphicsOverlay?.Content is Grid grid)
                {
                    foreach (var child in grid.Children)
                    {
                        if (child is Border border && border.Child is TextBlock clockText &&
                            clockText.FontFamily.Source == "Consolas")
                        {
                            clockText.Text = DateTime.Now.ToString("HH:mm:ss");
                            break;
                        }
                    }
                }
            });
        }

        /// <summary>
        /// Handles the clock timer tick event.
        /// </summary>
        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            if (_isRunning && cbShowClock.IsChecked == true)
            {
                UpdateClock();
            }
        }

        /// <summary>
        /// Position timer elapsed.
        /// </summary>
        private void PositionTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_pipeline != null && _isRunning)
            {
                var elapsed = DateTime.Now - _startTime;
                Dispatcher.Invoke(() =>
                {
                    lbTime.Text = elapsed.ToString(@"hh\:mm\:ss");
                });
            }
        }

        /// <summary>
        /// Get selected frame rate.
        /// </summary>
        private VideoFrameRate GetSelectedFrameRate()
        {
            // The output mode sets the rate; an interlaced mode's frame rate is half its field rate
            var mode = GetSelectedDecklinkMode();
            return mode switch
            {
                DecklinkMode.HD1080p25 or DecklinkMode.HD1080i50 => new VideoFrameRate(25, 1),
                DecklinkMode.HD1080p30 or DecklinkMode.HD1080i60 => new VideoFrameRate(30, 1),
                DecklinkMode.HD1080p50 => new VideoFrameRate(50, 1),
                DecklinkMode.HD1080p60 => new VideoFrameRate(60, 1),
                _ => throw new NotSupportedException($"Unsupported Decklink mode: {mode}")
            };
        }

        /// <summary>
        /// Get frame duration.
        /// </summary>
        private TimeSpan GetFrameDuration()
        {
            return TimeSpan.FromSeconds(1.0 / GetSelectedFrameRate().Value);
        }

        /// <summary>
        /// Get selected decklink mode.
        /// </summary>
        private DecklinkMode GetSelectedDecklinkMode()
        {
            return cbVideoMode.SelectedIndex switch
            {
                0 => DecklinkMode.HD1080p25,
                1 => DecklinkMode.HD1080p30,
                2 => DecklinkMode.HD1080p50,
                3 => DecklinkMode.HD1080p60,
                4 => DecklinkMode.HD1080i50,
                5 => DecklinkMode.HD1080i60,
                _ => DecklinkMode.HD1080p25
            };
        }

        /// <summary>
        /// Get selected video format.
        /// </summary>
        private DecklinkVideoFormat GetSelectedVideoFormat()
        {
            return cbVideoFormat.SelectedIndex switch
            {
                0 => DecklinkVideoFormat.YUV_8bit,
                1 => DecklinkVideoFormat.YUV_10bit,
                2 => DecklinkVideoFormat.ARGB_8bit,
                _ => DecklinkVideoFormat.YUV_10bit
            };
        }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                Log($"Pipeline Error: {e.Message}");
            });
        }

        /// <summary>
        /// Log.
        /// </summary>
        private void Log(string message)
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    if (mmLog != null)
                    {
                        string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
                        mmLog.AppendText($"[{timestamp}] {message}\n");
                        mmLog.ScrollToEnd();
                    }
                });
            }
            catch (Exception ex)
            {
                // Fallback to console if UI logging fails
                System.Diagnostics.Debug.WriteLine($"Log error: {ex.Message} - Original message: {message}");
            }
        }

        /// <summary>
        /// Handles the bt update graphics click event.
        /// </summary>
        private void btUpdateGraphics_Click(object sender, RoutedEventArgs e)
        {
            UpdateGraphicsContent();
            Log("Graphics content updated");
        }

        /// <summary>
        /// Handles the bt toggle graphics click event.
        /// </summary>
        private void btToggleGraphics_Click(object sender, RoutedEventArgs e)
        {
            _graphicsVisible = !_graphicsVisible;

            if (_graphicsVisible)
            {
                UpdateGraphicsContent();
                Log("Graphics shown");
            }
            else
            {
                _graphicsOverlay.Content = null;
                Log("Graphics hidden");
            }
        }

        /// <summary>
        /// Handles the bt refresh devices click event.
        /// </summary>
        private async void btRefreshDevices_Click(object sender, RoutedEventArgs e)
        {
            await LoadDecklinkDevices();
        }

        /// <summary>
        /// Handles the bt select video file click event.
        /// </summary>
        private void btSelectVideoFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Video files|*.mp4;*.mov;*.avi;*.mkv;*.wmv|All files|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                edVideoFile.Text = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Handles the bt clear log click event.
        /// </summary>
        private void btClearLog_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isRunning)
            {
                await StopBroadcast();
            }

            _captureTimer?.Stop();
            _clockTimer?.Stop();
            _positionTimer?.Stop();
            _positionTimer?.Dispose();
            _frame.Free();
        }
    }
}
