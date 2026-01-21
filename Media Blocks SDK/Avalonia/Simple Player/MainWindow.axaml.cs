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
using System.Threading.Tasks;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaInfoReaderX;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;

using System.Reactive.Linq;

namespace SimplePlayerAMB
{
    /// <summary>
    /// Interaction logic for MainWindow.axaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private VideoRendererBlock _videoRenderer;

        /// <summary>
        /// The audio renderer.
        /// </summary>
        private AudioRendererBlock _audioRenderer;

        /// <summary>
        /// The file source.
        /// </summary>
        private UniversalSourceBlock _fileSource;

        /// <summary>
        /// The position timer.
        /// </summary>
        private System.Timers.Timer _tmPosition;

#if WINDOWS
        private AudioOutputDeviceAPI _audioOutputDeviceAPI = AudioOutputDeviceAPI.DirectSound;
#else
    private AudioOutputDeviceAPI _audioOutputDeviceAPI = AudioOutputDeviceAPI.Default;
#endif

        /// <summary>
        /// The initialized flag.
        /// </summary>
        private bool _initialized;

        /// <summary>
        /// Gets or sets the log messages.
        /// </summary>
        public ObservableCollection<string> Log { get; set; } = new ObservableCollection<string>();

        /// <summary>
        /// Gets or sets the available audio output devices.
        /// </summary>
        public ObservableCollection<string> AudioOutputs { get; set; } = new ObservableCollection<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            VisioForgeX.InitSDK();

            Activated += MainWindow_Activated;
            Closing += MainWindow_Closing;

            DataContext = this;
        }

        /// <summary>
        /// Creates the media engine.
        /// </summary>
        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
        }

        /// <summary>
        /// Asynchronously destroys the media engine.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        /// <summary>
        /// Handles the Closing event of the MainWindow.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;

                _pipeline.Stop(true);
            }

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Loads the XAML component.
        /// </summary>
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <summary>
        /// Handles the Activated event of the MainWindow.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void MainWindow_Activated(object sender, EventArgs e)
        {
            if (_initialized)
            {
                return;
            }

            _initialized = true;

            InitControls();

            foreach (var device in await AudioRendererBlock.GetDevicesAsync(_audioOutputDeviceAPI))
            {
                AudioOutputs.Add(device.Name);
            }

            if (AudioOutputs.Count > 0)
            {
                cbAudioOutput.SelectedIndex = 0;
            }

            var audioInput = await DeviceEnumerator.Shared.AudioSourcesAsync(null);
            foreach (var device in audioInput)
            {
                Debug.WriteLine(device);
            }

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
        }

        /// <summary>
        /// The timeline applying value flag.
        /// </summary>
        private volatile bool _tbTimelineApplyingValue;

        /// <summary>
        /// The disposed value flag.
        /// </summary>
        private bool disposedValue;

        /// <summary>
        /// Initializes the UI controls.
        /// </summary>
        private void InitControls()
        {
            VideoView1 = this.FindControl<VisioForge.Core.UI.Avalonia.VideoView>("VideoView1");

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
            cbAudioOutput.ItemsSource = AudioOutputs;

            mmLog = this.FindControl<ListBox>("mmLog");
            mmLog.Items.Clear();
            mmLog.ItemsSource = Log;
        }

        /// <summary>
        /// Handles the Click event of the btSelectFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            string[] files = await ofd.ShowAsync(this);
            if (files != null && files.Length > 0)
            {
                edFilenameOrURL.Text = files[0];
            }
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

            _fileSource = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(edFilenameOrURL.Text, renderVideo: videoStream, renderAudio: audioStream));

            if (videoStream)
            {
                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);
                _pipeline.Connect(_fileSource.VideoOutput, _videoRenderer.Input);
            }

            if (audioStream)
            {
                var audioOutputDevice = AudioRendererBlock.GetDevicesAsync(_audioOutputDeviceAPI).Result[cbAudioOutput.SelectedIndex];
                _audioRenderer = new AudioRendererBlock(audioOutputDevice);
                _pipeline.Connect(_fileSource.AudioOutput, _audioRenderer.Input);
            }

            await _pipeline.StartAsync();

            _tmPosition.Start();
        }

        /// <summary>
        /// Asynchronously stops the media engine.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task StopAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;

                await _pipeline.StopAsync(true);
            }

            await DestroyEngineAsync();
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _tmPosition?.Stop();

            await StopAsync();

            tbTimeline.Value = 0;

            VideoView1?.InvalidateVisual();

            lbTimeline.Text = "00:00:00 / 00:00:00";
        }

        /// <summary>
        /// Handles the Click event of the btResume control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.ResumeAsync();
        }

        /// <summary>
        /// Handles the Click event of the btPause control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.PauseAsync();
        }

        /// <summary>
        /// Handles the Click event of the btNextFrame control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btNextFrame_Click(object sender, RoutedEventArgs e)
        {
            _pipeline.NextFrame();
        }

        /// <summary>
        /// Handles the OnError event of the Pipeline.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Log.Add(e.Message);
        }

        /// <summary>
        /// Handles the OnStop event of the Pipeline.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="StopEventArgs"/> instance containing the event data.</param>
        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            _tmPosition.Stop();

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                VideoView1.Refresh();
            });
        }

        /// <summary>
        /// Handles the Scroll event of the tbTimeline control.
        /// </summary>
        private async void tbTimeline_Scroll()
        {
            if (_tbTimelineApplyingValue && _pipeline != null)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        /// <summary>
        /// Handles the Elapsed event of the tmPosition timer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Scroll event of the tbSpeed control.
        /// </summary>
        private async void tbSpeed_Scroll()
        {
            if (_pipeline == null)
            {
                return;

            }
            await _pipeline.Rate_SetAsync(tbSpeed.Value / 10.0);
        }

        /// <summary>
        /// Handles the Scroll event of the tbVolume control.
        /// </summary>
        private void tbVolume_Scroll()
        {
            if (_audioRenderer == null)
            {
                return;
            }

            _audioRenderer.Volume = tbVolume.Value / 100.0;
        }

        /// <summary>
        /// Disposes of the resources used by the window.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
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

        /// <summary>
        /// Finalizes an instance of the <see cref="MainWindow"/> class.
        /// </summary>
        ~MainWindow()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        /// <summary>
        /// Disposes of the resources used by the window.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}