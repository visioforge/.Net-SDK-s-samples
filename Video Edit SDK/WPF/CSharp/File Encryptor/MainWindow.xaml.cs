using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using VisioForge.Core.MediaInfo;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoEdit;
using VisioForge.Core.VideoEdit;

namespace File_Encryptor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The video editing engine instance.
        /// </summary>
        private VideoEditCore _videoEdit = new VideoEditCore();

        /// <summary>
        /// Indicates whether fast encryption mode is used (stream copy instead of re-encoding).
        /// </summary>
        private bool _fastEncrypt = false;

        /// <summary>
        /// Timer for progress updates.
        /// </summary>
        private DispatcherTimer _tmProgress;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            _tmProgress = new DispatcherTimer();
            _tmProgress.Interval = TimeSpan.FromMilliseconds(500);
            _tmProgress.Tick += tmProgress_Tick;
        }

        /// <summary>
        /// Handles the Loaded event of the Window.
        /// Initializes the SDK version display and sets default file paths.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title += $" (SDK v{VideoEditCore.GetVersion()})";

            edOutputFile.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.enc");
            _videoEdit.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            _videoEdit.OnError += _videoEdit_OnError;
            _videoEdit.OnStop += _videoEdit_OnStop;
        }

        /// <summary>
        /// Handles the Closing event of the Window.
        /// Disposes the video editing engine to release resources.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _tmProgress.Stop();

            if (_videoEdit != null)
            {
                _videoEdit.OnError -= _videoEdit_OnError;
                _videoEdit.OnStop -= _videoEdit_OnStop;

                if (_fastEncrypt)
                {
                    _videoEdit.FastEncrypt_Stop();
                }
                else
                {
                    _videoEdit.Stop();
                }

                _videoEdit.Dispose();
                _videoEdit = null;
            }
        }

        /// <summary>
        /// Handles the OnStop event of the VideoEdit engine.
        /// Displays a completion message.
        /// </summary>
        private void _videoEdit_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                _tmProgress.Stop();
                pbProgress.Value = 0;
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
                MessageBox.Show(this, "Complete");
            });
        }

        /// <summary>
        /// Handles the OnError event of the VideoEdit engine.
        /// Logs the error message.
        /// </summary>
        private void _videoEdit_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                edLog.Text += e.Message + Environment.NewLine;
            });
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Checks media info to decide between fast encryption or re-encoding, and starts the process.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(edInputFile.Text))
            {
                MessageBox.Show(this, "Input file does not exist.");
                return;
            }

            if (string.IsNullOrWhiteSpace(edKey.Text))
            {
                MessageBox.Show(this, "Please enter an encryption key. An empty key provides no security.");
                return;
            }

            if (string.IsNullOrWhiteSpace(edOutputFile.Text))
            {
                MessageBox.Show(this, "Please select an output file.");
                return;
            }

            btStart.IsEnabled = false;
            btStop.IsEnabled = true;

            bool hasVideoStream;
            bool hasAudioStream;

            var mediaInfo = new MediaInfoReader();

            mediaInfo.Filename = edInputFile.Text;
            mediaInfo.ReadFileInfo(true);

            hasVideoStream = mediaInfo.VideoStreams.Count > 0;
            hasAudioStream = mediaInfo.AudioStreams.Count > 0;

            // H264 check
            _fastEncrypt = true;
            if (hasVideoStream)
            {
                if (!mediaInfo.VideoStreams[0].Codec.Contains("264"))
                {
                    _fastEncrypt = false;
                }
            }

            // AAC check
            if (hasAudioStream)
            {
                if (!mediaInfo.AudioStreams[0].Codec.ToLowerInvariant().Contains("aac"))
                {
                    _fastEncrypt = false;
                }
            }

            if (cbForceRecompress.IsChecked == true)
            {
                _fastEncrypt = false;
            }

            // fast encrypt or reencoding
            if (_fastEncrypt)
            {
                _videoEdit.FastEncrypt_Start(edInputFile.Text, edOutputFile.Text, EncryptionKeyType.String, edKey.Text, true);
            }
            else
            {
                _videoEdit.Input_Clear_List();

                if (hasVideoStream)
                {
                    _videoEdit.Input_AddVideoFile(edInputFile.Text);
                }

                if (hasAudioStream)
                {
                    _videoEdit.Input_AddAudioFile(edInputFile.Text, edInputFile.Text);
                }

                // you can specify settings
                var mp4Output = new MP4Output();
                mp4Output.Encryption = true;
                mp4Output.Encryption_Format = EncryptionFormat.MP4_H264_SW_AAC;
                mp4Output.Encryption_Key = edKey.Text;

                _videoEdit.Output_Format = mp4Output;
                _videoEdit.Output_Filename = edOutputFile.Text;
                _videoEdit.Mode = VideoEditMode.Convert;
                _videoEdit.Audio_Preview_Enabled = false;

                _videoEdit.Video_Renderer.VideoRenderer = VideoRendererMode.None;

                await _videoEdit.StartAsync();
            }

            _tmProgress.Start();
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the encryption process.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _tmProgress.Stop();
            btStart.IsEnabled = true;
            btStop.IsEnabled = false;

            if (_fastEncrypt)
            {
                _videoEdit.FastEncrypt_Stop();
            }
            else
            {
                await _videoEdit.StopAsync();
            }
        }

        /// <summary>
        /// Handles the Click event of the btInputFile control.
        /// Opens a file dialog to select the input media file.
        /// </summary>
        private void btInputFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Video files|*.mp4;*.avi;*.wmv;*.mpg;*.mkv;*.mov;*.ts|All files|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                edInputFile.Text = dlg.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the btOutputFile control.
        /// Opens a file dialog to select the output encrypted file path.
        /// </summary>
        private void btOutputFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "Encrypted files|*.enc|All files|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                edOutputFile.Text = dlg.FileName;
            }
        }

        /// <summary>
        /// Handles the Tick event of the progress timer.
        /// Updates the progress bar.
        /// </summary>
        private void tmProgress_Tick(object sender, EventArgs e)
        {
            if (_fastEncrypt)
            {
                pbProgress.Value = _videoEdit.FastEncrypt_GetProgress();
            }
            else
            {
                pbProgress.Value = _videoEdit.GetProgress();
            }
        }
    }
}
