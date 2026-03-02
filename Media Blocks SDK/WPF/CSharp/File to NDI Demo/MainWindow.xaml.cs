using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioProcessing;
using VisioForge.Core.MediaBlocks.Bridge;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaInfoReaderX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.AudioEffects;
using VisioForge.Core.Types.X.Bridge;
using VisioForge.Core.Types.X.Sources;

namespace File_to_NDI_Demo
{
    public partial class MainWindow : Window
    {
        private const string VIDEO_BRIDGE_ID = "ndi_video";

        private const string AUDIO_BRIDGE_ID = "ndi_audio";

        private System.Timers.Timer _timer;

        private volatile bool _timerFlag;

        // Source pipeline (file playback + seeking)
        private MediaBlocksPipeline _pipelineSource;

        // NDI output pipeline (never sees seeks)
        private MediaBlocksPipeline _pipelineNDI;

        // Source pipeline blocks
        private UniversalSourceBlock _fileSource;

        private BridgeVideoSinkBlock _videoBridgeSink;

        private BridgeAudioSinkBlock _audioBridgeSink;

        // NDI pipeline blocks
        private BridgeVideoSourceBlock _videoBridgeSource;

        private BridgeAudioSourceBlock _audioBridgeSource;

        private NDISinkBlock _ndiSink;

