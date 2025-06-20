using Microsoft.Win32;
using SkiaSharp;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;

namespace MediaBlocks_ChromaKey_Demo_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml - ChromaKey Demo
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;
        private VideoRendererBlock _videoRenderer;
        private AudioRendererBlock _audioRenderer;
        private SystemVideoSourceBlock _videoSource;
        private UniversalSourceBlock _videoFileSource;
        private SystemAudioSourceBlock _audioSource;
        private ImageVideoSourceBlock _backgroundSource;
        private ChromaKeyBlock _chromaKeyBlock;
        private System.Timers.Timer _timer;

        private VisioForge.Core.Types.Size _videoResolution;

        private System.Windows.Forms.ColorDialog _colorDialog;
        private SKColor _customChromaColor = SKColors.Lime;
        private System.Drawing.Color _backgroundColor = System.Drawing.Color.Blue;

        public MainWindow()
        {
            InitializeComponent();
            _colorDialog = new System.Windows.Forms.ColorDialog();
        }

        private void DeviceEnumerator_OnAudioSinkAdded(object sender, AudioOutputDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbAudioOutput.Items.Add(e.DisplayName);
                if (cbAudioOutput.Items.Count == 1)
                    cbAudioOutput.SelectedIndex = 0;
            });
        }

        private void DeviceEnumerator_OnAudioSourceAdded(object sender, AudioCaptureDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbAudioInput.Items.Add(e.DisplayName);
                if (cbAudioInput.Items.Count == 1)
                {
                    cbAudioInput.SelectedIndex = 0;
                    cbAudioInput_SelectionChanged(null, null);
                }
            });
        }

        private void DeviceEnumerator_OnVideoSourceAdded(object sender, VideoCaptureDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbVideoInput.Items.Add(e.DisplayName);
                if (cbVideoInput.Items.Count == 1)
                {
                    cbVideoInput.SelectedIndex = 0;
                    cbVideoInput_SelectionChanged(null, null);
                }
            });
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
                mmLog.ScrollToEnd();
            });
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                IsEnabled = true;
                Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

                DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;
                DeviceEnumerator.Shared.OnAudioSourceAdded += DeviceEnumerator_OnAudioSourceAdded;
                DeviceEnumerator.Shared.OnAudioSinkAdded += DeviceEnumerator_OnAudioSinkAdded;

                _timer = new System.Timers.Timer(500);
                _timer.Elapsed += Timer_Elapsed;

                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();
                await DeviceEnumerator.Shared.StartAudioSourceMonitorAsync();
                await DeviceEnumerator.Shared.StartAudioSinkMonitorAsync();

                LogMessage("Application initialized successfully.");
            }
            catch (Exception ex)
            {
                LogMessage($"Error during initialization: {ex.Message}");
                MessageBox.Show(this, $"Error during initialization: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Clean up any existing pipeline
                await StopPipeline();

                // Create new pipeline
                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;
                _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
                _pipeline.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

                mmLog.Clear();

                LogMessage("Starting ChromaKey preview...");

                // Create video source based on selected type
                bool isVideoFileSource = cbVideoSourceType.SelectedIndex == 1;

                if (isVideoFileSource)
                {
                    // Video file source
                    if (!await CreateVideoFileSourceAsync())
                    {
                        LogMessage("Error: Could not configure video file source.");
                        return;
                    }
                }
                else
                {
                    // Camera source
                    if (cbVideoInput.SelectedIndex < 0)
                    {
                        MessageBox.Show(this, "Please select a video input device", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    VideoCaptureDeviceSourceSettings videoSourceSettings = await GetVideoSourceSettings();
                    if (videoSourceSettings == null)
                    {
                        LogMessage("Error: Could not configure video source.");
                        return;
                    }

                    _videoResolution = new VisioForge.Core.Types.Size(videoSourceSettings.Format.Width, videoSourceSettings.Format.Height);

                    _videoSource = new SystemVideoSourceBlock(videoSourceSettings);
                }

                // Create background source
                CreateBackgroundSource();

                // Create ChromaKey block
                CreateChromaKeyBlock();

                // Create video renderer
                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

                // Create audio source and renderer (optional)
                await CreateAudioBlocks();

                // Build pipeline
                BuildPipeline();

                // Start pipeline
                await _pipeline.StartAsync();

                _timer.Start();

                // Update UI
                btStart.IsEnabled = false;
                btStop.IsEnabled = true;

                LogMessage("ChromaKey preview started successfully.");
            }
            catch (Exception ex)
            {
                LogMessage($"Error starting preview: {ex.Message}");
                MessageBox.Show(this, $"Error starting preview: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                await StopPipeline();
            }
        }

        private async Task<VideoCaptureDeviceSourceSettings> GetVideoSourceSettings()
        {
            var deviceName = cbVideoInput.Text;
            var format = cbVideoFormat.Text;

            if (string.IsNullOrEmpty(deviceName) || string.IsNullOrEmpty(format))
                return null;

            var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
            if (device == null)
                return null;

            var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
            if (formatItem == null)
                return null;

            var settings = new VideoCaptureDeviceSourceSettings(device)
            {
                Format = formatItem.ToFormat()
            };

            if (cbVideoFrameRate.SelectedValue != null)
            {
                settings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.Text));
            }

            return settings;
        }

        private void CreateBackgroundSource()
        {
            // Use image file background
            if (!File.Exists(edBackgroundImage.Text))
            {
                LogMessage("Warning: Background image file not found.");
                return;
            }

            var imageSettings = new ImageVideoSourceSettings(edBackgroundImage.Text)
            {
                FrameRate = new VideoFrameRate(30.0)
            };

            _backgroundSource = new ImageVideoSourceBlock(imageSettings);
        }

        private void CreateChromaKeyBlock()
        {
            var chromaKeySettings = GetChromaKeySettings();
            _chromaKeyBlock = new ChromaKeyBlock(chromaKeySettings);
        }

        private VisioForge.Core.Types.X.VideoEffects.ChromaKeySettingsX GetChromaKeySettings()
        {
            var settings = new ChromaKeySettingsX(_videoResolution)
            {
                Sensitivity = slSensitivity.Value,
                NoiseLevel = slNoiseLevel.Value,
                BlackSensitivity = (uint)slBlackSensitivity.Value,
                WhiteSensitivity = (uint)slWhiteSensitivity.Value,
                Alpha = slAlpha.Value,
                PreferPassthrough = cbPreferPassthrough.IsChecked == true
            };

            switch (cbChromaColor.SelectedIndex)
            {
                case 0: settings.ChromaColor = ChromaKeyColor.Green; break;
                case 1: settings.ChromaColor = ChromaKeyColor.Blue; break;
                case 2:
                    settings.ChromaColor = ChromaKeyColor.Custom;
                    settings.CustomColor = _customChromaColor;
                    break;
                default: settings.ChromaColor = ChromaKeyColor.Green; break;
            }

            return settings;
        }

        private async Task<bool> CreateVideoFileSourceAsync()
        {
            if (string.IsNullOrEmpty(edVideoFile.Text) || !File.Exists(edVideoFile.Text))
            {
                LogMessage("Error: Video file not found or path is empty.");
                return false;
            }

            try
            {
                var settings = await UniversalSourceSettings.CreateAsync(
                    edVideoFile.Text,
                    renderVideo: true,
                    renderAudio: true,
                    renderSubtitle: false);

                var videoStream = settings.GetInfo().VideoStreams.FirstOrDefault();
                _videoResolution = new VisioForge.Core.Types.Size(videoStream.Width, videoStream.Height);

                _videoFileSource = new UniversalSourceBlock(settings);
                LogMessage($"Video file source created: {edVideoFile.Text}");
                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"Error creating video file source: {ex.Message}");
                return false;
            }
        }

        private async Task CreateAudioBlocks()
        {
            // Create audio source if available
            if (cbAudioInput.SelectedIndex >= 0)
            {
                var audioDeviceName = cbAudioInput.Text;
                var audioFormat = cbAudioFormat.Text;

                if (!string.IsNullOrEmpty(audioDeviceName))
                {
                    var audioDevice = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == audioDeviceName);
                    if (audioDevice != null)
                    {
                        var audioFormatItem = audioDevice.Formats.FirstOrDefault(x => x.Name == audioFormat);
                        if (audioFormatItem != null)
                        {
                            var audioSourceSettings = audioDevice.CreateSourceSettings(audioFormatItem.ToFormat());
                            _audioSource = new SystemAudioSourceBlock(audioSourceSettings);
                        }
                    }
                }
            }

            // Create audio renderer
            var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync()).FirstOrDefault(x => x.DisplayName == cbAudioOutput.Text);
            if (audioOutputDevice != null)
            {
                var audioOutputSettings = new AudioRendererSettings(audioOutputDevice);
                _audioRenderer = new AudioRendererBlock(audioOutputSettings);
            }
        }

        private void BuildPipeline()
        {
            // Determine which video source to use
            MediaBlockPad videoSourcePad = null;
            if (_videoSource != null)
            {
                videoSourcePad = _videoSource.Output;
            }
            else if (_videoFileSource != null)
            {
                videoSourcePad = _videoFileSource.VideoOutput;
            }

            if (videoSourcePad == null)
            {
                LogMessage("Error: No video source available for pipeline.");
                return;
            }

            // Connect video pipeline
            _pipeline.Connect(videoSourcePad, _chromaKeyBlock.ChromaInput);
            _pipeline.Connect(_backgroundSource.Output, _chromaKeyBlock.BackgroundInput);

            _pipeline.Connect(_chromaKeyBlock.Output, _videoRenderer.Input);

            // Connect audio if available
            if (_audioSource != null && _audioRenderer != null)
            {
                _pipeline.Connect(_audioSource.Output, _audioRenderer.Input);
            }
            else if (_videoFileSource != null && _audioRenderer != null)
            {
                // Use audio from video file if available
                _pipeline.Connect(_videoFileSource.AudioOutput, _audioRenderer.Input);
            }

            LogMessage("Pipeline built successfully.");
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await StopPipeline();
        }

        private async Task StopPipeline()
        {
            try
            {
                _timer?.Stop();

                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    _pipeline.OnError -= Pipeline_OnError;
                    _pipeline.Dispose();
                    _pipeline = null;
                }

                // Clean up all blocks
                _videoSource?.Dispose();
                _videoSource = null;

                _videoFileSource?.Dispose();
                _videoFileSource = null;

                _backgroundSource?.Dispose();
                _backgroundSource = null;

                _chromaKeyBlock?.Dispose();
                _chromaKeyBlock = null;

                _videoRenderer?.Dispose();
                _videoRenderer = null;

                _audioSource?.Dispose();
                _audioSource = null;

                _audioRenderer?.Dispose();
                _audioRenderer = null;

                btStart.IsEnabled = true;
                btStop.IsEnabled = false;

                LogMessage("Preview stopped.");
            }
            catch (Exception ex)
            {
                LogMessage($"Error stopping pipeline: {ex.Message}");
            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Update status if needed
        }

        #region UI Event Handlers

        private async void cbVideoInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbVideoFormat.Items.Clear();
            cbVideoFrameRate.Items.Clear();

            if (cbVideoInput.SelectedIndex >= 0)
            {
                var deviceName = cbVideoInput.Text;
                var devices = await DeviceEnumerator.Shared.VideoSourcesAsync();
                var device = devices.FirstOrDefault(x => x.DisplayName == deviceName);

                if (device != null)
                {
                    foreach (var format in device.VideoFormats)
                    {
                        cbVideoFormat.Items.Add(format.Name);
                    }

                    if (cbVideoFormat.Items.Count > 0)
                        cbVideoFormat.SelectedIndex = 0;
                }
            }
        }

        private async void cbVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbVideoFrameRate.Items.Clear();

            var devices = await DeviceEnumerator.Shared.VideoSourcesAsync();
            var device = devices.FirstOrDefault(x => x.DisplayName == cbVideoInput.Text);
            if (device == null || cbVideoFormat.SelectedIndex < 0)
            {
                return;
            }

            var format = device.VideoFormats.FirstOrDefault(x => x.Name == cbVideoFormat.Text);
            if (format == null)
            {
                return;
            }

            // Populate frame rates based on selected video format
            if (format.FrameRateList == null || format.FrameRateList.Count == 0)
            {
                LogMessage("No frame rates available for the selected video format.");
                return;
            }

            // Add available frame rates to the combo box
            foreach (var frameRate in format.FrameRateList)
            {
                cbVideoFrameRate.Items.Add(frameRate.ToString());
            }

            if (cbVideoFormat.SelectedIndex >= 0)
            {
                cbVideoFrameRate.SelectedIndex = 0;
            }
        }

        private async void cbAudioInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbAudioFormat.Items.Clear();

            if (cbAudioInput.SelectedIndex >= 0)
            {
                var deviceName = cbAudioInput.Text;
                var devices = await DeviceEnumerator.Shared.AudioSourcesAsync();
                var device = devices.FirstOrDefault(x => x.DisplayName == deviceName);

                if (device != null)
                {
                    foreach (var format in device.Formats)
                    {
                        cbAudioFormat.Items.Add(format.Name);
                    }

                    if (cbAudioFormat.Items.Count > 0)
                        cbAudioFormat.SelectedIndex = 0;
                }
            }
        }

        private void btSelectBackground_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*",
                Title = "Select Background Image"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                edBackgroundImage.Text = openFileDialog.FileName;
            }
        }

        private void btSelectVideoFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Video files (*.mp4;*.avi;*.mkv;*.webm;*.mov;*.wmv;*.flv;*.ts;*.m4v)|*.mp4;*.avi;*.mkv;*.webm;*.mov;*.wmv;*.flv;*.ts;*.m4v|All files (*.*)|*.*",
                Title = "Select Video File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                edVideoFile.Text = openFileDialog.FileName;
            }
        }

        private void cbVideoSourceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pnCameraSource == null || pnVideoFileSource == null)
            {
                return;
            }

            if (cbVideoSourceType.SelectedIndex == 0)
            {
                // Camera/Capture Device
                pnCameraSource.Visibility = Visibility.Visible;
                pnVideoFileSource.Visibility = Visibility.Collapsed;
            }
            else
            {
                // Video File
                pnCameraSource.Visibility = Visibility.Collapsed;
                pnVideoFileSource.Visibility = Visibility.Visible;
            }
        }

        private void btBackgroundColor_Click(object sender, RoutedEventArgs e)
        {
            _colorDialog.Color = _backgroundColor;
            if (_colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _backgroundColor = _colorDialog.Color;
                var button = sender as Button;
                var rectangle = button?.Content as Rectangle;
                if (rectangle != null)
                {
                    rectangle.Fill = new SolidColorBrush(Color.FromArgb(_backgroundColor.A, _backgroundColor.R, _backgroundColor.G, _backgroundColor.B));
                }
            }
        }

        private void btCustomColor_Click(object sender, RoutedEventArgs e)
        {
            // Convert SKColor to System.Drawing.Color for the dialog
            _colorDialog.Color = System.Drawing.Color.FromArgb(_customChromaColor.Alpha, _customChromaColor.Red, _customChromaColor.Green, _customChromaColor.Blue);
            
            if (_colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Convert System.Drawing.Color back to SKColor
                var dialogColor = _colorDialog.Color;
                _customChromaColor = new SKColor(dialogColor.R, dialogColor.G, dialogColor.B, dialogColor.A);
                
                var button = sender as Button;
                var rectangle = button?.Content as Rectangle;
                if (rectangle != null)
                {
                    rectangle.Fill = new SolidColorBrush(Color.FromArgb(_customChromaColor.Alpha, _customChromaColor.Red, _customChromaColor.Green, _customChromaColor.Blue));
                }

                UpdateChromaKeySettings();
            }
        }

        private void cbChromaColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pnCustomColor == null)
            {
                return;
            }

            pnCustomColor.Visibility = cbChromaColor.SelectedIndex == 2 ? Visibility.Visible : Visibility.Collapsed;
            UpdateChromaKeySettings();
        }

        private void slAlpha_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbAlpha != null)
                lbAlpha.Content = e.NewValue.ToString("F2");
            UpdateChromaKeySettings();
        }

        private void slSensitivity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbSensitivity != null)
                lbSensitivity.Content = e.NewValue.ToString("F1");
            UpdateChromaKeySettings();
        }

        private void slNoiseLevel_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbNoiseLevel != null)
                lbNoiseLevel.Content = e.NewValue.ToString("F1");
            UpdateChromaKeySettings();
        }

        private void slBlackSensitivity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbBlackSensitivity != null)
                lbBlackSensitivity.Content = ((uint)e.NewValue).ToString();
            UpdateChromaKeySettings();
        }

        private void slWhiteSensitivity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbWhiteSensitivity != null)
                lbWhiteSensitivity.Content = ((uint)e.NewValue).ToString();
            UpdateChromaKeySettings();
        }

        private void cbPreferPassthrough_Changed(object sender, RoutedEventArgs e)
        {
            UpdateChromaKeySettings();
        }

        private void slVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_audioRenderer != null && _pipeline != null && _pipeline.State == PlaybackState.Play)
            {
                _audioRenderer.Volume = e.NewValue;
            }
        }

        private void cbUseColorBackground_Checked(object sender, RoutedEventArgs e)
        {
            edBackgroundImage.IsEnabled = false;
            btSelectBackground.IsEnabled = false;
        }

        private void cbUseColorBackground_Unchecked(object sender, RoutedEventArgs e)
        {
            edBackgroundImage.IsEnabled = true;
            btSelectBackground.IsEnabled = true;
        }

        #endregion

        #region Helper Methods

        private void UpdateChromaKeySettings()
        {
            if (_chromaKeyBlock != null && _pipeline != null && _pipeline.State == PlaybackState.Play)
            {
                var settings = GetChromaKeySettings();
                _chromaKeyBlock.UpdateSettings(settings);
            }
        }

        private void LogMessage(string message)
        {
            Dispatcher.Invoke(() =>
            {
                mmLog.Text += $"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}";
                mmLog.ScrollToEnd();
            });
        }

        #endregion

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                await StopPipeline();

                _pipeline?.Dispose();
                DeviceEnumerator.Shared.OnVideoSourceAdded -= DeviceEnumerator_OnVideoSourceAdded;
                DeviceEnumerator.Shared.OnAudioSourceAdded -= DeviceEnumerator_OnAudioSourceAdded;
                DeviceEnumerator.Shared.OnAudioSinkAdded -= DeviceEnumerator_OnAudioSinkAdded;
                _timer?.Dispose();
                _colorDialog?.Dispose();
            }
            catch (Exception ex)
            {
                LogMessage($"Error during cleanup: {ex.Message}");
            }
        }
    }
}