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
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

namespace Player_PII_Redaction_X_WPF
{
    /// <summary>
    /// Redacts PII (faces, license plates, on-screen text) while MediaPlayerCoreX plays a file. The
    /// PIIRedactionBlock is inserted through Video_Processing_AddBlock: it taps the decoded video, blurs/pixelates/
    /// fills the detected regions in place, and raises OnRegionsRedacted while the engine plays normally.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayerCoreX _player;

        private PIIRedactionBlock _redaction;

        // The settings object shared with the running block; category checkboxes, style, and sliders
        // mutate it live while playback runs.
        private PIIRedactionSettings _settings;

        private System.Windows.Threading.DispatcherTimer _timer;

        private bool _timerBusy;

        private bool _isClosing;

        // Set once async teardown has finished, so the final programmatic Close() is allowed through.
        private bool _cleanupCompleted;

        // Re-entrancy guard for START/STOP (0 = free, 1 = busy).
        private int _startStopBusy;

        // Seek-bar drag state.
        private bool _seeking;

        private bool _suppressSeek;

        private TimeSpan _duration;

        // Cancels an in-flight model download when the window is closing.
        private CancellationTokenSource _downloadCts;

        // All models (face, plate, text) are downloaded on demand into the cache below.
        // Weights are NOT shipped with the SDK.
        private const string ModelsReleaseUrl =
            "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

        private const string FaceModelFile = "face_detection_yunet_2023mar.onnx"; // YuNet (MIT)
        private const string PlateModelFile = "yolo-v9-t-640-license-plates-end2end.onnx"; // FastALPR (MIT)
        private const string TextDetModelFile = "ch_PP-OCRv5_mobile_det.onnx"; // PP-OCRv5 (Apache-2.0)
        private const string TextRecModelFile = "latin_PP-OCRv5_rec_mobile_infer.onnx"; // PP-OCRv5 (Apache-2.0)
        private const string TextDictFile = "ppocrv5_latin_dict.txt";

        // All models are hosted on the samples GitHub release and downloaded into the cache on demand.
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

                // The engine is created fresh per session in RecreatePlayerAsync.

