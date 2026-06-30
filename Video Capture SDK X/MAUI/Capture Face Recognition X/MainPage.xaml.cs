using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.MAUI;
using VisioForge.Core.VideoCaptureX;

namespace Capture_Face_Recognition_X
{
    /// <summary>
    /// Inserts a deep-learning face recognizer into VideoCaptureCoreX through the X-engine
    /// Video_Processing_AddBlock API. The recognizer taps the live camera frames, draws labelled boxes
    /// into the preview, and raises OnFacesIdentified (matched 1:N against an enrolled gallery) while the
    /// engine previews the camera. People are enrolled from photos with a second, app-owned recognizer.
    /// </summary>
    public partial class MainPage : ContentPage
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
        private readonly Dictionary<string, List<string>> _enrolledPhotos
            = new Dictionary<string, List<string>>(StringComparer.Ordinal);

        // The embedding family the current gallery embeddings were built with; null when unknown (empty or loaded .vfg).
        private int? _galleryFamily;

        private VideoCaptureDeviceInfo[] _cameras;
        private int _cameraSelectedIndex;

        private bool _isRunning;
        private bool _isCleanedUp;

        // Single-shot atomic claim so concurrent Unloaded + Window.Destroying can't both run teardown.
        private int _cleanupClaimed;

        private Window _window;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        // Set while an enroll loop runs on a background thread; teardown drains it before disposing the enroller.
        private volatile bool _enrollInProgress;

        // Set while RebuildGalleryAsync re-embeds on a background thread; teardown drains it before disposing the enroller.
        private volatile bool _rebuildInProgress;

        // Cancels an in-flight model download when the page is torn down (navigated away / closed).
        private CancellationTokenSource _downloadCts;

        // Resolved model paths (filled by download or prefilled from the cache on load).
        private string _detModelPath;
        private string _embModelPath;

        // OpenCV Zoo model file names hosted in the SDK samples release. Weights are NOT shipped with the SDK.
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

        private const string DetectorModelFile = "face_detection_yunet_2023mar.onnx"; // YuNet (MIT)
        private const string EmbeddingModelFile = "face_recognition_sface_2021dec.onnx"; // SFace (Apache-2.0)
        private const string AuraFaceModelFile = "face_recognition_auraface_v1.onnx"; // AuraFace r100, ArcFace family (Apache-2.0, by fal)

        // The embedding model file for the currently selected family (index 1 = AuraFace/ArcFace 512-D).
        private string SelectedEmbeddingFile => pkEmbFamily.SelectedIndex == 1 ? AuraFaceModelFile : EmbeddingModelFile;

        // Downloaded models are cached here; AppDataDirectory is writable on every platform.
        private static string ModelsCacheDir => Path.Combine(FileSystem.AppDataDirectory, "models");

        // Picked photos are copied here before enrollment (a packaged app can't open the picked path with the native decoder).
        private static string EnrolledPhotosDir => Path.Combine(FileSystem.AppDataDirectory, "enrolled_photos");

        // Fixed gallery path in app data (MAUI has no Save/Load file dialogs across all platforms).
        private static string GalleryPath => Path.Combine(FileSystem.AppDataDirectory, "faces.vfg");

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

