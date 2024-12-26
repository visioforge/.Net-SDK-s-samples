using System.Diagnostics;

using System.Windows;
using System.Windows.Input;

using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types;
using VisioForge.Core.UI;
using VisioForge.Core;
using System.IO;
using VisioForge.Core.Types.X.Special;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Live_Source_Switch_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private ScreenSourceBlock _screenSource;

        private SystemVideoSourceBlock _cameraSource;

        private SourceSwitchBlock _switch;

        private int _switchIndex = 0;

        private const int VIDEO_WIDTH = 1280;

        private const int VIDEO_HEIGHT = 720;

        private const int VIDEO_FPS = 25;

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();
        }

        private void Shared_OnVideoSourceAdded(object sender, VideoCaptureDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbCamera.Items.Add(e.DisplayName);

                cbCamera.SelectedIndex = 0;
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
            _pipeline = new MediaBlocksPipeline();
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

        private ScreenCaptureDX9SourceSettings CreateScreenCaptureSource()
        {
            var screenID = Convert.ToInt32(0);

            var source = new ScreenCaptureDX9SourceSettings();

            source.FrameRate = new VideoFrameRate(VIDEO_FPS);

            source.Rectangle = new VisioForge.Core.Types.Rect(0, 0, VIDEO_WIDTH, VIDEO_HEIGHT);

            source.CaptureCursor = true;
            source.Monitor = screenID;

            return source;
        }

        private async Task<VideoCaptureDeviceSourceSettings> CreateCameraSourceAsync()
        {
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            var deviceName = cbCamera.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    var formatItem = device.VideoFormats.Where(f => f.Width == VIDEO_WIDTH && f.Height == VIDEO_HEIGHT && f.Format != "H264").FirstOrDefault();
                    if (formatItem != null)
                    {
                        videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                        {
                            Format = formatItem.ToFormat()
                        };

                        videoSourceSettings.Format.FrameRate = formatItem.FrameRateList[formatItem.FrameRateList.Count - 1];
                    }
                }
            }

            return videoSourceSettings;
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

            // camera source
            var cameraSettings = await CreateCameraSourceAsync();
            _cameraSource = new SystemVideoSourceBlock(cameraSettings);

            // switch
            var switchSettings = new SourceSwitchSettings(2);
            _switch = new SourceSwitchBlock(switchSettings);

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };

            // connect
            _pipeline.Connect(_screenSource.Output, _switch.Inputs[0]);
            _pipeline.Connect(_cameraSource.Output, _switch.Inputs[1]);

            _pipeline.Connect(_switch.Output, _videoRenderer.Input);

            await _pipeline.StartAsync();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.StopAsync();

            await DestroyEnginesAsync();
        }

        private async void Form1_Load(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            DeviceEnumerator.Shared.OnVideoSourceAdded += Shared_OnVideoSourceAdded;

            CreateEngines();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            DeviceEnumerator.Shared.StartVideoSourceMonitor();
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

        private void btSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (_switch != null)
            {
                if (_switchIndex == 0)
                {
                    _switchIndex = 1;
                }
                else
                {
                    _switchIndex = 0;
                }

                _switch.Switch(_switchIndex);
            }
        }
    }
}