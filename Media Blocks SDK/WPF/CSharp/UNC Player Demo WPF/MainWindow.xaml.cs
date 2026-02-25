using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.Helpers;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;

namespace MediaBlocks_UNC_Player_Demo_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Timers.Timer _timer;

        private volatile bool _timerFlag;

        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private UniversalSourceBlockV2 _fileSource;

        private bool _smbConnected;

        private string _smbSharePath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                this.IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                this.IsEnabled = true;
                Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

                _timer = new System.Timers.Timer(500);
                _timer.Elapsed += _timer_Elapsed;

                var audioOutputDevices = (await AudioRendererBlock.GetDevicesAsync(AudioOutputDeviceAPI.DirectSound)).ToArray();
                cbAudioOutput.Items.Clear();
                if (audioOutputDevices.Length > 0)
                {
                    foreach (var item in audioOutputDevices)
                    {
                        cbAudioOutput.Items.Add(item.DisplayName);
                    }

                    cbAudioOutput.SelectedIndex = 0;
                }

                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
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

        private async Task CreateEngineAsync()
        {
            var uncPath = edFilename.Text;
            var username = edUsername.Text;
            var password = edPassword.Password;
            var domain = edDomain.Text;

            // Pre-authenticate to SMB share if credentials are provided
            if (!string.IsNullOrEmpty(username))
            {
                _smbConnected = SambaHelper.ConnectToShare(uncPath, username, password, domain);
                if (_smbConnected)
                {
                    _smbSharePath = uncPath;
                }
                else
                {
                    edLog.Text += "Failed to authenticate to SMB share. Check credentials." + Environment.NewLine;
                    return;
                }
            }

            var audioDevices = await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound);
            var selectedAudioDevice = audioDevices.FirstOrDefault(device => device.DisplayName == cbAudioOutput.Text);
            if (selectedAudioDevice == null)
            {
                MessageBox.Show(
                    "The selected audio output device is not available. Please choose a different device.",
                    "Audio Device Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
            _pipeline.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            var settings = await UniversalSourceSettingsV2.CreateAsync(new Uri(uncPath));
            settings.SambaUsername = username;
            settings.SambaPassword = password;
            settings.SambaDomain = domain;

            _fileSource = new UniversalSourceBlockV2(settings);

            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);
            _pipeline.Connect(_fileSource.VideoOutput, _videoRenderer.Input);

            _audioRenderer = new AudioRendererBlock(selectedAudioDevice);
            _pipeline.Connect(_fileSource.AudioOutput, _audioRenderer.Input);
        }

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                _timerFlag = true;

                var position = await _pipeline.Position_GetAsync();
                var duration = await _pipeline.DurationAsync();

                Dispatcher.Invoke((Action)(() =>
                {
                    tbTimeline.Maximum = (int)duration.TotalSeconds;

                    lbTime.Text = position.ToString("hh\\:mm\\:ss") + " / " + duration.ToString("hh\\:mm\\:ss");

                    if (tbTimeline.Maximum >= position.TotalSeconds)
                    {
                        tbTimeline.Value = (int)position.TotalSeconds;
                    }
                }));

                _timerFlag = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async Task StopEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;
                await _pipeline.StopAsync(true);
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            if (_smbConnected)
            {
                try
                {
                    SambaHelper.DisconnectFromShare(_smbSharePath);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

                _smbConnected = false;
            }
        }

        private void DestroyEngine()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;
                _pipeline.Stop(true);
                _pipeline.Dispose();
                _pipeline = null;
            }

            if (_smbConnected)
            {
                try
                {
                    SambaHelper.DisconnectFromShare(_smbSharePath);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

                _smbConnected = false;
            }
        }

        private async void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (!_timerFlag && _pipeline != null)
                {
                    await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                edLog.Clear();

                await CreateEngineAsync();

                if (_pipeline == null)
                {
                    return;
                }

                _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;

                await _pipeline.StartAsync();

                _timer.Start();
            }
            catch (Exception ex)
            {
                edLog.Text += ex.Message + Environment.NewLine;
                Debug.WriteLine(ex);
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _timer.Stop();

                if (_pipeline != null)
                {
                    await StopEngineAsync();
                }

                tbTimeline.Value = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _pipeline.PauseAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_pipeline == null)
                {
                    return;
                }

                await _pipeline.ResumeAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_audioRenderer != null)
            {
                _audioRenderer.Volume = tbVolume.Value / 100.0;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer?.Stop();

            DestroyEngine();

            VisioForgeX.DestroySDK();
        }
    }
}