        static MainPage()
        {
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("VisioForge-AI-Demo/1.0");
        }

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;
        }

        private async void MainPage_Loaded(object sender, EventArgs e)
        {
            // Re-arm cleanup/guard flags: MAUI reuses the page instance after an Unloaded teardown.
            _isCleanedUp = false;
            _isRunning = false;
            _enrollInProgress = false;
            _rebuildInProgress = false;
            Interlocked.Exchange(ref _cleanupClaimed, 0);
            Interlocked.Exchange(ref _startStopBusy, 0);

            try
            {
#if __ANDROID__ || __MACOS__ || __MACCATALYST__ || __IOS__
                await RequestCameraPermissionAsync();
#endif

                await VisioForgeX.InitSDKAsync();

                // Page torn down during the await (fast navigation away): CleanupAsync already ran, so bail.
                if (_isCleanedUp)
                {
                    return;
                }

                // The engine is created fresh per session in StartAsync (RecreateEngineAsync).

                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
                if (_cameras != null && _cameras.Length > 0)
                {
                    // Reset the index so a stale prior-session value can't point at a different camera than the one shown.
                    _cameraSelectedIndex = 0;
                    btCamera.Text = _cameras[0].DisplayName;
                }

                // Populate the embedding family selector.
                pkEmbFamily.ItemsSource = new List<string> { "SFace (128-D)", "AuraFace (512-D)" };
                pkEmbFamily.SelectedIndex = 0;

                // Prefill model paths from the cache when the models were already downloaded.
                PrefillFromCache(ref _detModelPath, DetectorModelFile);
                PrefillFromCache(ref _embModelPath, SelectedEmbeddingFile);

                // Restore a previously saved gallery only on a fresh page — a re-Loaded (MAUI reuses the
                // page instance on navigation) must not clobber unsaved in-memory enrollments.
                if (_gallery.Count == 0 && _enrolledPhotos.Count == 0)
                {
                    LoadGalleryFromAppData();
                }

                RefreshModelStatus();

                // Drop persisted photos only on a genuinely fresh state (nothing enrolled in memory).
                try { if (_enrolledPhotos.Count == 0 && Directory.Exists(EnrolledPhotosDir)) Directory.Delete(EnrolledPhotosDir, true); } catch (Exception ex) { Debug.WriteLine(ex); }

                _window = Window;
                if (_window != null)
                {
                    _window.Destroying += Window_Destroying;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                SetStatus("Init error: " + ex.Message);
            }
        }

        private async Task RequestCameraPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Camera>();
            if (result != PermissionStatus.Granted && Permissions.ShouldShowRationale<Permissions.Camera>())
            {
                if (await DisplayAlert("Camera permission", "You need to allow access to the Camera to recognize faces.", "OK", "Cancel"))
                {
                    await RequestCameraPermissionAsync();
                }
            }
        }

        private static void PrefillFromCache(ref string target, string fileName)
        {
            var path = Path.Combine(ModelsCacheDir, fileName);
            if (File.Exists(path))
            {
                target = path;
            }
        }

        // Updates the models label / download-button visibility from the current cache state.
        private void RefreshModelStatus()
        {
            var detCached = File.Exists(Path.Combine(ModelsCacheDir, DetectorModelFile));
            var embCached = File.Exists(Path.Combine(ModelsCacheDir, SelectedEmbeddingFile));

            if (detCached && embCached)
            {
                btDownloadModels.IsVisible = false;
                lbModels.Text = $"Models ready: YuNet + {(pkEmbFamily.SelectedIndex == 1 ? "AuraFace" : "SFace")}.";
            }
            else
            {
                btDownloadModels.IsVisible = true;
                lbModels.Text = "Models not downloaded - tap Download models.";
            }
        }

        private void pkEmbFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isCleanedUp)
            {
                return;
            }

            // Keep the embedding model path consistent with the selected family (weights and preprocessing must match).
            var selectedPath = Path.Combine(ModelsCacheDir, SelectedEmbeddingFile);
            _embModelPath = File.Exists(selectedPath) ? selectedPath : null;

            if (_gallery.Count > 0 && _galleryFamily != null && _galleryFamily != pkEmbFamily.SelectedIndex)
            {
                SetStatus(_enrolledPhotos.Count > 0
                    ? "Embedding model changed - the gallery will be rebuilt from the enrolled photos on the next enroll/Start."
                    : "Embedding model changed - the loaded gallery doesn't match and can't be rebuilt; re-enroll or load a matching gallery.");
            }

            RefreshModelStatus();
        }

        private async void btDownloadModels_Clicked(object sender, EventArgs e)
        {
            Directory.CreateDirectory(ModelsCacheDir);

            btDownloadModels.IsEnabled = false;
            var originalText = btDownloadModels.Text;
            pbDownload.Progress = 0;
            pbDownload.IsVisible = true;

            // Lock the family selector during the embedder download so a mid-download switch can't mismatch the weights.
            pkEmbFamily.IsEnabled = false;

            var cts = new CancellationTokenSource();
            _downloadCts = cts;
            try
            {
                // Face detector (family-independent).
                var detDest = Path.Combine(ModelsCacheDir, DetectorModelFile);
                if (!File.Exists(detDest))
                {
                    btDownloadModels.Text = "Downloading detector...";
                    await DownloadModelWithProgressAsync(ModelsReleaseUrl + "/" + DetectorModelFile, detDest, cts.Token);
                }

                _detModelPath = detDest;

                // Embedder for the selected family.
                var embFile = SelectedEmbeddingFile;
                var embDest = Path.Combine(ModelsCacheDir, embFile);
                if (!File.Exists(embDest))
                {
                    btDownloadModels.Text = "Downloading embedder...";
                    await DownloadModelWithProgressAsync(ModelsReleaseUrl + "/" + embFile, embDest, cts.Token);
                }

                _embModelPath = embDest;
                pbDownload.Progress = 1;
                RefreshModelStatus();
            }
            catch (OperationCanceledException) when (cts.Token.IsCancellationRequested)
            {
                // Page torn down mid-download (our token fired); nothing to surface.
            }
            catch (Exception ex)
            {
                lbModels.Text = "Download failed.";
                await DisplayAlert("Download failed", $"{ex.Message}\n\nURL: {ModelsReleaseUrl}", "OK");
            }
            finally
            {
                if (ReferenceEquals(_downloadCts, cts))
                {
                    _downloadCts = null;
                }

                cts.Dispose();

                if (!_isCleanedUp)
                {
                    pbDownload.IsVisible = false;
                    pkEmbFamily.IsEnabled = true;
                    btDownloadModels.IsEnabled = true;
                    btDownloadModels.Text = originalText;
                }
            }
        }

        // Streams the model to a .part file off the UI thread, reporting progress via the bar and label,
        // then moves it into place. Rejects a truncated download so a partial file is never cached.
        private async Task DownloadModelWithProgressAsync(string url, string dest, CancellationToken token)
        {
            Directory.CreateDirectory(ModelsCacheDir);
            var temp = dest + ".part";
            var fileName = Path.GetFileName(dest);

            try
            {
                // Run the network + disk loop off the UI thread; progress is marshalled back via the Dispatcher.
                await Task.Run(async () =>
                {
                    using (var response = await _http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, token))
                    {
                        response.EnsureSuccessStatusCode();
                        var total = response.Content.Headers.ContentLength ?? -1L;

                        using (var src = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = File.Create(temp))
                        {
                            var buffer = new byte[81920];
                            long readTotal = 0;
                            int lastPercent = -1;
                            int read;
                            while ((read = await src.ReadAsync(buffer, 0, buffer.Length, token)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, read, token);
                                readTotal += read;

                                // Throttle UI updates to whole-percent steps so they don't flood the dispatcher.
                                if (total > 0)
                                {
                                    var percent = (int)(readTotal * 100 / total);
                                    if (percent != lastPercent)
                                    {
                                        lastPercent = percent;
                                        var fraction = percent / 100.0;
                                        var doneMb = readTotal / 1024 / 1024;
                                        var totalMb = total / 1024 / 1024;
                                        Dispatcher?.Dispatch(() =>
                                        {
                                            pbDownload.Progress = fraction;
                                            lbModels.Text = $"Downloading {fileName}... {percent}%  ({doneMb} / {totalMb} MB)";
                                        });
                                    }
                                }
                                else
                                {
                                    var doneMb = readTotal / 1024 / 1024;
                                    Dispatcher?.Dispatch(() => lbModels.Text = $"Downloading {fileName}... {doneMb} MB");
                                }
                            }

                            // Reject a truncated download so a partial file is never promoted to the cache.
                            if (total > 0 && readTotal != total)
                            {
                                throw new IOException($"Incomplete download: received {readTotal} of {total} bytes.");
                            }
                        }
                    }

                    File.Move(temp, dest, overwrite: true);
                });
            }
            catch
            {
                // Best-effort cleanup of the partial file so a failed/cancelled download doesn't orphan it.
                try { if (File.Exists(temp)) File.Delete(temp); } catch { }
                throw;
            }
        }

        // Reads the current model paths / family into a settings object. The shared gallery is always attached.
        private FaceRecognitionSettings BuildSettings()
        {
            return new FaceRecognitionSettings(_detModelPath, _embModelPath)
            {
                Gallery = _gallery,
                EmbeddingModel = pkEmbFamily.SelectedIndex == 1 ? FaceEmbeddingModel.ArcFace : FaceEmbeddingModel.SFace,
                DrawResults = true,
                FramesToSkip = 2,
                DetectionConfidenceThreshold = 0.6f,
                RecognitionThreshold = 0.36f,
            };
        }

        private bool ModelsSelected()
        {
            if (string.IsNullOrWhiteSpace(_detModelPath) || string.IsNullOrWhiteSpace(_embModelPath)
                || !File.Exists(_detModelPath) || !File.Exists(_embModelPath))
            {
                return false;
            }

            return true;
        }

        private async void btEnroll_Clicked(object sender, EventArgs e)
        {
            var name = edPersonName.Text?.Trim();
            if (string.IsNullOrEmpty(name))
            {
                await DisplayAlert("Enroll", "Enter a person name first.", "OK");
                return;
            }

            if (!ModelsSelected())
            {
                await DisplayAlert("Models required", "Download the face detector and embedding models first.", "OK");
                return;
            }

            // Claim the enroll guard before opening the picker (which yields), and stay mutually exclusive with
            // Start/Stop and teardown. Its own flag (not _startStopBusy) keeps Core_OnStop from misreading a stop.
            if (_isCleanedUp || _enrollInProgress || Volatile.Read(ref _startStopBusy) != 0)
            {
                return;
            }

            _enrollInProgress = true;

            try
            {
                btEnroll.IsEnabled = false;

                IEnumerable<FileResult> picks;
                try
                {
                    // Multiselect: enroll several photos of the same person under one name for more robust matching.
                    picks = await FilePicker.Default.PickMultipleAsync(new PickOptions { PickerTitle = "Pick photo(s) to enroll" });
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Could not open the file picker: " + ex.Message, "OK");
                    return;
                }

                if (picks == null)
                {
                    return;
                }

                var files = picks.ToList();
                if (files.Count == 0)
                {
                    return;
                }

                // Page torn down while the picker was open: don't touch controls.
                if (_isCleanedUp)
                {
                    return;
                }

                int family = pkEmbFamily.SelectedIndex;

                // Loaded gallery built with a different family and no source photos to rebuild from: stop and tell the user.
                if (_gallery.Count > 0 && _galleryFamily != family && _enrolledPhotos.Count == 0)
                {
                    await DisplayAlert("Family mismatch", "The loaded gallery was built with a different embedding " +
                        "family. Re-select the gallery's family or Clear the gallery before enrolling.", "OK");
                    return;
                }

                await EnsureGalleryMatchesModelAsync();

                Directory.CreateDirectory(EnrolledPhotosDir);

                var enroller = GetEnroller();
                int ok = 0;
                foreach (var file in files)
                {
                    // Stop processing remaining photos once the page is being torn down.
                    if (_isCleanedUp)
                    {
                        break;
                    }

                    // A packaged app can't open the picked path with the native decoder — copy to app-data and enroll from there.
                    var persisted = Path.Combine(EnrolledPhotosDir, $"{Guid.NewGuid():N}{Path.GetExtension(file.FileName)}");
                    try
                    {
                        using (var src = await file.OpenReadAsync())
                        using (var dst = File.Create(persisted))
                        {
                            await src.CopyToAsync(dst);
                        }

                        // Offload the heavy synchronous detection + embedding inference off the UI thread.
                        if (await Task.Run(() => enroller.Enroll(name, persisted)))
                        {
                            ok++;
                            RecordPhoto(name, persisted);
                        }
                        else
                        {
                            try { File.Delete(persisted); } catch { /* best effort */ }
                        }
                    }
                    catch (Exception photoEx)
                    {
                        // One bad photo (mismatched dimensions / unreadable) must not abort the whole batch.
                        try { File.Delete(persisted); } catch { /* best effort */ }
                        Debug.WriteLine(photoEx);
                    }
                }

                // The enroll loop awaited Task.Run, which pumps the UI: a teardown may have completed in between.
                if (_isCleanedUp)
                {
                    return;
                }

                if (ok > 0)
                {
                    _galleryFamily = family;
                    RefreshGalleryList();
                    SetStatus($"Enrolled '{name}' from {ok} of {files.Count} photo(s).");
                }
                else
                {
                    await DisplayAlert("No face", "No face was found in the selected photo(s). Use clear, front-facing photos.", "OK");
                }
            }
            catch (Exception ex)
            {
                SetStatus("Enrollment failed: " + ex.Message);
                Debug.WriteLine(ex);
            }
            finally
            {
                _enrollInProgress = false;
                if (!_isCleanedUp)
                {
                    btEnroll.IsEnabled = true;
                }
            }
        }

        // Lazily creates (and reuses) the enroller block, rebuilding it when the model selection changes.
        private FaceRecognitionBlock GetEnroller()
        {
            var signature = string.Join("|", _detModelPath, _embModelPath, pkEmbFamily.SelectedIndex);
            if (_enroller != null && _enrollerSignature == signature)
            {
                return _enroller;
            }

            _enroller?.Dispose();

            _enroller = new FaceRecognitionBlock(BuildSettings());
            _enrollerSignature = signature;
            return _enroller;
        }

        private void RefreshGalleryList()
        {
            cvGallery.ItemsSource = _gallery.GetNames().ToList();
        }

        private void RecordPhoto(string name, string file)
        {
            if (!_enrolledPhotos.TryGetValue(name, out var list))
            {
                list = new List<string>();
                _enrolledPhotos[name] = list;
            }

            list.Add(file);
        }

        // Re-embeds the gallery from the original photos when the embedding model changed since enrollment.
        private async Task EnsureGalleryMatchesModelAsync()
        {
            int family = pkEmbFamily.SelectedIndex;
            if (_gallery.Count == 0 || _galleryFamily == family)
            {
                return;
            }

            if (_enrolledPhotos.Count > 0)
            {
                if (!File.Exists(_embModelPath))
                {
                    SetStatus("Embedding model changed but the model file was not found - keeping the existing gallery.");
                    return;
                }

                SetStatus("Embedding model changed - rebuilding the gallery from the enrolled photos...");
                await RebuildGalleryAsync(family);
            }
            else
            {
                SetStatus("Warning: the loaded gallery was built with a different embedding model and has no source " +
                    "photos to rebuild from, so faces may read as Unknown. Load a matching gallery or re-enroll.");
            }
        }

        // Clears and re-embeds every enrolled photo with the current model (CPU-heavy, so it runs on a background thread).
        private async Task RebuildGalleryAsync(int family)
        {
            // Mark the rebuild so teardown drains it before disposing the enroller.
            _rebuildInProgress = true;
            try
            {
                _gallery.Clear();

                var enroller = GetEnroller();
                var photos = _enrolledPhotos.SelectMany(kv => kv.Value.Select(file => (kv.Key, file))).ToList();
                await Task.Run(() =>
                {
                    foreach (var (name, file) in photos)
                    {
                        // Stop re-embedding if the page is being torn down so the loop drains promptly.
                        if (_isCleanedUp)
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

                _galleryFamily = family;
                RefreshGalleryList();
            }
            finally
            {
                _rebuildInProgress = false;
            }
        }

        private void btRemove_Clicked(object sender, EventArgs e)
        {
            if (cvGallery.SelectedItem is string name)
            {
                _gallery.Remove(name);

                // Delete this demo's own copies of the identity's photos so removed identities don't leak disk.
                if (_enrolledPhotos.TryGetValue(name, out var files))
                {
                    foreach (var file in files)
                    {
                        try { if (File.Exists(file)) File.Delete(file); } catch (Exception ex) { Debug.WriteLine(ex); }
                    }

                    _enrolledPhotos.Remove(name);
                }

                if (_gallery.Count == 0)
                {
                    _galleryFamily = null;
                }

                RefreshGalleryList();
            }
        }

        private async void btSaveGallery_Clicked(object sender, EventArgs e)
        {
            try
            {
                _gallery.Save(GalleryPath);

                // Persist which embedding family produced these embeddings so a later Load can re-select the matching model.
                var famPath = GalleryPath + ".family";
                if (_galleryFamily != null)
                {
                    File.WriteAllText(famPath, _galleryFamily.Value.ToString());
                }
                else if (File.Exists(famPath))
                {
                    File.Delete(famPath);
                }

                SetStatus($"Saved {_gallery.Count} identities.");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Save failed", ex.Message, "OK");
            }
        }

        private async void btLoadGallery_Clicked(object sender, EventArgs e)
        {
            if (!File.Exists(GalleryPath))
            {
                await DisplayAlert("Load", "No saved gallery was found.", "OK");
                return;
            }

            try
            {
                LoadGalleryFromAppData();
                SetStatus($"Loaded {_gallery.Count} identities.");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Load failed", ex.Message, "OK");
            }
        }

        // Loads the fixed app-data gallery (and its .family sidecar) into the shared gallery if present.
        private void LoadGalleryFromAppData()
        {
            if (!File.Exists(GalleryPath))
            {
                return;
            }

            _gallery.Load(GalleryPath);

            // A loaded gallery has no source photos to re-embed.
            _enrolledPhotos.Clear();

            var famPath = GalleryPath + ".family";
            var familyCount = (pkEmbFamily.ItemsSource as IList<string>)?.Count ?? 0;
            if (File.Exists(famPath) && int.TryParse(File.ReadAllText(famPath).Trim(), out var savedFamily)
                && savedFamily >= 0 && savedFamily < familyCount)
            {
                _galleryFamily = savedFamily;
                pkEmbFamily.SelectedIndex = savedFamily;

                // Re-assert the embedding model path for the loaded family (the SelectedIndex change handler may null it).
                var selectedPath = Path.Combine(ModelsCacheDir, SelectedEmbeddingFile);
                _embModelPath = File.Exists(selectedPath) ? selectedPath : _embModelPath;
            }
            else
            {
                _galleryFamily = null;
            }

            RefreshGalleryList();
        }

        private void btCamera_Clicked(object sender, EventArgs e)
        {
            if (_cameras == null || _cameras.Length < 2)
            {
                return;
            }

            _cameraSelectedIndex = (_cameraSelectedIndex + 1) % _cameras.Length;
            btCamera.Text = _cameras[_cameraSelectedIndex].DisplayName;
        }

        private async void btStartStop_Clicked(object sender, EventArgs e)
        {
            // Don't start/stop while an enroll loop is running against the shared enroller.
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
                if (_isRunning)
                {
                    await StopAsync();
                }
                else
                {
                    await StartAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                SetStatus("Error: " + ex.Message);
            }
            finally
            {
                Interlocked.Exchange(ref _startStopBusy, 0);
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

            if (_isCleanedUp)
            {
                return;
            }

            _core = new VideoCaptureCoreX(videoView.GetVideoView());
            _core.OnError += Core_OnError;
            _core.OnStop += Core_OnStop;
        }

        private async Task StartAsync()
        {
            if (_isCleanedUp)
            {
                return;
            }

            if (_cameras == null || _cameras.Length == 0)
            {
                await DisplayAlert("No camera", "No camera devices were found.", "OK");
                return;
            }

            if (!ModelsSelected())
            {
                await DisplayAlert("Models required",
                    "Download the face detector and embedding models first.", "OK");
                return;
            }

            // Make sure the gallery embeddings match the model we're about to run.
            await EnsureGalleryMatchesModelAsync();

            await RecreateEngineAsync();
            if (_core == null || _isCleanedUp)
            {
                return;
            }

            // The camera list can change (e.g. USB unplug) between page load and Start, so re-validate the index.
            if (_cameras == null || _cameras.Length == 0)
            {
                await DisplayAlert("No camera", "No camera is available. Connect a camera and try again.", "OK");
                return;
            }

            _cameraSelectedIndex = Math.Max(0, Math.Min(_cameras.Length - 1, _cameraSelectedIndex));

            // Configure the camera source at an HD (or best available) format.
            var device = _cameras[_cameraSelectedIndex];
            var formatItem = device.GetHDOrAnyVideoFormatAndFrameRate(out var frameRate);
            if (formatItem == null)
            {
                await DisplayAlert("Error", "Unable to read a camera format.", "OK");
                return;
            }

            var videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
            {
                Format = formatItem.ToFormat()
            };
            videoSourceSettings.Format.FrameRate = frameRate;
            _core.Video_Source = videoSourceSettings;
            _core.Audio_Play = false;

            // Build the recognizer and insert it as a video processing block (DrawResults renders boxes into the preview).
            _face = new FaceRecognitionBlock(BuildSettings());
            _face.OnFacesIdentified += Face_OnFacesIdentified;
            _core.Video_Processing_AddBlock(_face);

            if (!await _core.StartAsync())
            {
                // Start failed: stop the engine, drop our block reference, and leave the UI stopped.
                await _core.StopAsync();
                DetachBlock();
                SetStatus("Error: failed to start capture.");
                return;
            }

            _isRunning = true;
            btStartStop.Text = "STOP";
            btStartStop.BackgroundColor = Colors.Red;
            SetStatus($"Recognizing... Gallery: {_gallery.Count} identities.");

            // Lock gallery-mutating controls while the recognizer reads _gallery on the pipeline thread.
            SetGalleryControlsEnabled(false);
        }

        private async Task StopAsync()
        {
            if (_core != null)
            {
                await _core.StopAsync();
            }

            DetachBlock();
            _isRunning = false;
            btStartStop.Text = "START";
            btStartStop.BackgroundColor = Color.FromRgb(76, 175, 80);

            SetGalleryControlsEnabled(true);
        }

        private void SetGalleryControlsEnabled(bool enabled)
        {
            btEnroll.IsEnabled = enabled;
            btRemove.IsEnabled = enabled;
            btLoadGallery.IsEnabled = enabled;
            pkEmbFamily.IsEnabled = enabled;
        }

        private void Face_OnFacesIdentified(object sender, FacesIdentifiedEventArgs e)
        {
            // Summarize the identified faces for the status label (Unknown when no gallery match).
            var faces = e.Faces;
            var count = faces?.Length ?? 0;
            var summary = count > 0
                ? string.Join(", ", faces.Where(f => f != null).Select(f => string.IsNullOrEmpty(f.Identity)
                    ? "Unknown"
                    : $"{f.Identity} ({f.Similarity:P0})"))
                : null;

            Dispatcher?.Dispatch(() =>
            {
                if (_isCleanedUp || !_isRunning)
                {
                    return;
                }

                SetStatus(count > 0 ? $"Faces: {count}  |  {summary}" : "Faces: none");
            });
        }

        /// <summary>
        /// The engine owns and disposes the inserted recognizer, so here we only detach the handler and drop the reference.
        /// </summary>
        private void DetachBlock()
        {
            if (_face != null)
            {
                _face.OnFacesIdentified -= Face_OnFacesIdentified;
                _face = null;
            }
        }

        private void Core_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
            Dispatcher?.Dispatch(() => SetStatus("Engine error: " + e.Message));
        }

        // Reset the UI when the engine stops on its own (device error, end of stream, etc.), not just on user STOP.
        private async void Core_OnStop(object sender, StopEventArgs e)
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                if (_isCleanedUp)
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
                _isRunning = false;
                btStartStop.Text = "START";
                btStartStop.BackgroundColor = Color.FromRgb(76, 175, 80);
                SetGalleryControlsEnabled(true);
            });
        }

        private void SetStatus(string text)
        {
            if (_isCleanedUp)
            {
                return;
            }

            lbStatus.Text = text;
        }

        private async void MainPage_Unloaded(object sender, EventArgs e)
        {
            try
            {
                await CleanupAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void Window_Destroying(object sender, EventArgs e)
        {
            try
            {
                await CleanupAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async Task CleanupAsync()
        {
            // Atomically claim teardown so Unloaded and Window.Destroying can't both run it (double DestroySDK).
            if (Interlocked.Exchange(ref _cleanupClaimed, 1) == 1)
            {
                return;
            }

            _isCleanedUp = true;

            // Cancel an in-flight model download so it stops touching the disposed page's UI.
            try { _downloadCts?.Cancel(); } catch (ObjectDisposedException) { }

            // Drain any in-flight Start/Stop transition and claim the guard before disposing the engine.
            while (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                await Task.Delay(50);
            }

            // Drain an in-flight enroll/rebuild before disposing the shared enroller block (use-after-free otherwise).
            while (_enrollInProgress || _rebuildInProgress)
            {
                await Task.Delay(50);
            }

            if (_window != null)
            {
                _window.Destroying -= Window_Destroying;
                _window = null;
            }

            if (_core != null)
            {
                _core.OnError -= Core_OnError;
                _core.OnStop -= Core_OnStop;
                await _core.StopAsync();
                await _core.DisposeAsync();
                _core = null;
            }

            DetachBlock();

            // The enroller is owned by the app, so dispose it here.
            _enroller?.Dispose();
            _enroller = null;

            VisioForgeX.DestroySDK();
        }
    }
}
