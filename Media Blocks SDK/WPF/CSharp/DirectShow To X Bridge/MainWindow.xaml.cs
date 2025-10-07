using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioProcessing;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCapture;

namespace MediaBlocks_Simple_Video_Capture_Demo_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private PushVideoSourceBlock _videoSource;

        private PushAudioSourceBlock _audioSource;

        private VideoCaptureCore VideoCapture1;

        private System.Timers.Timer _timer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DeviceEnumerator_OnAudioSinkAdded(object sender, AudioOutputDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                if (e.API != AudioOutputDeviceAPI.DirectSound)
                {
                    return;
                }

                cbAudioOutput.Items.Add(e.Name);

                if (cbAudioOutput.Items.Count == 1)
                {
                    cbAudioOutput.SelectedIndex = 0;
                }
            });
        }          

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            DeviceEnumerator.Shared.OnAudioSinkAdded += DeviceEnumerator_OnAudioSinkAdded;

            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            await DeviceEnumerator.Shared.StartAudioSinkMonitorAsync();

            VideoCapture1 = await VideoCaptureCore.CreateAsync();
            VideoCapture1.OnError += VideoCapture1_OnError;

            foreach (var device in VideoCapture1.Video_CaptureDevices())
            {
                cbVideoInput.Items.Add(device.Name);
            }

            if (cbVideoInput.Items.Count > 0)
            {
                cbVideoInput.SelectedIndex = 0;
            }

            cbVideoInput_SelectionChanged(null, null);

            foreach (var device in VideoCapture1.Audio_CaptureDevices())
            {
                cbAudioInput.Items.Add(device.Name);
            }

            if (cbAudioInput.Items.Count > 0)
            {
                cbAudioInput.SelectedIndex = 0;
                cbAudioInput_SelectionChanged(null, null);
            }
        }

        private void Log(string txt)
        {
            Dispatcher.Invoke(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; });
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        public static void ParseVideoFormat(string formatString, out int width, out int height)
        {
            width = 0;
            height = 0;

            // Parse resolution and format
            var resolutionMatch = Regex.Match(formatString, @"(\d+)x(\d+)\s+(\w+)");
            if (resolutionMatch.Success)
            {
                width = int.Parse(resolutionMatch.Groups[1].Value);
                height = int.Parse(resolutionMatch.Groups[2].Value);
            }
        }

        public static void ParseAudioFormat(string formatString, out int sampleRate, out int channels, out int bps)
        {
            sampleRate = 0;
            channels = 0;
            bps = 0;

            // Parse sample rate
            var sampleRateMatch = Regex.Match(formatString, @"(\d+)\s+Hz");
            if (sampleRateMatch.Success)
            {
                sampleRate = int.Parse(sampleRateMatch.Groups[1].Value);
            }

            // Parse bit depth
            var bitDepthMatch = Regex.Match(formatString, @"(\d+)\s+Bits");
            if (bitDepthMatch.Success)
            {
                bps = int.Parse(bitDepthMatch.Groups[1].Value);
            }

            // Parse channels
            var channelsMatch = Regex.Match(formatString, @"(\d+)\s+Channels");
            if (channelsMatch.Success)
            {
                channels = int.Parse(channelsMatch.Groups[1].Value);
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (cbVideoFrameRate.SelectedIndex == -1)
            {
                MessageBox.Show("The frame rate should be specified.");
                return;
            }

            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
            _pipeline.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            mmLog.Clear();

            if (cbVideoInput.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Select video input device");
                return;
            }

            // Configure DirectShow video/audio source
            VideoCapture1.Video_Sample_Grabber_Enabled = true;

            VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            // Set NULL audio output, because we don't need real audio output but need to get audio frames in sample grabber    
            VideoCapture1.Audio_PlayAudio = true;
            VideoCapture1.Audio_OutputDevice = "NULL";
            VideoCapture1.Audio_Sample_Grabber_Enabled = true;

            // Set video and audio devices
            VideoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbVideoInput.Text);
            VideoCapture1.Video_CaptureDevice.Format = cbVideoFormat.Text;
            VideoCapture1.Video_CaptureDevice.Format_UseBest = false;

            VideoCapture1.Audio_CaptureDevice = new AudioCaptureSource(cbAudioInput.Text);
            VideoCapture1.Audio_CaptureDevice.Format = cbAudioFormat.Text;
            VideoCapture1.Audio_CaptureDevice.Format_UseBest = false;

            var frameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.Text));
            VideoCapture1.Video_CaptureDevice.FrameRate = frameRate;

            VideoCapture1.Mode = VideoCaptureMode.VideoPreview;

            // Disable video renderer
            VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.None;

            // Add video and audio frame callbacks
            VideoCapture1.OnVideoFrameBuffer += VideoCapture1_OnVideoFrameBuffer;
            VideoCapture1.OnAudioFrameBuffer += VideoCapture1_OnAudioFrameBuffer;

            // Configure Media Blocks      
            ParseVideoFormat(cbVideoFormat.Text, out int width, out int height);
            var videoSettings = new PushVideoSourceSettings(width, height, frameRate, VideoFormatX.BGR);
            _videoSource = new PushVideoSourceBlock(videoSettings); //new PushVideoSourceBlock(videoSettings);

            ParseAudioFormat(cbAudioFormat.Text, out int sampleRate, out int channels, out int bps);
            if (bps != 16)
            {
                MessageBox.Show("Only 16-bit audio is supported in this sample to make it simpler.");
                return;
            }

            var audioSettings = new PushAudioSourceSettings(isLive: true, sampleRate, channels, AudioFormatX.S16LE);
            audioSettings.DoTimestamp = true;
            _audioSource = new PushAudioSourceBlock(audioSettings);

            // Video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            // Audio renderer
            _audioRenderer = new AudioRendererBlock((await DeviceEnumerator.Shared.AudioOutputsAsync()).Where(device => device.Name == cbAudioOutput.Text).First()) { IsSync = false };
            
            // Connect all          
            _pipeline.Connect(_audioSource.Output, _audioRenderer.Input);
            _pipeline.Connect(_videoSource.Output, _videoRenderer.Input);

            // Start DirectShow part first
            await VideoCapture1.StartAsync();

            await Task.Delay(500); // give some time to DirectShow to start

            // Start Media Blocks part
            await _pipeline.StartAsync();

            _timer.Start();
        }

        private void VideoCapture1_OnAudioFrameBuffer(object sender, AudioFrameBufferEventArgs e)
        {
            _audioSource?.PushData(e.Frame);
        }

        private void VideoCapture1_OnVideoFrameBuffer(object sender, VideoFrameBufferEventArgs e)
        {
            _videoSource?.PushFrame(e.Frame.ToVideoFrameX(false));
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            await VideoCapture1.StopAsync();

            await _pipeline?.StopAsync();

            _pipeline?.ClearBlocks();

            VideoView1.CallRefresh();
        }      

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var position = await _pipeline.Position_GetAsync();

            Dispatcher.Invoke(() =>
            {
                lbTime.Text = position.ToString("hh\\:mm\\:ss");
            });           
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();

            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;

                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();

                _pipeline.OnError -= Pipeline_OnError;

                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            VisioForgeX.DestroySDK();
        }

        private void cbVideoInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbVideoInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                cbVideoFormat.Items.Clear();

                var deviceItem =
                    VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == e.AddedItems[0].ToString());
                if (deviceItem == null)
                {
                    return;
                }

                foreach (var format in deviceItem.VideoFormats)
                {
                    cbVideoFormat.Items.Add(format);
                }

                if (cbVideoFormat.Items.Count > 0)
                {
                    cbVideoFormat.SelectedIndex = 0;
                    cbVideoFormat_SelectionChanged(null, null);
                }
            }
        }

        private void cbVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoFormat.SelectedValue?.ToString()) || string.IsNullOrEmpty(cbVideoInput.SelectedValue.ToString()))
            {
                return;
            }

            if (cbVideoInput.SelectedIndex != -1)
            {
                var deviceItem = VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbVideoInput.SelectedValue.ToString());
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.FirstOrDefault(format => format.Name == cbVideoFormat.SelectedValue.ToString());
                if (videoFormat == null)
                {
                    return;
                }

                cbVideoFrameRate.Items.Clear();
                foreach (var frameRate in videoFormat.FrameRates)
                {
                    cbVideoFrameRate.Items.Add(frameRate.ToString(CultureInfo.CurrentCulture));
                }

                if (cbVideoFrameRate.Items.Count > 0)
                {
                    cbVideoFrameRate.SelectedIndex = 0;
                }
            }
        }

        private void cbAudioInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAudioInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                cbAudioFormat.Items.Clear();

                var deviceItem = VideoCapture1.Audio_CaptureDevices().FirstOrDefault(device => device.Name == e.AddedItems[0].ToString());
                if (deviceItem == null)
                {
                    return;
                }

                var defaultValue = "PCM, 44100 Hz, 16 Bits, 2 Channels";
                var defaultValueExists = false;
                foreach (string format in deviceItem.Formats)
                {
                    cbAudioFormat.Items.Add(format);

                    if (defaultValue == format)
                    {
                        defaultValueExists = true;
                    }
                }

                if (cbAudioFormat.Items.Count > 0)
                {
                    cbAudioFormat.SelectedIndex = 0;

                    if (defaultValueExists)
                    {
                        cbAudioFormat.Text = defaultValue;
                    }
                }
            }
        }

        private void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_audioRenderer != null)
            {
                _audioRenderer.Volume = tbVolume.Value / 100.0;
            }
        }
    }
}
