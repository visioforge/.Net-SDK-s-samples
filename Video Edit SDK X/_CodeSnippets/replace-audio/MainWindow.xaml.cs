using System;
using System.Windows;
using System.IO;
using System.ComponentModel;

using VisioForge.Core;
using VisioForge.Core.Types.Events;
using VisioForge.Core.VideoEditX;
using VisioForge.Core.Types.X.Output;

namespace replace_audio
{
    /// <summary>
    /// Interaction logic for the replace-audio snippet MainWindow.
    /// Demonstrates how to replace or remove audio tracks from a video file using the X-engine.
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoEditCoreX _core;

        private string _outputFile;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Loaded event of the Window.
        /// Initializes the SDK engine on startup.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
        }
            
        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures and starts the process of replacing or removing audio from the video source.
        /// </summary>
        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(edSourceVideoFile.Text))
            {
                MessageBox.Show("Please select video file.");
                return;
            }

            if (cbRemoveAudio.IsChecked == false && !File.Exists(edSourceAudioFile.Text))
            {
                MessageBox.Show("Please select audio file.");
                return;
            }

            // Create VideoEditCoreX object
            _core = new VideoEditCoreX();
            _core.OnStop += _core_OnStop;

            // Add the video file (video track only, no audio)
            _core.Input_AddVideoFile(edSourceVideoFile.Text);

            // Add the replacement audio file if not removing audio
            if (cbRemoveAudio.IsChecked == false)
            {
                _core.Input_AddAudioFile(edSourceAudioFile.Text);
            }

            // MP4 output (use default encoder settings for better compatibility)
            var outputDir = Path.GetDirectoryName(edSourceVideoFile.Text);
            _outputFile = Path.Combine(outputDir ?? Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "new_output.mp4");
            _core.Output_Format = new MP4Output(_outputFile);

            // Start processing
            _core.Start();
        }

        /// <summary>
        /// Event handler for the engine's OnStop event.
        /// Cleans up resources and notifies the user of completion.
        /// </summary>
        private void _core_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (_core != null)
                {
                    _core.OnStop -= _core_OnStop;
                    _core.Dispose();
                    _core = null;
                }

                if (e.Successful)
                {
                    MessageBox.Show("Done. Video saved to " + _outputFile);
                }
                else
                {
                    MessageBox.Show("Processing failed.");
                }
            });
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the current operation.
        /// </summary>
        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (_core == null)
            {
                return;
            }

            _core.Stop();
        }

        /// <summary>
        /// Handles the Closing event of the Window.
        /// Ensures the SDK resources are released upon closing.
        /// </summary>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (_core != null)
            {
                _core.OnStop -= _core_OnStop;
                _core.Stop();
                _core.Dispose();
                _core = null;
            }

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Handles the bt select video click event.
        /// </summary>
        private void btSelectVideo_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "MP4 files|*.mp4";
            var result = dlg.ShowDialog();
            if (result == true)
            {
                edSourceVideoFile.Text = dlg.FileName;
            }
        }

        /// <summary>
        /// Handles the bt select audio click event.
        /// </summary>
        private void btSelectAudio_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "MP3 files|*.mp3|AAC files|*.m4a";
            var result = dlg.ShowDialog();
            if (result == true)
            {
                edSourceAudioFile.Text = dlg.FileName;
            }
        }
    }
}