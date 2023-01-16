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

        private VideoMixerBlock _videoMixer;

        private VirtualAudioSourceBlock _fakeAudioSource;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();

            _pipeline = new MediaBlocksPipeline(true);
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
            _pipeline = new MediaBlocksPipeline(true);
            _pipeline.OnError += Pipeline_OnError;
        }

        private void DestroyEngine()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;

                _pipeline.Dispose();
                _pipeline = null;
            }
        }

        private void btAddCamera_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new VideoCaptureSourceDialog(_pipeline);
            if (dlg.ShowDialog() == true)
            {
                var src = new CompositorSource();

                VideoCaptureDeviceSourceSettings settings = null;

                var deviceName = dlg.VideoCaptureDevice;
                var format = dlg.VideoCaptureFormat;
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = SystemVideoSourceBlock.GetDevices(_pipeline).FirstOrDefault(x => x.Name == deviceName);
                    if (device != null)
                    {
                        var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                        if (formatItem != null)
                        {
                            settings = new VideoCaptureDeviceSourceSettings(device.Name)
                            {
                                Format = formatItem.ToFormat()
                            };

                            settings.Format.FrameRate = dlg.VideoFrameRate;
                        }
                    }
                }

                if (settings == null)
                {
                    MessageBox.Show("Unable to configure video capture device.");
                    return;
                }

                src.Source = new SystemVideoSourceBlock(settings);
                src.Rectangle = new Rect(Convert.ToInt32(edRectLeft.Text), Convert.ToInt32(edRectTop.Text), Convert.ToInt32(edRectRight.Text), Convert.ToInt32(edRectBottom.Text));

                _sources.Add(src);

                cbSources.Items.Add($"Camera [{dlg.VideoCaptureDevice}]");
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

        private void btAddFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                var src = new CompositorSource();
                src.Source = new FileSourceBlock(dlg.FileName);
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
            var ts = _pipeline.Duration();

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

            var videoMixerSettings = new VideoMixerSettings(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text), new VideoFrameRate(Convert.ToInt32(edFrameRate.Text), 1));

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
                    _mp4Output = new MP4OutputBlock(new MP4SinkSettings(edOutputFilename.Text), new OpenH264EncoderSettings(), null);
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
                    _facebookOutput = new FacebookLiveOutputBlock(new FacebookLiveSinkSettings(edOutputYouTubeKey.Text), new OpenH264EncoderSettings(), new MFAACEncoderSettings());
                    _pipeline.Connect(_videoTee.Outputs[1], _facebookOutput.CreateNewInput(MediaBlockPadMediaType.Video));
                    _pipeline.Connect(_fakeAudioSource.Output, _facebookOutput.CreateNewInput(MediaBlockPadMediaType.Audio));
                }
            }

            await _pipeline.StartAsync();

            tmRecording.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await _pipeline.StopAsync();

            DestroyEngine();
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

                var stream = _videoMixer.Input_Get(index);
                stream.Rectangle = _sources[index].Rectangle;
                _videoMixer.Input_Update(index, stream);
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
    }
}
