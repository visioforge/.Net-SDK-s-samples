using Microsoft.Win32;
using SkiaSharp;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core;
using VisioForge.Core.AI;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace Capture_PII_Redaction_X_WPF
{
    /// <summary>
    /// Redacts PII (faces, license plates, on-screen text) on the live VideoCaptureCoreX preview. The
    /// PIIRedactionBlock is inserted through Video_Processing_AddBlock: it taps the camera frames, blurs/pixelates/
    /// fills the detected regions in place, and raises OnRegionsRedacted.
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCaptureCoreX _core;

        private PIIRedactionBlock _redaction;

        // The settings object shared with the running block; category checkboxes, style, and sliders
        // mutate it live while capture runs.
        private PIIRedactionSettings _settings;

        private VideoCaptureDeviceInfo[] _cameras;

        private bool _isClosing;

        // Set once async teardown has finished, so the final programmatic Close() is allowed through.
        private bool _cleanupCompleted;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        // Cancels an in-flight model download when the window is closing.
        private CancellationTokenSource _downloadCts;

        // The models are hosted in the SDK samples release and downloaded into the cache on demand.
        // Weights are NOT shipped with the SDK.
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

        private const string FaceModelFile = "face_detection_yunet_2023mar.onnx"; // YuNet (MIT)
        private const string PlateModelFile = "yolo-v9-t-640-license-plates-end2end.onnx"; // FastALPR (MIT)
        private const string TextDetModelFile = "ch_PP-OCRv5_mobile_det.onnx"; // PP-OCRv5 (Apache-2.0)
        private const string TextRecModelFile = "latin_PP-OCRv5_rec_mobile_infer.onnx"; // PP-OCRv5 (Apache-2.0)
        private const string TextDictFile = "ppocrv5_latin_dict.txt";

        private static readonly string[] AllModelFiles =
        {
            FaceModelFile, PlateModelFile, TextDetModelFile, TextRecModelFile, TextDictFile,
        };

        private static readonly string ModelsCacheDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "VisioForge", "models");

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

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
                Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                this.IsEnabled = false;
                try
                {
                    await VisioForgeX.InitSDKAsync();
                }
                finally
                {
                    this.IsEnabled = true;
                    Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", string.Empty);
                }

                // The engine is created fresh per session in RecreateEngineAsync.

                Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";

                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync() ?? Array.Empty<VideoCaptureDeviceInfo>();
                foreach (var camera in _cameras)
                {
                    cbCamera.Items.Add(camera.DisplayName);
                }

                if (cbCamera.Items.Count > 0)
                {
                    cbCamera.SelectedIndex = 0;
                }

                cbStyle.Items.Add("Gaussian blur");
                cbStyle.Items.Add("Pixelate");
                cbStyle.Items.Add("Solid fill");
                cbStyle.SelectedIndex = 0;

                cbFillColor.Items.Add("Black");
                cbFillColor.Items.Add("White");
                cbFillColor.Items.Add("Gray");
                cbFillColor.SelectedIndex = 0;

                // All models are downloaded on demand into the cache; prefill any already present.
                PrefillAllFromCache();
                RefreshModelButtons();

                var providers = OnnxInferenceEngine.GetAvailableProviders();
                mmLog.Text += "ONNX Runtime providers: " + string.Join(", ", providers) + Environment.NewLine;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void PrefillAllFromCache()
        {
            PrefillFromCache(edFaceModel, FaceModelFile);
            PrefillFromCache(edPlateModel, PlateModelFile);
            PrefillFromCache(edTextDetModel, TextDetModelFile);
            PrefillFromCache(edTextRecModel, TextRecModelFile);
            PrefillFromCache(edTextDict, TextDictFile);
        }

        private static void PrefillFromCache(TextBox box, string fileName)
        {
            var path = Path.Combine(ModelsCacheDir, fileName);
            if (File.Exists(path))
            {
                box.Text = path;
            }
        }

        // Show the "Download all models" button while any model is still missing from the cache.
        private void RefreshModelButtons()
        {
            var anyMissing = AllModelFiles.Any(f => !File.Exists(Path.Combine(ModelsCacheDir, f)));
            btDownloadModels.Visibility = anyMissing ? Visibility.Visible : Visibility.Collapsed;
        }

        // Disposes any existing engine and builds a fresh VideoCaptureCoreX bound to the same VideoView.
        private async Task RecreateEngineAsync()
        {
            if (_core != null)
            {
                _core.OnError -= Core_OnError;
                _core.OnStop -= Core_OnStop;
                try { await _core.StopAsync(); } catch (Exception ex) { Debug.WriteLine(ex); }
                try { await _core.DisposeAsync(); } catch (Exception ex) { Debug.WriteLine(ex); }
                _core = null;
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
            if (_cameras == null || _cameras.Length == 0 || cbCamera.SelectedIndex < 0)
            {
                MessageBox.Show(this, "No camera devices were found.");
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
                txtResults.Clear();

                if (!ModelsSelected())
                {
                    btStart.IsEnabled = true;
                    return;
                }

                // Build the engine from scratch for every session.
                await RecreateEngineAsync();
                if (_core == null || _isClosing)
                {
                    btStart.IsEnabled = true;
                    return;
                }

                // Configure the camera source at an HD (or best available) format.
                var device = _cameras[cbCamera.SelectedIndex];
                var formatItem = device.GetHDOrAnyVideoFormatAndFrameRate(out var frameRate);
                if (formatItem == null)
                {
                    MessageBox.Show(this, "Unable to read a camera format.");
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

                _settings = BuildSettings();
                _redaction = new PIIRedactionBlock(_settings);
                _redaction.OnRegionsRedacted += Redaction_OnRegionsRedacted;

                // Add the processing block BEFORE StartAsync - the engine builds the pipeline then and takes
                // ownership of the block (it disposes it on Stop).
                _core.Video_Processing_AddBlock(_redaction);

                if (!await _core.StartAsync())
                {
                    mmLog.Text += "Failed to start capture - check the camera and model paths." + Environment.NewLine;
                    await CleanupAfterStopAsync();
                    btStart.IsEnabled = true;
                    return;
                }

                // The window may have started closing while StartAsync awaited; don't flip the UI to a running state.
                if (_isClosing)
                {
                    return;
                }

                mmLog.Text += $"PII redaction running on: {_redaction.ActiveProvider}" + Environment.NewLine;
                btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                mmLog.Text += ex.Message + Environment.NewLine;
                Debug.WriteLine(ex);
                await CleanupAfterStopAsync();
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
            }
            finally
            {
                Interlocked.Exchange(ref _startStopBusy, 0);
            }
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
                VideoView1.CallRefresh();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                Interlocked.Exchange(ref _startStopBusy, 0);
            }

            btStart.IsEnabled = true;
        }

        private async Task CleanupAfterStopAsync()
        {
            if (_core != null)
            {
                await _core.StopAsync();
            }

            DetachBlock();
        }

        /// <summary>
        /// The engine owns and disposes the inserted block once started, so we only detach the handler and drop
        /// the reference here (we do not dispose it ourselves).
        /// </summary>
        private void DetachBlock()
        {
            if (_redaction != null)
            {
                _redaction.OnRegionsRedacted -= Redaction_OnRegionsRedacted;
                _redaction = null;
            }

            _settings = null;
        }

        private void Core_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => { mmLog.Text += e.Message + Environment.NewLine; }));
        }

        private void Core_OnStop(object sender, StopEventArgs e)
        {
            // The engine disposes the inserted block on stop; drop our reference so the next Start re-creates one.
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (_isClosing)
                {
                    return;
                }

                // Ignore a stale Stop from a previous session while a start/stop is in flight.
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

        private void btSelectFaceModel_Click(object sender, RoutedEventArgs e) => PickOnnx(edFaceModel);

        private void btSelectPlateModel_Click(object sender, RoutedEventArgs e) => PickOnnx(edPlateModel);

        private void btSelectTextDetModel_Click(object sender, RoutedEventArgs e) => PickOnnx(edTextDetModel);

        private void btSelectTextRecModel_Click(object sender, RoutedEventArgs e) => PickOnnx(edTextRecModel);

        private void btSelectTextDict_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "Dictionary files|*.txt|All files|*.*" };
            if (dlg.ShowDialog() == true)
            {
                edTextDict.Text = dlg.FileName;
            }
        }

        private static void PickOnnx(TextBox box)
        {
            var dlg = new OpenFileDialog { Filter = "ONNX models|*.onnx|All files|*.*" };
            if (dlg.ShowDialog() == true)
            {
                box.Text = dlg.FileName;
            }
        }

        private async void btDownloadModels_Click(object sender, RoutedEventArgs e)
        {
            var missing = AllModelFiles.Where(f => !File.Exists(Path.Combine(ModelsCacheDir, f))).ToList();
            if (missing.Count == 0)
            {
                PrefillAllFromCache();
                RefreshModelButtons();
                return;
            }

            btDownloadModels.IsEnabled = false;
            pnlDownload.Visibility = Visibility.Visible;

            _downloadCts?.Dispose();
            _downloadCts = new CancellationTokenSource();

            try
            {
                Directory.CreateDirectory(ModelsCacheDir);
                for (int i = 0; i < missing.Count; i++)
                {
                    await DownloadOneAsync(missing[i], i + 1, missing.Count, _downloadCts.Token);
                }

                if (!_isClosing)
                {
                    pbDownload.Value = 100;
                    lbDownloadStatus.Text = "All models downloaded.";
                    mmLog.Text += $"Models saved to {ModelsCacheDir}." + Environment.NewLine;
                    PrefillAllFromCache();
                    RefreshModelButtons();
                }
            }
            catch (Exception ex)
            {
                if (!_isClosing)
                {
                    pbDownload.IsIndeterminate = false;
                    pbDownload.Value = 0;
                    lbDownloadStatus.Text = "Download failed.";
                    mmLog.Text += $"Download failed: {ex.Message}" + Environment.NewLine;
                    MessageBox.Show(this, $"Download failed:\n{ex.Message}\n\nModels come from {ModelsReleaseUrl}", "Download Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            finally
            {
                btDownloadModels.IsEnabled = true;
                pnlDownload.Visibility = Visibility.Collapsed;
            }
        }

        // Streams one model to a .part temp file (idle-timeout guarded) then renames it in, so an interrupted
        // download never leaves a corrupt file at the final path. Throws on failure to stop the batch.
        private async Task DownloadOneAsync(string fileName, int index, int total, CancellationToken cancellationToken)
        {
            var destPath = Path.Combine(ModelsCacheDir, fileName);
            var tmpPath = destPath + ".part";

            pbDownload.IsIndeterminate = false;
            pbDownload.Value = 0;
            lbDownloadStatus.Text = $"Downloading {fileName} ({index}/{total})...";
            mmLog.Text += $"Downloading {fileName}..." + Environment.NewLine;

            try
            {
                await Task.Run(async () =>
                {
                    using (var response = await _http.GetAsync(ModelsReleaseUrl + "/" + fileName, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                    {
                        response.EnsureSuccessStatusCode();

                        var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                        _ = Dispatcher.BeginInvoke(new Action(() => pbDownload.IsIndeterminate = totalBytes <= 0));

                        using (var src = await response.Content.ReadAsStreamAsync(cancellationToken))
                        using (var fileStream = File.Create(tmpPath))
                        using (var idleCts = new CancellationTokenSource())
                        using (var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(idleCts.Token, cancellationToken))
                        {
                            // ResponseHeadersRead means the HttpClient timeout only bounds the header read, not the
                            // body stream. Guard the copy with an idle timeout that resets after every chunk. The
                            // linked token also fires when the window is closing (cancellationToken).
                            var idleTimeout = TimeSpan.FromSeconds(100);
                            var buffer = new byte[81920];
                            long readTotal = 0;
                            int lastPercent = -1;
                            int read;
                            idleCts.CancelAfter(idleTimeout);
                            while ((read = await src.ReadAsync(buffer, 0, buffer.Length, linkedCts.Token)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, read, linkedCts.Token);
                                idleCts.CancelAfter(idleTimeout);
                                readTotal += read;

                                if (totalBytes > 0)
                                {
                                    var percent = (int)(readTotal * 100 / totalBytes);
                                    if (percent != lastPercent)
                                    {
                                        lastPercent = percent;
                                        _ = Dispatcher.BeginInvoke(new Action(() =>
                                        {
                                            pbDownload.Value = percent;
                                            lbDownloadStatus.Text = $"Downloading {fileName} ({index}/{total})... {percent}%";
                                        }));
                                    }
                                }
                            }

                            if (totalBytes > 0 && readTotal != totalBytes)
                            {
                                throw new IOException($"Incomplete download: received {readTotal} of {totalBytes} bytes.");
                            }
                        }
                    }
                });

                File.Move(tmpPath, destPath, true);
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                // Idle timeout fired (not a window close): report it as a clear failure instead of a silent cancel.
                try { if (File.Exists(tmpPath)) File.Delete(tmpPath); } catch { }
                throw new TimeoutException($"Download of {fileName} timed out due to inactivity.");
            }
            catch
            {
                try { if (File.Exists(tmpPath)) File.Delete(tmpPath); } catch { }
                throw;
            }
        }

        // Live-updates the shared settings while capture runs; a no-op before the first Start.
        private void cbCategory_Changed(object sender, RoutedEventArgs e)
        {
            if (_settings == null)
            {
                return;
            }

            _settings.Faces.Enabled = cbFaces.IsChecked == true;
            _settings.LicensePlates.Enabled = cbPlates.IsChecked == true;
            _settings.Text.Enabled = cbText.IsChecked == true;
        }

        private void cbStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_settings != null)
            {
                _settings.Style = (PIIRedactionStyle)cbStyle.SelectedIndex;
            }
        }

        private void cbFillColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_settings != null)
            {
                _settings.FillColor = SelectedFillColor();
            }
        }

        private SKColor SelectedFillColor()
        {
            switch (cbFillColor.SelectedIndex)
            {
                case 1: return SKColors.White;
                case 2: return SKColors.Gray;
                default: return SKColors.Black;
            }
        }

        private void slBlurRadius_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbBlurRadius != null)
            {
                lbBlurRadius.Text = ((int)slBlurRadius.Value).ToString();
            }

            if (_settings != null)
            {
                _settings.BlurRadius = (float)slBlurRadius.Value;
            }
        }

        private void slPixelate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbPixelate != null)
            {
                lbPixelate.Text = ((int)slPixelate.Value).ToString();
            }

            if (_settings != null)
            {
                _settings.PixelateBlockSize = (int)slPixelate.Value;
            }
        }

        // Reads the current UI into a fresh settings object (used at Start).
        private PIIRedactionSettings BuildSettings()
        {
            var settings = new PIIRedactionSettings
            {
                Style = (PIIRedactionStyle)cbStyle.SelectedIndex,
                BlurRadius = (float)slBlurRadius.Value,
                PixelateBlockSize = (int)slPixelate.Value,
                FillColor = SelectedFillColor(),
            };

            settings.Faces.Enabled = cbFaces.IsChecked == true;
            settings.Faces.ModelPath = edFaceModel.Text;
            settings.LicensePlates.Enabled = cbPlates.IsChecked == true;
            settings.LicensePlates.ModelPath = edPlateModel.Text;
            settings.Text.Enabled = cbText.IsChecked == true;
            settings.Text.DetectionModelPath = edTextDetModel.Text;
            settings.Text.RecognitionModelPath = edTextRecModel.Text;
            settings.Text.CharacterDictionaryPath = edTextDict.Text;

            var regex = edTextRegex.Text?.Trim();
            if (!string.IsNullOrEmpty(regex))
            {
                settings.Text.TextFilterRegex = regex;
            }

            if (float.TryParse(edPadding.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var padding) && padding >= 0)
            {
                settings.RegionPaddingPercent = padding / 100f;
            }

            if (int.TryParse(edHoldMs.Text, out var hold) && hold >= 0)
            {
                settings.RegionHoldTimeMs = hold;
            }

            if (int.TryParse(edFramesToSkip.Text, out var skip) && skip >= 0)
            {
                settings.FramesToSkip = skip;
            }

            return settings;
        }

        private bool ModelsSelected()
        {
            if (cbFaces.IsChecked != true && cbPlates.IsChecked != true && cbText.IsChecked != true)
            {
                MessageBox.Show(this, "Enable at least one PII category on the Redaction tab.");
                return false;
            }

            if (cbFaces.IsChecked == true && string.IsNullOrWhiteSpace(edFaceModel.Text))
            {
                MessageBox.Show(this, "Select (or download) the face detector model on the Models tab, or disable the Faces category.");
                return false;
            }

            if (cbPlates.IsChecked == true && string.IsNullOrWhiteSpace(edPlateModel.Text))
            {
                MessageBox.Show(this, "Select the license plate detector model on the Models tab, or disable the License plates category.");
                return false;
            }

            if (cbText.IsChecked == true
                && (string.IsNullOrWhiteSpace(edTextDetModel.Text)
                    || string.IsNullOrWhiteSpace(edTextRecModel.Text)
                    || string.IsNullOrWhiteSpace(edTextDict.Text)))
            {
                MessageBox.Show(this, "On-screen text redaction needs the detection model, the recognition model, and the dictionary on the Models tab (recognition filters out non-text detections), or disable the On-screen text category.");
                return false;
            }

            // Validate the regex up front so an invalid pattern reports the real reason instead of the generic
            // "check the model paths" start failure.
            if (cbText.IsChecked == true && !string.IsNullOrWhiteSpace(edTextRegex.Text))
            {
                try
                {
                    _ = new System.Text.RegularExpressions.Regex(edTextRegex.Text.Trim());
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(this, "Invalid text filter regex: " + ex.Message);
                    return false;
                }
            }

            return true;
        }

        private void Redaction_OnRegionsRedacted(object sender, PIIRegionsRedactedEventArgs e)
        {
            // Marshal to the UI thread without blocking the detection worker.
            Dispatcher.BeginInvoke(new Action(() =>
            {
                int faces = 0, plates = 0, text = 0;
                foreach (var region in e.Regions)
                {
                    switch (region.Category)
                    {
                        case PIICategory.Face: faces++; break;
                        case PIICategory.LicensePlate: plates++; break;
                        case PIICategory.Text: text++; break;
                    }
                }

                var parts = new System.Collections.Generic.List<string>();
                if (faces > 0) parts.Add($"{faces} face(s)");
                if (plates > 0) parts.Add($"{plates} plate(s)");
                if (text > 0) parts.Add($"{text} text region(s)");

                var line = $"[{e.Timestamp:hh\\:mm\\:ss}] Redacted {string.Join(", ", parts)}";

                // Newest on top; cap the buffer so it does not grow without bound.
                txtResults.Text = line + "\r\n" + txtResults.Text;
                if (txtResults.Text.Length > 40000)
                {
                    txtResults.Text = txtResults.Text.Substring(0, 40000);
                }
            }));
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Cleanup finished — let the final programmatic Close() proceed.
            if (_cleanupCompleted)
            {
                return;
            }

            // Cancel FIRST, so any close message that arrives while cleanup is running (Alt+F4, taskbar,
            // shutdown) is deferred instead of closing the window mid-teardown.
            e.Cancel = true;

            if (_isClosing)
            {
                return;
            }

            _isClosing = true;
            IsEnabled = false;

            // Abort an in-flight model download so it can't keep streaming during teardown, then release it.
            try { _downloadCts?.Cancel(); _downloadCts?.Dispose(); } catch (ObjectDisposedException) { }

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
                    // Isolate each step so a throwing StopAsync can't skip DisposeAsync + DestroySDK below.
                    try { await _core.StopAsync(); } catch (Exception stopEx) { Debug.WriteLine(stopEx); }
                    try { await _core.DisposeAsync(); } catch (Exception disposeEx) { Debug.WriteLine(disposeEx); }
                    _core = null;
                }

                DetachBlock();

                VideoView1.CallRefresh();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            _cleanupCompleted = true;
            _ = Dispatcher.BeginInvoke(new Action(() => Close()));
        }
    }
}
