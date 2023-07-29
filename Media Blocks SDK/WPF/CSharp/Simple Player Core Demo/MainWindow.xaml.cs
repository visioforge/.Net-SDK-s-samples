using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.SimplePlayerX;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;

namespace MediaBlocks_Simple_Player_Core_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Timers.Timer _timer;

        private volatile bool _timerFlag;

        private SimplePlayerCoreX _simplePlayer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MediaBlocksPipeline.InitSDK();

            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
        }

        private void Player_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                edLog.Text = edLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                _timer.Stop();
                tbTimeline.Value = 0;
            }));
        }

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timerFlag = true;

            var position = await _simplePlayer.Position_GetAsync();
            var duration = await _simplePlayer.DurationAsync();

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
            if (_simplePlayer != null)
            {
                _simplePlayer.OnError -= Player_OnError;
                _simplePlayer.OnStop -= Pipeline_OnStop;
                await _simplePlayer.DisposeAsync();
                _simplePlayer = null;
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
            if (!_timerFlag && _simplePlayer != null)
            {
                await _simplePlayer.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            edLog.Clear();

            VideoView1.SetNativeRendering(true);

            _simplePlayer = new SimplePlayerCoreX(VideoView1);
            _simplePlayer.Audio_Streams_MixAll = cbPlayAllAudioStreams.IsChecked == true;

            _simplePlayer.OnStreamsInfoAvailable += _simplePlayer_OnStreamsInfoAvailable;
            _simplePlayer.OnError += Player_OnError;

            await _simplePlayer.StartAsync(await UniversalSourceSettings.CreateAsync(new Uri(edFilename.Text)));

            _timer.Start();
        }

        private void _simplePlayer_OnStreamsInfoAvailable(object sender, EventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                cbAudioStream.Items.Clear();
                cbVideoStream.Items.Clear();

                foreach (var stream in _simplePlayer.Video_Streams)
                {
                    cbVideoStream.Items.Add(stream);
                }

                foreach (var stream in _simplePlayer.Audio_Streams)
                {
                    cbAudioStream.Items.Add(stream);
                }

                if (cbAudioStream.Items.Count > 0)
                {
                    cbAudioStream.SelectedIndex = 0;
                }

                if (cbVideoStream.Items.Count > 0)
                {
                    cbVideoStream.SelectedIndex = 0;
                }
            }));
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            if (_simplePlayer != null)
            {
                //_simplePlayer.Debug_SavePipeline("before-stop");
                await _simplePlayer.StopAsync();
                await DestroyEngineAsync();

                _simplePlayer = null;
            }            

            tbTimeline.Value = 0;
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await _simplePlayer.PauseAsync();
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await _simplePlayer.ResumeAsync();
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();

            await DestroyEngineAsync(); 
        }

        private void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_simplePlayer == null)
            {
                return;
            }

            _simplePlayer.Audio_Volume = tbVolume.Value / 100.0;
        }

        private void btSelectVideoStream_Click(object sender, RoutedEventArgs e)
        {
            if (_simplePlayer == null || cbVideoStream.SelectedIndex == -1 || _simplePlayer.State != VisioForge.Core.Types.PlaybackState.Play)
            {
                return;
            }

            _simplePlayer.Video_Stream_Select(_simplePlayer.Video_Streams[cbVideoStream.SelectedIndex]);
        }

        private void btSelectAudioStream_Click(object sender, RoutedEventArgs e)
        {
            if (_simplePlayer == null || cbAudioStream.SelectedIndex == -1 || _simplePlayer.State != VisioForge.Core.Types.PlaybackState.Play)
            {
                return;
            }

            _simplePlayer.Audio_Stream_Select(_simplePlayer.Audio_Streams[cbAudioStream.SelectedIndex]);
        }
    }
}
