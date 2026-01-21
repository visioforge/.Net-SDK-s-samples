using Microsoft.Win32;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.MediaPlayer;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.MediaPlayer;

namespace Custom_Source_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// Custom Source Player demo demonstrates how to use MediaPlayerCore 
    /// with a custom DirectShow source filter (MediaPlayerSourceMode.CustomSource).
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The timer.
        /// </summary>
        private System.Timers.Timer _timer;

        /// <summary>
        /// Flag to indicate if the timer is running.
        /// </summary>
        private volatile bool _timerFlag;

        /// <summary>
        /// The media player.
        /// </summary>
        private MediaPlayerCore _player;

        /// <summary>
        /// Flag to indicate if the window is closing.
        /// </summary>
        private volatile bool _isClosing;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += Timer_Elapsed;

            Title += $" (SDK v{VisioForge.Core.MediaPlayerX.MediaPlayerCoreX.SDK_Version})";

            CreateEngine();

            // Populate audio output devices
            foreach (var device in _player.Audio_OutputDevices())
            {
                cbAudioOutput.Items.Add(device);
            }

            if (cbAudioOutput.Items.Count > 0)
            {
                cbAudioOutput.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Player on error.
        /// </summary>
        private void Player_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                MessageBox.Show(this, e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            });
        }

        /// <summary>
        /// Player on stop.
        /// </summary>
        private void Player_OnStop(object sender, StopEventArgs e)
        {
            if (_isClosing)
            {
                return;
            }

            Dispatcher.Invoke(() =>
            {
                tbTimeline.Value = 0;
                lbTime.Text = "00:00:00 / 00:00:00";
            });
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            _player = new MediaPlayerCore(VideoView1);
            _player.OnError += Player_OnError;
            _player.OnStop += Player_OnStop;

            _player.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _player.Debug_Mode = cbDebugMode.IsChecked == true;
        }

        /// <summary>
        /// Timer elapsed.
        /// </summary>
        private async void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timerFlag = true;

            if (_player == null)
            {
                return;
            }

            var position = await _player.Position_Get_TimeAsync();
            var duration = await _player.Duration_TimeAsync();

            Dispatcher.Invoke(() =>
            {
                tbTimeline.Maximum = (int)duration.TotalSeconds;

                lbTime.Text = position.ToString(@"hh\:mm\:ss") + " / " + duration.ToString(@"hh\:mm\:ss");

                if (tbTimeline.Maximum >= position.TotalSeconds)
                {
                    tbTimeline.Value = (int)position.TotalSeconds;
                }
            });

            _timerFlag = false;
        }

        /// <summary>
        /// Destroy engine async.
        /// </summary>
        private async Task DestroyEngineAsync()
        {
            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                Thread.Sleep(500);
                await _player.DisposeAsync();
                _player = null;
            }
        }

        /// <summary>
        /// Handles the bt select file click event.
        /// </summary>
        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Media files|*.mp4;*.avi;*.mkv;*.wmv;*.mov;*.ts;*.mpg;*.mpeg|All files|*.*"
            };

            if (dialog.ShowDialog() == true)
            {
                edFilename.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// Tb timeline value changed.
        /// </summary>
        private async void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_timerFlag && _player != null)
            {
                await _player.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            // Validate CLSID
            string clsid = edFilterCLSID.Text.Trim();
            if (string.IsNullOrEmpty(clsid))
            {
                MessageBox.Show(this, "Please specify a custom source filter CLSID.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validate file
            if (string.IsNullOrEmpty(edFilename.Text))
            {
                MessageBox.Show(this, "Please specify a file to play.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            await DestroyEngineAsync();

            CreateEngine();

            _player.Debug_Mode = cbDebugMode.IsChecked == true;

            // Set audio output device
            _player.Audio_OutputDevice = cbAudioOutput.Text;

            // Configure custom source mode
            _player.Source_Mode = MediaPlayerSourceMode.CustomSource;
            _player.Source_Custom_CLSID = clsid;

            // Add file to playlist
            _player.Playlist_Clear();
            _player.Playlist_Add(edFilename.Text);

            // Start playback
            await _player.PlayAsync();

            // Start position/duration update timer
            _timer.Start();
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            if (_player != null)
            {
                await _player.PauseAsync();
            }
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            if (_player != null)
            {
                await _player.ResumeAsync();
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            if (_player != null)
            {
                await _player.StopAsync();
                await DestroyEngineAsync();
                _player = null;
            }

            tbTimeline.Value = 0;
            lbTime.Text = "00:00:00 / 00:00:00";
        }

        /// <summary>
        /// Tb volume value changed.
        /// </summary>
        private void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_player != null)
            {
                _player.Audio_OutputDevice_Volume_Set(0, (int)tbVolume.Value);
            }
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();

            _isClosing = true;

            await DestroyEngineAsync();
        }
    }
}
