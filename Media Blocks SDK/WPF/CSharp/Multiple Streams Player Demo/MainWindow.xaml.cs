using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaInfoReaderX;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Libs.DirectShowLib;
using static System.Net.Mime.MediaTypeNames;

namespace MediaBlocks_Multiple_Streams_Player_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Timers.Timer _timer;

        private volatile bool _timerFlag;

        private MediaBlocksPipeline _pipeline;

        private List<MediaBlock> _videoRenderers = new List<MediaBlock>();

        private List<MediaBlock> _audioRenderers = new List<MediaBlock>();

        private DemuxerSourceBlock _fileSource;

        private DeviceEnumerator _deviceEnumerator;

        private MediaInfoReaderX _mediaInfo;

        public MainWindow()
        {
            InitializeComponent();

            // We have to initialize the engine on start
            MediaBlocksPipeline.InitSDK();

            _deviceEnumerator = new DeviceEnumerator();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MediaBlocksPipeline.InitSDK();

            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            var audioOutputDevices = (await AudioRendererBlock.GetDevicesAsync(_deviceEnumerator, AudioOutputDeviceAPI.DirectSound)).ToArray();
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
            _pipeline = new MediaBlocksPipeline(false);
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
            _pipeline.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            _fileSource = new DemuxerSourceBlock(await DemuxerSourceSettings.CreateAsync(edFilename.Text, true, true, false));

            _mediaInfo = new MediaInfoReaderX(_pipeline.GetContext());
            if (! await _mediaInfo.OpenAsync(edFilename.Text))
            {
                MessageBox.Show("Unable to read file info.");
                return;
            }

            // video streams
            for (int i = 0; i < _mediaInfo.Info.VideoStreams.Count; i++)
            {
                MediaBlock videoRenderer = null;

                switch (i)
                {
                    case 0:
                        videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);                        
                        break;
                    case 1:
                        videoRenderer = new NullRendererBlock();// VideoRendererBlock(_pipeline, VideoView2);
                        break;
                    case 2:
                        videoRenderer = new NullRendererBlock();// new VideoRendererBlock(_pipeline, VideoView3);
                        break;
                    case 3:
                        videoRenderer = new NullRendererBlock();// new VideoRendererBlock(_pipeline, VideoView4);
                        break;
                    default:
                        break;
                }

                if (videoRenderer == null)
                {
                    break;
                }

                _pipeline.Connect(_fileSource.GetFreeOutputPadByType(MediaBlockPadMediaType.Video), videoRenderer.Input);

                _videoRenderers.Add(videoRenderer);
            }

            // audio streams
            for (int i = 0; i < _mediaInfo.Info.AudioStreams.Count; i++)
            {
                MediaBlock audioRenderer = null;

                switch (i)
                {
                    case 0:
                        audioRenderer = new NullRendererBlock();// new VideoRendererBlock(_pipeline, VideoView1);
                        break;
                    case 1:
                        audioRenderer = new NullRendererBlock();// VideoRendererBlock(_pipeline, VideoView2);
                        break;
                    case 2:
                        audioRenderer = new NullRendererBlock();// new VideoRendererBlock(_pipeline, VideoView3);
                        break;
                    case 3:
                        audioRenderer = new NullRendererBlock();// new VideoRendererBlock(_pipeline, VideoView4);
                        break;
                    default:
                        break;
                }

                if (audioRenderer == null)
                {
                    break;
                }

                _pipeline.Connect(_fileSource.GetFreeOutputPadByType(MediaBlockPadMediaType.Audio), audioRenderer.Input);

                _audioRenderers.Add(audioRenderer);
            }

            // _audioRenderer = new AudioRendererBlock((await _deviceEnumerator.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).Where(device => device.DisplayName == cbAudioOutput.Text).First());
            // _pipeline.Connect(_fileSource.AudioOutput, _audioRenderer.Input);
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

        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;
                await _pipeline.DisposeAsync();
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
            if (!_timerFlag)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            edLog.Clear();

            await CreateEngineAsync();

            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;

            await _pipeline.StartAsync();

            _timer.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            if (_pipeline != null)
            {
                _pipeline.Debug_SavePipeline("before-stop");

                await _pipeline.StopAsync();
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
            //if (_audioRenderer != null)
            //{
            //    _audioRenderer.Volume = tbVolume.Value / 100.0;
            //}
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();

            await DestroyEngineAsync();     
            
            _deviceEnumerator.Dispose();
        }
    }
}
