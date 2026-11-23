using System.Net;
using System.Runtime.InteropServices;
using System.Text;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;

namespace RTSPWHEPCameraGrid
{
    /// <summary>
    /// Shows RTSP cameras on a web page over WHEP. The cameras' H.264 goes to the browsers as it is, never re-encoded;
    /// their audio is encoded to Opus.
    /// Usage: RTSPWHEPCameraGrid [--port 8080] [--login user --password pass] [--no-audio] rtsp://camera1 [rtsp://camera2 ...]
    /// </summary>
    internal class Program
    {
        private const int FirstWhepPort = 9100;

        private static readonly HttpClient _http = new();

        private static int _cameraCount;

        private static int _viewers;

        static async Task Main(string[] args)
        {
#if __MACOS__
            // A macOS exe has an AppKit context with no run loop; continuations posted to it never run.
            System.Threading.SynchronizationContext.SetSynchronizationContext(null);
#endif

            var pagePort = 8080;
            string login = null, password = null;
            var audio = true;
            var cameras = new List<Uri>();
            var argsValid = true;
            for (var i = 0; i < args.Length && argsValid; i++)
            {
                switch (args[i])
                {
                    case "--port" when i + 1 < args.Length: argsValid = int.TryParse(args[++i], out pagePort); break;
                    case "--login" when i + 1 < args.Length: login = args[++i]; break;
                    case "--password" when i + 1 < args.Length: password = args[++i]; break;
                    case "--no-audio": audio = false; break;
                    default:
                        argsValid = Uri.TryCreate(args[i], UriKind.Absolute, out var camera) && camera.Scheme.StartsWith("rtsp", StringComparison.Ordinal);
                        if (argsValid) cameras.Add(camera);
                        break;
                }
            }

            if (!argsValid || cameras.Count == 0)
            {
                Console.WriteLine("Usage: RTSPWHEPCameraGrid [--port 8080] [--login user --password pass] [--no-audio] rtsp://camera1 [rtsp://camera2 ...]");
                return;
            }

            await VisioForgeX.InitSDKAsync();

            var pipeline = new MediaBlocksPipeline();
            pipeline.OnError += (s, e) => Console.WriteLine($"ERROR: {e.Message}");

            // The page and the WHEP requests share one origin: whepserversink sends no CORS headers.
            var pageServer = new HttpListener();

            // Ctrl+C (SIGINT) and SIGTERM (systemctl stop, docker stop) stop the same way as Enter, through the finally below; a second one terminates as usual.
            var stop = new TaskCompletionSource();
            var signals = 0;
            void OnSignal(PosixSignalContext c)
            {
                c.Cancel = Interlocked.Increment(ref signals) == 1;
                if (c.Cancel) Console.WriteLine("Stopping... press Ctrl+C again to force.");
                stop.TrySetResult();
            }
            using var sigint = PosixSignalRegistration.Create(PosixSignal.SIGINT, OnSignal);
            using var sigterm = PosixSignalRegistration.Create(PosixSignal.SIGTERM, OnSignal);

            try
            {
                if (!WHEPServerSinkBlock.IsAvailable())
                {
                    Console.WriteLine("WHEPServerSinkBlock is not available: add the VisioForge.CrossPlatform.Core.*.Adds package for this platform; on Linux also install gstreamer1.0-plugins-bad and gstreamer1.0-nice.");
                    return;
                }

                var pageUrl = $"http://localhost:{pagePort}/";
                for (var i = 0; i < cameras.Count && !stop.Task.IsCompleted; i++)
                {
                    // Encoded H.264 straight from the camera, and its audio if it has any (CreateAsync turns audio off otherwise).
                    // --no-audio drops every camera's audio: an audio codec with no decoder stops the whole grid, a camera listing audio it never sends leaves its tile empty.
                    var rtspSettings = await RTSPRAWSourceSettings.CreateAsync(cameras[i], login, password, audioEnabled: audio);
                    var rtsp = new RTSPRAWSourceBlock(rtspSettings);

                    // One WHEP server per camera; only this app talks to it, the browsers go through the page server below.
                    var whep = new WHEPServerSinkBlock(new WHEPServerSinkSettings { ServerAddress = $"http://127.0.0.1:{FirstWhepPort + i}" });
                    whep.ConsumerAdded += (s, e) => Console.WriteLine($"Viewer sessions: {Interlocked.Increment(ref _viewers)}");
                    whep.ConsumerRemoved += (s, e) => Console.WriteLine($"Viewer sessions: {Interlocked.Decrement(ref _viewers)}");

                    pipeline.Connect(rtsp.VideoOutput, whep.VideoInput);

                    // Browsers take Opus, not the camera's AAC or G.711: decode it here, the WHEP server encodes it to Opus.
                    if (rtspSettings.AudioEnabled)
                    {
                        var audioDecoder = new DecodeBinBlock(renderVideo: false, renderAudio: true, renderSubtitle: false);
                        pipeline.Connect(rtsp.AudioOutput, audioDecoder.Input);
                        pipeline.Connect(audioDecoder.AudioOutput, whep.AudioInput);
                    }
                    Console.WriteLine($"Camera {i}: {cameras[i]}  ->  {pageUrl}cam/{i}/whep/endpoint");
                }

                if (stop.Task.IsCompleted)
                {
                    return;
                }

                _cameraCount = cameras.Count;

                pageServer.Prefixes.Add(pageUrl);
                pageServer.Start();
                _ = ServePageAsync(pageServer);

                if (!await pipeline.StartAsync())
                {
                    Console.WriteLine("Failed to start the pipeline.");
                    return;
                }

                Console.WriteLine($"Open {pageUrl} in a browser. Press Enter or Ctrl+C to stop.");

                // Without a terminal (docker without -i, systemd) ReadLine returns null at once: Ctrl+C stops it then.
                _ = Task.Run(() => { if (Console.ReadLine() != null) stop.TrySetResult(); });
                await stop.Task;
            }
            catch (Exception ex)
            {
                // An unreachable camera, or a page port that is taken.
                Console.WriteLine(ex.Message);
            }
            finally
            {
                pageServer.Close();
                await pipeline.StopAsync();
                await pipeline.DisposeAsync();
                VisioForgeX.DestroySDK();
            }
        }

