using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoCapture;

namespace MediaBlocks_ImageSequence_Demo_WPF
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
        private ImageSequenceSourceBlock _imageSequenceSource;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Initialize the SDK
                Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                this.IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                this.IsEnabled = true;
                Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

                _timer = new System.Timers.Timer(500);
                _timer.Elapsed += _timer_Elapsed;

                // Initialize frame rate combo box
                InitializeFrameRates();

                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Initialize frame rates.
        /// </summary>
        private void InitializeFrameRates()
        {
            cbFrameRate.Items.Clear();
            cbFrameRate.Items.Add("1 FPS");
            cbFrameRate.Items.Add("5 FPS");
            cbFrameRate.Items.Add("10 FPS");
            cbFrameRate.Items.Add("15 FPS");
            cbFrameRate.Items.Add("24 FPS");
            cbFrameRate.Items.Add("25 FPS");
            cbFrameRate.Items.Add("30 FPS");
            cbFrameRate.Items.Add("60 FPS");
            cbFrameRate.SelectedIndex = 5; // 25 FPS
        }

        /// <summary>
        /// Get selected frame rate.
        /// </summary>
        private VideoFrameRate GetSelectedFrameRate()
        {
            return cbFrameRate.SelectedIndex switch
            {
                0 => VideoFrameRate.FPS_1,
                1 => VideoFrameRate.FPS_5,
                2 => VideoFrameRate.FPS_10,
                3 => VideoFrameRate.FPS_15,
                4 => VideoFrameRate.FPS_24,
                5 => VideoFrameRate.FPS_25,
                6 => VideoFrameRate.FPS_30,
                7 => VideoFrameRate.FPS_60,
                _ => VideoFrameRate.FPS_25
            };
        }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                edLog.Text += e.Message + Environment.NewLine;
                tbStatus.Text = "Error: " + e.Message;
            });
        }

        /// <summary>
        /// Pipeline on stop.
        /// </summary>
        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                _timer.Stop();
                tbTimeline.Value = 0;
                tbStatus.Text = "Stopped";
            });
        }

        /// <summary>
        /// Create engine async.
        /// </summary>
        private async Task CreateEngineAsync()
        {
            if (string.IsNullOrEmpty(edFolderPath.Text))
            {
                System.Windows.MessageBox.Show("Please select a folder containing image sequence.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Directory.Exists(edFolderPath.Text))
            {
                System.Windows.MessageBox.Show("Selected folder does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;
                _pipeline.OnStop += Pipeline_OnStop;
                _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

                // Create image sequence source settings
                var settings = new ImageSequenceSourceSettings(edFolderPath.Text)
                {
                    FrameRate = GetSelectedFrameRate(),
                    Loop = chkLoop.IsChecked == true
                };

                // Check if image sequence source is available
                if (!ImageSequenceSourceBlock.IsAvailable(settings))
                {
                    System.Windows.MessageBox.Show("ImageSequenceSource is not available. Please ensure GStreamer multifile plugin is installed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _imageSequenceSource = new ImageSequenceSourceBlock(settings);

                // Create video renderer
                _videoRenderer = new VideoRendererBlock(_pipeline, VideoPanel);

                // Connect blocks
                _pipeline.Connect(_imageSequenceSource.Output, _videoRenderer.Input);

                tbStatus.Text = "Engine created successfully";
                edLog.Text += "Engine created successfully" + Environment.NewLine;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error creating engine: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                tbStatus.Text = "Error creating engine";
                edLog.Text += $"Error creating engine: {ex.Message}" + Environment.NewLine;
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await CreateEngineAsync();

                if (_pipeline != null)
                {
                    await _pipeline.StartAsync();
                    _timer.Start();
                    tbStatus.Text = "Playing";
                    edLog.Text += "Playback started" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error starting playback: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                tbStatus.Text = "Error starting playback";
                edLog.Text += $"Error starting playback: {ex.Message}" + Environment.NewLine;
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    _pipeline.Dispose();
                    _pipeline = null;
                    _imageSequenceSource = null;
                    _videoRenderer = null;
                    tbStatus.Text = "Stopped";
                    edLog.Text += "Playback stopped" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error stopping playback: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                tbStatus.Text = "Error stopping playback";
                edLog.Text += $"Error stopping playback: {ex.Message}" + Environment.NewLine;
            }
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_pipeline != null)
                {
                    await _pipeline.PauseAsync();
                    tbStatus.Text = "Paused";
                    edLog.Text += "Playback paused" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error pausing playback: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                tbStatus.Text = "Error pausing playback";
                edLog.Text += $"Error pausing playback: {ex.Message}" + Environment.NewLine;
            }
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_pipeline != null)
                {
                    await _pipeline.ResumeAsync();
                    tbStatus.Text = "Playing";
                    edLog.Text += "Playback resumed" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error resuming playback: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                tbStatus.Text = "Error resuming playback";
                edLog.Text += $"Error resuming playback: {ex.Message}" + Environment.NewLine;
            }
        }

        /// <summary>
        /// Handles the bt browse folder click event.
        /// </summary>
        private void btBrowseFolder_Click(object sender, RoutedEventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            dialog.Description = "Select folder containing image sequence";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                edFolderPath.Text = dialog.SelectedPath;

                // Count images in folder
                var supportedExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff", ".tif" };
                var imageCount = Directory.GetFiles(dialog.SelectedPath)
                    .Count(f => supportedExtensions.Contains(Path.GetExtension(f).ToLowerInvariant()));

                tbStatus.Text = $"Selected folder contains {imageCount} image files";
                edLog.Text += $"Selected folder: {dialog.SelectedPath} ({imageCount} images)" + Environment.NewLine;
            }
        }

        /// <summary>
        /// Tb timeline value changed.
        /// </summary>
        private void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Timeline seeking functionality could be implemented here
            // For image sequences, this might involve seeking to specific frame
        }

        /// <summary>
        /// Timer elapsed.
        /// </summary>
        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_timerFlag)
                return;

            _timerFlag = true;

            try
            {
                if (_pipeline != null)
                {
                    var position = _pipeline.Position_Get();
                    var duration = _pipeline.Duration_Get();

                    Dispatcher.Invoke(() =>
                    {
                        if (duration > 0)
                        {
                            tbTimeline.Maximum = duration;
                            tbTimeline.Value = position;
                        }

                        lbTime.Content = $"{TimeSpan.FromMilliseconds(position):hh\\:mm\\:ss} / {TimeSpan.FromMilliseconds(duration):hh\\:mm\\:ss}";
                    });
                }
            }
            catch
            {
                // Ignore timer errors
            }

            _timerFlag = false;
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer?.Stop();
            _timer?.Dispose();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }
    }
}
