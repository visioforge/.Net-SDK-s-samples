using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

using VisioForge.Core;
using VisioForge.Core.AI.Whisper.Subtitles;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AI;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AI;
using VisioForge.Core.Types.X.Sources;

using Whisper.net.Ggml;

namespace Live_Subtitles_Demo
{
    public partial class MainWindow : Window
    {
        // Models are cached under %USERPROFILE%/VisioForge/models. Weights are NOT shipped with the SDK.
        private static readonly string ModelsCacheDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "VisioForge", "models");

        // Official Silero VAD v5 ONNX model (MIT).
        private const string SileroVadUrl =
            "https://github.com/snakers4/silero-vad/raw/master/src/silero_vad/data/silero_vad.onnx";

        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };

        private sealed class WhisperPreset
        {
            public string Name;
            public string Tag;
            public GgmlType Ggml;
            public string FileName;
            public bool IsCustom;
        }

        private List<WhisperPreset> _presets;

        // ---- pipeline fields ----
        private MediaBlocksPipeline _pipeline;
        private VideoRendererBlock _videoRenderer;
        private AudioRendererBlock _audioRenderer;
        private OverlayManagerBlock _overlay;
        private MediaBlock _videoSource;
        private MediaBlock _audioSource;
        private SpeechToTextBlock _sttBlock;
        private SubtitleRenderer _subtitleRenderer;

        private VideoCaptureDeviceInfo[] _videoDevices;
        private AudioCaptureDeviceInfo[] _audioDevices;
        private CancellationTokenSource _whisperDlCts;
        private CancellationTokenSource _vadDlCts;
        private bool _isClosing;
        private bool _running;

        public MainWindow()
        {
            InitializeComponent();
        }

        private List<WhisperPreset> BuildPresets()
        {
            Directory.CreateDirectory(ModelsCacheDir);
            return new List<WhisperPreset>
            {
                new WhisperPreset { Name = "Tiny (fastest)", Tag = "tiny", Ggml = GgmlType.Tiny, FileName = "ggml-tiny.bin" },
                new WhisperPreset { Name = "Base (real-time default)", Tag = "base", Ggml = GgmlType.Base, FileName = "ggml-base.bin" },
                new WhisperPreset { Name = "Small (more accurate)", Tag = "small", Ggml = GgmlType.Small, FileName = "ggml-small.bin" },
                new WhisperPreset { Name = "Custom model...", Tag = "custom", IsCustom = true },
            };
        }

        private WhisperPreset SelectedPreset()
        {
            var tag = ((cbModel.SelectedItem as ComboBoxItem)?.Tag as string) ?? "base";
            return _presets.FirstOrDefault(p => p.Tag == tag) ?? _presets[1];
        }

        private void Log(string message) => Dispatcher.Invoke(() => mmLog.Text += message + Environment.NewLine);

        // ---- lifecycle ----
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                try { await VisioForgeX.InitSDKAsync(); }
                finally { IsEnabled = true; }

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += (s, ev) => Log(ev.Message);
                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                _videoDevices = await SystemVideoSourceBlock.GetDevicesAsync() ?? Array.Empty<VideoCaptureDeviceInfo>();
                foreach (var d in _videoDevices) cbVideoInput.Items.Add(d.DisplayName);
                if (cbVideoInput.Items.Count > 0) cbVideoInput.SelectedIndex = 0;

                _audioDevices = await SystemAudioSourceBlock.GetDevicesAsync() ?? Array.Empty<AudioCaptureDeviceInfo>();
                foreach (var d in _audioDevices) cbAudioInput.Items.Add(d.DisplayName);
                if (cbAudioInput.Items.Count > 0) cbAudioInput.SelectedIndex = 0;

                _presets = BuildPresets();
                foreach (var p in _presets) cbModel.Items.Add(new ComboBoxItem { Content = p.Name, Tag = p.Tag });
                cbModel.SelectedIndex = 1; // Base

                // Pre-fill cached paths if present.
                var cachedVad = Path.Combine(ModelsCacheDir, "silero_vad.onnx");
                if (File.Exists(cachedVad)) edVadFile.Text = cachedVad;
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_isClosing) return;
            e.Cancel = true; _isClosing = true; IsEnabled = false;
            try
            {
                _whisperDlCts?.Cancel();
                _vadDlCts?.Cancel();
                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();
                    await _pipeline.DisposeAsync();
                    _pipeline = null;
                }

                CleanupBlocks();
                VideoView1.CallRefresh();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            try { _ = Dispatcher.BeginInvoke(new Action(() => Close())); }
            catch (Exception ex) { Debug.WriteLine(ex); _isClosing = false; IsEnabled = true; }
        }

        // ---- source UI ----
        private void rbSource_Checked(object sender, RoutedEventArgs e)
        {
            if (pnlWebcam == null) return;
            pnlWebcam.Visibility = rbWebcam.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            pnlFile.Visibility = rbFile.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btSelectVideoFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "Media files|*.mp4;*.mkv;*.avi;*.mov;*.webm;*.ts;*.wav;*.mp3|All files|*.*" };
            if (dlg.ShowDialog() == true) edVideoFile.Text = dlg.FileName;
        }

        private void btSelectModel_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "Whisper GGML models|*.bin|All files|*.*" };
            if (dlg.ShowDialog() == true) edModelFile.Text = dlg.FileName;
        }

        private void btSelectVad_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "ONNX models|*.onnx|All files|*.*" };
            if (dlg.ShowDialog() == true) edVadFile.Text = dlg.FileName;
        }

        private void btSelectSrt_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog { Filter = "SubRip subtitles|*.srt", FileName = "subtitles.srt" };
            if (dlg.ShowDialog() == true) edSrtFile.Text = dlg.FileName;
        }

        private void cbModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsInitialized || _presets == null) return;
            var p = SelectedPreset();
            if (p.IsCustom)
            {
                btDownloadModel.IsEnabled = false;
                return;
            }

            btDownloadModel.IsEnabled = true;
            var cached = Path.Combine(ModelsCacheDir, p.FileName);
            if (File.Exists(cached)) edModelFile.Text = cached;
        }

        private void cbVideoInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbVideoInput.SelectedIndex < 0 || e?.AddedItems.Count == 0) return;
                var device = _videoDevices?.FirstOrDefault(x => x.DisplayName == (string)e.AddedItems[0]);
                if (device == null) return;
                cbVideoFormat.Items.Clear();
                foreach (var f in device.VideoFormats) cbVideoFormat.Items.Add(f.Name);
                if (cbVideoFormat.Items.Count > 0) cbVideoFormat.SelectedIndex = 0;
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        private void cbVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbVideoFrameRate.Items.Clear();
                if (cbVideoInput.SelectedIndex < 0 || e?.AddedItems.Count == 0) return;
                var device = _videoDevices?.FirstOrDefault(x => x.DisplayName == cbVideoInput.SelectedValue?.ToString());
                var fmt = device?.VideoFormats.FirstOrDefault(x => x.Name == (string)e.AddedItems[0]);
                if (fmt == null) return;
                foreach (var r in fmt.GetFrameRateRangeAsStringList()) cbVideoFrameRate.Items.Add(r);
                if (cbVideoFrameRate.Items.Count > 0) cbVideoFrameRate.SelectedIndex = 0;
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        // ---- downloads ----
        private async void btDownloadModel_Click(object sender, RoutedEventArgs e)
        {
            var preset = SelectedPreset();
            if (preset.IsCustom) return;

            Directory.CreateDirectory(ModelsCacheDir);
            var destPath = Path.Combine(ModelsCacheDir, preset.FileName);
            var tempPath = destPath + ".part";

            _whisperDlCts?.Cancel();
            _whisperDlCts?.Dispose();
            _whisperDlCts = new CancellationTokenSource();
            var token = _whisperDlCts.Token;

            btDownloadModel.IsEnabled = false;
            btDownloadModel.Content = "...";
            Log($"Downloading Whisper {preset.Name}...");

            try
            {
                using (var modelStream = await WhisperGgmlDownloader.Default.GetGgmlModelAsync(preset.Ggml, cancellationToken: token))
                using (var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true))
                {
                    await modelStream.CopyToAsync(fileStream, token);
                }

                if (File.Exists(destPath)) File.Delete(destPath);
                File.Move(tempPath, destPath);
                edModelFile.Text = destPath;
                Log($"Saved Whisper model ({new FileInfo(destPath).Length / 1024 / 1024} MB).");
            }
            catch (OperationCanceledException) { TryDeleteTemp(tempPath); Log("Whisper download canceled."); }
            catch (Exception ex) { TryDeleteTemp(tempPath); Log("Whisper download failed: " + ex.Message); }
            finally { btDownloadModel.IsEnabled = true; btDownloadModel.Content = "Download"; }
        }

        private async void btDownloadVad_Click(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory(ModelsCacheDir);
            var destPath = Path.Combine(ModelsCacheDir, "silero_vad.onnx");
            var tempPath = destPath + ".part";

            _vadDlCts?.Cancel();
            _vadDlCts?.Dispose();
            _vadDlCts = new CancellationTokenSource();
            var token = _vadDlCts.Token;

            btDownloadVad.IsEnabled = false;
            btDownloadVad.Content = "...";
            Log("Downloading Silero VAD model...");

            try
            {
                using (var response = await _http.GetAsync(SileroVadUrl, HttpCompletionOption.ResponseHeadersRead, token))
                {
                    response.EnsureSuccessStatusCode();
                    using (var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true))
                    {
                        await response.Content.CopyToAsync(fileStream, token);
                    }
                }

                if (File.Exists(destPath)) File.Delete(destPath);
                File.Move(tempPath, destPath);
                edVadFile.Text = destPath;
                Log($"Saved Silero VAD model ({new FileInfo(destPath).Length / 1024} KB).");
            }
            catch (OperationCanceledException) { TryDeleteTemp(tempPath); Log("Silero download canceled."); }
            catch (Exception ex) { TryDeleteTemp(tempPath); Log("Silero download failed: " + ex.Message); }
            finally { btDownloadVad.IsEnabled = true; btDownloadVad.Content = "Download"; }
        }

        private static void TryDeleteTemp(string path)
        {
            try { if (File.Exists(path)) File.Delete(path); }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        // ---- options ----
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

        // ---- source builders ----
        private async System.Threading.Tasks.Task<bool> BuildSourcesAsync()
        {
            if (rbFile.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(edVideoFile.Text) || !File.Exists(edVideoFile.Text))
                {
                    MessageBox.Show(this, "Select a media file."); return false;
                }

                var src = new UniversalSourceBlock(await UniversalSourceSettings.CreateAsync(edVideoFile.Text, renderVideo: true, renderAudio: true));
                _videoSource = src;
                _audioSource = src; // same block exposes both VideoOutput and AudioOutput
                return true;
            }

            // Webcam + microphone.
            if (cbVideoInput.SelectedIndex < 0) { MessageBox.Show(this, "Select a video input device."); return false; }
            var device = _videoDevices?.FirstOrDefault(x => x.DisplayName == cbVideoInput.Text);
            var fmt = device?.VideoFormats.FirstOrDefault(x => x.Name == cbVideoFormat.Text);
            if (device == null || fmt == null) { MessageBox.Show(this, "Unable to configure the video device."); return false; }

            var vs = new VideoCaptureDeviceSourceSettings(device) { Format = fmt.ToFormat() };
            if (!string.IsNullOrEmpty(cbVideoFrameRate.Text))
                vs.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.Text, CultureInfo.InvariantCulture));
            _videoSource = new SystemVideoSourceBlock(vs);

            if (cbAudioInput.SelectedIndex < 0) { MessageBox.Show(this, "Select a microphone."); return false; }
            var audioDevice = _audioDevices?.FirstOrDefault(x => x.DisplayName == cbAudioInput.Text);
            if (audioDevice == null) { MessageBox.Show(this, "Unable to configure the microphone."); return false; }
            _audioSource = new SystemAudioSourceBlock(audioDevice.CreateSourceSettings());
            return true;
        }

        private MediaBlockPad VideoOutputPad()
            => _videoSource is UniversalSourceBlock u ? u.VideoOutput : _videoSource.Output;

        private MediaBlockPad AudioOutputPad()
            => _audioSource is UniversalSourceBlock u ? u.AudioOutput : _audioSource.Output;

        // ---- start / stop ----
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btStart.IsEnabled = false;
                if (_pipeline == null) { MessageBox.Show(this, "SDK failed to initialize."); btStart.IsEnabled = true; return; }

                mmLog.Clear();
                lbTranscript.Items.Clear();

                try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); }
                catch (Exception ex) { Debug.WriteLine(ex); }
                CleanupBlocks();

                if (string.IsNullOrWhiteSpace(edModelFile.Text) || !File.Exists(edModelFile.Text))
                {
                    MessageBox.Show(this, "Select or download a Whisper model."); btStart.IsEnabled = true; return;
                }

                var enableVad = cbEnableVad.IsChecked == true;
                if (enableVad && (string.IsNullOrWhiteSpace(edVadFile.Text) || !File.Exists(edVadFile.Text)))
                {
                    MessageBox.Show(this, "Select or download the Silero VAD model, or uncheck Enable VAD."); btStart.IsEnabled = true; return;
                }

                if (cbWriteSrt.IsChecked == true && string.IsNullOrWhiteSpace(edSrtFile.Text))
                {
                    MessageBox.Show(this, "Choose an .srt output path or uncheck 'Write .srt'."); btStart.IsEnabled = true; return;
                }

                if (!await BuildSourcesAsync()) { CleanupBlocks(); btStart.IsEnabled = true; return; }

                var provider = SelectedProvider();
                var settings = new SpeechToTextSettings(edModelFile.Text)
                {
                    Language = string.IsNullOrWhiteSpace(edLanguage.Text) ? "auto" : edLanguage.Text.Trim(),
                    Task = SelectedTask(),
                    Provider = provider,
                    EnableVad = enableVad,
                };
                settings.Vad.ModelPath = edVadFile.Text;
                settings.Vad.Provider = provider == OnnxExecutionProvider.CUDA ? OnnxExecutionProvider.CUDA : OnnxExecutionProvider.CPU;

                if (cbWriteSrt.IsChecked == true && !string.IsNullOrWhiteSpace(edSrtFile.Text))
                {
                    settings.OutputSrtPath = edSrtFile.Text;
                }

                var audioPad = AudioOutputPad();
                if (audioPad == null) { MessageBox.Show(this, "The selected source has no audio track to transcribe."); CleanupBlocks(); btStart.IsEnabled = true; return; }

                var videoPad = VideoOutputPad();
                var isFile = rbFile.IsChecked == true;

                _sttBlock = new SpeechToTextBlock(settings);
                _sttBlock.OnSpeechRecognized += SttBlock_OnSpeechRecognized;
                _audioRenderer = new AudioRendererBlock();

                // Audio branch: source -> speech-to-text (passthrough) -> audio renderer.
                if (!_pipeline.Connect(audioPad, _sttBlock.Input) || !_pipeline.Connect(_sttBlock.Output, _audioRenderer.Input))
                {
                    MessageBox.Show(this, "Failed to wire the audio branch."); CleanupBlocks(); btStart.IsEnabled = true; return;
                }

                // Video branch (only when the source has video): source -> overlay -> renderer.
                if (videoPad != null)
                {
                    _overlay = new OverlayManagerBlock();
                    _subtitleRenderer = new SubtitleRenderer(_overlay, new SubtitleStyle { X = 40, Y = 380, FontSize = 30 });
                    // Live capture renders unsynced (low latency); a file plays at its real rate (synced).
                    _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1) { IsSync = isFile };
                    if (!_pipeline.Connect(videoPad, _overlay.Input) || !_pipeline.Connect(_overlay.Output, _videoRenderer.Input))
                    {
                        MessageBox.Show(this, "Failed to wire the video branch."); CleanupBlocks(); btStart.IsEnabled = true; return;
                    }
                }
                else
                {
                    Log("Source has no video; transcribing audio only (subtitles overlay disabled).");
                }

                await _pipeline.StartAsync();
                _running = true;

                Log($"Started. VAD provider: {_sttBlock.ActiveProvider}. Whisper runtime auto-selected.");
                btStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                try { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); } catch { }
                CleanupBlocks(); btStart.IsEnabled = true; btStop.IsEnabled = false;
                Log(ex.Message);
            }
        }

        private void SttBlock_OnSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // Raised on the worker thread; marshal to the UI thread for the overlay and the list.
            Dispatcher.BeginInvoke(new Action(() =>
            {
                // A queued callback can arrive after Stop; drop it so it doesn't append to a cleared transcript.
                if (_isClosing || !_running) return;
                _subtitleRenderer?.OnSpeechRecognized(sender, e);
                foreach (var seg in e.Segments)
                {
                    if (!string.IsNullOrWhiteSpace(seg?.Text))
                    {
                        lbTranscript.Items.Add($"[{seg.StartTime:hh\\:mm\\:ss}] {seg.Text.Trim()}");
                    }
                }

                if (lbTranscript.Items.Count > 0)
                {
                    lbTranscript.ScrollIntoView(lbTranscript.Items[lbTranscript.Items.Count - 1]);
                }
            }));
        }

        private void CleanupBlocks()
        {
            _running = false;
            if (_sttBlock != null) { _sttBlock.OnSpeechRecognized -= SttBlock_OnSpeechRecognized; _sttBlock.Dispose(); _sttBlock = null; }
            _subtitleRenderer?.Dispose(); _subtitleRenderer = null;
            _overlay?.Dispose(); _overlay = null;
            _audioRenderer?.Dispose(); _audioRenderer = null;
            _videoRenderer?.Dispose(); _videoRenderer = null;

            // For a file source the same block is both video and audio; dispose once.
            if (ReferenceEquals(_videoSource, _audioSource))
            {
                _videoSource?.Dispose();
            }
            else
            {
                _videoSource?.Dispose();
                _audioSource?.Dispose();
            }

            _videoSource = null;
            _audioSource = null;
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btStop.IsEnabled = false;
                if (_pipeline != null) { await _pipeline.StopAsync(); _pipeline.ClearBlocks(); }
                CleanupBlocks();
                VideoView1.CallRefresh();
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            finally { btStart.IsEnabled = true; }
        }
    }
}
