using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Sources;

namespace MediaBlocks_Barcode_Detection_Demo_WPF
{
    public class BarcodeInfo : INotifyPropertyChanged
    {
        private string _type;
        private string _value;
        private string _timestamp;

        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public string Timestamp
        {
            get => _timestamp;
            set
            {
                _timestamp = value;
                OnPropertyChanged(nameof(Timestamp));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;
        private VideoRendererBlock _videoRenderer;
        private SystemVideoSourceBlock _videoSource;
        private BarcodeDetectorBlock _barcodeDetector;
        private System.Timers.Timer _timer;
        private ObservableCollection<BarcodeInfo> _barcodes = new ObservableCollection<BarcodeInfo>();
        private int _detectionCount = 0;

        public MainWindow()
        {
            InitializeComponent();
            lbBarcodes.ItemsSource = _barcodes;
        }

        private void DeviceEnumerator_OnVideoSourceAdded(object sender, VideoCaptureDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbVideoInput.Items.Add(e.DisplayName);

                if (cbVideoInput.Items.Count == 1)
                {
                    cbVideoInput.SelectedIndex = 0;
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

            DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;

            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
            _pipeline.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            mmLog.Clear();

            if (cbVideoInput.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Select video input device");
                return;
            }

            // video source
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            var deviceName = cbVideoInput.Text;
            var format = cbVideoFormat.Text;
            if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
            {
                var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                if (device != null)
                {
                    var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                    if (formatItem != null)
                    {
                        videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                        {
                            Format = formatItem.ToFormat()
                        };

                        videoSourceSettings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.Text));
                    }
                }
            }

            _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };

            // connect pipeline
            _barcodeDetector = new BarcodeDetectorBlock(BarcodeDetectorMode.InputOutput);
            _barcodeDetector.OnBarcodeDetected += BarcodeDetector_OnBarcodeDetected;

            _pipeline.Connect(_videoSource.Output, _barcodeDetector.Input);
            _pipeline.Connect(_barcodeDetector.Output, _videoRenderer.Input);

            // start
            await _pipeline.StartAsync();

            _timer.Start();
        }

        private void BarcodeDetector_OnBarcodeDetected(object sender, BarcodeDetectorEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                var barcodeInfo = new BarcodeInfo
                {
                    Type = e.BarcodeType,
                    Value = e.Value,
                    Timestamp = DateTime.Now.ToString("HH:mm:ss.fff")
                };

                _barcodes.Insert(0, barcodeInfo);

                // Keep only last 100 barcodes
                if (_barcodes.Count > 100)
                {
                    _barcodes.RemoveAt(_barcodes.Count - 1);
                }

                _detectionCount++;
                lbDetectionCount.Text = $"Barcodes detected: {_detectionCount}";

                mmLog.Text = mmLog.Text + $"[{barcodeInfo.Timestamp}] {e.BarcodeType}: {e.Value}" + Environment.NewLine;
            });
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            await _pipeline?.StopAsync();

            if (_barcodeDetector != null)
            {
                _barcodeDetector.OnBarcodeDetected -= BarcodeDetector_OnBarcodeDetected;
            }

            _pipeline?.ClearBlocks();

            VideoView1.CallRefresh();
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.PauseAsync();
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await _pipeline.ResumeAsync();
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

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();

                _pipeline.OnError -= Pipeline_OnError;

                if (_barcodeDetector != null)
                {
                    _barcodeDetector.OnBarcodeDetected -= BarcodeDetector_OnBarcodeDetected;
                }

                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            VisioForgeX.DestroySDK();
        }

        private async void cbVideoInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbVideoInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                var deviceName = (string)e.AddedItems[0];

                if (!string.IsNullOrEmpty(deviceName))
                {
                    cbVideoFormat.Items.Clear();

                    var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                    if (device != null)
                    {
                        foreach (var item in device.VideoFormats)
                        {
                            cbVideoFormat.Items.Add(item.Name);
                        }

                        if (cbVideoFormat.Items.Count > 0)
                        {
                            cbVideoFormat.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        private async void cbVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbVideoFrameRate.Items.Clear();

            if (cbVideoInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                var deviceName = cbVideoInput.SelectedValue?.ToString();
                var format = (string)e.AddedItems[0];
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                    if (device != null)
                    {
                        var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                        if (formatItem != null)
                        {
                            // build int range from tuple (min, max)    
                            var frameRateList = formatItem.GetFrameRateRangeAsStringList();
                            foreach (var item in frameRateList)
                            {
                                cbVideoFrameRate.Items.Add(item);
                            }

                            if (cbVideoFrameRate.Items.Count > 0)
                            {
                                cbVideoFrameRate.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
        }

        private void btClearBarcodes_Click(object sender, RoutedEventArgs e)
        {
            _barcodes.Clear();
            _detectionCount = 0;
            lbDetectionCount.Text = "Barcodes detected: 0";
        }
    }
}