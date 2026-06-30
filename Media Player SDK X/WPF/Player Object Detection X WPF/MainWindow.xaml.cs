using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using Microsoft.Win32;

using VisioForge.Core;
using VisioForge.Core.AI;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

namespace Player_Object_Detection_X_WPF
{
    /// <summary>
    /// Inserts a YOLO object detector into MediaPlayerCoreX through the Video_Processing_AddBlock API: the
    /// detector taps the decoded video, draws bounding boxes into the rendered frame, and raises
    /// OnObjectsDetected while the engine plays a normal file.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayerCoreX _player;
        private YOLOObjectDetectorBlock _detector;
        private bool _isClosing;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        // Models are hosted on the samples GitHub release and cached under %USERPROFILE%/VisioForge/models.
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

        private static readonly string ModelsCacheDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "VisioForge", "models");

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

        private List<ModelPreset> _modelPresets;
        private ModelPreset _selectedPreset;

        static MainWindow()
        {
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("VisioForge-AI-Demo/1.0");
        }

        public MainWindow()
        {
            InitializeComponent();
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

        // The two object-detection model families available on the release; "Custom" lets the user browse for any .onnx.
        private List<ModelPreset> BuildModelList()
        {
            Directory.CreateDirectory(ModelsCacheDir);
            var list = new List<ModelPreset>();
            AddDownloadable(list, "YOLOX Nano", "yolox", "yolox_nano.onnx", ObjectDetectorModel.YOLOX);
            AddDownloadable(list, "RT-DETR R18vd", "rtdetr", "rtdetr_r18vd_fp16.onnx", ObjectDetectorModel.RTDETR);
            list.Add(new ModelPreset { Name = "Custom model...", Tag = "custom", Family = ObjectDetectorModel.YOLOX });
            return list;
        }

        private void AddDownloadable(List<ModelPreset> list, string name, string tag, string fileName, ObjectDetectorModel family)
        {
            var cachePath = Path.Combine(ModelsCacheDir, fileName);
            var isCached = File.Exists(cachePath);
            list.Add(new ModelPreset
            {
                Name = name,
                Tag = tag,
                Family = family,
                DownloadUrl = ModelsReleaseUrl + "/" + fileName,
                FileName = fileName,
                IsLocal = isCached,
                LocalPath = isCached ? cachePath : null,
            });
        }

        private void RefreshModelList()
        {
            var selTag = _selectedPreset?.Tag;
            _modelPresets = BuildModelList();
            cbModel.Items.Clear();
            var selIdx = 0;
            for (var i = 0; i < _modelPresets.Count; i++)
            {
                cbModel.Items.Add(new ComboBoxItem { Content = _modelPresets[i].Name, Tag = _modelPresets[i].Tag });
                if (_modelPresets[i].Tag == selTag)
                {
                    selIdx = i;
                }
            }

            cbModel.SelectedIndex = selIdx;
        }

        private ModelPreset GetSelectedPreset()
        {
            var tag = ((cbModel.SelectedItem as ComboBoxItem)?.Tag as string) ?? "yolox";
            return _modelPresets.Find(p => p.Tag == tag) ?? _modelPresets[0];
        }

        private ObjectDetectorModel SelectedModelFamily() => _selectedPreset?.Family ?? ObjectDetectorModel.YOLOX;

        // Reads "Min confidence %" (0-100) as a 0..1 detector threshold; defaults to 0.6 on a bad value.
        private float ReadConfidenceThreshold()
        {
            if (float.TryParse(edConfidence.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var percent))
            {
                return Math.Max(0f, Math.Min(1f, percent / 100f));
            }

            return 0.6f;
        }

        private void cbModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsInitialized || cbModel.SelectedItem == null || _modelPresets == null)
            {
                return;
            }

            _selectedPreset = GetSelectedPreset();
            var needsDownload = _selectedPreset.DownloadUrl != null && !_selectedPreset.IsLocal;
            var isCustom = _selectedPreset.Tag == "custom";
            btDownloadModel.Visibility = needsDownload ? Visibility.Visible : Visibility.Collapsed;
            btSelectModel.Visibility = isCustom ? Visibility.Visible : Visibility.Collapsed;
            edModel.Text = _selectedPreset.IsLocal && _selectedPreset.LocalPath != null ? _selectedPreset.LocalPath : string.Empty;
        }

        private async void btDownloadModel_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedPreset?.DownloadUrl == null)
            {
                return;
            }

            Directory.CreateDirectory(ModelsCacheDir);
            var destPath = Path.Combine(ModelsCacheDir, _selectedPreset.FileName);
            var tempPath = destPath + ".part";

            btDownloadModel.IsEnabled = false;
            btDownloadModel.Content = "Downloading...";
            Log($"Downloading {_selectedPreset.Name}...");

            try
            {
                // Download off the UI thread so a large model can't freeze the window.
                await Task.Run(async () =>
                {
                    // Stream to a .part temp, then move into place so a failed download leaves no corrupt cache.
                    using (var response = await _http.GetAsync(_selectedPreset.DownloadUrl, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();
                        var total = response.Content.Headers.ContentLength ?? -1L;

                        using (var source = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true))
                        {
                            var buffer = new byte[81920];
                            long readTotal = 0;
                            int read;
                            while ((read = await source.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, read);
                                readTotal += read;
                            }

                            // Reject a truncated download so a partial file is never promoted to the cache.
                            if (total > 0 && readTotal != total)
                            {
                                throw new IOException($"Incomplete download: received {readTotal} of {total} bytes.");
                            }
                        }
                    }

                    if (File.Exists(destPath)) { File.Delete(destPath); }
                    File.Move(tempPath, destPath);
                });

                edModel.Text = destPath;
                Log($"Saved to {ModelsCacheDir} ({new FileInfo(destPath).Length / 1024 / 1024} MB).");
                RefreshModelList();
            }
            catch (Exception ex)
            {
                TryDeleteTemp(tempPath);
                Log("download failed: " + ex.Message);
                MessageBox.Show(this, $"Download failed:\n{ex.Message}\n\nURL: {_selectedPreset.DownloadUrl}", "Download error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                btDownloadModel.IsEnabled = true;
                btDownloadModel.Content = "Download";
            }
        }

        private static void TryDeleteTemp(string path)
        {
            try { if (File.Exists(path)) File.Delete(path); }
            catch { /* best-effort cleanup */ }
        }

        private void Log(string text)
        {
            if (_isClosing)
            {
                return;
            }

            // OnObjectsDetected fires on the pipeline streaming thread; post non-blocking to the UI.
            _ = Dispatcher.BeginInvoke(new Action(() => mmLog.AppendText(text + Environment.NewLine)));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                IsEnabled = true;

                // The engine is created fresh per session in btStart_Click (RecreatePlayerAsync).

                RefreshModelList();

                Log($"SDK v{MediaPlayerCoreX.SDK_Version} ready.");
                Log("ONNX Runtime providers: " + string.Join(", ", OnnxInferenceEngine.GetAvailableProviders()));
            }
            catch (Exception ex)
            {
                Log("load error: " + ex.Message);
            }
        }

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "Media files|*.mp4;*.mkv;*.avi;*.mov;*.webm;*.ts|All files|*.*" };
            if (dialog.ShowDialog() == true)
            {
                edFile.Text = dialog.FileName;
            }
        }

        private void btSelectModel_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "ONNX models|*.onnx|All files|*.*" };
            if (dialog.ShowDialog() == true)
            {
                edModel.Text = dialog.FileName;
            }
        }

        // Disposes any existing engine and builds a fresh MediaPlayerCoreX bound to the same VideoView.
        private async Task RecreatePlayerAsync()
        {
            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                try { await _player.StopAsync(); } catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex); }
                await _player.DisposeAsync();
                _player = null;
            }

            if (_isClosing)
            {
                return;
            }

            _player = new MediaPlayerCoreX(VideoView1);
            _player.OnError += Player_OnError;
            _player.OnStop += Player_OnStop;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edFile.Text))
            {
                MessageBox.Show(this, "Select a media file.");
                return;
            }

            if (string.IsNullOrWhiteSpace(edModel.Text))
            {
                MessageBox.Show(this, "Pick a model and press Download (or choose Custom and browse).");
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

                // Build the engine from scratch for every session.
                await RecreatePlayerAsync();
                if (_player == null || _isClosing)
                {
                    return;
                }

                // Build the source before registering the block so a CreateAsync failure strands nothing.
                var source = await UniversalSourceSettings.CreateAsync(edFile.Text, renderVideo: true, renderAudio: false);

                var settings = new YoloDetectorSettings(edModel.Text)
                {
                    Model = SelectedModelFamily(),
                    ConfidenceThreshold = ReadConfidenceThreshold(),
                    DrawDetections = true,
                };

                _detector = new YOLOObjectDetectorBlock(settings);
                _detector.OnObjectsDetected += Detector_OnObjectsDetected;
                _player.Video_Processing_AddBlock(_detector);

                _player.Video_Play = true;
                _player.Audio_Play = false;

                if (!await _player.OpenAsync(source) || !await _player.PlayAsync())
                {
                    Log("start error: failed to open or play the source.");
                    await CleanupAfterStopAsync();
                    btStart.IsEnabled = true;
                    return;
                }

                btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                // StopAsync tears down the pipeline and disposes any wired block it owns.
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

            var line = $"[{e.Timestamp:hh\\:mm\\:ss}] ";
            foreach (var det in e.Objects)
            {
                if (det != null)
                {
                    line += $"{det.Label} {det.Confidence:P0}   ";
                }
            }

            Log(line.TrimEnd());
        }

        private void Player_OnError(object sender, ErrorsEventArgs e) => Log(e.Message);

        private void Player_OnStop(object sender, StopEventArgs e)
        {
            // The engine disposes the inserted block on stop; drop our reference so the next Start re-creates one.
            _ = Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_isClosing)
                {
                    return;
                }

                // Ignore a stale Stop from a previous session while a start/stop is in flight.
                if (Volatile.Read(ref _startStopBusy) != 0)
                {
                    return;
                }

                if (_player != null && _player.State != PlaybackState.Free)
                {
                    return;
                }

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
            try
            {
                await CleanupAfterStopAsync();
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

        private async System.Threading.Tasks.Task CleanupAfterStopAsync()
        {
            if (_player != null)
            {
                await _player.StopAsync();
            }

            DetachBlock();
        }

        /// <summary>
        /// The engine owns and disposes the inserted block once started, so we only detach the handler and drop
        /// the reference here (we do not dispose it ourselves).
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

            // Wait for an in-flight Start/Stop to finish before tearing the engine down.
            while (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                await Task.Delay(50);
            }

            try
            {
                if (_player != null)
                {
                    _player.OnError -= Player_OnError;
                    _player.OnStop -= Player_OnStop;
                    await _player.StopAsync();
                    await _player.DisposeAsync();
                    _player = null;
                }

                VideoView1.CallRefresh();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            _ = Dispatcher.BeginInvoke(new Action(() => Close()));
        }
    }
}
