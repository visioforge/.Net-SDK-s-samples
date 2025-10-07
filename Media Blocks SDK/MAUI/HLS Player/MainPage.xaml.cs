using System.Diagnostics;
using System.Globalization;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.Types.Events;

namespace HLS_Player_MB_MAUI
{
    public partial class MainPage : ContentPage
    {
        private MediaBlocksPipeline _pipeline;
        private UniversalSourceBlockMini _source;
        private MediaBlock _videoRenderer;
        private AudioRendererBlock _audioRenderer;
        private volatile bool _isTimerUpdate;
        private System.Timers.Timer _tmPosition = new System.Timers.Timer(500);
        
        private readonly Dictionary<string, string> _sampleStreams = new Dictionary<string, string>
        {
            { "Mux Test Stream", "https://test-streams.mux.dev/x36xhzz/x36xhzz.m3u8" },
            { "Sintel Movie", "https://bitdash-a.akamaihd.net/content/sintel/hls/playlist.m3u8" },
            { "Tears of Steel", "https://demo.unified-streaming.com/k8s/features/stable/video/tears-of-steel/tears-of-steel.ism/.m3u8" },
            { "Apple Sample Stream", "https://devstreaming-cdn.apple.com/videos/streaming/examples/bipbop_16x9/bipbop_16x9_variant.m3u8" }
        };

        public MainPage()
        {
            InitializeComponent();
            
            Loaded += MainPage_Loaded;
            _tmPosition.Elapsed += tmPosition_Elapsed;
            
            // Set default selection
            pickerSampleStreams.SelectedIndex = 0;
        }

        private void MainPage_Loaded(object sender, EventArgs e)
        {
            Window.Destroying += Window_Destroying;
        }

        private async void Window_Destroying(object sender, EventArgs e)
        {
            try
            {
                await StopAllAsync();
                await DisposePipelineAsync();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error during cleanup: {ex.Message}");
            }
        }

        private async Task DisposePipelineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= _pipeline_OnError;
                _pipeline.OnStart -= _pipeline_OnStart;
                _pipeline.OnStop -= _pipeline_OnStop;
                
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        private async Task CreateEngineAsync(string hlsUrl)
        {
            // Clean up any existing pipeline
            await DisposePipelineAsync();

            _pipeline = new MediaBlocksPipeline();
            
            _pipeline.OnError += _pipeline_OnError;
            _pipeline.OnStart += _pipeline_OnStart;
            _pipeline.OnStop += _pipeline_OnStop;

            // Create source with HLS URL
            var sourceSettings = await UniversalSourceSettings.CreateAsync(
                new Uri(hlsUrl),
                renderVideo: true,
                renderAudio: true
            );
            
            _source = new UniversalSourceBlockMini(sourceSettings);
            
            // Create video renderer
            var vv = videoView.GetVideoView();
            _videoRenderer = new VideoRendererBlock(_pipeline, vv);
            
            // Create audio renderer
            _audioRenderer = new AudioRendererBlock();
            _audioRenderer.Volume = slVolume.Value / 100.0;

            // Connect pipeline
            _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);
            _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
        }

        private void _pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine($"Pipeline Error: {e.Message}");
            
