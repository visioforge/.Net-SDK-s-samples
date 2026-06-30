using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

using Microsoft.Win32;

using VisioForge.Core;
using VisioForge.Core.AI;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

namespace Player_OCR_X_WPF
{
    /// <summary>
    /// Inserts a PaddleOCR text recognizer into MediaPlayerCoreX through the Video_Processing_AddBlock API:
    /// the recognizer taps the decoded video, draws the recognized text into the rendered frame, and raises
    /// OnTextDetected while the engine plays a normal file. The Apache-2.0 PP-OCRv5 mobile models ship next
    /// to the executable, so the demo loads them directly with no model picker.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Bundled Apache-2.0 PP-OCRv5 mobile models, copied next to the executable by the project.
        private static readonly string DetModelPath = Path.Combine(AppContext.BaseDirectory, "ch_PP-OCRv5_mobile_det.onnx");
        private static readonly string ClsModelPath = Path.Combine(AppContext.BaseDirectory, "ch_ppocr_mobile_v2.0_cls_infer.onnx");
        private static readonly string RecModelPath = Path.Combine(AppContext.BaseDirectory, "latin_PP-OCRv5_rec_mobile_infer.onnx");
        private static readonly string DictPath = Path.Combine(AppContext.BaseDirectory, "ppocrv5_latin_dict.txt");

        private MediaPlayerCoreX _player;
        private OcrBlock _ocr;
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
                IsEnabled = true;

                // The engine is created fresh per session in RecreatePlayerAsync.

                Log($"SDK v{MediaPlayerCoreX.SDK_Version} ready.");
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

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "Media files|*.mp4;*.mkv;*.avi;*.mov;*.webm;*.ts|All files|*.*" };
            if (dialog.ShowDialog() == true)
            {
                edFile.Text = dialog.FileName;
            }
        }

        // Disposes any existing engine and builds a fresh MediaPlayerCoreX on the same VideoView for each Start.
        private async Task RecreatePlayerAsync()
        {
            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                try { await _player.StopAsync(); } catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex); }
                await _player.DisposeAsync();
                _player = null;
            }

            if (_isClosing)
            {
                return;
            }

            _player = new MediaPlayerCoreX(VideoView1);
            _player.OnError += Player_OnError;
            _player.OnStop += Player_OnStop;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edFile.Text) || !File.Exists(edFile.Text))
            {
                MessageBox.Show(this, "Select a valid, existing media file.");
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

                await RecreatePlayerAsync();
                if (_player == null || _isClosing)
                {
                    return;
                }

                // Build the source before registering the block so a CreateAsync failure can't strand one.
                var source = await UniversalSourceSettings.CreateAsync(edFile.Text, renderVideo: true, renderAudio: false);

                var useAngle = cbUseAngle.IsChecked == true;

                // Only enable angle classification when its model file is present.
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
                _player.Video_Processing_AddBlock(_ocr);

                _player.Video_Play = true;
                _player.Audio_Play = false;

                if (!await _player.OpenAsync(source) || !await _player.PlayAsync())
                {
                    Log("start error: failed to open or play the source.");
                    await CleanupAfterStopAsync();
                    btStart.IsEnabled = true;
                    return;
                }

                Log($"OCR running on: {_ocr.ActiveProvider}");
                btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                // StopAsync tears down the pipeline and disposes any block it owns.
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

        private void Player_OnError(object sender, ErrorsEventArgs e) => Log(e.Message);

        private void Player_OnStop(object sender, StopEventArgs e)
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

                if (_player != null && _player.State != PlaybackState.Free)
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
            if (_player != null)
            {
                await _player.StopAsync();
            }

            DetachBlock();
        }

        /// <summary>
        /// Detaches the handler and drops the block reference (the engine owns and disposes the block itself).
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
                if (_player != null)
                {
                    _player.OnError -= Player_OnError;
                    _player.OnStop -= Player_OnStop;
                    await _player.StopAsync();
                    await _player.DisposeAsync();
                    _player = null;
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
