#nullable disable

using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using Windows.Storage;
using Windows.Storage.Pickers;

#if __ANDROID__
using Android.Content.PM;
using AndroidX.Core.Content;
using AndroidX.Core.App;
using Android.Widget;
#endif

using DebugLogger = System.Diagnostics.Debug;

namespace FaceRecognitionUno;

public sealed partial class MainPage : Page
{
    private MediaBlocksPipeline _pipeline;
    private VideoRendererBlock _videoRenderer;
    private SystemVideoSourceBlock _videoSource;
    private FaceRecognitionBlock _face;

    // Persistent block used only to compute embeddings for enrollment (never added to the pipeline).
    private FaceRecognitionBlock _enroller;
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

    // START/STOP re-entrancy guard (0 = free, 1 = busy).
    private int _startStopBusy;

    // Serializes teardown (STOP + page-unload).
    private readonly SemaphoreSlim _teardownGate = new SemaphoreSlim(1, 1);

    // ---- Models (hosted in the SDK samples release; not shipped in NuGet) ----
    private const string ModelsReleaseUrl =
        "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

    private const string DetectorModelFile = "face_detection_yunet_2023mar.onnx"; // YuNet (MIT)
    private const string EmbeddingModelFile = "face_recognition_sface_2021dec.onnx"; // SFace (Apache-2.0, 128-D)
    private const string AuraFaceModelFile = "face_recognition_auraface_v1.onnx"; // AuraFace (Apache-2.0, 512-D)

    // Selected embedding family: 0 = SFace (128-D), 1 = AuraFace (512-D, ArcFace).
    private int _embeddingFamily = 0;

    private string SelectedEmbeddingFile => _embeddingFamily == 1 ? AuraFaceModelFile : EmbeddingModelFile;

    private FaceEmbeddingModel SelectedEmbeddingModel => _embeddingFamily == 1 ? FaceEmbeddingModel.ArcFace : FaceEmbeddingModel.SFace;

    private string EmbedderName => _embeddingFamily == 1 ? "AuraFace 512-D" : "SFace 128-D";

    // Local app storage is writable on every Uno target.
    private static string AppDataDir => ApplicationData.Current.LocalFolder.Path;

    private static string ModelsCacheDir => Path.Combine(AppDataDir, "models");

    private static string EnrolledPhotosDir => Path.Combine(AppDataDir, "enrolled_photos");

    private static string GalleryPath => Path.Combine(AppDataDir, "faces.vfg");

    // Sidecar recording which embedding family the saved gallery was built with.
    private static string GalleryFamilyPath => GalleryPath + ".family";

    private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

    private string _detPath;
    private string _embPath;

    static MainPage()
    {
        _http.DefaultRequestHeaders.UserAgent.ParseAdd("VisioForge-FaceRecognition-Uno/1.0");
    }

    public MainPage()
    {
        this.InitializeComponent();

        Loaded += MainPage_Loaded;
        Unloaded += MainPage_Unloaded;

        VisioForgeX.InitSDK();
    }

    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
#if __ANDROID__
            if (!await EnsureCameraPermissionAsync())
            {
                lbStatus.Text = "Camera permission denied";
                return;
            }
#endif

            // The in-memory photo->identity map resets each launch, so drop persisted photos from a previous run.
            try { if (Directory.Exists(EnrolledPhotosDir)) Directory.Delete(EnrolledPhotosDir, true); } catch (Exception ex) { DebugLogger.WriteLine(ex); }

            _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
            if (_cameras != null && _cameras.Length > 0)
            {
                btCamera.Content = _cameras[0].DisplayName;
            }
            else
            {
                btCamera.Content = "No camera";
            }

            ApplyEmbeddingFamilyUI();

            if (File.Exists(GalleryPath))
            {
                try
                {
                    _gallery.Load(GalleryPath);
                    RestoreGalleryFamily();
                }
                catch (Exception ex)
                {
                    DebugLogger.WriteLine($"Gallery load skipped: {ex.Message}");
                }
            }

