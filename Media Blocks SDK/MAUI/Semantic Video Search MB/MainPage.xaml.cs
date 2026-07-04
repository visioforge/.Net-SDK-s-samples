using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using VisioForge.Core;
using VisioForge.Core.AI.Clip;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

namespace SemanticVideoSearchMB
{
    public partial class MainPage : ContentPage
    {
        private MediaBlocksPipeline _pipeline;
        private VideoRendererBlock _videoRenderer;
        private SystemVideoSourceBlock _videoSource;

        // File source (used instead of the camera when the source is a video file).
        private UniversalSourceBlock _fileSource;

        // Encodes sampled frames into CLIP embeddings and (via EncodeText) natural-language queries.
        private VideoEmbeddingBlock _embeddingBlock;

        // The shared semantic index: the embedding block appends each sampled frame; queries search it.
        private readonly FrameEmbeddingIndex _index = new FrameEmbeddingIndex();

        // Standalone CLIP engine used only to encode text queries, decoupled from the indexing pipeline so search
        // keeps working after indexing finishes and the pipeline (and its embedding block) has been torn down.
        private ClipEmbeddingEngine _clipEngine;

        // Frames-per-second choices for indexing; the selected value maps to SampleInterval = 1/fps.
        private static readonly double[] IndexFpsOptions = { 0.5, 1.0, 2.0, 4.0, 5.0, 10.0 };

        // Maximum number of relevant frames shown per search (after the margin threshold is applied).
        private const int MaxResults = 24;

        // Generic "background" prompts. CLIP's raw cosine carries a large per-prompt bias, so an absent concept
        // still scores ~0.2 on every frame. Subtracting the best of these generic descriptions from the query's
        // cosine cancels that bias, leaving a margin that is positive only where the query beats a plain description
        // of the frame — which is what makes an absent concept (e.g. "a tank") return nothing.
        private static readonly string[] BaselinePrompts =
        {
            "a photo", "a picture", "an image", "a screenshot", "a random background",
        };

        // Source selection: false = live camera, true = video file.
        private bool _isFile;
        private string _filename;

        private VideoCaptureDeviceInfo[] _cameras;
        private int _cameraSelectedIndex = 0;
        private bool _isRunning = false;
        private bool _isCleanedUp = false;

        // Captured so the Window.Destroying handler can be unsubscribed on cleanup.
        private Window _window;

        // START/STOP re-entrancy guard (0 = free, 1 = busy).
        private int _startStopBusy;

        // Serializes teardown (STOP + page-close).
        private readonly SemaphoreSlim _teardownGate = new SemaphoreSlim(1, 1);

        // ---- CLIP model files (hosted in the SDK samples release; not shipped in NuGet) ----
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v2";

        private const string VisionModelFile = "clip-vitb32-vision.onnx";
        private const string TextModelFile = "clip-vitb32-text.onnx";
        private const string VocabFile = "clip-vocab.json";
        private const string MergesFile = "clip-merges.txt";

        // Downloaded models are cached here; AppDataDirectory is writable on every platform.
        private static string ModelsCacheDir => Path.Combine(FileSystem.AppDataDirectory, "models", "clip");

        // Default path used when saving the in-memory index.
        private static string DefaultIndexPath => Path.Combine(FileSystem.AppDataDirectory, "frames.vfei");

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(15) };

        private string _visionPath;
        private string _textPath;
        private string _vocabPath;
        private string _mergesPath;

        // A single search hit as displayed in the results list (timestamp + score + source file).
        public sealed class SearchResultItem
        {
            public string Time { get; set; }

            public string Score { get; set; }

            public string Source { get; set; }
        }

        static MainPage()
        {
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("VisioForge-SemanticVideoSearch-Demo/1.0");
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

                // Drop any copied source videos left in the cache by a previous run.
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

                // Populate the frames-per-second picker (default 1 fps).
                var fpsItems = new List<string>();
                foreach (var f in IndexFpsOptions)
                {
                    fpsItems.Add(f.ToString(CultureInfo.InvariantCulture));
                }

                pkIndexFps.ItemsSource = fpsItems;
                pkIndexFps.SelectedIndex = 1;

                // Prefill model paths from the cache when they were already downloaded.
                ResolveCachedModels();
                RefreshModelStatus();

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
            _visionPath = CachedOrNull(VisionModelFile);
            _textPath = CachedOrNull(TextModelFile);
            _vocabPath = CachedOrNull(VocabFile);
            _mergesPath = CachedOrNull(MergesFile);
        }

