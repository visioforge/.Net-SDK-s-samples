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
using VisioForge.Core.Types.X.Special;


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

        private SourceSwitchBlock _videoSwitch;

        private SourceSwitchBlock _audioSwitch;

        private MediaFileInfo _mediaInfo;

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

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                edLog.Text = edLog.Text + e.Message + Environment.NewLine;
            }));
        }

        /// <summary>
        /// Pipeline on stop.
        /// </summary>
        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                _timer.Stop();
                tbTimeline.Value = 0;
            }));
        }

        /// <summary>
        /// Create engine async.
        /// </summary>
        private async Task CreateEngineAsync()
        {
            // create the pipeline
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
            _pipeline.OnBusStreamCollection += Pipeline_OnBusStreamCollection;
            _pipeline.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;

            // read media information with deep discovery to get all streams
            _infoReader = new MediaInfoReaderX(_pipeline.GetContext());
            await _infoReader.OpenAsync(edFilename.Text);
            _mediaInfo = _infoReader.Info;

            // create the file source
            _fileSource = new BasicFileSourceBlock(edFilename.Text);

            bool videoFound = _mediaInfo.VideoStreams.Any();
            bool audioFound = _mediaInfo.AudioStreams.Any();
            int videoStreamCount = _mediaInfo.VideoStreams.Count;
            int audioStreamCount = _mediaInfo.AudioStreams.Count;

            // create MPEG-TS demux with MediaFileInfo for multiple stream support
            _demux = new MPEGTSDemuxBlock(_mediaInfo, renderVideo: videoFound, renderAudio: audioFound);
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

                if (videoStreamCount > 1)
                {
                    // create source switch for multiple video streams
                    var videoSwitchSettings = new SourceSwitchSettings { PadsCount = videoStreamCount };
                    _videoSwitch = new SourceSwitchBlock(videoSwitchSettings);

                    // connect all video outputs from demux to switch inputs
                    for (int i = 0; i < videoStreamCount && i < _demux.VideoOutputs.Count; i++)
                    {
                        _pipeline.Connect(_demux.VideoOutputs[i], _videoSwitch.Inputs[i]);
                    }

                    // connect switch output to video decoder
                    _pipeline.Connect(_videoSwitch.Output, _videoDecoder.Input);
                }
                else
                {
                    // single video stream - connect directly
                    _pipeline.Connect(_demux.VideoOutput, _videoDecoder.Input);
                }

                // connect video decoder to video renderer
                _pipeline.Connect(_videoDecoder.Output, _videoRenderer.Input);
            }

            if (audioFound)
            {
                // create audio decoder
                _audioDecoder = new DecodeBinBlock(renderVideo: false, renderAudio: true);

                // create audio renderer
                _audioRenderer = new AudioRendererBlock((await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).Where(device => device.DisplayName == cbAudioOutput.Text).First());

                if (audioStreamCount > 1)
                {
                    // create source switch for multiple audio streams
                    var audioSwitchSettings = new SourceSwitchSettings { PadsCount = audioStreamCount };
                    _audioSwitch = new SourceSwitchBlock(audioSwitchSettings);

                    // connect all audio outputs from demux to switch inputs
                    for (int i = 0; i < audioStreamCount && i < _demux.AudioOutputs.Count; i++)
                    {
                        _pipeline.Connect(_demux.AudioOutputs[i], _audioSwitch.Inputs[i]);
                    }

                    // connect switch output to audio decoder
                    _pipeline.Connect(_audioSwitch.Output, _audioDecoder.Input);
                }
                else
                {
                    // single audio stream - connect directly
                    _pipeline.Connect(_demux.AudioOutput, _audioDecoder.Input);
                }

                // connect audio decoder to audio renderer
                _pipeline.Connect(_audioDecoder.Output, _audioRenderer.Input);
            }
        }

        /// <summary>
        /// Pipeline on bus stream collection.
        /// </summary>
        private void Pipeline_OnBusStreamCollection(object sender, Tuple<VideoStreamInfo[], AudioStreamInfo[], SubtitleStreamInfo[]> e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                // Use MediaFileInfo for accurate stream information
                if (_mediaInfo != null)
                {
                    cbVideoStream.Items.Clear();
                    for (int i = 0; i < _mediaInfo.VideoStreams.Count; i++)
                    {
                        cbVideoStream.Items.Add($"Video stream {i + 1}");
                    }

                    if (cbVideoStream.Items.Count > 0)
                    {
                        cbVideoStream.Tag = true;
                        cbVideoStream.SelectedIndex = 0;
                        cbVideoStream.Tag = false;
                    }

                    cbAudioStream.Items.Clear();
                    for (int i = 0; i < _mediaInfo.AudioStreams.Count; i++)
                    {
                        cbAudioStream.Items.Add($"Audio stream {i + 1}");
                    }

                    if (cbAudioStream.Items.Count > 0)
                    {
                        cbAudioStream.Tag = true;
                        cbAudioStream.SelectedIndex = 0;
                        cbAudioStream.Tag = false;
                    }
                }
                else
                {
                    // Fallback to event data if MediaFileInfo is not available
                    var videoStreams = e.Item1;
                    cbVideoStream.Items.Clear();

                    for (int i = 0; i < videoStreams.Length; i++)
                    {
                        cbVideoStream.Items.Add($"Video stream {i + 1}");
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
                        cbAudioStream.Items.Add($"Audio stream {i + 1}");
                    }

                    if (cbAudioStream.Items.Count > 0)
                    {
                        cbAudioStream.Tag = true;
                        cbAudioStream.SelectedIndex = 0;
                        cbAudioStream.Tag = false;
                    }
                }
            }));
        }

        /// <summary>
        /// Timer elapsed.
        /// </summary>
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

        /// <summary>
        /// Stop engine async.
        /// </summary>
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

            // Clean up switches
            _videoSwitch?.Dispose();
            _videoSwitch = null;
            _audioSwitch?.Dispose();
            _audioSwitch = null;
            _mediaInfo = null;
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
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

            // Clean up switches
            _videoSwitch?.Dispose();
            _videoSwitch = null;
            _audioSwitch?.Dispose();
            _audioSwitch = null;
            _mediaInfo = null;
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
            if (!_timerFlag && _pipeline != null)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        /// <summary>
        /// Restart playback.
        /// </summary>
        private async Task RestartPlayback()
        {
            edLog.Clear();

            await StopEngineAsync();

            await CreateEngineAsync();

            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;

            await _pipeline.StartAsync();

            _timer.Start();
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
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

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            if (_pipeline != null)
            {
                await StopEngineAsync();
            }

            tbTimeline.Value = 0;
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.PauseAsync();
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.ResumeAsync();
        }

        /// <summary>
        /// Tb volume value changed.
        /// </summary>
        private void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_audioRenderer != null)
            {
                _audioRenderer.Volume = tbVolume.Value / 100.0;
            }
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();

            if (_pipeline != null)
            {
                DestroyEngine();
            }

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Cb program stream selection changed.
        /// </summary>
        private async void cbProgramStream_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbProgramStream.SelectedIndex == -1 || (bool)cbProgramStream.Tag)
            {
                return;
            }

            await RestartPlayback();
        }

        /// <summary>
        /// Cb video stream selection changed.
        /// </summary>
        private void cbVideoStream_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbVideoStream.SelectedIndex == -1 || (bool)cbVideoStream.Tag)
            {
                return;
            }

            // Switch to the selected video stream
            if (_videoSwitch != null && _pipeline != null)
            {
                _videoSwitch.Switch(cbVideoStream.SelectedIndex);
                edLog.Text = edLog.Text + $"Switched to video stream {cbVideoStream.SelectedIndex + 1}" + Environment.NewLine;
            }
        }

        /// <summary>
        /// Cb audio stream selection changed.
        /// </summary>
        private void cbAudioStream_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbAudioStream.SelectedIndex == -1 || (bool)cbAudioStream.Tag)
            {
                return;
            }

            // Switch to the selected audio stream
            if (_audioSwitch != null && _pipeline != null)
            {
                _audioSwitch.Switch(cbAudioStream.SelectedIndex);
                edLog.Text = edLog.Text + $"Switched to audio stream {cbAudioStream.SelectedIndex + 1}" + Environment.NewLine;
            }
        }
    }
}
