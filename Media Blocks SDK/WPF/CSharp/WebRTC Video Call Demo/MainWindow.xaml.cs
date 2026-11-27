using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioProcessing;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.AudioEffects;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;

namespace WebRTC_Video_Call_Demo
{
    /// <summary>
    /// A two-way video call between this application and a web browser over WebRTC, with no media server.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VolumeBlock _microphoneVolume;

        private VideoBalanceBlock _cameraBalance;

        // The combo boxes show DisplayName, which is not unique: keep the devices the items were added from.
        private readonly List<VideoCaptureDeviceInfo> _videoDevices = new List<VideoCaptureDeviceInfo>();

        private readonly List<AudioCaptureDeviceInfo> _audioDevices = new List<AudioCaptureDeviceInfo>();

        private string _callUrl;

        private bool _closing;

        private bool _canClose;

        // The Start or Stop in progress: closing the window waits for it before the teardown.
        private System.Threading.Tasks.Task _busyTask;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Also called from the GStreamer threads: never block them on the UI thread.
        private void Log(string text)
        {
            Dispatcher.BeginInvoke(() => mmLog.AppendText(text + Environment.NewLine));
        }

        // The pipeline is created when the window opens and again after each Stop; Start builds the call into it.
        private void CreatePipeline()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += (s, args) => Log(args.Message);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();

                // The window was closed while the SDK loaded: the SDK is destroyed already.
                if (_closing)
                {
                    return;
                }

