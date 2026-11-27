using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
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

        // The combo boxes show DisplayName, which is not unique: keep the devices the items were added from.
        private readonly List<VideoCaptureDeviceInfo> _videoDevices = new List<VideoCaptureDeviceInfo>();

        private readonly List<AudioCaptureDeviceInfo> _audioDevices = new List<AudioCaptureDeviceInfo>();

        private int _viewers;

        private string _viewerUrl;

        private bool _closing;

        private bool _canClose;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Also called from the GStreamer threads: never block them on the UI thread.
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

                if (!WebRTCSinkBlock.IsAvailable())
                {
                    Log("WebRTCSinkBlock is not available: the VisioForge.CrossPlatform.Core.Windows.Adds.x64 package is missing.");
                    btStart.IsEnabled = false;
                }

                DeviceEnumerator.Shared.OnVideoSourceAdded += (s, device) => Dispatcher.BeginInvoke(() =>
                {
                    _videoDevices.Add(device);
                    cbVideoInput.Items.Add(device.DisplayName);
                    if (cbVideoInput.Items.Count == 1)
                    {
                        cbVideoInput.SelectedIndex = 0;
                    }
                });

                DeviceEnumerator.Shared.OnAudioSourceAdded += (s, device) => Dispatcher.BeginInvoke(() =>
                {
                    _audioDevices.Add(device);
                    cbAudioInput.Items.Add(device.DisplayName);
                });

                cbAudioInput.Items.Add("None");
                cbAudioInput.SelectedIndex = 0;

                await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();
                await DeviceEnumerator.Shared.StartAudioSourceMonitorAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                IsEnabled = true;
                Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
                MessageBox.Show(this, $"Initialization failed: {ex.Message}");
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

                if (!int.TryParse(edWebPort.Text, out var webPort) || webPort < 1 || webPort > 65535 ||
                    !int.TryParse(edSignallingPort.Text, out var signallingPort) || signallingPort < 1 || signallingPort > 65535)
                {
                    Log("Enter port numbers between 1 and 65535.");
                    return;
                }

                btStart.IsEnabled = false;
                mmLog.Clear();

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += (s, args) => Log(args.Message);

                // Camera, split to the local preview and to the browsers.
                var device = _videoDevices[cbVideoInput.SelectedIndex];
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
                    var audioDevice = _audioDevices[cbAudioInput.SelectedIndex - 1]; // index 0 is None
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

                // The handler is async void: an exception out of the cleanup would end the application.
                try
                {
                    await StopAsync();
                }
                catch (Exception stopEx)
                {
                    Log($"Cleanup failed: {stopEx.Message} Close the window to release the camera and the ports.");
                }
            }
        }

        private void UpdateViewers(int delta, string message)
        {
            // Called from the streaming threads: never block them on the UI thread.
            Dispatcher.BeginInvoke(() =>
            {
                _viewers += delta;
                lbViewers.Text = $"Viewers: {_viewers}";
                mmLog.AppendText(message + Environment.NewLine);
            });
        }

        private static string GetLanAddress()
        {
            // A phone on the same Wi-Fi cannot reach a VPN, Hyper-V or WSL address: prefer a real Ethernet or
            // Wi-Fi adapter that has a default gateway.
            var virtualMarkers = new[] { "vEthernet", "Virtual", "VPN", "Wintun", "TAP-", "Tailscale", "WireGuard" };
            try
            {
                foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus != OperationalStatus.Up ||
                        (nic.NetworkInterfaceType != NetworkInterfaceType.Ethernet && nic.NetworkInterfaceType != NetworkInterfaceType.Wireless80211) ||
                        virtualMarkers.Any(m => nic.Name.Contains(m, StringComparison.OrdinalIgnoreCase) || nic.Description.Contains(m, StringComparison.OrdinalIgnoreCase)))
                    {
                        continue;
                    }

                    var properties = nic.GetIPProperties();
                    if (!properties.GatewayAddresses.Any(g => g.Address.AddressFamily == AddressFamily.InterNetwork))
                    {
                        continue;
                    }

                    var address = properties.UnicastAddresses.FirstOrDefault(a => a.Address.AddressFamily == AddressFamily.InterNetwork);
                    if (address != null)
                    {
                        return address.Address.ToString();
                    }
                }
            }
            catch (NetworkInformationException)
            {
            }

            // Fallback: a UDP connect sends nothing; it only picks the interface that routes outward.
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
            if (_canClose)
            {
                return;
            }

            // Keep the window open until the pipeline has stopped and the SDK is destroyed, then close again.
            e.Cancel = true;
            if (_closing)
            {
                return;
            }

            _closing = true;
            IsEnabled = false;

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

            _canClose = true;

            // Deferred: WPF throws if Close() runs while this Closing call is still on the stack.
            _ = Dispatcher.BeginInvoke(new Action(Close));
        }

        private void cbVideoInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbVideoFormat.Items.Clear();
                if (cbVideoInput.SelectedIndex < 0)
                {
                    return;
                }

                var device = _videoDevices[cbVideoInput.SelectedIndex];

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

        private void cbVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbVideoFrameRate.Items.Clear();
                if (cbVideoInput.SelectedIndex < 0 || e.AddedItems.Count == 0)
                {
                    return;
                }

                var device = _videoDevices[cbVideoInput.SelectedIndex];
                var format = device.VideoFormats.FirstOrDefault(x => x.Name == (string)e.AddedItems[0]);
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

        private void cbAudioInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbAudioFormat.Items.Clear();
                if (cbAudioInput.SelectedIndex <= 0 || e.AddedItems.Count == 0)
                {
                    return;
                }

                var device = _audioDevices[cbAudioInput.SelectedIndex - 1]; // index 0 is None

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
