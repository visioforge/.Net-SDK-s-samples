using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.MAUI;

namespace Player_Face_Recognition_X
{
    /// <summary>
    /// Inserts a deep-learning face recognizer into MediaPlayerCoreX through the X-engine
    /// Video_Processing_AddBlock API. The recognizer taps the decoded video, draws labelled boxes into
    /// the rendered frame, and raises OnFacesIdentified (matched 1:N against an enrolled gallery) while
    /// the engine plays a normal file.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private MediaPlayerCoreX _player;

        // Live recognizer added to the engine. The engine owns and disposes it on stop.
        private FaceRecognitionBlock _face;

        // Persistent block used only to compute embeddings for enrollment (app-owned, never added to the engine).
        private FaceRecognitionBlock _enroller;
        private string _enrollerSignature;

        // Shared gallery: enrollment writes into it and the live recognizer matches against it.
        private readonly FaceGallery _gallery = new FaceGallery();

        // Source photos per identity, so the gallery can be re-embedded when the embedding model changes.
        private readonly Dictionary<string, List<string>> _enrolledPhotos
            = new Dictionary<string, List<string>>(StringComparer.Ordinal);

        // Embedding family the gallery was built with; null when empty or loaded from a .vfg (can't be re-embedded).
        private int? _galleryFamily;

        // Local app-data copy of the picked media file (iOS/Mac picker paths are security-scoped; we play from this copy).
        private string _filePath;

        // Picked media is copied here; AppDataDirectory is writable and accessible by the native engine on every platform.
        private static string OpenedMediaDir => Path.Combine(FileSystem.AppDataDirectory, "opened_media");

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

        // Picked photos are copied here before enrollment (packaged apps can't open arbitrary picker paths natively).
        private static string EnrolledPhotosDir => Path.Combine(FileSystem.AppDataDirectory, "enrolled_photos");

        // Fixed gallery path under app data (+ ".family" sidecar recording the embedding family).
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
                await VisioForgeX.InitSDKAsync();

                // Page torn down during the await (fast navigation away): bail.
                if (_isCleanedUp)
                {
                    return;
                }

                // The engine is created fresh per session in StartAsync (RecreatePlayerAsync).

                pkEmbFamily.ItemsSource = new List<string> { "SFace (128-D)", "AuraFace (512-D)" };
                pkEmbFamily.SelectedIndex = 0;

                Directory.CreateDirectory(ModelsCacheDir);

                // Restore a previously saved gallery only on a fresh page — a re-Loaded (MAUI reuses the
                // page instance on navigation) must not clobber unsaved in-memory enrollments.
                if (_gallery.Count == 0 && _enrolledPhotos.Count == 0)
                {
                    LoadGalleryFromAppData();
                }

                RefreshModelStatus();

                // Drop persisted photos only on a genuinely fresh state (nothing enrolled in memory).
                try { if (_enrolledPhotos.Count == 0 && Directory.Exists(EnrolledPhotosDir)) Directory.Delete(EnrolledPhotosDir, true); } catch (Exception ex) { Debug.WriteLine(ex); }

                // Drop stale copied media from previous runs (no file in use yet).
                try { if (string.IsNullOrEmpty(_filePath) && Directory.Exists(OpenedMediaDir)) Directory.Delete(OpenedMediaDir, true); } catch (Exception ex) { Debug.WriteLine(ex); }

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

        // On-disk paths of the detector and the embedding model for the selected family.
        private string DetectorModelPath => Path.Combine(ModelsCacheDir, DetectorModelFile);
        private string EmbeddingModelPath => Path.Combine(ModelsCacheDir, SelectedEmbeddingFile);

