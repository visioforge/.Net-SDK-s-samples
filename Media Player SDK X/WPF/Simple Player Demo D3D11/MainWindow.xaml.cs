using Microsoft.Win32;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using VisioForge.Core;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;

namespace Simple_Player_Demo_D3D11_X
{
    /// <summary>
    /// Demo for the D3D11 composable WPF renderer driven by the GStreamer-backed
    /// MediaPlayerCoreX (X engine). Unlike the DirectShow demo this engine does
    /// not implement IMPVCVECore and pushes frames directly via the
    /// IVideoViewPushFrame contract; the same UseD3D11ComposableRenderer() call
    /// on the VideoView wires the pipeline.
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Timers.Timer _timer;
        private volatile bool _timerFlag;
        private MediaPlayerCoreX _player;
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

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                IsEnabled = true;
                Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

                _timer = new System.Timers.Timer(500);
                _timer.Elapsed += Timer_Elapsed;

                // Activate the D3D11 composable renderer on the VideoView BEFORE
                // attaching the X engine, so the first frame the X pipeline pushes
                // lands in the GPU-shared texture rather than the default
                // WriteableBitmap path.
                VideoView1.UseD3D11ComposableRenderer();

                CreateEngine();

                foreach (var device in await _player.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound))
                {
                    cbAudioOutput.Items.Add(device.Name);
                }

                if (cbAudioOutput.Items.Count > 0)
                {
                    cbAudioOutput.SelectedIndex = 0;
                }

                Log($"D3D11Composable renderer ready. SDK v{MediaPlayerCoreX.SDK_Version}");
            }
            catch (Exception ex)
            {
                Log("load error: " + ex.Message);
            }
        }

        private void CreateEngine()
        {
            _player = new MediaPlayerCoreX(VideoView1);
            _player.OnError += Player_OnError;
            _player.OnStop += Player_OnStop;

            _player.Debug_Dir = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "VisioForge");
            _player.Debug_Mode = cbDebugMode.IsChecked == true;
        }

        private async Task DestroyEngineAsync()
        {
            if (_player != null)
            {
                // Unsubscribe before delay+dispose so a late OnError/OnStop from
                // the GStreamer pipeline during teardown does not reach a
                // disposed handler. The delay drains in-flight callbacks; tune
                // for engine. Sibling DirectShow demo uses 500 ms (heavier
                // DirectShow filter-graph teardown).
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                await Task.Delay(300);
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
            try
            {
                _timerFlag = true;
                if (_player == null) return;

                var position = await _player.Position_GetAsync();
                var duration = await _player.DurationAsync();

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
            try
            {
                if (!_timerFlag && _player != null)
                {
                    await _player.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
                }
            }
            catch (Exception ex)
            {
                Log("seek: " + ex.Message);
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

                // Re-arm the GPU renderer in case the previous engine teardown
                // cleared the view; UseD3D11ComposableRenderer is idempotent.
                VideoView1.UseD3D11ComposableRenderer();

                CreateEngine();

                var audioOutputDevice = (await _player.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound))
                    .First(x => x.Name == cbAudioOutput.Text);
                _player.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);
                _player.Loop = cbLoop.IsChecked == true;

                var source = await UniversalSourceSettingsV2.CreateAsync(new Uri(edFilename.Text));
                await _player.OpenAsync(source);
                await _player.PlayAsync();

                var provider = VideoView1.GetSurfaceProvider();
                Log(provider == null
                    ? "Note: SurfaceProvider is null — D3D11Composable not active."
                    : $"D3D11Composable active. Surface {provider.SurfaceWidth}x{provider.SurfaceHeight}");

                _timer.Start();
            }
            catch (Exception ex)
            {
                Log("start: " + ex.Message);
            }
            finally
            {
                _starting = false;
                btStart.IsEnabled = true;
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _timer.Stop();
                if (_player != null)
                {
                    await _player.StopAsync();
                    await DestroyEngineAsync();
                }
                tbTimeline.Value = 0;
            }
            catch (Exception ex)
            {
                Log("stop: " + ex.Message);
            }
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
                _player.Audio_OutputDevice_Volume = tbVolume.Value / 100.0;
            }
        }

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

            try
            {
                _timer?.Stop();
                await DestroyEngineAsync();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Log("closing: " + ex.Message);
            }

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
