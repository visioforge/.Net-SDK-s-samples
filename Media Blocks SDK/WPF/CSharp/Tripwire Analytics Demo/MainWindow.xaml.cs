using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using SkiaSharp;
using VisioForge.Core;
using VisioForge.Core.AI;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.VideoProcessing;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

namespace Tripwire_Analytics_Demo
{
    public partial class MainWindow : Window
    {
        // ---- model download infrastructure ----
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

        private static readonly string ModelsCacheDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "VisioForge", "models");

        private static readonly HttpClient _http = new HttpClient
        {
            Timeout = TimeSpan.FromMinutes(5)
        };

        static MainWindow()
        {
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("VisioForge-Tripwire-Demo/1.0");
        }

        private sealed class ModelPreset
        {
            public string Name;
            public string Tag;
            public ObjectDetectorModel Family;
            public string DownloadUrl;
            public string FileName;
            public bool IsLocal;
            public string LocalPath;
        }

        private List<ModelPreset> _modelPresets;
        private ModelPreset _selectedPreset;

        private List<ModelPreset> BuildModelList()
        {
            Directory.CreateDirectory(ModelsCacheDir);
            var list = new List<ModelPreset>();

            var bundled = Path.Combine(AppContext.BaseDirectory, "yolox_nano.onnx");
            list.Add(new ModelPreset
            {
                Name = File.Exists(bundled) ? "YOLOX Nano (bundled)" : "YOLOX Nano (bundled — MISSING)",
                Tag = "yolox-bundled", Family = ObjectDetectorModel.YOLOX,
                IsLocal = File.Exists(bundled), LocalPath = bundled, FileName = "yolox_nano.onnx"
            });

            AddDownloadable(list, "RT-DETR R18vd", "rtdetr", "rtdetr_r18vd_fp16.onnx", ObjectDetectorModel.RTDETR);

            list.Add(new ModelPreset
            {
                Name = "Custom model...", Tag = "custom",
                Family = ObjectDetectorModel.YOLOX, IsLocal = false
            });

            return list;
        }

        private void AddDownloadable(List<ModelPreset> list, string name, string tag,
            string fileName, ObjectDetectorModel family)
        {
            var cachePath = Path.Combine(ModelsCacheDir, fileName);
            var isCached = File.Exists(cachePath);
            list.Add(new ModelPreset
            {
                Name = name,
                Tag = tag, Family = family,
                DownloadUrl = ModelsReleaseUrl + "/" + fileName,
                FileName = fileName,
                IsLocal = isCached, LocalPath = isCached ? cachePath : null
            });
        }

        private void RefreshModelList()
        {
            _modelPresets = BuildModelList();
            var selTag = _selectedPreset?.Tag;
            cbModel.Items.Clear();
            int selIdx = 0;
            for (int i = 0; i < _modelPresets.Count; i++)
            {
                var p = _modelPresets[i];
                cbModel.Items.Add(new ComboBoxItem { Content = p.Name, Tag = p.Tag });
                if (p.Tag == selTag) selIdx = i;
            }
            cbModel.SelectedIndex = selIdx;
        }

        private ModelPreset GetSelectedPreset()
        {
            var tag = ((cbModel.SelectedItem as ComboBoxItem)?.Tag as string) ?? "yolox-bundled";
            return _modelPresets.FirstOrDefault(p => p.Tag == tag) ?? _modelPresets[0];
        }

        // ---- pipeline fields ----
        private MediaBlocksPipeline _pipeline;
        private VideoRendererBlock _videoRenderer;
        private MediaBlock _videoSource;
        private ObjectAnalyticsBlock _analytics;
        private System.Windows.Threading.DispatcherTimer _timer;
        private bool _timerBusy;
        private VideoCaptureDeviceInfo[] _videoCaptureDevices;
        private bool _isClosing;
        private bool _uiBusy;

        public MainWindow() { InitializeComponent(); }

