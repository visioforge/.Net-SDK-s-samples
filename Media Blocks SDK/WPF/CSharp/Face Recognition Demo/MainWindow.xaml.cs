using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace Face_Recognition_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        // Webcam, file or RTSP source.
        private MediaBlock _videoSource;

        private FaceRecognitionBlock _face;

        // Persistent block used only to compute embeddings for enrollment (never added to the pipeline).
        private FaceRecognitionBlock _enroller;
        private string _enrollerSignature;

        // Shared gallery: enrollment writes into it and the live pipeline matches against it.
        private readonly FaceGallery _gallery = new FaceGallery();

        // Source photos per identity, so the gallery can be re-embedded when the embedding model changes.
        private readonly System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> _enrolledPhotos
            = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>(StringComparer.Ordinal);

        // The embedding family (cbEmbFamily index) the current gallery embeddings were built with; null when the
        // gallery is empty or was loaded from a .vfg (origin unknown, so it can't be re-embedded).
        private int? _galleryFamily;

        private System.Windows.Threading.DispatcherTimer _timer;

        private bool _timerBusy;

        private VideoCaptureDeviceInfo[] _videoCaptureDevices;

        private bool _isClosing;

        private bool _cleanupFinished;

        private bool _uiBusy;

        // File-playback transport state (seek bar + real-time/max-speed toggle).
        private bool _isFile;

        private bool _seeking;

        private bool _suppressSeek;

        private TimeSpan _duration;

        // OpenCV Zoo model file names hosted in the SDK samples release. Weights are NOT shipped with the SDK.
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

        private const string DetectorModelFile = "face_detection_yunet_2023mar.onnx"; // YuNet (MIT)
        private const string EmbeddingModelFile = "face_recognition_sface_2021dec.onnx"; // SFace (Apache-2.0)
        private const string AuraFaceModelFile = "face_recognition_auraface_v1.onnx"; // AuraFace r100, ArcFace family (Apache-2.0, by fal)

        // The embedding model file for the currently selected family (index 1 = AuraFace/ArcFace 512-D).
        private string SelectedEmbeddingFile => cbEmbFamily.SelectedIndex == 1 ? AuraFaceModelFile : EmbeddingModelFile;

        private static readonly string ModelsCacheDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "VisioForge", "models");

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            // BeginInvoke (non-blocking): OnError fires on a background worker, and teardown joins that worker
            // on the UI thread - a blocking Invoke would deadlock.
            Dispatcher.BeginInvoke(new Action(() => { mmLog.Text += e.Message + Environment.NewLine; }));
        }

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_uiBusy || _isClosing)
                {
                    return;
                }

                _timer?.Stop();
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;

                slSeek.IsEnabled = false;
                _suppressSeek = true;
                slSeek.Value = 0;
                _suppressSeek = false;
            }));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                this.IsEnabled = false;
                try
                {
                    await VisioForgeX.InitSDKAsync();
                }
                finally
                {
                    this.IsEnabled = true;
                    Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", string.Empty);
                }

                _timer = new System.Windows.Threading.DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(500),
                };
                _timer.Tick += Timer_Tick;

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;
                _pipeline.OnStop += Pipeline_OnStop;

                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                _videoCaptureDevices = await SystemVideoSourceBlock.GetDevicesAsync() ?? Array.Empty<VideoCaptureDeviceInfo>();
                foreach (var item in _videoCaptureDevices)
                {
                    cbVideoInput.Items.Add(item.DisplayName);
                }

                if (cbVideoInput.Items.Count > 0)
                {
                    cbVideoInput.SelectedIndex = 0;
                }

                cbEmbFamily.Items.Add("SFace (128-D)");
                cbEmbFamily.Items.Add("AuraFace (512-D)");
                cbEmbFamily.SelectedIndex = 0;

                // Prefill the model paths from the cache directory when the models were already downloaded.
                PrefillFromCache(edDetModel, DetectorModelFile);
                PrefillFromCache(edEmbModel, EmbeddingModelFile);
                RefreshModelButtons();

                var providers = OnnxInferenceEngine.GetAvailableProviders();
                mmLog.Text += "ONNX Runtime providers: " + string.Join(", ", providers) + Environment.NewLine;
                mmLog.Text += "Models are cached under %USERPROFILE%/VisioForge/models. Weights are NOT shipped with the SDK." + Environment.NewLine;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private static void PrefillFromCache(TextBox box, string fileName)
        {
            var path = Path.Combine(ModelsCacheDir, fileName);
            if (File.Exists(path))
            {
                box.Text = path;
            }
        }

        // Show a Download button only when the selected model is missing from the cache. YuNet, SFace and AuraFace
        // are all SDK-hosted, so each button appears whenever its file is not yet cached.
        private void RefreshModelButtons()
        {
            btDownloadDet.Visibility = File.Exists(Path.Combine(ModelsCacheDir, DetectorModelFile))
                ? Visibility.Collapsed : Visibility.Visible;

            // Both embedders (SFace 128-D, AuraFace 512-D) are SDK-hosted: show Download only when missing from cache.
            var embCached = File.Exists(Path.Combine(ModelsCacheDir, SelectedEmbeddingFile));
            btDownloadEmb.Visibility = embCached ? Visibility.Collapsed : Visibility.Visible;

            // Attribution / guidance for the AuraFace family (Apache-2.0, by fal).
            var auraSelected = cbEmbFamily.SelectedIndex == 1;
            lbEmbHint.Visibility = auraSelected ? Visibility.Visible : Visibility.Collapsed;
            lbEmbHint.Text = "AuraFace 512-D embedder (Apache-2.0, by fal) - commercial-friendly. Downloads on demand, or Browse for your own ArcFace-family .onnx.";
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
                if (_pipeline == null)
                {
                    return;
                }

                var position = await _pipeline.Position_GetAsync();

                if (_isFile)
                {
                    // Duration usually becomes available only once playback has prerolled - keep trying until known.
                    if (_duration <= TimeSpan.Zero)
                    {
                        try { _duration = await _pipeline.DurationAsync(); } catch (Exception durEx) { Debug.WriteLine(durEx); }
                    }
                }

                if (_isFile && _duration > TimeSpan.Zero)
                {
                    lbTime.Text = $"{position:hh\\:mm\\:ss} / {_duration:hh\\:mm\\:ss}";

                    // Reflect playback position on the seek bar unless the user is dragging it.
                    if (!_seeking)
                    {
                        _suppressSeek = true;
                        slSeek.Value = Math.Max(0, Math.Min(slSeek.Maximum, position.TotalSeconds / _duration.TotalSeconds * slSeek.Maximum));
                        _suppressSeek = false;
                    }
                }
                else
                {
                    lbTime.Text = position.ToString("hh\\:mm\\:ss");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                _timerBusy = false;
            }
        }

        private void slSeek_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            _seeking = true;
        }

        private async void slSeek_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            _seeking = false;
            await SeekToSliderAsync();
        }

        private async void slSeek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Ignore programmatic updates from the timer and the continuous changes while dragging
            // (the drag is committed once in DragCompleted). A track click lands here directly.
            if (_suppressSeek || _seeking)
            {
                return;
            }

            await SeekToSliderAsync();
        }

        private async System.Threading.Tasks.Task SeekToSliderAsync()
        {
            if (_pipeline == null || !_isFile)
            {
                return;
            }

            if (_duration <= TimeSpan.Zero)
            {
                try { _duration = await _pipeline.DurationAsync(); } catch (Exception durEx) { Debug.WriteLine(durEx); }
            }

            if (_duration <= TimeSpan.Zero)
            {
                return;
            }

            try
            {
                var target = TimeSpan.FromSeconds(slSeek.Value / slSeek.Maximum * _duration.TotalSeconds);
                await _pipeline.Position_SetAsync(target, seekToKeyframe: true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Once cleanup has completed, let the real close proceed.
            if (_cleanupFinished)
            {
                return;
            }

            // Cancel close attempts until the async teardown finishes.
            e.Cancel = true;

            if (_isClosing)
            {
                return;
            }

            _isClosing = true;
            IsEnabled = false;

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

                _enroller?.Dispose();
                _enroller = null;

                VideoView1.CallRefresh();

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            try
            {
                _cleanupFinished = true;
                Dispatcher.BeginInvoke(new Action(() => Close()));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                _isClosing = false;
                _cleanupFinished = false;
                IsEnabled = true;
            }
        }

        private void rbSource_Checked(object sender, RoutedEventArgs e)
        {
            if (pnlWebcam == null || pnlFile == null || pnlRTSP == null)
            {
                return;
            }

            pnlWebcam.Visibility = rbWebcam.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            pnlFile.Visibility = rbFile.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            pnlRTSP.Visibility = rbRTSP.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btSelectVideoFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "Video files|*.mp4;*.mkv;*.avi;*.mov;*.webm;*.ts|All files|*.*" };
            if (dlg.ShowDialog() == true)
            {
                edVideoFile.Text = dlg.FileName;
            }
        }

        private void btSelectDet_Click(object sender, RoutedEventArgs e) => PickOnnx(edDetModel);

        private void btSelectEmb_Click(object sender, RoutedEventArgs e) => PickOnnx(edEmbModel);

        private static void PickOnnx(TextBox box)
        {
            var dlg = new OpenFileDialog { Filter = "ONNX models|*.onnx|All files|*.*" };
            if (dlg.ShowDialog() == true)
            {
                box.Text = dlg.FileName;
            }
        }

        private async void btDownloadDet_Click(object sender, RoutedEventArgs e)
            => await DownloadModelAsync(btDownloadDet, edDetModel, DetectorModelFile);

        private async void btDownloadEmb_Click(object sender, RoutedEventArgs e)
        {
            // Both hosted embedders are downloadable: SFace (128-D) and AuraFace (512-D, ArcFace family).
            // Lock the family selector only around the embedder download (the detector is family-independent), so a
            // mid-download switch can't pair the just-downloaded weights with the other family's preprocessing - and
            // a concurrent detector download can't re-enable it early.
            cbEmbFamily.IsEnabled = false;
            try
            {
                await DownloadModelAsync(btDownloadEmb, edEmbModel, SelectedEmbeddingFile);
            }
            finally
            {
                cbEmbFamily.IsEnabled = true;
            }
        }

        private void cbEmbFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (edEmbModel == null)
            {
                return;
            }

            // Keep the embedding model path consistent with the selected family so SFace (128-D) and AuraFace
            // (512-D, ArcFace family) weights are never paired with the wrong preprocessing.
            var selectedPath = Path.Combine(ModelsCacheDir, SelectedEmbeddingFile);

            if (File.Exists(selectedPath))
            {
                edEmbModel.Text = selectedPath;
            }
            else if (!string.Equals(edEmbModel.Text, selectedPath, StringComparison.OrdinalIgnoreCase))
            {
                // The new family's model isn't cached: clear any leftover path (the other family's cache OR a
                // previously Browsed custom .onnx) so it can't be paired with this family's preprocessing. The user
                // downloads or re-Browses for the selected family.
                edEmbModel.Text = string.Empty;
            }

            // A gallery built with the other model isn't comparable; tell the user it'll be re-embedded.
            if (mmLog != null && _gallery.Count > 0 && _galleryFamily != null && _galleryFamily != cbEmbFamily.SelectedIndex)
            {
                mmLog.Text += (_enrolledPhotos.Count > 0
                    ? "Embedding model changed - the gallery will be rebuilt from the enrolled photos on the next enroll/Start."
                    : "Embedding model changed - the loaded gallery doesn't match and can't be rebuilt; re-enroll or load a matching gallery.")
                    + Environment.NewLine;
            }

            RefreshModelButtons();
        }

        private async System.Threading.Tasks.Task DownloadModelAsync(Button button, TextBox target, string fileName)
        {
            var destPath = Path.Combine(ModelsCacheDir, fileName);
            if (File.Exists(destPath))
            {
                target.Text = destPath;
                RefreshModelButtons();
                return;
            }

            button.IsEnabled = false;
            var tmpPath = destPath + ".part";

            pnlDownload.Visibility = Visibility.Visible;
            pbDownload.IsIndeterminate = false;
            pbDownload.Value = 0;
            lbDownloadStatus.Text = $"Downloading {fileName}...";
            mmLog.Text += $"Downloading {fileName}..." + Environment.NewLine;

            try
            {
                Directory.CreateDirectory(ModelsCacheDir);

                // Stream to a temp file so progress can be reported and an interrupted download never leaves a
                // corrupt .onnx at the final path; rename into place only after the full download succeeds.
                using (var response = await _http.GetAsync(ModelsReleaseUrl + "/" + fileName, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();

                    var total = response.Content.Headers.ContentLength ?? -1L;
                    pbDownload.IsIndeterminate = total <= 0;

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
                                    pbDownload.Value = percent;
                                    lbDownloadStatus.Text = $"Downloading {fileName}... {percent}% ({readTotal / 1024} / {total / 1024} KB)";
                                }
                            }
                            else
                            {
                                lbDownloadStatus.Text = $"Downloading {fileName}... {readTotal / 1024} KB";
                            }
                        }
                    }
                }

                File.Move(tmpPath, destPath, true);

                target.Text = destPath;
                pbDownload.IsIndeterminate = false;
                pbDownload.Value = 100;
                lbDownloadStatus.Text = $"Saved {fileName} ({new FileInfo(destPath).Length / 1024} KB).";
                mmLog.Text += $"Saved to {ModelsCacheDir}." + Environment.NewLine;
                RefreshModelButtons();
            }
            catch (Exception ex)
            {
                try { if (File.Exists(tmpPath)) File.Delete(tmpPath); } catch { }
                pbDownload.IsIndeterminate = false;
                pbDownload.Value = 0;
                lbDownloadStatus.Text = "Download failed.";
                mmLog.Text += $"Download failed: {ex.Message}" + Environment.NewLine;
                MessageBox.Show(this, $"Download failed:\n{ex.Message}\n\nURL: {ModelsReleaseUrl}/{fileName}", "Download Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                button.IsEnabled = true;
            }
        }

        private void cbVideoInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbVideoInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
                {
                    var deviceName = (string)e.AddedItems[0];
                    if (!string.IsNullOrEmpty(deviceName))
                    {
                        cbVideoFormat.Items.Clear();

                        var device = _videoCaptureDevices?.FirstOrDefault(x => x.DisplayName == deviceName);
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void cbVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbVideoFrameRate.Items.Clear();

                if (cbVideoInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
                {
                    var deviceName = cbVideoInput.SelectedValue.ToString();
                    var format = (string)e.AddedItems[0];
                    if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                    {
                        var device = _videoCaptureDevices?.FirstOrDefault(x => x.DisplayName == deviceName);
                        var formatItem = device?.VideoFormats.FirstOrDefault(x => x.Name == format);
                        if (formatItem != null)
                        {
                            foreach (var item in formatItem.GetFrameRateRangeAsStringList())
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        // Reads the current UI into a settings object. The shared gallery is always attached.
        private FaceRecognitionSettings BuildSettings()
        {
            var settings = new FaceRecognitionSettings(edDetModel.Text, edEmbModel.Text)
            {
                Gallery = _gallery,
                EmbeddingModel = cbEmbFamily.SelectedIndex == 1 ? FaceEmbeddingModel.ArcFace : FaceEmbeddingModel.SFace,
                DrawResults = cbDrawResults.IsChecked == true,
                DrawLandmarks = cbDrawLandmarks.IsChecked == true,
            };

            if (int.TryParse(edFramesToSkip.Text, out var skip) && skip >= 0)
            {
                settings.FramesToSkip = skip;
            }

            if (float.TryParse(edDetConfidence.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var detConf))
            {
                settings.DetectionConfidenceThreshold = detConf;
            }

            if (float.TryParse(edRecThreshold.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var recThr))
            {
                settings.RecognitionThreshold = recThr;
            }

            return settings;
        }

        private bool ModelsSelected()
        {
            if (string.IsNullOrWhiteSpace(edDetModel.Text) || string.IsNullOrWhiteSpace(edEmbModel.Text))
            {
                MessageBox.Show(this, "Select (or download) the face detector and embedding models on the Models tab.");
                return false;
            }

            return true;
        }

        private void btEnroll_Click(object sender, RoutedEventArgs e)
        {
            var name = edPersonName.Text?.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(this, "Enter a person name first.");
                return;
            }

            if (!ModelsSelected())
            {
                return;
            }

            // Multiselect: enroll several photos of the same person under one name for more robust matching.
            var dlg = new OpenFileDialog { Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp;*.webp|All files|*.*", Multiselect = true };
            if (dlg.ShowDialog() != true)
            {
                return;
            }

            try
            {
                // If the embedding model changed since the gallery was built, re-embed the existing photos with the
                // current model first; otherwise Add would reject the new (different-dimension) embeddings.
                int family = cbEmbFamily.SelectedIndex;
                EnsureGalleryMatchesModel();

                var enroller = GetEnroller();
                int ok = 0;
                foreach (var file in dlg.FileNames)
                {
                    if (enroller.Enroll(name, file))
                    {
                        ok++;
                        RecordPhoto(name, file);
                        mmLog.Text += $"Enrolled '{name}' from {Path.GetFileName(file)}." + Environment.NewLine;
                    }
                    else
                    {
                        mmLog.Text += $"No face found in {Path.GetFileName(file)} - skipped." + Environment.NewLine;
                    }
                }

                if (ok > 0)
                {
                    _galleryFamily = family;
                    RefreshGalleryList();
                    mmLog.Text += $"Enrolled '{name}' from {ok} of {dlg.FileNames.Length} photo(s)." + Environment.NewLine;
                }
                else
                {
                    MessageBox.Show(this, "No face was found in the selected photo(s). Use clear, front-facing photos.");
                }
            }
            catch (Exception ex)
            {
                mmLog.Text += "Enrollment failed: " + ex.Message + Environment.NewLine;
                Debug.WriteLine(ex);
            }
        }

        // Lazily creates (and reuses) the enroller block, rebuilding it when the model selection changes.
        private FaceRecognitionBlock GetEnroller()
        {
            // Include the detection confidence: it affects whether a face is found during enrollment, so a change
            // must rebuild the enroller rather than silently reuse the old threshold.
            var signature = string.Join("|", edDetModel.Text, edEmbModel.Text, cbEmbFamily.SelectedIndex, edDetConfidence.Text);
            if (_enroller != null && _enrollerSignature == signature)
            {
                return _enroller;
            }

            _enroller?.Dispose();

            var settings = BuildSettings();
            _enroller = new FaceRecognitionBlock(settings);
            _enrollerSignature = signature;
            return _enroller;
        }

        private void RefreshGalleryList()
        {
            lbGallery.Items.Clear();
            foreach (var name in _gallery.GetNames())
            {
                lbGallery.Items.Add(name);
            }
        }

        private void RecordPhoto(string name, string file)
        {
            if (!_enrolledPhotos.TryGetValue(name, out var list))
            {
                list = new System.Collections.Generic.List<string>();
                _enrolledPhotos[name] = list;
            }

            list.Add(file);
        }

        // Ensures the gallery's embeddings match the currently selected embedding model. Embeddings from different
        // models have different dimensions and are not comparable (every face would read as Unknown), so when the
        // model changed since enrollment we re-embed the original photos with the new model.
        private void EnsureGalleryMatchesModel()
        {
            int family = cbEmbFamily.SelectedIndex;
            if (_gallery.Count == 0 || _galleryFamily == family)
            {
                return;
            }

            if (_enrolledPhotos.Count > 0)
            {
                // Don't clear the gallery unless the selected model is actually present - otherwise the rebuild
                // re-embeds nothing and we'd wipe the existing (still-usable) gallery.
                if (!File.Exists(edEmbModel.Text))
                {
                    mmLog.Text += "Embedding model changed but the model file was not found - keeping the existing gallery." + Environment.NewLine;
                    return;
                }

                mmLog.Text += "Embedding model changed - rebuilding the gallery from the enrolled photos..." + Environment.NewLine;
                RebuildGallery(family);
                mmLog.Text += $"Rebuilt gallery: {_gallery.Count} identities." + Environment.NewLine;
            }
            else
            {
                // Loaded from a .vfg with no source photos to re-embed; it can't be rebuilt.
                mmLog.Text += "Warning: the loaded gallery was built with a different embedding model and has no source " +
                              "photos to rebuild from, so faces may read as Unknown. Load a matching gallery or re-enroll." + Environment.NewLine;
            }
        }

        // Clears and re-embeds every enrolled photo with the current model so the gallery matches the selected family.
        private void RebuildGallery(int family)
        {
            // Identities loaded from a .vfg have no tracked source photos, so the re-embed below cannot recreate them.
            var loadedOnly = _gallery.GetNames().Where(n => !_enrolledPhotos.ContainsKey(n)).ToList();

            _gallery.Clear();

            var enroller = GetEnroller();
            foreach (var kv in _enrolledPhotos)
            {
                foreach (var file in kv.Value)
                {
                    try
                    {
                        enroller.Enroll(kv.Key, file);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                }
            }

            // Warn if any enrolled identity could not be re-embedded (e.g. a source photo was moved/deleted), so the
            // shrink isn't silent.
            var lost = _enrolledPhotos.Keys.Where(n => !_gallery.GetNames().Contains(n)).ToList();
            if (lost.Count > 0)
            {
                mmLog.Text += $"Warning: {lost.Count} identity(ies) could not be re-embedded and were dropped: {string.Join(", ", lost)}." + Environment.NewLine;
            }

            if (loadedOnly.Count > 0)
            {
                mmLog.Text += $"Warning: {loadedOnly.Count} loaded identity(ies) without source photos were dropped by the model switch: {string.Join(", ", loadedOnly)}." + Environment.NewLine;
            }

            _galleryFamily = family;
            RefreshGalleryList();
        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbGallery.SelectedItem is string name)
            {
                _gallery.Remove(name);
                _enrolledPhotos.Remove(name);
                if (_gallery.Count == 0)
                {
                    _galleryFamily = null;
                }

                RefreshGalleryList();
            }
        }

        private void btSaveGallery_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog { Filter = "Face gallery|*.vfg|All files|*.*", FileName = "faces.vfg" };
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    _gallery.Save(dlg.FileName);

                    // Persist which embedding family produced these embeddings so a later Load can re-select the
                    // matching model (otherwise the gallery reads as Unknown after a relaunch with a different model).
                    var famPath = dlg.FileName + ".family";
                    if (_galleryFamily != null)
                    {
                        File.WriteAllText(famPath, _galleryFamily.Value.ToString());
                    }
                    else if (File.Exists(famPath))
                    {
                        File.Delete(famPath);
                    }

                    mmLog.Text += $"Saved {_gallery.Count} identities to {dlg.FileName}." + Environment.NewLine;
                }
                catch (Exception ex)
                {
                    mmLog.Text += "Save failed: " + ex.Message + Environment.NewLine;
                }
            }
        }

        private void btLoadGallery_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "Face gallery|*.vfg|All files|*.*" };
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    _gallery.Load(dlg.FileName);

                    // A loaded gallery has no source photos to re-embed.
                    _enrolledPhotos.Clear();

                    // Restore the embedding family from the sidecar (written on Save) and re-select the matching model,
                    // so recognition runs the correct embedder; without it the loaded gallery reads as Unknown.
                    var famPath = dlg.FileName + ".family";
                    if (File.Exists(famPath) && int.TryParse(File.ReadAllText(famPath).Trim(), out var savedFamily)
                        && savedFamily >= 0 && savedFamily < cbEmbFamily.Items.Count)
                    {
                        _galleryFamily = savedFamily;
                        cbEmbFamily.SelectedIndex = savedFamily;
                    }
                    else
                    {
                        _galleryFamily = null;
                    }

                    RefreshGalleryList();
                    mmLog.Text += $"Loaded {_gallery.Count} identities from {dlg.FileName}." + Environment.NewLine;
                }
                catch (Exception ex)
                {
                    mmLog.Text += "Load failed: " + ex.Message + Environment.NewLine;
                }
            }
        }

        private async System.Threading.Tasks.Task<bool> BuildSourceAsync()
        {
            if (rbFile.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(edVideoFile.Text))
                {
                    MessageBox.Show(this, "Select a video file.");
                    return false;
                }

                var settings = await UniversalSourceSettings.CreateAsync(edVideoFile.Text, renderVideo: true, renderAudio: false);
                _videoSource = new UniversalSourceBlock(settings);
                return true;
            }

            if (rbRTSP.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(edRTSPURL.Text) || edRTSPURL.Text.Trim() == "rtsp://")
                {
                    MessageBox.Show(this, "Enter an RTSP URL.");
                    return false;
                }

                var rtspSettings = await RTSPSourceSettings.CreateAsync(new Uri(edRTSPURL.Text.Trim()), edRTSPLogin.Text, edRTSPPassword.Password, audioEnabled: false);
                _videoSource = new RTSPSourceBlock(rtspSettings);
                return true;
            }

            if (cbVideoInput.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Select a video input device.");
                return false;
            }

            VideoCaptureDeviceSourceSettings videoSourceSettings = null;
            var deviceName = cbVideoInput.Text;
            var deviceFormat = cbVideoFormat.Text;
            if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(deviceFormat))
            {
                var device = _videoCaptureDevices?.FirstOrDefault(x => x.DisplayName == deviceName);
                var formatItem = device?.VideoFormats.FirstOrDefault(x => x.Name == deviceFormat);
                if (formatItem != null)
                {
                    videoSourceSettings = new VideoCaptureDeviceSourceSettings(device) { Format = formatItem.ToFormat() };
                    if (!string.IsNullOrEmpty(cbVideoFrameRate.Text))
                    {
                        videoSourceSettings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.Text, CultureInfo.InvariantCulture));
                    }
                }
            }

            if (videoSourceSettings == null)
            {
                MessageBox.Show(this, "Unable to configure the selected video device.");
                return false;
            }

            _videoSource = new SystemVideoSourceBlock(videoSourceSettings);
            return true;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _uiBusy = true;
                btStart.IsEnabled = false;

                if (_pipeline == null)
                {
                    MessageBox.Show(this, "The SDK failed to initialize. Please restart the application.");
                    btStart.IsEnabled = true;
                    return;
                }

                mmLog.Clear();
                lbResults.Items.Clear();

                try
                {
                    await _pipeline.StopAsync();
                    _pipeline.ClearBlocks();
                }
                catch (Exception priorStopEx)
                {
                    Debug.WriteLine(priorStopEx);
                }

                CleanupBlocks();

                if (!ModelsSelected())
                {
                    btStart.IsEnabled = true;
                    return;
                }

                // Make sure the gallery embeddings match the model we're about to run, re-embedding the enrolled
                // photos if the family changed since enrollment (otherwise every face reads as Unknown).
                EnsureGalleryMatchesModel();

                if (!await BuildSourceAsync())
                {
                    btStart.IsEnabled = true;
                    return;
                }

                _isFile = rbFile.IsChecked == true;

                // Live sources run unsynchronized (latest frame wins). A file plays in real time when requested,
                // or as fast as the pipeline can go (max speed) when "Play in real time" is unchecked.
                var realTime = _isFile && cbRealTime.IsChecked == true;
                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = realTime };

                _face = new FaceRecognitionBlock(BuildSettings());
                _face.OnFacesIdentified += Face_OnFacesIdentified;

                _pipeline.Connect(_videoSource.Output, _face.Input);
                _pipeline.Connect(_face.Output, _videoRenderer.Input);

                if (!await _pipeline.StartAsync())
                {
                    mmLog.Text += "Failed to start face recognition - check the model paths and selected device." + Environment.NewLine;
                    try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); } catch (Exception stopEx) { Debug.WriteLine(stopEx); }
                    CleanupBlocks();
                    btStart.IsEnabled = true;
                    return;
                }

                mmLog.Text += $"Face recognition running on: {_face.ActiveProvider}" + Environment.NewLine;
                mmLog.Text += $"Gallery: {_gallery.Count} identities." + Environment.NewLine;

                // Enable the seek bar for file playback. Duration is often not ready right after Start (the
                // demuxer reports it once playback prerolls), so it is resolved lazily in the timer.
                _duration = TimeSpan.Zero;
                _suppressSeek = true;
                slSeek.Value = 0;
                _suppressSeek = false;
                slSeek.IsEnabled = _isFile;

                _timer.Start();
                btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                try
                {
                    await _pipeline.StopAsync();
                    _pipeline.ClearBlocks();
                }
                catch (Exception cleanupEx)
                {
                    Debug.WriteLine(cleanupEx);
                }

                CleanupBlocks();

                btStart.IsEnabled = true;
                btStop.IsEnabled = false;

                mmLog.Text += ex.Message + Environment.NewLine;
                Debug.WriteLine(ex);
            }
            finally
            {
                _uiBusy = false;
            }
        }

        private void Face_OnFacesIdentified(object sender, FacesIdentifiedEventArgs e)
        {
            // Marshal to the UI thread without blocking the recognizer worker.
            Dispatcher.BeginInvoke(new Action(() =>
            {
                foreach (var face in e.Faces)
                {
                    var label = string.IsNullOrEmpty(face.Identity)
                        ? "Unknown"
                        : $"{face.Identity} ({face.Similarity:P0})";
                    lbResults.Items.Insert(0, $"[{e.Timestamp:hh\\:mm\\:ss}] {label}");
                }

                while (lbResults.Items.Count > 300)
                {
                    lbResults.Items.RemoveAt(lbResults.Items.Count - 1);
                }
            }));
        }

        private void CleanupBlocks()
        {
            if (_face != null)
            {
                _face.OnFacesIdentified -= Face_OnFacesIdentified;
                _face.Dispose();
                _face = null;
            }

            _videoRenderer = null;
            _videoSource = null;
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _uiBusy = true;
                btStop.IsEnabled = false;

                _timer?.Stop();

                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    _pipeline.ClearBlocks();
                }

                CleanupBlocks();

                VideoView1.CallRefresh();

                slSeek.IsEnabled = false;
                _suppressSeek = true;
                slSeek.Value = 0;
                _suppressSeek = false;

                btStart.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                _uiBusy = false;
            }
        }
    }
}