            RefreshGalleryStatus();
        }
        catch (Exception ex)
        {
            DebugLogger.WriteLine(ex);
        }
    }

    private async void MainPage_Unloaded(object sender, RoutedEventArgs e)
    {
        try
        {
            await CleanupAsync();
        }
        catch (Exception ex)
        {
            DebugLogger.WriteLine(ex);
        }
    }

    private void ResolveCachedModels()
    {
        var det = Path.Combine(ModelsCacheDir, DetectorModelFile);
        var emb = Path.Combine(ModelsCacheDir, SelectedEmbeddingFile);
        _detPath = File.Exists(det) ? det : null;
        _embPath = File.Exists(emb) ? emb : null;
    }

    private bool ModelsReady => !string.IsNullOrEmpty(_detPath) && File.Exists(_detPath)
                                && !string.IsNullOrEmpty(_embPath) && File.Exists(_embPath);

    private void RefreshModelStatus()
    {
        lbModels.Text = ModelsReady ? $"Models: ready (YuNet + {EmbedderName})" : $"Models: {EmbedderName} not downloaded";
        btDownloadModels.Visibility = ModelsReady ? Visibility.Collapsed : Visibility.Visible;
    }

    private void RefreshGalleryStatus()
    {
        lbGallery.Text = $"Gallery: {_gallery.Count} identities";
    }

    // Reflects the current embedding family on the toggle UI and re-resolves the cached model paths.
    private void ApplyEmbeddingFamilyUI()
    {
        btEmbModel.Content = _embeddingFamily == 1 ? "AuraFace (512-D)" : "SFace (128-D)";
        lbEmbHint.Text = _embeddingFamily == 1
            ? "AuraFace 512-D (Apache-2.0): higher accuracy, ~260 MB, slower on mobile CPU."
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

    // Cycles the embedding family (SFace 128-D <-> AuraFace 512-D).
    private async void btEmbModel_Clicked(object sender, RoutedEventArgs e)
    {
        if (_isRunning)
        {
            return;
        }

        // Serialize against the background enroll/rebuild: holding the gate keeps the model from changing
        // (which the background GetEnroller reads) while that work is in flight.
        await _teardownGate.WaitAsync();
        try
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
        finally
        {
            _teardownGate.Release();
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
    // drawResults is captured on the UI thread by the caller so this can run on a background thread.
    private FaceRecognitionBlock GetEnroller(bool drawResults)
    {
        if (_enroller != null && _enrollerFamily == _embeddingFamily)
        {
            return _enroller;
        }

        _enroller?.Dispose();
        _enroller = new FaceRecognitionBlock(BuildSettings(drawResults));
        _enrollerFamily = _embeddingFamily;
        return _enroller;
    }

    // Re-embeds the persisted photos with the selected model when the gallery was built with a different one.
    // The re-embed loop is CPU-heavy, so it runs on a background thread; UI-bound values are captured first.
    // Returns false when the gallery is incompatible with the selected model and cannot be rebuilt (a .vfg
    // loaded after restart has no source photos) — the caller must abort rather than mix embedding dimensions.
    // Callers run this while holding _teardownGate so the background rebuild can't race CleanupAsync.
    private async Task<bool> EnsureGalleryMatchesModelAsync()
    {
        if (_gallery.Count == 0 || _galleryFamily == _embeddingFamily)
        {
            return true;
        }

        if (_enrolledPhotos.Count > 0 && ModelsReady)
        {
            int family = _embeddingFamily;
            bool drawResults = cbDrawResults.IsChecked == true;
            await Task.Run(() => RebuildGallery(family, drawResults));
            return true;
        }

        return false;
    }

    private void RebuildGallery(int family, bool drawResults)
    {
        // Identities loaded from a .vfg have no tracked source photos, so the re-embed below cannot recreate them.
        var loadedOnly = _gallery.GetNames().Where(n => !_enrolledPhotos.ContainsKey(n)).ToList();

        _gallery.Clear();

        var enroller = GetEnroller(drawResults);
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
                    DebugLogger.WriteLine(ex);
                }
            }
        }

        var rebuilt = _gallery.GetNames();
        var dropped = _enrolledPhotos.Keys.Where(n => !rebuilt.Contains(n)).Concat(loadedOnly).ToList();
        _galleryFamily = family;

        // Marshal the UI updates back to the UI thread (this method may run on a background thread).
        DispatcherQueue.TryEnqueue(() =>
        {
            if (dropped.Count > 0)
            {
                lbStatus.Text = $"Rebuild dropped {dropped.Count}: {string.Join(", ", dropped)}";
            }

            RefreshGalleryStatus();
        });
    }

    private FaceRecognitionSettings BuildSettings(bool drawResults)
    {
        return new FaceRecognitionSettings(_detPath, _embPath)
        {
            Gallery = _gallery,
            EmbeddingModel = SelectedEmbeddingModel,
            RecognitionThreshold = 0.36f,
            FramesToSkip = 2,
            DrawResults = drawResults,
        };
    }

    private async void btDownloadModels_Clicked(object sender, RoutedEventArgs e)
    {
        btDownloadModels.IsEnabled = false;
        btEmbModel.IsEnabled = false;
        pbDownload.Value = 0;
        pbDownload.Visibility = Visibility.Visible;

        try
        {
            Directory.CreateDirectory(ModelsCacheDir);
            _detPath = await DownloadAsync(DetectorModelFile);
            _embPath = await DownloadAsync(SelectedEmbeddingFile);
        }
        catch (Exception ex)
        {
            lbModels.Text = "Models: download failed";
            await ShowMessageAsync("Download failed", ex.Message);
        }
        finally
        {
            pbDownload.Visibility = Visibility.Collapsed;
            btDownloadModels.IsEnabled = true;
            btEmbModel.IsEnabled = true;
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
            using (var response = await _http.GetAsync(ModelsReleaseUrl + "/" + fileName, HttpCompletionOption.ResponseHeadersRead))
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
                                DispatcherQueue.TryEnqueue(() => pbDownload.Value = percent);
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
            try { if (File.Exists(temp)) File.Delete(temp); } catch { }
            throw;
        }
    }

    private async void btEnroll_Clicked(object sender, RoutedEventArgs e)
    {
        if (_isRunning)
        {
            await ShowMessageAsync("Busy", "Stop recognition before editing the gallery.");
            return;
        }

        var name = edName.Text?.Trim();
        if (string.IsNullOrEmpty(name))
        {
            await ShowMessageAsync("Name required", "Enter a person name first.");
            return;
        }

        if (!ModelsReady)
        {
            await ShowMessageAsync("Models required", "Tap DOWNLOAD MODELS first.");
            return;
        }

        // Prevent re-entrancy: this handler is async void and awaits the picker + background enroll, so a
        // second tap could open a second picker and run a concurrent enroll against the shared gallery.
        btEnroll.IsEnabled = false;
        string persisted = null;
        bool recorded = false;
        try
        {
            var photo = await PickPhotoAsync();
            if (photo == null)
            {
                return;
            }

            // Persist the picked photo (a content URI is not directly decodable by the embedder).
            Directory.CreateDirectory(EnrolledPhotosDir);
            var ext = Path.GetExtension(photo.Name);
            persisted = Path.Combine(EnrolledPhotosDir, $"{Guid.NewGuid():N}{ext}");
            using (var src = await photo.OpenStreamForReadAsync())
            using (var dst = File.Create(persisted))
            {
                await src.CopyToAsync(dst);
            }

            int family = _embeddingFamily;
            bool drawResults = cbDrawResults.IsChecked == true;

            bool ok = false;
            bool mismatch = false;
            // Hold the teardown gate across the rebuild + enroll so CleanupAsync (page unload) can't dispose
            // the enroller / destroy the SDK while this background work runs.
            await _teardownGate.WaitAsync();
            try
            {
                if (_isCleanedUp)
                {
                    return;
                }

                if (await EnsureGalleryMatchesModelAsync())
                {
                    // Detection + embedding is CPU-heavy (seconds with AuraFace on mobile); keep it off the UI thread.
                    ok = await Task.Run(() => GetEnroller(drawResults).Enroll(name, persisted));
                }
                else
                {
                    mismatch = true;
                }
            }
            finally
            {
                _teardownGate.Release();
            }

            if (mismatch)
            {
                try { File.Delete(persisted); } catch { /* best effort */ }
                await ShowMessageAsync("Gallery mismatch", "The loaded gallery was built with a different model and has no source photos to re-embed. Clear the gallery or switch the model back before enrolling.");
                return;
            }

            if (ok)
            {
                RecordPhoto(name, persisted);
                recorded = true;
                _galleryFamily = family;
                RefreshGalleryStatus();
                await ShowMessageAsync("Enrolled", $"Enrolled '{name}'.");
            }
            else
            {
                try { File.Delete(persisted); } catch { /* best effort */ }
                await ShowMessageAsync("No face", "No face was found in the photo. Use a clear, front-facing photo.");
            }
        }
        catch (Exception ex)
        {
            if (persisted != null && !recorded)
            {
                try { File.Delete(persisted); } catch { /* best effort */ }
            }

            await ShowMessageAsync("Enrollment failed", ex.Message);
        }
        finally
        {
            btEnroll.IsEnabled = true;
        }
    }

    // Opens the platform photo picker and returns the chosen file (null if cancelled).
    private async Task<StorageFile> PickPhotoAsync()
    {
        var picker = new FileOpenPicker();
        picker.FileTypeFilter.Add(".jpg");
        picker.FileTypeFilter.Add(".jpeg");
        picker.FileTypeFilter.Add(".png");

#if NET_WINDOWS
        // WinUI requires the picker to be associated with the app window (HWND).
        if (App.MainWindow != null)
        {
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.MainWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);
        }
