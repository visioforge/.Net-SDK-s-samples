using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Gst;
using SkiaSharp;
using VisioForge.Core;
using VisioForge.Core.GStreamer.Sources;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI;
using System.Diagnostics;

namespace ImageVideoSourceCairo_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline? _pipeline;
        private ImageVideoSourceCairoBlock? _imageSource;
        private VideoRendererBlock? _videoRenderer;
        
        private readonly string[] _imageFiles = { "image1.png", "image2.jpg", "image3.gif", "image4.bmp" };
        private int _currentImageIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            
            // Set default selection
            cbDisplayMode.SelectedIndex = 1; // Letterbox
            
            // Initialize VisioForge
        }

        /// <summary>
        /// Handles the btn start click event.
        /// </summary>
        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnStart.IsEnabled = false;
                btnStop.IsEnabled = true;
                lblStatus.Content = "Starting...";

                // Check if first image exists
                string firstImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _imageFiles[0]);
                if (!File.Exists(firstImage))
                {
                    MessageBox.Show($"Please provide {_imageFiles[0]} in the application directory", "Missing Image", MessageBoxButton.OK, MessageBoxImage.Warning);
                    btnStart.IsEnabled = true;
                    btnStop.IsEnabled = false;
                    lblStatus.Content = "Missing image file";
                    return;
                }

                // Create pipeline
                _pipeline = new MediaBlocksPipeline();

                // Create image source settings

                // Create image source with Cairo
                var settings = new ImageVideoSourceSettings(firstImage);
                
                _imageSource = new ImageVideoSourceCairoBlock(_pipeline, settings, new VisioForge.Core.Types.Size(1920, 1080));
                
                // Set initial display mode
                UpdateDisplayMode();

                // Create video renderer
                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView);

                // Connect blocks
                _pipeline.Connect(_imageSource.Output, _videoRenderer.Input);

                // Start pipeline
                await _pipeline.StartAsync();
                
                lblStatus.Content = $"Playing: {_imageFiles[_currentImageIndex]}";
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting pipeline: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                btnStart.IsEnabled = true;
                btnStop.IsEnabled = false;
                lblStatus.Content = "Error";
            }
        }

        /// <summary>
        /// Handles the btn stop click event.
        /// </summary>
        private async void btnStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnStop.IsEnabled = false;
                lblStatus.Content = "Stopping...";

                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    _pipeline.Dispose();
                    _pipeline = null;
                }

                _imageSource?.Dispose();
                _imageSource = null;
                
                _videoRenderer?.Dispose();
                _videoRenderer = null;

                btnStart.IsEnabled = true;
                lblStatus.Content = "Stopped";
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping pipeline: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Handles the btn image 1 click event.
        /// </summary>
        private void btnImage1_Click(object sender, RoutedEventArgs e)
        {
            SwitchToImage(0);
        }

        /// <summary>
        /// Handles the btn image 2 click event.
        /// </summary>
        private void btnImage2_Click(object sender, RoutedEventArgs e)
        {
            SwitchToImage(1);
        }

        /// <summary>
        /// Handles the btn image 3 click event.
        /// </summary>
        private void btnImage3_Click(object sender, RoutedEventArgs e)
        {
            SwitchToImage(2);
        }

        /// <summary>
        /// Handles the btn image 4 click event.
        /// </summary>
        private void btnImage4_Click(object sender, RoutedEventArgs e)
        {
            SwitchToImage(3);
        }

        /// <summary>
        /// Switch to image.
        /// </summary>
        private void SwitchToImage(int index)
        {
            if (_imageSource == null || _pipeline == null || _pipeline.State != PlaybackState.Play)
            {
                MessageBox.Show("Please start the pipeline first", "Not Started", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _imageFiles[index]);
            if (!File.Exists(imagePath))
            {
                MessageBox.Show($"Image file not found: {_imageFiles[index]}", "Missing Image", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Update the image dynamically
                _imageSource.UpdateFilename(imagePath);
                _currentImageIndex = index;
                lblStatus.Content = $"Playing: {_imageFiles[index]}";
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error switching image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Cb display mode selection changed.
        /// </summary>
        private void cbDisplayMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDisplayMode();
        }

        /// <summary>
        /// Update display mode.
        /// </summary>
        private void UpdateDisplayMode()
        {
            if (_imageSource == null || cbDisplayMode.SelectedItem == null)
                return;

            var selectedItem = (ComboBoxItem)cbDisplayMode.SelectedItem;
            var mode = selectedItem.Content.ToString() switch
            {
                "Stretch" => ImageDisplayMode.Stretch,
                "Letterbox" => ImageDisplayMode.Letterbox,
                "Original Size" => ImageDisplayMode.OriginalSize,
                _ => ImageDisplayMode.Letterbox
            };

            _imageSource.SetDisplayMode(mode);
        }

        /// <summary>
        /// Update button states.
        /// </summary>
        private void UpdateButtonStates()
        {
            bool isRunning = _pipeline != null && _pipeline.State == PlaybackState.Play;
            
            // Highlight current image button
            btnImage1.FontWeight = _currentImageIndex == 0 && isRunning ? FontWeights.Bold : FontWeights.Normal;
            btnImage2.FontWeight = _currentImageIndex == 1 && isRunning ? FontWeights.Bold : FontWeights.Normal;
            btnImage3.FontWeight = _currentImageIndex == 2 && isRunning ? FontWeights.Bold : FontWeights.Normal;
            btnImage4.FontWeight = _currentImageIndex == 3 && isRunning ? FontWeights.Bold : FontWeights.Normal;
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private async void Window_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                if (_pipeline != null && _pipeline.State == PlaybackState.Play)
                {
                    e.Cancel = true;
                    await _pipeline.StopAsync();
                    _pipeline.Dispose();
                    System.Windows.Application.Current.Shutdown();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}