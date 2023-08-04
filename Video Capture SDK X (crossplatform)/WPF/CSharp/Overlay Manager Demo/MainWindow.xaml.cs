using System;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.Events;
using Microsoft.Win32;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;
using System.Linq;
using System.Windows.Controls;
using VisioForge.Core.Types;

namespace Overlay_Manager_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Timers.Timer _timer;

        private volatile bool _timerFlag;

        private VideoCaptureCoreX _videoCapture;

        private DeviceEnumerator _deviceEnumerator;

        public MainWindow()
        {
            InitializeComponent();

            // We have to initialize the engine on start
            MediaBlocksPipeline.InitSDK();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";

            _deviceEnumerator = new DeviceEnumerator();

            // video input
            foreach (var device in await _deviceEnumerator.VideoSourcesAsync())
            {
                cbVideoInputDevice.Items.Add(device.DisplayName);
            }

            if (cbVideoInputDevice.Items.Count > 0)
            {
                cbVideoInputDevice.SelectedIndex = 0;
            }

            cbVideoInputDevice_SelectionChanged(null, null);
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                edLog.Text = edLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {

            }));
        }

        private void CreateEngine()
        {
            _videoCapture = new VideoCaptureCoreX(VideoView1);
            _videoCapture.OnError += Pipeline_OnError;
            _videoCapture.OnStop += Pipeline_OnStop;
            _videoCapture.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _videoCapture.Debug_Mode = cbDebugMode.IsChecked == true;
        }

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timerFlag = true;

            var duration = await _videoCapture.DurationAsync();

            Dispatcher.Invoke((Action)(() =>
            {
                lbTime.Text = duration.ToString("hh\\:mm\\:ss");
            }));

            _timerFlag = false;
        }

        private async Task DestroyEngineAsync()
        {
            if (_videoCapture != null)
            {
                _videoCapture.OnError -= Pipeline_OnError;
                _videoCapture.OnStop -= Pipeline_OnStop;
                await _videoCapture.DisposeAsync();
                _videoCapture = null;
            }
        }

        private async void cbVideoInputDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbVideoInputDevice.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                cbVideoInputFormat.Items.Clear();

                var deviceItem =
                    (await _deviceEnumerator.VideoSourcesAsync()).FirstOrDefault(device => device.DisplayName == e.AddedItems[0].ToString());
                if (deviceItem == null)
                {
                    return;
                }

                foreach (var format in deviceItem.VideoFormats)
                {
                    cbVideoInputFormat.Items.Add(format.Name);
                }

                if (cbVideoInputFormat.Items.Count > 0)
                {
                    cbVideoInputFormat.SelectedIndex = 0;
                    cbVideoInputFormat_SelectionChanged(null, null);
                }
            }
        }

        private async void cbVideoInputFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbVideoInputFrameRate.Items.Clear();

            if (string.IsNullOrEmpty(cbVideoInputFormat.SelectedValue?.ToString()) || string.IsNullOrEmpty(cbVideoInputDevice.SelectedValue.ToString()))
            {
                return;
            }

            if (cbVideoInputDevice.SelectedIndex != -1)
            {
                var deviceItem = (await _deviceEnumerator.VideoSourcesAsync()).FirstOrDefault(device => device.DisplayName == cbVideoInputDevice.SelectedValue.ToString());
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.FirstOrDefault(format => format.Name == cbVideoInputFormat.SelectedValue.ToString());
                if (videoFormat == null)
                {
                    return;
                }

                // build int range from tuple (min, max)    
                var frameRateList = videoFormat.GetFrameRateRangeAsStringList();
                foreach (var item in frameRateList)
                {
                    cbVideoInputFrameRate.Items.Add(item);
                }

                if (cbVideoInputFrameRate.Items.Count > 0)
                {
                    cbVideoInputFrameRate.SelectedIndex = 0;
                }
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            edLog.Clear();

            CreateEngine();

              // video source
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            var deviceName = cbVideoInputDevice.Text;
            var format = cbVideoInputFormat.Text;
            if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
            {
                var device = (await _deviceEnumerator.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                    if (formatItem != null)
                    {
                        videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                        {
                            Format = formatItem.ToFormat()
                        };

                        videoSourceSettings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoInputFrameRate.Text));
                    }
                }
            }

            _videoCapture.Video_Source = videoSourceSettings;

            // enable overlay manager
            _videoCapture.Video_Overlay_Enabled = true;

            await _videoCapture.StartAsync();

            _timer.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            if (_videoCapture != null)
            {
                await _videoCapture.StopAsync();
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btStop_Click(null, null);

            await DestroyEngineAsync();

            _deviceEnumerator?.Dispose();
        }

        private void btAddImage_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                if (dlg.FileName.ToLowerInvariant().EndsWith(".gif"))
                {
                    
                    _videoCapture.Video_Overlay_Add(new OverlayManagerGIF(dlg.FileName, new SkiaSharp.SKPoint(150, 150)));
                    lbOverlays.Items.Add($"[GIF] {dlg.FileName}");
                }
                else
                {
                    _videoCapture.Video_Overlay_Add(new OverlayManagerImage(dlg.FileName, 100, 100));
                    lbOverlays.Items.Add($"[Image] {dlg.FileName}");
                }
            }
        }

        private void btAddText_Click(object sender, RoutedEventArgs e)
        {
            var text = new OverlayManagerText("Hello world!", 100, 100);
            text.Color = SkiaSharp.SKColors.Red;
            text.Font.Size = 32;
            text.Font.Style = VisioForge.Core.Types.X.VideoEffects.FontStyle.Italic;
            _videoCapture.Video_Overlay_Add(text);
            lbOverlays.Items.Add($"[Text] {text.Text}");
        }

        private void btAddLine_Click(object sender, RoutedEventArgs e)
        {
            var line = new OverlayManagerLine(new SkiaSharp.SKPoint(100, 100), new SkiaSharp.SKPoint(200, 200));
            line.Color = SkiaSharp.SKColors.Red;
            _videoCapture.Video_Overlay_Add(line);
            lbOverlays.Items.Add($"[Line] {line.Start.X}x{line.Start.Y} - {line.End.X}x{line.End.Y}");
        }

        private void btAddRectangle_Click(object sender, RoutedEventArgs e)
        {
            var rect = new OverlayManagerRectangle(new SkiaSharp.SKRect(100, 100, 200, 200));
            rect.Color = SkiaSharp.SKColors.Red;
            _videoCapture.Video_Overlay_Add(rect);
            lbOverlays.Items.Add($"[Rectangle] {rect.Rectangle.Left}x{rect.Rectangle.Top} - {rect.Rectangle.Right}x{rect.Rectangle.Bottom}");
        }

        private void btAddCircle_Click(object sender, RoutedEventArgs e)
        {
            var circle = new OverlayManagerCircle(new SkiaSharp.SKPoint(150, 150), 50);
            circle.Color = SkiaSharp.SKColors.Red;
            _videoCapture.Video_Overlay_Add(circle);
            lbOverlays.Items.Add($"[Circle] {circle.Center.X}x{circle.Center.Y} - {circle.Radius}");
        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbOverlays.SelectedIndex != -1)
            {
                _videoCapture.Video_Overlay_RemoveAt(lbOverlays.SelectedIndex);
                lbOverlays.Items.RemoveAt(lbOverlays.SelectedIndex);
            }
        }
    }
}
