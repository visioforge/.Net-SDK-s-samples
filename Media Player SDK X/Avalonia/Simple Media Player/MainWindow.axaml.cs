using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaInfoReaderX;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.Avalonia;

using System.Reactive.Linq;

namespace Simple_Media_Player
{
    public partial class MainWindow : Window
    {
        private System.Timers.Timer _tmPosition;

        private bool _initialized;

        private MediaPlayerCoreX _player;

#if WINDOWS
        private AudioOutputDeviceAPI? _audioOutputDeviceAPI = AudioOutputDeviceAPI.DirectSound;
#else
        private AudioOutputDeviceAPI? _audioOutputDeviceAPI = null;
#endif

        public ObservableCollection<string> Log { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> Info { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> AudioOutputDevices { get; set; } = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();

#if DEBUG
            this.AttachDevTools();
#endif

            // We have to initialize the engine on start
            Activated += MainWindow_Activated;
            Closing += MainWindow_Closing;

            DataContext = this;
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

        private async void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_player == null)
            {
                return;
            }

            _player.Stop();
            await DestroyEngineAsync();

            VisioForgeX.DestroySDK();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private async Task ShowMessageAsync(string message)
        {
            var messageBoxStandardWindow = MsBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandard("Message", message);

            await messageBoxStandardWindow.ShowAsync();
        }

        private async void MainWindow_Activated(object sender, EventArgs e)
        {
            if (_initialized)
            {
                return;
            }

            _initialized = true;

            InitControls();

            InitPlayer();

            Title += $" (SDK v{MediaPlayerCoreX.SDK_Version})";
            _player.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            AudioOutputDeviceInfo[] audioOutputs = await _player.Audio_OutputDevicesAsync(_audioOutputDeviceAPI);
            foreach (var item in audioOutputs)
            {
                AudioOutputDevices.Add(item.DisplayName);
            }

            if (AudioOutputDevices.Count > 0)
            {
                cbAudioOutputDevice.SelectedIndex = 0;
            }
        }

        private void InitPlayer()
        {
            _player = new MediaPlayerCoreX(VideoView1);
            _player.OnStop += Player_OnStop;
            _player.OnError += Player_OnError;
        }

        private volatile bool _tbTimelineApplyingValue;

        private bool disposedValue;

        private void InitControls()
        {
            VideoView1 = this.FindControl<VideoView>("VideoView1");

            lbTimeline = this.FindControl<TextBlock>("lbTimeline");

            btSelectFile = this.FindControl<Button>("btSelectFile");
            btSelectFile.Click += btSelectFile_Click;

            edFilenameOrURL = this.FindControl<TextBox>("edFilenameOrURL");

            tbTimeline = this.FindControl<Slider>("tbTimeline");
            tbTimeline.GetObservable(Slider.ValueProperty)
                .Subscribe(value => tbTimeline_Scroll());

            tbSpeed = this.FindControl<Slider>("tbSpeed");
            tbSpeed.GetObservable(Slider.ValueProperty)
                .Subscribe(value => tbSpeed_Scroll());

            btStart = this.FindControl<Button>("btStart");
            btStart.Click += btStart_Click;

            btStop = this.FindControl<Button>("btStop");
            btStop.Click += btStop_Click;

            btResume = this.FindControl<Button>("btResume");
            btResume.Click += btResume_Click;

            btPause = this.FindControl<Button>("btPause");
            btPause.Click += btPause_Click;

            btNextFrame = this.FindControl<Button>("btNextFrame");
            btNextFrame.Click += btNextFrame_Click;

            tbVolume = this.FindControl<Slider>("tbVolume");
            tbVolume.GetObservable(Slider.ValueProperty)
                .Subscribe(value => tbVolume_Scroll());

            btReadTags = this.FindControl<Button>("btReadTags");
            btReadTags.Click += btReadTags_Click;

            btReadInfo = this.FindControl<Button>("btReadInfo");
            btReadInfo.Click += btReadInfo_Click;

            cbDebugMode = this.FindControl<CheckBox>("cbDebugMode");
            cbPlayAudio = this.FindControl<CheckBox>("cbPlayAudio");

            cbAudioOutputDevice = this.FindControl<ComboBox>("cbAudioOutputDevice");

            _tmPosition = new System.Timers.Timer(1000);
            _tmPosition.Elapsed += tmPosition_Elapsed;

            mmLog = this.FindControl<ListBox>("mmLog");
            mmLog.ItemsSource = Log;

            mmInfo = this.FindControl<ListBox>("mmInfo");
            mmInfo.ItemsSource = Info;

            cbAudioOutputDevice = this.FindControl<ComboBox>("cbAudioOutputDevice");
            cbAudioOutputDevice.ItemsSource = AudioOutputDevices;
        }

        private async void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var ofd = new OpenFileDialog();
#pragma warning restore CS0618 // Type or member is obsolete
            string[] files = await ofd.ShowAsync(this);
            if (files != null && files.Length > 0)
            {
                edFilenameOrURL.Text = files[0];
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            tbSpeed.Value = 10;
            _player.Debug_Mode = cbDebugMode.IsChecked == true;

            string source = edFilenameOrURL.Text;

            _player.Audio_Play = cbPlayAudio.IsChecked == true;

            var audioOutputs = await _player.Audio_OutputDevicesAsync(_audioOutputDeviceAPI);
            var audioOutputDevice = audioOutputs.First(device => device.DisplayName == cbAudioOutputDevice.SelectedItem.ToString());
            _player.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);

            await _player.OpenAsync(await UniversalSourceSettings.CreateAsync(new Uri(source)));
            await _player.PlayAsync();

            _tmPosition.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _tmPosition.Stop();

            await _player.StopAsync();

            tbTimeline.Value = 0;
            lbTimeline.Text = "00:00:00 / 00:00:00";
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await _player.ResumeAsync();
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await _player.PauseAsync();
        }