            MainThread.BeginInvokeOnMainThread(() =>
            {
                lblStreamInfo.Text = $"Error: {e.Message}";
                lblStreamInfo.TextColor = Colors.Red;
                UpdateConnectionStatus(false);
            });
        }

        private void _pipeline_OnStart(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (_pipeline == null)
                    return;

                UpdateConnectionStatus(true);
                btPlay.IsEnabled = false;
                btStop.IsEnabled = true;
                
                try
                {
                    var duration = await _pipeline.DurationAsync();
                    if (duration.TotalMilliseconds > 0)
                    {
                        slSeeking.Maximum = duration.TotalMilliseconds;
                        slSeeking.IsEnabled = true;
                    }
                    else
                    {
                        // Live stream
                        slSeeking.IsEnabled = false;
                        lbStatus.Text = "LIVE";
                        lbStatus.TextColor = Colors.Red;
                    }
                    
                    // Get stream info
                    var info = _source.Settings.GetInfo();

                    if (info != null && info.VideoStreams.Count > 0)
                    {
                        var vi = info.VideoStreams[0];
                        lblVideoInfo.Text = $"Video: {vi.Width}x{vi.Height} @ {vi.FrameRate:F2} fps, {vi.Codec}";
                    }
                    
                    if (info != null && info.AudioStreams.Count > 0)
                    {
                        var ai = info.AudioStreams[0];
                        lblAudioInfo.Text = $"Audio: {ai.SampleRate} Hz, {ai.Channels} ch, {ai.Codec}";
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting stream info: {ex.Message}");
                }
            });
        }

        private void _pipeline_OnStop(object sender, StopEventArgs e)
        {
            _tmPosition.Stop();
            
            MainThread.BeginInvokeOnMainThread(() =>
            {
                UpdateConnectionStatus(false);
                ResetUI();
            });
        }

        private void UpdateConnectionStatus(bool connected)
        {
            if (connected)
            {
                connectionIndicator.BackgroundColor = Colors.Green;
                lblConnectionStatus.Text = "Connected";
                lblStreamInfo.Text = "Stream Status: Connected";
                lblStreamInfo.TextColor = Colors.Green;
            }
            else
            {
                connectionIndicator.BackgroundColor = Colors.Red;
                lblConnectionStatus.Text = "Disconnected";
                lblStreamInfo.Text = "Stream Status: Not Connected";
                lblStreamInfo.TextColor = Colors.White;
            }
        }

        private void ResetUI()
        {
            btPlay.Text = "PLAY";
            btPlay.IsEnabled = true;
            btStop.IsEnabled = false;
            slSeeking.Value = 0;
            slSeeking.IsEnabled = false;
            lbDuration.Text = "00:00:00";
            lbPosition.Text = "00:00:00";
            lbStatus.Text = "";
            lblVideoInfo.Text = "";
            lblAudioInfo.Text = "";
        }

        private async Task StopAllAsync()
        {
            _tmPosition.Stop();

            if (_pipeline != null && _pipeline.State != PlaybackState.Free)
            {
                await _pipeline.StopAsync(force: true);
            }
            
            // Ensure UI is properly reset after stop
            MainThread.BeginInvokeOnMainThread(() =>
            {
                UpdateConnectionStatus(false);
                ResetUI();
            });
        }

        private async void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_pipeline == null || _pipeline.State != PlaybackState.Play)
                return;

            try
            {
                var pos = await _pipeline.Position_GetAsync();
                var progress = (int)pos.TotalMilliseconds;

                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    if (_pipeline == null)
                        return;

                    _isTimerUpdate = true;

                    var duration = await _pipeline.DurationAsync();
                    
                    if (duration.TotalMilliseconds > 0)
                    {
                        slSeeking.Maximum = duration.TotalMilliseconds;
                        
                        if (progress > slSeeking.Maximum)
                            slSeeking.Value = slSeeking.Maximum;
                        else
                            slSeeking.Value = progress;
                        
                        lbDuration.Text = duration.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture);
                    }
                    
                    lbPosition.Text = pos.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture);

                    _isTimerUpdate = false;
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Timer error: {ex.Message}");
            }
        }

        private void pickerSampleStreams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerSampleStreams.SelectedIndex >= 0)
            {
                var selectedStream = pickerSampleStreams.Items[pickerSampleStreams.SelectedIndex];
                if (_sampleStreams.TryGetValue(selectedStream, out var url))
                {
                    txtHLSUrl.Text = url;
                }
            }
        }

        private async void btPlay_Clicked(object sender, EventArgs e)
        {
            try
            {
                var hlsUrl = txtHLSUrl.Text?.Trim();
                if (string.IsNullOrEmpty(hlsUrl))
                {
                    await DisplayAlert("Error", "Please enter an HLS stream URL", "OK");
                    return;
                }

                if (!hlsUrl.StartsWith("http://") && !hlsUrl.StartsWith("https://"))
                {
                    await DisplayAlert("Error", "Please enter a valid HTTP/HTTPS URL", "OK");
                    return;
                }

                // Start playing
                btPlay.IsEnabled = false;
                btPlay.Text = "CONNECTING...";
                lblStreamInfo.Text = "Connecting...";
                lblStreamInfo.TextColor = Colors.Yellow;
                
                await CreateEngineAsync(hlsUrl);
                await _pipeline.StartAsync();
                
                _tmPosition.Start();
                btPlay.Text = "PLAY";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error playing stream: {ex.Message}");
                await DisplayAlert("Connection Error", $"Failed to connect: {ex.Message}", "OK");
                lblStreamInfo.Text = $"Connection failed: {ex.Message}";
                lblStreamInfo.TextColor = Colors.Red;
                UpdateConnectionStatus(false);
                btPlay.IsEnabled = true;
                btPlay.Text = "PLAY";
            }
        }


        private async void btStop_Clicked(object sender, EventArgs e)
        {
            try
            {
                btStop.IsEnabled = false;
                btStop.Text = "STOPPING...";
                
                await StopAllAsync();
                
                // Properly dispose the pipeline after stop
                await DisposePipelineAsync();
                
                btStop.Text = "STOP";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error stopping: {ex.Message}");
            }
            finally
            {
                btStop.IsEnabled = true;
            }
        }

        private async void slSeeking_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            try
            {
                if (!_isTimerUpdate && _pipeline != null && slSeeking.IsEnabled)
                {
                    await _pipeline.Position_SetAsync(TimeSpan.FromMilliseconds(e.NewValue));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error setting position: {ex.Message}");
            }
        }

        private void slVolume_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (_audioRenderer != null)
            {
                _audioRenderer.Volume = e.NewValue / 100.0;
            }
        }
    }
}