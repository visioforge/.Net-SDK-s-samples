using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;

namespace WHEP_Player_Demo
{
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private Task<bool> _start = Task.FromResult(true);

        private Task _stop = Task.CompletedTask;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await VisioForgeX.InitSDKAsync();
            }
            catch (Exception ex)
            {
                lbStatus.Text = ex.Message;
                return;
            }

            if (!WHEPSourceBlock.IsAvailable())
            {
                lbStatus.Text = "whepclientsrc is missing: add the VisioForge.CrossPlatform.Core.Windows.Adds.x64 package.";
                return;
            }

            btStart.IsEnabled = true;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            btStart.IsEnabled = false;
            cbAudio.IsEnabled = false;
            lbStatus.Text = "Connecting...";

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;

            bool started;
            try
            {
                // No StunServer: on a LAN the hosts connect directly. Clear Audio for a video-only stream.
                var audio = cbAudio.IsChecked == true;
                var source = new WHEPSourceBlock(new WHEPSourceSettings
                {
                    Location = edURL.Text,
                    AudioEnabled = audio,
                });

                // IsSync = false: show each frame on arrival instead of holding it for the 200 ms jitter buffer.
                var videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };
                _pipeline.Connect(source.VideoOutput, videoRenderer.Input);

                if (audio)
                {
                    // Audio plays on arrival too.
                    var audioRenderer = new AudioRendererBlock { IsSync = false };
                    _pipeline.Connect(source.AudioOutput, audioRenderer.Input);
                }

                _start = _pipeline.StartAsync();
                started = await _start;
            }
            catch (Exception ex)
            {
                // Shown below as the reason the start failed.
                lbStatus.Text = ex.Message;
                _start = Task.FromResult(false);
                started = false;
            }

            if (_pipeline == null)
            {
                // The window was closed while connecting.
                return;
            }

            if (!started)
            {
                if (lbStatus.Text == "Connecting...")
                {
                    lbStatus.Text = "Unable to start";
                }

                await StopAsync();
                btStart.IsEnabled = true;
                cbAudio.IsEnabled = true;
                return;
            }

            // An error may have arrived already; keep it on screen.
            if (lbStatus.Text == "Connecting...")
            {
                lbStatus.Text = "Playing";
            }

            btStop.IsEnabled = true;
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            btStop.IsEnabled = false;

            try
            {
                await StopAsync();
                lbStatus.Text = "Stopped";
            }
            catch (Exception ex)
            {
                lbStatus.Text = ex.Message;
            }

            btStart.IsEnabled = true;
            cbAudio.IsEnabled = true;
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
            // Closing while connecting: the stop cuts the start short, and disposing waits for it.
            await pipeline.StopAsync();
            await _start;
            pipeline.OnError -= Pipeline_OnError;
            await pipeline.DisposeAsync();
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.BeginInvoke(() => lbStatus.Text = e.Message);
        }

        private async void Window_Closing(object sender, CancelEventArgs e)
        {
            // Stop the pipeline first, then close for real.
            if (_pipeline != null || !_stop.IsCompleted)
            {
                e.Cancel = true;
                await StopAsync();

                // A window cannot close from inside its own Closing event, and the stop may end synchronously.
                _ = Dispatcher.BeginInvoke(Close);
                return;
            }

            VisioForgeX.DestroySDK();
        }
    }
}
