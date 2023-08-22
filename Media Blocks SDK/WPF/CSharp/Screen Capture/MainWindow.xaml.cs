using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI;
using VisioForge.Core.Types.Events;
using VisioForge.Core.MediaBlocks.Sources;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
using VisioForge.Core;
using VisioForge.Core.Types.X.Output;
using System.Threading.Tasks;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.Types.X;
using VisioForge.Core.GStreamer.Helpers;

namespace Screen_Capture_MB_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipelineScreen;

        private MediaBlocksPipeline _pipelinePush;

        private VideoRendererBlock _videoRenderer;

        private PushVideoSourceBlock _pushSource;

       // private AudioRendererBlock _audioRenderer;


        private ScreenSourceBlock _screenSource;

        private VideoSampleGrabberBlock _screenVideoSampleGrabber;

       // private SystemAudioSourceBlock _audioInput;

       // private TeeBlock _videoTee;

      //  private TeeBlock _audioTee;

      //  private H264EncoderBlock _videoEncoder;

      //  private AACEncoderBlock _audioEncoder;

       // private MP4SinkBlock _sink;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        private DeviceEnumerator _deviceEnumerator;

        // Dialogs
        private readonly SaveFileDialog saveFileDialog1 = new SaveFileDialog();

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();

            _deviceEnumerator = new DeviceEnumerator();
        }

        private void PipelineScreen_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + "[SCREEN]" + e.Message + Environment.NewLine;
            }));
        }

        private void PipelinePush_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + "[PUSH]" + e.Message + Environment.NewLine;
            }));
        }

        private void CreateEngines()
        {
            _pipelineScreen = new MediaBlocksPipeline(true);
            _pipelineScreen.OnError += PipelineScreen_OnError;

            _pipelinePush = new MediaBlocksPipeline(true);
            _pipelinePush.OnError += PipelinePush_OnError;
        }

        private async Task DestroyEnginesAsync()
        {
            if (_pipelineScreen != null)
            {
                _pipelineScreen.OnError -= PipelineScreen_OnError;
                await _pipelineScreen.DisposeAsync();
                _pipelineScreen = null;
            }

            if (_pipelinePush != null)
            {
                _pipelinePush.OnError -= PipelinePush_OnError;
                await _pipelinePush.DisposeAsync();
                _pipelinePush = null;
            }
        }

        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == true)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        private ScreenCaptureDX9SourceSettings CreateScreenCaptureSource()
        {
            var screenID = Convert.ToInt32(cbScreenCaptureDisplayIndex.Text);

            var source = new ScreenCaptureDX9SourceSettings();

            source.FrameRate = new VideoFrameRate(Convert.ToDouble(edScreenFrameRate.Text));

            if (rbScreenFullScreen.IsChecked == true)
            {
                for (int i = 0; i < System.Windows.Forms.Screen.AllScreens.Length; i++)
                {
                    if (i == screenID)
                    {
                        source.Rectangle = new VisioForge.Core.Types.Rect(System.Windows.Forms.Screen.AllScreens[i].Bounds);
                    }
                }
            }
            else
            {
                source.Rectangle = new VisioForge.Core.Types.Rect(
                    Convert.ToInt32(edScreenLeft.Text),
                    Convert.ToInt32(edScreenTop.Text),
                    Convert.ToInt32(edScreenRight.Text),
                    Convert.ToInt32(edScreenBottom.Text));
            }

            source.CaptureCursor = cbScreenCapture_GrabMouseCursor.IsChecked == true;
            source.Monitor = screenID;

            return source;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();

            CreateEngines();

            _pipelineScreen.Debug_Mode = cbDebugMode.IsChecked == true;
            _pipelineScreen.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            _pipelinePush.Debug_Mode = cbDebugMode.IsChecked == true;
            _pipelinePush.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            // screen source with sample grabber
            var screenSettings = CreateScreenCaptureSource();
            _screenSource = new ScreenSourceBlock(screenSettings);
            _screenVideoSampleGrabber = new VideoSampleGrabberBlock(VideoFormatX.RGB, addNullRenderer: true);
            _screenVideoSampleGrabber.OnVideoFrameBuffer += ScreenVideoSampleGrabber_OnVideoFrameBuffer;
            _pipelineScreen.Connect(_screenSource.Output, _screenVideoSampleGrabber.Input);

            // push source
            var pushSourceSettings = new PushVideoSourceSettings(true)
            {
                FrameRate = screenSettings.FrameRate,
                Width = screenSettings.Rectangle.Width,
                Height = screenSettings.Rectangle.Height,
                Format = VideoFormatX.RGB
            };
            _pushSource = new PushVideoSourceBlock(pushSourceSettings);
            _videoRenderer = new VideoRendererBlock(_pipelinePush, VideoView1);
            _pipelinePush.Connect(_pushSource.Output, _videoRenderer.Input);





            //if (cbRecordAudio.IsChecked == true)
            //{
            //    var audioInputDevice = (await _deviceEnumerator.AudioSourcesAsync(AudioCaptureDeviceAPI.DirectSound)).Where(device => device.DisplayName == cbAudioInputDevice.Text).First();
            //    _audioInput = new SystemAudioSourceBlock(new DSAudioCaptureDeviceSourceSettings(audioInputDevice, null));
            //    _audioRenderer = new AudioRendererBlock((await _deviceEnumerator.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).Where(device => device.DisplayName == cbAudioOutputDevice.Text).First());
            //}

            //if (rbPreview.IsChecked == true)
            //{
            //    _pipeline.Connect(_screenSource.Output, _videoRenderer.Input);

            //    if (cbRecordAudio.IsChecked == true)
            //    {
            //        _pipeline.Connect(_audioInput.Output, _audioRenderer.Input);
            //    }
            //}
            //else
            //{
            //    // create video tee
            //    _videoTee = new TeeBlock(2);
            //    _pipeline.Connect(_screenSource.Output, _videoTee.Input);

            //    // connect video renderer for preview
            //    _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);

            //    // create and connect video encoder
            //    _videoEncoder = new H264EncoderBlock(new OpenH264EncoderSettings());
            //    _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);

            //    _sink = new MP4SinkBlock(new MP4SinkSettings(edOutput.Text));
            //    _pipeline.Connect(_videoEncoder.Output, _sink.CreateNewInput(MediaBlockPadMediaType.Video));

            //    if (cbRecordAudio.IsChecked == true)
            //    {
            //        // create audio tee
            //        _audioTee = new TeeBlock(2);
            //        _pipeline.Connect(_audioInput.Output, _audioTee.Input);

            //        // connect audio renderer for preview
            //        _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);

            //        // create and connect audio encoder
            //        _audioEncoder = new AACEncoderBlock(new MFAACEncoderSettings());
            //        _pipeline.Connect(_audioTee.Outputs[1], _audioEncoder.Input);

            //        _pipeline.Connect(_audioEncoder.Output, _sink.CreateNewInput(MediaBlockPadMediaType.Audio));
            //    }
            //}

            await _pipelineScreen.StartAsync();
            await _pipelinePush.StartAsync();

            tcMain.SelectedIndex = 3;
            tmRecording.Start();
        }

        private void ScreenVideoSampleGrabber_OnVideoFrameBuffer(object sender, VideoFrameXBufferEventArgs e)
        {
            _pushSource.PushFrame(e.Frame);
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            _pipelinePush.Debug_Dir = @"c:\vf";
            _pipelinePush.Debug_SavePipeline("push");

           // await _pipeline.ResumeAsync();
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
           // await _pipeline.PauseAsync();
        }

        private void UpdateRecordingTime()
        {
            var ts = _pipelineScreen.Duration();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            Dispatcher.BeginInvoke((Action)(() =>
            {
                lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
            }));
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await _pipelineScreen.StopAsync();
            await _pipelinePush.StopAsync();

            await DestroyEnginesAsync();
        }

        private async void Form1_Load(object sender, RoutedEventArgs e)
        {
            CreateEngines();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

            foreach (var device in await SystemAudioSourceBlock.GetDevicesAsync(_deviceEnumerator, AudioCaptureDeviceAPI.DirectSound))
            {
                cbAudioInputDevice.Items.Add(device.DisplayName);
            }

            if (cbAudioInputDevice.Items.Count > 0)
            {
                cbAudioInputDevice.SelectedIndex = 0;
                //cbAudioInputDevice_SelectedIndexChanged(null, null);
            }

            foreach (var device in await AudioRendererBlock.GetDevicesAsync(_deviceEnumerator, AudioOutputDeviceAPI.DirectSound))
            {
                cbAudioOutputDevice.Items.Add(device);
            }

            if (cbAudioOutputDevice.Items.Count > 0)
            {
                cbAudioOutputDevice.SelectedIndex = 0;
                //cbAudioInputDevice_SelectedIndexChanged(null, null);
            }

            for (int i = 0; i < System.Windows.Forms.Screen.AllScreens.Length; i++)
            {
                cbScreenCaptureDisplayIndex.Items.Add(i.ToString());
            }

            if (cbScreenCaptureDisplayIndex.Items.Count > 0)
            {
                cbScreenCaptureDisplayIndex.SelectedIndex = 0;
            }

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
        }

        private void llVideoTutorials_LinkClicked(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await DestroyEnginesAsync();

            tmRecording?.Dispose();
            tmRecording = null;

            _deviceEnumerator?.Dispose();
        }
    }
}
