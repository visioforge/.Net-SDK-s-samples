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
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.AudioEncoders;
using System.Linq;
using VisioForge.Core.Types.X.VideoCapture;
using System.Windows.Media;

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

        // Dialogs
        private readonly SaveFileDialog saveFileDialog1 = new SaveFileDialog();

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();

            DeviceEnumerator.Shared.OnAudioSourceAdded += DeviceEnumerator_OnAudioSourceAdded;
            DeviceEnumerator.Shared.OnAudioSinkAdded += DeviceEnumerator_OnAudioSinkAdded;
        }

        private void DeviceEnumerator_OnAudioSinkAdded(object sender, AudioOutputDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbAudioOutputDevice.Items.Add(e.DisplayName);

                if (cbAudioOutputDevice.Items.Count == 1)
                {
                    cbAudioOutputDevice.SelectedIndex = 0;
                }
            });
        }

        private void DeviceEnumerator_OnAudioSourceAdded(object sender, AudioCaptureDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbAudioInputDevice.Items.Add(e.DisplayName);

                if (cbAudioInputDevice.Items.Count == 1)
                {
                    cbAudioInputDevice.SelectedIndex = 0;
                }
            });
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

        private IScreenCaptureSourceSettings CreateWindowCaptureSource()
        { 
            // create Direct3D11 source
            var source = new ScreenCaptureD3D11SourceSettings();

            // set frame rate
            source.FrameRate = new VideoFrameRate(Convert.ToDouble(edScreenFrameRate.Text));

            // get handle of the window
            var wih = new System.Windows.Interop.WindowInteropHelper(this);
            source.WindowHandle = wih.Handle;

            return source;
        }

        private IScreenCaptureSourceSettings CreateScreenCaptureSource()
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

            if (rbWindow.IsChecked == true)
            {
                var windowSettings = CreateWindowCaptureSource();
                _screenSource = new ScreenSourceBlock(windowSettings);
            }
            else
            {
                // screen source
                var screenSettings = CreateScreenCaptureSource();
                _screenSource = new ScreenSourceBlock(screenSettings);
            }

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
                IAudioCaptureDeviceSourceSettings audioSourceSettings = null;

                var deviceName = cbAudioInputDevice.Text;
                if (!string.IsNullOrEmpty(deviceName))
                {
                    var device = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                    if (device != null)
                    {
                        audioSourceSettings = device.CreateSourceSettings();
                    }
                }

                _audioInput = new SystemAudioSourceBlock(audioSourceSettings);

                // audio renderer
                _audioRenderer = new AudioRendererBlock((await DeviceEnumerator.Shared.AudioOutputsAsync()).Where(x => x.DisplayName == cbAudioOutputDevice.Text).First());

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
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.StopAsync();

            await DestroyEnginesAsync();
        }

        private async void Form1_Load(object sender, RoutedEventArgs e)
        {
            CreateEngines();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            await DeviceEnumerator.Shared.StartAudioSourceMonitorAsync();
            await DeviceEnumerator.Shared.StartAudioSinkMonitorAsync();

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

            VisioForgeX.DestroySDK();
        }
    }
}