                CreatePipeline();
                IsEnabled = true;
                Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                if (!WebRTCSinkBlock.IsAvailable() || !WebRTCSourceBlock.IsAvailable() || !EchoCancellationBlock.IsAvailable())
                {
                    Log("WebRTC is not available: the VisioForge.CrossPlatform.Core.Windows.Adds.x64 package is missing.");
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
                    if (cbAudioInput.Items.Count == 1)
                    {
                        cbAudioInput.SelectedIndex = 0;
                    }
                });

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
            _busyTask = StartCallAsync();
            await _busyTask;
        }

        // Never throws: every failure is logged, so the window can await it while closing.
        private async System.Threading.Tasks.Task StartCallAsync()
        {
            try
            {
                if (cbVideoInput.SelectedIndex < 0 || cbAudioInput.SelectedIndex < 0)
                {
                    MessageBox.Show(this, "Select a camera and a microphone");
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

                // WebRTC sink: sends this side of the call, runs the signalling server and serves the call page in wwwroot.
                var sink = new WebRTCSinkBlock(new WebRTCSinkSettings
                {
                    SignallingServerHost = "127.0.0.1",
                    SignallingServerPort = signallingPort,
                    WebServerDirectory = Path.Combine(AppContext.BaseDirectory, "wwwroot"),
                    WebServerAddress = $"http://127.0.0.1:{webPort}/",
                });

                sink.ConsumerAdded += (s, args) => Log("The browser joined the call.");
                sink.ConsumerRemoved += (s, args) => Log("The browser left the call.");

                // Camera: "Camera off" turns the picture black, then it goes to the local preview and to the browser.
                var device = _videoDevices[cbVideoInput.SelectedIndex];
                var videoSettings = new VideoCaptureDeviceSourceSettings(device);
                var format = device.VideoFormats.FirstOrDefault(x => x.Name == cbVideoFormat.Text);
                if (format != null)
                {
                    videoSettings.Format = format.ToFormat();
                    if (double.TryParse(cbVideoFrameRate.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var frameRate))
                    {
                        videoSettings.Format.FrameRate = new VideoFrameRate(frameRate);
                    }
                }

                var videoSource = new SystemVideoSourceBlock(videoSettings);
                _cameraBalance = new VideoBalanceBlock(new VideoBalanceVideoEffect());
                var videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
                var localRenderer = new VideoRendererBlock(_pipeline, LocalView) { IsSync = false };

                _pipeline.Connect(videoSource.Output, _cameraBalance.Input);
                _pipeline.Connect(_cameraBalance.Output, videoTee.Input);
                _pipeline.Connect(videoTee.Outputs[0], localRenderer.Input);
                _pipeline.Connect(videoTee.Outputs[1], sink.CreateNewInput(MediaBlockPadMediaType.Video));

                // Microphone: mute, then echo cancellation, which removes the browser's voice the microphone picks up
                // from the speakers.
                var audioDevice = _audioDevices[cbAudioInput.SelectedIndex];
                var audioFormat = audioDevice.Formats.FirstOrDefault(x => x.Name == cbAudioFormat.Text);
                var audioSource = new SystemAudioSourceBlock(audioDevice.CreateSourceSettings(audioFormat?.ToFormat()));
                _microphoneVolume = new VolumeBlock();
                var echoCancellation = new EchoCancellationBlock(new EchoCancellationSettings());

                _pipeline.Connect(audioSource.Output, _microphoneVolume.Input);
                _pipeline.Connect(_microphoneVolume.Output, echoCancellation.Input);
                _pipeline.Connect(echoCancellation.Output, sink.CreateNewInput(MediaBlockPadMediaType.Audio));

                // The browser's picture and voice: the renderers wait for the call. The voice passes the echo
                // canceller on its way to the speakers, so it knows what to remove.
                var remoteRenderer = new VideoRendererBlock(_pipeline, RemoteView) { IsSync = false };
                _pipeline.AddBlock(remoteRenderer);
                _pipeline.Connect(echoCancellation.PlaybackOutput, new AudioRendererBlock().Input);

                if (!await _pipeline.StartAsync())
                {
                    await StopAsync();
                    return;
                }

                // WebRTC source on the sink's signalling server, added once the server runs: it waits for the call page
                // to call it. Its outputs are connected after it is built.
                var source = new WebRTCSourceBlock(new WebRTCSourceSettings { SignallingServer = $"ws://127.0.0.1:{signallingPort}" });
                source.VideoOutput.OnDemandConnect = true;
                source.AudioOutput.OnDemandConnect = true;

                if (!_pipeline.AddBlockLive(source) ||
                    !_pipeline.ConnectLive(source.VideoOutput, remoteRenderer.Input) ||
                    !_pipeline.ConnectLive(source.AudioOutput, echoCancellation.PlaybackInput) ||
                    !_pipeline.SyncBlockStateLive(source))
                {
                    Log("Unable to add the WebRTC source.");

                    await StopAsync();
                    return;
                }

                _callUrl = $"http://127.0.0.1:{webPort}/?signalling={signallingPort}";
                lbCallUrl.Text = _callUrl;
                lnkCall.IsEnabled = true;
                btStop.IsEnabled = true;
                btMute.IsEnabled = true;
                btCameraOff.IsEnabled = true;
                Log($"Ready. Open {_callUrl} in a browser on this computer to call.");
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
                    Log($"Cleanup failed: {stopEx.Message} Close the window to release the devices and the ports.");
                }
            }
        }

        private void btMute_Click(object sender, RoutedEventArgs e)
        {
            _microphoneVolume.Mute = btMute.IsChecked == true;
        }

        private void btCameraOff_Click(object sender, RoutedEventArgs e)
        {
            // Zero contrast and saturation, minimum brightness: a black picture, still sent, so the call keeps its video.
            var off = btCameraOff.IsChecked == true;
            _cameraBalance.Settings.Contrast = off ? 0 : 1;
            _cameraBalance.Settings.Saturation = off ? 0 : 1;
            _cameraBalance.Settings.Brightness = off ? -1 : 0;
        }

        private void lnkCall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(_callUrl) { UseShellExecute = true });
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
                _busyTask = StopAsync();
                await _busyTask;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async System.Threading.Tasks.Task StopAsync()
        {
            btStop.IsEnabled = false;
            btMute.IsEnabled = false;
            btCameraOff.IsEnabled = false;
            btMute.IsChecked = false;
            btCameraOff.IsChecked = false;
            lnkCall.IsEnabled = false;
            lbCallUrl.Text = "Call page: press Start first";

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            CreatePipeline();
            LocalView.CallRefresh();
            RemoteView.CallRefresh();
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
                if (_busyTask != null)
                {
                    await _busyTask;
                }

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

                foreach (var item in _videoDevices[cbVideoInput.SelectedIndex].VideoFormats)
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

                var format = _videoDevices[cbVideoInput.SelectedIndex].VideoFormats.FirstOrDefault(x => x.Name == (string)e.AddedItems[0]);
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
                if (cbAudioInput.SelectedIndex < 0)
                {
                    return;
                }

                foreach (var format in _audioDevices[cbAudioInput.SelectedIndex].Formats)
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
