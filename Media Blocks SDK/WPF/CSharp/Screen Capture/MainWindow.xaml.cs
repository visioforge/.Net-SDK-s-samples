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
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.AudioEncoders;
using Gst.Audio;
using System.Linq;

namespace Screen_Capture_MB_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private ScreenSourceBlock _screenSource;

        private SystemAudioSourceBlock _audioInput;

        private AudioRendererBlock _audioRenderer;

        private TeeBlock _videoTee;

        private TeeBlock _audioTee;

        private H264EncoderBlock _videoEncoder;

        private AACEncoderBlock _audioEncoder;

       private MP4SinkBlock _sink;

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

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + "[SCREEN]" + e.Message + Environment.NewLine;
            }));
        }

        private void CreateEngines()
        {
            _pipeline = new MediaBlocksPipeline(true);
            _pipeline.OnError += Pipeline_OnError;
        }

        private async Task DestroyEnginesAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                await _pipeline.DisposeAsync();
                _pipeline = null;
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

            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            // screen source
            var screenSettings = CreateScreenCaptureSource();
            _screenSource = new ScreenSourceBlock(screenSettings);

            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            if (rbPreview.IsChecked == true)
            {
                _pipeline.Connect(_screenSource.Output, _videoRenderer.Input);
            }
            else
            {
                _videoTee = new TeeBlock(2);

                _pipeline.Connect(_screenSource.Output, _videoTee.Input);

                _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);

                _videoEncoder = new H264EncoderBlock(new OpenH264EncoderSettings());
                _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);

                _sink = new MP4SinkBlock(new MP4SinkSettings(edOutput.Text));
                _pipeline.Connect(_videoEncoder.Output, _sink.CreateNewInput(MediaBlockPadMediaType.Video));                
            }

            // audio source
            if (cbRecordAudio.IsChecked == true)
            {
                // audio source
                DSAudioCaptureDeviceSourceSettings audioSourceSettings = null;

                var deviceName = cbAudioInputDevice.Text;
                if (!string.IsNullOrEmpty(deviceName))
                {
                    var device = (await _deviceEnumerator.AudioSourcesAsync(AudioCaptureDeviceAPI.DirectSound)).FirstOrDefault(x => x.Name == deviceName);
                    if (device != null)
                    {
                        audioSourceSettings = new DSAudioCaptureDeviceSourceSettings(device, device.GetDefaultFormat());
                    }
                }

                _audioInput = new SystemAudioSourceBlock(audioSourceSettings);

                // audio renderer
                _audioRenderer = new AudioRendererBlock((await _deviceEnumerator.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).Where(x => x.Name == cbAudioOutputDevice.Text).First());

                if (rbPreview.IsChecked == true)
                {
                    _pipeline.Connect(_audioInput.Output, _audioRenderer.Input);
                }
                else
                {
                    _audioTee = new TeeBlock(2);

                    _pipeline.Connect(_audioInput.Output, _audioTee.Input);

                    _audioEncoder = new AACEncoderBlock(new VOAACEncoderSettings());
                    _pipeline.Connect(_audioTee.Outputs[0], _audioEncoder.Input);
                    _pipeline.Connect(_audioEncoder.Output, _sink.CreateNewInput(MediaBlockPadMediaType.Audio));

                    _pipeline.Connect(_audioTee.Outputs[1], _audioRenderer.Input);
                }
            }

            await _pipeline.StartAsync();

            tcMain.SelectedIndex = 3;
            tmRecording.Start();
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
                lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
            }));
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await _pipeline.StopAsync();

            await DestroyEnginesAsync();
        }

        private async void Form1_Load(object sender, RoutedEventArgs e)
        {
            CreateEngines();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

            foreach (var device in await SystemAudioSourceBlock.GetDevicesAsync(_deviceEnumerator, AudioCaptureDeviceAPI.DirectSound))
            {
                cbAudioInputDevice.Items.Add(device.Name);
            }

            if (cbAudioInputDevice.Items.Count > 0)
            {
                cbAudioInputDevice.SelectedIndex = 0;
                //cbAudioInputDevice_SelectedIndexChanged(null, null);
            }

            foreach (var device in await AudioRendererBlock.GetDevicesAsync(_deviceEnumerator, AudioOutputDeviceAPI.DirectSound))
            {
                cbAudioOutputDevice.Items.Add(device.Name);
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
