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
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core;
using System.Linq;
using VisioForge.Core.Types.X.Output;

namespace Screen_Capture_MB_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private ScreenSourceBlock _screenSource;

        private SystemAudioSourceBlock _audioInput;

        private TeeBlock _videoTee;

        private TeeBlock _audioTee;

        private H264EncoderBlock _videoEncoder;

        private AACEncoderBlock _audioEncoder;

        private MP4SinkBlock _sink;
        
        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        // Dialogs
        private readonly SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        
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
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
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

            CreateEngine();

            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            _screenSource = new ScreenSourceBlock(CreateScreenCaptureSource());
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            if (cbRecordAudio.IsChecked == true)
            {
                _audioInput = new SystemAudioSourceBlock(new DSAudioCaptureDeviceSourceSettings(cbAudioInputDevice.Text));
                _audioRenderer = new AudioRendererBlock((await DeviceEnumerator.AudioOutputsAsync()).Where(device => device.Name == cbAudioOutputDevice.Text && device.API == AudioOutputDeviceAPI.DirectSound).First());
            }

            if (rbPreview.IsChecked == true)
            {
                _pipeline.Connect(_screenSource.Output, _videoRenderer.Input);

                if (cbRecordAudio.IsChecked == true)
                {
                    _pipeline.Connect(_audioInput.Output, _audioRenderer.Input);
                }
            }
            else
            {   
                // create video tee
                _videoTee = new TeeBlock(2);
                _pipeline.Connect(_screenSource.Output, _videoTee.Input);

                // connect video renderer for preview
                _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);

                // create and connect video encoder
                _videoEncoder = new H264EncoderBlock(new OpenH264EncoderSettings());
                _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);

                _sink = new MP4SinkBlock(new MP4SinkSettings(edOutput.Text));
                _pipeline.Connect(_videoEncoder.Output, _sink.CreateNewInput(MediaBlockPadMediaType.Video));

                if (cbRecordAudio.IsChecked == true)
                {
                    // create audio tee
                    _audioTee = new TeeBlock(2);
                    _pipeline.Connect(_audioInput.Output, _audioTee.Input);
                    
                    // connect audio renderer for preview
                    _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);

                    // create and connect audio encoder
                    _audioEncoder = new AACEncoderBlock(new MFAACEncoderSettings());
                    _pipeline.Connect(_audioTee.Outputs[1], _audioEncoder.Input);

                    _pipeline.Connect(_audioEncoder.Output, _sink.CreateNewInput(MediaBlockPadMediaType.Audio));
                }
            }

            await _pipeline.StartAsync();

            tcMain.SelectedIndex = 3;
            tmRecording.Start();
        }
        
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.ResumeAsync();
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.PauseAsync();
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

            DestroyEngine();
        }

        private async void Form1_Load(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

            foreach (var device in await SystemAudioSourceBlock.GetDevicesAsync())
            {
                cbAudioInputDevice.Items.Add(device.Name);
            }

            if (cbAudioInputDevice.Items.Count > 0)
            {
                cbAudioInputDevice.SelectedIndex = 0;
                //cbAudioInputDevice_SelectedIndexChanged(null, null);
            }

            foreach (var device in await AudioRendererBlock.GetDevicesAsync())
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
       
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DestroyEngine();
            
            tmRecording?.Dispose();
            tmRecording = null;
        }
    }
}
