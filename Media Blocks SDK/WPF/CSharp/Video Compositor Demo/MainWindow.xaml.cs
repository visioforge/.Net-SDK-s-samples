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
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.WPF.Dialogs;
using Microsoft.Win32;
using VisioForge.Core.Types.Events;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types;
using Rect = VisioForge.Core.Types.Rect;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.UI.WPF.Dialogs.Sources;
using VisioForge.Core;
using VisioForge.Core.Types.X.OpenGL;
using VisioForge.Libs.DirectShowLib;

namespace Video_Compositor_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<CompositorSource> _sources = new List<CompositorSource>();

        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private TeeBlock _videoTee;

        private MP4OutputBlock _mp4Output;

        private YouTubeOutputBlock _youTubeOutput;

        private FacebookLiveOutputBlock _facebookOutput;

        private NDISinkBlock _ndiSink;

        private VideoMixerBlock _videoMixer;

        private VirtualAudioSourceBlock _fakeAudioSource;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
        }
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                // mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
        }

        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        private async void btAddCamera_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new VideoCaptureSourceDialog();
            if (dlg.ShowDialog() == true)
            {
                var src = new CompositorSource();

                VideoCaptureDeviceSourceSettings settings = null;

                var deviceName = dlg.Device;
                var format = dlg.Format;
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = (await SystemVideoSourceBlock.GetDevicesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
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

                src.Source = new SystemVideoSourceBlock(settings);
                src.Rectangle = new Rect(Convert.ToInt32(edRectLeft.Text), Convert.ToInt32(edRectTop.Text), Convert.ToInt32(edRectRight.Text), Convert.ToInt32(edRectBottom.Text));

                _sources.Add(src);

                cbSources.Items.Add($"Camera [{dlg.Device}]");
                cbSources.SelectedIndex = cbSources.Items.Count - 1;
            }
        }

        private void btAddScreen_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ScreenSourceDialog();
            if (dlg.ShowDialog() == true)
            {
                var src = new CompositorSource();
                var settings = new ScreenCaptureDX9SourceSettings();
                settings.CaptureCursor = dlg.GrabMouseCursor;
                settings.Monitor = dlg.DisplayIndex;
                settings.FrameRate = dlg.FrameRate;
                settings.Rectangle = dlg.Rectangle;
                src.Source = new ScreenSourceBlock(settings);
                src.Rectangle = new Rect(Convert.ToInt32(edRectLeft.Text), Convert.ToInt32(edRectTop.Text), Convert.ToInt32(edRectRight.Text), Convert.ToInt32(edRectBottom.Text));

                _sources.Add(src);

                cbSources.Items.Add($"Screen [{dlg.DisplayIndex}] {dlg.Rectangle.Width}x{dlg.Rectangle.Height}");
                cbSources.SelectedIndex = cbSources.Items.Count - 1;
            }
        }

        private async void btAddFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                var src = new CompositorSource();
                src.Source = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(dlg.FileName));
                src.Rectangle = new Rect(Convert.ToInt32(edRectLeft.Text), Convert.ToInt32(edRectTop.Text), Convert.ToInt32(edRectRight.Text), Convert.ToInt32(edRectBottom.Text));

                _sources.Add(src);

                cbSources.Items.Add($"File [{dlg.FileName}]");
                cbSources.SelectedIndex = cbSources.Items.Count - 1;
            }
        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            if (cbSources.SelectedIndex != -1)
            {
                _sources.RemoveAt(cbSources.SelectedIndex);
                cbSources.Items.RemoveAt(cbSources.SelectedIndex);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };
        }
       
        private void UpdateRecordingTime()
        {
            var ts = _pipeline.Position_Get();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            Dispatcher.BeginInvoke((Action)(() =>
            {
                lbTimestamp.Content = ts.ToString(@"hh\:mm\:ss");
            }));
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            //mmLog.Clear();

            CreateEngine();

            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);
            _videoRenderer.IsSync = false;

            VideoMixerBaseSettings videoMixerSettings;

            if (cbMixerType.SelectedIndex == 0)
            {
                videoMixerSettings = new VideoMixerSettings(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text), new VideoFrameRate(Convert.ToInt32(edFrameRate.Text)));
            }
            else if (cbMixerType.SelectedIndex == 1)
            {
                videoMixerSettings = new D3D11VideoCompositorSettings(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text), new VideoFrameRate(Convert.ToInt32(edFrameRate.Text)));
            }
            else
            {
                videoMixerSettings = new GLVideoMixerSettings(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text), new VideoFrameRate(Convert.ToInt32(edFrameRate.Text)));
            }

            uint i = 0;
            foreach (var source in _sources)
            {
                videoMixerSettings.AddStream(new VideoMixerStream(source.Rectangle, i));
                i++;
            }

            _videoMixer = new VideoMixerBlock(videoMixerSettings);

            i = 0;
            foreach (var source in _sources)
            {
                _pipeline.Connect(source.Source.Output, _videoMixer.Inputs[i]);
                i++;
            }

            if (rbOutputNone.IsChecked == true)
            {
                _pipeline.Connect(_videoMixer.Output, _videoRenderer.Input);
            }
            else
            {
                // create video tee
                _videoTee = new TeeBlock(2);
                _pipeline.Connect(_videoMixer.Output, _videoTee.Input);

                // connect video renderer for preview
                _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
                
                if (rbOutputFile.IsChecked == true)
                {
                    // create and connect MP4 output
                    _mp4Output = new MP4OutputBlock(new MP4SinkSettings(edOutputFilename.Text), new OpenH264EncoderSettings(), aacSettings: null);
                    _pipeline.Connect(_videoTee.Outputs[1], _mp4Output.CreateNewInput(MediaBlockPadMediaType.Video));
                }
                else if (rbOutputYouTube.IsChecked == true)
                {
                    // fake audio source 
                    _fakeAudioSource = new VirtualAudioSourceBlock(new VirtualAudioSourceSettings());

                    // create and connect YouTube output
                    _youTubeOutput = new YouTubeOutputBlock(new YouTubeSinkSettings(edOutputYouTubeKey.Text), new OpenH264EncoderSettings(), new MFAACEncoderSettings());
                    _pipeline.Connect(_videoTee.Outputs[1], _youTubeOutput.CreateNewInput(MediaBlockPadMediaType.Video));
                    _pipeline.Connect(_fakeAudioSource.Output, _youTubeOutput.CreateNewInput(MediaBlockPadMediaType.Audio));
                }
                else if (rbOutputFacebook.IsChecked == true)
                {
                    // fake audio source 
                    _fakeAudioSource = new VirtualAudioSourceBlock(new VirtualAudioSourceSettings());

                    // create and connect Facebook Live output
                    _facebookOutput = new FacebookLiveOutputBlock(new FacebookLiveSinkSettings(edOutputFacebookKey.Text), new OpenH264EncoderSettings(), new MFAACEncoderSettings());
                    _pipeline.Connect(_videoTee.Outputs[1], _facebookOutput.CreateNewInput(MediaBlockPadMediaType.Video));
                    _pipeline.Connect(_fakeAudioSource.Output, _facebookOutput.CreateNewInput(MediaBlockPadMediaType.Audio));
                }
                else if (rbOutputNDI.IsChecked == true)
                {
                    // fake audio source 
                    _fakeAudioSource = new VirtualAudioSourceBlock(new VirtualAudioSourceSettings());

                    // create and connect Facebook Live output
                    _ndiSink = new NDISinkBlock(new NDISinkSettings(edOutputNDIName.Text));
                    _pipeline.Connect(_videoTee.Outputs[1], _ndiSink.CreateNewInput(MediaBlockPadMediaType.Video));
                    _pipeline.Connect(_fakeAudioSource.Output, _ndiSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                }
            }

            await _pipeline.StartAsync();

            //_pipeline.SavePipeline("compositor");

            tmRecording.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            if (rbOutputFile.IsChecked == true)
            {
                await _pipeline.StopAsync();
            }
            else
            {
                await _pipeline.StopAsync(true);
            }
            
            await DestroyEngineAsync();
        }

        private void btUpdateRect_Click(object sender, RoutedEventArgs e)
        {
            int index = cbSources.SelectedIndex;
            if (index != -1)
            {
                _sources[index].Rectangle = new Rect(
                    Convert.ToInt32(edRectLeft.Text),
                    Convert.ToInt32(edRectTop.Text),
                    Convert.ToInt32(edRectRight.Text),
                    Convert.ToInt32(edRectBottom.Text));

                if (_videoMixer != null)
                {
                    var stream = _videoMixer.Input_Get(index);
                    stream.Rectangle = _sources[index].Rectangle;
                    _videoMixer.Input_Update(index, stream);
                }
            }
        }

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == true)
            {
                edOutputFilename.Text = dlg.FileName;
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await DestroyEngineAsync();

            VisioForgeX.DestroySDK();
        }
    }
}