        private void btNextFrame_Click(object sender, RoutedEventArgs e)
        {
            _player.NextFrame(1);
        }

        private void Player_OnError(object sender, ErrorsEventArgs e)
        {
            Log.Add(e.Message);
        }

        private void Player_OnStop(object sender, StopEventArgs e)
        {
            _tmPosition.Stop();

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                VideoView1.Refresh();
                //ShowMessage("Playback complete.");
            });
        }

        private async void tbTimeline_Scroll()
        {
            if (_tbTimelineApplyingValue)
            {
                await _player.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync((Action)(() =>
            {
                var position = _player.Position_Get();
                var duration = _player.Duration();

                tbTimeline.Maximum = (int)duration.TotalSeconds;

                lbTimeline.Text = position.ToString("hh\\:mm\\:ss", CultureInfo.InvariantCulture) + " / " + duration.ToString("hh\\:mm\\:ss", CultureInfo.InvariantCulture);

                if (tbTimeline.Maximum >= position.TotalSeconds)
                {
                    _tbTimelineApplyingValue = false;
                    tbTimeline.Value = position.TotalSeconds;
                    _tbTimelineApplyingValue = true;
                }
            }));
        }

        private async void tbSpeed_Scroll()
        {
            if (_player == null)
            {
                return;
            }

            await _player.Rate_SetAsync(tbSpeed.Value / 10.0);
        }

        private void tbVolume_Scroll()
        {
            if (_player == null)
            {
                return;
            }

            _player.Audio_OutputDevice_Volume = tbVolume.Value / 100.0;
        }

        private void btReadTags_Click(object sender, RoutedEventArgs e)
        {
            var tags = _player.Tags_Read(edFilenameOrURL.Text);
            Info.Clear();
            Info.Add(tags?.ToString());
        }

        private async void btReadInfo_Click(object sender, RoutedEventArgs e)
        {
            Info.Clear();

            var infoReader = new MediaInfoReaderX(_player);
            await infoReader.OpenAsync(new Uri(edFilenameOrURL.Text));

            if (infoReader.Info.VideoStreams.Count > 0)
            {
                Info.Add("Video streams:");
                foreach (var video in infoReader.Info.VideoStreams)
                {
                    Info.Add($"{video.Width}x{video.Height}, {video.FrameRate:F2} fps, Duration: {video.Duration.ToString()}");
                }
            }

            if (infoReader.Info.AudioStreams.Count > 0)
            {
                Info.Add("Audio streams:");
                foreach (var audio in infoReader.Info.AudioStreams)
                {
                    Info.Add($"{audio.SampleRate} Hz, {audio.Channels} channels, Duration: {audio.Duration.ToString()}");
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _tmPosition?.Dispose();
                _tmPosition = null;

                VideoView1?.Dispose();
                VideoView1 = null;

                disposedValue = true;
            }
        }

        ~MainWindow()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}