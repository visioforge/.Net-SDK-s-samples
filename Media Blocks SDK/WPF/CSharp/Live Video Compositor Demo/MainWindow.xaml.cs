using System;
using System.Linq;
using System.Windows;

using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types;
using VisioForge.Core.UI.WPF.Dialogs.Sources;

using Rect = VisioForge.Core.Types.Rect;
using VisioForge.Core.LiveVideoCompositor;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.VideoEncoders;
using System.IO;
using System.Windows.Controls;
using System.Threading.Tasks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core;
using Microsoft.Win32;
using VisioForge.Core.MediaBlocks.Decklink;
using VisioForge.Core.UI.WPF.Dialogs.Decklink;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X;
using VisioForge.Core.Helpers;
using VisioForge.Core.MediaBlocks.Bridge;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.MediaBlocks.Special;
using System.Diagnostics;

namespace Live_Video_Compositor_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LiveVideoCompositor _compositor;

        private LVCVideoViewOutput _videoRendererOutput;

        private LVCAudioOutput _audioRendererOutput;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();

            // We have to initialize the engine on start
            VisioForgeX.InitSDK();
        }
                
        private void Compositor_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private void CreateEngine()
        {
            _compositor = new LiveVideoCompositor(new LiveVideoCompositorSettings(1920, 1080, VideoFrameRate.FPS_25));
            _compositor.OnError += Compositor_OnError;
        }

        private void DestroyEngine()
        {
            if (_compositor != null)
            {
                _compositor.OnError -= Compositor_OnError;

                _compositor.Dispose();
                _compositor = null;
            }
        }

        private async Task AddCameraSourceAsync()
        {
            var dlg = new VideoCaptureSourceDialog();
            if (dlg.ShowDialog() == true)
            {
                VideoCaptureDeviceSourceSettings settings = null;

                var deviceName = dlg.Device;
                var format = dlg.Format;
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                    if (device != null)
                    {
                        var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                        if (formatItem != null)
                        {
                            settings = new VideoCaptureDeviceSourceSettings(device)
                            {
                                Format = formatItem.ToFormat()
                            };

                            settings.Format.FrameRate = dlg.FrameRate;
                        }
                    }
                }

                if (settings == null)
                {
                    MessageBox.Show(this, "Unable to configure video capture device.");
                    return;
                }

                var name = $"Camera [{dlg.Device}]";
                var rect = new Rect(Convert.ToInt32(edRectLeft.Text), Convert.ToInt32(edRectTop.Text), Convert.ToInt32(edRectRight.Text), Convert.ToInt32(edRectBottom.Text));
                var videoInfo = new VideoFrameInfoX(settings.Format.Width, settings.Format.Height, settings.Format.FrameRate);
                var src = new LVCVideoInput(name, _compositor, new SystemVideoSourceBlock(settings), videoInfo, rect, true);

                if (await _compositor.Input_AddAsync(src))
                {
                    lbSources.Items.Add(name);
                    lbSources.SelectedIndex = lbSources.Items.Count - 1;
                }
                else
                {
                    src.Dispose();
                }
            }
        }

        private async Task AddFileSourceAsync()
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                //var filename = @"c:\Samples\XXX\!videoonly.mp4";
                // var filename = @"c:\Samples\!video.mp4";
                var filename = dlg.FileName;
                var name = $"File [{filename}]";
                var rect = new Rect(Convert.ToInt32(edRectLeft.Text), Convert.ToInt32(edRectTop.Text),
                    Convert.ToInt32(edRectRight.Text), Convert.ToInt32(edRectBottom.Text));
                var settings = await UniversalSourceSettings.CreateAsync(filename);
                var info = settings.GetInfo();

                VideoFrameInfoX videoInfo = null;
                if (info.VideoStreams.Count > 0)
                {
                    videoInfo = new VideoFrameInfoX(info.VideoStreams[0].Width, info.VideoStreams[0].Height, info.VideoStreams[0].FrameRate);
                }

                AudioInfoX audioInfo = null;
                if (info.AudioStreams.Count > 0)
                {
                    audioInfo = new AudioInfoX(AudioFormatX.S16LE, info.AudioStreams[0].SampleRate, info.AudioStreams[0].Channels);
                }

                var src = new LVCVideoAudioInput(name, _compositor, new UniversalSourceBlock(settings), videoInfo, audioInfo, rect, autostart: true, live: false);

                if (await _compositor.Input_AddAsync(src))
                {
                    lbSources.Items.Add(name);
                    lbSources.SelectedIndex = lbSources.Items.Count - 1;
                }
                else
                {
                    src.Dispose();
                }
            }
        }

        private async Task AddScreenSourceAsync()
        {
            var dlg = new ScreenSourceDialog();
            if (dlg.ShowDialog() == true)
            {
                var settings = new ScreenCaptureDX9SourceSettings();
                settings.CaptureCursor = dlg.GrabMouseCursor;
                settings.Monitor = dlg.DisplayIndex;
                settings.FrameRate = dlg.FrameRate;
                settings.Rectangle = dlg.Rectangle;

                var rect = new Rect(Convert.ToInt32(edRectLeft.Text), Convert.ToInt32(edRectTop.Text), Convert.ToInt32(edRectRight.Text), Convert.ToInt32(edRectBottom.Text));
                var name = $"Screen [{dlg.DisplayIndex}] {dlg.Rectangle.Width}x{dlg.Rectangle.Height}";
                var info = new VideoFrameInfoX(dlg.Rectangle.Width, dlg.Rectangle.Height, dlg.FrameRate);
                var src = new LVCVideoInput(name, _compositor, new ScreenSourceBlock(settings), info, rect, true);

                if (await _compositor.Input_AddAsync(src))
                {
                    lbSources.Items.Add(name);
                    lbSources.SelectedIndex = lbSources.Items.Count - 1;
                }
                else
                { 
                    src.Dispose(); 
                }
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

            DeviceEnumerator.Shared.OnAudioSinkAdded += Shared_OnAudioSinkAdded;
            await DeviceEnumerator.Shared.StartAudioSinkMonitorAsync();
        }

        private void Shared_OnAudioSinkAdded(object sender, AudioOutputDeviceInfo e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                if (e.API == AudioOutputDeviceAPI.DirectSound)
                {
                    cbAudioRenderer.Items.Add(e.Name);
                }

                cbAudioRenderer.SelectedIndex = 0;
            }));
        }

        private async void UpdateRecordingTime()
        {
            var ts = await _compositor.DurationAsync();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            Dispatcher.BeginInvoke((Action)(() =>
            {
                lbTimestamp.Content = ts.ToString(@"hh\:mm\:ss");
            }));
        }

        private async Task AddVideoRendererAsync()
        {
            var name = "[VideoView] Preview";
            _videoRendererOutput = new LVCVideoViewOutput(name, _compositor, VideoView1, true);
            await _compositor.Output_AddAsync(_videoRendererOutput);
        }

        private async Task AddAudioRendererAsync()
        {
            var audioRenderer = new AudioRendererBlock((await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).First(x => x.Name == cbAudioRenderer.Text)); // <- TODO replace with a dialog 
            _audioRendererOutput = new LVCAudioOutput("Audio renderer", _compositor, audioRenderer, true);
            await _compositor.Output_AddAsync(_audioRendererOutput, true);
        }


        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            //string test_stream_mixer_input = "test_stream_mixer_input";
            //string test_stream_mixer_output = "test_stream_mixer_output";

            //var sourcePipeline = new MediaBlocksPipeline(live: true, name: "Source");

            //Gst.Debug.SetDefaultThreshold(Gst.DebugLevel.Debug);
            ////Gst.Debug.AddLogFunction((category, level, file, function, line, _object, message) =>
            ////{
            ////    Debug.WriteLine($"Gst: {level} {message}");
            ////});

            //var videoSource = new VirtualVideoSourceBlock(new VirtualVideoSourceSettings());
            //var videoInfo = new VideoFrameInfoX(videoSource.Settings.Width, videoSource.Settings.Height, videoSource.Settings.Format, videoSource.Settings.FrameRate);

            //var sourceBridgeSink = new BridgeVideoSinkBlock(new VisioForge.Core.Types.X.Bridge.BridgeVideoSinkSettings(test_stream_mixer_input, videoInfo));
            //sourcePipeline.Connect(videoSource.Output, sourceBridgeSink.Input);

            //var mainPipeline = new MediaBlocksPipeline(live: true, name: "Main");
            //var mixerBridgeSource = new BridgeVideoSourceBlock(new VisioForge.Core.Types.X.Bridge.BridgeVideoSourceSettings(test_stream_mixer_input, videoInfo));

            //var mixerSettings = new VideoMixerSettings(1920, 1080, VideoFrameRate.FPS_30);
            //mixerSettings.AddStream(new VideoMixerStream(new Rect(0, 0, 640, 480), 0));
            //var videoMixer = new VideoMixerBlock(mixerSettings);
            ////var mixerBridgeSink = new InterPipeSinkBlock(test_stream_mixer_output);

            ////var videoMixer = new CustomMediaBlock(new VisioForge.Core.Types.X.Special.CustomMediaBlockSettings("videomixer"));
            ////videoMixer.OnElementAdded += (sender, args) =>
            ////{
            ////    var pad = videoMixer.GetElement().GetRequestPad("sink_%u");
            ////    videoMixer.Inputs[0].SetInternalPad(pad);
            ////};           

            //var videoConvert = new VideoConverterBlock();
            //mainPipeline.Connect(mixerBridgeSource.Output, videoConvert.Input);
            //mainPipeline.Connect(videoConvert.Output, videoMixer.Inputs[0]);

            ////var nullRenderer = new NullRendererBlock();
            ////mainPipeline.Connect(videoMixer.Output, nullRenderer.Input);

            //var videoRenderer = new VideoRendererBlock(mainPipeline, VideoView1);
            //mainPipeline.Connect(videoMixer.Output, videoRenderer.Input);
            ////  mainPipeline.Connect(videoMixer.Output, mixerBridgeSink.Input);

            ////var renderPipeline = new MediaBlocksPipeline();
            ////var bridgeSource = new InterPipeSourceBlock(test_stream_mixer_output);
            ////var videoRenderer = new VideoRendererBlock(renderPipeline, VideoView1);
            ////renderPipeline.Connect(bridgeSource, videoRenderer);

            //await sourcePipeline.StartAsync();

            //mainPipeline.Debug_Dir = @"c:\vf\";
            //mainPipeline.Debug_Mode = true;

            //await mainPipeline.StartAsync();
            //await renderPipeline.StartAsync();

            // add video renderer
            await AddVideoRendererAsync();

            // add audio renderer
            await AddAudioRendererAsync();

            //await AddVideoVirtualAsync();

            await _compositor.StartAsync();

            //_pipeline.SavePipeline("compositor");

            tmRecording.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await _compositor.StopAsync();
            
            DestroyEngine();
            CreateEngine();

            lbOutputs.Items.Clear();
            lbSources.Items.Clear();
        }

        private void btUpdateRect_Click(object sender, RoutedEventArgs e)
        {
            int index = lbSources.SelectedIndex;
            if (index != -1)
            {
                var rect = new Rect(
                    Convert.ToInt32(edRectLeft.Text),
                    Convert.ToInt32(edRectTop.Text),
                    Convert.ToInt32(edRectRight.Text),
                    Convert.ToInt32(edRectBottom.Text));

                var stream = _compositor.Input_VideoStream_Get(index);
                stream.Rectangle = rect;
                _compositor.Input_VideoStream_Update(index, stream);
            }
        }

        private async Task AddMP4OutputAsync()
        {
            var now = DateTime.Now;
            var name = $"output_{now.Year}_{now.Month}_{now.Day}_{now.Hour}_{now.Minute}_{now.Second}.mp4";
            var outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), name);
            var mp4Output = new MP4OutputBlock(new MP4SinkSettings(outputFile), new OpenH264EncoderSettings(), new MFAACEncoderSettings());

            //var videoResizeBlock = new VideoResizeBlock(new ResizeVideoEffect(640, 480));

            var output = new LVCVideoAudioOutput(outputFile, _compositor, mp4Output, false); //, processingVideoBlock: videoResizeBlock);

            if (await _compositor.Output_AddAsync(output))
            {
                lbOutputs.Items.Add(outputFile);
                lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
            }
            else
            {
                output.Dispose();
            }
        }

        private async Task AddDecklinkVideoOutputAsync()
        {
            // Decklink video output
            var dlg = new DecklinkVideoOutputDialog();
            if (dlg.ShowDialog() == true)
            {
                var rect = new Rect(
                   Convert.ToInt32(edRectLeft.Text),
                   Convert.ToInt32(edRectTop.Text),
                   Convert.ToInt32(edRectRight.Text),
                   Convert.ToInt32(edRectBottom.Text));

               DecklinkVideoAudioSinkBlock _decklinkOutputBlock;

                var videoSettings = await dlg.GetVideoDeviceSettingsAsync();
                var audioSettings = await dlg.GetAudioDeviceSettingsAsync();
                var name = $"Decklink output [V{dlg.VideoDevice}:A{dlg.AudioDevice}]";

                _decklinkOutputBlock = new DecklinkVideoAudioSinkBlock(videoSettings, audioSettings);

                var decklinkOutput = new LVCVideoAudioOutput(name, _compositor, _decklinkOutputBlock, false);
                
                if (await _compositor.Output_AddAsync(decklinkOutput))
                {
                    lbOutputs.Items.Add(name);
                    lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
                }
                else
                {
                    decklinkOutput.Dispose();
                }
            }
        }

        private async Task AddWebMOutputAsync()
        {
            var now = DateTime.Now;
            var name = $"output_{now.Year}_{now.Month}_{now.Day}_{now.Hour}_{now.Minute}_{now.Second}.webm";
            var outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), name);
            var webmOutput = new WebMOutputBlock(new WebMSinkSettings(outputFile), new VP8EncoderSettings(), new VorbisEncoderSettings());
            var output = new LVCVideoAudioOutput(outputFile, _compositor, webmOutput, false);

            if (await _compositor.Output_AddAsync(output))
            {
                lbOutputs.Items.Add(outputFile);
                lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
            }
            else
            {
                output.Dispose();
            }
        }

        private async Task AddMP3OutputAsync()
        {
            var now = DateTime.Now;
            var name = $"output_{now.Year}_{now.Month}_{now.Day}_{now.Hour}_{now.Minute}_{now.Second}.mp3";
            var outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), name);
            var mp3Output = new MP3OutputBlock(outputFile, new MP3EncoderSettings());
            var output = new LVCAudioOutput(outputFile, _compositor, mp3Output, false);

            if (await _compositor.Output_AddAsync(output))
            {
                lbOutputs.Items.Add(outputFile);
                lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
            }
            else
            {
                output.Dispose();
            }
        }

        private async Task AddAudioSourceAsync()
        {
            var dlg = new AudioCaptureSourceDialog();
            if (dlg.ShowDialog() == true)
            {
                DSAudioCaptureDeviceSourceSettings settings = null;
                AudioCaptureDeviceFormat deviceFormat = null;

                var deviceName = dlg.Device;
                var format = dlg.Format;
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = (await DeviceEnumerator.Shared.AudioSourcesAsync(AudioCaptureDeviceAPI.DirectSound)).FirstOrDefault(x => x.DisplayName == deviceName);
                    if (device != null)
                    {
                        var formatItem = device.Formats.FirstOrDefault(x => x.Name == format);
                        if (formatItem != null)
                        {
                            deviceFormat = formatItem.ToFormat();
                            settings = new DSAudioCaptureDeviceSourceSettings(device, deviceFormat);
                        }
                    }
                }

                if (settings == null)
                {
                    MessageBox.Show(this, "Unable to configure audio capture device.");
                    return;
                }

                var name = $"Audio source [{dlg.Device}]";
                var info = new AudioInfoX(deviceFormat.Format, deviceFormat.SampleRate, deviceFormat.Channels);
                var src = new LVCAudioInput(name, _compositor, new SystemAudioSourceBlock(settings), info, true);
                if (await _compositor.Input_AddAsync(src))
                {
                    lbSources.Items.Add(name);
                    lbSources.SelectedIndex = lbSources.Items.Count - 1;
                }
                else
                {
                    src.Dispose();
                }
            }
        }

        private async Task AddAudioVirtualAsync()
        {
            var name = "Audio source [Virtual]";
            var settings = new VirtualAudioSourceSettings();
            var info = new AudioInfoX(settings.Format, settings.SampleRate, settings.Channels);
            var src = new LVCAudioInput(name, _compositor, new VirtualAudioSourceBlock(settings), info, true);            
            if (await _compositor.Input_AddAsync(src))
            {
                lbSources.Items.Add(name);
                lbSources.SelectedIndex = lbSources.Items.Count - 1;
            }
            else
            {
                src.Dispose();
            }
        }

        private async Task AddVideoVirtualAsync()
        {
            var rect = new Rect(
                   Convert.ToInt32(edRectLeft.Text),
                   Convert.ToInt32(edRectTop.Text),
                   Convert.ToInt32(edRectRight.Text),
                   Convert.ToInt32(edRectBottom.Text));

            var name = "Video source [Virtual]";
            var settings = new VirtualVideoSourceSettings();
            var info = new VideoFrameInfoX(settings.Width, settings.Height, settings.FrameRate);
            var src = new LVCVideoInput(name, _compositor, new VirtualVideoSourceBlock(settings), info, rect, true);
            if (await _compositor.Input_AddAsync(src))
            {
                lbSources.Items.Add(name);
                lbSources.SelectedIndex = lbSources.Items.Count - 1;
            }
            else
            {
                src.Dispose();
            }
        }

        private async Task AddDecklinkVideoSourceAsync()
        {
            // Decklink video source
            var dlg = new DecklinkVideoSourceDialog();
            if (dlg.ShowDialog() == true)
            {               
                var rect = new Rect(
                   Convert.ToInt32(edRectLeft.Text),
                   Convert.ToInt32(edRectTop.Text),
                   Convert.ToInt32(edRectRight.Text),
                   Convert.ToInt32(edRectBottom.Text));

                var videoSettings = await dlg.GetVideoDeviceSettingsAsync();
                var audioSettings = await dlg.GetAudioDeviceSettingsAsync();
                var name = $"Decklink source [{videoSettings.DeviceNumber}]";

                var sourceBlock = new DecklinkVideoAudioSourceBlock(videoSettings, audioSettings);

                DecklinkHelper.GetVideoInfoFromMode(videoSettings.Mode, out int width, out int height, out VideoFrameRate frameRate);
                var videoInfo = new VideoFrameInfoX(width, height, frameRate);
                var audioInfo = new AudioInfoX(DecklinkHelper.ToFormat(audioSettings.Format), audioSettings.SampleRate, (int)audioSettings.Channels);
                var videoSrc = new LVCVideoAudioInput(name, _compositor, sourceBlock, videoInfo, audioInfo, rect, true);
                if (await _compositor.Input_AddAsync(videoSrc))
                {
                    lbSources.Items.Add(name);
                    lbSources.SelectedIndex = lbSources.Items.Count - 1;
                }
                else
                {
                    videoSrc.Dispose();
                }
            }
        }

        private void btAddSource_Click(object sender, RoutedEventArgs e)
        {
            var ctx = new ContextMenu();

            var miScreen = new MenuItem() { Header = "Screen source" };
            miScreen.Click += async (senderm, args) =>
            {
                await AddScreenSourceAsync();
            };

            var miCamera = new MenuItem() { Header = "Camera source" };
            miCamera.Click += async (senderm, args) =>
            {
                await AddCameraSourceAsync();
            };

            var miFile = new MenuItem() { Header = "File source" };
            miFile.Click += async (senderm, args) =>
            {
                await AddFileSourceAsync();
            };

            var miAudioSource = new MenuItem() { Header = "Audio source" };
            miAudioSource.Click += async (senderm, args) =>
            {
                await AddAudioSourceAsync();
            };

            var miAudioVirtual = new MenuItem() { Header = "Virtual audio" };
            miAudioVirtual.Click += async (senderm, args) =>
            {
                await AddAudioVirtualAsync();
            };

            var miVideoVirtual = new MenuItem() { Header = "Virtual video" };
            miVideoVirtual.Click += async (senderm, args) =>
            {
                await AddVideoVirtualAsync();
            };

            var miDecklinkSource = new MenuItem() { Header = "Decklink source" };
            miDecklinkSource.Click += async (senderm, args) =>
            {
                await AddDecklinkVideoSourceAsync();
            };

            ctx.Items.Add(miScreen);
            ctx.Items.Add(miCamera);
            ctx.Items.Add(miFile);
            ctx.Items.Add(miVideoVirtual);
            ctx.Items.Add(new Separator());
            ctx.Items.Add(miAudioSource);
            ctx.Items.Add(miAudioVirtual);
            ctx.Items.Add(new Separator());
            ctx.Items.Add(miDecklinkSource);
            ctx.PlacementTarget = sender as Button;
            ctx.IsOpen = true;
        }

        private async void btRemoveSource_Click(object sender, RoutedEventArgs e)
        {
            if (lbSources.SelectedIndex != -1)
            {
                await _compositor.Input_RemoveAtAsync(lbSources.SelectedIndex);
                lbSources.Items.RemoveAt(lbSources.SelectedIndex);
            }
        }

        private async Task UpdateSourceSelectionAsync()
        {
            if (lbSources.SelectedIndex != -1)
            {
                var input = _compositor.Input_VideoStream_Get(lbSources.SelectedIndex);

                if (input != null)
                {
                    edRectLeft.Text = input.Rectangle.Left.ToString();
                    edRectTop.Text = input.Rectangle.Top.ToString();
                    edRectRight.Text = input.Rectangle.Right.ToString();
                    edRectBottom.Text = input.Rectangle.Bottom.ToString();
                }

                _timelineSeeking = false;

                var inputSource = _compositor.Input_Get(lbSources.SelectedIndex);
                if (inputSource != null && inputSource is LVCVideoAudioInput vai)
                {
                    var duration = await vai.Pipeline.DurationAsync();
                    var position = await vai.Pipeline.Position_GetAsync();
                    tbSeeking.IsEnabled = true;
                    tbSeeking.Maximum = duration.TotalSeconds;
                    tbSeeking.Value = position.TotalSeconds;
                }
                else
                {
                    tbSeeking.IsEnabled = false;
                    tbSeeking.Value = 0;
                }

                _timelineSeeking = true;
            }
        }

        private async void lbSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await UpdateSourceSelectionAsync();
        }

        private async void lbSources_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            await UpdateSourceSelectionAsync();
        }

        private void btAddOutput_Click(object sender, RoutedEventArgs e)
        {
            var ctx = new ContextMenu();

            var miMP4 = new MenuItem() { Header = "MP4 file" };
            miMP4.Click += async (senderm, args) =>
            {
                await AddMP4OutputAsync();
            };

            var miWebM = new MenuItem() { Header = "WebM file" };
            miWebM.Click += async (senderm, args) =>
            {
                await AddWebMOutputAsync();
            };

            var miMP3 = new MenuItem() { Header = "MP3 file" };
            miMP3.Click += async (senderm, args) =>
            {
                await AddMP3OutputAsync();
            };

            var miDecklink = new MenuItem() { Header = "Decklink device" };
            miDecklink.Click += async (senderm, args) =>
            {
                await AddDecklinkVideoOutputAsync();
            };

            ctx.Items.Add(miMP4);
            ctx.Items.Add(miWebM);
            ctx.Items.Add(miMP3);
            ctx.Items.Add(new Separator());
            ctx.Items.Add(miDecklink);
            ctx.PlacementTarget = sender as Button;
            ctx.IsOpen = true;
        }

        private async void btRemoveOutput_Click(object sender, RoutedEventArgs e)
        {
            if (lbOutputs.SelectedIndex != -1)
            {
                await _compositor.Output_RemoveAsync(lbOutputs.SelectedValue.ToString());
                lbOutputs.Items.RemoveAt(lbOutputs.SelectedIndex);
                lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await _compositor.DisposeAsync();

            VisioForgeX.DestroySDK();
        }

        private async void btStartOutput_Click(object sender, RoutedEventArgs e)
        {
            if (lbOutputs.SelectedIndex != -1)
            {
                var output = _compositor.Output_Get(lbOutputs.SelectedValue.ToString());
                await output.StartAsync();
            }
        }

        private async void btStopOutput_Click(object sender, RoutedEventArgs e)
        {
            if (lbOutputs.SelectedIndex != -1)
            {
                var output = _compositor.Output_Get(lbOutputs.SelectedValue.ToString());
                await output.StopAsync();
            }
        }

        private bool _timelineSeeking = true;

        private async void tbSeeking_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_timelineSeeking)
            {
                return;
            }

            int index = lbSources.SelectedIndex;
            if (index != -1)
            {
                var fileInput = _compositor.Input_VideoAudio_Get(index);
                if (fileInput == null)
                {
                    return;
                }

                await fileInput?.Pipeline?.Position_SetAsync(TimeSpan.FromSeconds(e.NewValue));
            }
        }
    }
}
