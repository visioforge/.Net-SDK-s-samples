using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

namespace FaceRecognitionMB
{
    public partial class MainPage : ContentPage
    {
        private MediaBlocksPipeline _pipeline;
        private VideoRendererBlock _videoRenderer;
        private SystemVideoSourceBlock _videoSource;

        // File source (used instead of the camera when the source is a video file).
        private UniversalSourceBlock _fileSource;

        private FaceRecognitionBlock _face;

        // File-playback transport state (seek bar + position polling).
        private bool _isFile;
        private string _filename;
        private TimeSpan _duration;
        private bool _isTimerUpdate;
        private bool _timerBusy;
        private IDispatcherTimer _timer;

        // Persistent block used only to compute embeddings for enrollment (never added to the pipeline).
        private FaceRecognitionBlock _enroller;

        // The embedding family the cached enroller was built with (-1 = none), so it is rebuilt when the family changes.
        private int _enrollerFamily = -1;

        // Shared gallery: enrollment writes into it and the live pipeline matches against it.
        private readonly FaceGallery _gallery = new FaceGallery();

        // Source photos per identity (persisted), so the gallery can be re-embedded when the embedding model changes.
        private readonly Dictionary<string, List<string>> _enrolledPhotos = new Dictionary<string, List<string>>(StringComparer.Ordinal);

        // The embedding family (0 = SFace, 1 = AuraFace) the current gallery was built with; null when empty or loaded.
        private int? _galleryFamily;

        private VideoCaptureDeviceInfo[] _cameras;
        private int _cameraSelectedIndex = 0;
        private bool _isRunning = false;
        private bool _isCleanedUp = false;

        private Window _window;

        // START/STOP re-entrancy guard (0 = free, 1 = busy).
        private int _startStopBusy;

        // Serializes teardown (STOP + page-close).
        private readonly SemaphoreSlim _teardownGate = new SemaphoreSlim(1, 1);

        // ---- Models (OpenCV Zoo, hosted in the SDK samples release; not shipped in NuGet) ----
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

        private const string DetectorModelFile = "face_detection_yunet_2023mar.onnx"; // YuNet (MIT)
        private const string EmbeddingModelFile = "face_recognition_sface_2021dec.onnx"; // SFace (Apache-2.0, 128-D)
        private const string AuraFaceModelFile = "face_recognition_auraface_v1.onnx"; // AuraFace r100, ArcFace family (Apache-2.0, by fal, 512-D)

        // Selected embedding family: 0 = SFace (128-D), 1 = AuraFace (512-D, ArcFace).
        private int _embeddingFamily = 0;

        private string SelectedEmbeddingFile => _embeddingFamily == 1 ? AuraFaceModelFile : EmbeddingModelFile;

        private FaceEmbeddingModel SelectedEmbeddingModel => _embeddingFamily == 1 ? FaceEmbeddingModel.ArcFace : FaceEmbeddingModel.SFace;

        // Downloaded models are cached here; AppDataDirectory is writable on every platform.
        private static string ModelsCacheDir => Path.Combine(FileSystem.AppDataDirectory, "models");

        // Persisted copies of the enrolled photos, so the gallery can be rebuilt when the embedding model changes.
        private static string EnrolledPhotosDir => Path.Combine(FileSystem.AppDataDirectory, "enrolled_photos");

        private static string GalleryPath => Path.Combine(FileSystem.AppDataDirectory, "faces.vfg");

        // Sidecar recording which embedding family (0 = SFace, 1 = AuraFace) the saved gallery was built with.
        private static string GalleryFamilyPath => GalleryPath + ".family";

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

        private string _detPath;
        private string _embPath;

        static MainPage()
        {
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("VisioForge-FaceRecognition-Demo/1.0");
        }

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;
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

