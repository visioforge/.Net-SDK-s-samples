using VisioForge.Core.UI.MAUI;
using System.Diagnostics;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using System.Globalization;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.UI.Skins;
using VisioForge.Core.Types;
using Microsoft.Maui.Storage;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioRenderers;

#if ANDROID
using Android.Runtime;
#endif

namespace Simple_Player_MAUI
{
    public partial class MainPage : ContentPage
    {
        private MediaPlayerCoreX _player;

        private string _filename;

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

        private async void MainPage_Loaded(object sender, EventArgs e)
        {
            IVideoView vv;
#if __MACCATALYST__
            vv = videoView;
#else
            vv = videoView.GetVideoView();
#endif

            _player = new MediaPlayerCoreX(vv);

            _player.OnError += _player_OnError;
            _player.OnStart += _player_OnStart;
            _player.OnStop += _player_OnStop;
            
#if !__IOS__ || __MACCATALYST__
            var audioOutputs = await _player.Audio_OutputDevicesAsync();
            if (audioOutputs.Length > 0)
            {
                _player.Audio_OutputDevice = new AudioRendererSettings(audioOutputs[0]);
            }            
#endif

            Window.Destroying += Window_Destroying;
        }
        
        private async void _player_OnStop(object sender, StopEventArgs e)
        {
            await StopAllAsync();
            
            // update UI controls using invoke
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                btSpeed.Text = "SPEED: 1X";
                btPlayPause.Text = "PLAY";
                slSeeking.Value = 0;
                lbDuration.Text = "00:00:00";
                lbPosition.Text = "00:00:00";
            });
        }

        private void _player_OnStart(object sender, EventArgs e)
        {
            try
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    if (_player == null)
                    {
                        return;
                    }

                    slSeeking.Maximum = (await _player.DurationAsync()).TotalMilliseconds;
                });
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }                      
        }

        private void Window_Destroying(object sender, EventArgs e)
        {
            if (_player != null)
            {
                _player.OnError -= _player_OnError;
                _player.Stop();

                _player.Dispose();
                _player = null;
            }

            VisioForgeX.DestroySDK();
        }

        private void _player_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private async Task StopAllAsync()
        {
            if (_player == null)
            {
                return;
            }

            _tmPosition.Stop();

            if (_player != null)
            {
                await _player.StopAsync();
            }
        }

        /// <summary>
        /// Handles the Elapsed event of the tmPosition control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private async void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_player == null)
            {
                return;
            }

            var pos = await _player.Position_GetAsync();
            var progress = (int)pos.TotalMilliseconds;

            try
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    if (_player == null)
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
                    lbDuration.Text = $"{_player.Duration().ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";

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
            if (!_isTimerUpdate && _player != null)
            {
                await _player.Position_SetAsync(TimeSpan.FromMilliseconds(e.NewValue));
            }
        }

        private void slVolume_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (_player != null)
            {
                _player.Audio_OutputDevice_Volume = e.NewValue / 100.0;
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
            catch
            {
                // The user canceled or something went wrong
            }
        }

        private async void btPlayPause_Clicked(object sender, EventArgs e)
        {
            if (_player == null || string.IsNullOrEmpty(_filename))
            {
                return;
            }

            switch (_player.State)
            {
                case PlaybackState.Play:
                    {
                        await _player.PauseAsync();

                        btPlayPause.Text = "PLAY";
                    }

                    break;
                case PlaybackState.Pause:
                    {
                        await _player.ResumeAsync();

                        btPlayPause.Text = "PAUSE";
                    }

                    break;
                case PlaybackState.Free:
                    {
                        if (_player.State == PlaybackState.Play || _player.State == PlaybackState.Pause)
                        {
                            return;
                        }

                        await _player.OpenAsync(await UniversalSourceSettings.CreateAsync(
                            new Uri(_filename))
                            );
                        await _player.PlayAsync();

                        _tmPosition.Start();

                        btPlayPause.Text = "PAUSE";
                    }

                    break;
                default:
                    break;
            }
        }

        private async void btSpeed_Clicked(object sender, EventArgs e)
        {         
            if (btSpeed.Text == "SPEED: 1X")
            {
                // set 2x
                btSpeed.Text = "SPEED: 2X";
                await _player.Rate_SetAsync(2.0);
            }
            else if (btSpeed.Text == "SPEED: 2X")
            {
                // set 0.5x
                btSpeed.Text = "SPEED: 0.5X";
                await _player.Rate_SetAsync(0.5);
            }
            else if (btSpeed.Text == "SPEED: 0.5X")
            {
                // set 1x
                btSpeed.Text = "SPEED: 1X";
                await _player.Rate_SetAsync(1.0);
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