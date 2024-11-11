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
        private VideoEditCore _core;

        public MainWindow()
        {
            InitializeComponent();
        }

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

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            await _core.FastEdit_CutFileAsync(
                edSourceVideoFile.Text,
                TimeSpan.FromSeconds(Convert.ToInt32(edStartTime.Text)),
                TimeSpan.FromSeconds(Convert.ToInt32(edStopTime.Text)),
                edOutputVideoFile.Text);
        }

        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                ProgressBar1.Value = e.Progress;
            });
        }

        private void VideoEdit1_OnStop(object sender, StopEventArgs e)
        {
            MessageBox.Show("Completed");

            Dispatcher.Invoke(() =>
            {
                ProgressBar1.Value = 0;
            });
        }

        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                edLog.Text += e.Message + Environment.NewLine;
            });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title += $" (SDK v{VisioForge.Core.VideoEditX.VideoEditCoreX.SDK_Version})";

            _core = new VideoEditCore();

            _core.OnError += VideoEdit1_OnError;
            _core.OnStop += VideoEdit1_OnStop;
            _core.OnProgress += VideoEdit1_OnProgress;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _core.Dispose();
        }
    }
}