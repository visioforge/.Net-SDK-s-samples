namespace Video_Join_Demo_X
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Windows;

    using VisioForge.Core;
    using VisioForge.Core.Helpers;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.UI;
    using VisioForge.Core.VideoEditX;

    /// <summary>
    /// The main window for the Video Join Demo X WPF.
    /// Provides a simplified interface for joining multiple video/audio/image files into a single output using the X-engine.
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoEditCoreX VideoEdit1;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates the video editing engine and subscribes to events.
        /// </summary>
        private void CreateEngine()
        {
            VideoEdit1 = new VideoEditCoreX(VideoView1 as IVideoView);

            VideoEdit1.OnError += VideoEdit1_OnError;
            VideoEdit1.OnStop += VideoEdit1_OnStop;
            VideoEdit1.OnProgress += VideoEdit1_OnProgress;
        }

        /// <summary>
        /// Destroys the video editing engine and unsubscribes from events to release resources.
        /// </summary>
        private void DestroyEngine()
        {
            if (VideoEdit1 != null)
            {
                VideoEdit1.OnError -= VideoEdit1_OnError;
                VideoEdit1.OnStop -= VideoEdit1_OnStop;
                VideoEdit1.OnProgress -= VideoEdit1_OnProgress;

                VideoEdit1.Dispose();
                VideoEdit1 = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the btAddInputFile control.
        /// Opens a file dialog to select and add multimedia files to the join list.
        /// </summary>
        private void btAddInputFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "All files|*.*|Video files|*.avi;*.mp4;*.wmv;*.mkv;*.webm;*.ts;*.mpg|Audio files|*.mp3;*.wav;*.ogg;*.wma;*.aac;*.flac;*.m4a|Image files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tiff"
            };

            if (dlg.ShowDialog() == true)
            {
                string filename = dlg.FileName;

                if (cbResize.IsChecked == true && !string.IsNullOrEmpty(edWidth.Text) && !string.IsNullOrEmpty(edHeight.Text))
                {
                    VideoEdit1.Output_VideoSize = new VisioForge.Core.Types.Size(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text));
                }

                var frameRate = Convert.ToInt32(((System.Windows.Controls.ComboBoxItem)cbFrameRate.SelectedItem).Content.ToString(), CultureInfo.InvariantCulture);
                if (frameRate != 0)
                {
                    VideoEdit1.Output_VideoFrameRate = new VideoFrameRate(frameRate);
                }

                lbFiles.Items.Add(filename);

                if (FilenameHelper.IsImageFile(filename))
                {
                    VideoEdit1.Input_AddImageFile(filename, TimeSpan.FromMilliseconds(2000));
                }
                else if (FilenameHelper.IsAudioFile(filename))
                {
                    VideoEdit1.Input_AddAudioFile(filename);
                }
                else
                {
                    VideoEdit1.Input_AddAudioVideoFile(filename);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btSelectOutput control.
        /// </summary>
        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "AVI (*.avi)|*.avi|Windows Media Video (*.wmv)|*.wmv|Matroska (*.mkv)|*.mkv|All files (*.*)|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                edOutput.Text = dlg.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the btClearList control.
        /// </summary>
        private void btClearList_Click(object sender, RoutedEventArgs e)
        {
            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures the output format and starts the joining process.
        /// </summary>
        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoEdit1.Debug_Telemetry = cbTelemetry.IsChecked == true;

            mmLog.Clear();

            if (rbPreview.IsChecked == true)
            {
                VideoEdit1.Output_Format = null;
            }
            else
            {
                switch (cbOutputVideoFormat.SelectedIndex)
                {
                    case 0:
                        {
                            var mp4Output = new MP4Output(edOutput.Text);
                            VideoEdit1.Output_Format = mp4Output;
                            break;
                        }
                    case 1:
                        {
                            var webmOutput = new WebMOutput(edOutput.Text);
                            VideoEdit1.Output_Format = webmOutput;
                            break;
                        }
                    case 2:
                        {
                            var aviOutput = new AVIOutput(edOutput.Text);
                            VideoEdit1.Output_Format = aviOutput;
                            break;
                        }
                    case 3:
                        {
                            var mkvOutput = new MKVOutput(edOutput.Text);
                            VideoEdit1.Output_Format = mkvOutput;
                            break;
                        }
                    case 4:
                        {
                            var wmvOutput = new WMVOutput(edOutput.Text);
                            VideoEdit1.Output_Format = wmvOutput;
                            break;
                        }
                    case 5:
                        {
                            var dvOutput = new DVOutput(edOutput.Text);
                            VideoEdit1.Output_Format = dvOutput;
                            break;
                        }
                    case 6:
                        {
                            var acmOutput = new WAVOutput(edOutput.Text);
                            VideoEdit1.Output_Format = acmOutput;
                            break;
                        }
                    case 7:
                        {
                            var mp3Output = new MP3Output(edOutput.Text);
                            VideoEdit1.Output_Format = mp3Output;
                            break;
                        }
                    case 8:
                        {
                            var m4aOutput = new M4AOutput(edOutput.Text);
                            VideoEdit1.Output_Format = m4aOutput;
                            break;
                        }
                    case 9:
                        {
                            var wmaOutput = new WMAOutput(edOutput.Text);
                            VideoEdit1.Output_Format = wmaOutput;
                            break;
                        }
                    case 10:
                        {
                            var oggVorbisOutput = new OGGVorbisOutput(edOutput.Text);
                            VideoEdit1.Output_Format = oggVorbisOutput;
                            break;
                        }
                    case 11:
                        {
                            var flacOutput = new FLACOutput(edOutput.Text);
                            VideoEdit1.Output_Format = flacOutput;
                            break;
                        }
                    case 12:
                        {
                            var speexOutput = new SpeexOutput(edOutput.Text);
                            VideoEdit1.Output_Format = speexOutput;
                            break;
                        }
                }
            }

            VideoEdit1.Start();
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// </summary>
        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Stop();

            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
            ProgressBar1.Value = 0;
        }

        /// <summary>
        /// Video edit 1 on error.
        /// </summary>
        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + "(" + e.CallSite + ")" + Environment.NewLine;
            });
        }

        /// <summary>
        /// Video edit 1 on progress.
        /// </summary>
        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            Dispatcher.Invoke(() => { ProgressBar1.Value = e.Progress; });
        }

        /// <summary>
        /// Video edit 1 on stop.
        /// </summary>
        private void VideoEdit1_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                ProgressBar1.Value = 0;
                lbFiles.Items.Clear();

                if (e.Successful)
                {
                    MessageBox.Show(this, "Completed successfully", string.Empty, MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show(this, "Stopped with error", string.Empty, MessageBoxButton.OK);
                }
            });
        }

        /// <summary>
        /// Handles the Loaded event of the Window.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            CreateEngine();

            Title += $" (SDK v{VideoEditCoreX.SDK_Version})";

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");

            VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            cbFrameRate.SelectedIndex = 0;
            cbOutputVideoFormat.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the Closing event of the Window.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VideoEdit1?.Stop();

            DestroyEngine();

            VisioForgeX.DestroySDK();
        }
    }
}
