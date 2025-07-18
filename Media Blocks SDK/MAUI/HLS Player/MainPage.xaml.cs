﻿using System.Diagnostics;
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
            await StopAllAsync();
            
            if (_pipeline != null)
            {
                _pipeline.OnError -= _pipeline_OnError;
                _pipeline.OnStart -= _pipeline_OnStart;
                _pipeline.OnStop -= _pipeline_OnStop;
                
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            VisioForgeX.DestroySDK();
        }

        private async Task CreateEngineAsync(string hlsUrl)
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
            }

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
                btPlayPause.IsEnabled = true;
                btStop.IsEnabled = true;
                btConnect.Text = "DISCONNECT";
                
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
                    var info =  _source.Settings.GetInfo();
                    var videoInfo = info.VideoStreams;
                    var audioInfo = info.AudioStreams;
                    
                    if (videoInfo != null && videoInfo.Count > 0)
                    {
                        var vi = videoInfo[0];
                        lblVideoInfo.Text = $"Video: {vi.Width}x{vi.Height} @ {vi.FrameRate:F2} fps, {vi.Codec}";
                    }
                    
                    if (audioInfo != null && audioInfo.Count > 0)
                    {
                        var ai = audioInfo[0];
                        lblAudioInfo.Text = $"Audio: {ai.SampleRate} Hz, {ai.Channels} ch, {ai.Codec}";
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting stream info: {ex.Message}");
                }
            });
        }

        private async void _pipeline_OnStop(object sender, StopEventArgs e)
        {
            await StopAllAsync();
            
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
            btConnect.Text = "CONNECT";
            btPlayPause.Text = "PLAY";
            btPlayPause.IsEnabled = false;
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

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
            }
        }

        private async void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_pipeline == null || _pipeline.State != PlaybackState.Play)
                return;

            try
            {
                var pos = await _pipeline.Position_GetAsync();
                var progress = (int)pos.TotalMilliseconds;

                MainThread.BeginInvokeOnMainThread(async () =>
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
                Debug.WriteLine($"Timer error: {ex.Message}");
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

        private async void btConnect_Clicked(object sender, EventArgs e)
        {
            if (_pipeline != null && (_pipeline.State == PlaybackState.Play || _pipeline.State == PlaybackState.Pause))
            {
                // Disconnect
                await StopAllAsync();
                return;
            }

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

            try
            {
                lblStreamInfo.Text = "Connecting...";
                lblStreamInfo.TextColor = Colors.Yellow;
                
                await CreateEngineAsync(hlsUrl);
                await _pipeline.StartAsync();
                
                _tmPosition.Start();
                btPlayPause.Text = "PAUSE";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Connection Error", $"Failed to connect: {ex.Message}", "OK");
                lblStreamInfo.Text = $"Connection failed: {ex.Message}";
                lblStreamInfo.TextColor = Colors.Red;
                UpdateConnectionStatus(false);
            }
        }

        private async void btPlayPause_Clicked(object sender, EventArgs e)
        {
            if (_pipeline == null)
                return;

            if (_pipeline.State == PlaybackState.Play)
            {
                await _pipeline.PauseAsync();
                btPlayPause.Text = "PLAY";
                lbStatus.Text = "PAUSED";
                lbStatus.TextColor = Colors.Yellow;
            }
            else if (_pipeline.State == PlaybackState.Pause)
            {
                await _pipeline.ResumeAsync();
                btPlayPause.Text = "PAUSE";
                lbStatus.Text = "";
            }
        }

        private async void btStop_Clicked(object sender, EventArgs e)
        {
            await StopAllAsync();
        }

        private async void slSeeking_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!_isTimerUpdate && _pipeline != null && slSeeking.IsEnabled)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromMilliseconds(e.NewValue));
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