#endif

        return await picker.PickSingleFileAsync();
    }

    private async void btSaveGallery_Clicked(object sender, RoutedEventArgs e)
    {
        // Serialize against the background rebuild so the gallery isn't saved mid-mutation.
        await _teardownGate.WaitAsync();
        try
        {
            _gallery.Save(GalleryPath);

            // Persist the embedding family so a later load re-selects the matching model.
            if (_galleryFamily != null)
            {
                File.WriteAllText(GalleryFamilyPath, _galleryFamily.Value.ToString());
            }
            else if (File.Exists(GalleryFamilyPath))
            {
                File.Delete(GalleryFamilyPath);
            }

            await ShowMessageAsync("Saved", $"Saved {_gallery.Count} identities.");
        }
        catch (Exception ex)
        {
            await ShowMessageAsync("Save failed", ex.Message);
        }
        finally
        {
            _teardownGate.Release();
        }
    }

    private async void btLoadGallery_Clicked(object sender, RoutedEventArgs e)
    {
        if (_isRunning)
        {
            await ShowMessageAsync("Busy", "Stop recognition before editing the gallery.");
            return;
        }

        // Serialize against the background enroll/rebuild: loading clears _enrolledPhotos and replaces
        // _gallery, which RebuildGallery iterates/mutates on a background thread.
        await _teardownGate.WaitAsync();
        try
        {
            if (!File.Exists(GalleryPath))
            {
                await ShowMessageAsync("Nothing to load", "No saved gallery found.");
                return;
            }

            _gallery.Load(GalleryPath);

            // A loaded gallery has no source photos to re-embed; restore its embedding family from the sidecar.
            _enrolledPhotos.Clear();
            RestoreGalleryFamily();

            RefreshGalleryStatus();
            await ShowMessageAsync("Loaded", $"Loaded {_gallery.Count} identities.");
        }
        catch (Exception ex)
        {
            await ShowMessageAsync("Load failed", ex.Message);
        }
        finally
        {
            _teardownGate.Release();
        }
    }

    private void btCamera_Clicked(object sender, RoutedEventArgs e)
    {
        if (_isRunning || _cameras == null || _cameras.Length == 0)
        {
            return;
        }

        _cameraSelectedIndex++;
        if (_cameraSelectedIndex >= _cameras.Length)
        {
            _cameraSelectedIndex = 0;
        }

        btCamera.Content = _cameras[_cameraSelectedIndex].DisplayName;
    }

    private async void btStartStop_Clicked(object sender, RoutedEventArgs e)
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
            DebugLogger.WriteLine(ex);
        }
        finally
        {
            Interlocked.Exchange(ref _startStopBusy, 0);
        }
    }

    private async Task StartAsync()
    {
        if (_cameras == null || _cameras.Length == 0)
        {
            await ShowMessageAsync("Error", "No cameras available");
            return;
        }

        if (!ModelsReady)
        {
            await ShowMessageAsync("Models required", "Tap DOWNLOAD MODELS first.");
            return;
        }

        // Serialize against teardown: holding the gate keeps CleanupAsync (page unload) from disposing the
        // pipeline (or the enroller, during the gallery rebuild below) while it is still in use here.
        await _teardownGate.WaitAsync();
        try
        {
            if (_isCleanedUp)
            {
                return;
            }

            // Make sure the gallery embeddings match the model we're about to run (inside the gate so the
            // background rebuild can't race CleanupAsync disposing the enroller / destroying the SDK).
            if (!await EnsureGalleryMatchesModelAsync())
            {
                await ShowMessageAsync("Gallery mismatch", "The loaded gallery was built with a different model and has no source photos to re-embed. Re-enroll or switch the model back.");
                return;
            }

            _pipeline = new MediaBlocksPipeline();
            // Verbose diagnostics: SDK logs surface in the Debug output (logcat tag "VisioForge" on Android).
            _pipeline.Debug_Dir = AppDataDir;
            _pipeline.Debug_Mode = true;
            _pipeline.OnError += Pipeline_OnError;

            var device = _cameras[_cameraSelectedIndex];
            var formatItem = device.GetHDOrAnyVideoFormatAndFrameRate(out var frameRate);
            if (formatItem == null)
            {
                await DiscardPipelineAsync();
                await ShowMessageAsync("Error", "Unable to get camera format");
                return;
            }

            var videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
            {
                Format = formatItem.ToFormat()
            };
            videoSourceSettings.Format.FrameRate = frameRate;
            _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

            _face = new FaceRecognitionBlock(BuildSettings(cbDrawResults.IsChecked == true));
            _face.OnFacesIdentified += Face_OnFacesIdentified;

            // A live camera always runs unsynced (latest frame wins).
            _videoRenderer = new VideoRendererBlock(_pipeline, videoView) { IsSync = false };

            _pipeline.Connect(_videoSource.Output, _face.Input);
            _pipeline.Connect(_face.Output, _videoRenderer.Input);

            if (!await _pipeline.StartAsync())
            {
                await DiscardPipelineAsync();
                await ShowMessageAsync("Error", "Failed to start face recognition.");
                return;
            }

            _isRunning = true;
            DispatcherQueue.TryEnqueue(() =>
            {
                btStartStop.Content = "STOP";
                btStartStop.Background = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Red);
            });
        }
        catch (Exception ex)
        {
            DebugLogger.WriteLine($"Error starting: {ex.Message}");
            await DiscardPipelineAsync();
            await ShowMessageAsync("Error", $"Failed to start: {ex.Message}");
        }
        finally
        {
            _teardownGate.Release();
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
    }

    // Tears down a partially/fully built pipeline and its blocks (error / early-return paths).
    private async Task DiscardPipelineAsync()
    {
        if (_pipeline != null)
        {
            _pipeline.OnError -= Pipeline_OnError;
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

            try
            {
                await _pipeline.StopAsync();
            }
            catch (Exception ex)
            {
                DebugLogger.WriteLine($"Error stopping pipeline: {ex.Message}");
            }
            finally
            {
                _pipeline.OnError -= Pipeline_OnError;
                await _pipeline.DisposeAsync();
                _pipeline = null;

                DisposeBlocks();
                _isRunning = false;
            }

            if (updateUI)
            {
                DispatcherQueue.TryEnqueue(() =>
                {
                    btStartStop.Content = "START";
                    btStartStop.Background = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.ColorHelper.FromArgb(255, 76, 175, 80));
                });
            }
        }
        catch (Exception ex)
        {
            DebugLogger.WriteLine($"Error stopping: {ex.Message}");
        }
        finally
        {
            _teardownGate.Release();
        }
    }

    private void Face_OnFacesIdentified(object sender, FacesIdentifiedEventArgs e)
    {
        var faces = e.Faces;
        if (faces == null || faces.Length == 0)
        {
            return;
        }

        var count = faces.Length;
        string headline = null;
        float bestScore = -1f;
        foreach (var f in faces)
        {
            if (!string.IsNullOrEmpty(f.Identity) && f.Similarity > bestScore)
            {
                bestScore = f.Similarity;
                headline = $"{f.Identity} ({f.Similarity:P0})";
            }
        }

        headline ??= "Unknown";

        DispatcherQueue.TryEnqueue(() =>
        {
            if (_isCleanedUp || !_isRunning)
            {
                return;
            }

            try
            {
                lbStatus.Text = $"Faces: {count}  |  {headline}";
            }
            catch (Exception ex)
            {
                DebugLogger.WriteLine($"Face UI update failed: {ex.Message}");
            }
        });
    }

    private void Pipeline_OnError(object sender, ErrorsEventArgs e)
    {
        DebugLogger.WriteLine($"Pipeline error: {e.Message}");
    }

    private async Task CleanupAsync()
    {
        if (_isCleanedUp)
        {
            return;
        }

        // Set before waiting so a StartAsync currently holding the gate bails out when it re-checks.
        _isCleanedUp = true;

        // Same gate as StartAsync/StopAsync. Inline the stop here (don't call StopAsync) because
        // SemaphoreSlim is not re-entrant.
        await _teardownGate.WaitAsync();
        try
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;

                try
                {
                    await _pipeline.StopAsync();
                }
                catch (Exception ex)
                {
                    DebugLogger.WriteLine($"Error stopping pipeline during cleanup: {ex.Message}");
                }

                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            DisposeBlocks();
            _isRunning = false;

            _enroller?.Dispose();
            _enroller = null;

            VisioForgeX.DestroySDK();
        }
        finally
        {
            _teardownGate.Release();
        }
    }

