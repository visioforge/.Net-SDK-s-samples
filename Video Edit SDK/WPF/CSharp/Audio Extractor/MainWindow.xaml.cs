using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.Output;
using VisioForge.Core.VideoEdit;

namespace Audio_Extractor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The video editing engine instance.
        /// </summary>
        private VideoEditCore _core;

        /// <summary>
        /// Indicates whether the current operation is a fast edit extract (not a full engine start).
        /// </summary>
        private bool _extractMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btSelectOutput control.
        /// Opens a file dialog to select the output audio file path.
        /// </summary>
        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "MP3|*.mp3|M4A|*.m4a|All files|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                edOutputFile.Text = dlg.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the btSelectInput control.
        /// Opens a file dialog to select the source video file.
        /// </summary>
        private void btSelectInput_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Video files|*.mp4;*.avi;*.wmv;*.mpg;*.mkv;*.mov;*.ts|Audio files|*.mp3;*.wav;*.ogg;*.wma;*.m4a|All files|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                edSourceFile.Text = dlg.FileName;
            }
        }

        /// <summary>
        /// Handles the Loaded event of the Window.
        /// Initializes the engine and sets default values.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title += $" (SDK v{VisioForge.Core.VideoEditX.VideoEditCoreX.SDK_Version})";

            edOutputFile.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp3");

            _core = new VideoEditCore();
            _core.Video_Renderer.VideoRenderer = VideoRendererMode.None;
            _core.OnProgress += _core_OnProgress;
            _core.OnError += _core_OnError;
            _core.OnStop += _core_OnStop;
        }

        /// <summary>
        /// Handles the Closing event of the Window.
        /// Disposes the video editing engine to release resources.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_core != null)
            {
                _core.OnProgress -= _core_OnProgress;
                _core.OnError -= _core_OnError;
                _core.OnStop -= _core_OnStop;

                if (_extractMode)
                {
                    _core.FastEdit_StopAsync().GetAwaiter().GetResult();
                }
                else
                {
                    _core.Stop();
                }

                _core.Dispose();
                _core = null;
            }
        }

        /// <summary>
        /// Handles the OnStop event of the VideoEdit engine.
        /// Updates the UI and displays a completion message.
        /// </summary>
        private void _core_OnStop(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;

                pbProgress.Value = 0;

                MessageBox.Show(this, "Finished!");
            });
        }

        /// <summary>
        /// Handles the OnError event of the VideoEdit engine.
        /// Logs the error message to debug output and the text box.
        /// </summary>
        private void _core_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);

            Dispatcher.Invoke(() =>
            {
                edLog.Text += e.Message + Environment.NewLine;
            });
        }

        /// <summary>
        /// Handles the OnProgress event of the VideoEdit engine.
        /// Updates the progress bar.
        /// </summary>
        private void _core_OnProgress(object sender, ProgressEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (e.Progress > 0)
                {
                    pbProgress.Value = e.Progress;
                }
            });
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Starts the audio extraction or re-encoding process.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edSourceFile.Text))
            {
                MessageBox.Show(this, "Please select a source file.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!File.Exists(edSourceFile.Text))
            {
                MessageBox.Show(this, "Source file does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(edOutputFile.Text))
            {
                MessageBox.Show(this, "Please select an output file.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            btStart.IsEnabled = false;
            btStop.IsEnabled = true;

            if (rbExtract.IsChecked == true)
            {
                _extractMode = true;
                await _core.FastEdit_ExtractAudioStreamAsync(edSourceFile.Text, TimeSpan.Zero, TimeSpan.Zero, edOutputFile.Text);
            }
            else
            {
                _extractMode = false;
                _core.Input_Clear_List();
                await _core.Input_AddAudioFileAsync(edSourceFile.Text);

                _core.Output_Filename = edOutputFile.Text;

                if (rbReencodeMP3.IsChecked == true)
                {
                    _core.Output_Format = new MP3Output();
                }
                else if (rbReencodeM4A.IsChecked == true)
                {
                    _core.Output_Format = new M4AOutput();
                }

                await _core.StartAsync();
            }
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the process.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            btStart.IsEnabled = true;
            btStop.IsEnabled = false;

            if (_extractMode)
            {
                await _core.FastEdit_StopAsync();
            }
            else
            {
                await _core.StopAsync();
            }
        }
    }
}
