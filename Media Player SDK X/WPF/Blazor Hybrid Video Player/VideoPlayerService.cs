using System;
using System.Collections.Generic;
using System.IO;

using VisioForge.Core;

using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.UI;
using System.Windows.Media;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types;

namespace Video_Preview_Blazor_Hybrid
{
    public class VideoPlayerService : IDisposable
    {
        private MediaPlayerCoreX _core;

        private bool _isPlaying;

        private bool _isRunning;

        private TimeSpan _duration;

        private CancellationTokenSource _cts;

        private UniversalSourceSettings _sourceSettings;

        private JPEGCallbackVideoView _videoView;

        public event Action<byte[]> FrameCaptured;

        public event Action<bool> PlayerStateChanged;

        public VideoPlayerService()
        {
            _cts = new CancellationTokenSource();
        }

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
                              
                //await _core.PlayAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to initialize camera: {ex.Message}");
                return false;
            }
        }

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

        private void _core_OnStop(object sender, VisioForge.Core.Types.Events.StopEventArgs e)
        {
            _isPlaying = false;
            PlayerStateChanged?.Invoke(_isPlaying);
        }

        private async void _core_OnStart(object sender, EventArgs e)
        {
            _isPlaying = true;
            PlayerStateChanged?.Invoke(_isPlaying);
        }

        private void _videoView_OnJPEGFrame(object sender, byte[] frame)
        {
            if (frame == null)
                return;

            if (_isRunning && !_cts.Token.IsCancellationRequested)
            {
                // Notify UI
                FrameCaptured?.Invoke(frame);
            }
        }

        public void StopCamera()
        {
            _isRunning = false;
            _cts.Cancel();

            _core?.Stop();
            _core?.Dispose();
            _core = null;
        }

        // Get the total duration of the media
        public Task<double> GetDurationAsync()
        {
            if (_core != null)
            {
                return Task.FromResult(_duration.TotalSeconds);
            }

            return Task.FromResult(0.0);
        }

        // Get the current playback position
        public async Task<double> GetCurrentPositionAsync()
        {
            if (_core != null)
            {
                return (await _core.Position_GetAsync()).TotalSeconds;
            }

            return 0.0;
        }

        // Seek to a specific position
        public async Task<bool> SeekAsync(double positionInSeconds)
        {
            if (_core != null)
            {
                try
                {
                    await _core.Position_SetAsync(TimeSpan.FromSeconds(positionInSeconds));
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        // Play the media
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

        public void Dispose()
        {
            StopCamera();
            _cts.Dispose();
        }
    }
}
