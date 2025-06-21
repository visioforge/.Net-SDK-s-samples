using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using SkiaSharp;

using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.X.Sources;
using Microsoft.Win32;
using VisioForge.Core.Types.Events;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types;
using Rect = VisioForge.Core.Types.Rect;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.UI.WPF.Dialogs.Sources;
using VisioForge.Core;
using VisioForge.Core.Types.X.OpenGL;
using Size = VisioForge.Core.Types.Size;

namespace Video_Compositor_Demo
{
    public enum LogLevel
    {
        Error = 0,
        Warning = 1,
        Info = 2,
        Debug = 3
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<CompositorSource> _sources = new List<CompositorSource>();

        private MediaBlocksPipeline _pipeline;

        private bool _isUpdatingUI = false;

        private VideoRendererBlock _videoRenderer;

        private TeeBlock _videoTee;

        private MP4OutputBlock _mp4Output;

        private YouTubeOutputBlock _youTubeOutput;

        private FacebookLiveOutputBlock _facebookOutput;

        private NDISinkBlock _ndiSink;

        private VideoMixerBlock _videoMixer;

        private VirtualAudioSourceBlock _fakeAudioSource;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                LogMessage($"ERROR: {e.Message}", LogLevel.Error);
            }));
        }

        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            
            LogMessage("Media pipeline created", LogLevel.Info);
        }

        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                LogMessage("Destroying media pipeline", LogLevel.Info);
                _pipeline.OnError -= Pipeline_OnError;
                await _pipeline.DisposeAsync();
                _pipeline = null;
                LogMessage("Media pipeline destroyed", LogLevel.Info);
            }
        }

        private async void btAddCamera_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new VideoCaptureSourceDialog();
            if (dlg.ShowDialog() == true)
            {
                var src = new CompositorSource();

                VideoCaptureDeviceSourceSettings settings = null;

                var deviceName = dlg.Device;
                var format = dlg.Format;
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = (await SystemVideoSourceBlock.GetDevicesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
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

                src.Source = new SystemVideoSourceBlock(settings);
                src.Rectangle = new Rect(Convert.ToInt32(edRectLeft.Text), Convert.ToInt32(edRectTop.Text), Convert.ToInt32(edRectRight.Text), Convert.ToInt32(edRectBottom.Text));
                src.DisplayName = $"Camera [{dlg.Device}]";
                src.ZOrder = _sources.Count; // Set default z-order

                _sources.Add(src);

                cbSources.Items.Add(src.DisplayName + $" (Z:{src.ZOrder})");
                cbSources.SelectedIndex = cbSources.Items.Count - 1;
            }
        }

        private void btAddScreen_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ScreenSourceDialog();
            if (dlg.ShowDialog() == true)
            {
                var src = new CompositorSource();
                var settings = new ScreenCaptureDX9SourceSettings();
                settings.CaptureCursor = dlg.GrabMouseCursor;
                settings.Monitor = dlg.DisplayIndex;
                settings.FrameRate = dlg.FrameRate;
                settings.Rectangle = dlg.Rectangle;
                src.Source = new ScreenSourceBlock(settings);
                src.Rectangle = new Rect(Convert.ToInt32(edRectLeft.Text), Convert.ToInt32(edRectTop.Text), Convert.ToInt32(edRectRight.Text), Convert.ToInt32(edRectBottom.Text));
                src.DisplayName = $"Screen [{dlg.DisplayIndex}] {dlg.Rectangle.Width}x{dlg.Rectangle.Height}";
                src.ZOrder = _sources.Count; // Set default z-order

                _sources.Add(src);

                cbSources.Items.Add(src.DisplayName + $" (Z:{src.ZOrder})");
                cbSources.SelectedIndex = cbSources.Items.Count - 1;
            }
        }

        private async void btAddFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                var src = new CompositorSource();
                src.Source = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(dlg.FileName, renderAudio: false));
                src.Rectangle = new Rect(Convert.ToInt32(edRectLeft.Text), Convert.ToInt32(edRectTop.Text), Convert.ToInt32(edRectRight.Text), Convert.ToInt32(edRectBottom.Text));
                src.DisplayName = $"Video [{System.IO.Path.GetFileName(dlg.FileName)}]";
                src.ZOrder = _sources.Count; // Set default z-order

                _sources.Add(src);

                cbSources.Items.Add(src.DisplayName + $" (Z:{src.ZOrder})");
                cbSources.SelectedIndex = cbSources.Items.Count - 1;
            }
        }

        private void btAddImage_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                var src = new CompositorSource();
                var imageSettings = new ImageVideoSourceSettings(dlg.FileName);
                imageSettings.FrameRate = new VideoFrameRate(Convert.ToInt32(edFrameRate.Text));
                src.Source = new ImageVideoSourceBlock(imageSettings);
                src.Rectangle = new Rect(Convert.ToInt32(edRectLeft.Text), Convert.ToInt32(edRectTop.Text), Convert.ToInt32(edRectRight.Text), Convert.ToInt32(edRectBottom.Text));
                src.DisplayName = $"Image [{System.IO.Path.GetFileName(dlg.FileName)}]";
                src.ZOrder = _sources.Count; // Set default z-order

                _sources.Add(src);

                cbSources.Items.Add(src.DisplayName + $" (Z:{src.ZOrder})");
                cbSources.SelectedIndex = cbSources.Items.Count - 1;
            }
        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            if (cbSources.SelectedIndex != -1)
            {
                var sourceName = _sources[cbSources.SelectedIndex].DisplayName;
                _sources.RemoveAt(cbSources.SelectedIndex);
                cbSources.Items.RemoveAt(cbSources.SelectedIndex);
                
                LogMessage($"Removed source: {sourceName}", LogLevel.Info);
                
                // Reset selection if no items left
                if (cbSources.Items.Count == 0)
                {
                    UpdateChromaKeyUI();
                }
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize logging first
            LogMessage("Application starting up", LogLevel.Info);
            
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            LogMessage("Initializing VisioForge SDK", LogLevel.Info);
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
            LogMessage("VisioForge SDK initialized successfully", LogLevel.Info);

            CreateEngine();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };
            
            // Initialize chroma key UI
            cbSources.SelectionChanged += CbSources_SelectionChanged;
            UpdateChromaKeyUI();
            
            LogMessage($"Application ready (SDK v{MediaBlocksPipeline.SDK_Version})", LogLevel.Info);
        }
       
        private void UpdateRecordingTime()
        {
            var ts = _pipeline.Position_Get();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            Dispatcher.BeginInvoke((Action)(() =>
            {
                lbTimestamp.Content = ts.ToString(@"hh\:mm\:ss");
            }));
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LogMessage("Starting video compositor pipeline", LogLevel.Info);

                CreateEngine();

            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            VideoMixerBaseSettings videoMixerSettings;

            if (cbMixerType.SelectedIndex == 0)
            {
                videoMixerSettings = new VideoMixerSettings(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text), new VideoFrameRate(Convert.ToInt32(edFrameRate.Text)));
            }
            else if (cbMixerType.SelectedIndex == 1)
            {
                videoMixerSettings = new D3D11VideoCompositorSettings(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text), new VideoFrameRate(Convert.ToInt32(edFrameRate.Text)));
            }
            else
            {
                videoMixerSettings = new GLVideoMixerSettings(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text), new VideoFrameRate(Convert.ToInt32(edFrameRate.Text)));
            }

            // Sort sources by z-order (lower values first, higher values appear on top)
            var sortedSources = _sources.OrderBy(s => s.ZOrder).ToList();
            
            uint i = 0;
            foreach (var source in sortedSources)
            {
                if (source.IsChromaKeyEnabled)
                {
                    var chromaKeySettings = new ChromaKeySettingsX(
                        sourceVideoResolution: new Size(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text)),
                        chromaColor: source.ChromaColor,
                        sensitivity: source.Sensitivity,
                        noiseLevel: source.NoiseLevel
                    );

                    if (source.ChromaColor == ChromaKeyColor.Custom)
                    {
                        chromaKeySettings.CustomColor = source.CustomColor;
                    }

                    var chromaStream = new VideoMixerStreamChromaKey(source.Rectangle, i, chromaKeySettings);
                    videoMixerSettings.AddStream(chromaStream);
                }
                else
                {
                    videoMixerSettings.AddStream(new VideoMixerStream(source.Rectangle, i));
                }
                i++;
            }

            _videoMixer = new VideoMixerBlock(videoMixerSettings);

            i = 0;
            foreach (var source in sortedSources)
            {
                _pipeline.Connect(source.Source.Output, _videoMixer.Inputs[i]);
                i++;
            }

            if (rbOutputNone.IsChecked == true)
            {
                _pipeline.Connect(_videoMixer.Output, _videoRenderer.Input);
            }
            else
            {
                // create video tee
                _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
                _pipeline.Connect(_videoMixer.Output, _videoTee.Input);

                // connect video renderer for preview
                _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
                
                if (rbOutputFile.IsChecked == true)
                {
                    // create and connect MP4 output
                    _mp4Output = new MP4OutputBlock(new MP4SinkSettings(edOutputFilename.Text), new OpenH264EncoderSettings(), aacSettings: null);
                    _pipeline.Connect(_videoTee.Outputs[1], _mp4Output.CreateNewInput(MediaBlockPadMediaType.Video));
                }
                else if (rbOutputYouTube.IsChecked == true)
                {
                    // fake audio source 
                    _fakeAudioSource = new VirtualAudioSourceBlock(new VirtualAudioSourceSettings());

                    // create and connect YouTube output
                    _youTubeOutput = new YouTubeOutputBlock(new YouTubeSinkSettings(edOutputYouTubeKey.Text), new OpenH264EncoderSettings(), new MFAACEncoderSettings());
                    _pipeline.Connect(_videoTee.Outputs[1], _youTubeOutput.CreateNewInput(MediaBlockPadMediaType.Video));
                    _pipeline.Connect(_fakeAudioSource.Output, _youTubeOutput.CreateNewInput(MediaBlockPadMediaType.Audio));
                }
                else if (rbOutputFacebook.IsChecked == true)
                {
                    // fake audio source 
                    _fakeAudioSource = new VirtualAudioSourceBlock(new VirtualAudioSourceSettings());

                    // create and connect Facebook Live output
                    _facebookOutput = new FacebookLiveOutputBlock(new FacebookLiveSinkSettings(edOutputFacebookKey.Text), new OpenH264EncoderSettings(), new MFAACEncoderSettings());
                    _pipeline.Connect(_videoTee.Outputs[1], _facebookOutput.CreateNewInput(MediaBlockPadMediaType.Video));
                    _pipeline.Connect(_fakeAudioSource.Output, _facebookOutput.CreateNewInput(MediaBlockPadMediaType.Audio));
                }
                else if (rbOutputNDI.IsChecked == true)
                {
                    // fake audio source 
                    _fakeAudioSource = new VirtualAudioSourceBlock(new VirtualAudioSourceSettings());

                    // create and connect Facebook Live output
                    _ndiSink = new NDISinkBlock(new NDISinkSettings(edOutputNDIName.Text));
                    _pipeline.Connect(_videoTee.Outputs[1], _ndiSink.CreateNewInput(MediaBlockPadMediaType.Video));
                    _pipeline.Connect(_fakeAudioSource.Output, _ndiSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                }
            }

            await _pipeline.StartAsync();

            //_pipeline.SavePipeline("compositor");

            tmRecording.Start();
            
            LogMessage($"Pipeline started successfully with {_sources.Count} sources", LogLevel.Info);
            }
            catch (Exception ex)
            {
                LogMessage($"Failed to start pipeline: {ex.Message}", LogLevel.Error);
                MessageBox.Show($"Failed to start pipeline: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            LogMessage("Stopping video compositor pipeline", LogLevel.Info);
            
            tmRecording.Stop();

            if (rbOutputFile.IsChecked == true)
            {
                await _pipeline.StopAsync();
            }
            else
            {
                await _pipeline.StopAsync(true);
            }
            
            await DestroyEngineAsync();
            
            LogMessage("Pipeline stopped", LogLevel.Info);
        }

        private void btUpdateRect_Click(object sender, RoutedEventArgs e)
        {
            int index = cbSources.SelectedIndex;
            if (index != -1)
            {
                _sources[index].Rectangle = new Rect(
                    Convert.ToInt32(edRectLeft.Text),
                    Convert.ToInt32(edRectTop.Text),
                    Convert.ToInt32(edRectRight.Text),
                    Convert.ToInt32(edRectBottom.Text));

                if (_videoMixer != null)
                {
                    var stream = _videoMixer.Input_Get(index);
                    stream.Rectangle = _sources[index].Rectangle;
                    _videoMixer.Input_Update(index, stream);
                }
            }
        }

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == true)
            {
                edOutputFilename.Text = dlg.FileName;
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await DestroyEngineAsync();

            VisioForgeX.DestroySDK();
        }

        #region Chroma Key Event Handlers

        private void CbSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateChromaKeyUI();
        }

        private void cbEnableChromaKey_Checked(object sender, RoutedEventArgs e)
        {
            if (_isUpdatingUI) return; 
            
            int index = cbSources.SelectedIndex;
            if (index != -1 && index < _sources.Count)
            {
                _sources[index].IsChromaKeyEnabled = true;
                UpdateChromaKeyInMixer(index);
            }
        }

        private void cbEnableChromaKey_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_isUpdatingUI) return; 
            
            int index = cbSources.SelectedIndex;
            if (index != -1 && index < _sources.Count)
            {
                _sources[index].IsChromaKeyEnabled = false;
                UpdateChromaKeyInMixer(index);
            }
        }

        private void cbChromaColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isUpdatingUI) return;
            
            int index = cbSources.SelectedIndex;
            if (index != -1 && index < _sources.Count && cbChromaColor.SelectedIndex >= 0)
            {
                _sources[index].ChromaColor = (ChromaKeyColor)cbChromaColor.SelectedIndex;
                if (btCustomColor != null)
                {
                    btCustomColor.IsEnabled = cbChromaColor.SelectedIndex == 2; // Custom color
                }
                UpdateChromaKeyInMixer(index);
            }
        }

        private void btCustomColor_Click(object sender, RoutedEventArgs e)
        {
            var colorDialog = new System.Windows.Forms.ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int index = cbSources.SelectedIndex;
                if (index != -1 && index < _sources.Count)
                {
                    var color = colorDialog.Color;
                    _sources[index].CustomColor = new SKColor(color.R, color.G, color.B);
                    UpdateChromaKeyInMixer(index);
                }
            }
        }

        private void slSensitivity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_isUpdatingUI) return; 
            
            if (lblSensitivity != null)
            {
                lblSensitivity.Content = ((int)slSensitivity.Value).ToString();
            }
            
            int index = cbSources.SelectedIndex;
            if (index != -1 && index < _sources.Count)
            {
                _sources[index].Sensitivity = slSensitivity.Value;
                UpdateChromaKeyInMixer(index);
            }
        }

        private void slNoiseLevel_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_isUpdatingUI) return; 
            
            if (lblNoiseLevel != null)
            {
                lblNoiseLevel.Content = ((int)slNoiseLevel.Value).ToString();
            }
            
            int index = cbSources.SelectedIndex;
            if (index != -1 && index < _sources.Count)
            {
                _sources[index].NoiseLevel = slNoiseLevel.Value;
                UpdateChromaKeyInMixer(index);
            }
        }

        private void btUpdateChromaKey_Click(object sender, RoutedEventArgs e)
        {
            int index = cbSources.SelectedIndex;
            if (index != -1 && index < _sources.Count)
            {
                UpdateChromaKeyInMixer(index);
            }
        }

        private void UpdateChromaKeyInMixer(int index)
        {
            if (_videoMixer != null && index < _sources.Count)
            {
                var source = _sources[index];
                
                if (source.IsChromaKeyEnabled)
                {
                    var chromaKeySettings = new ChromaKeySettingsX(
                        sourceVideoResolution: new Size(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text)),
                        chromaColor: source.ChromaColor,
                        sensitivity: source.Sensitivity,
                        noiseLevel: source.NoiseLevel
                    );

                    if (source.ChromaColor == ChromaKeyColor.Custom)
                    {
                        chromaKeySettings.CustomColor = source.CustomColor;
                    }

                    _videoMixer.Input_UpdateChromaKeySettings(index, chromaKeySettings);
                }
                
                _videoMixer.Input_SetChromaKeyEnabled(index, source.IsChromaKeyEnabled);
            }
        }

        private void UpdateChromaKeyUI()
        {
            if (_isUpdatingUI) return; 
            
            _isUpdatingUI = true;
            
            try
            {
                int index = cbSources.SelectedIndex;
                if (index != -1 && index < _sources.Count)
                {
                    var source = _sources[index];
                    cbEnableChromaKey.IsChecked = source.IsChromaKeyEnabled;
                    cbChromaColor.SelectedIndex = (int)source.ChromaColor;
                    btCustomColor.IsEnabled = source.ChromaColor == ChromaKeyColor.Custom;
                    slSensitivity.Value = source.Sensitivity;
                    slNoiseLevel.Value = source.NoiseLevel;
                    lblSensitivity.Content = ((int)source.Sensitivity).ToString();
                    lblNoiseLevel.Content = ((int)source.NoiseLevel).ToString();
                    edZOrder.Text = source.ZOrder.ToString();
                }
                else
                {
                    cbEnableChromaKey.IsChecked = false;
                    cbChromaColor.SelectedIndex = 0;
                    btCustomColor.IsEnabled = false;
                    slSensitivity.Value = 20;
                    slNoiseLevel.Value = 2;
                    lblSensitivity.Content = "20";
                    lblNoiseLevel.Content = "2";
                    edZOrder.Text = "0";
                }
            }
            finally
            {
                _isUpdatingUI = false;
            }
        }

        #endregion

        #region Z-Order Event Handlers

        private void edZOrder_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_isUpdatingUI) return; 
            
            int index = cbSources.SelectedIndex;
            if (index != -1 && index < _sources.Count && int.TryParse(edZOrder.Text, out int zOrder))
            {
                _sources[index].ZOrder = zOrder;
                UpdateSingleSourceZOrder(index);
                UpdateSourceDisplayName(index);
            }
        }

        private void btMoveUp_Click(object sender, RoutedEventArgs e)
        {
            int index = cbSources.SelectedIndex;
            if (index != -1 && index < _sources.Count)
            {
                _sources[index].ZOrder++;
                edZOrder.Text = _sources[index].ZOrder.ToString();
                UpdateSingleSourceZOrder(index);
                UpdateSourceDisplayName(index);
            }
        }

        private void btMoveDown_Click(object sender, RoutedEventArgs e)
        {
            int index = cbSources.SelectedIndex;
            if (index != -1 && index < _sources.Count)
            {
                _sources[index].ZOrder--;
                edZOrder.Text = _sources[index].ZOrder.ToString();
                UpdateSingleSourceZOrder(index);
                UpdateSourceDisplayName(index);
            }
        }

        private void btUpdateZOrder_Click(object sender, RoutedEventArgs e)
        {
            UpdateZOrderInMixer();
        }

        private void btSortByZOrder_Click(object sender, RoutedEventArgs e)
        {
            // Sort the sources list by z-order and update the combo box
            var selectedSource = cbSources.SelectedIndex >= 0 ? _sources[cbSources.SelectedIndex] : null;
            
            _sources = _sources.OrderBy(s => s.ZOrder).ToList();
            
            // Update combo box items
            cbSources.Items.Clear();
            foreach (var source in _sources)
            {
                cbSources.Items.Add(source.DisplayName + $" (Z:{source.ZOrder})");
            }
            
            // Try to maintain selection based on the selected source object
            if (selectedSource != null)
            {
                var newIndex = _sources.IndexOf(selectedSource);
                if (newIndex >= 0)
                {
                    cbSources.SelectedIndex = newIndex;
                }
            }
            
            // No need to update mixer z-order since sources are just reordered in the UI list
            // The actual z-order values in the mixer remain the same
        }

        private void UpdateZOrderInMixer()
        {
            if (_videoMixer != null)
            {
                // Update z-order for all sources in real-time
                for (int i = 0; i < _sources.Count; i++)
                {
                    UpdateSingleSourceZOrder(i);
                }
            }
        }

        private void UpdateSingleSourceZOrder(int index)
        {
            if (_videoMixer != null && index >= 0 && index < _sources.Count)
            {
                var stream = _videoMixer.Input_Get(index);
                if (stream != null)
                {
                    var oldZOrder = stream.ZOrder;
                    // Update the z-order value
                    stream.ZOrder = (uint)_sources[index].ZOrder;
                    
                    // Apply the update to the mixer
                    _videoMixer.Input_Update(index, stream);
                    
                    LogMessage($"Updated z-order for source {index} ({_sources[index].DisplayName}): {oldZOrder} → {stream.ZOrder}", LogLevel.Debug);
                }
            }
        }

        private void UpdateSourceDisplayName(int index)
        {
            if (index >= 0 && index < _sources.Count && index < cbSources.Items.Count)
            {
                var selectedIndex = cbSources.SelectedIndex;
                cbSources.Items[index] = _sources[index].DisplayName + $" (Z:{_sources[index].ZOrder})";
                cbSources.SelectedIndex = selectedIndex; // Maintain selection
            }
        }

        #endregion

        #region Logging

        private void LogMessage(string message, LogLevel level = LogLevel.Info)
        {
            // Check if message should be displayed based on current log level
            var currentLogLevel = (LogLevel)cbLogLevel.SelectedIndex;
            if (level > currentLogLevel)
            {
                return;
            }

            var timestamp = cbShowTimestamp.IsChecked == true ? $"[{DateTime.Now:HH:mm:ss.fff}] " : "";
            var levelText = level switch
            {
                LogLevel.Error => "ERROR",
                LogLevel.Warning => "WARN",
                LogLevel.Info => "INFO",
                LogLevel.Debug => "DEBUG",
                _ => "INFO"
            };

            var color = level switch
            {
                LogLevel.Error => "Red",
                LogLevel.Warning => "Orange",
                LogLevel.Info => "LightGreen",
                LogLevel.Debug => "LightBlue",
                _ => "LightGreen"
            };

            var logEntry = $"{timestamp}[{levelText}] {message}{Environment.NewLine}";
            
            if (mmLog.Text.Length > 50000) // Limit log size
            {
                var lines = mmLog.Text.Split('\n');
                mmLog.Text = string.Join("\n", lines.Skip(lines.Length / 2));
            }

            mmLog.Text += logEntry;

            // Auto-scroll to bottom if enabled
            if (cbAutoScroll.IsChecked == true)
            {
                logScrollViewer.ScrollToEnd();
            }
        }

        private void btClearLog_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();
            LogMessage("Log cleared", LogLevel.Info);
        }

        #endregion
    }
}
