using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaInfoReaderX;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.UI.Avalonia;

namespace MediaBlocks_Simple_Player_Demo_Avalonia
{
    public partial class MainWindow : Window, IDisposable
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private FileSourceBlock _fileSource;

        private System.Timers.Timer _tmPosition;

        private bool _initialized;

        public ObservableCollection<string> Log { get; set; } = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            MediaBlocksPipeline.InitSDK();

            InitControls();

            Activated += MainWindow_Activated;
            Closing += MainWindow_Closing;

            DataContext = this;
        }

        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline(false);
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _pipeline.OnError += MediaPlayer1_OnError;
            _pipeline.OnStop += MediaPlayer1_OnStop;
        }

        private void DestroyEngine()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= MediaPlayer1_OnError;
                _pipeline.OnStop -= MediaPlayer1_OnStop;

                _pipeline.Dispose();
                _pipeline = null;
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btStop_Click(null, null);

            DestroyEngine();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            if (_initialized)
            {
                return;
            }

            _initialized = true;

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
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

            cbDebugMode = this.FindControl<CheckBox>("cbDebugMode");

            _tmPosition = new System.Timers.Timer(1000);
            _tmPosition.Elapsed += tmPosition_Elapsed;

            cbAudioOutput = this.FindControl<ComboBox>("cbAudioOutput");

            var cbAudioOutputItems = new ObservableCollection<string>();
            foreach (var device in AudioRendererBlock.GetDevicesAsync(AudioOutputDeviceAPI.DirectSound).Result)
            {
                cbAudioOutputItems.Add(device.Name);
            }

            cbAudioOutput.Items = cbAudioOutputItems;

            if (cbAudioOutputItems.Count > 0)
            {
                cbAudioOutput.SelectedIndex = 0;
            }
        }

        private async void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            string[] files = await ofd.ShowAsync(this);
            if (files != null && files.Length > 0)
            {
                edFilenameOrURL.Text = files[0];
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            tbSpeed.Value = 10;
            Log.Clear();

            CreateEngine();

            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;

            var mediaInfo = new MediaInfoReaderX();
            bool videoStream = true;
            bool audioStream = true;
            if (await mediaInfo.OpenAsync(new Uri(edFilenameOrURL.Text)))
            {
                if (mediaInfo.Info.VideoStreams.Count == 0)
                {
                    videoStream = false;
                }

                if (mediaInfo.Info.AudioStreams.Count == 0)
                {
                    audioStream = false;
                }
            }

            _fileSource = new FileSourceBlock(edFilenameOrURL.Text, renderVideo: videoStream, renderAudio: audioStream);

            if (videoStream)
            {
                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);
                _pipeline.Connect(_fileSource.VideoOutput, _videoRenderer.Input);
            }

            if (audioStream)
            {
                _audioRenderer = new AudioRendererBlock();
                _pipeline.Connect(_fileSource.AudioOutput, _audioRenderer.Input);
            }

            await _pipeline.StartAsync();

            _tmPosition.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _tmPosition?.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
            }

            tbTimeline.Value = 0;

            VideoView1?.InvalidateVisual();

            DestroyEngine();
            lbTimeline.Text = "00:00:00 / 00:00:00";
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.ResumeAsync();
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.PauseAsync();
        }

        private void btNextFrame_Click(object sender, RoutedEventArgs e)
        {
            _pipeline.NextFrame(1);
        }

        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Log.Add(e.Message);
        }

        private void MediaPlayer1_OnStop(object sender, StopEventArgs e)
        {
            _tmPosition.Stop();

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                VideoView1.Refresh();
            });
        }

        private async void tbTimeline_Scroll()
        {
            if (_tbTimelineApplyingValue)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync((Action)(async () =>
            {
                var position = await _pipeline.Position_GetAsync();
                var duration = await _pipeline.DurationAsync();

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
            if (_pipeline == null)
            {
                return;

            }
            await _pipeline.Rate_SetAsync(tbSpeed.Value / 10.0);
        }

        private void tbVolume_Scroll()
        {
            if (_audioRenderer == null)
            {
                return;
            }

            _audioRenderer.Volume = tbVolume.Value / 100.0;
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
