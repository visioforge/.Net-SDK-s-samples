using Microsoft.Win32;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.MediaInfo;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;

namespace MPEG_TS_Player_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Timers.Timer _timer;

        private volatile bool _timerFlag;

        private MediaPlayerCoreX _player;

        private volatile bool _isClosing;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            Title += $" (SDK v{MediaPlayerCoreX.SDK_Version})";

            await VisioForgeX.InitSDKAsync();

            CreateEngine();

            foreach (var device in await _player.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound))
            {
                cbAudioOutput.Items.Add(device.Name);
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

        private void Player_OnStop(object sender, StopEventArgs e)
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

        private void CreateEngine()
        {
            _player = new MediaPlayerCoreX(VideoView1);
            _player.OnError += Player_OnError;
            _player.OnStop += Player_OnStop;

            _player.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _player.Debug_Mode = cbDebugMode.IsChecked == true;
        }

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timerFlag = true;

            if (_player == null)
            {
                return;
            }

            var position = await _player.Position_GetAsync();
            var duration = await _player.DurationAsync();

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
            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                Thread.Sleep(500);
                await _player.DisposeAsync();
                _player = null;
            }
        }

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                edFilename.Text = dialog.FileName;
            }
        }

        private async void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_timerFlag && _player != null)
            {
                await _player.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async Task RestartPlayback()
        {
            edLog.Clear();

            if (_player != null)
            {
                await _player.StopAsync();

                await DestroyEngineAsync();
            }

            CreateEngine();

            var audioOutputDevice = (await _player.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound)).First(x => x.Name == cbAudioOutput.Text);
            _player.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);

            _player.OnStreamsInfoAvailable += _player_OnStreamsInfoAvailable;

            cbVideoStream.Items.Clear();
            cbAudioStream.Items.Clear();

            var source = await UniversalSourceSettings.CreateAsync(new Uri(edFilename.Text));
            //source.UseAdvancedEngine = false;
            source.MPEGTSProgramNumber = Convert.ToInt32(cbProgramStream.Text);
            await _player.OpenAsync(source);

            await _player.PlayAsync();
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            cbProgramStream.Items.Clear();
            var programs = TSProgramEnumerator.EnumeratePrograms(edFilename.Text);
            if (programs.Any())
            {
                foreach (var program in programs)
                {
                    cbProgramStream.Items.Add(program);
                }

                cbProgramStream.Tag = true;
                cbProgramStream.SelectedIndex = 0;
                cbProgramStream.Tag = false;
            }

            await RestartPlayback();

            _timer.Start();
        }

        private void _player_OnStreamsInfoAvailable(object sender, EventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                var videoStreams = _player.Video_Streams;
                cbVideoStream.Items.Clear();

                for (int i = 0; i < videoStreams.Count; i++)
                {
                    cbVideoStream.Items.Add($"Video stream {i}");
                }

                if (cbVideoStream.Items.Count > 0)
                {
                    cbVideoStream.Tag = true;
                    cbVideoStream.SelectedIndex = 0;
                    cbVideoStream.Tag = false;
                }

                var audioStreams = _player.Audio_Streams;
                cbAudioStream.Items.Clear();

                for (int i = 0; i < audioStreams.Count; i++)
                {
                    cbAudioStream.Items.Add($"Audio stream {i}");
                }

                if (cbAudioStream.Items.Count > 0)
                {
                    cbAudioStream.Tag = true;
                    cbAudioStream.SelectedIndex = 0;
                    cbAudioStream.Tag = false;
                }
            }));
        }

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
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await _player.PauseAsync();
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await _player.ResumeAsync();
        }

        private void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_player != null)
            {
                _player.Audio_OutputDevice_Volume = tbVolume.Value / 100.0;
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();

            _isClosing = true;

            await DestroyEngineAsync();

            VisioForgeX.DestroySDK();
        }

        private void cbVideoStream_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbVideoStream.SelectedIndex != -1 && !(bool)cbVideoStream.Tag)
            {
                _player.Video_Stream_Select(_player.Video_Streams[cbVideoStream.SelectedIndex]);
            }
        }

        private void cbAudioStream_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbAudioStream.SelectedIndex != -1 && !(bool)cbAudioStream.Tag)
            {
                _player.Audio_Stream_Select(_player.Audio_Streams[cbAudioStream.SelectedIndex]);
            }
        }

        private async void cbProgramStream_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbProgramStream.SelectedIndex == -1 || (bool)cbProgramStream.Tag)
            {
                return;
            }

            await RestartPlayback();
        }
    }
}
