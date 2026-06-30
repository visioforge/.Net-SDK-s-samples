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
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Sources;

namespace Player_Live_Subtitles_X_WPF
{
    /// <summary>
    /// Inserts a Whisper speech-to-text block into MediaPlayerCoreX through the Audio_Processing_AddBlock API:
    /// the block taps the decoded audio (audio output goes to a null renderer, so it plays without speaker sound) and raises
    /// OnSpeechRecognized, shown as a live subtitle while the engine plays a normal file.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayerCoreX _player;
        private SpeechToTextBlock _speechToText;
        private bool _isClosing;

        // Re-entrancy guard for Start/Stop (0 = free, 1 = busy); also suppresses a stale OnStop from a prior session.
        private int _startStopBusy;

        // Whisper GGML weights on the samples GitHub release; cached under %USERPROFILE%/VisioForge/models.
        private const string ModelsBaseUrl = "https://github.com/visioforge/.Net-SDK-s-samples/releases/download/onnx-models-v1";

        // Silero VAD ONNX model on the same samples release.
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

                // Download off the UI thread to a .part temp, then move into place so a failure leaves no corrupt cache.
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
                IsEnabled = true;

                // The engine is built fresh per session in btStart_Click (RecreatePlayerAsync) — nothing to construct here.

                RefreshModelList();

                // Pre-fill the Silero VAD path if it was downloaded earlier, and hide the download button when present.
                var cachedVad = Path.Combine(ModelsCacheDir, "silero_vad.onnx");
                if (File.Exists(cachedVad))
                {
                    edVadFile.Text = cachedVad;
                }

                RefreshVadDownloadButton();

                Log($"SDK v{MediaPlayerCoreX.SDK_Version} ready.");
            }
            catch (Exception ex)
            {
                Log("load error: " + ex.Message);
            }
        }

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "Media files|*.mp4;*.mkv;*.avi;*.mov;*.webm;*.ts;*.m4a;*.wav;*.mp3|All files|*.*" };
            if (dialog.ShowDialog() == true)
            {
                edFile.Text = dialog.FileName;
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
                // Download off the UI thread to a .part temp, then move into place so a failure leaves no corrupt cache.
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

        // Disposes any existing engine and builds a fresh MediaPlayerCoreX bound to the same VideoView.
        private async System.Threading.Tasks.Task RecreatePlayerAsync()
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
            if (string.IsNullOrWhiteSpace(edFile.Text))
            {
                MessageBox.Show(this, "Select a media file.");
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

                // Build the engine from scratch for every session.
                await RecreatePlayerAsync();
                if (_player == null || _isClosing)
                {
                    btStart.IsEnabled = true;
                    return;
                }

                // Build the source before registering the block (a CreateAsync failure must not strand a block).
                var source = await UniversalSourceSettings.CreateAsync(edFile.Text, renderVideo: true, renderAudio: true);

                // Route audio to a non-synced null renderer so the speech-to-text block runs at full speed, not real time.
                _player.Audio_OutputBlock = new NullRendererBlock(MediaBlockPadMediaType.Audio) { IsSync = false };

                // VAD runs on CUDA only when Whisper does, otherwise CPU.
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
                _player.Audio_Processing_AddBlock(_speechToText);

                _player.Video_Play = true;
                _player.Audio_Play = true;

                if (!await _player.OpenAsync(source) || !await _player.PlayAsync())
                {
                    Log("start error: failed to open or play the source.");
                    await CleanupAfterStopAsync();
                    btStart.IsEnabled = true;
                    return;
                }

                btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                // StopAsync tears down the pipeline and disposes any wired block; a pre-build throw registered none.
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
                    Log($"[{segment.StartTime:hh\\:mm\\:ss} -> {segment.EndTime:hh\\:mm\\:ss}] {text}");
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

                // Ignore a stale Stop from a previous session while a new Start/Stop is in flight.
                if (Volatile.Read(ref _startStopBusy) != 0)
                {
                    return;
                }

                if (_player != null && _player.State != PlaybackState.Free)
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
