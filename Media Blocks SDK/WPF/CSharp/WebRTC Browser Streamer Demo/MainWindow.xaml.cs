using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;

namespace WebRTC_Browser_Streamer_Demo
{
    /// <summary>
    /// Streams a camera and a microphone to web browsers over WebRTC, with no media server.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private WebRTCSinkBlock _webrtcSink;

        private int _viewers;

        private string _viewerUrl;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Log(string text)
        {
            Dispatcher.Invoke(() => mmLog.AppendText(text + Environment.NewLine));
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

                if (!WebRTCSinkBlock.IsAvailable())
                {
                    Log("WebRTCSinkBlock is not available: the VisioForge.CrossPlatform.Core.Windows.Adds.x64 package is missing.");
                    btStart.IsEnabled = false;
                }

                DeviceEnumerator.Shared.OnVideoSourceAdded += (s, device) => Dispatcher.Invoke(() =>
                {
                    cbVideoInput.Items.Add(device.DisplayName);
                    if (cbVideoInput.Items.Count == 1)
                    {
                        cbVideoInput.SelectedIndex = 0;
                    }
                });

                DeviceEnumerator.Shared.OnAudioSourceAdded += (s, device) => Dispatcher.Invoke(() => cbAudioInput.Items.Add(device.DisplayName));

                cbAudioInput.Items.Add("None");
                cbAudioInput.SelectedIndex = 0;

                await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();
                await DeviceEnumerator.Shared.StartAudioSourceMonitorAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbVideoInput.SelectedIndex < 0)
                {
                    MessageBox.Show(this, "Select a camera");
                    return;
                }

                if (!int.TryParse(edWebPort.Text, out var webPort) || !int.TryParse(edSignallingPort.Text, out var signallingPort))
                {
                    MessageBox.Show(this, "Enter valid port numbers");
                    return;
                }

                btStart.IsEnabled = false;
                mmLog.Clear();

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += (s, args) => Log(args.Message);