        private static string CachedOrNull(string fileName)
        {
            var path = Path.Combine(ModelsCacheDir, fileName);
            return File.Exists(path) && new FileInfo(path).Length > 0 ? path : null;
        }

        private bool ModelsReady =>
            !string.IsNullOrEmpty(_visionPath) && File.Exists(_visionPath) &&
            !string.IsNullOrEmpty(_textPath) && File.Exists(_textPath) &&
            !string.IsNullOrEmpty(_vocabPath) && File.Exists(_vocabPath) &&
            !string.IsNullOrEmpty(_mergesPath) && File.Exists(_mergesPath);

        private void RefreshModelStatus()
        {
            lbModels.Text = ModelsReady ? "Models: ready (CLIP ViT-B/32)" : "Models: not downloaded";

            // Hide the Download button once all four CLIP files are cached.
            btDownloadModels.IsVisible = !ModelsReady;
        }

        private async void btDownloadModels_Clicked(object sender, EventArgs e)
        {
            btDownloadModels.IsEnabled = false;
            var original = btDownloadModels.Text;
            btDownloadModels.Text = "Downloading...";
            pbDownload.Progress = 0;
            pbDownload.IsVisible = true;

            try
            {
                Directory.CreateDirectory(ModelsCacheDir);
                foreach (var fileName in new[] { VisionModelFile, TextModelFile, VocabFile, MergesFile })
                {
                    await DownloadAsync(fileName);
                }

                ResolveCachedModels();
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
                btDownloadModels.Text = original;
                RefreshModelStatus();
            }
        }

