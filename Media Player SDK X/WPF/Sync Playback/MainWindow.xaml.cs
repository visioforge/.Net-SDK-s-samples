using Microsoft.Win32;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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
        private System.Timers.Timer _timer;

        private volatile bool _timerFlag;

        private MediaPlayerCoreX _player1;

        private MediaPlayerCoreX _player2;

        private volatile bool _isClosing;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
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

        private void Player_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                edLog.Text = edLog.Text + e.Message + Environment.NewLine;
            }));
        }

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

        private void CreateEngines()
        {
            _player1 = new MediaPlayerCoreX(VideoView1);
            _player1.OnError += Player_OnError;
            _player1.OnStop += Player1_OnStop;

            _player1.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _player1.Debug_Mode = cbDebugMode.IsChecked == true;

            _player2 = new MediaPlayerCoreX(VideoView2);
            _player2.OnError += Player_OnError;
            //_player2.OnStop += Player2_OnStop;

            _player2.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _player2.Debug_Mode = cbDebugMode.IsChecked == true;

        }

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
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
                //_player2.OnStop -= Player2_OnStop;
                await Task.Delay(500);
                await _player2.DisposeAsync();
                _player2 = null;
            }
        }

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                edFilename1.Text = dialog.FileName;
            }
        }

        private void btSelectFile2_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                edFilename2.Text = dialog.FileName;
            }
        }

        private async void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
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

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            edLog.Clear();

            await DestroyEngineAsync();

            CreateEngines();

            var audioOutputs = await _player1.Audio_OutputDevicesAsync();

            // Configure player 1
            var audioOutputDevice = audioOutputs.First(x => x.DisplayName == cbAudioOutput.Text);
            _player1.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);
            await _player1.OpenAsync(edFilename1.Text);

            // Configure player 2
            _player2.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);
            await _player2.OpenAsync(edFilename2.Text);

            // Preload playerw
            //  _player1.Play_DelayEnabled = true;
            await _player1.PlayAsync(onlyPreload: true);

        //    _player2.Play_DelayEnabled = true;
            await _player2.PlayAsync(onlyPreload: true);

            await Task.Delay(500);

            // Start players
            await _player1.ResumeAsync();
            await _player2.ResumeAsync();

            // Start timer
            _timer.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            if (_player1 != null)
            {
                await _player1.StopAsync();
                await DestroyEngineAsync();
                _player1 = null;
            }

            if (_player2 != null)
            {
                await _player2.StopAsync();
                await DestroyEngineAsync();
                _player2 = null;
            }

            tbTimeline.Value = 0;
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await _player1.PauseAsync();
            await _player2.PauseAsync();
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await _player1.ResumeAsync();
            await _player2.ResumeAsync();
        }

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

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();

            _isClosing = true;

            await DestroyEngineAsync();
        }
    }
}
