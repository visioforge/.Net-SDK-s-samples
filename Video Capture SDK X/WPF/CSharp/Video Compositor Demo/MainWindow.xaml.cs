using Microsoft.Win32;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.OpenGL;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.UI.WPF.Dialogs.Sources;
using VisioForge.Core.VideoCaptureX;
using Rect = VisioForge.Core.Types.Rect;
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
        private VideoCaptureCoreX _videoCapture;

        private List<CompositorSource> _sources = new List<CompositorSource>();

        private bool _isUpdatingUI = false;

        private VideoMixerSourceSettings _videoMixerSourceSettings = new VideoMixerSourceSettings();

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void VideoCapture_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                LogMessage($"ERROR: {e.Message}", LogLevel.Error);
            }));
        }

        private void CreateEngine()
        {
            _videoCapture = new VideoCaptureCoreX(VideoView1);
            _videoCapture.OnError += VideoCapture_OnError;

            _videoCapture.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _videoCapture.Debug_Mode = true;

            LogMessage("Media pipeline created", LogLevel.Info);
        }

        private async Task DestroyEngineAsync()
        {
            if (_videoCapture != null)
            {
                LogMessage("Destroying media pipeline", LogLevel.Info);
                _videoCapture.OnError -= VideoCapture_OnError;
                await _videoCapture.DisposeAsync();
                _videoCapture = null;
                
                // Clear mixer stream references
                foreach (var source in _sources)
                {
                    source.MixerStream = null;
                }
                
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

                src.Source = settings;
                src.Rectangle = GetDefaultRectangleForNewSource();
                src.DisplayName = $"Camera [{dlg.Device}]";
                src.ZOrder = _sources.Count; // Set default z-order

                _sources.Add(src);

                cbSources.Items.Add(src.DisplayName + $" (Z:{src.ZOrder})");
                cbSources.SelectedIndex = cbSources.Items.Count - 1;
                
                LogMessage($"Added camera source: {src.DisplayName} at {src.Rectangle}", LogLevel.Info);
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
                src.Source = settings;
                src.Rectangle = GetDefaultRectangleForNewSource();
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
                src.Source = await UniversalSourceSettings.CreateAsync(dlg.FileName, renderAudio: false);
                src.Rectangle = GetDefaultRectangleForNewSource();
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
                src.Source = imageSettings;
                src.Rectangle = GetDefaultRectangleForNewSource();
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
                    UpdateSourceUI();
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

            // Initialize source UI
            cbSources.SelectionChanged += CbSources_SelectionChanged;
            UpdateSourceUI();

            LogMessage($"Application ready (SDK v{MediaBlocksPipeline.SDK_Version})", LogLevel.Info);
        }

        private void UpdateRecordingTime()
        {
            var ts = _videoCapture.Duration();

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

                VideoMixerSourceSettings videoMixerSettings = new VideoMixerSourceSettings(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text), new VideoFrameRate(Convert.ToInt32(edFrameRate.Text)));

                if (cbMixerType.SelectedIndex == 0)
                {
                    videoMixerSettings.MixerType = VideoMixerType.CPU;
                }
                else if (cbMixerType.SelectedIndex == 1)
                {
                    videoMixerSettings.MixerType = VideoMixerType.D3D11;
                }
                else
                {
                    videoMixerSettings.MixerType = VideoMixerType.OpenGL;
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

                        videoMixerSettings.Add(source.Source, source.Rectangle, chromaKeySettings);
                    }
                    else
                    {
                        videoMixerSettings.Add(source.Source, source.Rectangle);
                    }
                    i++;
                }

                _videoCapture.Video_Source =  videoMixerSettings;
                           
                if (rbOutputNone.IsChecked == true)
                {
                    _videoCapture.Outputs_Clear();
                }
                else
                {
                    if (rbOutputFile.IsChecked == true)
                    {
                        _videoCapture.Outputs_Add(new MP4Output(edOutputFilename.Text)
                        {
                            Video = H264EncoderBlock.GetDefaultSettings()
                        });
                    }
                    else if (rbOutputYouTube.IsChecked == true)
                    {
                        // fake audio source 
                        var fakeAudioSource = new VirtualAudioSourceSettings();
                        _videoCapture.Audio_Source = fakeAudioSource;
                        tmRecording.Start();

                        // create and connect YouTube output
                        var youTubeOutput = new YouTubeOutput(edOutputYouTubeKey.Text)
                        {
                            Video = new OpenH264EncoderSettings(),
                            Audio = new MFAACEncoderSettings()
                        };
                        _videoCapture.Outputs_Add(youTubeOutput);
                    }
                    else if (rbOutputFacebook.IsChecked == true)
                    {
                        // fake audio source 
                        var fakeAudioSource = new VirtualAudioSourceSettings();
                        _videoCapture.Audio_Source = fakeAudioSource;

                        // create and connect Facebook Live output
                        var facebookOutput = new FacebookLiveOutput(edOutputFacebookKey.Text)
                        {
                            Video = new OpenH264EncoderSettings(),
                            Audio = new MFAACEncoderSettings()
                        };
                        _videoCapture.Outputs_Add(facebookOutput);
                    }
                    else if (rbOutputNDI.IsChecked == true)
                    {
                        // fake audio source 
                        var fakeAudioSource = new VirtualAudioSourceSettings();
                        _videoCapture.Audio_Source = fakeAudioSource;

                        // create and connect Facebook Live output
                        var ndiOutput = new NDISinkSettings(edOutputNDIName.Text);
                        _videoCapture.Outputs_Add(ndiOutput);
                    }
                }

                await _videoCapture.StartAsync();

                // Get the mixer streams and assign them to the sources for GUID-based API usage
                var mixer = _videoCapture.GetSourceMixerControl();
                if (mixer != null)
                {
                    var streams = mixer.Input_List();
                    for (int streamIndex = 0; streamIndex < Math.Min(_sources.Count, streams.Length); streamIndex++)
                    {
                        _sources[streamIndex].MixerStream = streams[streamIndex];
                        LogMessage($"Assigned mixer stream ID {streams[streamIndex].ID} to source '{_sources[streamIndex].DisplayName}'", LogLevel.Debug);
                    }
                }

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
                await _videoCapture.StopAsync();
            }
            else
            {
                await _videoCapture.StopAsync();
            }

            await DestroyEngineAsync();

            LogMessage("Pipeline stopped", LogLevel.Info);
        }

        private void btUpdateRect_Click(object sender, RoutedEventArgs e)
        {
            int index = cbSources.SelectedIndex;
            if (index != -1 && index < _sources.Count)
            {
                _sources[index].Rectangle = new Rect(
                    Convert.ToInt32(edRectLeft.Text),
                    Convert.ToInt32(edRectTop.Text),
                    Convert.ToInt32(edRectRight.Text),
                    Convert.ToInt32(edRectBottom.Text));

                var mixer = _videoCapture.GetSourceMixerControl();
                if (mixer != null && _sources[index].MixerStream != null && _sources[index].MixerStream.ID != Guid.Empty)
                {
                    var stream = mixer.Input_Get(_sources[index].MixerStream.ID);
                    if (stream != null)
                    {
                        stream.Rectangle = _sources[index].Rectangle;
                        mixer.Input_Update(stream);
                    }
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
            UpdateSourceUI();
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
            if (_videoCapture.State != PlaybackState.Play)
            {
                return;
            }

            var mixer = _videoCapture.GetSourceMixerControl();
            if (mixer != null && index >= 0 && index < _sources.Count && _sources[index].MixerStream != null && _sources[index].MixerStream.ID != Guid.Empty)
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

                    mixer.Input_UpdateChromaKeySettings(source.MixerStream.ID, chromaKeySettings);
                }

                mixer.Input_SetChromaKeyEnabled(source.MixerStream.ID, source.IsChromaKeyEnabled);
            }
        }

        private void UpdateSourceUI()
        {
            if (_isUpdatingUI) return;

            _isUpdatingUI = true;

            try
            {
                int index = cbSources.SelectedIndex;
                if (index != -1 && index < _sources.Count)
                {
                    var source = _sources[index];
                    
                    // Update chroma key settings
                    cbEnableChromaKey.IsChecked = source.IsChromaKeyEnabled;
                    cbChromaColor.SelectedIndex = (int)source.ChromaColor;
                    btCustomColor.IsEnabled = source.ChromaColor == ChromaKeyColor.Custom;
                    slSensitivity.Value = source.Sensitivity;
                    slNoiseLevel.Value = source.NoiseLevel;
                    lblSensitivity.Content = ((int)source.Sensitivity).ToString();
                    lblNoiseLevel.Content = ((int)source.NoiseLevel).ToString();
                    
                    // Update z-order
                    edZOrder.Text = source.ZOrder.ToString();
                    
                    // Update rectangle values
                    edRectLeft.Text = source.Rectangle.Left.ToString();
                    edRectTop.Text = source.Rectangle.Top.ToString();
                    edRectRight.Text = source.Rectangle.Right.ToString();
                    edRectBottom.Text = source.Rectangle.Bottom.ToString();
                    
                    LogMessage($"Updated UI for source: {source.DisplayName} - Rect({source.Rectangle.Left},{source.Rectangle.Top},{source.Rectangle.Right},{source.Rectangle.Bottom})", LogLevel.Debug);
                }
                else
                {
                    // Reset to default values when no source is selected
                    cbEnableChromaKey.IsChecked = false;
                    cbChromaColor.SelectedIndex = 0;
                    btCustomColor.IsEnabled = false;
                    slSensitivity.Value = 20;
                    slNoiseLevel.Value = 2;
                    lblSensitivity.Content = "20";
                    lblNoiseLevel.Content = "2";
                    edZOrder.Text = "0";
                    
                    // Set default rectangle values (typical 720p)
                    edRectLeft.Text = "0";
                    edRectTop.Text = "0";
                    edRectRight.Text = "1280";
                    edRectBottom.Text = "720";
                    
                    LogMessage("UI reset to defaults - no source selected", LogLevel.Debug);
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
            var mixer = _videoCapture.GetSourceMixerControl();
            if (mixer != null)
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
            var mixer = _videoCapture.GetSourceMixerControl();
            if (mixer != null && index >= 0 && index < _sources.Count && _sources[index].MixerStream != null && _sources[index].MixerStream.ID != Guid.Empty)
            {
                var stream = mixer.Input_Get(_sources[index].MixerStream.ID);
                if (stream != null)
                {
                    var oldZOrder = stream.ZOrder;
                    // Update the z-order value
                    stream.ZOrder = (uint)_sources[index].ZOrder;

                    // Apply the update to the mixer
                    mixer.Input_Update(stream);

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

        #region Helper Methods

        /// <summary>
        /// Gets a default rectangle for a new source based on mixer dimensions and existing source count.
        /// </summary>
        /// <returns>A reasonable default rectangle for the new source.</returns>
        private Rect GetDefaultRectangleForNewSource()
        {
            int mixerWidth = Convert.ToInt32(edWidth.Text);
            int mixerHeight = Convert.ToInt32(edHeight.Text);
            int sourceCount = _sources.Count;

            if (sourceCount == 0)
            {
                // First source takes full screen
                return new Rect(0, 0, mixerWidth, mixerHeight);
            }
            else if (sourceCount == 1)
            {
                // Second source gets picture-in-picture in top-right corner
                int pipWidth = mixerWidth / 4;
                int pipHeight = mixerHeight / 4;
                return new Rect(mixerWidth - pipWidth, 0, mixerWidth, pipHeight);
            }
            else
            {
                // Additional sources get arranged in a grid pattern
                int cols = (int)Math.Ceiling(Math.Sqrt(sourceCount + 1));
                int rows = (int)Math.Ceiling((double)(sourceCount + 1) / cols);
                
                int sourceWidth = mixerWidth / cols;
                int sourceHeight = mixerHeight / rows;
                
                int col = sourceCount % cols;
                int row = sourceCount / cols;
                
                int x = col * sourceWidth;
                int y = row * sourceHeight;
                
                return new Rect(x, y, x + sourceWidth, y + sourceHeight);
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
