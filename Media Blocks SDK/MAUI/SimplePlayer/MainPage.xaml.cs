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

namespace Simple_Player_MB_MAUI
{
    /// <summary>
    /// The main page of the application.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline? _pipeline;

        /// <summary>
        /// The source.
        /// </summary>
        private UniversalSourceBlock? _source;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private MediaBlock? _videoRenderer;

        /// <summary>
        /// The audio renderer.
        /// </summary>
        private AudioRendererBlock? _audioRenderer;

        /// <summary>
        /// The filename.
        /// </summary>
        private string? _filename;

        /// <summary>
        /// The seeking flag.
        /// </summary>
        private volatile bool _isTimerUpdate;

        /// <summary>
        /// The position timer.
        /// </summary>
        private System.Timers.Timer _tmPosition = new System.Timers.Timer(500);        

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            
            _tmPosition.Elapsed += tmPosition_Elapsed;
        }

        /// <summary>
        /// Create engine async.
        /// </summary>
        private async Task CreateEngineAsync()
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
            }

            _pipeline = new MediaBlocksPipeline();

            _pipeline.OnError += _player_OnError;
            _pipeline.OnStart += _player_OnStart;
            _pipeline.OnStop += _player_OnStop;

            _audioRenderer = new AudioRendererBlock();
            
            _source = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(new Uri(_filename!)));
            
            var vv = videoView.GetVideoView();
            _videoRenderer = new VideoRendererBlock(_pipeline, vv);
            _audioRenderer = new AudioRendererBlock();

            _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);
            _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
        }

        /// <summary>
        /// Player on stop.
        /// </summary>
        private async void _player_OnStop(object? sender, StopEventArgs e)
        {
            try
            {
                await StopAllAsync();
                
                // update UI controls using invoke
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    btSpeed.Text = "SPEED: 1X";
                    btPlayPause.Text = "PLAY";
                    slSeeking.Value = 0;
                    lbDuration.Text = "00:00:00";
                    lbPosition.Text = "00:00:00";
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in OnStop: {ex.Message}");
            }
        }

        /// <summary>
        /// Main page loaded.
        /// </summary>
        private void MainPage_Loaded(object? sender, EventArgs e)
        {
            Window.Destroying += Window_Destroying;
        }

        /// <summary>
        /// Player on start.
        /// </summary>
        private async void _player_OnStart(object? sender, EventArgs e)
        {
            try
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    if (_pipeline == null)
                    {
                        return;
                    }

                    slSeeking.Maximum = (await _pipeline.DurationAsync()).TotalMilliseconds;
                });
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine($"Error in OnStart: {exception.Message}");
            }                      
        }

        /// <summary>
        /// Window destroying.
        /// </summary>
        private async void Window_Destroying(object? sender, EventArgs e)
        {
            try
            {
                if (_pipeline != null)
                {
                    _pipeline.OnError -= _player_OnError;
                    await _pipeline.StopAsync();

                    _pipeline.Dispose();
                    _pipeline = null!;
                }

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error during cleanup: {ex.Message}");
            }
        }

        /// <summary>
        /// Player on error.
        /// </summary>
        private void _player_OnError(object? sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        /// <summary>
        /// Stop all async.
        /// </summary>
        private async Task StopAllAsync()
        {
            if (_pipeline == null)
            {
                return;
            }

            _tmPosition.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
            }
        }

        /// <summary>
        /// Handles the Elapsed event of the tmPosition control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        /// <summary>
        /// Tm position elapsed.
        /// </summary>
        private async void tmPosition_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (_pipeline == null)
            {
                return;
            }

            try
            {
                var pos = await _pipeline.Position_GetAsync();
                var progress = (int)pos.TotalMilliseconds;

                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    if (_pipeline == null)
                    {
                        return;
                    }

                    _isTimerUpdate = true;

                    slSeeking.Maximum = (await _pipeline.DurationAsync()).TotalMilliseconds;

                    if (progress > slSeeking.Maximum)
                    {
                        slSeeking.Value = slSeeking.Maximum;
                    }
                    else
                    {
                        slSeeking.Value = progress;
                    }

                    // This is where the received data is passed
                    lbPosition.Text = $"{pos.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";
                    lbDuration.Text = $"{(await _pipeline.DurationAsync()).ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";

                    _isTimerUpdate = false;
                });
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine($"Error in timer update: {exception.Message}");
            }
        }

        /// <summary>
        /// Sl seeking value changed.
        /// </summary>
        private async void slSeeking_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            try
            {
                if (!_isTimerUpdate && _pipeline != null)
                {
                    await _pipeline.Position_SetAsync(TimeSpan.FromMilliseconds(e.NewValue));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error setting position: {ex.Message}");
            }
        }

        /// <summary>
        /// Sl volume value changed.
        /// </summary>
        private void slVolume_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            if (_pipeline != null && _audioRenderer != null)
            {
                _audioRenderer.Volume = e.NewValue / 100.0;
            }
        }

        /// <summary>
        /// Handles the bt open clicked event.
        /// </summary>
        private async void btOpen_Clicked(object? sender, EventArgs e)
        {
            try
            {
                await StopAllAsync();

                btPlayPause.Text = "PLAY";

                var result = await FilePicker.Default.PickAsync();
                if (result != null)
                {
                    _filename = result.FullPath;
                    lbFilename.Text = _filename;
                    lbFilename.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error opening file: {ex.Message}");
                // The user canceled or something went wrong
            }
        }

        /// <summary>
        /// Handles the bt play pause clicked event.
        /// </summary>
        private async void btPlayPause_Clicked(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_filename))
                {
                    return;
                }

                // START
                if (_pipeline == null || _pipeline.State == PlaybackState.Free)
                {
                    await CreateEngineAsync();

                    await _pipeline!.StartAsync();

                    _tmPosition.Start();

                    btPlayPause.Text = "PAUSE";
                }
                else if (_pipeline.State == PlaybackState.Play)
                {
                    await _pipeline.PauseAsync();

                    btPlayPause.Text = "PLAY";
                }
                else if (_pipeline.State == PlaybackState.Pause)
                {
                    await _pipeline.ResumeAsync();

                    btPlayPause.Text = "PAUSE";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in play/pause: {ex.Message}");
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await DisplayAlertAsync("Error", $"Playback error: {ex.Message}", "OK");
                });
            }
        }

        /// <summary>
        /// Handles the bt speed clicked event.
        /// </summary>
        private async void btSpeed_Clicked(object? sender, EventArgs e)
        {
            try
            {
                if (btSpeed.Text == "SPEED: 1X")
                {
                    // set 2x
                    btSpeed.Text = "SPEED: 2X";
                    await _pipeline!.Rate_SetAsync(2.0);
                }
                else if (btSpeed.Text == "SPEED: 2X")
                {
                    // set 0.5x
                    btSpeed.Text = "SPEED: 0.5X";
                    await _pipeline!.Rate_SetAsync(0.5);
                }
                else if (btSpeed.Text == "SPEED: 0.5X")
                {
                    // set 1x
                    btSpeed.Text = "SPEED: 1X";
                    await _pipeline!.Rate_SetAsync(1.0);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error setting speed: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the bt stop clicked event.
        /// </summary>
        private async void btStop_Clicked(object? sender, EventArgs e)
        {
            try
            {
                await StopAllAsync();

                btSpeed.Text = "SPEED: 1X";
                btPlayPause.Text = "PLAY";
                slSeeking.Value = 0;
                lbDuration.Text = "00:00:00";
                lbPosition.Text = "00:00:00";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error stopping playback: {ex.Message}");
            }
        }
    }
}
