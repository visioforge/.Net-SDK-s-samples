using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

using Microsoft.Win32;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

namespace Capture_Live_Subtitles_X_WPF
{
    /// <summary>
    /// Inserts a Whisper speech-to-text block into VideoCaptureCoreX through the Audio_Processing_AddBlock API:
    /// the block taps the live microphone audio (passing it through unchanged) and raises OnSpeechRecognized,
    /// shown as a live subtitle over the camera preview. Audio_Record builds the audio chain without needing
    /// speaker output or a recording file.
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCaptureCoreX _core;
        private SpeechToTextBlock _speechToText;
        private VideoCaptureDeviceInfo[] _cameras;
        private AudioCaptureDeviceInfo[] _mics;
        private bool _isClosing;

        // Re-entrancy guard for Start/Stop (0 = free, 1 = busy); also suppresses a stale OnStop from a prior session.
        private int _startStopBusy;

        // Whisper GGML weights, hosted on the samples GitHub release; cached under %USERPROFILE%/VisioForge/models.
        private const string ModelsBaseUrl = "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

        // Silero VAD ONNX model on the samples GitHub release.
        private const string SileroVadUrl = "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1/silero_vad.onnx";

        private static readonly string ModelsCacheDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "VisioForge", "models");

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };

        private List<ModelPreset> _modelPresets;
        private ModelPreset _selectedPreset;

        static MainWindow()
        {
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("VisioForge-AI-Demo/1.0");
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private sealed class ModelPreset
        {
            public string Name;
            public string Tag;
            public string DownloadUrl;
            public string FileName;
            public bool IsLocal;
            public string LocalPath;
        }

        // The Whisper model hosted on the samples release; "Custom" lets the user browse for any .bin.
        private List<ModelPreset> BuildModelList()
        {
            Directory.CreateDirectory(ModelsCacheDir);
            var list = new List<ModelPreset>();
            AddDownloadable(list, "Whisper Base", "whisper-base", "ggml-base.bin");
            list.Add(new ModelPreset { Name = "Custom model...", Tag = "custom" });
            return list;
        }

        private void AddDownloadable(List<ModelPreset> list, string name, string tag, string fileName)
        {
            var cachePath = Path.Combine(ModelsCacheDir, fileName);
            var isCached = File.Exists(cachePath);
            list.Add(new ModelPreset
            {
                Name = name,
                Tag = tag,
                DownloadUrl = ModelsBaseUrl + "/" + fileName,
                FileName = fileName,
                IsLocal = isCached,
                LocalPath = isCached ? cachePath : null,
            });
        }

        private void RefreshModelList()
        {
            var selTag = _selectedPreset?.Tag;
            _modelPresets = BuildModelList();
            cbModel.Items.Clear();
            var selIdx = 0;
            for (var i = 0; i < _modelPresets.Count; i++)
            {
                cbModel.Items.Add(new ComboBoxItem { Content = _modelPresets[i].Name, Tag = _modelPresets[i].Tag });
                if (_modelPresets[i].Tag == selTag)
                {
                    selIdx = i;
                }
            }

            cbModel.SelectedIndex = selIdx;
        }

        private ModelPreset GetSelectedPreset()
        {
            var tag = ((cbModel.SelectedItem as ComboBoxItem)?.Tag as string) ?? "whisper-base";
            return _modelPresets.Find(p => p.Tag == tag) ?? _modelPresets[0];
        }

        private void cbModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsInitialized || cbModel.SelectedItem == null || _modelPresets == null)
            {
                return;
            }

            _selectedPreset = GetSelectedPreset();
            var needsDownload = _selectedPreset.DownloadUrl != null && !_selectedPreset.IsLocal;
            var isCustom = _selectedPreset.Tag == "custom";
            btDownloadModel.Visibility = needsDownload ? Visibility.Visible : Visibility.Collapsed;
            btSelectModel.Visibility = isCustom ? Visibility.Visible : Visibility.Collapsed;
            edModel.Text = _selectedPreset.IsLocal && _selectedPreset.LocalPath != null ? _selectedPreset.LocalPath : string.Empty;
        }

        private async void btDownloadModel_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedPreset?.DownloadUrl == null)
            {
                return;
            }

            Directory.CreateDirectory(ModelsCacheDir);
            var destPath = Path.Combine(ModelsCacheDir, _selectedPreset.FileName);
            var tempPath = destPath + ".part";

            btDownloadModel.IsEnabled = false;
            btDownloadModel.Content = "Downloading...";
            Log($"Downloading {_selectedPreset.Name}...");

            try
            {
                var url = _selectedPreset.DownloadUrl;

                // Download off the UI thread; stream to a .part temp, then move into place so a failed download leaves no corrupt cache.
                await System.Threading.Tasks.Task.Run(async () =>
                {
                    using (var response = await _http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();
                        var total = response.Content.Headers.ContentLength ?? -1L;
                        using (var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true))
                        {
                            await response.Content.CopyToAsync(fileStream);

                            // Reject a truncated download so a partial file is never cached as a complete model.
                            if (total > 0 && fileStream.Length != total)
                            {
                                throw new IOException($"Incomplete download: received {fileStream.Length} of {total} bytes.");
                            }
                        }
                    }

                    File.Move(tempPath, destPath, overwrite: true);
                });

                edModel.Text = destPath;
                Log($"Saved to {ModelsCacheDir} ({new FileInfo(destPath).Length / 1024 / 1024} MB).");
                RefreshModelList();
            }
            catch (Exception ex)
            {
                TryDeleteTemp(tempPath);
                Log("download failed: " + ex.Message);
                MessageBox.Show(this, $"Download failed:\n{ex.Message}\n\nURL: {_selectedPreset.DownloadUrl}", "Download error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                btDownloadModel.IsEnabled = true;
                btDownloadModel.Content = "Download";
            }
        }

        private static void TryDeleteTemp(string path)
        {
            try { if (File.Exists(path)) File.Delete(path); }
            catch { /* best-effort cleanup */ }
        }

        private void Log(string text)
        {
            if (_isClosing)
            {
                return;
            }

            // OnSpeechRecognized fires on the pipeline streaming thread; post non-blocking to the UI.
            _ = Dispatcher.BeginInvoke(new Action(() => mmLog.AppendText(text + Environment.NewLine)));
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();

                // The engine is created fresh per session in btStart_Click (RecreateEngineAsync) — nothing to construct here.

                _cameras = await DeviceEnumerator.Shared.VideoSourcesAsync();
                foreach (var camera in _cameras)
                {
                    cbCamera.Items.Add(camera.DisplayName);
                }

                if (cbCamera.Items.Count > 0)
                {
                    cbCamera.SelectedIndex = 0;
                }

                _mics = await DeviceEnumerator.Shared.AudioSourcesAsync(null);
                foreach (var mic in _mics)
                {
                    cbMic.Items.Add(mic.DisplayName);
                }

                if (cbMic.Items.Count > 0)
                {
                    cbMic.SelectedIndex = 0;
                }

                RefreshModelList();

                // Pre-fill the cached Silero VAD path if it was downloaded previously.
                var cachedVad = Path.Combine(ModelsCacheDir, "silero_vad.onnx");
                if (File.Exists(cachedVad))
                {
                    edVadFile.Text = cachedVad;
                }

                RefreshVadDownloadButton();

                Log($"SDK v{VideoCaptureCoreX.SDK_Version} ready.");
            }
            catch (Exception ex)
            {
                Log("load error: " + ex.Message);
            }
            finally
            {
                IsEnabled = true;
            }
        }

        private void btSelectModel_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "Whisper GGML models|*.bin|All files|*.*" };
            if (dialog.ShowDialog() == true)
            {
                edModel.Text = dialog.FileName;
            }
        }

        private void btSelectVad_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "ONNX models|*.onnx|All files|*.*" };
            if (dialog.ShowDialog() == true)
            {
                edVadFile.Text = dialog.FileName;
            }
        }

        private async void btDownloadVad_Click(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory(ModelsCacheDir);
            var destPath = Path.Combine(ModelsCacheDir, "silero_vad.onnx");
            var tempPath = destPath + ".part";
            btDownloadVad.IsEnabled = false;
            btDownloadVad.Content = "...";
            Log("Downloading Silero VAD model...");
            try
            {
                // Download off the UI thread; stream to a .part temp, then move into place so a failed download leaves no corrupt cache.
                await System.Threading.Tasks.Task.Run(async () =>
                {
                    using (var response = await _http.GetAsync(SileroVadUrl, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();
                        var total = response.Content.Headers.ContentLength ?? -1L;
                        using (var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true))
                        {
                            await response.Content.CopyToAsync(fileStream);

                            // Reject a truncated download so a partial file is never cached as a complete model.
                            if (total > 0 && fileStream.Length != total)
                            {
                                throw new IOException($"Incomplete download: received {fileStream.Length} of {total} bytes.");
                            }
                        }
                    }

                    File.Move(tempPath, destPath, overwrite: true);
                });

                edVadFile.Text = destPath;
                Log($"Saved Silero VAD ({new FileInfo(destPath).Length / 1024} KB).");
            }
            catch (Exception ex)
            {
                TryDeleteTemp(tempPath);
                Log("Silero download failed: " + ex.Message);
                MessageBox.Show(this, $"Download failed:\n{ex.Message}\n\nURL: {SileroVadUrl}", "Download error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                btDownloadVad.IsEnabled = true;
                btDownloadVad.Content = "Download";
                RefreshVadDownloadButton();
            }
        }

        // Hides the Silero VAD download button once the model is cached locally; shows it otherwise.
        private void RefreshVadDownloadButton()
        {
            var cachedVad = Path.Combine(ModelsCacheDir, "silero_vad.onnx");
            btDownloadVad.Visibility = File.Exists(cachedVad) ? Visibility.Collapsed : Visibility.Visible;
        }

        private SpeechToTextTask SelectedTask()
            => ((cbTask.SelectedItem as ComboBoxItem)?.Tag as string) == "translate" ? SpeechToTextTask.Translate : SpeechToTextTask.Transcribe;

        private OnnxExecutionProvider SelectedProvider()
        {
            var tag = ((cbProvider.SelectedItem as ComboBoxItem)?.Tag as string) ?? "auto";
            switch (tag)
            {
                case "cpu": return OnnxExecutionProvider.CPU;
                case "cuda": return OnnxExecutionProvider.CUDA;
                case "auto":
                default: return OnnxExecutionProvider.Auto;
            }
        }

        // Disposes any existing engine and builds a fresh VideoCaptureCoreX bound to the same VideoView.
        private async System.Threading.Tasks.Task RecreateEngineAsync()
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

            if (_mics == null || _mics.Length == 0 || cbMic.SelectedIndex < 0)
            {
                MessageBox.Show(this, "No microphone devices were found.");
                return;
            }

            if (string.IsNullOrWhiteSpace(edModel.Text))
            {
                MessageBox.Show(this, "Select a Whisper GGML .bin model.");
                return;
            }

            var enableVad = cbEnableVad.IsChecked == true;
            if (enableVad && (string.IsNullOrWhiteSpace(edVadFile.Text) || !File.Exists(edVadFile.Text)))
            {
                MessageBox.Show(this, "Select or download the Silero VAD model, or uncheck Enable VAD.");
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
                lbSubtitle.Text = string.Empty;

                // Build a fresh engine for this session.
                await RecreateEngineAsync();
                if (_core == null || _isClosing)
                {
                    btStart.IsEnabled = true;
                    return;
                }

                // Camera source (for the preview the subtitle is drawn over).
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

                // Microphone source. A non-synced null renderer via Audio_OutputBlock terminates the audio chain with no audible output.
                var mic = _mics[cbMic.SelectedIndex];
                var micFormat = mic.GetDefaultFormat();
                if (micFormat == null)
                {
                    MessageBox.Show(this, "Unable to read a microphone format.");
                    btStart.IsEnabled = true;
                    return;
                }

                _core.Audio_Source = mic.CreateSourceSettingsVC(micFormat);
                _core.Audio_Play = false;
                _core.Audio_OutputBlock = new NullRendererBlock(MediaBlockPadMediaType.Audio) { IsSync = false };

                // The block taps audio and passes it through unchanged. Silero VAD (when enabled) trims silence so Whisper only runs on speech.
                var provider = SelectedProvider();
                var settings = new SpeechToTextSettings(edModel.Text)
                {
                    Language = string.IsNullOrWhiteSpace(edLanguage.Text) ? "auto" : edLanguage.Text.Trim(),
                    Task = SelectedTask(),
                    Provider = provider,
                    EnableVad = enableVad,
                };
                settings.Vad.ModelPath = edVadFile.Text;
                settings.Vad.Provider = provider == OnnxExecutionProvider.CUDA ? OnnxExecutionProvider.CUDA : OnnxExecutionProvider.CPU;

                _speechToText = new SpeechToTextBlock(settings);
                _speechToText.OnSpeechRecognized += SpeechToText_OnSpeechRecognized;
                _core.Audio_Processing_AddBlock(_speechToText);

                if (!await _core.StartAsync())
                {
                    Log("start error: failed to start capture.");
                    await CleanupAfterStopAsync();
                    btStart.IsEnabled = true;
                    return;
                }

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

        private void SpeechToText_OnSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Segments == null || e.Segments.Length == 0)
            {
                return;
            }

            string line = null;
            foreach (var segment in e.Segments)
            {
                var text = segment?.Text?.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    line = text;
                    Log(text);
                }
            }

            if (line == null)
            {
                return;
            }

            _ = Dispatcher.BeginInvoke(new Action(() =>
            {
                if (!_isClosing)
                {
                    lbSubtitle.Text = line;
                }
            }));
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

                // Ignore a stale Stop from a previous session while a new Start/Stop is in flight.
                if (Volatile.Read(ref _startStopBusy) != 0)
                {
                    return;
                }

                if (_core != null && _core.State != PlaybackState.Free)
                {
                    return;
                }

                DetachBlock();
                lbSubtitle.Text = string.Empty;
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
                lbSubtitle.Text = string.Empty;
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
        /// The engine owns and disposes the inserted block once started, so we only detach the handler and drop
        /// the reference here (we do not dispose it ourselves).
        /// </summary>
        private void DetachBlock()
        {
            if (_speechToText != null)
            {
                _speechToText.OnSpeechRecognized -= SpeechToText_OnSpeechRecognized;
                _speechToText = null;
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
                await System.Threading.Tasks.Task.Delay(50);
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
