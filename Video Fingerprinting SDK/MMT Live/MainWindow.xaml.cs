using System.Collections.Concurrent;
using System.Threading;


namespace VisioForge_MMT_Live
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using VisioForge.Core;
    using VisioForge.Core.Helpers;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.VideoCaptureX;
    using VisioForge.Core.VideoFingerPrinting;
    using VisioForge.Libs.WinAPI;
    using Rect = VisioForge.Core.Types.Rect;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IDisposable
    {
        private FingerprintLiveData _searchLiveData;

        private FingerprintLiveData _searchLiveOverlapData;

        private ConcurrentQueue<FingerprintLiveData> _fingerprintQueue;

        private IntPtr _tempBuffer;

        private List<VFPFingerPrint> _adVFPList;

        private List<DetectedAd> _results;

        private List<Rect> _ignoredAreas;

        private long _fragmentDuration;

        private int _fragmentCount;

        private int _overlapFragmentCount;

        private object _processingLock;

        private readonly VideoCaptureCoreX _videoCapture;

        private readonly FrameSource _videoPlayer;

        private bool _stopFlag;

        public MainWindow()
        {
            InitializeComponent();

            _videoPlayer = new FrameSource();
            _videoPlayer.OnVideoFrame += VideoCapture1_OnVideoFrameBuffer;
            _videoPlayer.OnError += VideoCapture1_OnError;

            _videoCapture = new VideoCaptureCoreX();
            _videoCapture.OnVideoFrameBuffer += VideoCapture1_OnVideoFrameBuffer;
            _videoCapture.OnError += VideoCapture1_OnError;
        }

        private void btAddAdFolder_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.FolderBrowserDialog
            {
                SelectedPath = Settings.LastPath
            };

            System.Windows.Forms.DialogResult result = dlg.ShowDialog(this.GetIWin32Window());

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                var files = FileScanner.SearchVideoInFolder(dlg.SelectedPath);
                foreach (var file in files)
                {
                    lbAdFiles.Items.Add(file);
                }
                
                Settings.LastPath = dlg.SelectedPath;
            }
        }

        private void btClearAds_Click(object sender, RoutedEventArgs e)
        {
            lbAdFiles.Items.Clear();
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btStart.Content == "Stop")
            {
                _stopFlag = true;

                Thread.Sleep(500);

                _videoCapture?.Stop();

                Thread.Sleep(500);

                ProcessVideoDelegateMethod();

                btStart.Content = "Start";

                lbStatus.Content = string.Empty;

                if (_tempBuffer != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(_tempBuffer);
                    _tempBuffer = IntPtr.Zero;
                }

                pnScreen.BeginInit();
                pnScreen.Source = null;
                pnScreen.EndInit();
            }
            else
            {
                _stopFlag = false;

                btStart.IsEnabled = false;
                
                lbStatus.Content = "Step 1: Searching video files";
                
                _fragmentCount = 0;
                _overlapFragmentCount = 0;

                var adList = new List<string>();

                _adVFPList = new List<VFPFingerPrint>();
                
                foreach (string item in lbAdFiles.Items)
                {
                    adList.Add(item);
                }

                lbStatus.Content = "Step 2: Getting fingerprints for ads files";

                if (adList.Count == 0)
                {
                    btStart.Content = "Start";
                    lbStatus.Content = string.Empty;
                    btStart.IsEnabled = true;

                    MessageBox.Show("Ads list is empty!");
                    
                    return;
                }

                int progress = 0;
                foreach (string filename in adList)
                {
                    pbProgress.Value = progress;
                    string error = "";
                    VFPFingerPrint fp;

                    if (File.Exists(filename + ".vfsigx"))
                    {
                        fp = VFPFingerPrint.Load(filename + ".vfsigx");
                    }
                    else
                    {
                        var source = new VFPFingerprintSource(filename);
                        foreach (var area in _ignoredAreas)
                        {
                            source.IgnoredAreas.Add(area);
                        }

                        fp = await VFPAnalyzer.GetSearchFingerprintForVideoFileAsync(source, ErrorCallback);
                    }
                    
                    if (fp == null)
                    {
                        MessageBox.Show("Unable to get fingerprint for video file: " + filename + ". Error: " + error);
                    }
                    else
                    {
                        fp.Save(filename + ".vfsigx");
                        _adVFPList.Add(fp);
                    }

                    progress += 100 / adList.Count;
                }

                int fragmentDurationProperty = Convert.ToInt32(edFragmentDuration.Text);
                if (fragmentDurationProperty != 0)
                {
                    _fragmentDuration = fragmentDurationProperty * 1000;
                }
                else
                {
                    var maxDuration = _adVFPList.Max((print => print.Duration));
                    long minfragmentDuration = ((((long)maxDuration.TotalMilliseconds + 1000) / 1000) + 1) * 1000;
                    _fragmentDuration = minfragmentDuration * 2;
                }

                pbProgress.Value = 100;
                
                if (_tempBuffer != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(_tempBuffer);
                    _tempBuffer = IntPtr.Zero;
                }

                lbStatus.Content = "Step 3: Starting video preview";

                if (cbSource.SelectedIndex == 0)
                {
                    var device = (await _videoCapture.Video_SourcesAsync()).Where(s => s.Name == cbVideoSource.Text).FirstOrDefault();
                    var format = device.VideoFormats.Where(f => f.Name == cbVideoFormat.Text).FirstOrDefault();

                    if (format == null)
                    {
                        MessageBox.Show("Camera format not found.");
                        return;
                    }

                    var videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                    {
                        Format = format.ToFormat()
                    };

                    videoSourceSettings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.Text));


                    _videoCapture.Video_Source = videoSourceSettings;

                    _videoCapture.Start();
                }
                else
                {
                    string url = edNetworkSourceURL.Text;
                    //var ip = new IPCameraSourceSettings
                    //             {
                    //                 URL =,
                    //                 Login = edNetworkSourceLogin.Text,
                    //                 Password = edNetworkSourcePassword.Text
                    //             };

                    var sourceSettings = await UniversalSourceSettings.CreateAsync(url);
                    await _videoPlayer.PlayAsync(sourceSettings);
                }

                lbStatus.Content = "Step 4: Getting data";

                pbProgress.Value = 0;

                lvResults.Items.Refresh();

                btStart.IsEnabled = true;
                btStart.Content = "Stop";
            }
        }

        #region List view

        private ObservableCollection<ResultsViewModel> resultsView = new ObservableCollection<ResultsViewModel>();

        public ObservableCollection<ResultsViewModel> ResultsView
        {
            get
            {
                return resultsView;
            }
        }

        #endregion

        private void btSaveResults_Click(object sender, RoutedEventArgs e)
        {
            string xml = XmlUtility.Obj2XmlStr(resultsView);

            var dlg = new System.Windows.Forms.SaveFileDialog
            {
                Filter = @"XML file|*.xml"
            };

            var result = dlg.ShowDialog(this.GetIWin32Window());

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string filename = dlg.FileName;

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                if (!File.Exists(filename))
                {
                    // Create a file to write to.
                    using (var sw = File.CreateText(filename))
                    {
                        sw.WriteLine(xml);
                    }
                }
            }
        }

        private void SaveSettings()
        {
            string filename = Settings.SettingsFolder + "settings.xml";

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            if (!Directory.Exists(Settings.SettingsFolder))
            {
                Directory.CreateDirectory(Settings.SettingsFolder);
            }

            Settings.Save(typeof(Settings), filename);
        }

        private void LoadSettings()
        {
            string filename = Settings.SettingsFolder + "settings.xml";

            if (File.Exists(filename))
            {
                Settings.Load(typeof(Settings), filename);
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSettings();

            foreach (var item in await _videoCapture.Video_SourcesAsync())
            {
                cbVideoSource.Items.Add(item.Name);
            }

            if (cbVideoSource.Items.Count > 0)
            {
                cbVideoSource.SelectedIndex = 0;
                cbVideoSource_SelectionChanged(null, null);
            }

            _fingerprintQueue = new ConcurrentQueue<FingerprintLiveData>();

            _processingLock = new object();
            _results = new List<DetectedAd>();
            _ignoredAreas = new List<Rect>();
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            edLog.Text += e.Message + Environment.NewLine;
        }

        [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        private static extern void CopyMemory(IntPtr dest, IntPtr src, int length);

        private delegate void ProcessVideoDelegate();

        private void ProcessVideoDelegateMethod()
        {
            lock (_processingLock)
            {
                //if (VideoCapture1.Status == VFVideoCaptureStatus.Free)
                //{
                //    return;
                //}

                //// done. searching for fingerprints.
                //VideoCapture1.Stop();

                long n;
                FingerprintLiveData fingerprint = null;

                if (_fingerprintQueue.TryDequeue(out fingerprint))
                {
                    IntPtr p = VFPSearch.Build(out n, ref fingerprint.Data);

                    VFPFingerPrint fvp = new VFPFingerPrint()
                    {
                        Data = new byte[n],
                        OriginalFilename = string.Empty
                    };

                    Marshal.Copy(p, fvp.Data, 0, (int) n);

                    foreach (var ad in _adVFPList)
                    {
                        var positions = VFPAnalyzer.Search(ad, fvp, ad.Duration, (int)slDifference.Value, true);

                        if (positions.Count > 0)
                        {
                            foreach (var pos in positions)
                            {
                                DateTime tm = fingerprint.StartTime.AddMilliseconds(pos.TotalMilliseconds);

                                bool duplicate = false;
                                foreach (var detectedAd in _results)
                                {
                                    long time = 0;

                                    if (detectedAd.Timestamp > tm)
                                    {
                                        time = (long)(detectedAd.Timestamp - tm).TotalMilliseconds;
                                    }
                                    else
                                    {
                                        time = (long)(tm - detectedAd.Timestamp).TotalMilliseconds;
                                    }

                                    if (time < 1000)
                                    {
                                        // duplicate
                                        duplicate = true;
                                        break;
                                    }
                                }

                                if (duplicate)
                                {
                                    break;
                                }

                                _results.Add(new DetectedAd(tm));
                                resultsView.Add(
                                    new ResultsViewModel()
                                    {
                                        Sample = ad.OriginalFilename,
                                        TimeStamp = tm.ToString("HH:mm:ss.fff"),
                                        TimeStampMS = tm - new DateTime(1970, 1, 1)
                                    });
                            }
                        }
                    }

                    fingerprint.Data.Free();
                    fingerprint.Dispose();
                }
            }
        }

        private WriteableBitmap _frameBitmap;

        private bool _frameStopped;

        private delegate void NewFrameDelegate(VideoFrameXBufferEventArgs e);

        private void NewFrameDelegateMethod(VideoFrameXBufferEventArgs e)
        {
            if (_stopFlag)
            {
                return;
            }

            try
            {
                if (pnScreen == null)
                {
                    return;
                }

                if (_frameStopped)
                {
                    return;
                }

                if (_frameBitmap == null || _frameBitmap.PixelWidth != e.Frame.Width || _frameBitmap.PixelHeight != e.Frame.Height)
                {
                    _frameBitmap = new WriteableBitmap(e.Frame.Width, e.Frame.Height, 72, 72, PixelFormats.Bgr24, null);

                    pnScreen.BeginInit();
                    pnScreen.Source = _frameBitmap;
                    pnScreen.EndInit();
                }

                pnScreen.BeginInit();

                if (pnScreen.Source == null)
                {
                    pnScreen.Source = _frameBitmap;
                }

                int lineStep = (((e.Frame.Width * 24) + 31) / 32) * 4;
                _frameBitmap.WritePixels(new Int32Rect(0, 0, e.Frame.Width, e.Frame.Height), e.Frame.Data, (int)e.Frame.DataSize, lineStep);
                pnScreen.EndInit();
            }
            catch
            {
            }
        }


        private void VideoCapture1_OnVideoFrameBuffer(object sender, VideoFrameXBufferEventArgs e)
        {
            try
            {
                if (_stopFlag)
                {
                    return;
                }

                Dispatcher.BeginInvoke(new NewFrameDelegate(NewFrameDelegateMethod), e);
                
                if (_tempBuffer == IntPtr.Zero)
                {
                    _tempBuffer = Marshal.AllocCoTaskMem(ImageHelper.GetStrideRGB24(e.Frame.Width) * e.Frame.Height);
                }

                // live
                if (_searchLiveData == null)
                {
                    _searchLiveData = new FingerprintLiveData(TimeSpan.FromMilliseconds(_fragmentDuration), DateTime.Now);
                    _fragmentCount++;
                }

                long timestamp = (long)(e.Frame.Timestamp.TotalMilliseconds * 1000);
                if (timestamp < _fragmentDuration * _fragmentCount)
                {
                    Win32API.CopyMemory(_tempBuffer, e.Frame.Data, e.Frame.DataSize);

                    // process frame to remove ignored areas
                    if (_ignoredAreas.Count > 0)
                    {
                        foreach (var area in _ignoredAreas)
                        {
                            if (area.Right > e.Frame.Width || area.Bottom > e.Frame.Height)
                            {
                                continue;
                            }

                            FastImageProcessing.FillColor(_tempBuffer, e.Frame.Width, e.Frame.Height, area.ToRectIntl(), 0);
                        }
                    }

                    var correctedTimestamp = timestamp - _fragmentDuration * (_fragmentCount - 1);
                    VFPSearch.Process(_tempBuffer, e.Frame.Width, e.Frame.Height, ImageHelper.GetStrideRGB24(e.Frame.Width), TimeSpan.FromMilliseconds(correctedTimestamp), ref _searchLiveData.Data);
                    Debug.WriteLine(TimeSpan.FromMilliseconds(correctedTimestamp));
                }
                else
                {
                    _fingerprintQueue.Enqueue(_searchLiveData);

                    _searchLiveData = null;

                    Dispatcher.BeginInvoke(new ProcessVideoDelegate(ProcessVideoDelegateMethod));
                }

                // overlap
                if (timestamp < _fragmentDuration / 2)
                {
                    return;
                }

                if (_searchLiveOverlapData == null)
                {
                    _searchLiveOverlapData = new FingerprintLiveData(TimeSpan.FromSeconds(_fragmentDuration), DateTime.Now);
                    _overlapFragmentCount++;
                }

                if (timestamp < _fragmentDuration * _overlapFragmentCount + _fragmentDuration / 2)
                {
                    Win32API.CopyMemory(_tempBuffer, e.Frame.Data, e.Frame.DataSize);
                    VFPSearch.Process(_tempBuffer, e.Frame.Width, e.Frame.Height, ImageHelper.GetStrideRGB24(e.Frame.Width), TimeSpan.FromMilliseconds(timestamp), ref _searchLiveOverlapData.Data);
                }
                else
                {
                    _fingerprintQueue.Enqueue(_searchLiveOverlapData);

                    _searchLiveOverlapData = null;

                    Dispatcher.BeginInvoke(new ProcessVideoDelegate(ProcessVideoDelegateMethod));
                }
            }
            catch
            {
            }
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        private async void cbVideoSource_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            string val = e.AddedItems[0].ToString();
            if (string.IsNullOrEmpty(val))
            {
                return;
            }

            var device = (await _videoCapture.Video_SourcesAsync()).Where(s => s.Name == val).FirstOrDefault();

            // enumerate video formats
            cbVideoFormat.Items.Clear();

            foreach (var format in device.VideoFormats)
            {
                cbVideoFormat.Items.Add(format.Name);
            }

            if (cbVideoFormat.Items.Count > 0)
            {
                cbVideoFormat.SelectedIndex = 0;
            }
        }

        private async void cbVideoFormat_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            string val = e.AddedItems[0].ToString();
            if (string.IsNullOrEmpty(val))
            {
                return;
            }

            var device = (await _videoCapture.Video_SourcesAsync()).Where(s => s.Name == cbVideoSource.Text).FirstOrDefault();
            if (device == null)
            {
                return;
            }

            var format = device.VideoFormats.Where(f => f.Name == val).FirstOrDefault();
            if (format == null)
            {
                return;
            }

            // enumerate video frame rates
            cbVideoFrameRate.Items.Clear();

            foreach (var frameRate in format.FrameRateList)
            {
                cbVideoFrameRate.Items.Add(frameRate);
            }

            if (cbVideoFrameRate.Items.Count > 0)
            {
                cbVideoFrameRate.SelectedIndex = 0;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSettings();
        }

        #region Dispose

        /// <summary>
        /// Dispose flag.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Finalizes an instance of the <see cref="MainWindow"/> class. 
        /// </summary>
        ~MainWindow()
        {
            Dispose(false);
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="disposing">
        /// Disposing parameter.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }

                // Free your own state (unmanaged objects).
                // Set large fields to null.

                if (_searchLiveData != null)
                {
                    _searchLiveData.Dispose();
                    _searchLiveData = null;
                }

                if (_searchLiveOverlapData != null)
                {
                    _searchLiveOverlapData.Dispose();
                    _searchLiveOverlapData = null;
                }

                VisioForgeX.DestroySDK();

                disposed = true;
            }
        }

        #endregion

        private void btIgnoredAreaAdd_Click(object sender, RoutedEventArgs e)
        {
            var rect = new Rect()
            {
                Left = Convert.ToInt32(edIgnoredAreaLeft.Text),
                Top = Convert.ToInt32(edIgnoredAreaTop.Text),
                Right = Convert.ToInt32(edIgnoredAreaRight.Text),
                Bottom = Convert.ToInt32(edIgnoredAreaBottom.Text)
            };

            _ignoredAreas.Add(rect);
            lbIgnoredAreas.Items.Add($"Left: {rect.Left}, Top: {rect.Top}, Right: {rect.Right}, Bottom: {rect.Bottom}");
        }

        private void btIgnoredAreasRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            int index = lbIgnoredAreas.SelectedIndex;
            if (index >= 0)
            {
                lbIgnoredAreas.Items.RemoveAt(index);
                _ignoredAreas.RemoveAt(index);
            }
        }

        private void btIgnoredAreasRemoveAll_Click(object sender, RoutedEventArgs e)
        {
            lbIgnoredAreas.Items.Clear();
            _ignoredAreas.Clear();
        }

        private void btSortResults_Click(object sender, RoutedEventArgs e)
        {
            resultsView = new ObservableCollection<ResultsViewModel>(resultsView.OrderBy(i => i.TimeStampMS.TotalMilliseconds));
            lvResults.ItemsSource = resultsView;
        }

        private void BtAddAdFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.OpenFileDialog
            {
                InitialDirectory = Settings.LastPath,
                Multiselect = true
            };

            System.Windows.Forms.DialogResult result = dlg.ShowDialog(this.GetIWin32Window());

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var name in dlg.FileNames)
                {
                    this.lbAdFiles.Items.Add(name);
                }

                Settings.LastPath = Path.GetFullPath(dlg.FileNames[0]);
            }
        }

        private void ErrorCallback(string error)
        {
            Dispatcher.Invoke(() =>
            {
                MessageBox.Show(this, error);
            });
        }
    }
}
