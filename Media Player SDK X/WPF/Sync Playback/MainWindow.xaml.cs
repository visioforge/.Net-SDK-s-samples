using Microsoft.Win32;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;

namespace SyncPlayback
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The timer for UI updates.
        /// </summary>
        private System.Timers.Timer _timer;

        /// <summary>
        /// Flag to prevent re-entrant timer calls.
        /// </summary>
        private volatile bool _timerFlag;

        /// <summary>
        /// The media player instance 1.
        /// </summary>
        private MediaPlayerCoreX _player1;

        /// <summary>
        /// The media player instance 2.
        /// </summary>
        private MediaPlayerCoreX _player2;

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
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Initialize the SDK
                await VisioForgeX.InitSDKAsync();

                _timer = new System.Timers.Timer(500);
                _timer.Elapsed += _timer_Elapsed;

                Title += $" (SDK v{VisioForge.Core.MediaPlayerX.MediaPlayerCoreX.SDK_Version})";

                CreateEngines();

                var audioOutputs = await _player1.Audio_OutputDevicesAsync();
                foreach (var device in audioOutputs)
                {
                    cbAudioOutput.Items.Add(device);
                }

                if (cbAudioOutput.Items.Count > 0)
                {
                    cbAudioOutput.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Window_Loaded error: {ex.Message}");
            }
        }

        /// <summary>
        /// Player on error.
        /// </summary>
        private void Player_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                edLog.Text = edLog.Text + e.Message + Environment.NewLine;
            }));
        }

        /// <summary>
        /// Player 1 on stop.
        /// </summary>
        private void Player1_OnStop(object sender, StopEventArgs e)
        {
            if (_isClosing)
            {
                return;
            }

            Dispatcher.Invoke((Action)(() =>
            {
                tbTimeline.Value = 0;
            }));
        }

        /// <summary>
        /// Create engines.
        /// </summary>
        private void CreateEngines()
        {
            _player1 = new MediaPlayerCoreX(VideoView1);
            _player1.OnError += Player_OnError;
            _player1.OnStop += Player1_OnStop;

            _player1.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _player1.Debug_Mode = cbDebugMode.IsChecked == true;

            _player2 = new MediaPlayerCoreX(VideoView2);
            _player2.OnError += Player_OnError;

            _player2.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _player2.Debug_Mode = cbDebugMode.IsChecked == true;

        }

        /// <summary>
        /// Timer elapsed.
        /// </summary>
        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                _timerFlag = true;

                if (_player1 == null)
                {
                    return;
                }

                var position = await _player1.Position_GetAsync();
                var duration = await _player1.DurationAsync();

                Dispatcher.Invoke((Action)(() =>
                {
                    tbTimeline.Maximum = (int)duration.TotalSeconds;

                    lbTime.Text = position.ToString("hh\\:mm\\:ss") + " | " + duration.ToString("hh\\:mm\\:ss");

                    if (tbTimeline.Maximum >= position.TotalSeconds)
                    {
                        tbTimeline.Value = (int)position.TotalSeconds;
                    }
                }));

                _timerFlag = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Timer error: {ex.Message}");
            }
        }

        /// <summary>
        /// Destroy engine async.
        /// </summary>
        private async Task DestroyEngineAsync()
        {
            if (_player1 != null)
            {
                _player1.OnError -= Player_OnError;
                _player1.OnStop -= Player1_OnStop;
                await Task.Delay(500);
                await _player1.DisposeAsync();
                _player1 = null;
            }

            if (_player2 != null)
            {
                _player2.OnError -= Player_OnError;
                await Task.Delay(500);
                await _player2.DisposeAsync();
                _player2 = null;
            }
        }

        /// <summary>
        /// Handles the bt select file click event.
        /// </summary>
        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                edFilename1.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// Handles the bt select file 2 click event.
        /// </summary>
        private void btSelectFile2_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                edFilename2.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// Tb timeline value changed.
        /// </summary>
        private async void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (!_timerFlag && _player1 != null)
                {
                    await _player1.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
                }

                if (!_timerFlag && _player2 != null)
                {
                    await _player2.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Seek error: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                edLog.Clear();

                await DestroyEngineAsync();

                CreateEngines();

                var audioOutputs = await _player1.Audio_OutputDevicesAsync();

                // Configure player 1
                var audioOutputDevice = audioOutputs.FirstOrDefault(x => x.DisplayName == cbAudioOutput.Text);
                if (audioOutputDevice == null)
                {
                    edLog.Text = "Selected audio output device not found" + Environment.NewLine;
                    return;
                }
                _player1.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);
                await _player1.OpenAsync(edFilename1.Text);

                // Configure player 2
                _player2.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);
                await _player2.OpenAsync(edFilename2.Text);

                // Preload players
                await _player1.PlayAsync(onlyPreload: true);
                await _player2.PlayAsync(onlyPreload: true);

                await Task.Delay(500);

                // Start players
                await _player1.ResumeAsync();
                await _player2.ResumeAsync();

                // Start timer
                _timer.Start();
            }
            catch (Exception ex)
            {
                edLog.Text += $"Start error: {ex.Message}{Environment.NewLine}";
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _timer.Stop();

                // Stop both players first
                if (_player1 != null)
                {
                    await _player1.StopAsync();
                }

                if (_player2 != null)
                {
                    await _player2.StopAsync();
                }

                // DestroyEngineAsync disposes both players, so only call it once
                await DestroyEngineAsync();

                tbTimeline.Value = 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Stop error: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_player1 != null)
                {
                    await _player1.PauseAsync();
                }

                if (_player2 != null)
                {
                    await _player2.PauseAsync();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Pause error: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_player1 != null)
                {
                    await _player1.ResumeAsync();
                }

                if (_player2 != null)
                {
                    await _player2.ResumeAsync();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Resume error: {ex.Message}");
            }
        }

        /// <summary>
        /// Tb volume value changed.
        /// </summary>
        private void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_player1 != null)
            {
                _player1.Audio_OutputDevice_Volume = tbVolume.Value / 100.0;
            }

            if (_player2 != null)
            {
                _player2.Audio_OutputDevice_Volume = tbVolume.Value / 100.0;
            }
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                _timer.Stop();

                _isClosing = true;

                await DestroyEngineAsync();

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Window closing error: {ex.Message}");
            }
        }
    }
}
