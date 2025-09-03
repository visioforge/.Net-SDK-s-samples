using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
        private DecklinkVideoSinkBlock _decklinkFillSink;
        private DecklinkVideoSinkBlock _decklinkKeySink;
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
        }

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
            _captureTimer.Interval = TimeSpan.FromMilliseconds(40); // 25fps
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
                    
                    // Note for Fill+Key mode
                    if (outputDevices.Length >= 2)
                    {
                        Log("Fill+Key mode available: Will use consecutive outputs for Fill and Key signals");
                    }
                    else
                    {
                        Log("WARNING: Fill+Key mode requires at least 2 outputs. Only internal keying available.");
                    }
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

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbDecklinkDevice.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a Decklink output device.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                
                // Check if Fill+Key mode is properly configured
                if (cbEnableKeyer.IsChecked == true && cbVideoFormat.SelectedIndex == 2)
                {
                    var outputDevices = await DecklinkVideoSinkBlock.GetDevicesAsync();
                    uint selectedDevice = (uint)cbDecklinkDevice.SelectedIndex;
                    
                    if (selectedDevice + 1 >= outputDevices.Length)
                    {
                        MessageBox.Show(
                            $"Fill+Key mode requires two consecutive outputs.\n" +
                            $"Selected device {selectedDevice} needs device {selectedDevice + 1} for Key output.\n" +
                            $"Please select a lower device number or use Internal keyer mode.",
                            "Configuration Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        return;
                    }
                    
                    Log($"Fill+Key mode: Using device {selectedDevice} for Fill and device {selectedDevice + 1} for Key");
                }

                btStart.IsEnabled = false;
                lbStatus.Text = "Initializing...";
                lbStatus.Foreground = Brushes.Orange;

                await StartBroadcast();

                btStart.IsEnabled = false;
                btStop.IsEnabled = true;
                lbStatus.Text = "Broadcasting";
                lbStatus.Foreground = Brushes.Red;
                _startTime = DateTime.Now;

                bool isFillKeyMode = cbEnableKeyer.IsChecked == true && cbVideoFormat.SelectedIndex == 2;
                if (isFillKeyMode)
                {
                    uint device = (uint)cbDecklinkDevice.SelectedIndex;
                    Log($"Broadcast started in Fill+Key mode");
                    Log($"  Fill signal on device {device}");
                    Log($"  Key signal on device {device + 1}");
                }
                else
                {
                    Log("Broadcast started successfully");
                }
            }
            catch (Exception ex)
            {
                Log($"Error starting broadcast: {ex.Message}");
                MessageBox.Show($"Failed to start broadcast: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
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

            // Configure Decklink outputs for Fill+Key mode
            uint deviceNumber = (uint)cbDecklinkDevice.SelectedIndex;
            
            // Determine if we're using Fill+Key (External keyer) or Internal keyer
            bool useFillKey = cbEnableKeyer.IsChecked == true && cbVideoFormat.SelectedIndex == 2; // ARGB_8bit is required for Fill+Key
            
            if (useFillKey)
            {
                Log("Configuring Fill+Key mode with External keyer...");
                
                // Fill output (device N) - contains the composited video
                var fillSettings = new DecklinkVideoSinkSettings
                {
                    DeviceNumber = deviceNumber,
                    Mode = GetSelectedDecklinkMode(),
                    VideoFormat = DecklinkVideoFormat.ARGB_8bit, // Must be ARGB for Fill+Key
                    KeyerMode = DecklinkKeyerMode.External,
                    IsSync = true
                };
                _decklinkFillSink = new DecklinkVideoSinkBlock(fillSettings);
                
                // Key output (device N+1) - contains the alpha channel
                var keySettings = new DecklinkVideoSinkSettings
                {
                    DeviceNumber = deviceNumber + 1, // Next consecutive output
                    Mode = GetSelectedDecklinkMode(),
                    VideoFormat = DecklinkVideoFormat.ARGB_8bit, // Must match Fill format
                    KeyerMode = DecklinkKeyerMode.Off, // Key output doesn't use keyer
                    IsSync = true
                };
                _decklinkKeySink = new DecklinkVideoSinkBlock(keySettings);
            }
            else
            {
                // Single output with Internal keyer or no keying
                Log($"Configuring single output with {(cbEnableKeyer.IsChecked == true ? "Internal keyer" : "no keying")}...");
                
                var decklinkSettings = new DecklinkVideoSinkSettings
                {
                    DeviceNumber = deviceNumber,
                    Mode = GetSelectedDecklinkMode(),
                    VideoFormat = GetSelectedVideoFormat(),
                    KeyerMode = cbEnableKeyer.IsChecked == true ? DecklinkKeyerMode.Internal : DecklinkKeyerMode.Off,
                    KeyerLevel = (int)slKeyerLevel.Value,
                    IsSync = true
                };
                _decklinkFillSink = new DecklinkVideoSinkBlock(decklinkSettings);
            }

            // Build pipeline based on background source
            MediaBlock finalOutput = _graphicsSource;

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
                _pipeline.AddBlock(_graphicsSource);
                
                // Connect: background -> mixer input 0
                // Connect: graphics -> mixer input 1 (overlay with alpha)
                _pipeline.Connect(_backgroundSource.Output, _videoMixer.Inputs[0]);
                _pipeline.Connect(_graphicsSource.Output, _videoMixer.Inputs[1]);
                
                finalOutput = _videoMixer;
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
                _pipeline.AddBlock(_graphicsSource);
                
                _pipeline.Connect(decklinkInput.Output, _videoMixer.Inputs[0]);
                _pipeline.Connect(_graphicsSource.Output, _videoMixer.Inputs[1]);
                
                finalOutput = _videoMixer;
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
                _pipeline.AddBlock(_graphicsSource);
                
                _pipeline.Connect(testPattern.Output, _videoMixer.Inputs[0]);
                _pipeline.Connect(_graphicsSource.Output, _videoMixer.Inputs[1]);
                
                finalOutput = _videoMixer;
            }
            else
            {
                // Graphics only
                _pipeline.AddBlock(_graphicsSource);
            }

            // Add tee for preview and output
            bool useFillKeyMode = cbEnableKeyer.IsChecked == true && cbVideoFormat.SelectedIndex == 2;
            
            if (useFillKeyMode && _decklinkKeySink != null)
            {
                // Fill+Key mode: Need to split output to Fill and Key
                _outputTee = new TeeBlock(3, MediaBlockPadMediaType.Video); // 3 outputs: Fill, Key, Preview
                _pipeline.AddBlock(_outputTee);
                _pipeline.Connect(finalOutput.Output, _outputTee.Input);
                
                // Connect Fill output (full composited video)
                _pipeline.AddBlock(_decklinkFillSink);
                _pipeline.Connect(_outputTee.Outputs[0], _decklinkFillSink.Input);
                
                // For Key output, we need to extract just the alpha channel
                // In Fill+Key mode, the key signal is typically the alpha channel
                // Since we're sending ARGB, the Decklink will extract the alpha for the key
                _pipeline.AddBlock(_decklinkKeySink);
                _pipeline.Connect(_outputTee.Outputs[1], _decklinkKeySink.Input);
                
                // Use output 2 for preview
                var previewOutput = _outputTee.Outputs[2];
                
                // Add preview renderer
                var videoView = (VisioForge.Core.UI.WPF.VideoView)this.FindName("VideoViewBackground");
                if (videoView != null)
                {
                    _previewRenderer = new VideoRendererBlock(_pipeline, videoView);
                    _pipeline.AddBlock(_previewRenderer);
                    _pipeline.Connect(previewOutput, _previewRenderer.Input);
                }
            }
            else
            {
                // Single output mode
                _outputTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
                _pipeline.AddBlock(_outputTee);
                _pipeline.Connect(finalOutput.Output, _outputTee.Input);
                
                // Connect to Decklink output
                _pipeline.AddBlock(_decklinkFillSink);
                _pipeline.Connect(_outputTee.Outputs[0], _decklinkFillSink.Input);
                
                // Add preview renderer
                var videoView = (VisioForge.Core.UI.WPF.VideoView)this.FindName("VideoViewBackground");
                if (videoView != null)
                {
                    _previewRenderer = new VideoRendererBlock(_pipeline, videoView);
                    _pipeline.AddBlock(_previewRenderer);
                    _pipeline.Connect(_outputTee.Outputs[1], _previewRenderer.Input);
                }
            }

            // Preview handling is now done in the tee section above

            // Start pipeline
            await _pipeline.StartAsync();
            _isRunning = true;

            // Start capture timer
            _captureTimer.Start();
            _clockTimer.Start();
            _positionTimer.Start();
        }

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

        private void CaptureTimer_Tick(object sender, EventArgs e)
        {
            if (!_isRunning || _graphicsSource == null || _graphicsOverlay == null)
                return;

            try
            {
                // Update clock if enabled
                if (cbShowClock.IsChecked == true)
                {
                    UpdateClock();
                }

                // Capture UserControl to frame
                var frame = CaptureUserControlToFrame(_graphicsOverlay);
                if (frame != null)
                {
                    _graphicsSource.PushFrame(frame);
                    
                    // Save frame for debugging if enabled
                    if (cbSaveFrames.IsChecked == true)
                    {
                        SaveDebugFrame(frame);
                    }
                    
                    frame.Free();
                }
            }
            catch (Exception ex)
            {
                Log($"Capture error: {ex.Message}");
            }
        }

        private VideoFrameX CaptureUserControlToFrame(UserControl control)
        {
            if (!control.Dispatcher.CheckAccess())
            {
                return control.Dispatcher.Invoke(() => CaptureUserControlToFrame(control));
            }

            // Ensure proper layout
            control.Measure(new WinSize(1920, 1080));
            control.Arrange(new WinRect(0, 0, 1920, 1080));
            control.UpdateLayout();

            // Create render target with alpha
            var renderBitmap = new RenderTargetBitmap(1920, 1080, 96, 96, PixelFormats.Pbgra32);
            
            // Clear with transparent background
            var drawingVisual = new DrawingVisual();
            using (var drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawRectangle(Brushes.Transparent, null, new WinRect(0, 0, 1920, 1080));
            }
            renderBitmap.Render(drawingVisual);

            // Render the control
            if (_graphicsVisible)
            {
                renderBitmap.Render(control);
            }

            // Get pixel data
            int stride = renderBitmap.PixelWidth * 4;
            int size = stride * renderBitmap.PixelHeight;
            byte[] pixels = new byte[size];
            renderBitmap.CopyPixels(pixels, stride, 0);

            // Convert alpha if needed
            if (cbStraightAlpha.IsChecked == true && !cbPremultipliedAlpha.IsChecked == true)
            {
                ConvertPreMultipliedToStraightAlpha(pixels);
            }

            // Create frame
            var frame = new VideoFrameX(pixels, 1920, 1080, stride, VideoFormatX.BGRA);
            frame.Timestamp = TimeSpan.FromMilliseconds(Environment.TickCount);
            frame.Duration = GetFrameDuration();

            return frame;
        }

        private void ConvertPreMultipliedToStraightAlpha(byte[] pixels)
        {
            for (int i = 0; i < pixels.Length; i += 4)
            {
                byte alpha = pixels[i + 3];
                if (alpha != 0 && alpha != 255)
                {
                    float alphaFloat = alpha / 255.0f;
                    pixels[i] = (byte)Math.Min(255, pixels[i] / alphaFloat);     // B
                    pixels[i + 1] = (byte)Math.Min(255, pixels[i + 1] / alphaFloat); // G
                    pixels[i + 2] = (byte)Math.Min(255, pixels[i + 2] / alphaFloat); // R
                }
            }
        }

        private void SaveDebugFrame(VideoFrameX frame)
        {
            // Save frames for debugging (limited to avoid disk space issues)
            int frameCount = 0;
            if (frameCount++ % 100 == 0) // Save every 100th frame
            {
                string debugDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), 
                    "VisioForge", "DecklinkFillKey", "Frames");
                Directory.CreateDirectory(debugDir);
                
                string filename = Path.Combine(debugDir, $"frame_{frameCount:D6}.raw");
                
                byte[] data = new byte[frame.DataSize];
                Marshal.Copy(frame.Data, data, 0, frame.DataSize);
                File.WriteAllBytes(filename, data);
            }
        }

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

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            if (_isRunning && cbShowClock.IsChecked == true)
            {
                UpdateClock();
            }
        }

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

        private VideoFrameRate GetSelectedFrameRate()
        {
            return cbFrameRate.SelectedIndex switch
            {
                0 => new VideoFrameRate(25, 1),    // 25 fps
                1 => new VideoFrameRate(30, 1),    // 30 fps
                2 => new VideoFrameRate(50, 1),    // 50 fps
                3 => new VideoFrameRate(60, 1),    // 60 fps
                _ => new VideoFrameRate(25, 1)
            };
        }

        private TimeSpan GetFrameDuration()
        {
            return cbFrameRate.SelectedIndex switch
            {
                0 => TimeSpan.FromMilliseconds(40),    // 25 fps
                1 => TimeSpan.FromMilliseconds(33.33), // 30 fps
                2 => TimeSpan.FromMilliseconds(20),    // 50 fps
                3 => TimeSpan.FromMilliseconds(16.67), // 60 fps
                _ => TimeSpan.FromMilliseconds(40)
            };
        }

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

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                Log($"Pipeline Error: {e.Message}");
            });
        }

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

        private void btUpdateGraphics_Click(object sender, RoutedEventArgs e)
        {
            UpdateGraphicsContent();
            Log("Graphics content updated");
        }
        
        private void cbEnableKeyer_Checked(object sender, RoutedEventArgs e)
        {
            if (cbVideoFormat != null && cbVideoFormat.SelectedIndex == 2)
            {
                Log("Fill+Key mode enabled - Will use External keyer with two outputs");
            }
            else
            {
                Log("Internal keyer mode enabled");
            }
        }
        
        private void cbVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbEnableKeyer != null && cbEnableKeyer.IsChecked == true && cbVideoFormat.SelectedIndex == 2)
            {
                Log("ARGB format selected with keyer - Fill+Key mode will be used");
            }
        }

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

        private async void btRefreshDevices_Click(object sender, RoutedEventArgs e)
        {
            await LoadDecklinkDevices();
        }

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

        private void btClearLog_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();
        }

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
        }
    }
}