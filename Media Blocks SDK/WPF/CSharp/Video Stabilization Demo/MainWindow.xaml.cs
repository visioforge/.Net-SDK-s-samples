using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.OpenCV;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.OpenCV;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;

namespace Video_Stabilization_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;
        private VideoRendererBlock _videoRenderer;
        private UniversalSourceBlock _videoSource;
        private VideoStabilizationBlock _stab;
        private VideoStabilizationSettings _settings;
        private TeeBlock _videoTee;
        private H264EncoderBlock _h264Encoder;
        private MP4SinkBlock _mp4Sink;
        private volatile bool _isClosing;

        // The in-flight StartAsync, so a window close can wait for it instead of disposing the pipeline underneath it.
        private Task<bool> _startTask;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Pipeline events fire on the GStreamer thread; post to the UI without blocking.
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            if (_isClosing) return;
            _ = Dispatcher.BeginInvoke(new Action(() => mmLog.Text += e.Message + Environment.NewLine));
        }

        // Fires on Stop and on a natural end of file.
        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            _ = Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_isClosing) return;
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
                SetRecordingControlsEnabled(true);
                SetTuningEnabled(false);
            }));
        }

        // Recording settings are read once when the pipeline is built, so lock them while it runs.
        private void SetRecordingControlsEnabled(bool enabled)
        {
            chkRecord.IsEnabled = enabled;
            edOutputFile.IsEnabled = enabled && chkRecord.IsChecked == true;
            btSelectOutputFile.IsEnabled = edOutputFile.IsEnabled;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                IsEnabled = false;
                try { await VisioForgeX.InitSDKAsync(); }
                finally { IsEnabled = !_isClosing; Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", string.Empty); }

                // The registry build takes a while on a fresh machine - the user may have closed the window by now.
                if (_isClosing) return;

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;
                _pipeline.OnStop += Pipeline_OnStop;
                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                if (!VideoStabilizationBlock.IsAvailable())
                {
                    mmLog.Text += "WARNING: the OpenCV vfdeshake element is not available. " +
                                  "Add the VisioForge.CrossPlatform.OpenCV.Windows.x64 NuGet package." + Environment.NewLine;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
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
                // Never tear the pipeline down under a Start that is still building it - let it finish first.
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

        private void btSelectVideoFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "Video files|*.mp4;*.mkv;*.avi;*.mov;*.webm;*.ts|All files|*.*" };
            if (dlg.ShowDialog() == true) edVideoFile.Text = dlg.FileName;
        }

        // Keep the current lock state: while the pipeline runs the recording choice stays frozen.
        private void chkRecord_Changed(object sender, RoutedEventArgs e) => SetRecordingControlsEnabled(chkRecord.IsEnabled);

        private void btSelectOutputFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog { Filter = "MP4 files|*.mp4", DefaultExt = "mp4", FileName = "stabilized.mp4" };
            if (dlg.ShowDialog() == true) edOutputFile.Text = dlg.FileName;
        }

        // The output must be a file in an existing folder (the MP4 sink cannot create the folder),
        // and it must not be the source file - the sink would truncate the clip being read.
        private static bool IsValidOutputPath(string path, string sourcePath)
        {
            if (string.IsNullOrWhiteSpace(path)) return false;

            try
            {
                var full = Path.GetFullPath(path);
                if (Directory.Exists(full) || string.IsNullOrEmpty(Path.GetFileName(full))) return false;

                var dir = Path.GetDirectoryName(full);
                if (string.IsNullOrEmpty(dir) || !Directory.Exists(dir)) return false;

                return string.IsNullOrWhiteSpace(sourcePath)
                    || !string.Equals(full, Path.GetFullPath(sourcePath), StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        // Stabilizer parameters can only be retuned while the pipeline runs.
        private void SetTuningEnabled(bool enabled)
        {
            chkEnabled.IsEnabled = enabled;
            slRadius.IsEnabled = enabled;
            slCrop.IsEnabled = enabled;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btStart.IsEnabled = false;
                if (_pipeline == null) { MessageBox.Show(this, "SDK failed to initialize."); btStart.IsEnabled = true; return; }

                mmLog.Clear();

                try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); }
                catch (Exception ex) { Debug.WriteLine(ex); }
                CleanupBlocks();

                if (string.IsNullOrWhiteSpace(edVideoFile.Text) || !File.Exists(edVideoFile.Text))
                {
                    MessageBox.Show(this, "Select a video file.");
                    btStart.IsEnabled = true; return;
                }

                var recording = chkRecord.IsChecked == true;
                var outputFile = edOutputFile.Text?.Trim();
                if (recording && !IsValidOutputPath(outputFile, edVideoFile.Text))
                {
                    MessageBox.Show(this, "Select a valid output MP4 file in an existing folder, different from the source.");
                    btStart.IsEnabled = true; return;
                }

                // Lock the recording choice now: it is read while the graph is built, so changing it
                // during the awaits below would silently not apply.
                SetRecordingControlsEnabled(false);

                var sourceSettings = await UniversalSourceSettings.CreateAsync(edVideoFile.Text, renderVideo: true, renderAudio: false);
                if (_isClosing) return;

                _videoSource = new UniversalSourceBlock(sourceSettings);

                _settings = new VideoStabilizationSettings
                {
                    Enabled = chkEnabled.IsChecked == true,
                    SmoothingRadius = (int)slRadius.Value,
                    CropRatio = slCrop.Value,
                };
                _stab = new VideoStabilizationBlock(_settings);

                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

                _pipeline.Connect(_videoSource.VideoOutput, _stab.Input);

                if (recording)
                {
                    // Tee the stabilized video: preview on one branch, H264 + MP4 file on the other.
                    _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
                    _h264Encoder = new H264EncoderBlock(H264EncoderBlock.GetDefaultSettings());
                    _mp4Sink = new MP4SinkBlock(new MP4SinkSettings(outputFile));

                    _pipeline.Connect(_stab.Output, _videoTee.Input);
                    _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
                    _pipeline.Connect(_videoTee.Outputs[1], _h264Encoder.Input);
                    _pipeline.Connect(_h264Encoder.Output, _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Video));
                }
                else
                {
                    _pipeline.Connect(_stab.Output, _videoRenderer.Input);
                }

                // StartAsync returns false (it does not throw) when a block fails to build - e.g. the
                // OpenCV redist is missing - so a fake "running" UI must not be shown.
                // Publish the task so a window close waits for the build instead of racing it.
                _startTask = _pipeline.StartAsync();
                var started = await _startTask;
                _startTask = null;

                // The close path is already tearing things down; do not touch the pipeline or the UI.
                if (_isClosing) return;

                if (!started)
                {
                    mmLog.Text += "Failed to start the pipeline." + Environment.NewLine;
                    try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); } catch (Exception ex) { Debug.WriteLine(ex); }
                    CleanupBlocks();
                    btStart.IsEnabled = true; btStop.IsEnabled = false;
                    SetRecordingControlsEnabled(true); SetTuningEnabled(false);
                    return;
                }

                // The StopAsync above raises OnStop, which re-enables the idle UI from the dispatcher queue
                // while we await. Set the running state last so it wins.
                btStart.IsEnabled = false;
                btStop.IsEnabled = true;
                SetRecordingControlsEnabled(false);
                SetTuningEnabled(true);
            }
            catch (Exception ex)
            {
                // Clear the faulted task so Window_Closing's await does not rethrow and skip disposal.
                _startTask = null;
                try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); } catch (Exception stopEx) { Debug.WriteLine(stopEx); }
                CleanupBlocks();
                btStart.IsEnabled = true; btStop.IsEnabled = false;
                SetRecordingControlsEnabled(true); SetTuningEnabled(false);
                mmLog.Text += ex.Message + Environment.NewLine;
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btStop.IsEnabled = false;
                SetTuningEnabled(false);

                if (_pipeline != null) { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); }
                CleanupBlocks();
                VideoView1.CallRefresh();
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            finally
            {
                btStart.IsEnabled = true;
                SetRecordingControlsEnabled(true);
            }
        }

        private void CleanupBlocks()
        {
            _stab?.Dispose(); _stab = null;
            _settings = null;
            _videoSource?.Dispose(); _videoSource = null;
            _videoRenderer?.Dispose(); _videoRenderer = null;
            _videoTee?.Dispose(); _videoTee = null;
            _h264Encoder?.Dispose(); _h264Encoder = null;
            _mp4Sink?.Dispose(); _mp4Sink = null;
        }

        // ---- live parameter changes (applied to the running element without restarting) ----
        // The vfdeshake element re-reads its properties every frame; ApplySettings() pushes the
        // current settings object to the element live. Each handler no-ops until Start.

        private void chkEnabled_Changed(object sender, RoutedEventArgs e)
        {
            if (_settings == null) return;
            _settings.Enabled = chkEnabled.IsChecked == true;
            _stab?.ApplySettings();
        }

        private void slRadius_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_settings == null) return;
            _settings.SmoothingRadius = (int)slRadius.Value;
            _stab?.ApplySettings();
        }

        private void slCrop_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_settings == null) return;
            _settings.CropRatio = Math.Round(slCrop.Value, 2);
            _stab?.ApplySettings();
        }
    }
}
