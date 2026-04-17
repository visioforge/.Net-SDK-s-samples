using System.Diagnostics;
using System.Globalization;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.OpenGL;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.OpenGL;

namespace Simple_Player_MB_MAUI
{
    public partial class MainPage : ContentPage
    {
        private MediaBlocksPipeline _pipeline;

        private UniversalSourceBlock _source;

        private MediaBlock _videoRenderer;

        private GLEquirectangularViewBlock _processor;

        private AudioRendererBlock _audioRenderer;

        private string _filename;

        private double _viewX;

        private double _viewY;

        private IVRVideoControl _vrControl;

        /// <summary>
        /// The seeking flag.
        /// </summary>
        private volatile bool _isTimerUpdate;

        /// <summary>
        /// The position timer.
        /// </summary>
        private System.Timers.Timer _tmPosition = new System.Timers.Timer(100);

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

            var sourceSettings = await UniversalSourceSettings.CreateAsync(new Uri(_filename));
            _source = new UniversalSourceBlock(sourceSettings);

            var videoInfo = sourceSettings.GetInfo().GetVideoInfo();
            var audioStream = sourceSettings.GetInfo().AudioStreams.Count > 0;

            var vv = videoView.GetVideoView();
            _videoRenderer = new VideoRendererBlock(_pipeline, vv) { IsSync = true };

            if (audioStream)
            {
                _audioRenderer = new AudioRendererBlock();
            }

#if __IOS__ || __MACOS__ || __MACCATALYST__
            // We have equi-rectangular view for iOS and macOS inside the VideoView control.
            _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);
#else
                _processor =
 new GLEquirectangularViewBlock(new GLEquirectangularViewSettings(videoInfo.Width, videoInfo.Height));

                var glUpload = new GLUploadBlock();
                var glDownload = new GLDownloadBlock();
                
                _pipeline.Connect(_source.VideoOutput, glUpload.Input);
                _pipeline.Connect(glUpload.Output, _processor.Input);
                _pipeline.Connect(_processor.Output, glDownload.Input);
                _pipeline.Connect(glDownload.Output, _videoRenderer.Input);
#endif

            if (audioStream)
            {
                _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
            }

            // Configure VR control
            _vrControl = _pipeline.GetVRVideoControl();
            if (_vrControl != null)
            {
                _vrControl.Mode = VRMode.Equirectangular;
            }
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
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    btPlayPause.Text = "PLAY";
                    slSeeking.Value = 0;
                    lbDuration.Text = "00:00:00";
                    lbPosition.Text = "00:00:00";
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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
        private void _player_OnStart(object? sender, EventArgs e)
        {
            try
            {
                MainThread.BeginInvokeOnMainThread(async () =>
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
                System.Diagnostics.Debug.WriteLine(exception);
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
                    _pipeline = null;
                }

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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
                await _pipeline.StopAsync(force: true);
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
            try
            {
                if (_pipeline == null)
                {
                    return;
                }

                var pos = await _pipeline.Position_GetAsync();
                var progress = (int)pos.TotalMilliseconds;

                try
                {
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        if (_pipeline == null)
                        {
                            return;
                        }

                        _isTimerUpdate = true;

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
                        lbDuration.Text =
                            $"{(await _pipeline.DurationAsync()).ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";

                        _isTimerUpdate = false;
                    });
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Sl volume value changed.
        /// </summary>
        private void slVolume_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            if (_pipeline != null)
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

                try
                {
                    var result = await FilePicker.Default.PickAsync();
                    if (result != null)
                    {
                        _filename = result.FullPath;
                        lbFilename.Text = _filename;
                        lbFilename.IsVisible = true;
                    }
                }
                catch
                {
                    // The user canceled or something went wrong
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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

                    await _pipeline.StartAsync();

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
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt stop clicked event.
        /// </summary>
        private async void btStop_Clicked(object? sender, EventArgs e)
        {
            try
            {
                //var dot = _pipeline.Debug_GetPipeline();

                await StopAllAsync();

                btPlayPause.Text = "PLAY";
                slSeeking.Value = 0;
                lbDuration.Text = "00:00:00";
                lbPosition.Text = "00:00:00";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// On pan updated.
        /// </summary>
        private void OnPanUpdated(object? sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    // Reset or initialize tracking
                    _viewX = 0;
                    _viewY = 0;
                    break;

                case GestureStatus.Running:
                    // Update tracking of finger position
                    if (_vrControl == null)
                    {
                        return;
                    }

                    // Update the position
                    _vrControl.Yaw += (float)(e.TotalX - _viewX) * 2;
                    _viewX = e.TotalX;

                    _vrControl.Pitch += (float)(e.TotalY - _viewY) * 2;
                    _viewY = e.TotalY;

                    break;

                case GestureStatus.Completed:
                    // Handle the completion of the gesture if needed
                    _viewX = 0;
                    _viewY = 0;
                    break;
            }
        }
    }
}
