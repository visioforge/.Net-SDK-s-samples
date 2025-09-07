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
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Sources;

namespace MediaBlocks_DataMatrix_Detection_Demo_WPF
{
    public class DataMatrixInfo : INotifyPropertyChanged
    {
        private string _value;
        private string _timestamp;
        private long _frameNumber;
        private int _rows;
        private int _cols;
        private string _topLeft;
        private string _topRight;
        private string _bottomLeft;
        private string _bottomRight;

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

        public long FrameNumber
        {
            get => _frameNumber;
            set
            {
                _frameNumber = value;
                OnPropertyChanged(nameof(FrameNumber));
            }
        }

        public int Rows
        {
            get => _rows;
            set
            {
                _rows = value;
                OnPropertyChanged(nameof(Rows));
            }
        }

        public int Cols
        {
            get => _cols;
            set
            {
                _cols = value;
                OnPropertyChanged(nameof(Cols));
            }
        }

        public string TopLeft
        {
            get => _topLeft;
            set
            {
                _topLeft = value;
                OnPropertyChanged(nameof(TopLeft));
            }
        }

        public string TopRight
        {
            get => _topRight;
            set
            {
                _topRight = value;
                OnPropertyChanged(nameof(TopRight));
            }
        }

        public string BottomLeft
        {
            get => _bottomLeft;
            set
            {
                _bottomLeft = value;
                OnPropertyChanged(nameof(BottomLeft));
            }
        }

        public string BottomRight
        {
            get => _bottomRight;
            set
            {
                _bottomRight = value;
                OnPropertyChanged(nameof(BottomRight));
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
        private DataMatrixDecoderBlock _dataMatrixDecoder;
        private System.Timers.Timer _timer;
        private ObservableCollection<DataMatrixInfo> _dataMatrixCodes = new ObservableCollection<DataMatrixInfo>();
        private int _detectionCount = 0;

        public MainWindow()
        {
            InitializeComponent();
            lbDataMatrixCodes.ItemsSource = _dataMatrixCodes;
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
            // Check if DataMatrix detection is available
            //if (!DataMatrixDecoderBlock.IsAvailable())
            //{
            //    MessageBox.Show(this, "DataMatrix detection is not available. Please ensure LibDMTX is installed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    Close();
            //    return;
            //}

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

            // DataMatrix decoder with passthrough for video preview
            _dataMatrixDecoder = new DataMatrixDecoderBlock(true, VideoFormatX.RGBA);
            
            // Configure DataMatrix decoder settings
            _dataMatrixDecoder.FrameSkip = (int)slFrameSkip.Value;
            _dataMatrixDecoder.DecodeTimeoutMs = (int)slTimeout.Value;
            _dataMatrixDecoder.MaxCodes = (int)slMaxCodes.Value;
            _dataMatrixDecoder.EnableDebugLogging = cbDebugLogging.IsChecked == true;
            
            // Subscribe to DataMatrix detection events
            _dataMatrixDecoder.OnDataMatrixDetected += DataMatrixDecoder_OnDataMatrixDetected;

            // connect pipeline
            _pipeline.Connect(_videoSource.Output, _dataMatrixDecoder.Input);
            _pipeline.Connect(_dataMatrixDecoder.Output, _videoRenderer.Input);

            // start
            await _pipeline.StartAsync();

            _timer.Start();
        }

        private void DataMatrixDecoder_OnDataMatrixDetected(object sender, DataMatrixDecoderEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                var dataMatrixInfo = new DataMatrixInfo
                {
                    Value = e.DecodedText,
                    Timestamp = e.Timestamp.ToString(@"hh\:mm\:ss\.fff"),
                    FrameNumber = e.FrameNumber,
                    Rows = e.SymbolInfo?.Rows ?? 0,
                    Cols = e.SymbolInfo?.Cols ?? 0
                };

                // Set corner positions if available
                if (e.Corners != null)
                {
                    if (e.Corners.Corner0 != null)
                        dataMatrixInfo.TopLeft = $"{e.Corners.Corner0.X:F0},{e.Corners.Corner0.Y:F0}";
                    if (e.Corners.Corner1 != null)
                        dataMatrixInfo.TopRight = $"{e.Corners.Corner1.X:F0},{e.Corners.Corner1.Y:F0}";
                    if (e.Corners.Corner2 != null)
                        dataMatrixInfo.BottomLeft = $"{e.Corners.Corner2.X:F0},{e.Corners.Corner2.Y:F0}";
                    if (e.Corners.Corner3 != null)
                        dataMatrixInfo.BottomRight = $"{e.Corners.Corner3.X:F0},{e.Corners.Corner3.Y:F0}";
                }

                _dataMatrixCodes.Insert(0, dataMatrixInfo);

                // Keep only last 100 DataMatrix codes
                if (_dataMatrixCodes.Count > 100)
                {
                    _dataMatrixCodes.RemoveAt(_dataMatrixCodes.Count - 1);
                }

                _detectionCount++;
                lbDetectionCount.Text = $"DataMatrix codes detected: {_detectionCount}";
                
                // Display last detection with proper length check
                var displayValue = dataMatrixInfo.Value ?? string.Empty;
                if (displayValue.Length > 50)
                {
                    lbLastDetection.Text = $"Last: {displayValue.Substring(0, 50)}...";
                }
                else
                {
                    lbLastDetection.Text = $"Last: {displayValue}";
                }

                mmLog.Text = mmLog.Text + $"[{dataMatrixInfo.Timestamp}] DataMatrix ({dataMatrixInfo.Rows}x{dataMatrixInfo.Cols}): {e.DecodedText}" + Environment.NewLine;
            });
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            await _pipeline?.StopAsync();

            if (_dataMatrixDecoder != null)
            {
                _dataMatrixDecoder.OnDataMatrixDetected -= DataMatrixDecoder_OnDataMatrixDetected;
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
            _timer?.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();

                _pipeline.OnError -= Pipeline_OnError;

                if (_dataMatrixDecoder != null)
                {
                    _dataMatrixDecoder.OnDataMatrixDetected -= DataMatrixDecoder_OnDataMatrixDetected;
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

        private void btClearDataMatrix_Click(object sender, RoutedEventArgs e)
        {
            _dataMatrixCodes.Clear();
            _detectionCount = 0;
            lbDetectionCount.Text = "DataMatrix codes detected: 0";
            lbLastDetection.Text = "";
        }

        private void slFrameSkip_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbFrameSkipValue != null)
            {
                lbFrameSkipValue.Content = ((int)e.NewValue).ToString();
                
                if (_dataMatrixDecoder != null)
                {
                    _dataMatrixDecoder.FrameSkip = (int)e.NewValue;
                }
            }
        }

        private void slTimeout_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbTimeoutValue != null)
            {
                lbTimeoutValue.Content = ((int)e.NewValue).ToString();
                
                if (_dataMatrixDecoder != null)
                {
                    _dataMatrixDecoder.DecodeTimeoutMs = (int)e.NewValue;
                }
            }
        }

        private void slMaxCodes_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbMaxCodesValue != null)
            {
                lbMaxCodesValue.Content = ((int)e.NewValue).ToString();
                
                if (_dataMatrixDecoder != null)
                {
                    _dataMatrixDecoder.MaxCodes = (int)e.NewValue;
                }
            }
        }
    }
}