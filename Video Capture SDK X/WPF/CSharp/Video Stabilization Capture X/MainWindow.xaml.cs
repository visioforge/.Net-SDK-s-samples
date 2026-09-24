using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks.OpenCV;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.OpenCV;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace Video_Stabilization_Capture_X
{
    /// <summary>
    /// Stabilizes a live camera: a VideoStabilizationBlock is inserted into VideoCaptureCoreX with
    /// Video_Processing_AddBlock, and its settings are retuned on the fly with ApplySettings().
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCaptureCoreX _core;
        private VideoStabilizationBlock _stabilizer;
        private VideoCaptureDeviceInfo[] _cameras;
        private volatile bool _isClosing;

        // The in-flight StartAsync, so a window close can wait for it instead of disposing the engine underneath it.
        private Task<bool> _startTask;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Log(string text)
        {
            if (_isClosing)
            {
                return;
            }

            // Engine events fire on the pipeline thread; post non-blocking to the UI.
            _ = Dispatcher.BeginInvoke(new Action(() => mmLog.AppendText(text + Environment.NewLine)));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();

                // The registry build takes a while on a fresh machine - the user may have closed the window by now.
                if (_isClosing)
                {
                    return;
                }

                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
                foreach (var camera in _cameras ?? Array.Empty<VideoCaptureDeviceInfo>())
                {
                    cbCamera.Items.Add(camera.DisplayName);
                }

                if (cbCamera.Items.Count > 0)
                {
                    cbCamera.SelectedIndex = 0;
                }

                Log($"SDK v{VideoCaptureCoreX.SDK_Version} ready.");

                // The stabilizer needs the OpenCV redistributable (vfdeshake element).
                if (!VideoStabilizationBlock.IsAvailable())
                {
                    Log("WARNING: video stabilization is not available. Add the VisioForge.CrossPlatform.OpenCV.Windows.x64 package.");
                }
            }
            catch (Exception ex)
            {
                Log("load error: " + ex.Message);
            }
            finally
            {
                // Always re-enable, even if device enumeration failed - unless the window is already closing.
                if (!_isClosing)
                {
                    IsEnabled = true;
                    UpdateSettingsLabels();
                }
            }
        }

        private void cbCamera_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsInitialized || _cameras == null || cbCamera.SelectedIndex < 0 || cbCamera.SelectedIndex >= _cameras.Length)
            {
                return;
            }

            cbFormat.Items.Clear();
            foreach (var format in _cameras[cbCamera.SelectedIndex].VideoFormats ?? Enumerable.Empty<VideoCaptureDeviceFormatInfo>())
            {
                cbFormat.Items.Add(format.Name);
            }

            if (cbFormat.Items.Count > 0)
            {
                cbFormat.SelectedIndex = 0;
            }
        }

        private void UpdateSettingsLabels()
        {
            lbSmoothing.Text = string.Format(CultureInfo.CurrentCulture, "Smoothing radius: {0} frames", (int)slSmoothing.Value);
            lbCropRatio.Text = string.Format(CultureInfo.CurrentCulture, "Crop ratio: {0:F2}", slCropRatio.Value);
        }

        // Pushes the UI values into the running vfdeshake element (it re-reads its properties every frame).
        private void ApplyLiveSettings()
        {
            if (!IsInitialized)
            {
                return;
            }

            UpdateSettingsLabels();

            var stabilizer = _stabilizer;
            if (stabilizer?.Settings == null)
            {
                return;
            }

            stabilizer.Settings.Enabled = chkEnabled.IsChecked == true;
            stabilizer.Settings.SmoothingRadius = (int)slSmoothing.Value;
            stabilizer.Settings.CropRatio = slCropRatio.Value;
            stabilizer.ApplySettings();
        }

        private void chkEnabled_Changed(object sender, RoutedEventArgs e) => ApplyLiveSettings();

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) => ApplyLiveSettings();

        // Disposes any existing engine and builds a fresh VideoCaptureCoreX bound to the same VideoView.
        private async Task RecreateEngineAsync()
        {
            // The previous engine disposes the block; drop the reference before the teardown await.
            _stabilizer = null;
            SetTuningEnabled(false);

            if (_core != null)
            {
                // Drop the reference before the awaits: if the teardown throws, nothing points at a half-disposed engine.
                var core = _core;
                _core = null;

                core.OnError -= Core_OnError;
                core.OnStop -= Core_OnStop;
                await core.StopAsync();
                await core.DisposeAsync();
            }

            if (_isClosing)
            {
                return;
            }

            _core = new VideoCaptureCoreX(VideoView1);
            _core.OnError += Core_OnError;
            _core.OnStop += Core_OnStop;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (_cameras == null || _cameras.Length == 0 || cbCamera.SelectedIndex < 0 || cbCamera.SelectedIndex >= _cameras.Length)
            {
                MessageBox.Show(this, "No camera devices were found.");
                return;
            }

            try
            {
                btStart.IsEnabled = false;
                mmLog.Clear();

                var device = _cameras[cbCamera.SelectedIndex];

                // Select the format by position: its name ("1920x1080 NV12") is not unique across frame rates.
                var formats = device.VideoFormats;
                var formatIndex = cbFormat.SelectedIndex;
                if (formats == null || formatIndex < 0 || formatIndex >= formats.Count)
                {
                    MessageBox.Show(this, "Select a camera format.");
                    btStart.IsEnabled = true;
                    return;
                }

                var formatItem = formats[formatIndex];

                // Build the engine from scratch for every session.
                await RecreateEngineAsync();
                if (_core == null || _isClosing)
                {
                    btStart.IsEnabled = true;
                    return;
                }

                _core.Video_Source = new VideoCaptureDeviceSourceSettings(device)
                {
                    Format = formatItem.ToFormat()
                };
                _core.Audio_Play = false;

                var settings = new VideoStabilizationSettings
                {
                    Enabled = chkEnabled.IsChecked == true,
                    SmoothingRadius = (int)slSmoothing.Value,
                    CropRatio = slCropRatio.Value,
                };

                _stabilizer = new VideoStabilizationBlock(settings);
                _core.Video_Processing_AddBlock(_stabilizer);

                // Publish the task so a window close waits for the camera to come up instead of racing it.
                _startTask = _core.StartAsync();
                var started = await _startTask;
                _startTask = null;

                // The close path is already tearing things down; do not touch the engine or the UI.
                if (_isClosing)
                {
                    return;
                }

                if (!started)
                {
                    Log("start error: failed to start capture.");
                    await CleanupAfterStopAsync();
                    btStart.IsEnabled = true;
                    return;
                }

                SetTuningEnabled(true);
                btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Log("start error: " + ex.Message);

                // async void: the recovery itself must not throw.
                try { await CleanupAfterStopAsync(); } catch (Exception cleanupEx) { System.Diagnostics.Debug.WriteLine(cleanupEx); }

                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
            }
        }

        // Errors are reported in the log; Stop remains the way out of a broken session.
        private void Core_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private void Core_OnStop(object sender, StopEventArgs e)
        {
            // The engine disposes the inserted block on stop; drop our reference so the next Start re-creates one.
            _ = Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_isClosing)
                {
                    return;
                }

                _stabilizer = null;
                SetTuningEnabled(false);
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
            }));
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            btStop.IsEnabled = false;
            try
            {
                await CleanupAfterStopAsync();
            }
            catch (Exception ex)
            {
                Log("stop error: " + ex.Message);
            }

            btStart.IsEnabled = true;
        }

        // The engine OWNS the inserted block and disposes it during Stop, so drop the reference and freeze the
        // tuning controls before the await.
        private async Task CleanupAfterStopAsync()
        {
            _stabilizer = null;
            SetTuningEnabled(false);

            if (_core != null)
            {
                await _core.StopAsync();
            }
        }

        // The stabilizer is retunable only while a session runs; the camera and its format are read at Start,
        // so they are frozen for the lifetime of the session.
        private void SetTuningEnabled(bool enabled)
        {
            chkEnabled.IsEnabled = enabled;
            slSmoothing.IsEnabled = enabled;
            slCropRatio.IsEnabled = enabled;

            cbCamera.IsEnabled = !enabled;
            cbFormat.IsEnabled = !enabled;
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isClosing)
            {
                return;
            }

            // Cancel the close, tear the engine down asynchronously, then close for real.
            e.Cancel = true;
            _isClosing = true;
            IsEnabled = false;

            // The engine disposes the block during Stop.
            _stabilizer = null;

            try
            {
                // Never tear the engine down under a Start that is still bringing the camera up - let it finish first.
                if (_startTask != null)
                {
                    await _startTask;
                }

                if (_core != null)
                {
                    _core.OnError -= Core_OnError;
                    _core.OnStop -= Core_OnStop;
                    await _core.StopAsync();
                    await _core.DisposeAsync();
                    _core = null;
                }

                VideoView1.CallRefresh();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                // Releases the SDK's native resources - GStreamer, its GLib main loop and the devices it holds.
                try { VisioForgeX.DestroySDK(); } catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex); }
                _ = Dispatcher.BeginInvoke(new Action(() => Close()));
            }
        }
    }
}
