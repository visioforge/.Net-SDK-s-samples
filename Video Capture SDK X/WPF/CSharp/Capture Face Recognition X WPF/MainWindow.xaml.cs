using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace Capture_Face_Recognition_X_WPF
{
    /// <summary>
    /// Inserts a deep-learning face recognizer into VideoCaptureCoreX through the Video_Processing_AddBlock
    /// API: the recognizer taps the live camera frames, draws labelled boxes into the preview, and raises
    /// OnFacesIdentified (matched 1:N against an enrolled gallery) while the engine previews the camera.
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCaptureCoreX _core;

        // Live recognizer added to the engine. The engine owns and disposes it on stop.
        private FaceRecognitionBlock _face;

        // Persistent block used only to compute embeddings for enrollment (never added to the engine).
        private FaceRecognitionBlock _enroller;
        private string _enrollerSignature;

        // Shared gallery: enrollment writes into it and the live recognizer matches against it.
        private readonly FaceGallery _gallery = new FaceGallery();

        // Source photos per identity, so the gallery can be re-embedded when the embedding model changes.
        private readonly System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> _enrolledPhotos
            = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>(StringComparer.Ordinal);

        // Embedding family (cbEmbFamily index) the gallery was built with; null when empty or loaded from a .vfg.
        private int? _galleryFamily;

        private VideoCaptureDeviceInfo[] _cameras;

        private bool _isClosing;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        // Set while an enroll loop runs on a background thread; teardown drains it before disposing the enroller.
        private volatile bool _enrollInProgress;

        // Set while RebuildGalleryAsync re-embeds on a background thread; teardown drains it before disposing the enroller.
        private volatile bool _rebuildInProgress;

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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Log(string text)
        {
            if (_isClosing)
            {
                return;
            }

            Dispatcher.BeginInvoke(new Action(() => mmLog.AppendText(text + Environment.NewLine)));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();

                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync() ?? Array.Empty<VideoCaptureDeviceInfo>();
                foreach (var cam in _cameras)
                {
                    cbCamera.Items.Add(cam.DisplayName);
                }

                if (cbCamera.Items.Count > 0)
                {
                    cbCamera.SelectedIndex = 0;
                }

                // The engine is created fresh per session in btStart_Click (RecreateEngineAsync).

                cbEmbFamily.Items.Add("SFace (128-D)");
                cbEmbFamily.Items.Add("AuraFace (512-D)");
                cbEmbFamily.SelectedIndex = 0;

                // Prefill the model paths from the cache directory when the models were already downloaded.
                PrefillFromCache(edDetModel, DetectorModelFile);
                PrefillFromCache(edEmbModel, EmbeddingModelFile);
                RefreshModelButtons();

                Log($"SDK v{VideoCaptureCoreX.SDK_Version} ready.");
                Log("ONNX Runtime providers: " + string.Join(", ", OnnxInferenceEngine.GetAvailableProviders()));
                Log("Models are cached under %USERPROFILE%/VisioForge/models. Weights are NOT shipped with the SDK.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsEnabled = true;
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

        // Show each Download button only when its model is missing from the cache.
        private void RefreshModelButtons()
        {
            btDownloadDet.Visibility = File.Exists(Path.Combine(ModelsCacheDir, DetectorModelFile))
                ? Visibility.Collapsed : Visibility.Visible;

            var embCached = File.Exists(Path.Combine(ModelsCacheDir, SelectedEmbeddingFile));
            btDownloadEmb.Visibility = embCached ? Visibility.Collapsed : Visibility.Visible;

            var auraSelected = cbEmbFamily.SelectedIndex == 1;
            lbEmbHint.Visibility = auraSelected ? Visibility.Visible : Visibility.Collapsed;
            lbEmbHint.Text = "AuraFace 512-D embedder (Apache-2.0, by fal) - commercial-friendly. Downloads on demand, or Browse for your own ArcFace-family .onnx.";
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
            // Lock the family selector during the download so a mid-download switch can't mispair weights with preprocessing.
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

            // Keep the embedding model path in sync with the selected family.
            var selectedPath = Path.Combine(ModelsCacheDir, SelectedEmbeddingFile);

            if (File.Exists(selectedPath))
            {
                edEmbModel.Text = selectedPath;
            }
            else if (!string.Equals(edEmbModel.Text, selectedPath, StringComparison.OrdinalIgnoreCase))
            {
                edEmbModel.Text = string.Empty;
            }

            if (mmLog != null && _gallery.Count > 0 && _galleryFamily != null && _galleryFamily != cbEmbFamily.SelectedIndex)
            {
                Log(_enrolledPhotos.Count > 0
                    ? "Embedding model changed - the gallery will be rebuilt from the enrolled photos on the next enroll/Start."
                    : "Embedding model changed - the loaded gallery doesn't match and can't be rebuilt; re-enroll or load a matching gallery.");
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
            Log($"Downloading {fileName}...");

            try
            {
                Directory.CreateDirectory(ModelsCacheDir);

                // Download off the UI thread, streaming to a .part temp file and renaming into place on success.
                await Task.Run(async () =>
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
                            long lastReportedMb = -1;
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
                                        var doneKb = readTotal / 1024;
                                        var totalKb = total / 1024;
                                        Dispatcher.BeginInvoke(new Action(() =>
                                        {
                                            pbDownload.Value = percent;
                                            lbDownloadStatus.Text = $"Downloading {fileName}... {percent}% ({doneKb} / {totalKb} KB)";
                                        }));
                                    }
                                }
                                else
                                {
                                    // No Content-Length: throttle progress to whole-MB steps.
                                    var doneMb = readTotal / 1024 / 1024;
                                    if (doneMb != lastReportedMb)
                                    {
                                        lastReportedMb = doneMb;
                                        var doneKb = readTotal / 1024;
                                        Dispatcher.BeginInvoke(new Action(() => lbDownloadStatus.Text = $"Downloading {fileName}... {doneKb} KB"));
                                    }
                                }
                            }
                        }
                    }

                    if (File.Exists(destPath)) { File.Delete(destPath); }
                    File.Move(tmpPath, destPath);
                });

                target.Text = destPath;
                pbDownload.IsIndeterminate = false;
                pbDownload.Value = 100;
                lbDownloadStatus.Text = $"Saved {fileName} ({new FileInfo(destPath).Length / 1024} KB).";
                Log($"Saved to {ModelsCacheDir}.");
                RefreshModelButtons();
            }
            catch (Exception ex)
            {
                try { if (File.Exists(tmpPath)) File.Delete(tmpPath); } catch { }
                pbDownload.IsIndeterminate = false;
                pbDownload.Value = 0;
                lbDownloadStatus.Text = "Download failed.";
                Log($"Download failed: {ex.Message}");
                MessageBox.Show(this, $"Download failed:\n{ex.Message}\n\nURL: {ModelsReleaseUrl}/{fileName}", "Download Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                button.IsEnabled = true;
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

            if (!File.Exists(edDetModel.Text) || !File.Exists(edEmbModel.Text))
            {
                MessageBox.Show(this, "One or both model files do not exist. Check the paths or download them on the Models tab.");
                return false;
            }

            return true;
        }

        private async void btEnroll_Click(object sender, RoutedEventArgs e)
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

            // Enroll is mutually exclusive with another enroll, a Start/Stop transition, and window teardown.
            if (_isClosing || _enrollInProgress || Volatile.Read(ref _startStopBusy) != 0)
            {
                return;
            }

            _enrollInProgress = true;

            try
            {
                btEnroll.IsEnabled = false;

                int family = cbEmbFamily.SelectedIndex;

                // Loaded gallery built with a different family and no source photos to rebuild from — can't mix dimensions.
                if (_gallery.Count > 0 && _galleryFamily != family && _enrolledPhotos.Count == 0)
                {
                    MessageBox.Show(this, "The loaded gallery was built with a different embedding family. " +
                        "Re-select the gallery's family or Clear the gallery before enrolling.");
                    return;
                }

                await EnsureGalleryMatchesModelAsync();

                var enroller = GetEnroller();
                int ok = 0;
                foreach (var file in dlg.FileNames)
                {
                    // Stop the batch if the window is closing so it doesn't keep the enroller busy past teardown.
                    if (_isClosing)
                    {
                        break;
                    }

                    try
                    {
                        // Offload the heavy synchronous detection + embedding inference off the UI thread.
                        if (await Task.Run(() => enroller.Enroll(name, file)))
                        {
                            ok++;
                            RecordPhoto(name, file);
                            Log($"Enrolled '{name}' from {Path.GetFileName(file)}.");
                        }
                        else
                        {
                            Log($"No face found in {Path.GetFileName(file)} - skipped.");
                        }
                    }
                    catch (Exception photoEx)
                    {
                        // One bad photo (mismatched dimensions / unreadable) must not abort the whole batch.
                        Log($"Could not enroll {Path.GetFileName(file)}: {photoEx.Message}");
                        Debug.WriteLine(photoEx);
                    }
                }

                if (ok > 0)
                {
                    _galleryFamily = family;
                    RefreshGalleryList();
                    Log($"Enrolled '{name}' from {ok} of {dlg.FileNames.Length} photo(s).");
                }
                else
                {
                    MessageBox.Show(this, "No face was found in the selected photo(s). Use clear, front-facing photos.");
                }
            }
            catch (Exception ex)
            {
                Log("Enrollment failed: " + ex.Message);
                Debug.WriteLine(ex);
            }
            finally
            {
                _enrollInProgress = false;
                btEnroll.IsEnabled = true;
            }
        }

        // Lazily creates (and reuses) the enroller block, rebuilding it when the model selection changes.
        private FaceRecognitionBlock GetEnroller()
        {
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

        // Re-embeds the gallery from the original photos when the embedding model changed since enrollment.
        private async System.Threading.Tasks.Task EnsureGalleryMatchesModelAsync()
        {
            int family = cbEmbFamily.SelectedIndex;
            if (_gallery.Count == 0 || _galleryFamily == family)
            {
                return;
            }

            if (_enrolledPhotos.Count > 0)
            {
                if (!File.Exists(edEmbModel.Text))
                {
                    Log("Embedding model changed but the model file was not found - keeping the existing gallery.");
                    return;
                }

                Log("Embedding model changed - rebuilding the gallery from the enrolled photos...");
                await RebuildGalleryAsync(family);
                Log($"Rebuilt gallery: {_gallery.Count} identities.");
            }
            else
            {
                Log("Warning: the loaded gallery was built with a different embedding model and has no source " +
                    "photos to rebuild from, so faces may read as Unknown. Load a matching gallery or re-enroll.");
            }
        }

        // Clears and re-embeds every enrolled photo with the current model (on a background thread, CPU-heavy).
        private async System.Threading.Tasks.Task RebuildGalleryAsync(int family)
        {
            // Mark the rebuild so teardown drains it before disposing the enroller.
            _rebuildInProgress = true;
            try
            {
                var loadedOnly = _gallery.GetNames().Where(n => !_enrolledPhotos.ContainsKey(n)).ToList();

                _gallery.Clear();

                var enroller = GetEnroller();
                var photos = _enrolledPhotos.SelectMany(kv => kv.Value.Select(file => (kv.Key, file))).ToList();
                await System.Threading.Tasks.Task.Run(() =>
                {
                    foreach (var (name, file) in photos)
                    {
                        // Stop re-embedding if the window is closing so the loop drains promptly.
                        if (_isClosing)
                        {
                            break;
                        }

                        try
                        {
                            enroller.Enroll(name, file);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                        }
                    }
                });

                var lost = _enrolledPhotos.Keys.Where(n => !_gallery.GetNames().Contains(n)).ToList();
                if (lost.Count > 0)
                {
                    Log($"Warning: {lost.Count} identity(ies) could not be re-embedded and were dropped: {string.Join(", ", lost)}.");
                }

                if (loadedOnly.Count > 0)
                {
                    Log($"Warning: {loadedOnly.Count} loaded identity(ies) without source photos were dropped by the model switch: {string.Join(", ", loadedOnly)}.");
                }

                _galleryFamily = family;
                RefreshGalleryList();
            }
            finally
            {
                _rebuildInProgress = false;
            }
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

                    // Persist the embedding family in a sidecar so a later Load can re-select the matching model.
                    var famPath = dlg.FileName + ".family";
                    if (_galleryFamily != null)
                    {
                        File.WriteAllText(famPath, _galleryFamily.Value.ToString());
                    }
                    else if (File.Exists(famPath))
                    {
                        File.Delete(famPath);
                    }

                    Log($"Saved {_gallery.Count} identities to {dlg.FileName}.");
                }
                catch (Exception ex)
                {
                    Log("Save failed: " + ex.Message);
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
                    Log($"Loaded {_gallery.Count} identities from {dlg.FileName}.");
                }
                catch (Exception ex)
                {
                    Log("Load failed: " + ex.Message);
                }
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

            _core = new VideoCaptureCoreX(VideoView1 as IVideoView);
            _core.OnError += Core_OnError;
            _core.OnStop += Core_OnStop;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (_cameras == null || _cameras.Length == 0 || cbCamera.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Select a camera on the Source tab.");
                return;
            }

            if (!ModelsSelected())
            {
                return;
            }

            // Don't start while an enroll loop is running against the shared enroller.
            if (_enrollInProgress)
            {
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
                lbResults.Items.Clear();

                // Make sure the gallery embeddings match the model we're about to run.
                await EnsureGalleryMatchesModelAsync();

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
                    Log("start error: unable to read a camera format.");
                    await CleanupAfterStopAsync();
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

                _face = new FaceRecognitionBlock(BuildSettings());
                _face.OnFacesIdentified += Face_OnFacesIdentified;
                _core.Video_Processing_AddBlock(_face);

                if (!await _core.StartAsync())
                {
                    Log("start error: failed to start capture.");
                    await CleanupAfterStopAsync();
                    btStart.IsEnabled = true;
                    return;
                }

                Log($"Face recognition running on: {_face.ActiveProvider}");
                Log($"Gallery: {_gallery.Count} identities.");
                btStop.IsEnabled = true;

                // Lock gallery-mutating controls while the recognizer reads _gallery on the pipeline thread.
                SetGalleryControlsEnabled(false);
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

        private void Face_OnFacesIdentified(object sender, FacesIdentifiedEventArgs e)
        {
            // Marshal to the UI thread without blocking the recognizer worker.
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_isClosing || e.Faces == null)
                {
                    return;
                }

                foreach (var face in e.Faces)
                {
                    if (face == null)
                    {
                        continue;
                    }

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

                // Ignore a stale Stop from a previous session (explicit Stop -> Start) so it can't reset the live UI.
                if (Volatile.Read(ref _startStopBusy) != 0)
                {
                    return;
                }

                if (_core != null && _core.State != PlaybackState.Free)
                {
                    return;
                }

                DetachBlock();
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
                SetGalleryControlsEnabled(true);
            }));
        }

        private void SetGalleryControlsEnabled(bool enabled)
        {
            btEnroll.IsEnabled = enabled;
            btRemove.IsEnabled = enabled;
            btLoadGallery.IsEnabled = enabled;
            cbEmbFamily.IsEnabled = enabled;
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            // Don't stop while an enroll loop is running against the shared enroller.
            if (_enrollInProgress)
            {
                return;
            }

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
            SetGalleryControlsEnabled(true);
        }

        private async System.Threading.Tasks.Task CleanupAfterStopAsync()
        {
            if (_core != null)
            {
                await _core.StopAsync();
            }

            DetachBlock();
        }

        /// <summary>
        /// Detaches the handler and drops the recognizer reference (the engine owns and disposes the block itself).
        /// </summary>
        private void DetachBlock()
        {
            if (_face != null)
            {
                _face.OnFacesIdentified -= Face_OnFacesIdentified;
                _face = null;
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

            // Drain an in-flight enroll/rebuild before disposing the shared enroller (avoids a native use-after-free).
            while (_enrollInProgress || _rebuildInProgress)
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

                DetachBlock();

                _enroller?.Dispose();
                _enroller = null;

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