        // Reports which models are cached so the user knows whether to tap "Download models".
        private void RefreshModelStatus()
        {
            var detOk = File.Exists(DetectorModelPath);
            var embOk = File.Exists(EmbeddingModelPath);
            var familyName = pkEmbFamily.SelectedIndex == 1 ? "AuraFace" : "SFace";

            lbModelStatus.Text = detOk && embOk
                ? $"Models ready (YuNet + {familyName})."
                : $"Tap Download models to fetch YuNet + {familyName}. Weights are not bundled with the SDK.";

            btDownloadModels.IsVisible = !(detOk && embOk);
        }

        private void pkEmbFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbModelStatus == null)
            {
                return;
            }

            if (_gallery.Count > 0 && _galleryFamily != null && _galleryFamily != pkEmbFamily.SelectedIndex)
            {
                SetStatus(_enrolledPhotos.Count > 0
                    ? "Embedding model changed - the gallery will be rebuilt from the enrolled photos on the next enroll/Start."
                    : "Embedding model changed - the loaded gallery doesn't match and can't be rebuilt; re-enroll or load a matching gallery.");
            }

            RefreshModelStatus();
        }

        // Downloads the YuNet detector and the selected embedding model into the app-data cache.
        private async void btDownloadModels_Clicked(object sender, EventArgs e)
        {
            btDownloadModels.IsEnabled = false;
            pkEmbFamily.IsEnabled = false;
            var originalText = btDownloadModels.Text;
            pbDownload.Progress = 0;
            pbDownload.IsVisible = true;

            var cts = new CancellationTokenSource();
            _downloadCts = cts;
            try
            {
                Directory.CreateDirectory(ModelsCacheDir);

                if (!File.Exists(DetectorModelPath))
                {
                    btDownloadModels.Text = "Downloading detector...";
                    await DownloadModelWithProgressAsync(ModelsReleaseUrl + "/" + DetectorModelFile, DetectorModelPath, cts.Token);
                }

                if (!File.Exists(EmbeddingModelPath))
                {
                    btDownloadModels.Text = "Downloading embedder...";
                    await DownloadModelWithProgressAsync(ModelsReleaseUrl + "/" + SelectedEmbeddingFile, EmbeddingModelPath, cts.Token);
                }

                pbDownload.Progress = 1;
                SetStatus("Models downloaded.");
            }
            catch (OperationCanceledException) when (cts.Token.IsCancellationRequested)
            {
                // Page torn down mid-download (our token fired); nothing to surface.
            }
            catch (Exception ex)
            {
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
                    RefreshModelStatus();
                }
            }
        }

        // Streams the model to a .part file off the UI thread (reporting progress), then moves it into place.
        private async Task DownloadModelWithProgressAsync(string url, string dest, CancellationToken token)
        {
            Directory.CreateDirectory(ModelsCacheDir);
            var temp = dest + ".part";

            try
            {
                // Run the network + disk loop off the UI thread so a large download can't freeze the window.
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

                                // Throttle UI updates to whole-percent steps so the dispatcher isn't flooded.
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
                                            lbModelStatus.Text = $"Downloading... {percent}%  ({doneMb} / {totalMb} MB)";
                                        });
                                    }
                                }
                                else
                                {
                                    var doneMb = readTotal / 1024 / 1024;
                                    Dispatcher?.Dispatch(() => lbModelStatus.Text = $"Downloading... {doneMb} MB");
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

        // Builds a recognizer settings object from the current UI. The shared gallery is always attached.
        private FaceRecognitionSettings BuildSettings()
        {
            return new FaceRecognitionSettings(DetectorModelPath, EmbeddingModelPath)
            {
                Gallery = _gallery,
                EmbeddingModel = pkEmbFamily.SelectedIndex == 1 ? FaceEmbeddingModel.ArcFace : FaceEmbeddingModel.SFace,
                DrawResults = true,
                FramesToSkip = 2,
                DetectionConfidenceThreshold = 0.6f,
                RecognitionThreshold = 0.36f,
            };
        }

        // Confirms the detector and embedding models are present; alerts and returns false otherwise.
        private async Task<bool> EnsureModelsAsync()
        {
            if (!File.Exists(DetectorModelPath) || !File.Exists(EmbeddingModelPath))
            {
                await DisplayAlert("Models required", "Tap Download models to fetch the YuNet detector and the embedding model.", "OK");
                return false;
            }

            return true;
        }

        // Lazily creates (and reuses) the enroller block, rebuilding it when the model selection changes.
        private FaceRecognitionBlock GetEnroller()
        {
            var signature = string.Join("|", DetectorModelPath, EmbeddingModelPath, pkEmbFamily.SelectedIndex);
            if (_enroller != null && _enrollerSignature == signature)
            {
                return _enroller;
            }

            _enroller?.Dispose();

            _enroller = new FaceRecognitionBlock(BuildSettings());
            _enrollerSignature = signature;
            return _enroller;
        }

        private async void btEnroll_Clicked(object sender, EventArgs e)
        {
            var name = edPersonName.Text?.Trim();
            if (string.IsNullOrEmpty(name))
            {
                await DisplayAlert("Name required", "Enter a person name first.", "OK");
                return;
            }

            if (!await EnsureModelsAsync())
            {
                return;
            }

            // Bail if teardown ran, an enroll is already running, or a Start/Stop transition is in flight.
            if (_isCleanedUp || _enrollInProgress || Volatile.Read(ref _startStopBusy) != 0)
            {
                return;
            }

            _enrollInProgress = true;

            try
            {
                btEnroll.IsEnabled = false;

                // Multiselect: enroll several photos of the same person under one name for more robust matching.
                var picks = await FilePicker.Default.PickMultipleAsync();

                // Page torn down while the picker was open: don't touch controls.
                if (_isCleanedUp)
                {
                    return;
                }

                var files = picks?.ToList();
                if (files == null || files.Count == 0)
                {
                    return;
                }

                int family = pkEmbFamily.SelectedIndex;

                // Loaded gallery built with a different family and no source photos to rebuild from: can't mix dims.
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
                foreach (var pick in files)
                {
                    // Stop processing remaining photos if the page is being torn down.
                    if (_isCleanedUp)
                    {
                        break;
                    }

                    // Copy the picked photo into writable app-data and enroll from that local copy.
                    var persisted = Path.Combine(EnrolledPhotosDir, $"{Guid.NewGuid():N}{Path.GetExtension(pick.FileName)}");
                    try
                    {
                        using (var src = await pick.OpenReadAsync())
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

                // A teardown may have completed while the enroll loop awaited Task.Run.
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
                    await DisplayAlert("No face found", "No face was found in the selected photo(s). Use clear, front-facing photos.", "OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                SetStatus("Enrollment failed: " + ex.Message);
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

        private void RecordPhoto(string name, string file)
        {
            if (!_enrolledPhotos.TryGetValue(name, out var list))
            {
                list = new List<string>();
                _enrolledPhotos[name] = list;
            }

            list.Add(file);
        }

        // Re-embeds the gallery with the selected model when the model changed since enrollment (dims must match).
        private async Task EnsureGalleryMatchesModelAsync()
        {
            int family = pkEmbFamily.SelectedIndex;
            if (_gallery.Count == 0 || _galleryFamily == family)
            {
                return;
            }

            if (_enrolledPhotos.Count > 0)
            {
                if (!File.Exists(EmbeddingModelPath))
                {
                    SetStatus("Embedding model changed but the model file was not found - keeping the existing gallery.");
                    return;
                }

                await RebuildGalleryAsync(family);
            }
            else
            {
                SetStatus("Warning: the loaded gallery was built with a different embedding model and has no source " +
                    "photos to rebuild from, so faces may read as Unknown. Load a matching gallery or re-enroll.");
            }
        }

        // Clears and re-embeds every enrolled photo with the current model (CPU-heavy, so off the UI thread).
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

        private void RefreshGalleryList()
        {
            lvGallery.ItemsSource = _gallery.GetNames().ToList();
        }

        private void btRemove_Clicked(object sender, EventArgs e)
        {
            if (lvGallery.SelectedItem is string name)
            {
                _gallery.Remove(name);

                // Delete this demo's own copies of the removed identity's photos so disk isn't leaked.
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

        private void btSaveGallery_Clicked(object sender, EventArgs e)
        {
            try
            {
                _gallery.Save(GalleryPath);

                // Persist the embedding family so a later Load re-selects the matching model.
                var famPath = GalleryPath + ".family";
                if (_galleryFamily != null)
                {
                    File.WriteAllText(famPath, _galleryFamily.Value.ToString());
                }
                else if (File.Exists(famPath))
                {
                    File.Delete(famPath);
                }

                SetStatus($"Saved {_gallery.Count} identities to {GalleryPath}.");
            }
            catch (Exception ex)
            {
                SetStatus("Save failed: " + ex.Message);
            }
        }

        private async void btLoadGallery_Clicked(object sender, EventArgs e)
        {
            if (!File.Exists(GalleryPath))
            {
                await DisplayAlert("No gallery", "No saved gallery was found. Enroll faces and tap Save first.", "OK");
                return;
            }

            try
            {
                LoadGalleryFromAppData();
                SetStatus($"Loaded {_gallery.Count} identities from {GalleryPath}.");
            }
            catch (Exception ex)
            {
                SetStatus("Load failed: " + ex.Message);
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

                // Re-select the family that produced these embeddings (also points the model paths at the right weights).
                pkEmbFamily.SelectedIndex = savedFamily;
            }
            else
            {
                _galleryFamily = null;
            }

            RefreshGalleryList();
        }

        private async void btFile_Clicked(object sender, EventArgs e)
        {
            try
            {
                var pick = await FilePicker.Default.PickAsync();
                if (pick != null)
                {
                    // iOS/Mac picker paths are security-scoped — copy the stream to app-data and play from there.
                    Directory.CreateDirectory(OpenedMediaDir);
                    if (!string.IsNullOrEmpty(_filePath))
                    {
                        try { File.Delete(_filePath); } catch (Exception delEx) { Debug.WriteLine(delEx); }
                    }

                    var local = Path.Combine(OpenedMediaDir, $"{Guid.NewGuid():N}{Path.GetExtension(pick.FileName)}");
                    using (var src = await pick.OpenReadAsync())
                    using (var dst = File.Create(local))
                    {
                        await src.CopyToAsync(dst);
                    }

                    _filePath = local;
                    SetStatus("File: " + pick.FileName);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Could not open the file picker: " + ex.Message, "OK");
            }
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

        // Disposes any existing engine and builds a fresh MediaPlayerCoreX bound to the same VideoView.
        private async Task RecreatePlayerAsync()
        {
            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                try { await _player.StopAsync(); } catch (Exception ex) { Debug.WriteLine(ex); }
                await _player.DisposeAsync();
                _player = null;
            }

            if (_isCleanedUp)
            {
                return;
            }

            _player = new MediaPlayerCoreX(videoView.GetVideoView());
            _player.OnError += Player_OnError;
            _player.OnStop += Player_OnStop;
        }

        private async Task StartAsync()
        {
            if (_isCleanedUp)
            {
                return;
            }

            if (string.IsNullOrEmpty(_filePath) || !File.Exists(_filePath))
            {
                await DisplayAlert("File required", "Tap OPEN FILE and pick a media file first.", "OK");
                return;
            }

            if (!await EnsureModelsAsync())
            {
                return;
            }

            // Make sure the gallery embeddings match the model we're about to run.
            await EnsureGalleryMatchesModelAsync();

            await RecreatePlayerAsync();
            if (_player == null || _isCleanedUp)
            {
                return;
            }

            // Build the source first (a CreateAsync failure must not strand a registered block).
            // iOS exposes only the NSUrl overload; other platforms use the string overload.
#if IOS && !MACCATALYST
            var source = await UniversalSourceSettings.CreateAsync(Foundation.NSUrl.FromFilename(_filePath), renderVideo: true, renderAudio: false);
#else
            var source = await UniversalSourceSettings.CreateAsync(_filePath, renderVideo: true, renderAudio: false);
#endif

            // Build the recognizer and insert it as a video processing block (DrawResults draws boxes into the frame).
            _face = new FaceRecognitionBlock(BuildSettings());
            _face.OnFacesIdentified += Face_OnFacesIdentified;
            _player.Video_Processing_AddBlock(_face);

            _player.Video_Play = true;
            _player.Audio_Play = false;

            try
            {
                if (!await _player.OpenAsync(source) || !await _player.PlayAsync())
                {
                    // Start failed: tear the player down so an opened-but-not-playing pipeline isn't leaked.
                    await StopAsync();
                    SetStatus("Error: failed to open or play the source.");
                    return;
                }
            }
            catch
            {
                // A failed build disposes the block inside the engine; drop our stale reference.
                DetachBlock();
                throw;
            }

            _isRunning = true;
            btStartStop.Text = "STOP";
            btStartStop.BackgroundColor = Colors.Red;
            SetStatus($"Recognizing... ({_gallery.Count} enrolled)");

            // Lock gallery-mutating controls while the recognizer reads _gallery on the pipeline thread.
            SetGalleryControlsEnabled(false);
        }

        private async Task StopAsync()
        {
            if (_player != null)
            {
                await _player.StopAsync();
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
            // Summarize the identified faces: known names with similarity, plus an Unknown count.
            var faces = e.Faces;
            var known = new List<string>();
            int unknown = 0;
            if (faces != null)
            {
                foreach (var face in faces)
                {
                    if (face == null)
                    {
                        continue;
                    }

                    if (string.IsNullOrEmpty(face.Identity))
                    {
                        unknown++;
                    }
                    else
                    {
                        known.Add($"{face.Identity} ({face.Similarity:P0})");
                    }
                }
            }

            Dispatcher?.Dispatch(() =>
            {
                if (_isCleanedUp || !_isRunning)
                {
                    return;
                }

                var parts = new List<string>();
                if (known.Count > 0)
                {
                    parts.Add(string.Join(", ", known));
                }

                if (unknown > 0)
                {
                    parts.Add($"Unknown x{unknown}");
                }

                SetStatus(parts.Count > 0 ? $"Faces: {string.Join("  |  ", parts)}" : "Faces: none");
            });
        }

        /// <summary>
        /// The engine owns and disposes the inserted recognizer once started, so we only detach the handler and
        /// drop the reference here (we never dispose it ourselves). The enroller is owned by the app and disposed
        /// on cleanup. The next START re-creates a fresh recognizer.
        /// </summary>
        private void DetachBlock()
        {
            if (_face != null)
            {
                _face.OnFacesIdentified -= Face_OnFacesIdentified;
                _face = null;
            }
        }

        private async void Player_OnStop(object sender, StopEventArgs e)
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                if (_isCleanedUp)
                {
                    return;
                }

                // Ignore a stale Stop from a previous session so it can't reset the live UI.
                if (Volatile.Read(ref _startStopBusy) != 0)
                {
                    return;
                }

                if (_player != null && _player.State != PlaybackState.Free)
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

        private void Player_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
            Dispatcher?.Dispatch(() => SetStatus("Engine error: " + e.Message));
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

            // Drain and claim the Start/Stop guard before disposing the engine, so teardown can't race a StartAsync.
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

            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                await _player.StopAsync();
                await _player.DisposeAsync();
                _player = null;
            }

            DetachBlock();

            // The enroller is app-owned (never added to the engine), so we dispose it here.
            _enroller?.Dispose();
            _enroller = null;

            VisioForgeX.DestroySDK();
        }
    }
}
