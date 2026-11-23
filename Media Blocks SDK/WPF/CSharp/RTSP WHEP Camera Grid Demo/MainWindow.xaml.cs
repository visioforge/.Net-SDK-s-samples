using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;

namespace RTSP_WHEP_Camera_Grid_Demo
{
    /// <summary>
    /// Shows RTSP cameras on a web page over WHEP. The cameras' H.264 goes to the browsers as it is, never re-encoded;
    /// their audio is encoded to Opus.
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int FirstWhepPort = 9100;

        private readonly List<(Uri Url, string Login, string Password)> _cameras = new();

        private readonly HttpClient _http = new();

        private MediaBlocksPipeline _pipeline;

        private HttpListener _pageServer;

        private int _viewers;

        private string _pageUrl;

        private Task<bool> _start = Task.FromResult(true);

        private Task _stop = Task.CompletedTask;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Log(string text)
        {
            Dispatcher.BeginInvoke(() => mmLog.AppendText(text + Environment.NewLine));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                IsEnabled = true;
                Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                if (!WHEPServerSinkBlock.IsAvailable())
                {
                    Log("WHEPServerSinkBlock is not available: the VisioForge.CrossPlatform.Core.Windows.Adds.x64 package is missing.");
                    btStart.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!Uri.TryCreate(edURL.Text, UriKind.Absolute, out var url))
            {
                MessageBox.Show(this, "Enter a valid RTSP URL");
                return;
            }

            _cameras.Add((url, edLogin.Text, edPassword.Password));
            lbCameras.Items.Add($"Camera {_cameras.Count - 1}: {url}");
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_cameras.Count == 0)
                {
                    MessageBox.Show(this, "Add a camera first");
                    return;
                }

                if (!int.TryParse(edPagePort.Text, out var pagePort))
                {
                    MessageBox.Show(this, "Enter a valid port number");
                    return;
                }

                btStart.IsEnabled = false;
                btAdd.IsEnabled = false;
                mmLog.Clear();
                _viewers = 0;

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += (s, args) => Log(args.Message);

                _start = StartCamerasAsync(pagePort);
                var started = await _start;
                if (_pipeline == null)
                {
                    // The window was closed while starting.
                    return;
                }

                if (!started)
                {
                    await StopAsync();
                    return;
                }

                lbPageUrl.Text = _pageUrl;
                lnkPage.IsEnabled = true;
                btStop.IsEnabled = true;
                Log($"Serving {_cameras.Count} camera(s). Open {_pageUrl} in a browser.");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                await StopAsync();
            }
        }

        // The whole start in one task, so that closing the window can wait for it: probing a camera takes seconds.
        private async Task<bool> StartCamerasAsync(int pagePort)
        {
            try
            {
                _pageUrl = $"http://localhost:{pagePort}/";
                lbCameras.Items.Clear();

                // Unchecked drops every camera's audio: an audio codec with no decoder stops the whole grid, a camera listing audio it never sends leaves its tile empty.
                var audio = cbAudio.IsChecked == true;
                for (var i = 0; i < _cameras.Count; i++)
                {
                    var camera = _cameras[i];

                    // Encoded H.264 straight from the camera, and its audio if it has any (CreateAsync turns audio off otherwise).
                    var rtspSettings = await RTSPRAWSourceSettings.CreateAsync(camera.Url, camera.Login, camera.Password, audioEnabled: audio);
                    if (_pipeline == null)
                    {
                        // The window was closed while connecting.
                        return false;
                    }

                    var rtsp = new RTSPRAWSourceBlock(rtspSettings);

                    // One WHEP server per camera; only this app talks to it, the browsers go through the page server below.
                    var whep = new WHEPServerSinkBlock(new WHEPServerSinkSettings { ServerAddress = $"http://127.0.0.1:{FirstWhepPort + i}" });
                    whep.ConsumerAdded += (s, args) => UpdateViewers(+1);
                    whep.ConsumerRemoved += (s, args) => UpdateViewers(-1);

                    _pipeline.Connect(rtsp.VideoOutput, whep.VideoInput);

                    // Browsers take Opus, not the camera's AAC or G.711: decode it here, the WHEP server encodes it to Opus.
                    if (rtspSettings.AudioEnabled)
                    {
                        var audioDecoder = new DecodeBinBlock(renderVideo: false, renderAudio: true, renderSubtitle: false);
                        _pipeline.Connect(rtsp.AudioOutput, audioDecoder.Input);
                        _pipeline.Connect(audioDecoder.AudioOutput, whep.AudioInput);
                    }

                    lbCameras.Items.Add($"Camera {i}: {camera.Url}  ->  {_pageUrl}cam/{i}/whep/endpoint");
                }

                // The page and the WHEP requests share one origin: whepserversink sends no CORS headers.
                _pageServer = new HttpListener();
                _pageServer.Prefixes.Add(_pageUrl);
                try
                {
                    _pageServer.Start();
                }
                catch (HttpListenerException ex)
                {
                    Log($"Cannot serve the page on port {pagePort}, choose another one: {ex.Message}");
                    return false;
                }

                _ = ServePageAsync(_pageServer);

                return await _pipeline.StartAsync();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                return false;
            }
        }

        private async Task ServePageAsync(HttpListener server)
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

        private async Task HandleRequestAsync(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            try
            {
                var path = request.Url.AbsolutePath;
                var parts = path.Split('/', 4, StringSplitOptions.RemoveEmptyEntries);

                if (path == "/")
                {
                    await WriteAsync(response, "text/html", File.ReadAllBytes(Path.Combine(AppContext.BaseDirectory, "wwwroot", "index.html")));
                }
                else if (path == "/cameras")
                {
                    await WriteAsync(response, "application/json", Encoding.UTF8.GetBytes(_cameras.Count.ToString()));
                }
                else if (parts.Length == 4 && parts[0] == "cam" && int.TryParse(parts[1], out var camera) && camera >= 0 && camera < _cameras.Count)
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
                Log(ex.Message);

                // Once a body is under way the status is already sent.
                if (response.ContentLength64 == 0)
                {
                    response.StatusCode = 502;
                }
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

        private void UpdateViewers(int delta)
        {
            // BeginInvoke: never hold the GStreamer thread that raised the event while the UI thread is busy.
            Dispatcher.BeginInvoke(() =>
            {
                _viewers += delta;
                lbViewers.Text = $"Viewer sessions: {_viewers}";
            });
        }

        private void lnkPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(_pageUrl) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await StopAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        // A second caller (closing the window mid-stop) waits for the same stop.
        private Task StopAsync()
        {
            if (_pipeline != null)
            {
                _stop = StopPipelineAsync(_pipeline);
                _pipeline = null;
            }

            return _stop;
        }

        private async Task StopPipelineAsync(MediaBlocksPipeline pipeline)
        {
            btStop.IsEnabled = false;
            lnkPage.IsEnabled = false;
            lbPageUrl.Text = "Grid page: start first";
            lbViewers.Text = "Viewer sessions: 0";

            _pageServer?.Close();
            _pageServer = null;

            // Closing while starting: the stop cuts the start short, and disposing waits for it.
            await pipeline.StopAsync();
            await _start;
            await pipeline.DisposeAsync();

            btStart.IsEnabled = true;
            btAdd.IsEnabled = true;
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Stop the pipeline first, then close for real.
            if (_pipeline != null || !_stop.IsCompleted)
            {
                e.Cancel = true;

                try
                {
                    await StopAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

                // A window cannot close from inside its own Closing event, and the stop may end synchronously.
                _ = Dispatcher.BeginInvoke(Close);
                return;
            }

            try
            {
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