        private static async Task ServePageAsync(HttpListener server)
        {
            while (server.IsListening)
            {
                HttpListenerContext context;
                try
                {
                    context = await server.GetContextAsync();
                }
                catch (Exception ex) when (ex is HttpListenerException || ex is ObjectDisposedException)
                {
                    return;
                }

                _ = HandleRequestAsync(context);
            }
        }

        private static async Task HandleRequestAsync(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            try
            {
                var path = request.Url.AbsolutePath;
                var parts = path.Split('/', 4, StringSplitOptions.RemoveEmptyEntries);

                if (path == "/")
                {
                    using var page = typeof(Program).Assembly.GetManifestResourceStream("index.html");
                    using var html = new MemoryStream();
                    await page.CopyToAsync(html);
                    await WriteAsync(response, "text/html", html.ToArray());
                }
                else if (path == "/cameras")
                {
                    await WriteAsync(response, "application/json", Encoding.UTF8.GetBytes(_cameraCount.ToString()));
                }
                else if (parts.Length == 4 && parts[0] == "cam" && int.TryParse(parts[1], out var camera) && camera >= 0 && camera < _cameraCount)
                {
                    // /cam/N/whep/... is forwarded to camera N's WHEP server.
                    using var forward = new HttpRequestMessage(new HttpMethod(request.HttpMethod), $"http://127.0.0.1:{FirstWhepPort + camera}/{parts[2]}/{parts[3]}");
                    if (request.HasEntityBody)
                    {
                        using var body = new MemoryStream();
                        await request.InputStream.CopyToAsync(body);
                        forward.Content = new ByteArrayContent(body.ToArray());
                        forward.Content.Headers.TryAddWithoutValidation("Content-Type", request.ContentType);
                    }

                    using var reply = await _http.SendAsync(forward);
                    if (reply.Headers.Location != null)
                    {
                        // The session URL the player deletes when it leaves, under the same /cam/N prefix.
                        response.Headers["Location"] = $"/cam/{camera}{reply.Headers.Location.OriginalString}";
                    }

                    response.StatusCode = (int)reply.StatusCode;
                    await WriteAsync(response, reply.Content.Headers.ContentType?.ToString(), await reply.Content.ReadAsByteArrayAsync());
                }
                else
                {
                    response.StatusCode = 404;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.StatusCode = 502;
            }
            finally
            {
                response.Close();
            }
        }

        private static async Task WriteAsync(HttpListenerResponse response, string contentType, byte[] body)
        {
            response.ContentType = contentType;
            response.ContentLength64 = body.Length;
            await response.OutputStream.WriteAsync(body);
        }
    }
}