                // Camera, split to the local preview and to the browsers.
                var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).First(x => x.DisplayName == cbVideoInput.Text);
                var videoSettings = new VideoCaptureDeviceSourceSettings(device);
                var format = device.VideoFormats.FirstOrDefault(x => x.Name == cbVideoFormat.Text);
                if (format != null)
                {
                    videoSettings.Format = format.ToFormat();
                    if (double.TryParse(cbVideoFrameRate.Text, out var frameRate))
                    {
                        videoSettings.Format.FrameRate = new VideoFrameRate(frameRate);
                    }
                }

                var videoSource = new SystemVideoSourceBlock(videoSettings);
                var videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
                var videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };

                _pipeline.Connect(videoSource.Output, videoTee.Input);
                _pipeline.Connect(videoTee.Outputs[0], videoRenderer.Input);

                // WebRTC sink: its own signalling server plus a web server for the viewer page in wwwroot.
                var host = cbAllowLan.IsChecked == true ? "0.0.0.0" : "127.0.0.1";
                _webrtcSink = new WebRTCSinkBlock(new WebRTCSinkSettings
                {
                    SignallingServerHost = host,
                    SignallingServerPort = signallingPort,
                    WebServerDirectory = Path.Combine(AppContext.BaseDirectory, "wwwroot"),
                    WebServerAddress = $"http://{host}:{webPort}/",
                });

                _viewers = 0;
                _webrtcSink.ConsumerAdded += (s, args) => UpdateViewers(+1, $"Viewer connected: {args.PeerId}");
                _webrtcSink.ConsumerRemoved += (s, args) => UpdateViewers(-1, $"Viewer left: {args.PeerId}");

                // Raw video and audio: the sink encodes them for each browser.
                _pipeline.Connect(videoTee.Outputs[1], _webrtcSink.CreateNewInput(MediaBlockPadMediaType.Video));

                if (cbAudioInput.SelectedIndex > 0)
                {
                    var audioDevice = (await DeviceEnumerator.Shared.AudioSourcesAsync()).First(x => x.DisplayName == cbAudioInput.Text);
                    var audioFormat = audioDevice.Formats.FirstOrDefault(x => x.Name == cbAudioFormat.Text);
                    var audioSource = new SystemAudioSourceBlock(audioDevice.CreateSourceSettings(audioFormat?.ToFormat()));
                    _pipeline.Connect(audioSource.Output, _webrtcSink.CreateNewInput(MediaBlockPadMediaType.Audio));
                }

                if (!await _pipeline.StartAsync())
                {
                    await StopAsync();
                    return;
                }

                var pageHost = cbAllowLan.IsChecked == true ? GetLanAddress() : "127.0.0.1";
                _viewerUrl = $"http://{pageHost}:{webPort}/?signalling={signallingPort}";
                lbViewerUrl.Text = _viewerUrl;
                lnkViewer.IsEnabled = true;
                btStop.IsEnabled = true;
                Log($"Streaming. Open {_viewerUrl} in a browser.");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                await StopAsync();
            }
        }

        private void UpdateViewers(int delta, string message)
        {
            Dispatcher.Invoke(() =>
            {
                _viewers += delta;
                lbViewers.Text = $"Viewers: {_viewers}";
                mmLog.AppendText(message + Environment.NewLine);
            });
        }

        private static string GetLanAddress()
        {
            // A UDP connect sends nothing; it only picks the interface that routes outward.
            try
            {
                using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.Connect("8.8.8.8", 80);
                return ((IPEndPoint)socket.LocalEndPoint).Address.ToString();
            }
            catch (SocketException)
            {
            }

            // No default route (an isolated LAN): take the first non-loopback IPv4 address.
            try
            {
                var address = Dns.GetHostAddresses(Dns.GetHostName())
                    .FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(a));
                return address?.ToString() ?? "127.0.0.1";
            }
            catch (SocketException)
            {
                return "127.0.0.1";
            }
        }

        private void lnkViewer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(_viewerUrl) { UseShellExecute = true });
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

        private async System.Threading.Tasks.Task StopAsync()
        {
            btStop.IsEnabled = false;
            lnkViewer.IsEnabled = false;
            lbViewerUrl.Text = "Viewer page: start the stream first";
            lbViewers.Text = "Viewers: 0";

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            VideoView1.CallRefresh();
            btStart.IsEnabled = true;
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    await _pipeline.DisposeAsync();
                    _pipeline = null;
                }

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void cbVideoInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbVideoFormat.Items.Clear();
                if (e.AddedItems.Count == 0)
                {
                    return;
                }

                var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == (string)e.AddedItems[0]);
                if (device == null)
                {
                    return;
                }

                foreach (var item in device.VideoFormats)
                {
                    cbVideoFormat.Items.Add(item.Name);
                }

                if (cbVideoFormat.Items.Count > 0)
                {
                    cbVideoFormat.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void cbVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbVideoFrameRate.Items.Clear();
                if (e.AddedItems.Count == 0)
                {
                    return;
                }

                var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == cbVideoInput.Text);
                var format = device?.VideoFormats.FirstOrDefault(x => x.Name == (string)e.AddedItems[0]);
                if (format == null)
                {
                    return;
                }

                foreach (var item in format.GetFrameRateRangeAsStringList())
                {
                    cbVideoFrameRate.Items.Add(item);
                }

                if (cbVideoFrameRate.Items.Count > 0)
                {
                    cbVideoFrameRate.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void cbAudioInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbAudioFormat.Items.Clear();
                if (cbAudioInput.SelectedIndex <= 0 || e.AddedItems.Count == 0)
                {
                    return;
                }

                var device = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == (string)e.AddedItems[0]);
                if (device == null)
                {
                    return;
                }

                foreach (var format in device.Formats)
                {
                    cbAudioFormat.Items.Add(format.Name);
                }

                if (cbAudioFormat.Items.Count > 0)
                {
                    cbAudioFormat.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