        // ---- pipeline events ----
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
            => Dispatcher.Invoke(() => mmLog.Text += e.Message + Environment.NewLine);

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_uiBusy || _isClosing) return;
                _timer?.Stop(); btStart.IsEnabled = true; btStop.IsEnabled = false;
            }));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                IsEnabled = false;
                try { await VisioForgeX.InitSDKAsync(); }
                finally { IsEnabled = true; Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", string.Empty); }

                _timer = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
                _timer.Tick += Timer_Tick;

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;
                _pipeline.OnStop += Pipeline_OnStop;
                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                _videoCaptureDevices = await SystemVideoSourceBlock.GetDevicesAsync() ?? Array.Empty<VideoCaptureDeviceInfo>();
                foreach (var item in _videoCaptureDevices) cbVideoInput.Items.Add(item.DisplayName);
                if (cbVideoInput.Items.Count > 0) cbVideoInput.SelectedIndex = 0;

                _modelPresets = BuildModelList();
                foreach (var p in _modelPresets) cbModel.Items.Add(new ComboBoxItem { Content = p.Name, Tag = p.Tag });
                cbModel.SelectedIndex = 0;

                var providers = OnnxInferenceEngine.GetAvailableProviders();
                mmLog.Text += "ONNX Runtime providers: " + string.Join(", ", providers) + Environment.NewLine;
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (_timerBusy) return; _timerBusy = true;
            try { if (_pipeline != null) lbTime.Text = (await _pipeline.Position_GetAsync()).ToString("hh\\:mm\\:ss"); }
            catch (Exception ex) { Debug.WriteLine(ex); }
            finally { _timerBusy = false; }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isClosing) return; e.Cancel = true; _isClosing = true; IsEnabled = false;
            try
            {
                _timer?.Stop();
                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    _pipeline.OnError -= Pipeline_OnError;
                    _pipeline.OnStop -= Pipeline_OnStop;
                    await _pipeline.DisposeAsync();
                    _pipeline = null;
                }
                CleanupBlocks(); VideoView1.CallRefresh(); VisioForgeX.DestroySDK();
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            try { Dispatcher.BeginInvoke(new Action(() => Close())); }
            catch (Exception ex) { Debug.WriteLine(ex); _isClosing = false; IsEnabled = true; }
        }

        // ---- source UI ----
        private void rbSource_Checked(object sender, RoutedEventArgs e)
        {
            if (pnlWebcam == null) return;
            pnlWebcam.Visibility = rbWebcam.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            pnlFile.Visibility = rbFile.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            pnlRTSP.Visibility = rbRTSP.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btSelectVideoFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "Video files|*.mp4;*.mkv;*.avi;*.mov;*.webm;*.ts|All files|*.*" };
            if (dlg.ShowDialog() == true) edVideoFile.Text = dlg.FileName;
        }

        private void btSelectModel_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "ONNX models|*.onnx|All files|*.*" };
            if (dlg.ShowDialog() == true) edModelFile.Text = dlg.FileName;
        }

        // ---- model selection ----
        private ObjectDetectorModel SelectedModelFamily() => _selectedPreset?.Family ?? ObjectDetectorModel.YOLOX;

        private void cbModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this.IsInitialized || cbModel.SelectedItem == null || _modelPresets == null) return;
            try
            {
                _selectedPreset = GetSelectedPreset();
                var needsDownload = _selectedPreset.DownloadUrl != null && !_selectedPreset.IsLocal;
                var isCustom = _selectedPreset.Tag == "custom";
                btDownloadModel.Visibility = needsDownload ? Visibility.Visible : Visibility.Collapsed;
                btSelectModel.Visibility = isCustom ? Visibility.Visible : Visibility.Collapsed;
                edModelFile.Visibility = isCustom ? Visibility.Visible : Visibility.Collapsed;
                if (_selectedPreset.IsLocal && _selectedPreset.LocalPath != null)
                    edModelFile.Text = _selectedPreset.LocalPath;
            }
            catch { }
        }

        private async void btDownloadModel_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedPreset?.DownloadUrl == null) return;
            Directory.CreateDirectory(ModelsCacheDir);
            var destPath = Path.Combine(ModelsCacheDir, _selectedPreset.FileName);

            btDownloadModel.IsEnabled = false;
            btDownloadModel.Content = "Downloading...";
            mmLog.Text += $"Downloading {_selectedPreset.Name}..." + Environment.NewLine;

            try
            {
                var bytes = await _http.GetByteArrayAsync(_selectedPreset.DownloadUrl);
                await File.WriteAllBytesAsync(destPath, bytes);
                edModelFile.Text = destPath;
                mmLog.Text += $"Saved to {ModelsCacheDir} ({bytes.Length / 1024 / 1024} MB)" + Environment.NewLine;
                RefreshModelList();
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(() => MessageBox.Show(this,
                    $"Download failed:\n{ex.Message}\n\nURL: {_selectedPreset.DownloadUrl}",
                    "Download Error", MessageBoxButton.OK, MessageBoxImage.Warning));
            }
            finally
            {
                btDownloadModel.IsEnabled = true;
                btDownloadModel.Content = "Download";
            }
        }

        // ---- video device selection ----
        private void cbVideoInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbVideoInput.SelectedIndex != -1 && e?.AddedItems.Count > 0)
                {
                    var device = _videoCaptureDevices?.FirstOrDefault(x => x.DisplayName == (string)e.AddedItems[0]);
                    if (device != null)
                    {
                        cbVideoFormat.Items.Clear();
                        foreach (var f in device.VideoFormats) cbVideoFormat.Items.Add(f.Name);
                        if (cbVideoFormat.Items.Count > 0) cbVideoFormat.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        private void cbVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbVideoFrameRate.Items.Clear();
                if (cbVideoInput.SelectedIndex != -1 && e?.AddedItems.Count > 0)
                {
                    var device = _videoCaptureDevices?.FirstOrDefault(x => x.DisplayName == cbVideoInput.SelectedValue.ToString());
                    if (device != null)
                    {
                        var fmt = device.VideoFormats.FirstOrDefault(x => x.Name == (string)e.AddedItems[0]);
                        if (fmt != null)
                        {
                            foreach (var r in fmt.GetFrameRateRangeAsStringList()) cbVideoFrameRate.Items.Add(r);
                            if (cbVideoFrameRate.Items.Count > 0) cbVideoFrameRate.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        // ---- source builder ----
        private async System.Threading.Tasks.Task<bool> BuildSourceAsync()
        {
            if (rbFile.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(edVideoFile.Text)) { MessageBox.Show(this, "Select a video file."); return false; }
                _videoSource = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(edVideoFile.Text, renderVideo: true, renderAudio: false));
                return true;
            }
            if (rbRTSP.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(edRTSPURL.Text) || edRTSPURL.Text.Trim() == "rtsp://") { MessageBox.Show(this, "Enter an RTSP URL."); return false; }
                _videoSource = new RTSPSourceBlock(await RTSPSourceSettings.CreateAsync(new Uri(edRTSPURL.Text.Trim()), edRTSPLogin.Text, edRTSPPassword.Password, audioEnabled: false));
                return true;
            }
            if (cbVideoInput.SelectedIndex < 0) { MessageBox.Show(this, "Select a video input device."); return false; }

            var device = _videoCaptureDevices?.FirstOrDefault(x => x.DisplayName == cbVideoInput.Text);
            var fmt = device?.VideoFormats.FirstOrDefault(x => x.Name == cbVideoFormat.Text);
            if (device == null || fmt == null) { MessageBox.Show(this, "Unable to configure video device."); return false; }
            var s = new VideoCaptureDeviceSourceSettings(device) { Format = fmt.ToFormat() };
            if (!string.IsNullOrEmpty(cbVideoFrameRate.Text))
                s.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.Text, CultureInfo.InvariantCulture));
            _videoSource = new SystemVideoSourceBlock(s);
            return true;
        }

        // ---- class filter ----
        private int[] GetClassIds()
        {
            var list = new List<int>();
            if (cbClassPerson.IsChecked == true) list.Add((int)CocoClass.Person);
            if (cbClassBicycle.IsChecked == true) list.Add((int)CocoClass.Bicycle);
            if (cbClassCar.IsChecked == true) list.Add((int)CocoClass.Car);
            if (cbClassMotorcycle.IsChecked == true) list.Add((int)CocoClass.Motorcycle);
            if (cbClassBus.IsChecked == true) list.Add((int)CocoClass.Bus);
            if (cbClassTruck.IsChecked == true) list.Add((int)CocoClass.Truck);
            if (cbClassDog.IsChecked == true) list.Add((int)CocoClass.Dog);
            if (cbClassCat.IsChecked == true) list.Add((int)CocoClass.Cat);
            return list.Count > 0 ? list.ToArray() : null;
        }

        private LineZoneSettings ParseLine(string id, string x1, string y1, string x2, string y2)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;
            if (!float.TryParse(x1, NumberStyles.Float, CultureInfo.InvariantCulture, out var px1)) return null;
            if (!float.TryParse(y1, NumberStyles.Float, CultureInfo.InvariantCulture, out var py1)) return null;
            if (!float.TryParse(x2, NumberStyles.Float, CultureInfo.InvariantCulture, out var px2)) return null;
            if (!float.TryParse(y2, NumberStyles.Float, CultureInfo.InvariantCulture, out var py2)) return null;
            return new LineZoneSettings
            {
                Id = id.Trim(),
                Start = new SKPoint(px1, py1), End = new SKPoint(px2, py2),
                Anchor = DetectionAnchor.BottomCenter,
                UseNormalizedCoordinates = true, DeadbandPixels = 5f,
            };
        }

        // ---- start / stop ----
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _uiBusy = true; btStart.IsEnabled = false;
                if (_pipeline == null) { MessageBox.Show(this, "SDK failed to initialize."); btStart.IsEnabled = true; return; }

                mmLog.Clear(); lbCrossings.Items.Clear();
                lbLine1In.Text = lbLine1Out.Text = lbLine2In.Text = lbLine2Out.Text = "0";

                try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); }
                catch (Exception ex) { Debug.WriteLine(ex); }
                CleanupBlocks();

                if (string.IsNullOrWhiteSpace(edModelFile.Text)) { MessageBox.Show(this, "Select a model."); btStart.IsEnabled = true; return; }
                if (!await BuildSourceAsync()) { btStart.IsEnabled = true; return; }

                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };

                var det = new YoloDetectorSettings(edModelFile.Text) { Model = SelectedModelFamily(), DrawDetections = false };
                if (float.TryParse(edConfidence.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var cf)) det.ConfidenceThreshold = cf;
                if (int.TryParse(edFramesToSkip.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var sk)) det.FramesToSkip = sk;

                var s = new ObjectAnalyticsSettings(det);
                s.Overlay.DrawBoxes = cbDrawBoxes.IsChecked == true;
                s.Overlay.DrawLabels = cbDrawLabels.IsChecked == true;
                s.Overlay.DrawTrackIds = cbDrawTrackIds.IsChecked == true;
                s.Overlay.DrawTraces = cbDrawTraces.IsChecked == true;
                s.Overlay.DrawLines = cbDrawLines.IsChecked == true;
                s.Overlay.DrawZoneCounts = true;
                s.Overlay.LineThickness = s.Overlay.BoxThickness = s.Overlay.TraceThickness = 5f;

                var cids = GetClassIds(); if (cids != null) s.Filter.IncludedClassIds = cids;

                var l1 = ParseLine(edLine1Id.Text, edLine1X1.Text, edLine1Y1.Text, edLine1X2.Text, edLine1Y2.Text);
                if (l1 != null) s.Lines.Add(l1);
                var l2 = ParseLine(edLine2Id.Text, edLine2X1.Text, edLine2Y1.Text, edLine2X2.Text, edLine2Y2.Text);
                if (l2 != null) s.Lines.Add(l2);

                _analytics = new ObjectAnalyticsBlock(s);
                _analytics.OnAnalyticsUpdated += Analytics_OnAnalyticsUpdated;
                _pipeline.Connect(_videoSource.Output, _analytics.Input);
                _pipeline.Connect(_analytics.Output, _videoRenderer.Input);
                await _pipeline.StartAsync();

                mmLog.Text += $"Provider: {_analytics.ActiveProvider}" + Environment.NewLine;
                _timer.Start(); btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); } catch { }
                CleanupBlocks(); btStart.IsEnabled = true; btStop.IsEnabled = false;
                mmLog.Text += ex.Message + Environment.NewLine;
            }
            finally { _uiBusy = false; }
        }

        private void Analytics_OnAnalyticsUpdated(object sender, ObjectAnalyticsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                foreach (var c in e.LineCrossings)
                {
                    lbCrossings.Items.Insert(0, $"[{e.Timestamp:hh\\:mm\\:ss}] {c.LineId}: {c.Label}#{c.TrackerId} {(c.Direction == LineCrossingDirection.In ? "IN" : "OUT")}");
                    if (c.LineId == edLine1Id.Text.Trim())
                    {
                        if (c.Direction == LineCrossingDirection.In) lbLine1In.Text = (int.Parse(lbLine1In.Text) + 1).ToString();
                        else lbLine1Out.Text = (int.Parse(lbLine1Out.Text) + 1).ToString();
                    }
                    else if (c.LineId == edLine2Id.Text.Trim())
                    {
                        if (c.Direction == LineCrossingDirection.In) lbLine2In.Text = (int.Parse(lbLine2In.Text) + 1).ToString();
                        else lbLine2Out.Text = (int.Parse(lbLine2Out.Text) + 1).ToString();
                    }
                }
                while (lbCrossings.Items.Count > 200) lbCrossings.Items.RemoveAt(lbCrossings.Items.Count - 1);
            });
        }

        private void CleanupBlocks()
        {
            if (_analytics != null) { _analytics.OnAnalyticsUpdated -= Analytics_OnAnalyticsUpdated; _analytics.Dispose(); _analytics = null; }
            _videoSource?.Dispose(); _videoSource = null;
            _videoRenderer?.Dispose(); _videoRenderer = null;
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _uiBusy = true; btStop.IsEnabled = false; _timer?.Stop();
                if (_pipeline != null) { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); }
                CleanupBlocks(); VideoView1.CallRefresh();
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            finally { btStart.IsEnabled = true; _uiBusy = false; }
        }
    }
}
