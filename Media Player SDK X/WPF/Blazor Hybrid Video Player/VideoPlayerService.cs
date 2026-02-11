using System;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.UI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types;

namespace Video_Preview_Blazor_Hybrid
{
    /// <summary>
    /// Event args for frame captured events.
    /// </summary>
    public class FrameCapturedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the JPEG frame data.
        /// </summary>
        public byte[] Frame { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrameCapturedEventArgs"/> class.
        /// </summary>
        public FrameCapturedEventArgs(byte[] frame)
        {
            Frame = frame;
        }
    }

    /// <summary>
    /// Event args for player state changed events.
    /// </summary>
    public class PlayerStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets a value indicating whether the player is playing.
        /// </summary>
        public bool IsPlaying { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerStateChangedEventArgs"/> class.
        /// </summary>
        public PlayerStateChangedEventArgs(bool isPlaying)
        {
            IsPlaying = isPlaying;
        }
    }

    public class VideoPlayerService : IDisposable
    {
        /// <summary>
        /// The media player instance.
        /// </summary>
        private MediaPlayerCoreX _core;

        /// <summary>
        /// The playing flag.
        /// </summary>
        private bool _isPlaying;

        /// <summary>
        /// The running flag.
        /// </summary>
        private bool _isRunning;

        /// <summary>
        /// The video duration.
        /// </summary>
        private TimeSpan _duration;

        /// <summary>
        /// The cancellation token source.
        /// </summary>
        private CancellationTokenSource _cts;

        /// <summary>
        /// The source settings.
        /// </summary>
        private UniversalSourceSettings _sourceSettings;

        /// <summary>
        /// The video view.
        /// </summary>
        private JPEGCallbackVideoView _videoView;

        /// <summary>
        /// Occurs when a frame is captured.
        /// </summary>
        public event EventHandler<FrameCapturedEventArgs> FrameCaptured;

        /// <summary>
        /// Occurs when the player state changes.
        /// </summary>
        public event EventHandler<PlayerStateChangedEventArgs> PlayerStateChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoPlayerService"/> class.
        /// </summary>
        public VideoPlayerService()
        {
            _cts = new CancellationTokenSource();
        }

        /// <summary>
        /// Initialize player async.
        /// </summary>
        public async Task<bool> InitializePlayerAsync(string filename)
        {
            try
            {
                _videoView = new JPEGCallbackVideoView();
                _videoView.OnJPEGFrame += _videoView_OnJPEGFrame;

                _core = new MediaPlayerCoreX(_videoView);
                _core.Audio_Play = false;
                _core.OnStart += _core_OnStart;
                _core.OnStop += _core_OnStop;

                _sourceSettings = await UniversalSourceSettings.CreateAsync(filename);
                var info = _sourceSettings.GetInfo();
                _duration = info.Container.Duration;

                if (_duration.TotalSeconds == 0 && info.VideoStreams.Count > 0)
                {
                    var videoInfo = info.VideoStreams[0];
                    _duration = videoInfo.Duration;
                }

                if (_duration.TotalSeconds == 0 && info.AudioStreams.Count > 0)
                {
                    var audioInfo = info.AudioStreams[0];
                    _duration = audioInfo.Duration;
                }

                await _core.OpenAsync(_sourceSettings);

                _isRunning = true;

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to initialize camera: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Get video size.
        /// </summary>
        public (int, int) GetVideoSize()
        {
            if (_core != null)
            {
                var info = _sourceSettings.GetInfo();
                if (info.VideoStreams.Count > 0)
                {
                    var videoInfo = info.VideoStreams[0];
                    return (videoInfo.Width, videoInfo.Height);
                }
            }

            return (0, 0);
        }

        /// <summary>
        /// Core on stop.
        /// </summary>
        private void _core_OnStop(object sender, VisioForge.Core.Types.Events.StopEventArgs e)
        {
            _isPlaying = false;
            PlayerStateChanged?.Invoke(this, new PlayerStateChangedEventArgs(_isPlaying));
        }

        /// <summary>
        /// Handles the core on start event.
        /// </summary>
        private void _core_OnStart(object sender, EventArgs e)
        {
            _isPlaying = true;
            PlayerStateChanged?.Invoke(this, new PlayerStateChangedEventArgs(_isPlaying));
        }

        /// <summary>
        /// Video view on jpeg frame.
        /// </summary>
        private void _videoView_OnJPEGFrame(object sender, byte[] frame)
        {
            if (frame == null)
                return;

            if (_isRunning && !_cts.Token.IsCancellationRequested)
            {
                // Notify UI
                FrameCaptured?.Invoke(this, new FrameCapturedEventArgs(frame));
            }
        }

        /// <summary>
        /// Stop camera.
        /// </summary>
        public void StopCamera()
        {
            _isRunning = false;
            _cts.Cancel();

            _core?.Stop();
            _core?.Dispose();
            _core = null;
        }

        // Get the total duration of the media
        /// <summary>
        /// Get duration async.
        /// </summary>
        public Task<double> GetDurationAsync()
        {
            if (_core != null)
            {
                return Task.FromResult(_duration.TotalSeconds);
            }

            return Task.FromResult(0.0);
        }

        // Get the current playback position
        /// <summary>
        /// Get current position async.
        /// </summary>
        public async Task<double> GetCurrentPositionAsync()
        {
            if (_core != null)
            {
                return (await _core.Position_GetAsync()).TotalSeconds;
            }

            return 0.0;
        }

        // Seek to a specific position
        /// <summary>
        /// Seek async.
        /// </summary>
        public async Task<bool> SeekAsync(double positionInSeconds)
        {
            if (_core != null)
            {
                try
                {
                    await _core.Position_SetAsync(TimeSpan.FromSeconds(positionInSeconds));
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Seek failed: {ex.Message}");
                    return false;
                }
            }

            return false;
        }

        // Play the media
        /// <summary>
        /// Play async.
        /// </summary>
        public async Task<bool> PlayAsync()
        {
            if (_core != null)
            {
                if (_core.State == PlaybackState.Pause)
                {
                    await _core.ResumeAsync();
                }
                else
                {
                    await _core.PlayAsync();
                }

                _isPlaying = true;

                return true;
            }

            return false;
        }

        // Pause the media
        /// <summary>
        /// Pause async.
        /// </summary>
        public async Task<bool> PauseAsync()
        {
            if (_core != null)
            {
                await _core.PauseAsync();
                _isPlaying = false;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            StopCamera();
            _cts.Dispose();
        }
    }
}