#if __ANDROID__
    private const int PERMISSION_REQUEST_CODE = 100;
    private static TaskCompletionSource<bool> _permissionTcs;

    /// <summary>
    /// Called from MainActivity.OnRequestPermissionsResult to signal the permission result.
    /// </summary>
    public static void OnPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
    {
        if (requestCode != PERMISSION_REQUEST_CODE || _permissionTcs == null)
        {
            return;
        }

        var allGranted = grantResults.Length > 0 && grantResults.All(r => r == Permission.Granted);
        _permissionTcs.TrySetResult(allGranted);
    }

    private async Task<bool> EnsureCameraPermissionAsync()
    {
        try
        {
            var activity = Uno.UI.ContextHelper.Current as Android.App.Activity;
            if (activity == null)
            {
                return false;
            }

            if (ContextCompat.CheckSelfPermission(activity, Android.Manifest.Permission.Camera) == Permission.Granted)
            {
                return true;
            }

            _permissionTcs = new TaskCompletionSource<bool>();
            ActivityCompat.RequestPermissions(activity, new[] { Android.Manifest.Permission.Camera }, PERMISSION_REQUEST_CODE);
            var granted = await _permissionTcs.Task;
            _permissionTcs = null;
            return granted;
        }
        catch (Exception ex)
        {
            DebugLogger.WriteLine($"Android permission check failed: {ex.Message}");
            return false;
        }
    }
#endif

    private async Task ShowMessageAsync(string title, string message)
    {
#if __ANDROID__
        Toast.MakeText(Android.App.Application.Context, $"{title}: {message}", ToastLength.Long)?.Show();
        await Task.CompletedTask;
#else
        if (DispatcherQueue.HasThreadAccess)
        {
            await ShowDialogAsync(title, message);
        }
        else
        {
            var tcs = new TaskCompletionSource<bool>();
            DispatcherQueue.TryEnqueue(async () =>
            {
                try
                {
                    await ShowDialogAsync(title, message);
                    tcs.SetResult(true);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });
            await tcs.Task;
        }
#endif
    }

#if !__ANDROID__
    private async Task ShowDialogAsync(string title, string message)
    {
        try
        {
            var dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = "OK"
            };

            if (this.XamlRoot != null)
            {
                dialog.XamlRoot = this.XamlRoot;
            }

            await dialog.ShowAsync();
        }
        catch (Exception ex)
        {
            DebugLogger.WriteLine($"Error showing dialog: {ex.Message}");
        }
    }
#endif
}
