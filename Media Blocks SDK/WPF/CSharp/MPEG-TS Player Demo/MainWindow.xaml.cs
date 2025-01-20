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
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaInfo;
using VisioForge.Core.MediaInfoReaderX;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.MediaInfo;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;


namespace MPEG_TS_Player_Demo
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

        private BasicFileSourceBlock _fileSource;

        private DecodeBinBlock _videoDecoder;

        private DecodeBinBlock _audioDecoder;

        private MPEGTSDemuxBlock _demux;

        private MediaInfoReaderX _infoReader;

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
            // create the pipeline
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
            _pipeline.OnBusStreamCollection += Pipeline_OnBusStreamCollection;
            _pipeline.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;

            // read media information
            _infoReader = new MediaInfoReaderX(_pipeline.GetContext());
            await _infoReader.OpenAsync(edFilename.Text);

            // create the file source
            _fileSource = new BasicFileSourceBlock(edFilename.Text);

            bool videoFound = _infoReader.Info.VideoStreams.Any();
            bool audioFound = _infoReader.Info.AudioStreams.Any();

            // create MPEG-TS demux
            _demux = new MPEGTSDemuxBlock(renderVideo: videoFound, renderAudio: audioFound);
            if (cbProgramStream.SelectedIndex != -1)
            {
                _demux.Settings.ProgramNumber = Convert.ToInt32(cbProgramStream.Text);
            }

            // connect file source to demux
            _pipeline.Connect(_fileSource.Output, _demux.Input);

            if (videoFound)
            {
                // create video decoder
                _videoDecoder = new DecodeBinBlock(renderVideo: true, renderAudio: false);

                // create video renderer
                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

                // connect demux to video decoder
                _pipeline.Connect(_demux.VideoOutput, _videoDecoder.Input);

                // connect video decoder to video renderer
                _pipeline.Connect(_videoDecoder.Output, _videoRenderer.Input);
            }

            if (audioFound)
            {
                // create audio decoder
                _audioDecoder = new DecodeBinBlock(renderVideo: false, renderAudio: true);

                // create audio renderer
                _audioRenderer = new AudioRendererBlock((await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).Where(device => device.DisplayName == cbAudioOutput.Text).First());

                // connect demux to audio decoder
                _pipeline.Connect(_demux.AudioOutput, _audioDecoder.Input);

                // connect audio decoder to audio renderer
                _pipeline.Connect(_audioDecoder.Output, _audioRenderer.Input);
            }
        }

        private void Pipeline_OnBusStreamCollection(object sender, Tuple<VideoStreamInfo[], AudioStreamInfo[], SubtitleStreamInfo[]> e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                var videoStreams = e.Item1;
                cbVideoStream.Items.Clear();

                for (int i = 0; i < videoStreams.Length; i++)
                {
                    cbVideoStream.Items.Add($"Video stream {i}");
                }

                if (cbVideoStream.Items.Count > 0)
                {
                    cbVideoStream.Tag = true;
                    cbVideoStream.SelectedIndex = 0;
                    cbVideoStream.Tag = false;
                }

                var audioStreams = e.Item2;
                cbAudioStream.Items.Clear();

                for (int i = 0; i < audioStreams.Length; i++)
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

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timerFlag = true;

            var position = await _pipeline.Position_GetAsync();
            var duration = await _pipeline.DurationAsync();

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
            if (!_timerFlag && _pipeline != null)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async Task RestartPlayback()
        {
            edLog.Clear();

            await StopEngineAsync();

            await CreateEngineAsync();

            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;

            await _pipeline.StartAsync();

            _timer.Start();
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
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            if (_pipeline != null)
            {
                await StopEngineAsync();
            }

            tbTimeline.Value = 0;
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.PauseAsync();
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.ResumeAsync();
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
            _timer.Stop();

            if (_pipeline != null)
            {
                DestroyEngine();
            }

            VisioForgeX.DestroySDK();
        }

        private async void cbProgramStream_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbProgramStream.SelectedIndex == -1 || (bool)cbProgramStream.Tag)
            {
                return;
            }

            await RestartPlayback();
        }

        private void cbVideoStream_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void cbAudioStream_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
