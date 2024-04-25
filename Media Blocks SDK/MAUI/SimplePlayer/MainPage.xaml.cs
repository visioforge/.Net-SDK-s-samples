using System.Diagnostics;
using System.Globalization;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks.AudioRendering;

namespace Simple_Player_MB_MAUI
{
    public partial class MainPage : ContentPage
    {
        private MediaBlocksPipeline _pipeline;

        private UniversalSourceBlock _source;

        private MediaBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private string _filename;

        /// <summary>
        /// The seeking flag.
        /// </summary>
        private volatile bool _isTimerUpdate;

#if __ANDROID__
        private const string DEFAULT_FILENAME = "http://test.visioforge.com/video.mp4";
#else
        private const string DEFAULT_FILENAME = @"c:\samples\!video.mp4";
#endif

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

        private async Task CreateEngineAsync()
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
            }

            _pipeline = new MediaBlocksPipeline(false);

            _pipeline.OnError += _player_OnError;
            _pipeline.OnStart += _player_OnStart;

            _audioRenderer = new AudioRendererBlock();

            _source = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(_filename));

#if __IOS__ && !__MACCATALYST__ || __ANDROID__
            var vv = videoView.Handler.PlatformView;
            _videoRenderer = new VideoRendererBlock(_pipeline, (IVideoView)vv);
#else
            _videoRenderer = new VideoRendererBlock(_pipeline, videoView);
#endif

            _audioRenderer = new AudioRendererBlock();

            _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);
            _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
        }

        private void MainPage_Loaded(object sender, EventArgs e)
        {
            Window.Destroying += Window_Destroying;
        }

        private void _player_OnStart(object sender, EventArgs e)
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

        private async void Window_Destroying(object sender, EventArgs e)
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

        private async void OnStop(object sender, EventArgs e)
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= _player_OnError;
                await _pipeline.StopAsync();
            }
        }

        private void _player_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

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
        private async void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
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
                    lbDuration.Text = $"{(await _pipeline.DurationAsync()).ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";

                    _isTimerUpdate = false;
                });
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        private async void slSeeking_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!_isTimerUpdate && _pipeline != null)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromMilliseconds(e.NewValue));
            }
        }

        private void slVolume_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (_pipeline != null)
            {
                _audioRenderer.Volume = e.NewValue / 100.0;
            }
        }

        private async void btOpen_Clicked(object sender, EventArgs e)
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
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }
        }

        private async void btPlayPause_Clicked(object sender, EventArgs e)
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

        private async void btSpeed_Clicked(object sender, EventArgs e)
        {         
            if (btSpeed.Text == "SPEED: 1X")
            {
                // set 2x
                btSpeed.Text = "SPEED: 2X";
                await _pipeline.Rate_SetAsync(2.0);
            }
            else if (btSpeed.Text == "SPEED: 2X")
            {
                // set 0.5x
                btSpeed.Text = "SPEED: 0.5X";
                await _pipeline.Rate_SetAsync(0.5);
            }
            else if (btSpeed.Text == "SPEED: 0.5X")
            {
                // set 1x
                btSpeed.Text = "SPEED: 1X";
                await _pipeline.Rate_SetAsync(1.0);
            }
        }

        private async void btStop_Clicked(object sender, EventArgs e)
        {
            await StopAllAsync();

            btSpeed.Text = "SPEED: 1X";
            btPlayPause.Text = "PLAY";
        }
    }
}