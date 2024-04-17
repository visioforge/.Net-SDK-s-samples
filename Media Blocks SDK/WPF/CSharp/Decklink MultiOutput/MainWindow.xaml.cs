using GLib;
using System;
using System.Text;
using System.Windows;

using VisioForge.Core.MediaBlocks.Decklink;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Decklink;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core;
using VisioForge.Libs.Decklink.SDK;
using System.IO;
using VisioForge.Core.Types;
using Rect = VisioForge.Core.Types.Rect;
using System.Linq;

namespace Decklink_MultiOutput
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private MediaBlock _videoSource;

        private VideoRendererBlock _videoRenderer;

        private TeeBlock _videoTee;

        private DecklinkVideoSinkBlock _decklinkVideoSink1;

        private DecklinkVideoSinkBlock _decklinkVideoSink2;

        private System.Timers.Timer _timer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreatePipeline(bool live)
        {
            _pipeline = new MediaBlocksPipeline(live);
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_pipeline != null)
            {
                var position = await _pipeline.Position_GetAsync();

                Dispatcher.Invoke(() =>
                {
                    lbTime.Text = position.ToString("hh\\:mm\\:ss");
                });
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            var videoSinkDevices = await DecklinkVideoSinkBlock.GetDevicesAsync();
            if (videoSinkDevices.Length > 0)
            {
                foreach (var item in videoSinkDevices)
                {
                    cbDecklinkVideoOutput1.Items.Add(item.Name);
                    cbDecklinkVideoOutput2.Items.Add(item.Name);
                }

                cbDecklinkVideoOutput1.SelectedIndex = 0;
                cbDecklinkVideoOutput2.SelectedIndex = 0;
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                _pipeline.ClearBlocks();
            }

            VideoView1.CallRefresh();
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            CreatePipeline(true);

            mmLog.Clear();

            if (rbVirtualSource.IsChecked == true)
            {
                _videoSource = new VirtualVideoSourceBlock(new VirtualVideoSourceSettings(1920, 1080, new VideoFrameRate(30)));
            }
            else
            {
                var screenSource = new ScreenCaptureD3D11SourceSettings();
                screenSource.Rectangle = new Rect(0, 0, 1920, 1080);
                screenSource.FrameRate = new VideoFrameRate(30);
                _videoSource = new ScreenSourceBlock(screenSource);
            }

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            // tees
            _videoTee = new TeeBlock(3);

            _pipeline.Connect(_videoSource.Output, _videoTee.Input);
            _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);

            // create Decklink outputs
            DecklinkVideoSinkSettings videoSinkSettings1 = null;

            var deviceName1 = cbDecklinkVideoOutput1.Text;
            if (!string.IsNullOrEmpty(deviceName1))
            {
                var device1 = (await DecklinkVideoSinkBlock.GetDevicesAsync()).FirstOrDefault(x => x.Name == deviceName1);
                if (device1 != null)
                {
                    videoSinkSettings1 = new DecklinkVideoSinkSettings(device1);
                    videoSinkSettings1.Mode = DecklinkMode.HD1080p30;
                }
            }

            _decklinkVideoSink1 = new DecklinkVideoSinkBlock(videoSinkSettings1);

            _pipeline.Connect(_videoTee.Outputs[1], _decklinkVideoSink1.Input);

            DecklinkVideoSinkSettings videoSinkSettings2 = null;

            var deviceName2 = cbDecklinkVideoOutput2.Text;
            if (!string.IsNullOrEmpty(deviceName2))
            {
                var device2 = (await DecklinkVideoSinkBlock.GetDevicesAsync()).FirstOrDefault(x => x.Name == deviceName2);
                if (device2 != null)
                {
                    videoSinkSettings2 = new DecklinkVideoSinkSettings(device2);
                    videoSinkSettings2.Mode = DecklinkMode.HD1080p30;
                }
            }

            _decklinkVideoSink2 = new DecklinkVideoSinkBlock(videoSinkSettings2);

            _pipeline.Connect(_videoTee.Outputs[2], _decklinkVideoSink2.Input);

            // start
            await _pipeline.StartAsync();

            _timer.Start();
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();

                _pipeline.OnError -= Pipeline_OnError;

                await _pipeline.DisposeAsync();

                _pipeline = null;
            }

            VideoView1.CallRefresh();

            VisioForgeX.DestroySDK();
        }
    }
}