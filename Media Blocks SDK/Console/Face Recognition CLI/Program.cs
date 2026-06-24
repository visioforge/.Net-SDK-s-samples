using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.AudioProcessing;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.VideoProcessing;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;

namespace FaceRecognitionCLI
{
    // Console version of the Face Recognition demo. It can auto-discover the most frequent faces in a
    // video (1:N enrollment), then recognize them across the file and burn the names/boxes into an
    // annotated MP4. Models (YuNet detector + SFace or AuraFace embedder, --embedding) are downloaded
    // on first use.
    internal static class Program
    {
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

        private const string DetectorModelFile = "face_detection_yunet_2023mar.onnx"; // YuNet (MIT)
        private const string EmbeddingModelFile = "face_recognition_sface_2021dec.onnx"; // SFace (Apache-2.0, 128-D)
        private const string AuraFaceModelFile = "face_recognition_auraface_v1.onnx"; // AuraFace r100, ArcFace family (Apache-2.0, by fal, 512-D)

        private static readonly string ModelsCacheDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "VisioForge", "models");

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

        // Cosine thresholds for greedy face clustering during auto-enrollment.
        private const float ClusterMergeThreshold = 0.45f;
        private const float DistinctThreshold = 0.45f;

        private static async Task<int> Main(string[] args)
        {
            if (args.Length == 0)
            {
                PrintUsage();
                return 1;
            }

            var opts = Options.Parse(args);
            if (opts == null)
            {
                PrintUsage();
                return 1;
            }

            if (!File.Exists(opts.VideoPath))
            {
                Console.WriteLine($"Source file not found: {opts.VideoPath}");
                return 1;
            }

            // SFace (128-D) or AuraFace (512-D, ArcFace family). The family selects both the weights file and the
            // crop preprocessing; a gallery is only comparable to embeddings from the same family.
            var embeddingFile = opts.Embedding == FaceEmbeddingModel.ArcFace ? AuraFaceModelFile : EmbeddingModelFile;

            string detModel, embModel;
            try
            {
                detModel = await EnsureModelAsync(DetectorModelFile);
                embModel = await EnsureModelAsync(embeddingFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to obtain the ONNX models: " + ex.Message);
                return 1;
            }

            await VisioForgeX.InitSDKAsync();
            try
            {
                Console.WriteLine($"SDK v{MediaBlocksPipeline.SDK_Version}");

                var gallery = new FaceGallery();

                if (!string.IsNullOrEmpty(opts.GalleryPath) && File.Exists(opts.GalleryPath))
                {
                    gallery.Load(opts.GalleryPath);
                    Console.WriteLine($"Loaded {gallery.Count} identities from {opts.GalleryPath}.");
                }
                else if (opts.EnrollCount > 0)
                {
                    await DiscoverAndEnrollAsync(opts, detModel, embModel, gallery);
                }

                if (gallery.Count == 0)
                {
                    Console.WriteLine("Gallery is empty - recognition will report every face as 'Unknown'.");
                }

                // Persist the gallery and verify the on-disk round-trip (save -> load -> compare).
                var galleryOut = string.IsNullOrEmpty(opts.GalleryPath)
                    ? Path.Combine(Path.GetDirectoryName(Path.GetFullPath(opts.VideoPath)), "faces.vfg")
                    : opts.GalleryPath;
                if (gallery.Count > 0)
                {
                    SaveAndVerifyGallery(gallery, galleryOut);
                }

                await RecognizeAsync(opts, detModel, embModel, gallery);

                return 0;
            }
            finally
            {
                VisioForgeX.DestroySDK();
            }
        }

        // Pass 1: run the recognizer over the video with an EMPTY gallery to collect every face embedding,
        // greedily cluster them by cosine similarity, and enroll the N most frequent, mutually-distinct people.
        private static async Task DiscoverAndEnrollAsync(Options opts, string detModel, string embModel, FaceGallery gallery)
        {
            Console.WriteLine($"== Discovery pass: scanning '{Path.GetFileName(opts.VideoPath)}' for {opts.EnrollCount} distinct faces ==");

            var clusters = new List<Cluster>();
            long sampleCount = 0;

            var settings = new FaceRecognitionSettings(detModel, embModel)
            {
                EmbeddingModel = opts.Embedding,
                DrawResults = false,
                FramesToSkip = opts.DiscoverySkip,
                DetectionConfidenceThreshold = opts.DetectionConfidence,
            };

            var pipeline = new MediaBlocksPipeline();
            pipeline.OnError += (s, e) => Console.WriteLine("  [error] " + e.Message);

            var sourceSettings = await UniversalSourceSettings.CreateAsync(opts.VideoPath, renderVideo: true, renderAudio: false);
            var source = new UniversalSourceBlock(sourceSettings);
            var face = new FaceRecognitionBlock(settings);
            var nullSink = new NullRendererBlock(MediaBlockPadMediaType.Video) { IsSync = false };

            face.OnFacesIdentified += (s, e) =>
            {
                foreach (var f in e.Faces)
                {
                    if (f.Embedding == null || f.Embedding.Length == 0)
                    {
                        continue;
                    }

                    System.Threading.Interlocked.Increment(ref sampleCount);
                    AssignToCluster(clusters, f.Embedding, f.DetectionScore);
                }
            };

            pipeline.Connect(source.VideoOutput, face.Input);
            pipeline.Connect(face.Output, nullSink.Input);

            await RunToCompletionAsync(pipeline, opts.TimeoutSeconds, showProgress: true);

            // OnFacesIdentified fires on a background worker, so read 'clusters' only after face.Dispose() joins it.
            var provider = face.ActiveProvider;

            await pipeline.StopAsync();
            pipeline.ClearBlocks();
            face.Dispose();
            await pipeline.DisposeAsync();

            Console.WriteLine($"  Collected {sampleCount} face samples in {clusters.Count} raw clusters " +
                              $"(provider: {provider}, dropped frames: {face.DroppedFrameCount}).");

            // Keep only clusters seen often enough to be a real recurring person, then pick the N largest that
            // are mutually distinct so we never enroll the same person twice.
            var candidates = clusters
                .Where(c => c.Count >= opts.MinClusterSize)
                .OrderByDescending(c => c.Count)
                .ToList();

            var selected = new List<Cluster>();
            foreach (var c in candidates)
            {
                if (selected.Count >= opts.EnrollCount)
                {
                    break;
                }

                var centroid = c.NormalizedCentroid();
                bool distinct = selected.All(s => Cosine(centroid, s.NormalizedCentroid()) < DistinctThreshold);
                if (distinct)
                {
                    selected.Add(c);
                }
            }

            if (selected.Count == 0)
            {
                Console.WriteLine("  No recurring faces found - try a different segment or lower --min-cluster.");
                return;
            }

            for (int i = 0; i < selected.Count; i++)
            {
                var c = selected[i];
                var name = $"Person {i + 1:00}";

                // Enroll up to 3 highest-confidence samples per identity for matching robustness.
                var best = c.Embeddings
                    .OrderByDescending(e => e.Score)
                    .Take(3)
                    .ToList();
                foreach (var e in best)
                {
                    gallery.Add(name, e.Vector);
                }

                Console.WriteLine($"  Enrolled '{name}' from {best.Count} sample(s) (cluster size {c.Count}).");
            }

            if (selected.Count < opts.EnrollCount)
            {
                Console.WriteLine($"  Note: requested {opts.EnrollCount} faces but only {selected.Count} distinct recurring faces were found.");
            }
        }

        // Pass 2: recognize faces against the gallery, burn boxes + names into an annotated MP4, and report
        // per-identity hit counts.
        private static async Task RecognizeAsync(Options opts, string detModel, string embModel, FaceGallery gallery)
        {
            var outPath = opts.OutputPath ?? Path.Combine(
                Path.GetDirectoryName(Path.GetFullPath(opts.VideoPath)),
                Path.GetFileNameWithoutExtension(opts.VideoPath) + "_faces.mp4");

            Console.WriteLine($"== Recognition pass: writing annotated '{Path.GetFileName(outPath)}' ==");

            var hits = new Dictionary<string, int>(StringComparer.Ordinal);
            long totalFaces = 0, unknownFaces = 0;

            var settings = new FaceRecognitionSettings(detModel, embModel)
            {
                Gallery = gallery,
                EmbeddingModel = opts.Embedding,
                DrawResults = true,
                DrawLandmarks = true,
                FramesToSkip = opts.RecognitionSkip,
                DetectionConfidenceThreshold = opts.DetectionConfidence,
                RecognitionThreshold = opts.RecognitionThreshold,
            };

            var pipeline = new MediaBlocksPipeline();
            pipeline.OnError += (s, e) => Console.WriteLine("  [error] " + e.Message);

            var sourceSettings = await UniversalSourceSettings.CreateAsync(opts.VideoPath, renderVideo: true, renderAudio: opts.Audio);
            var source = new UniversalSourceBlock(sourceSettings);
            var face = new FaceRecognitionBlock(settings);
            var converter = new VideoConverterBlock();
            var h264 = new H264EncoderBlock();
            var mp4 = new MP4SinkBlock(new MP4SinkSettings(outPath));

            face.OnFacesIdentified += (s, e) =>
            {
                foreach (var f in e.Faces)
                {
                    System.Threading.Interlocked.Increment(ref totalFaces);
                    if (string.IsNullOrEmpty(f.Identity))
                    {
                        System.Threading.Interlocked.Increment(ref unknownFaces);
                        continue;
                    }

                    lock (hits)
                    {
                        hits.TryGetValue(f.Identity, out var n);
                        hits[f.Identity] = n + 1;
                    }
                }
            };

            // Video path: source -> face (RGBA overlay) -> convert -> H264 -> MP4.
            pipeline.Connect(source.VideoOutput, face.Input);
            pipeline.Connect(face.Output, converter.Input);
            pipeline.Connect(converter.Output, h264.Input);
            pipeline.Connect(h264.Output, mp4.CreateNewInput(MediaBlockPadMediaType.Video));

            // Optional audio passthrough (off by default). The converter normalizes the decoded audio (sample
            // format + channel layout) so the AAC encoder gets a complete caps set.
            if (opts.Audio && source.AudioOutput != null)
            {
                var audioConvert = new AudioConverterBlock();
                var aac = new AACEncoderBlock();
                pipeline.Connect(source.AudioOutput, audioConvert.Input);
                pipeline.Connect(audioConvert.Output, aac.Input);
                pipeline.Connect(aac.Output, mp4.CreateNewInput(MediaBlockPadMediaType.Audio));
            }

            await RunToCompletionAsync(pipeline, opts.TimeoutSeconds, showProgress: true);

            Console.WriteLine($"  Provider: {face.ActiveProvider}, dropped frames: {face.DroppedFrameCount}, " +
                              $"last inference: {face.LastInferenceTimeMs:F1} ms.");

            await pipeline.StopAsync();
            pipeline.ClearBlocks();
            face.Dispose();
            await pipeline.DisposeAsync();

            Console.WriteLine();
            Console.WriteLine("== Recognition summary ==");
            Console.WriteLine($"  Annotated file : {outPath}");
            Console.WriteLine($"  Total faces    : {totalFaces} (unknown: {unknownFaces})");
            Console.WriteLine($"  Distinct ids   : {hits.Count}");
            foreach (var kv in hits.OrderByDescending(k => k.Value))
            {
                Console.WriteLine($"    {kv.Key}: {kv.Value} detections");
            }

            if (File.Exists(outPath))
            {
                Console.WriteLine($"  Output size    : {new FileInfo(outPath).Length / 1024} KB");
            }
        }

        private static void SaveAndVerifyGallery(FaceGallery gallery, string path)
        {
            gallery.Save(path);
            var reloaded = new FaceGallery();
            reloaded.Load(path);
            var ok = reloaded.Count == gallery.Count;
            Console.WriteLine($"  Gallery saved to {path} ({gallery.Count} identities); round-trip {(ok ? "OK" : "MISMATCH")}.");
        }

        // Greedily assigns an embedding to the best-matching cluster, or starts a new one.
        private static void AssignToCluster(List<Cluster> clusters, float[] embedding, float score)
        {
            Cluster best = null;
            float bestSim = -1f;
            foreach (var c in clusters)
            {
                var sim = Cosine(embedding, c.NormalizedCentroid());
                if (sim > bestSim)
                {
                    bestSim = sim;
                    best = c;
                }
            }

            if (best != null && bestSim >= ClusterMergeThreshold)
            {
                best.Add(embedding, score);
            }
            else
            {
                var c = new Cluster(embedding.Length);
                c.Add(embedding, score);
                clusters.Add(c);
            }
        }

        private static float Cosine(float[] a, float[] b)
        {
            if (a == null || b == null || a.Length != b.Length)
            {
                return -1f;
            }

            float dot = 0f;
            for (int i = 0; i < a.Length; i++)
            {
                dot += a[i] * b[i];
            }

            return dot;
        }

        // Starts the pipeline and waits for EOS (or a timeout), printing a position line periodically.
        private static async Task RunToCompletionAsync(MediaBlocksPipeline pipeline, int timeoutSeconds, bool showProgress)
        {
            var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            void OnStop(object s, StopEventArgs e) => tcs.TrySetResult(true);
            // A fatal pipeline error never reaches end-of-stream, so complete the wait on error too; otherwise the
            // loop would spin until the timeout.
            void OnError(object s, ErrorsEventArgs e) => tcs.TrySetResult(true);
            pipeline.OnStop += OnStop;
            pipeline.OnError += OnError;

            try
            {
                if (!await pipeline.StartAsync())
                {
                    Console.WriteLine("  ERROR: the pipeline failed to start (check model paths / input file).");
                    return;
                }

                var deadline = DateTime.UtcNow.AddSeconds(timeoutSeconds);
                while (!tcs.Task.IsCompleted && DateTime.UtcNow < deadline)
                {
                    var finished = await Task.WhenAny(tcs.Task, Task.Delay(1000));
                    if (finished == tcs.Task)
                    {
                        break;
                    }

                    if (showProgress)
                    {
                        var pos = await pipeline.Position_GetAsync();
                        Console.Write($"\r  {pos:hh\\:mm\\:ss}   ");
                    }
                }

                if (showProgress)
                {
                    Console.WriteLine();
                }

                if (!tcs.Task.IsCompleted)
                {
                    Console.WriteLine("  [warn] timeout reached before end-of-stream.");
                }
            }
            finally
            {
                pipeline.OnStop -= OnStop;
                pipeline.OnError -= OnError;
            }
        }

        private static async Task<string> EnsureModelAsync(string fileName)
        {
            var path = Path.Combine(ModelsCacheDir, fileName);
            if (File.Exists(path))
            {
                return path;
            }

            Console.WriteLine($"Downloading {fileName} ...");
            Directory.CreateDirectory(ModelsCacheDir);
            var bytes = await _http.GetByteArrayAsync(ModelsReleaseUrl + "/" + fileName);

            // Write to a temp file then move into place so an interrupted download never leaves a corrupt
            // .onnx at the final path (which the File.Exists guard above would otherwise reuse forever).
            var tmpPath = path + ".part";
            try
            {
                File.WriteAllBytes(tmpPath, bytes);
                File.Move(tmpPath, path, true);
            }
            catch
            {
                try { File.Delete(tmpPath); } catch { }
                throw;
            }

            Console.WriteLine($"Saved {fileName} ({bytes.Length / 1024} KB).");
            return path;
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Face Recognition CLI (Media Blocks SDK)");
            Console.WriteLine();
            Console.WriteLine("Usage: FaceRecognitionCLI <video> [options]");
            Console.WriteLine();
            Console.WriteLine("  --enroll N           Auto-discover and enroll the N most frequent distinct faces (default 0).");
            Console.WriteLine("  --gallery <file.vfg> Load this gallery instead of auto-enrolling; otherwise the");
            Console.WriteLine("                       auto-built gallery is saved next to the video as faces.vfg.");
            Console.WriteLine("  --embedding <name>   Embedding model: 'sface' (128-D, default) or 'auraface' (512-D).");
            Console.WriteLine("                       A gallery is only comparable to embeddings from the same model.");
            Console.WriteLine("  --out <file.mp4>     Annotated output path (default <video>_faces.mp4).");
            Console.WriteLine("  --threshold T        Recognition cosine threshold (default 0.36).");
            Console.WriteLine("  --det-confidence T   Detector confidence threshold (default 0.6).");
            Console.WriteLine("  --min-cluster N      Minimum samples for an auto-enrolled identity (default 4).");
            Console.WriteLine("  --skip N             Frames to skip between recognitions in the output pass (default 0).");
            Console.WriteLine("  --discovery-skip N   Frames to skip during discovery (default 2).");
            Console.WriteLine("  --timeout S          Per-pass timeout in seconds (default 1800).");
            Console.WriteLine("  --audio              Mux the source audio into the annotated output (off by default).");
        }

        // A running cluster of similar face embeddings (one person). The centroid is the renormalized mean.
        private sealed class Cluster
        {
            private readonly float[] _sum;

            public Cluster(int dim)
            {
                _sum = new float[dim];
            }

            public List<Sample> Embeddings { get; } = new List<Sample>();

            public int Count => Embeddings.Count;

            public void Add(float[] embedding, float score)
            {
                Embeddings.Add(new Sample(embedding, score));
                for (int i = 0; i < _sum.Length && i < embedding.Length; i++)
                {
                    _sum[i] += embedding[i];
                }
            }

            public float[] NormalizedCentroid()
            {
                double mag = 0d;
                for (int i = 0; i < _sum.Length; i++)
                {
                    mag += (double)_sum[i] * _sum[i];
                }

                var result = new float[_sum.Length];
                if (mag <= 0d)
                {
                    return result;
                }

                float inv = (float)(1.0 / Math.Sqrt(mag));
                for (int i = 0; i < _sum.Length; i++)
                {
                    result[i] = _sum[i] * inv;
                }

                return result;
            }

            public readonly struct Sample
            {
                public Sample(float[] vector, float score)
                {
                    Vector = vector;
                    Score = score;
                }

                public float[] Vector { get; }

                public float Score { get; }
            }
        }

        private sealed class Options
        {
            public string VideoPath { get; private set; }

            public int EnrollCount { get; private set; }

            public string GalleryPath { get; private set; }

            public string OutputPath { get; private set; }

            public float RecognitionThreshold { get; private set; } = 0.36f;

            public float DetectionConfidence { get; private set; } = 0.6f;

            public int MinClusterSize { get; private set; } = 4;

            public int RecognitionSkip { get; private set; }

            public int DiscoverySkip { get; private set; } = 2;

            public int TimeoutSeconds { get; private set; } = 1800;

            public bool Audio { get; private set; }

            public FaceEmbeddingModel Embedding { get; private set; } = FaceEmbeddingModel.SFace;

            public static Options Parse(string[] args)
            {
                var o = new Options { VideoPath = args[0] };
                for (int i = 1; i < args.Length; i++)
                {
                    var a = args[i];
                    string Next() => i + 1 < args.Length ? args[++i] : null;
                    switch (a)
                    {
                        case "--enroll": o.EnrollCount = ParseInt(Next(), o.EnrollCount); break;
                        case "--gallery": o.GalleryPath = Next(); break;
                        case "--out": o.OutputPath = Next(); break;
                        case "--embedding": if (!ParseEmbedding(Next(), out var emb)) { return null; } o.Embedding = emb; break;
                        case "--threshold": o.RecognitionThreshold = ParseFloat(Next(), o.RecognitionThreshold); break;
                        case "--det-confidence": o.DetectionConfidence = ParseFloat(Next(), o.DetectionConfidence); break;
                        case "--min-cluster": o.MinClusterSize = ParseInt(Next(), o.MinClusterSize); break;
                        case "--skip": o.RecognitionSkip = ParseInt(Next(), o.RecognitionSkip); break;
                        case "--discovery-skip": o.DiscoverySkip = ParseInt(Next(), o.DiscoverySkip); break;
                        case "--timeout": o.TimeoutSeconds = ParseInt(Next(), o.TimeoutSeconds); break;
                        case "--audio": o.Audio = true; break;
                        default:
                            Console.WriteLine($"Unknown option: {a}");
                            return null;
                    }
                }

                return o;
            }

            private static bool ParseEmbedding(string s, out FaceEmbeddingModel model)
            {
                switch (s?.Trim().ToLowerInvariant())
                {
                    case "sface": model = FaceEmbeddingModel.SFace; return true;
                    case "auraface":
                    case "arcface": model = FaceEmbeddingModel.ArcFace; return true;
                    default:
                        Console.WriteLine($"Unknown --embedding value: '{s}' (use 'sface' or 'auraface').");
                        model = FaceEmbeddingModel.SFace;
                        return false;
                }
            }

            private static int ParseInt(string s, int fallback) =>
                int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v) ? v : fallback;

            private static float ParseFloat(string s, float fallback) =>
                float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var v) ? v : fallback;
        }
    }
}