                _timer = new System.Windows.Threading.DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(500),
                };
                _timer.Tick += Timer_Tick;

                Title += $" (SDK v{MediaPlayerCoreX.SDK_Version})";

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

        // Disposes any existing engine and builds a fresh MediaPlayerCoreX bound to the same VideoView.
        private async Task RecreatePlayerAsync()
        {
            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                try { await _player.StopAsync(); } catch (Exception ex) { Debug.WriteLine(ex); }
                try { await _player.DisposeAsync(); } catch (Exception ex) { Debug.WriteLine(ex); }
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
            if (string.IsNullOrWhiteSpace(edVideoFile.Text))
            {
                MessageBox.Show(this, "Select a video file on the Source tab.");
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
                await RecreatePlayerAsync();
                if (_player == null || _isClosing)
                {
                    btStart.IsEnabled = true;
                    return;
                }

                // Build the source before registering the block so a CreateAsync failure strands nothing.
                var source = await UniversalSourceSettings.CreateAsync(edVideoFile.Text, renderVideo: true, renderAudio: false);

                _settings = BuildSettings();
                _redaction = new PIIRedactionBlock(_settings);
                _redaction.OnRegionsRedacted += Redaction_OnRegionsRedacted;

                // Add the processing block BEFORE OpenAsync/PlayAsync - the engine builds the pipeline then and
                // takes ownership of the block (it disposes it on Stop).
                _player.Video_Processing_AddBlock(_redaction);

                _player.Video_Play = true;
                _player.Audio_Play = false;

                if (!await _player.OpenAsync(source) || !await _player.PlayAsync())
                {
                    mmLog.Text += "Failed to open or play the source - check the file and model paths." + Environment.NewLine;
                    await CleanupAfterStopAsync();
                    btStart.IsEnabled = true;
                    return;
                }

                // The window may have started closing while Open/Play awaited; don't flip the UI to a running state.
                if (_isClosing)
                {
                    return;
                }

                mmLog.Text += $"PII redaction running on: {_redaction.ActiveProvider}" + Environment.NewLine;

                // Enable the seek bar; duration resolves lazily in the timer once playback prerolls.
                _duration = TimeSpan.Zero;
                _suppressSeek = true;
                slSeek.Value = 0;
                _suppressSeek = false;
                slSeek.IsEnabled = true;

                _timer.Start();
                btStop.IsEnabled = true;
                btPause.IsEnabled = true;
                btResume.IsEnabled = false;
            }
            catch (Exception ex)
            {
                mmLog.Text += ex.Message + Environment.NewLine;
                Debug.WriteLine(ex);
                await CleanupAfterStopAsync();
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
                btPause.IsEnabled = false;
                btResume.IsEnabled = false;
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
            btPause.IsEnabled = false;
            btResume.IsEnabled = false;
            try
            {
                _timer?.Stop();
                await CleanupAfterStopAsync();

                VideoView1.CallRefresh();

                slSeek.IsEnabled = false;
                _suppressSeek = true;
                slSeek.Value = 0;
                _suppressSeek = false;
                lbTime.Text = "00:00:00";
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

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            if (_player == null)
            {
                return;
            }

            try
            {
                await _player.PauseAsync();
                btPause.IsEnabled = false;
                btResume.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            if (_player == null)
            {
                return;
            }

            try
            {
                await _player.ResumeAsync();
                btPause.IsEnabled = true;
                btResume.IsEnabled = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async Task CleanupAfterStopAsync()
        {
            if (_player != null)
            {
                await _player.StopAsync();
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

        private void Player_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => { mmLog.Text += e.Message + Environment.NewLine; }));
        }

        private void Player_OnStop(object sender, StopEventArgs e)
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

                if (_player != null && _player.State != PlaybackState.Free)
                {
                    return;
                }

                _timer?.Stop();
                DetachBlock();

                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
                btPause.IsEnabled = false;
                btResume.IsEnabled = false;

                slSeek.IsEnabled = false;
                _suppressSeek = true;
                slSeek.Value = 0;
                _suppressSeek = false;
            }));
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (_timerBusy)
            {
                return;
            }

            _timerBusy = true;
            try
            {
                if (_player == null)
                {
                    return;
                }

                var position = await _player.Position_GetAsync();

                // Duration is known only after preroll - keep trying until it resolves.
                if (_duration <= TimeSpan.Zero)
                {
                    try { _duration = await _player.DurationAsync(); } catch (Exception durEx) { Debug.WriteLine(durEx); }
                }

                if (_duration > TimeSpan.Zero)
                {
                    lbTime.Text = $"{position:hh\\:mm\\:ss} / {_duration:hh\\:mm\\:ss}";

                    // Reflect playback position on the seek bar unless the user is dragging it.
                    if (!_seeking)
                    {
                        _suppressSeek = true;
                        slSeek.Value = Math.Max(0, Math.Min(slSeek.Maximum, position.TotalSeconds / _duration.TotalSeconds * slSeek.Maximum));
                        _suppressSeek = false;
                    }
                }
                else
                {
                    lbTime.Text = position.ToString("hh\\:mm\\:ss");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                _timerBusy = false;
            }
        }

        private void slSeek_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            _seeking = true;
        }

        private async void slSeek_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            _seeking = false;
            await SeekToSliderAsync();
        }

        private async void slSeek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Ignore timer-driven updates and per-tick drag changes (committed once in DragCompleted); a track click lands here.
            if (_suppressSeek || _seeking)
            {
                return;
            }

            await SeekToSliderAsync();
        }

        private async Task SeekToSliderAsync()
        {
            if (_player == null)
            {
                return;
            }

            if (_duration <= TimeSpan.Zero)
            {
                try { _duration = await _player.DurationAsync(); } catch (Exception durEx) { Debug.WriteLine(durEx); }
            }

            if (_duration <= TimeSpan.Zero)
            {
                return;
            }

            try
            {
                var target = TimeSpan.FromSeconds(slSeek.Value / slSeek.Maximum * _duration.TotalSeconds);
                await _player.Position_SetAsync(target, seekToKeyframe: true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btSelectVideoFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "Video files|*.mp4;*.mkv;*.avi;*.mov;*.webm;*.ts|All files|*.*" };
            if (dlg.ShowDialog() == true)
            {
                edVideoFile.Text = dlg.FileName;
            }
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

                        using (var src = await response.Content.ReadAsStreamAsync())
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

                if (File.Exists(destPath)) File.Delete(destPath);
                File.Move(tmpPath, destPath);
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

        // Live-updates the shared settings while playback runs; a no-op before the first Start.
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
                _timer?.Stop();

                if (_player != null)
                {
                    _player.OnError -= Player_OnError;
                    _player.OnStop -= Player_OnStop;
                    // Isolate each step so a throwing StopAsync can't skip DisposeAsync + DestroySDK below.
                    try { await _player.StopAsync(); } catch (Exception stopEx) { Debug.WriteLine(stopEx); }
                    try { await _player.DisposeAsync(); } catch (Exception disposeEx) { Debug.WriteLine(disposeEx); }
                    _player = null;
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