        private AudioResamplerBlock _audioResampler;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                edLog.Text = edLog.Text + e.Message + Environment.NewLine;
            });
        }

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                _timer?.Stop();
                tbTimeline.Value = 0;
            });
        }

        private async Task CreateEngineAsync()
        {
            // Create source pipeline first to use its context for media probing
            _pipelineSource = new MediaBlocksPipeline(name: "SOURCE");
            _pipelineSource.OnError += Pipeline_OnError;
            _pipelineSource.OnStop += Pipeline_OnStop;
            _pipelineSource.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            // Probe file for available streams
            var mediaInfo = new MediaInfoReaderX(_pipelineSource.GetContext());
            bool hasVideo = true;
            bool hasAudio = true;
            VideoFrameInfoX videoInfo = null;
            AudioInfoX audioInfo = null;

            if (await mediaInfo.OpenAsync(new Uri(edFilename.Text)))
            {
                hasVideo = mediaInfo.Info.VideoStreams.Count > 0;
                hasAudio = mediaInfo.Info.AudioStreams.Count > 0;

                if (hasVideo)
                {
                    var vs = mediaInfo.Info.VideoStreams[0];
                    videoInfo = new VideoFrameInfoX(vs.Width, vs.Height, vs.FrameRate);
                }

                if (hasAudio)
                {
                    var aus = mediaInfo.Info.AudioStreams[0];
                    audioInfo = new AudioInfoX(AudioFormatX.S16LE, aus.SampleRate, aus.Channels);
                }
            }

            // Use defaults if probing didn't return info
            if (hasVideo && videoInfo == null)
            {
                videoInfo = new VideoFrameInfoX(1920, 1080, new VideoFrameRate(30));
            }

            if (hasAudio && audioInfo == null)
            {
                audioInfo = new AudioInfoX(AudioFormatX.S16LE, 48000, 2);
            }

            // --- Source pipeline: file → bridge sinks ---
            _fileSource = new UniversalSourceBlock(
                await UniversalSourceSettings.CreateAsync(
                    new Uri(edFilename.Text),
                    renderVideo: hasVideo,
                    renderAudio: hasAudio));

            if (hasVideo)
            {
                _videoBridgeSink = new BridgeVideoSinkBlock(new BridgeVideoSinkSettings(VIDEO_BRIDGE_ID, videoInfo));
                _pipelineSource.Connect(_fileSource.VideoOutput, _videoBridgeSink.Input);
            }

            if (hasAudio)
            {
                _audioBridgeSink = new BridgeAudioSinkBlock(new BridgeAudioSinkSettings(AUDIO_BRIDGE_ID, audioInfo));
                _pipelineSource.Connect(_fileSource.AudioOutput, _audioBridgeSink.Input);
            }

            _pipelineSource.Loop = cbLoop.IsChecked == true;

            // --- NDI pipeline: bridge sources → NDI sink ---
            _pipelineNDI = new MediaBlocksPipeline(name: "NDI_OUTPUT");
            _pipelineNDI.OnError += Pipeline_OnError;

            _ndiSink = new NDISinkBlock(edNDIName.Text);

            if (hasVideo)
            {
                var videoSourceSettings = new BridgeVideoSourceSettings(VIDEO_BRIDGE_ID, videoInfo)
                {
                    DoTimestamp = true
                };
                _videoBridgeSource = new BridgeVideoSourceBlock(videoSourceSettings);

                _pipelineNDI.Connect(
                    _videoBridgeSource.Output,
                    _ndiSink.CreateNewInput(MediaBlockPadMediaType.Video));
            }

            if (hasAudio)
            {
                var audioSourceSettings = new BridgeAudioSourceSettings(AUDIO_BRIDGE_ID, audioInfo)
                {
                    DoTimestamp = true
                };
                _audioBridgeSource = new BridgeAudioSourceBlock(audioSourceSettings);

                _audioResampler = new AudioResamplerBlock(
                    new AudioResamplerSettings(AudioFormatX.F32LE, 48000, 2));

                _pipelineNDI.Connect(_audioBridgeSource.Output, _audioResampler.Input);
                _pipelineNDI.Connect(
                    _audioResampler.Output,
                    _ndiSink.CreateNewInput(MediaBlockPadMediaType.Audio));
            }

            // Display the NDI URL
            edNDIURL.Text = $"ndi://{System.Net.Dns.GetHostName()}/{edNDIName.Text}";
        }

        private async Task StopEngineAsync()
        {
            // Stop source pipeline first
            if (_pipelineSource != null)
            {
                _pipelineSource.OnError -= Pipeline_OnError;
                _pipelineSource.OnStop -= Pipeline_OnStop;
                await _pipelineSource.StopAsync(true);
                await _pipelineSource.DisposeAsync();
                _pipelineSource = null;
            }

            // Then stop NDI pipeline
            if (_pipelineNDI != null)
            {
                _pipelineNDI.OnError -= Pipeline_OnError;
                await _pipelineNDI.StopAsync(true);
                await _pipelineNDI.DisposeAsync();
                _pipelineNDI = null;
            }
        }

        private void DestroyEngine()
        {
            if (_pipelineSource != null)
            {
                _pipelineSource.OnError -= Pipeline_OnError;
                _pipelineSource.OnStop -= Pipeline_OnStop;
                _pipelineSource.Stop(true);
                _pipelineSource.Dispose();
                _pipelineSource = null;
            }

            if (_pipelineNDI != null)
            {
                _pipelineNDI.OnError -= Pipeline_OnError;
                _pipelineNDI.Stop(true);
                _pipelineNDI.Dispose();
                _pipelineNDI = null;
            }
        }

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                _timerFlag = true;

                var position = await _pipelineSource.Position_GetAsync();
                var duration = await _pipelineSource.DurationAsync();

                Dispatcher.Invoke(() =>
                {
                    tbTimeline.Maximum = (int)duration.TotalSeconds;

                    lbTime.Text = position.ToString("hh\\:mm\\:ss") + " | " + duration.ToString("hh\\:mm\\:ss");

                    if (tbTimeline.Maximum >= position.TotalSeconds)
                    {
                        tbTimeline.Value = (int)position.TotalSeconds;
                    }
                });

                _timerFlag = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
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

                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Media files|*.mp4;*.mkv;*.avi;*.mov;*.wmv;*.flv;*.webm;*.ts;*.mp3;*.aac;*.wav;*.flac|All files|*.*"
            };

            if (dialog.ShowDialog() == true)
            {
                edFilename.Text = dialog.FileName;
            }
        }

        private async void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (!_timerFlag && _pipelineSource != null)
                {
                    await _pipelineSource.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
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

                _pipelineSource.Debug_Mode = cbDebugMode.IsChecked == true;
                _pipelineNDI.Debug_Mode = cbDebugMode.IsChecked == true;

                // Start source pipeline first (creates interaudiosink/intervideosink on channels)
                await _pipelineSource.StartAsync();

                // Brief delay to let bridge sinks initialize and accept first buffers
                await Task.Delay(100);

                // Then start NDI pipeline (interaudiosrc can now find existing surface with data)
                await _pipelineNDI.StartAsync();

                _timer.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _timer?.Stop();

                await StopEngineAsync();

                tbTimeline.Value = 0;
                edNDIURL.Text = "";
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
                await _pipelineSource.PauseAsync();
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
                await _pipelineSource.ResumeAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btCopyNDIURL_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(edNDIURL.Text))
            {
                Clipboard.SetText(edNDIURL.Text);
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