        private async Task<string> DownloadAsync(string fileName)
        {
            var dest = Path.Combine(ModelsCacheDir, fileName);

            // Already present with a plausible size: skip.
            if (File.Exists(dest) && new FileInfo(dest).Length > 0)
            {
                return dest;
            }

            var temp = dest + ".part";
            Dispatcher.Dispatch(() => lbModels.Text = $"Downloading {fileName}...");

            try
            {
                // I/O runs off the UI thread; progress updates marshal back via Dispatcher.Dispatch.
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
                                    var progress = percent / 100.0;
                                    Dispatcher.Dispatch(() => pbDownload.Progress = progress);
                                }
                            }
                        }

                        // Reject a truncated download so a partial file is never cached as complete.
                        if (total > 0 && readTotal != total)
                        {
                            throw new IOException($"Incomplete download: received {readTotal} of {total} bytes.");
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

        // Frames per second to sample for indexing; drives SampleInterval = 1/fps. Defaults to 1 fps.
        private double SelectedIndexFps =>
            (pkIndexFps.SelectedIndex >= 0 && pkIndexFps.SelectedIndex < IndexFpsOptions.Length)
                ? IndexFpsOptions[pkIndexFps.SelectedIndex]
                : 1.0;

        private VideoEmbeddingSettings BuildEmbeddingSettings()
        {
            var sourceTag = _isFile
                ? _filename
                : (_cameras != null && _cameras.Length > 0 ? _cameras[_cameraSelectedIndex].DisplayName : "camera");

            return new VideoEmbeddingSettings(_visionPath, _textPath, _vocabPath, _mergesPath)
            {
                Index = _index,
                SourceTag = sourceTag,
                SampleInterval = TimeSpan.FromSeconds(1.0 / SelectedIndexFps),
                Provider = OnnxExecutionProvider.Auto,

                // For a file: block the streaming thread until the CLIP worker is free instead of dropping samples,
                // so the file decodes at full speed but every 1s interval is captured. For a live camera: keep the
                // default (drop-latest) — a camera cannot be backpressured without stalling capture.
                BackpressureNoDrop = _isFile,
            };
        }

        // Lazily builds the standalone text-encoding CLIP engine from the cached model paths. Used by search only;
        // independent of the indexing pipeline so queries work whether or not indexing is running.
        private ClipEmbeddingEngine EnsureClipEngine()
        {
            if (_clipEngine != null)
            {
                return _clipEngine;
            }

            var engine = new ClipEmbeddingEngine(BuildEmbeddingSettings());

            bool ok;
            try { ok = engine.Init(); }
            catch { engine.Dispose(); throw; }

            if (!ok)
            {
                engine.Dispose();
                throw new InvalidOperationException("The CLIP engine failed to initialize. Check the model files on the Models row.");
            }

            _clipEngine = engine;
            return engine;
        }

        private async Task RequestCameraPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Camera>();

            if (result != PermissionStatus.Granted)
            {
                if (Permissions.ShouldShowRationale<Permissions.Camera>())
                {
                    if (await DisplayAlert(null, "You need to allow access to the Camera to index the live feed", "OK", "Cancel"))
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

                // The embedding block is a passthrough: it taps frames for indexing but leaves the video unchanged.
                _embeddingBlock = new VideoEmbeddingBlock(BuildEmbeddingSettings());
                _embeddingBlock.OnFrameEmbedding += Embedding_OnFrameEmbedding;

                IVideoView vv = videoView.GetVideoView();

                // Unsynchronized: a live camera has no clock to follow, and a file indexes as fast as it decodes.
                _videoRenderer = new VideoRendererBlock(_pipeline, vv) { IsSync = false };

                _pipeline.Connect(videoOut, _embeddingBlock.Input);
                _pipeline.Connect(_embeddingBlock.Output, _videoRenderer.Input);

                if (_isCleanedUp)
                {
                    await DiscardPipelineAsync();
                    return;
                }

                if (!await _pipeline.StartAsync())
                {
                    await DiscardPipelineAsync();
                    await DisplayAlert("Error", "Failed to start indexing.", "OK");
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
                lbIndex.Text = $"Indexing... ({_index.Count} frames)";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error starting: {ex.Message}");
                await DiscardPipelineAsync();
                await DisplayAlert("Error", $"Failed to start: {ex.Message}", "OK");
            }
        }

        // Disposes the source/embedding/renderer blocks (not owned by the pipeline) on every teardown path.
        private void DisposeBlocks()
        {
            if (_embeddingBlock != null)
            {
                _embeddingBlock.OnFrameEmbedding -= Embedding_OnFrameEmbedding;
                _embeddingBlock.Dispose();
                _embeddingBlock = null;
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

        // Tears down the indexing pipeline and returns the button to START. Called on a manual STOP, on end-of-file
        // (completed: true), and on page close (updateUI: false). Search stays available afterwards via _clipEngine.
        private async Task StopAsync(bool updateUI = true, bool completed = false)
        {
            await _teardownGate.WaitAsync();
            try
            {
                if (_pipeline == null)
                {
                    return;
                }

                // Unsubscribe first so stopping the pipeline here cannot re-enter this method via OnStop.
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;

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
                        lbIndex.Text = completed
                            ? $"Indexing complete: {_index.Count} frames. Enter a query and tap SEARCH."
                            : $"Indexed frames: {_index.Count} (stopped)";
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

        // Raised on a worker thread for each sampled frame; used only to keep the indexed-frame count live.
        private void Embedding_OnFrameEmbedding(object sender, FrameEmbeddingEventArgs e)
        {
            var count = _index.Count;
            Dispatcher.Dispatch(() =>
            {
                if (_isCleanedUp || !_isRunning)
                {
                    return;
                }

                lbIndex.Text = $"Indexing... ({count} frames)";
            });
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine($"Pipeline error: {e.Message}");
        }

        // End-of-stream for a video file: finish the indexing session. Tear the pipeline down and return the button
        // to START so a completed index no longer looks like it is still running. Search stays available because it
        // uses the standalone _clipEngine, not the (now disposed) embedding block.
        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Dispatch(async () =>
            {
                if (_isCleanedUp || !_isRunning)
                {
                    return;
                }

                await StopAsync(updateUI: true, completed: true);
            });
        }

        private void slThreshold_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (lbThreshold != null)
            {
                lbThreshold.Text = slThreshold.Value.ToString("F3", CultureInfo.InvariantCulture);
            }
        }

        private async void btSearch_Clicked(object sender, EventArgs e)
        {
            var query = edQuery.Text?.Trim();
            if (string.IsNullOrEmpty(query))
            {
                await DisplayAlert("Query required", "Enter a search phrase, e.g. \"a red car\".", "OK");
                return;
            }

            if (!ModelsReady)
            {
                await DisplayAlert("Models required", "Tap DOWNLOAD MODELS first.", "OK");
                return;
            }

            if (_index.Count == 0)
            {
                await DisplayAlert("Empty index", "No frames indexed yet. Index a source (or load a saved index) first.", "OK");
                return;
            }

            btSearch.IsEnabled = false;
            try
            {
                // Read the UI-thread-affine threshold before going off-thread.
                float minMargin = (float)slThreshold.Value;

                // Score each frame by a CONTRASTIVE margin, not raw cosine: margin = cos(frame, query) minus the best
                // cos(frame, generic-prompt). Raw CLIP cosine carries a large per-prompt bias (an absent concept still
                // scores ~0.2 everywhere), so a plain top-K always "finds" something. Subtracting the best generic
                // description cancels that bias, leaving a value that is positive only where the query genuinely
                // describes the frame better than a plain caption — so an absent concept (e.g. "a tank") returns
                // nothing. The standalone engine keeps search working during indexing and after it finishes.
                var items = await Task.Run(() =>
                {
                    var engine = EnsureClipEngine();

                    var queryCos = _index.Search(engine.EncodeText(query), _index.Count);

                    // Best generic-prompt cosine per frame (keyed by source + timestamp).
                    var baseline = new Dictionary<(string, TimeSpan), float>();
                    foreach (var neg in BaselinePrompts)
                    {
                        foreach (var h in _index.Search(engine.EncodeText(neg), _index.Count))
                        {
                            var key = (h.SourceTag, h.Timestamp);
                            if (!baseline.TryGetValue(key, out var cur) || h.Score > cur)
                            {
                                baseline[key] = h.Score;
                            }
                        }
                    }

                    var ranked = queryCos
                        .Select(h =>
                        {
                            baseline.TryGetValue((h.SourceTag, h.Timestamp), out var nb);
                            return (hit: h, margin: h.Score - nb);
                        })
                        .Where(r => r.margin >= minMargin)
                        .OrderByDescending(r => r.margin)
                        .Take(MaxResults);

                    var list = new List<SearchResultItem>();
                    foreach (var (hit, margin) in ranked)
                    {
                        list.Add(new SearchResultItem
                        {
                            Time = string.Format(CultureInfo.InvariantCulture, "{0:00}:{1:00}:{2:00}", (int)hit.Timestamp.TotalHours, hit.Timestamp.Minutes, hit.Timestamp.Seconds),
                            Score = margin.ToString("F3", CultureInfo.InvariantCulture),
                            Source = string.IsNullOrEmpty(hit.SourceTag) ? string.Empty : Path.GetFileName(hit.SourceTag),
                        });
                    }

                    return list;
                });

                cvResults.ItemsSource = items;
                lbIndex.Text = items.Count > 0
                    ? $"Indexed frames: {_index.Count}  |  {items.Count} match(es) with margin ≥ {minMargin.ToString("F3", CultureInfo.InvariantCulture)}"
                    : $"Indexed frames: {_index.Count}  |  no match with margin ≥ {minMargin.ToString("F3", CultureInfo.InvariantCulture)} — lower Min margin or try another query";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Search failed", ex.Message, "OK");
            }
            finally
            {
                btSearch.IsEnabled = true;
            }
        }

        private async void btSaveIndex_Clicked(object sender, EventArgs e)
        {
            if (_index.Count == 0)
            {
                await DisplayAlert("Empty index", "There is nothing to save yet.", "OK");
                return;
            }

            try
            {
                _index.Save(DefaultIndexPath);
                await DisplayAlert("Saved", $"Saved {_index.Count} embeddings to:\n{DefaultIndexPath}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Save failed", ex.Message, "OK");
            }
        }

        private async void btLoadIndex_Clicked(object sender, EventArgs e)
        {
            try
            {
                var pick = await FilePicker.Default.PickAsync(new PickOptions { PickerTitle = "Select a saved index (.vfei)" });
                if (pick == null)
                {
                    return;
                }

                _index.Load(pick.FullPath);
                cvResults.ItemsSource = null;
                lbIndex.Text = $"Loaded index: {_index.Count} frames";
                await DisplayAlert("Loaded", $"Loaded {_index.Count} embeddings.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Load failed", ex.Message, "OK");
            }
        }

        private void btClearIndex_Clicked(object sender, EventArgs e)
        {
            _index.Clear();
            cvResults.ItemsSource = null;
            lbIndex.Text = _isRunning ? "Indexing... (0 frames)" : "Indexed frames: 0";
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
            lbFile.IsVisible = _isFile;
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

            _clipEngine?.Dispose();
            _clipEngine = null;

            VisioForgeX.DestroySDK();
        }
    }
}
