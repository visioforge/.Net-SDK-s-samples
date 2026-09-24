using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.OpenCV;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.OpenCV;
using VisioForge.Core.Types.X.Sources;

namespace Video_Stabilization_Camera_Demo
{
    /// <summary>
    /// Stabilizes a live camera with a low-level MediaBlocksPipeline:
    /// SystemVideoSourceBlock -> VideoStabilizationBlock -> VideoRendererBlock.
    /// The stabilizer is retuned on the fly with ApplySettings().
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;
        private SystemVideoSourceBlock _videoSource;
        private VideoStabilizationBlock _stab;
        private VideoStabilizationSettings _settings;
        private VideoRendererBlock _videoRenderer;

        private VideoCaptureDeviceInfo[] _cameras;
        private volatile bool _isClosing;

        // The in-flight StartAsync, so a window close can wait for it instead of disposing the pipeline underneath it.
        private Task<bool> _startTask;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Log(string text)
        {
            if (_isClosing) return;

            // Pipeline events fire on the GStreamer thread; post to the UI without blocking.
            _ = Dispatcher.BeginInvoke(new Action(() => mmLog.AppendText(text + Environment.NewLine)));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();

                // The registry build takes a while on a fresh machine - the user may have closed the window by now.
                if (_isClosing) return;

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;
                _pipeline.OnStop += Pipeline_OnStop;

                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
                if (_isClosing) return;

                foreach (var camera in _cameras ?? Array.Empty<VideoCaptureDeviceInfo>())
                {
                    cbCamera.Items.Add(camera.DisplayName);
                }

                if (cbCamera.Items.Count > 0)
                {
                    cbCamera.SelectedIndex = 0;
                }

                Log($"SDK v{MediaBlocksPipeline.SDK_Version} ready.");

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

        // The camera and its format are read when the graph is built, so they are frozen while it runs.
        private void SetTuningEnabled(bool enabled)
        {
            chkEnabled.IsEnabled = enabled;
            slSmoothing.IsEnabled = enabled;
            slCropRatio.IsEnabled = enabled;

            cbCamera.IsEnabled = !enabled;
            cbFormat.IsEnabled = !enabled;
        }

        // ---- live parameter changes ----
        // The vfdeshake element re-reads its properties every frame, so ApplySettings() retunes the running
        // element without rebuilding the pipeline. Each handler no-ops until Start.

        private void ApplyLiveSettings()
        {
            if (!IsInitialized)
            {
                return;
            }

            UpdateSettingsLabels();

            if (_settings == null)
            {
                return;
            }

            _settings.Enabled = chkEnabled.IsChecked == true;
            _settings.SmoothingRadius = (int)slSmoothing.Value;
            _settings.CropRatio = Math.Round(slCropRatio.Value, 2);
            _stab?.ApplySettings();
        }

        private void chkEnabled_Changed(object sender, RoutedEventArgs e) => ApplyLiveSettings();

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) => ApplyLiveSettings();

        private void Pipeline_OnError(object sender, ErrorsEventArgs e) => Log(e.Message);

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            _ = Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_isClosing) return;

                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
                SetTuningEnabled(false);
            }));
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btStart.IsEnabled = false;

                if (_pipeline == null)
                {
                    MessageBox.Show(this, "SDK failed to initialize.");
                    btStart.IsEnabled = true;
                    return;
                }

                if (_cameras == null || cbCamera.SelectedIndex < 0 || cbCamera.SelectedIndex >= _cameras.Length)
                {
                    MessageBox.Show(this, "No camera devices were found.");
                    btStart.IsEnabled = true;
                    return;
                }

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

                mmLog.Clear();

                // Rebuild the graph from scratch for every session.
                try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); } catch (Exception ex) { Debug.WriteLine(ex); }
                CleanupBlocks();

                var formatItem = formats[formatIndex];
                var sourceSettings = new VideoCaptureDeviceSourceSettings(device)
                {
                    Format = formatItem.ToFormat()
                };

                if (formatItem.FrameRateList.Count > 0)
                {
                    sourceSettings.Format.FrameRate = formatItem.FrameRateList[0];
                }

                _videoSource = new SystemVideoSourceBlock(sourceSettings);

                _settings = new VideoStabilizationSettings
                {
                    Enabled = chkEnabled.IsChecked == true,
                    SmoothingRadius = (int)slSmoothing.Value,
                    CropRatio = Math.Round(slCropRatio.Value, 2),
                };
                _stab = new VideoStabilizationBlock(_settings);

                // A live camera drives the clock itself; an unsynced renderer shows every frame as it arrives.
                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = false };

                _pipeline.Connect(_videoSource.Output, _stab.Input);
                _pipeline.Connect(_stab.Output, _videoRenderer.Input);

                // Publish the task so a window close waits for the camera to come up instead of racing it.
                // StartAsync returns false (it does not throw) when a block fails to build - e.g. the OpenCV
                // redist is missing - so a fake "running" UI must not be shown.
                _startTask = _pipeline.StartAsync();
                var started = await _startTask;
                _startTask = null;

                if (_isClosing) return;

                if (!started)
                {
                    Log("Failed to start the pipeline.");
                    try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); } catch (Exception ex) { Debug.WriteLine(ex); }
                    CleanupBlocks();
                    btStart.IsEnabled = true;
                    btStop.IsEnabled = false;
                    SetTuningEnabled(false);
                    return;
                }

                btStart.IsEnabled = false;
                btStop.IsEnabled = true;
                SetTuningEnabled(true);
            }
            catch (Exception ex)
            {
                Log("start error: " + ex.Message);

                // async void: the recovery itself must not throw.
                try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); } catch (Exception stopEx) { Debug.WriteLine(stopEx); }
                CleanupBlocks();

                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
                SetTuningEnabled(false);
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btStop.IsEnabled = false;
                SetTuningEnabled(false);

                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    _pipeline.ClearBlocks();
                }

                CleanupBlocks();
                VideoView1.CallRefresh();
            }
            catch (Exception ex)
            {
                Log("stop error: " + ex.Message);
            }
            finally
            {
                btStart.IsEnabled = true;
            }
        }

        // This demo builds the graph itself, so it also owns and disposes the blocks.
        private void CleanupBlocks()
        {
            _stab?.Dispose(); _stab = null;
            _settings = null;
            _videoSource?.Dispose(); _videoSource = null;
            _videoRenderer?.Dispose(); _videoRenderer = null;
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isClosing) return;

            // Cancel the close, tear the pipeline down asynchronously, then close for real.
            e.Cancel = true;
            _isClosing = true;
            IsEnabled = false;

            try
            {
                // Never tear the pipeline down under a Start that is still bringing the camera up.
                if (_startTask != null) { await _startTask; }

                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    _pipeline.OnError -= Pipeline_OnError;
                    _pipeline.OnStop -= Pipeline_OnStop;
                    await _pipeline.DisposeAsync();
                    _pipeline = null;
                }

                CleanupBlocks();
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            finally
            {
                // Releases the SDK's native resources - GStreamer, its GLib main loop and the devices it holds.
                try { VisioForgeX.DestroySDK(); } catch (Exception ex) { Debug.WriteLine(ex); }
                _ = Dispatcher.BeginInvoke(new Action(() => Close()));
            }
        }
    }
}
