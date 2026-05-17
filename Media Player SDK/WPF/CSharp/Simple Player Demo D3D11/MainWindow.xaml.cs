using Microsoft.Win32;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using VisioForge.Core.MediaPlayer;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;

namespace Simple_Player_Demo_D3D11
{
    /// <summary>
    /// Demo for the D3D11 composable WPF renderer driven by the DirectShow-backed
    /// MediaPlayerCore. The renderer keeps each video frame GPU-resident from
    /// decode to display and composes natively with the WPF visual tree — the
    /// overlay banner, opacity, and rotation toggles in this window prove that
    /// the video surface plays under and around regular WPF visuals.
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Timers.Timer _timer;
        private volatile bool _timerFlag;
        private MediaPlayerCore _player;
        private volatile bool _isClosing;

        // Re-entry guard for btStart_Click. Multiple rapid clicks would
        // otherwise interleave DestroyEngineAsync + CreateEngine + PlayAsync
        // and end up with overlapping engines / a torn _player reference.
        private bool _starting;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>Window loaded handler.</summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += Timer_Elapsed;

            CreateEngine();

            foreach (var device in _player.Audio_OutputDevices())
            {
                cbAudioOutput.Items.Add(device);
            }

            if (cbAudioOutput.Items.Count > 0)
            {
                cbAudioOutput.SelectedIndex = 0;
            }

            Log($"Press Start to play. Renderer: D3D11Composable.");
        }

        private void CreateEngine()
        {
            _player = new MediaPlayerCore(VideoView1);
            _player.OnError += Player_OnError;
            _player.OnStop += Player_OnStop;

            _player.Debug_Dir = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "VisioForge");
            _player.Debug_Mode = cbDebugMode.IsChecked == true;

            // Switch the WPF VideoView to its GPU-resident composable renderer.
            // The view auto-configures the engine to deliver frames through the
            // FrameCallback channel so they land in the D3D11 shared texture.
            VideoView1.UseD3D11ComposableRenderer();
        }

        private async Task DestroyEngineAsync()
        {
            if (_player != null)
            {
                // Unsubscribe before delay+dispose so a late OnError/OnStop from
                // the DirectShow filter graph during teardown does not reach a
                // disposed handler. The delay drains in-flight callbacks; tune
                // for engine. Sibling X demo uses 300 ms (lighter X engine).
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                await Task.Delay(500);
                await _player.DisposeAsync();
                _player = null;
            }
        }

        private void Player_OnError(object sender, ErrorsEventArgs e)
        {
            // Mirror the Player_OnStop guard: a late OnError emitted during
            // teardown can race the dispatcher shutdown and crash on
            // Dispatcher.Invoke. Drop the log once the window is closing.
            if (_isClosing) return;
            Dispatcher.Invoke(() => Log(e.Message));
        }

        private void Player_OnStop(object sender, StopEventArgs e)
        {
            if (_isClosing) return;
            Dispatcher.Invoke(() => tbTimeline.Value = 0);
        }

        private async void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timerFlag = true;

            if (_player == null) return;

            try
            {
                var position = await _player.Position_Get_TimeAsync();
                var duration = await _player.Duration_TimeAsync();

                Dispatcher.Invoke(() =>
                {
                    tbTimeline.Maximum = (int)duration.TotalSeconds;
                    lbTime.Text = position.ToString("hh\\:mm\\:ss") + " | " + duration.ToString("hh\\:mm\\:ss");
                    if (tbTimeline.Maximum >= position.TotalSeconds)
                    {
                        tbTimeline.Value = (int)position.TotalSeconds;
                    }
                });
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(() => Log("timer: " + ex.Message));
            }
            finally
            {
                _timerFlag = false;
            }
        }

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                edFilename.Text = dialog.FileName;
            }
        }

        private async void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_timerFlag && _player != null)
            {
                await _player.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (_isClosing || _starting) return;
            _starting = true;
            btStart.IsEnabled = false;
            try
            {
                edLog.Clear();
                await DestroyEngineAsync();
                CreateEngine();

                _player.Audio_OutputDevice = cbAudioOutput.Text;
                _player.Playlist_Clear();
                _player.Playlist_Add(edFilename.Text);

                await _player.PlayAsync();

                var provider = VideoView1.GetSurfaceProvider();
                Log(provider == null
                    ? "Note: SurfaceProvider is null — D3D11Composable not active."
                    : $"D3D11Composable active. Surface {provider.SurfaceWidth}x{provider.SurfaceHeight}");

                _timer.Start();
            }
            finally
            {
                _starting = false;
                btStart.IsEnabled = true;
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            if (_player != null)
            {
                await _player.StopAsync();
                await DestroyEngineAsync();
            }

            tbTimeline.Value = 0;
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            if (_player != null) await _player.PauseAsync();
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            if (_player != null) await _player.ResumeAsync();
        }

        private void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_player != null)
            {
                _player.Audio_OutputDevice_Volume_Set(0, (int)tbVolume.Value);
            }
        }

        // Visual proof that D3D11Composable composes natively with WPF: a rotation
        // transform and an opacity change apply to the live video instantly.

        private void cbRotate_Checked(object sender, RoutedEventArgs e)
        {
            VideoView1.RenderTransformOrigin = new Point(0.5, 0.5);
            VideoView1.RenderTransform = cbRotate.IsChecked == true
                ? new RotateTransform(10)
                : Transform.Identity;
        }

        private void cbOpacity_Checked(object sender, RoutedEventArgs e)
        {
            VideoView1.Opacity = cbOpacity.IsChecked == true ? 0.7 : 1.0;
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // async void Window_Closing returns to the WPF Close pump at the
            // first await, so the window tears down BEFORE DestroyEngineAsync
            // finishes — leaving the engine alive and racing the dispatcher
            // shutdown. Pattern: short-circuit the second close, cancel the
            // first close, drive teardown to completion, then call Close()
            // synchronously. The synchronous Close re-enters this handler with
            // _isClosing == true and falls through.
            if (_isClosing) return;

            e.Cancel = true;
            _isClosing = true;

            // _timer is created in Window_Loaded; null-conditional matches the
            // sibling X demo and tolerates a window closing before Loaded fired.
            _timer?.Stop();
            await DestroyEngineAsync();

            // Defer the re-close to a fresh dispatcher tick so WPF's
            // closing pipeline (which produced this event) has fully
            // unwound before we re-enter InternalClose. Calling Close()
            // directly from the async-continuation hit VerifyNotClosing's
            // "Window is closing" guard on .NET 10 WPF and threw
            // InvalidOperationException. _isClosing is already set, so
            // the re-entered Window_Closing short-circuits above and the
            // close proceeds normally.
            Dispatcher.BeginInvoke(new Action(Close));
        }

        private void Log(string msg)
        {
            edLog.AppendText(msg + Environment.NewLine);
            edLog.ScrollToEnd();
        }
    }
}
