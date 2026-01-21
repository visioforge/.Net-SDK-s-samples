using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.VideoEdit;
using static System.Net.Mime.MediaTypeNames;

namespace Cut_Video_File
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
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btSelectSourceFile control.
        /// Opens a file dialog to select the source video file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btSelectSourceFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".mp4",
                Filter = "Video files|*.mp4;*.avi;*.mpg;*.mkv;*.ts;*.wmv;*.vob|All files|*.*"
            };

            var result = dlg.ShowDialog();

            if (result == true)
            {
                edSourceVideoFile.Text = dlg.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the btSelectOutputFile control.
        /// Opens a file dialog to select the output video file path.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btSelectOutputFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog
            {
                DefaultExt = ".mp4",
                Filter = "Video files|*.mp4;*.avi;*.mpg;*.mkv;*.ts;*.wmv;*.vob|All files|*.*"
            };

            var result = dlg.ShowDialog();

            if (result == true)
            {
                edOutputVideoFile.Text = dlg.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Initiates the file cutting process asynchronously.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            await _core.FastEdit_CutFileAsync(
                edSourceVideoFile.Text,
                TimeSpan.FromSeconds(Convert.ToInt32(edStartTime.Text)),
                TimeSpan.FromSeconds(Convert.ToInt32(edStopTime.Text)),
                edOutputVideoFile.Text);
        }

        /// <summary>
        /// Handles the OnProgress event of the VideoEdit engine.
        /// Updates the progress bar.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ProgressEventArgs"/> instance containing the event data.</param>
        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                ProgressBar1.Value = e.Progress;
            });
        }

        /// <summary>
        /// Handles the OnStop event of the VideoEdit engine.
        /// Displays a completion message and resets the progress bar.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="StopEventArgs"/> instance containing the event data.</param>
        private void VideoEdit1_OnStop(object sender, StopEventArgs e)
        {
            MessageBox.Show("Completed");

            Dispatcher.Invoke(() =>
            {
                ProgressBar1.Value = 0;
            });
        }

        /// <summary>
        /// Handles the OnError event of the VideoEdit engine.
        /// Logs the error message.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                edLog.Text += e.Message + Environment.NewLine;
            });
        }

        /// <summary>
        /// Handles the Loaded event of the Window control.
        /// Initializes the VideoEdit engine and subscribes to events.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title += $" (SDK v{VisioForge.Core.VideoEditX.VideoEditCoreX.SDK_Version})";

            _core = new VideoEditCore();

            _core.OnError += VideoEdit1_OnError;
            _core.OnStop += VideoEdit1_OnStop;
            _core.OnProgress += VideoEdit1_OnProgress;
        }

        /// <summary>
        /// Handles the Closing event of the Window control.
        /// Disposes of the VideoEdit engine.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _core.Dispose();
        }
    }
}