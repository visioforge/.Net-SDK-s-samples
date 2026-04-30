using System;
using System.ComponentModel;
using System.IO;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.VideoEditX;

namespace output_gif
{
    /// <summary>
    /// Interaction logic for the output-gif snippet MainWindow.
    /// Demonstrates how to render a timeline to an animated GIF using VideoEditCoreX.
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
        /// Handles the Loaded event of the Window. Initializes the SDK engine on startup.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
        }

        /// <summary>
        /// Handles the Click event of btStart. Configures GIFOutput with user-supplied
        /// Speed/Repeat values and starts rendering the source video to an animated GIF.
        /// </summary>
        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(edSourceVideoFile.Text))
            {
                MessageBox.Show("Please select source video file.");
                return;
            }

            if (string.IsNullOrWhiteSpace(edOutputFile.Text))
            {
                MessageBox.Show("Please specify output GIF file path.");
                return;
            }

            if (!int.TryParse(edSpeed.Text, out var speed) || speed < 1 || speed > 30)
            {
                MessageBox.Show("Speed must be an integer in range 1..30.");
                return;
            }

            if (!uint.TryParse(edRepeat.Text, out var repeat))
            {
                // Allow -1 (loop forever) by re-parsing as int and casting.
                if (!int.TryParse(edRepeat.Text, out var repeatSigned))
                {
                    MessageBox.Show("Repeat must be an integer (-1 = loop forever, 0..n = finite repeats).");
                    return;
                }

                repeat = unchecked((uint)repeatSigned);
            }

            _core = new VideoEditCoreX();
            _core.OnStop += _core_OnStop;

            // GIF has no audio — add only the video track.
            _core.Input_AddVideoFile(edSourceVideoFile.Text);

            _outputFile = edOutputFile.Text;
            _core.Output_Format = new GIFOutput(_outputFile, new GIFEncoderSettings { Speed = speed, Repeat = repeat });

            _core.Start();
        }

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
                    MessageBox.Show("Done. GIF saved to " + _outputFile);
                }
                else
                {
                    MessageBox.Show("Processing failed.");
                }
            });
        }

        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            _core?.Stop();
        }

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

        private void btSelectVideo_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Video files|*.mp4;*.avi;*.mov;*.mkv;*.webm|All files|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                edSourceVideoFile.Text = dlg.FileName;
            }
        }

        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "Animated GIF|*.gif",
                DefaultExt = ".gif",
                FileName = "output.gif"
            };

            if (dlg.ShowDialog() == true)
            {
                edOutputFile.Text = dlg.FileName;
            }
        }
    }
}
