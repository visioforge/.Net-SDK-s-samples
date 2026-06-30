using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.AI;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace Capture_OCR_X_WPF
{
    /// <summary>
    /// Inserts a PaddleOCR text recognizer into VideoCaptureCoreX through the Video_Processing_AddBlock API:
    /// the recognizer taps the live camera frames, draws the recognized text into the preview, and raises
    /// OnTextDetected while the engine previews the camera. The Apache-2.0 PP-OCRv5 mobile models ship next
    /// to the executable, so the demo loads them directly with no model picker.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Bundled Apache-2.0 PP-OCRv5 mobile models, copied next to the executable by the project.
        private static readonly string DetModelPath = Path.Combine(AppContext.BaseDirectory, "ch_PP-OCRv5_mobile_det.onnx");
        private static readonly string ClsModelPath = Path.Combine(AppContext.BaseDirectory, "ch_ppocr_mobile_v2.0_cls_infer.onnx");
        private static readonly string RecModelPath = Path.Combine(AppContext.BaseDirectory, "latin_PP-OCRv5_rec_mobile_infer.onnx");
        private static readonly string DictPath = Path.Combine(AppContext.BaseDirectory, "ppocrv5_latin_dict.txt");

        private VideoCaptureCoreX _core;
        private OcrBlock _ocr;
        private VideoCaptureDeviceInfo[] _cameras;
        private bool _isClosing;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

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

            // OnTextDetected fires on the pipeline streaming thread; post non-blocking to the UI.
            _ = Dispatcher.BeginInvoke(new Action(() => mmLog.AppendText(text + Environment.NewLine)));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();

                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync() ?? Array.Empty<VideoCaptureDeviceInfo>();
                foreach (var cam in _cameras)
                {
                    cbCamera.Items.Add(cam.DisplayName);
                }

                if (cbCamera.Items.Count > 0)
                {
                    cbCamera.SelectedIndex = 0;
                }

                IsEnabled = true;

                // The engine is created fresh per session in btStart_Click (RecreateEngineAsync).

                Log($"SDK v{VideoCaptureCoreX.SDK_Version} ready.");
                Log("ONNX Runtime providers: " + string.Join(", ", OnnxInferenceEngine.GetAvailableProviders()));

                if (!File.Exists(DetModelPath) || !File.Exists(RecModelPath) || !File.Exists(DictPath))
                {
                    Log("WARNING: bundled PP-OCRv5 models were not found next to the application.");
                }
            }
            catch (Exception ex)
            {
                Log("load error: " + ex.Message);
            }
        }

        // Dispose any existing engine and build a fresh VideoCaptureCoreX bound to the same VideoView.
        private async Task RecreateEngineAsync()
        {
            if (_core != null)
            {
                _core.OnError -= Core_OnError;
                _core.OnStop -= Core_OnStop;
                try { await _core.StopAsync(); } catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex); }
                await _core.DisposeAsync();
                _core = null;
            }

            if (_isClosing)
            {
                return;
            }

            _core = new VideoCaptureCoreX(VideoView1 as IVideoView);
            _core.OnError += Core_OnError;
            _core.OnStop += Core_OnStop;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (_cameras == null || _cameras.Length == 0 || cbCamera.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Select a camera.");
                return;
            }

            if (!File.Exists(DetModelPath) || !File.Exists(RecModelPath) || !File.Exists(DictPath))
            {
                MessageBox.Show(this, "The bundled PP-OCRv5 models were not found next to the application.");
                return;
            }

            if (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                return;
            }

            try
            {
                btStart.IsEnabled = false;
                mmLog.Clear();

                await RecreateEngineAsync();
                if (_core == null || _isClosing)
                {
                    return;
                }

                // Configure the camera source at an HD (or best available) format.
                var device = _cameras[cbCamera.SelectedIndex];
                var formatItem = device.GetHDOrAnyVideoFormatAndFrameRate(out var frameRate);
                if (formatItem == null)
                {
                    Log("start error: unable to read a camera format.");
                    await CleanupAfterStopAsync();
                    btStart.IsEnabled = true;
                    return;
                }

                var videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                {
                    Format = formatItem.ToFormat()
                };
                videoSourceSettings.Format.FrameRate = frameRate;
                _core.Video_Source = videoSourceSettings;
                _core.Audio_Play = false;

                var useAngle = cbUseAngle.IsChecked == true;

                // Enable angle classification only when its model is present.
                var clsPath = (useAngle && File.Exists(ClsModelPath)) ? ClsModelPath : null;
                if (useAngle && clsPath == null)
                {
                    Log("Angle classification disabled: the classifier model was not found next to the application.");
                }

                var settings = new OcrSettings(DetModelPath, RecModelPath, DictPath, clsPath)
                {
                    DrawResults = cbDrawResults.IsChecked == true,
                };

                if (int.TryParse(edFramesToSkip.Text, out var skip) && skip >= 0)
                {
                    settings.FramesToSkip = skip;
                }

                _ocr = new OcrBlock(settings);
                _ocr.OnTextDetected += Ocr_OnTextDetected;
                _core.Video_Processing_AddBlock(_ocr);

                if (!await _core.StartAsync())
                {
                    Log("start error: failed to start capture.");
                    await CleanupAfterStopAsync();
                    btStart.IsEnabled = true;
                    return;
                }

                Log($"OCR running on: {_ocr.ActiveProvider}");
                btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Log("start error: " + ex.Message);
                await CleanupAfterStopAsync();
                btStart.IsEnabled = true;
            }
            finally
            {
                Interlocked.Exchange(ref _startStopBusy, 0);
            }
        }

        private void Ocr_OnTextDetected(object sender, OcrTextDetectedEventArgs e)
        {
            if (e.Regions == null || e.Regions.Length == 0)
            {
                return;
            }

            foreach (var region in e.Regions)
            {
                if (region != null && !string.IsNullOrWhiteSpace(region.Text))
                {
                    Log($"[{e.Timestamp:hh\\:mm\\:ss}] {region.Text}  ({region.Confidence:P0})");
                }
            }
        }

        private void Core_OnError(object sender, ErrorsEventArgs e) => Log(e.Message);

        private void Core_OnStop(object sender, StopEventArgs e)
        {
            // The engine disposes the inserted block on stop; drop our reference so the next Start re-creates one.
            _ = Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_isClosing)
                {
                    return;
                }

                // Ignore a stale Stop from a previous session (explicit Stop -> Start) so it can't reset the live UI.
                if (Volatile.Read(ref _startStopBusy) != 0)
                {
                    return;
                }

                if (_core != null && _core.State != PlaybackState.Free)
                {
                    return;
                }

                DetachBlock();
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
            }));
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                return;
            }

            btStop.IsEnabled = false;
            try
            {
                await CleanupAfterStopAsync();
            }
            catch (Exception ex)
            {
                Log("stop error: " + ex.Message);
            }
            finally
            {
                Interlocked.Exchange(ref _startStopBusy, 0);
            }
            btStart.IsEnabled = true;
        }

        private async System.Threading.Tasks.Task CleanupAfterStopAsync()
        {
            if (_core != null)
            {
                await _core.StopAsync();
            }

            DetachBlock();
        }

        /// <summary>
        /// Detach the handler and drop the reference — the engine owns and disposes the inserted block.
        /// </summary>
        private void DetachBlock()
        {
            if (_ocr != null)
            {
                _ocr.OnTextDetected -= Ocr_OnTextDetected;
                _ocr = null;
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isClosing)
            {
                return;
            }

            e.Cancel = true;
            _isClosing = true;
            IsEnabled = false;

            // Wait for an in-flight Start/Stop to finish before tearing the engine down.
            while (Interlocked.CompareExchange(ref _startStopBusy, 1, 0) != 0)
            {
                await Task.Delay(50);
            }

            try
            {
                if (_core != null)
                {
                    _core.OnError -= Core_OnError;
                    _core.OnStop -= Core_OnStop;
                    await _core.StopAsync();
                    await _core.DisposeAsync();
                    _core = null;
                }

                VideoView1.CallRefresh();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            _ = Dispatcher.BeginInvoke(new Action(() => Close()));
        }
    }
}
