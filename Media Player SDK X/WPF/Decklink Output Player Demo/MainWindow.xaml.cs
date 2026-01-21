using Microsoft.Win32;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.Helpers;
using VisioForge.Core.MediaBlocks.Decklink;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Decklink;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;

namespace Decklink_Player_Demo_X
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
        /// The media player instance.
        /// </summary>
        private MediaPlayerCoreX _player;

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
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            Title += $" (SDK v{MediaPlayerCoreX.SDK_Version})";

            CreateEngine();

            // audio outputs
            foreach (var device in await _player.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound))
            {
                cbAudioOutput.Items.Add(device.Name);
            }

            if (cbAudioOutput.Items.Count > 0)
            {
                cbAudioOutput.SelectedIndex = 0;
            }

            // Decklink outputs
            foreach (var device in await DeviceEnumerator.Shared.DecklinkVideoSinksAsync())
            {
                cbDecklinkVideoOutput.Items.Add(device.Name);
            }

            if (cbDecklinkVideoOutput.Items.Count > 0)
            {
                cbDecklinkVideoOutput.SelectedIndex = 0;
            }

            foreach (var device in await DeviceEnumerator.Shared.DecklinkAudioSinksAsync())
            {
                cbDecklinkAudioOutput.Items.Add(device.Name);
            }

            if (cbDecklinkAudioOutput.Items.Count > 0)
            {
                cbDecklinkAudioOutput.SelectedIndex = 0;
            }

            foreach (var name in Enum.GetNames(typeof(DecklinkMode)))
            {
                cbDecklinkVideoMode.Items.Add(name);
            }

            cbDecklinkVideoMode.SelectedIndex = 10;
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
        /// Player on stop.
        /// </summary>
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

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            _player = new MediaPlayerCoreX(VideoView1);
            _player.OnError += Player_OnError;
            _player.OnStop += Player_OnStop;
            _player.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _player.Debug_Mode = cbDebugMode.IsChecked == true;
        }

        /// <summary>
        /// Timer elapsed.
        /// </summary>
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

        /// <summary>
        /// Destroy engine async.
        /// </summary>
        private async Task DestroyEngineAsync()
        {
            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                await Task.Delay(500);
                await _player.DisposeAsync();
                _player = null;
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
                edFilename.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// Tb timeline value changed.
        /// </summary>
        private async void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_timerFlag)
            {
                await _player.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            edLog.Clear();

            await DestroyEngineAsync();

            CreateEngine();

            var audioOutputDevice = (await _player.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound)).First(x => x.Name == cbAudioOutput.Text);
            _player.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);

            _player.Custom_Video_Outputs.Clear();
            _player.Custom_Audio_Outputs.Clear();
            if (cbDecklinkVideoOutput.Items.Count > 0)
            {
                var device = (await DeviceEnumerator.Shared.DecklinkVideoSinksAsync()).First(x => x.Name == cbDecklinkVideoOutput.Text);
                var mode = (DecklinkMode)Enum.Parse(typeof(DecklinkMode), cbDecklinkVideoMode.Text);
                var videoSettings = new DecklinkVideoSinkSettings(device, mode);

                if (cbDecklinkVideoOutputResize.IsChecked == true)
                {
                    DecklinkHelper.GetVideoInfoFromMode(videoSettings.Mode, out var width, out var height, out var framerate);
                    videoSettings.CustomVideoSize = new ResizeVideoEffect(width, height);
                    videoSettings.CustomFrameRate = framerate;
                }

                var videoOutput = new DecklinkVideoSinkBlock(videoSettings);
                _player.Custom_Video_Outputs.Add(videoOutput);
            }

            //if (cbDecklinkAudioOutput.Items.Count > 0)
            //{
            //    var device = (await _deviceEnumerator.DecklinkAudioSinksAsync()).First(x => x.Name == cbDecklinkAudioOutput.Text);
            //    var audioOutput = new DecklinkAudioSinkBlock(new DecklinkAudioSinkSettings(device));
            //    _player.Custom_Audio_Outputs.Add(audioOutput);
            //}

            await _player.OpenAsync(await UniversalSourceSettings.CreateAsync(new Uri(edFilename.Text)));

            await _player.PlayAsync();

            _timer.Start();
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
            }

            tbTimeline.Value = 0;
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await _player.PauseAsync();
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await _player.ResumeAsync();
        }

        /// <summary>
        /// Tb volume value changed.
        /// </summary>
        private void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_player != null)
            {
                _player.Audio_OutputDevice_Volume = tbVolume.Value / 100.0;
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

            VisioForgeX.DestroySDK();
        }
    }
}
