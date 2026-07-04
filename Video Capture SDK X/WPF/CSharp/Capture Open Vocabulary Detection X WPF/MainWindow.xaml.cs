using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using Microsoft.Win32;

using VisioForge.Core;
using VisioForge.Core.AI;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace Capture_Open_Vocabulary_Detection_X_WPF
{
    /// <summary>
    /// Inserts an OpenVocabularyDetectorBlock (OWLv2 / Grounding DINO) into VideoCaptureCoreX via
    /// Video_Processing_AddBlock: it taps the live camera frames, draws boxes for the text prompts, and
    /// raises OnObjectsDetected. Prompts can be edited while capture runs.
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCaptureCoreX _core;
        private OpenVocabularyDetectorBlock _detector;
        private VideoCaptureDeviceInfo[] _cameras;
        private bool _isClosing;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        private System.Windows.Threading.DispatcherTimer _timer;
        private bool _timerBusy;

        // Weights are NOT shipped with the SDK; hosted on the samples GitHub release, cached under %USERPROFILE%/VisioForge/models/openvocab.
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v2";

        private static readonly string ModelsCacheDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "VisioForge", "models", "openvocab");

        // Canonical asset file names.
        private const string Owlv2ModelFile = "owlv2-base-ensemble.onnx";
        private const string Owlv2VocabFile = "owlv2-vocab.json";
        private const string Owlv2MergesFile = "owlv2-merges.txt";
        private const string GroundingDinoModelFile = "grounding-dino-tiny.onnx";
        private const string BertVocabFile = "bert-vocab.txt";

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };

        public MainWindow()
        {
            InitializeComponent();
        }

        private OpenVocabularyModel SelectedModel =>
            cbModel.SelectedIndex == 1 ? OpenVocabularyModel.GroundingDINO : OpenVocabularyModel.OWLv2;

        private OnnxExecutionProvider SelectedProvider =>
            (cbProvider.SelectedItem as ComboBoxItem)?.Tag is OnnxExecutionProvider p ? p : OnnxExecutionProvider.Auto;

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();

                // The engine is created fresh per session in RecreateEngineAsync, so nothing to construct here.

                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
                foreach (var camera in _cameras)
                {
                    cbCamera.Items.Add(camera.DisplayName);
                }

                if (cbCamera.Items.Count > 0)
                {
                    cbCamera.SelectedIndex = 0;
                }

                cbModel.Items.Add("OWLv2");
                cbModel.Items.Add("Grounding DINO");
                cbModel.SelectedIndex = 1;

                foreach (var prov in new[] { OnnxExecutionProvider.Auto, OnnxExecutionProvider.CPU, OnnxExecutionProvider.CUDA, OnnxExecutionProvider.DirectML })
                {
                    cbProvider.Items.Add(new ComboBoxItem { Content = prov.ToString(), Tag = prov });
                }

                cbProvider.SelectedIndex = 0;

                foreach (var p in new[] { "a person", "a car" })
                {
                    lbPrompts.Items.Add(p);
                }

                PrefillModelPaths();

                _timer = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
                _timer.Tick += Timer_Tick;

                Log($"SDK v{VideoCaptureCoreX.SDK_Version} ready.");
                Log("ONNX Runtime providers: " + string.Join(", ", OnnxInferenceEngine.GetAvailableProviders()));
                Log("Models are cached under %USERPROFILE%/VisioForge/models/openvocab. Weights are NOT shipped with the SDK.");
            }
            catch (Exception ex)
            {
                Log("load error: " + ex.Message);
            }
            finally
            {
                IsEnabled = true;
            }
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

        // When every required file is on disk, disable + relabel Download so the user isn't nudged to re-download.
        private void RefreshModelStatus()
        {
            if (btDownloadModels == null)
            {
                return;
            }

            var isOwl = SelectedModel == OpenVocabularyModel.OWLv2;
            var ready = File.Exists(edModelFile.Text) && File.Exists(edVocabFile.Text)
                        && (!isOwl || File.Exists(edMergesFile.Text));
            btDownloadModels.IsEnabled = !ready;
            btDownloadModels.Content = ready ? "Model files ready" : "Download model files";
        }

        private static string CachedOrEmpty(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return string.Empty;
            }

            var path = Path.Combine(ModelsCacheDir, fileName);
            return File.Exists(path) ? path : string.Empty;
        }

        private void cbModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsInitialized)
            {
                return;
            }

            PrefillModelPaths();
        }

        private void btSelectModel_Click(object sender, RoutedEventArgs e) => PickFile(edModelFile, "ONNX models|*.onnx|All files|*.*");

        private void btSelectVocab_Click(object sender, RoutedEventArgs e) => PickFile(edVocabFile, "Vocabulary|*.json;*.txt|All files|*.*");

        private void btSelectMerges_Click(object sender, RoutedEventArgs e) => PickFile(edMergesFile, "Merges|*.txt|All files|*.*");

        private void PickFile(TextBox box, string filter)
        {
            var dlg = new OpenFileDialog { Filter = filter };
            if (dlg.ShowDialog() == true)
            {
                box.Text = dlg.FileName;
                RefreshModelStatus();
            }
        }

        // ---- prompts ----
        private void btAddPrompt_Click(object sender, RoutedEventArgs e)
        {
            var text = edPrompt.Text?.Trim();
            if (!string.IsNullOrEmpty(text))
            {
                lbPrompts.Items.Add(text);
                edPrompt.Clear();
            }
        }

        private void btRemovePrompt_Click(object sender, RoutedEventArgs e)
        {
            if (lbPrompts.SelectedIndex >= 0)
            {
                lbPrompts.Items.RemoveAt(lbPrompts.SelectedIndex);
            }
        }

        private string[] CurrentPrompts() => lbPrompts.Items.Cast<object>().Select(o => o.ToString()).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

        private void btApplyPrompts_Click(object sender, RoutedEventArgs e)
        {
            var prompts = CurrentPrompts();
            if (prompts.Length == 0)
            {
                MessageBox.Show(this, "Add at least one prompt.");
                return;
            }

            _detector?.SetPrompts(prompts);
            Log("Applied prompts: " + string.Join(", ", prompts));
        }

        // ---- settings ----
        private void slThreshold_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbConfidence != null)
            {
                lbConfidence.Text = slConfidence.Value.ToString("F2", CultureInfo.InvariantCulture);
            }

            if (lbIoU != null)
            {
                lbIoU.Text = slIoU.Value.ToString("F2", CultureInfo.InvariantCulture);
            }

            // Apply the thresholds to the running detector live — no Start/Stop needed.
            _detector?.SetConfidenceThreshold((float)slConfidence.Value);
            _detector?.SetIoUThreshold((float)slIoU.Value);
        }

        // ---- model download ----
        private async void btDownloadModels_Click(object sender, RoutedEventArgs e)
        {
            var (model, vocab, merges) = RequiredFiles();
            var wanted = new List<string> { model, vocab };
            if (!string.IsNullOrEmpty(merges))
            {
                wanted.Add(merges);
            }

            btDownloadModels.IsEnabled = false;
            pnlDownload.Visibility = Visibility.Visible;
            try
            {
                foreach (var fileName in wanted)
                {
                    await DownloadModelAsync(fileName);
                }

                PrefillModelPaths();
                Log("Model files ready.");
                lbDownloadStatus.Text = "All models ready.";
                MessageBox.Show(this, "All model files downloaded and ready.", "Models Ready", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                Log($"Download failed: {ex.Message}");
                MessageBox.Show(this, $"Download failed:\n{ex.Message}", "Download Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                RefreshModelStatus();
                pnlDownload.Visibility = Visibility.Collapsed;
            }
        }

        private async Task DownloadModelAsync(string fileName)
        {
            Directory.CreateDirectory(ModelsCacheDir);
            var destPath = Path.Combine(ModelsCacheDir, fileName);

            if (File.Exists(destPath) && new FileInfo(destPath).Length > 0)
            {
                Log($"{fileName} already present - skipped.");
                return;
            }

            var tmpPath = destPath + ".part";
            pbDownload.IsIndeterminate = false;
            pbDownload.Value = 0;
            lbDownloadStatus.Text = $"Downloading {fileName}...";
            Log($"Downloading {fileName}...");

            try
            {
                await Task.Run(async () =>
                {
                    // Stream to a .part temp, then move into place so a failed download leaves no corrupt cache.
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

                            if (total > 0 && readTotal != total)
                            {
                                throw new IOException($"Incomplete download: received {readTotal} of {total} bytes.");
                            }
                        }
                    }
                });

                File.Move(tmpPath, destPath, true);
                lbDownloadStatus.Text = $"Saved {fileName}.";
                Log($"Saved {fileName} to {ModelsCacheDir}.");
            }
            catch
            {
                try { if (File.Exists(tmpPath)) File.Delete(tmpPath); } catch { }
                throw;
            }
        }

        // Disposes any existing engine and builds a fresh VideoCaptureCoreX bound to the same VideoView.
        private async Task RecreateEngineAsync()
        {
            if (_core != null)
            {
                _core.OnError -= Core_OnError;
                _core.OnStop -= Core_OnStop;
                try { await _core.StopAsync(); } catch (Exception ex) { Debug.WriteLine(ex); }
                await _core.DisposeAsync();
                _core = null;
            }

            if (_isClosing)
            {
                return;
            }

            _core = new VideoCaptureCoreX(VideoView1);
            _core.OnError += Core_OnError;
            _core.OnStop += Core_OnStop;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (_cameras == null || _cameras.Length == 0 || cbCamera.SelectedIndex < 0)
            {
                MessageBox.Show(this, "No camera devices were found.");
                return;
            }

            var prompts = CurrentPrompts();
            if (prompts.Length == 0)
            {
                MessageBox.Show(this, "Add at least one prompt on the Prompts tab.");
                return;
            }

            if (string.IsNullOrWhiteSpace(edModelFile.Text) || !File.Exists(edModelFile.Text))
            {
                MessageBox.Show(this, "Select (or download) the model file on the Model tab.");
                return;
            }

            if (string.IsNullOrWhiteSpace(edVocabFile.Text) || !File.Exists(edVocabFile.Text))
            {
                MessageBox.Show(this, "Select (or download) the vocabulary file on the Model tab.");
                return;
            }

            if (SelectedModel == OpenVocabularyModel.OWLv2 && (string.IsNullOrWhiteSpace(edMergesFile.Text) || !File.Exists(edMergesFile.Text)))
            {
                MessageBox.Show(this, "Select (or download) the merges file on the Model tab. It is required for OWLv2.");
                return;
            }

            if (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                return;
            }

            try
            {
                btStart.IsEnabled = false;
                mmLog.Clear();
                lbDetections.Items.Clear();

                await RecreateEngineAsync();
                if (_core == null || _isClosing)
                {
                    return;
                }

                // Configure the camera source at an HD (or best available) format.
                var device = _cameras[cbCamera.SelectedIndex];
                var formatItem = device.GetHDOrAnyVideoFormatAndFrameRate(out var frameRate);
                if (formatItem == null)
                {
                    MessageBox.Show(this, "Unable to read a camera format.");
                    btStart.IsEnabled = true;
                    return;
                }

                var videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                {
                    Format = formatItem.ToFormat()
                };
                videoSourceSettings.Format.FrameRate = frameRate;
                _core.Video_Source = videoSourceSettings;
                _core.Audio_Play = false;

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
                {
                    settings.FramesToSkip = skip;
                }

                _detector = new OpenVocabularyDetectorBlock(settings);
                _detector.OnObjectsDetected += Detector_OnObjectsDetected;
                _core.Video_Processing_AddBlock(_detector);

                if (!await _core.StartAsync())
                {
                    Log("start error: failed to start capture.");
                    await CleanupAfterStopAsync();
                    btStart.IsEnabled = true;
                    return;
                }

                Log($"Running on: {_detector.ActiveProvider}");
                _timer.Start();
                btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Log("start error: " + ex.Message);
                await CleanupAfterStopAsync();
                btStart.IsEnabled = true;
            }
            finally
            {
                Interlocked.Exchange(ref _startStopBusy, 0);
            }
        }

        private void Detector_OnObjectsDetected(object sender, ObjectsDetectedEventArgs e)
        {
            if (e.Objects == null || e.Objects.Length == 0)
            {
                return;
            }

            var sb = new StringBuilder();
            foreach (var det in e.Objects)
            {
                if (det != null)
                {
                    sb.Append($"{det.Label} {det.Confidence:P0}   ");
                }
            }

            var line = sb.ToString().TrimEnd();
            _ = Dispatcher.BeginInvoke(new Action(() =>
            {
                lbDetections.Items.Insert(0, $"[{e.Timestamp:hh\\:mm\\:ss}] {line}");
                while (lbDetections.Items.Count > 200)
                {
                    lbDetections.Items.RemoveAt(lbDetections.Items.Count - 1);
                }
            }));
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (_timerBusy)
            {
                return;
            }

            _timerBusy = true;
            try
            {
                if (_detector != null)
                {
                    lbStatus.Text = $"Provider: {_detector.ActiveProvider}   |   Inference: {_detector.LastInferenceTimeMs:F0} ms   |   Dropped frames: {_detector.DroppedFrameCount}";
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            finally { _timerBusy = false; }
        }

        private void Log(string text)
        {
            if (_isClosing)
            {
                return;
            }

            // Events fire on the pipeline streaming thread; post non-blocking to the UI.
            _ = Dispatcher.BeginInvoke(new Action(() => mmLog.AppendText(text + Environment.NewLine)));
        }

        private void Core_OnError(object sender, ErrorsEventArgs e) => Log(e.Message);

        private void Core_OnStop(object sender, StopEventArgs e)
        {
            // The engine disposes the inserted block on stop; drop our reference so the next Start re-creates one.
            _ = Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_isClosing)
                {
                    return;
                }

                if (Volatile.Read(ref _startStopBusy) != 0)
                {
                    return;
                }

                if (_core != null && _core.State != PlaybackState.Free)
                {
                    return;
                }

                _timer?.Stop();
                DetachBlock();
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
            }));
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                return;
            }

            btStop.IsEnabled = false;
            _timer?.Stop();
            try
            {
                await CleanupAfterStopAsync();
                VideoView1.CallRefresh();
            }
            catch (Exception ex)
            {
                Log("stop error: " + ex.Message);
            }
            finally
            {
                Interlocked.Exchange(ref _startStopBusy, 0);
            }

            btStart.IsEnabled = true;
        }

        private async Task CleanupAfterStopAsync()
        {
            if (_core != null)
            {
                await _core.StopAsync();
            }

            DetachBlock();
        }

        /// <summary>
        /// Detaches the handler and drops the reference; the engine owns and disposes the block itself.
        /// </summary>
        private void DetachBlock()
        {
            if (_detector != null)
            {
                _detector.OnObjectsDetected -= Detector_OnObjectsDetected;
                _detector = null;
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isClosing)
            {
                return;
            }

            e.Cancel = true;
            _isClosing = true;
            IsEnabled = false;

            _timer?.Stop();

            // Wait for an in-flight Start/Stop to finish before tearing the engine down.
            while (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                await Task.Delay(50);
            }

            try
            {
                if (_core != null)
                {
                    _core.OnError -= Core_OnError;
                    _core.OnStop -= Core_OnStop;
                    await _core.StopAsync();
                    await _core.DisposeAsync();
                    _core = null;
                }

                VideoView1.CallRefresh();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            _ = Dispatcher.BeginInvoke(new Action(() => Close()));
        }
    }
}