        private async void MainPage_Loaded(object sender, EventArgs e)
        {
            try
            {
#if __ANDROID__ || __MACOS__ || __MACCATALYST__ || __IOS__
                await RequestCameraPermissionAsync();
#endif

                await VisioForgeX.InitSDKAsync();

                // Drop persisted photos from a previous run; the in-memory photo->identity map resets each launch.
                try { if (Directory.Exists(EnrolledPhotosDir)) Directory.Delete(EnrolledPhotosDir, true); } catch (Exception ex) { Debug.WriteLine(ex); }

                // Same for any copied source videos left in the cache by a previous run.
                try
                {
                    foreach (var stale in Directory.EnumerateFiles(FileSystem.CacheDirectory, "source_*"))
                    {
                        try { File.Delete(stale); } catch (Exception delEx) { Debug.WriteLine(delEx); }
                    }
                }
                catch (Exception ex) { Debug.WriteLine(ex); }

                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
                if (_cameras.Length > 0)
                {
                    // Reset the selection so a reused page can't keep a stale device.
                    _cameraSelectedIndex = 0;
                    btCamera.Text = _cameras[0].DisplayName;
                }

                // Prefill model paths from the cache when they were already downloaded.
                ResolveCachedModels();
                RefreshModelStatus();

                if (File.Exists(GalleryPath))
                {
                    try
                    {
                        _gallery.Load(GalleryPath);
                        RestoreGalleryFamily();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Gallery load skipped: {ex.Message}");
                    }
                }

                RefreshGalleryStatus();

                // Position-polling timer for file playback (drives the seek bar + position/duration labels).
                _timer = Dispatcher.CreateTimer();
                _timer.Interval = TimeSpan.FromMilliseconds(500);
                _timer.Tick += Timer_Tick;

                _window = Window;
                if (_window != null)
                {
                    _window.Destroying += Window_Destroying;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void ResolveCachedModels()
        {
            var det = Path.Combine(ModelsCacheDir, DetectorModelFile);
            var emb = Path.Combine(ModelsCacheDir, SelectedEmbeddingFile);
            _detPath = File.Exists(det) ? det : null;
            _embPath = File.Exists(emb) ? emb : null;
        }

        private string EmbedderName => _embeddingFamily == 1 ? "AuraFace 512-D" : "SFace 128-D";

        private bool ModelsReady => !string.IsNullOrEmpty(_detPath) && File.Exists(_detPath)
                                    && !string.IsNullOrEmpty(_embPath) && File.Exists(_embPath);

        private void RefreshModelStatus()
        {
            lbModels.Text = ModelsReady ? $"Models: ready (YuNet + {EmbedderName})" : $"Models: {EmbedderName} not downloaded";

            // Hide the Download button once the selected embedder's models are cached.
            btDownloadModels.IsVisible = !ModelsReady;
        }

        private void RefreshGalleryStatus()
        {
            lbGallery.Text = $"Gallery: {_gallery.Count} identities";
        }

        // Reflects the current embedding family on the toggle UI and re-resolves the cached model paths.
        private void ApplyEmbeddingFamilyUI()
        {
            btEmbModel.Text = _embeddingFamily == 1 ? "AuraFace (512-D)" : "SFace (128-D)";
            lbEmbHint.Text = _embeddingFamily == 1
                ? "AuraFace 512-D (Apache-2.0, by fal): higher accuracy, ~260 MB, slower on mobile CPU."
                : string.Empty;

            ResolveCachedModels();
            RefreshModelStatus();
        }

        // Restores the embedding family a loaded gallery was saved with (sidecar), so recognition runs the matching model.
        private void RestoreGalleryFamily()
        {
            if (File.Exists(GalleryFamilyPath)
                && int.TryParse(File.ReadAllText(GalleryFamilyPath).Trim(), out var savedFamily)
                && (savedFamily == 0 || savedFamily == 1))
            {
                _galleryFamily = savedFamily;
                _embeddingFamily = savedFamily;
                ApplyEmbeddingFamilyUI();
            }
            else
            {
                _galleryFamily = null;
            }
        }

        // Cycles the embedding family (SFace 128-D <-> AuraFace 512-D); the gallery is re-embedded on the next enroll/Start.
        private void btEmbModel_Clicked(object sender, EventArgs e)
        {
            _embeddingFamily = _embeddingFamily == 0 ? 1 : 0;
            ApplyEmbeddingFamilyUI();

            if (_gallery.Count > 0 && _galleryFamily != null && _galleryFamily != _embeddingFamily)
            {
                lbStatus.Text = _enrolledPhotos.Count > 0
                    ? "Model changed - gallery rebuilds on enroll/Start"
                    : "Model changed - loaded gallery won't match; re-enroll";
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

        // Lazily creates (and reuses) the enroller block, rebuilding it when the embedding family changes.
        private FaceRecognitionBlock GetEnroller()
        {
            if (_enroller != null && _enrollerFamily == _embeddingFamily)
            {
                return _enroller;
            }

            _enroller?.Dispose();
            _enroller = new FaceRecognitionBlock(BuildSettings());
            _enrollerFamily = _embeddingFamily;
            return _enroller;
        }

        // Re-embeds the persisted photos with the selected model when the gallery was built with a different one.
        private async Task EnsureGalleryMatchesModelAsync()
        {
            if (_gallery.Count == 0 || _galleryFamily == _embeddingFamily)
            {
                return;
            }

            // Only rebuild when we have source photos and the selected model is available, else we'd lose every identity.
            if (_enrolledPhotos.Count > 0 && ModelsReady)
            {
                await RebuildGalleryAsync(_embeddingFamily);
            }
        }

        // Re-embeds the persisted photos for the given family on a background thread (CPU-heavy).
        private async Task RebuildGalleryAsync(int family)
        {
            // Identities loaded from a .vfg have no tracked source photos, so the re-embed below cannot recreate them.
            var loadedOnly = _gallery.GetNames().Where(n => !_enrolledPhotos.ContainsKey(n)).ToList();

            _gallery.Clear();

            var enroller = GetEnroller();
            var photos = _enrolledPhotos.SelectMany(kv => kv.Value.Select(file => (kv.Key, file))).ToList();
            await Task.Run(() =>
            {
                foreach (var (name, file) in photos)
                {
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

            // Warn if any identity couldn't be re-embedded or was dropped by the model switch.
            var rebuilt = _gallery.GetNames();
            var dropped = _enrolledPhotos.Keys.Where(n => !rebuilt.Contains(n)).Concat(loadedOnly).ToList();
            if (dropped.Count > 0)
            {
                lbStatus.Text = $"Rebuild dropped {dropped.Count}: {string.Join(", ", dropped)}";
            }

            _galleryFamily = family;
            RefreshGalleryStatus();
        }

        private async void btDownloadModels_Clicked(object sender, EventArgs e)
        {
            btDownloadModels.IsEnabled = false;

            // Lock the embedder selector during the download so a mid-download switch can't mismatch weights and family.
            btEmbModel.IsEnabled = false;
            var original = btDownloadModels.Text;
            btDownloadModels.Text = "Downloading...";
            pbDownload.Progress = 0;
            pbDownload.IsVisible = true;

            try
            {
                Directory.CreateDirectory(ModelsCacheDir);
                _detPath = await DownloadAsync(DetectorModelFile);
                _embPath = await DownloadAsync(SelectedEmbeddingFile);
            }
            catch (Exception ex)
            {
                lbModels.Text = "Models: download failed";
                await DisplayAlert("Download failed", $"{ex.Message}", "OK");
            }
            finally
            {
                pbDownload.IsVisible = false;
                btDownloadModels.IsEnabled = true;
                btEmbModel.IsEnabled = true;
                btDownloadModels.Text = original;
                RefreshModelStatus();
            }
        }

        private async Task<string> DownloadAsync(string fileName)
        {
            var dest = Path.Combine(ModelsCacheDir, fileName);
            if (File.Exists(dest))
            {
                return dest;
            }

            var temp = dest + ".part";
            lbModels.Text = $"Downloading {fileName}...";

            try
            {
                // I/O runs off the UI thread; progress updates marshal back via Dispatcher.Dispatch.
                using (var response = await _http.GetAsync(ModelsReleaseUrl + "/" + fileName, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();

                    var total = response.Content.Headers.ContentLength ?? -1L;
                    using (var src = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var fileStream = File.Create(temp))
                    {
                        var buffer = new byte[81920];
                        long readTotal = 0;
                        int lastPercent = -1;
                        int read;
                        while ((read = await src.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, read).ConfigureAwait(false);
                            readTotal += read;

                            if (total > 0)
                            {
                                var percent = (int)(readTotal * 100 / total);
                                if (percent != lastPercent)
                                {
                                    lastPercent = percent;
                                    var progress = percent / 100.0;
                                    Dispatcher.Dispatch(() => pbDownload.Progress = progress);
                                }
                            }
                        }
                    }
                }

                File.Move(temp, dest, overwrite: true);
                return dest;
            }
            catch
            {
                // Best-effort cleanup of the partial download before propagating.
                try { if (File.Exists(temp)) File.Delete(temp); } catch { }
                throw;
            }
        }

        private FaceRecognitionSettings BuildSettings()
        {
            return new FaceRecognitionSettings(_detPath, _embPath)
            {
                Gallery = _gallery,
                EmbeddingModel = SelectedEmbeddingModel,
                RecognitionThreshold = 0.36f,
                FramesToSkip = 2,
                DrawResults = true,
            };
        }

        private async void btEnroll_Clicked(object sender, EventArgs e)
        {
            var name = edName.Text?.Trim();
            if (string.IsNullOrEmpty(name))
            {
                await DisplayAlert("Name required", "Enter a person name first.", "OK");
                return;
            }

            if (!ModelsReady)
            {
                await DisplayAlert("Models required", "Tap DOWNLOAD MODELS first.", "OK");
                return;
            }

            // Prevent re-entrancy: a second tap could open another picker and enroll concurrently against the shared gallery.
            btEnroll.IsEnabled = false;
            string persisted = null;
            bool recorded = false;
            try
            {
                var photo = await MediaPicker.Default.PickPhotoAsync();
                if (photo == null)
                {
                    return;
                }

                // Persist the picked photo (content URIs aren't directly decodable) so it can be re-embedded later.
                Directory.CreateDirectory(EnrolledPhotosDir);
                var ext = Path.GetExtension(photo.FileName);
                persisted = Path.Combine(EnrolledPhotosDir, $"{Guid.NewGuid():N}{ext}");
                using (var src = await photo.OpenReadAsync())
                using (var dst = File.Create(persisted))
                {
                    await src.CopyToAsync(dst);
                }

                int family = _embeddingFamily;
                bool ok = false;

                // Hold the teardown gate across the rebuild + enroll so CleanupAsync can't dispose the enroller mid-work.
                await _teardownGate.WaitAsync();
                try
                {
                    if (_isCleanedUp)
                    {
                        return;
                    }

                    // Re-embed existing photos first if the model changed, so Add won't reject a different-dimension embedding.
                    await EnsureGalleryMatchesModelAsync();

                    // Detection + embedding is CPU-heavy; keep it off the UI thread.
                    var enroller = GetEnroller();
                    ok = await Task.Run(() => enroller.Enroll(name, persisted));
                }
                finally
                {
                    _teardownGate.Release();
                }

                if (ok)
                {
                    RecordPhoto(name, persisted);
                    recorded = true;
                    _galleryFamily = family;
                    RefreshGalleryStatus();
                    await DisplayAlert("Enrolled", $"Enrolled '{name}'.", "OK");
                }
                else
                {
                    try { File.Delete(persisted); } catch { /* best effort */ }
                    await DisplayAlert("No face", "No face was found in the photo. Use a clear, front-facing photo.", "OK");
                }
            }
            catch (Exception ex)
            {
                // Drop the persisted copy if enroll threw before it was recorded.
                if (persisted != null && !recorded)
                {
                    try { File.Delete(persisted); } catch { /* best effort */ }
                }

                await DisplayAlert("Enrollment failed", ex.Message, "OK");
            }
            finally
            {
                btEnroll.IsEnabled = true;
            }
        }

        private async void btSaveGallery_Clicked(object sender, EventArgs e)
        {
            try
            {
                _gallery.Save(GalleryPath);

                // Persist the embedding family so a later load re-selects the matching model; drop a stale sidecar otherwise.
                if (_galleryFamily != null)
                {
                    File.WriteAllText(GalleryFamilyPath, _galleryFamily.Value.ToString());
                }
                else if (File.Exists(GalleryFamilyPath))
                {
                    File.Delete(GalleryFamilyPath);
                }

                await DisplayAlert("Saved", $"Saved {_gallery.Count} identities to:\n{GalleryPath}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Save failed", ex.Message, "OK");
            }
        }

        private async void btLoadGallery_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(GalleryPath))
                {
                    await DisplayAlert("Nothing to load", "No saved gallery found.", "OK");
                    return;
                }

                _gallery.Load(GalleryPath);

                // A loaded gallery has no source photos; restore its embedding family from the sidecar to match the model.
                _enrolledPhotos.Clear();
                RestoreGalleryFamily();

                RefreshGalleryStatus();
                await DisplayAlert("Loaded", $"Loaded {_gallery.Count} identities.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Load failed", ex.Message, "OK");
            }
        }

        private async Task RequestCameraPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Camera>();

            if (result != PermissionStatus.Granted)
            {
                if (Permissions.ShouldShowRationale<Permissions.Camera>())
                {
                    if (await DisplayAlert(null, "You need to allow access to the Camera to recognize faces", "OK", "Cancel"))
                        await RequestCameraPermissionAsync();
                }
            }
        }

        private async void btStartStop_Clicked(object sender, EventArgs e)
        {
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
            }
            finally
            {
                Interlocked.Exchange(ref _startStopBusy, 0);
            }
        }

        private async Task StartAsync()
        {
            if (_isFile)
            {
                if (string.IsNullOrEmpty(_filename) || !File.Exists(_filename))
                {
                    await DisplayAlert("File required", "Tap OPEN FILE and pick a video first.", "OK");
                    return;
                }
            }
            else if (_cameras == null || _cameras.Length == 0)
            {
                await DisplayAlert("Error", "No cameras available", "OK");
                return;
            }

            if (!ModelsReady)
            {
                await DisplayAlert("Models required", "Tap DOWNLOAD MODELS first.", "OK");
                return;
            }

            // Re-embed enrolled photos if the family changed, so the gallery matches the model and faces aren't all Unknown.
            // Hold the teardown gate so CleanupAsync can't dispose the enroller mid-rebuild.
            await _teardownGate.WaitAsync();
            try
            {
                if (_isCleanedUp)
                {
                    return;
                }

                await EnsureGalleryMatchesModelAsync();
            }
            finally
            {
                _teardownGate.Release();
            }

            try
            {
                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;
                _pipeline.OnStop += Pipeline_OnStop;

                MediaBlockPad videoOut;
                if (_isFile)
                {
#if IOS && !MACCATALYST
                    // On iOS the string overload is gated out; wrap the path in an NSUrl. Video-only (audio not connected).
                    var srcSettings = await UniversalSourceSettings.CreateAsync(Foundation.NSUrl.FromFilename(_filename), renderVideo: true, renderAudio: false);
#else
                    var srcSettings = await UniversalSourceSettings.CreateAsync(_filename, renderVideo: true, renderAudio: false);
#endif
                    _fileSource = new UniversalSourceBlock(srcSettings);
                    videoOut = _fileSource.VideoOutput;
                }
                else
                {
                    var device = _cameras[_cameraSelectedIndex];
                    var formatItem = device.GetHDOrAnyVideoFormatAndFrameRate(out var frameRate);

                    if (formatItem == null)
                    {
                        await DiscardPipelineAsync();
                        await DisplayAlert("Error", "Unable to get camera format", "OK");
                        return;
                    }

                    var videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                    {
                        Format = formatItem.ToFormat()
                    };
                    videoSourceSettings.Format.FrameRate = frameRate;

                    _videoSource = new SystemVideoSourceBlock(videoSourceSettings);
                    videoOut = _videoSource.Output;
                }

                _face = new FaceRecognitionBlock(BuildSettings());
                _face.OnFacesIdentified += Face_OnFacesIdentified;

                IVideoView vv = videoView.GetVideoView();

                // File: real time when the switch is on, else max speed. A live camera always runs unsynced.
                var realTime = _isFile && swRealTime.IsToggled;
                _videoRenderer = new VideoRendererBlock(_pipeline, vv) { IsSync = realTime };

                _pipeline.Connect(videoOut, _face.Input);
                _pipeline.Connect(_face.Output, _videoRenderer.Input);

                if (_isCleanedUp)
                {
                    await DiscardPipelineAsync();
                    return;
                }

                if (!await _pipeline.StartAsync())
                {
                    await DiscardPipelineAsync();
                    await DisplayAlert("Error", "Failed to start face recognition.", "OK");
                    return;
                }

                if (_isCleanedUp)
                {
                    await DiscardPipelineAsync();
                    return;
                }

                _isRunning = true;
                btStartStop.Text = "STOP";
                btStartStop.BackgroundColor = Colors.Red;

                // Enable the seek bar for file playback; duration is resolved lazily in the timer (not ready at Start).
                if (_isFile)
                {
                    _duration = TimeSpan.Zero;
                    _isTimerUpdate = true;
                    slSeek.Value = 0;
                    _isTimerUpdate = false;
                    pnSeek.IsVisible = true;
                    _timer?.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error starting: {ex.Message}");
                await DiscardPipelineAsync();
                await DisplayAlert("Error", $"Failed to start: {ex.Message}", "OK");
            }
        }

        // Disposes the source/face/renderer blocks (not owned by the pipeline) on every teardown path.
        private void DisposeBlocks()
        {
            if (_face != null)
            {
                _face.OnFacesIdentified -= Face_OnFacesIdentified;
                _face.Dispose();
                _face = null;
            }

            _videoRenderer?.Dispose();
            _videoRenderer = null;

            _videoSource?.Dispose();
            _videoSource = null;

            _fileSource?.Dispose();
            _fileSource = null;
        }

        // Tears down a partially/fully built pipeline and its blocks (error / early-return paths).
        private async Task DiscardPipelineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            DisposeBlocks();
        }

        private async Task StopAsync(bool updateUI = true)
        {
            await _teardownGate.WaitAsync();
            try
            {
                if (_pipeline == null)
                {
                    return;
                }

                _timer?.Stop();

                try
                {
                    await _pipeline.StopAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error stopping pipeline: {ex.Message}");
                }
                finally
                {
                    _pipeline.OnError -= Pipeline_OnError;
                    _pipeline.OnStop -= Pipeline_OnStop;
                    await _pipeline.DisposeAsync();
                    _pipeline = null;

                    DisposeBlocks();
                    _isRunning = false;
                }

                if (updateUI)
                {
                    Dispatcher.Dispatch(() =>
                    {
                        btStartStop.Text = "START";
                        btStartStop.BackgroundColor = Color.FromRgb(76, 175, 80);

                        pnSeek.IsVisible = false;
                        _isTimerUpdate = true;
                        slSeek.Value = 0;
                        _isTimerUpdate = false;
                        lbPosition.Text = "00:00:00";
                        lbDuration.Text = "00:00:00";
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error stopping: {ex.Message}");
            }
            finally
            {
                _teardownGate.Release();
            }
        }

        private void Face_OnFacesIdentified(object sender, FacesIdentifiedEventArgs e)
        {
            // A frame with no faces resets the status to idle so the last "Faces: ..." line doesn't linger.
            var faces = e.Faces;
            var count = faces?.Length ?? 0;

            string status;
            if (count == 0)
            {
                status = "Faces: none";
            }
            else
            {
                // Pick a representative label: the best match, else "Unknown".
                string headline = null;
                float bestScore = -1f;
                foreach (var f in faces)
                {
                    if (f != null && !string.IsNullOrEmpty(f.Identity) && f.Similarity > bestScore)
                    {
                        bestScore = f.Similarity;
                        headline = $"{f.Identity} ({f.Similarity:P0})";
                    }
                }

                headline ??= "Unknown";
                status = $"Faces: {count}  |  {headline}";
            }

            Dispatcher.Dispatch(() =>
            {
                if (_isCleanedUp || !_isRunning)
                {
                    return;
                }

                try
                {
                    lbStatus.Text = status;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Face UI update failed: {ex.Message}");
                }
            });
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine($"Pipeline error: {e.Message}");
        }

        // End-of-stream: the pipeline self-stopped, so tear down and reset the UI to idle.
        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Dispatch(async () =>
            {
                if (_isCleanedUp || !_isRunning)
                {
                    return;
                }

                await StopAsync();
            });
        }

        private void btCamera_Clicked(object sender, EventArgs e)
        {
            if (_cameras == null || _cameras.Length == 0)
            {
                return;
            }

            _cameraSelectedIndex++;

            if (_cameraSelectedIndex >= _cameras.Length)
            {
                _cameraSelectedIndex = 0;
            }

            btCamera.Text = _cameras[_cameraSelectedIndex].DisplayName;
        }

        // Toggles the source between the live camera and a video file. Disabled while running.
        private void btSource_Clicked(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                return;
            }

            _isFile = !_isFile;
            btSource.Text = _isFile ? "Source: Video file" : "Source: Camera";
            btCamera.IsVisible = !_isFile;
            btOpenFile.IsVisible = _isFile;
            pnFile.IsVisible = _isFile;
            if (!_isFile)
            {
                pnSeek.IsVisible = false;
            }
        }

        private async void btOpenFile_Clicked(object sender, EventArgs e)
        {
            string dest = null;
            try
            {
                var result = await FilePicker.Default.PickAsync(new PickOptions { PickerTitle = "Select a video file" });
                if (result == null)
                {
                    return;
                }

                // Copy to a stable local path (content URIs aren't openable by the demuxer); GUID name avoids collisions.
                Directory.CreateDirectory(FileSystem.CacheDirectory);
                dest = Path.Combine(FileSystem.CacheDirectory, $"source_{Guid.NewGuid():N}{Path.GetExtension(result.FileName)}");
                using (var src = await result.OpenReadAsync())
                using (var dst = File.Create(dest))
                {
                    await src.CopyToAsync(dst);
                }

                // Switch to the new copy only after it succeeds, then drop the previous one so caches don't accumulate.
                var previous = _filename;
                _filename = dest;
                lbFile.Text = result.FileName;
                if (!string.IsNullOrEmpty(previous))
                {
                    try { if (File.Exists(previous)) File.Delete(previous); } catch (Exception delEx) { Debug.WriteLine(delEx); }
                }
            }
            catch (Exception ex)
            {
                // Best-effort cleanup of a partial copy before surfacing the error.
                if (dest != null)
                {
                    try { if (File.Exists(dest)) File.Delete(dest); } catch (Exception delEx) { Debug.WriteLine(delEx); }
                }

                await DisplayAlert("Open failed", ex.Message, "OK");
            }
        }

        // Polls the playback position to drive the seek bar and the position/duration labels (file mode only).
        private async void Timer_Tick(object sender, EventArgs e)
        {
            // Skip overlapping ticks so a slow tick can't fire a spurious seek.
            if (_timerBusy || _pipeline == null || !_isFile)
            {
                return;
            }

            _timerBusy = true;
            try
            {
                var pos = await _pipeline.Position_GetAsync();

                // Duration becomes available only once playback prerolls - keep trying until known.
                if (_duration <= TimeSpan.Zero)
                {
                    try { _duration = await _pipeline.DurationAsync(); } catch (Exception durEx) { Debug.WriteLine(durEx); }
                }

                // Teardown can run during the awaits above; don't touch UI/controls of a torn-down page.
                if (_isCleanedUp || _pipeline == null)
                {
                    return;
                }

                _isTimerUpdate = true;
                if (_duration > TimeSpan.Zero)
                {
                    slSeek.Maximum = _duration.TotalMilliseconds;
                    slSeek.Value = Math.Min(slSeek.Maximum, pos.TotalMilliseconds);
                    lbDuration.Text = _duration.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture);
                }

                lbPosition.Text = pos.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture);
                _isTimerUpdate = false;
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

        private async void slSeek_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            // Ignore the programmatic updates pushed by the timer; act only on user drags/taps.
            if (_isTimerUpdate || _pipeline == null || !_isFile)
            {
                return;
            }

            try
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromMilliseconds(e.NewValue));
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
            if (_isCleanedUp)
            {
                return;
            }

            _isCleanedUp = true;

            _timer?.Stop();

            if (_window != null)
            {
                _window.Destroying -= Window_Destroying;
                _window = null;
            }

            if (_isRunning)
            {
                await StopAsync(updateUI: false);
            }

            if (_pipeline != null)
            {
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            // Drain an in-flight background enroll/rebuild before disposing the enroller / destroying the SDK (both native).
            await _teardownGate.WaitAsync();
            try
            {
                _enroller?.Dispose();
                _enroller = null;

                VisioForgeX.DestroySDK();
            }
            finally
            {
                _teardownGate.Release();
            }
        }
    }
}
