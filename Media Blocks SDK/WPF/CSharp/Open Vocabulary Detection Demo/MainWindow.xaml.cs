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
using VisioForge.Core;
using VisioForge.Core.AI;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

namespace Open_Vocabulary_Detection_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Base URL for the downloadable ONNX model assets (weights are not shipped with the SDK).
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v2";

        private static readonly string ModelsCacheDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "VisioForge", "models", "openvocab");

        // Canonical asset file names (see the model asset table).
        private const string Owlv2ModelFile = "owlv2-base-ensemble.onnx";
        private const string Owlv2VocabFile = "owlv2-vocab.json";
        private const string Owlv2MergesFile = "owlv2-merges.txt";
        private const string GroundingDinoModelFile = "grounding-dino-tiny.onnx";
        private const string BertVocabFile = "bert-vocab.txt";

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };

        private MediaBlocksPipeline _pipeline;
        private VideoRendererBlock _videoRenderer;
        private MediaBlock _videoSource;
        private OpenVocabularyDetectorBlock _detector;

        private System.Windows.Threading.DispatcherTimer _timer;
        private bool _timerBusy;
        private VideoCaptureDeviceInfo[] _videoCaptureDevices;
        private bool _isClosing;
        private bool _cleanupFinished;
        private bool _uiBusy;

        public MainWindow()
        {
            InitializeComponent();
        }

        private OpenVocabularyModel SelectedModel =>
            cbModel.SelectedIndex == 1 ? OpenVocabularyModel.GroundingDINO : OpenVocabularyModel.OWLv2;

        private OnnxExecutionProvider SelectedProvider =>
            (cbProvider.SelectedItem as ComboBoxItem)?.Tag is OnnxExecutionProvider p ? p : OnnxExecutionProvider.Auto;

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => { mmLog.Text += e.Message + Environment.NewLine; }));
        }

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_uiBusy || _isClosing) return;
                _timer?.Stop();
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
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

                cbModel.Items.Add("OWLv2");
                cbModel.Items.Add("Grounding DINO");
                cbModel.SelectedIndex = 1;

                foreach (var prov in new[] { OnnxExecutionProvider.Auto, OnnxExecutionProvider.CPU, OnnxExecutionProvider.CUDA, OnnxExecutionProvider.DirectML })
                    cbProvider.Items.Add(new ComboBoxItem { Content = prov.ToString(), Tag = prov });
                cbProvider.SelectedIndex = 0;

                foreach (var p in new[] { "a person", "a car" }) lbPrompts.Items.Add(p);

                PrefillModelPaths();

                var providers = OnnxInferenceEngine.GetAvailableProviders();
                mmLog.Text += "ONNX Runtime providers: " + string.Join(", ", providers) + Environment.NewLine;
                mmLog.Text += "Models are cached under %USERPROFILE%/VisioForge/models/openvocab. Weights are NOT shipped with the SDK." + Environment.NewLine;
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        // Names of the files the selected model requires.
        private (string model, string vocab, string merges) RequiredFiles()
        {
            return SelectedModel == OpenVocabularyModel.OWLv2
                ? (Owlv2ModelFile, Owlv2VocabFile, Owlv2MergesFile)
                : (GroundingDinoModelFile, BertVocabFile, null);
        }

        private void PrefillModelPaths()
        {
            var (model, vocab, merges) = RequiredFiles();
            edModelFile.Text = CachedOrEmpty(model);
            edVocabFile.Text = CachedOrEmpty(vocab);

            var isOwl = SelectedModel == OpenVocabularyModel.OWLv2;
            edMergesFile.Text = isOwl ? CachedOrEmpty(merges) : string.Empty;
            edMergesFile.IsEnabled = isOwl;
            btSelectMerges.IsEnabled = isOwl;
            lbMerges.Content = isOwl ? "Merges file (OWLv2)" : "Merges file (not used by Grounding DINO)";

            RefreshModelStatus();
        }

        // Reflects whether every required model file for the selected model is already on disk:
        // when ready, the Download button is disabled and relabeled so the user isn't nudged to re-download.
        private void RefreshModelStatus()
        {
            if (btDownloadModels == null) return;
            var isOwl = SelectedModel == OpenVocabularyModel.OWLv2;
            var ready = File.Exists(edModelFile.Text) && File.Exists(edVocabFile.Text)
                        && (!isOwl || File.Exists(edMergesFile.Text));
            btDownloadModels.IsEnabled = !ready;
            btDownloadModels.Content = ready ? "Model files ready" : "Download model files";
        }

        private static string CachedOrEmpty(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return string.Empty;
            var path = Path.Combine(ModelsCacheDir, fileName);
            return File.Exists(path) ? path : string.Empty;
        }

        private void cbModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsInitialized) return;
            PrefillModelPaths();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (_timerBusy) return; _timerBusy = true;
            try
            {
                if (_pipeline != null) lbTime.Text = (await _pipeline.Position_GetAsync()).ToString("hh\\:mm\\:ss");
                if (_detector != null)
                {
                    lbStatus.Text = $"Provider: {_detector.ActiveProvider}   |   Inference: {_detector.LastInferenceTimeMs:F0} ms   |   Dropped frames: {_detector.DroppedFrameCount}";
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            finally { _timerBusy = false; }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_cleanupFinished) return;
            e.Cancel = true;
            if (_isClosing) return;
            _isClosing = true; IsEnabled = false;
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
                CleanupBlocks();
                VideoView1.CallRefresh();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            try { _cleanupFinished = true; Dispatcher.BeginInvoke(new Action(() => Close())); }
            catch (Exception ex) { Debug.WriteLine(ex); _isClosing = false; _cleanupFinished = false; IsEnabled = true; }
        }

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

        private void btSelectModel_Click(object sender, RoutedEventArgs e) => PickFile(edModelFile, "ONNX models|*.onnx|All files|*.*");

        private void btSelectVocab_Click(object sender, RoutedEventArgs e) => PickFile(edVocabFile, "Vocabulary|*.json;*.txt|All files|*.*");

        private void btSelectMerges_Click(object sender, RoutedEventArgs e) => PickFile(edMergesFile, "Merges|*.txt|All files|*.*");

        private void PickFile(TextBox box, string filter)
        {
            var dlg = new OpenFileDialog { Filter = filter };
            if (dlg.ShowDialog() == true) { box.Text = dlg.FileName; RefreshModelStatus(); }
        }

        // ---- prompts ----
        private void btAddPrompt_Click(object sender, RoutedEventArgs e)
        {
            var text = edPrompt.Text?.Trim();
            if (!string.IsNullOrEmpty(text)) { lbPrompts.Items.Add(text); edPrompt.Clear(); }
        }

        private void btRemovePrompt_Click(object sender, RoutedEventArgs e)
        {
            if (lbPrompts.SelectedIndex >= 0) lbPrompts.Items.RemoveAt(lbPrompts.SelectedIndex);
        }

        private string[] CurrentPrompts() => lbPrompts.Items.Cast<object>().Select(o => o.ToString()).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

        private void btApplyPrompts_Click(object sender, RoutedEventArgs e)
        {
            var prompts = CurrentPrompts();
            if (prompts.Length == 0) { MessageBox.Show(this, "Add at least one prompt."); return; }
            _detector?.SetPrompts(prompts);
            mmLog.Text += "Applied prompts: " + string.Join(", ", prompts) + Environment.NewLine;
        }

        // ---- settings ----
        private void slThreshold_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbConfidence != null) lbConfidence.Text = slConfidence.Value.ToString("F2", CultureInfo.InvariantCulture);
            if (lbIoU != null) lbIoU.Text = slIoU.Value.ToString("F2", CultureInfo.InvariantCulture);
        }

        // ---- model download ----
        private async void btDownloadModels_Click(object sender, RoutedEventArgs e)
        {
            var (model, vocab, merges) = RequiredFiles();
            var wanted = new List<string> { model, vocab };
            if (!string.IsNullOrEmpty(merges)) wanted.Add(merges);

            btDownloadModels.IsEnabled = false;
            pnlDownload.Visibility = Visibility.Visible;
            try
            {
                foreach (var fileName in wanted)
                {
                    await DownloadModelAsync(fileName);
                }

                PrefillModelPaths();
                mmLog.Text += "Model files ready." + Environment.NewLine;
                lbDownloadStatus.Text = "All models ready.";
                MessageBox.Show(this, "All model files downloaded and ready.", "Models Ready", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                mmLog.Text += $"Download failed: {ex.Message}" + Environment.NewLine;
                MessageBox.Show(this, $"Download failed:\n{ex.Message}", "Download Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                RefreshModelStatus();
                pnlDownload.Visibility = Visibility.Collapsed; // hide the progress panel once downloads finish (or fail)
            }
        }

        private async System.Threading.Tasks.Task DownloadModelAsync(string fileName)
        {
            Directory.CreateDirectory(ModelsCacheDir);
            var destPath = Path.Combine(ModelsCacheDir, fileName);

            // Already present with a plausible size: skip the download.
            if (File.Exists(destPath) && new FileInfo(destPath).Length > 0)
            {
                mmLog.Text += $"{fileName} already present - skipped." + Environment.NewLine;
                return;
            }

            var tmpPath = destPath + ".part";
            pbDownload.IsIndeterminate = false;
            pbDownload.Value = 0;
            lbDownloadStatus.Text = $"Downloading {fileName}...";
            mmLog.Text += $"Downloading {fileName}..." + Environment.NewLine;

            try
            {
                await System.Threading.Tasks.Task.Run(async () =>
                {
                    using (var response = await _http.GetAsync(ModelsReleaseUrl + "/" + fileName, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();
                        var total = response.Content.Headers.ContentLength ?? -1L;
                        Dispatcher.BeginInvoke(new Action(() => pbDownload.IsIndeterminate = total <= 0));

                        using (var src = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = File.Create(tmpPath))
                        {
                            var buffer = new byte[81920];
                            long readTotal = 0;
                            int lastPercent = -1;
                            int read;
                            while ((read = await src.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, read);
                                readTotal += read;
                                if (total > 0)
                                {
                                    var percent = (int)(readTotal * 100 / total);
                                    if (percent != lastPercent)
                                    {
                                        lastPercent = percent;
                                        var done = readTotal;
                                        Dispatcher.BeginInvoke(new Action(() =>
                                        {
                                            pbDownload.Value = percent;
                                            lbDownloadStatus.Text = $"Downloading {fileName}... {percent}% ({done / 1024 / 1024} / {total / 1024 / 1024} MB)";
                                        }));
                                    }
                                }
                            }
                        }
                    }
                });

                File.Move(tmpPath, destPath, true);
                lbDownloadStatus.Text = $"Saved {fileName}.";
                mmLog.Text += $"Saved {fileName} to {ModelsCacheDir}." + Environment.NewLine;
            }
            catch
            {
                try { if (File.Exists(tmpPath)) File.Delete(tmpPath); } catch { }
                throw;
            }
        }

        // ---- device selection ----
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
                    var fmt = device?.VideoFormats.FirstOrDefault(x => x.Name == (string)e.AddedItems[0]);
                    if (fmt != null)
                    {
                        foreach (var r in fmt.GetFrameRateRangeAsStringList()) cbVideoFrameRate.Items.Add(r);
                        if (cbVideoFrameRate.Items.Count > 0) cbVideoFrameRate.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

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
            if (device == null || fmt == null) { MessageBox.Show(this, "Unable to configure the video device."); return false; }
            var s = new VideoCaptureDeviceSourceSettings(device) { Format = fmt.ToFormat() };
            if (!string.IsNullOrEmpty(cbVideoFrameRate.Text))
                s.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.Text, CultureInfo.InvariantCulture));
            _videoSource = new SystemVideoSourceBlock(s);
            return true;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _uiBusy = true; btStart.IsEnabled = false;
                if (_pipeline == null) { MessageBox.Show(this, "SDK failed to initialize."); btStart.IsEnabled = true; return; }

                mmLog.Clear(); lbDetections.Items.Clear();

                try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); }
                catch (Exception ex) { Debug.WriteLine(ex); }
                CleanupBlocks();

                var prompts = CurrentPrompts();
                if (prompts.Length == 0) { MessageBox.Show(this, "Add at least one prompt on the Prompts tab."); btStart.IsEnabled = true; return; }
                if (string.IsNullOrWhiteSpace(edModelFile.Text) || !File.Exists(edModelFile.Text)) { MessageBox.Show(this, "Select (or download) the model file on the Model tab."); btStart.IsEnabled = true; return; }
                if (string.IsNullOrWhiteSpace(edVocabFile.Text) || !File.Exists(edVocabFile.Text)) { MessageBox.Show(this, "Select (or download) the vocabulary file on the Model tab."); btStart.IsEnabled = true; return; }
                if (!await BuildSourceAsync()) { btStart.IsEnabled = true; return; }

                var isOwl = SelectedModel == OpenVocabularyModel.OWLv2;
                var mergesPath = isOwl && !string.IsNullOrWhiteSpace(edMergesFile.Text) ? edMergesFile.Text : null;

                var settings = new OpenVocabularyDetectorSettings(edModelFile.Text, edVocabFile.Text, mergesPath, prompts)
                {
                    Model = SelectedModel,
                    Provider = SelectedProvider,
                    ConfidenceThreshold = (float)slConfidence.Value,
                    IoUThreshold = (float)slIoU.Value,
                    DrawDetections = cbDrawDetections.IsChecked == true,
                };

                if (int.TryParse(edFramesToSkip.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var skip) && skip >= 0)
                    settings.FramesToSkip = skip;

                _detector = new OpenVocabularyDetectorBlock(settings);
                _detector.OnObjectsDetected += Detector_OnObjectsDetected;

                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };

                _pipeline.Connect(_videoSource.Output, _detector.Input);
                _pipeline.Connect(_detector.Output, _videoRenderer.Input);

                if (!await _pipeline.StartAsync())
                {
                    mmLog.Text += "Failed to start - check the model paths and selected source." + Environment.NewLine;
                    try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); } catch { }
                    CleanupBlocks(); btStart.IsEnabled = true; return;
                }

                mmLog.Text += $"Running on: {_detector.ActiveProvider}" + Environment.NewLine;
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

        private void Detector_OnObjectsDetected(object sender, ObjectsDetectedEventArgs e)
        {
            var sb = new StringBuilder();
            foreach (var det in e.Objects) sb.Append($"{det.Label} {det.Confidence:P0}   ");
            var line = sb.ToString().TrimEnd();
            Dispatcher.BeginInvoke(new Action(() =>
            {
                lbDetections.Items.Insert(0, $"[{e.Timestamp:hh\\:mm\\:ss}] {line}");
                while (lbDetections.Items.Count > 200) lbDetections.Items.RemoveAt(lbDetections.Items.Count - 1);
            }));
        }

        private void CleanupBlocks()
        {
            if (_detector != null) { _detector.OnObjectsDetected -= Detector_OnObjectsDetected; _detector.Dispose(); _detector = null; }
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
