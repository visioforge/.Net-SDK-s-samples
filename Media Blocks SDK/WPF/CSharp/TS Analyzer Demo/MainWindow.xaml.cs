using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

using Microsoft.Win32;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.Special;

namespace TS_Analyzer_Demo
{
    /// <summary>
    /// Demonstrates <c>TSAnalyzerBlock</c>: analyzes an MPEG transport stream from a
    /// local file or a live UDP / SRT broadcast and displays the discovered services,
    /// PIDs, per-PID bitrate and integrity (PCR / continuity) statistics.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;
        private TSAnalyzerBlock _analyzer;
        private readonly ObservableCollection<PidRow> _rows = new ObservableCollection<PidRow>();

        public MainWindow()
        {
            InitializeComponent();
            gridPids.ItemsSource = _rows;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                Title += " [INITIALIZING...]";
                await VisioForgeX.InitSDKAsync();
                Title = Title.Replace(" [INITIALIZING...]", string.Empty);
                IsEnabled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await StopAsync();
            VisioForgeX.DestroySDK();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "MPEG-TS files (*.ts;*.m2ts)|*.ts;*.m2ts|All files (*.*)|*.*",
            };

            if (dlg.ShowDialog() == true)
            {
                edSource.Text = dlg.FileName;
            }
        }

        private async void btnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            await StartAsync();
        }

        private async void btnStop_Click(object sender, RoutedEventArgs e)
        {
            await StopAsync();
        }

        private async System.Threading.Tasks.Task StartAsync()
        {
            await StopAsync();

            var source = edSource.Text?.Trim();
            if (string.IsNullOrEmpty(source))
            {
                MessageBox.Show("Please specify a source file or udp:// / srt:// URL.");
                return;
            }

            _rows.Clear();
            lblSummary.Text = "Starting...";

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += (s, ev) => Dispatcher.BeginInvoke(() => lblSummary.Text = "Error: " + ev.Message);
            _pipeline.OnStop += Pipeline_OnStop;

            MediaBlockPad sourcePad;
            try
            {
                sourcePad = await CreateSourcePadAsync(source);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to create source: " + ex.Message);
                _pipeline.Dispose();
                _pipeline = null;
                return;
            }

            _analyzer = new TSAnalyzerBlock(TSAnalyzerMode.Input,
                new TSAnalyzerSettings { StatisticsInterval = TimeSpan.FromSeconds(1) });
            _analyzer.OnAnalysisUpdated += Analyzer_OnAnalysisUpdated;

            try
            {
                _pipeline.Connect(sourcePad, _analyzer.Input);
                await _pipeline.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to start analysis: " + ex.Message);
                await StopAsync();
                return;
            }

            btnAnalyze.IsEnabled = false;
            btnStop.IsEnabled = true;
        }

        private async System.Threading.Tasks.Task<MediaBlockPad> CreateSourcePadAsync(string source)
        {
            if (source.StartsWith("udp://", StringComparison.OrdinalIgnoreCase))
            {
                var block = new UDPRAWMPEGTSSourceBlock(new UDPRAWMPEGTSSourceSettings(source));
                return block.Output;
            }

            if (source.StartsWith("srt://", StringComparison.OrdinalIgnoreCase))
            {
                var settings = await SRTSourceSettings.CreateAsync(new Uri(source), ignoreMediaInfoReader: true);
                var block = new SRTRAWSourceBlock(settings);
                return block.Output;
            }

            return new BasicFileSourceBlock(source).Output;
        }

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            // A file source reaches end-of-stream here; reset the UI to idle so the run
            // visibly finishes (the final cumulative report is already displayed). Live
            // UDP/SRT sources only reach here on a manual Stop. OnStop fires on a
            // GStreamer streaming thread, so marshal to the UI thread. The btnStop guard
            // makes this a no-op if a manual Stop already tore the pipeline down.
            // InvokeAsync with an async lambda (not BeginInvoke(new Action(async ...)))
            // so the continuation is an awaitable Task, not an unobserved async void.
            Dispatcher.InvokeAsync(async () =>
            {
                if (btnStop.IsEnabled)
                {
                    await StopAsync();
                    lblSummary.Text += "  |  completed";
                }
            });
        }

        private void Analyzer_OnAnalysisUpdated(object sender, TSAnalyzerEventArgs e)
        {
            var report = e.Report;
            Dispatcher.BeginInvoke(() => UpdateUI(report));
        }

        private void UpdateUI(TSAnalyzerReport report)
        {
            // Defensive: the analyzer always dispatches a non-null snapshot, but guard the
            // marshalled UI callback so a null report can never crash the demo window.
            if (report == null)
            {
                return;
            }

            // Map PID -> owning program number and elementary-stream descriptor for display.
            var pidToProgram = new Dictionary<int, int>();
            var pidToStream = new Dictionary<int, TSElementaryStreamInfo>();
            foreach (var program in report.Programs)
            {
                foreach (var es in program.Streams)
                {
                    pidToProgram[es.Pid] = program.ProgramNumber;
                    pidToStream[es.Pid] = es;
                }
            }

            // Update the grid in place instead of Clear()+rebuild: match each reported PID to
            // an existing row by PID, update its fields (INotifyPropertyChanged refreshes only
            // the changed cells), insert new PIDs, move rows into the bitrate-sorted order, and
            // remove PIDs that disappeared. This avoids the per-row CollectionChanged storm that
            // caused DataGrid flicker and lost selection/scroll on every tick.
            var ordered = report.Pids.OrderByDescending(p => p.BitrateKbps).ToList();

            // Drop rows whose PID is no longer present.
            var presentPids = new HashSet<int>(ordered.Select(p => p.Pid));
            for (int i = _rows.Count - 1; i >= 0; i--)
            {
                if (!presentPids.Contains(_rows[i].Pid))
                {
                    _rows.RemoveAt(i);
                }
            }

            for (int target = 0; target < ordered.Count; target++)
            {
                var pid = ordered[target];
                pidToStream.TryGetValue(pid.Pid, out var es);

                // Find the existing row for this PID (search from the target position onward).
                int existing = -1;
                for (int i = target; i < _rows.Count; i++)
                {
                    if (_rows[i].Pid == pid.Pid)
                    {
                        existing = i;
                        break;
                    }
                }

                PidRow row;
                if (existing < 0)
                {
                    row = new PidRow { Pid = pid.Pid };
                    _rows.Insert(target, row);
                }
                else
                {
                    if (existing != target)
                    {
                        _rows.Move(existing, target);
                    }

                    row = _rows[target];
                }

                row.Program = pidToProgram.TryGetValue(pid.Pid, out var prog) ? prog.ToString() : string.Empty;
                row.Kind = pid.Kind.ToString();
                row.StreamType = pid.StreamType != 0 ? "0x" + pid.StreamType.ToString("X2") : string.Empty;
                row.Codec = pid.Codec;
                row.Bitrate = pid.BitrateKbps.ToString("F0");
                row.PeakBitrate = pid.PeakBitrateKbps > 0 ? pid.PeakBitrateKbps.ToString("F0") : string.Empty;
                row.Language = es?.Language ?? string.Empty;
                row.Packets = pid.PacketCount;
                row.CcErrors = pid.ContinuityErrors;
                row.IsPcr = pid.IsPcrPid;
                row.IsScrambled = pid.IsScrambled;
            }

            UpdateTr101290(report);

            var pcr = report.Pcr.FirstOrDefault();
            var pcrText = pcr != null
                ? $"PCR PID {pcr.Pid}: {pcr.AvgIntervalMs:F1} ms avg, {pcr.Discontinuities} discontinuities"
                : "no PCR";

            // Service / provider / type from the first program.
            var svcText = string.Empty;
            var firstProgram = report.Programs.FirstOrDefault();
            if (firstProgram != null && (!string.IsNullOrEmpty(firstProgram.ServiceName) ||
                                         !string.IsNullOrEmpty(firstProgram.ServiceProvider)))
            {
                var name = string.IsNullOrEmpty(firstProgram.ServiceName) ? "?" : firstProgram.ServiceName;
                var provider = string.IsNullOrEmpty(firstProgram.ServiceProvider) ? "?" : firstProgram.ServiceProvider;
                svcText = $" | service: {name} / {provider}";
            }

            // Null-padding percentage relative to total bitrate, plus effective payload rate.
            var nullText = string.Empty;
            if (report.TotalBitrateKbps > 0)
            {
                var nullPct = report.NullBitrateKbps / report.TotalBitrateKbps * 100.0;
                nullText = $" | null: {nullPct:F1}% | effective: {report.EffectiveBitrateKbps:F0} kbps";
            }

            var netText = string.IsNullOrEmpty(report.NetworkName) ? string.Empty : $" | network: {report.NetworkName}";
            var timeText = report.StreamTimeUtc.HasValue
                ? $" | stream UTC: {report.StreamTimeUtc.Value:yyyy-MM-dd HH:mm:ss}"
                : string.Empty;

            // Codec details for the first video PID, surfaced via tooltip on the summary line.
            var videoStream = report.Programs.SelectMany(p => p.Streams)
                .FirstOrDefault(s => s.Kind == TSPidKind.Video && s.CodecDetails != null);
            if (videoStream != null)
            {
                var cd = videoStream.CodecDetails;
                var fps = cd.FrameRateDen > 0 ? (double)cd.FrameRateNum / cd.FrameRateDen : 0.0;
                lblSummary.ToolTip = $"Video PID {videoStream.Pid} ({videoStream.Codec}): " +
                                     $"{cd.Width}x{cd.Height}" +
                                     (fps > 0 ? $" @ {fps:F2} fps" : string.Empty) +
                                     (!string.IsNullOrEmpty(cd.Profile) ? $", profile {cd.Profile}" : string.Empty) +
                                     (!string.IsNullOrEmpty(cd.Level) ? $", level {cd.Level}" : string.Empty) +
                                     (!string.IsNullOrEmpty(cd.ChromaFormat) ? $", chroma {cd.ChromaFormat}" : string.Empty) +
                                     (!string.IsNullOrEmpty(cd.AspectRatio) ? $", aspect {cd.AspectRatio}" : string.Empty);
            }
            else
            {
                lblSummary.ToolTip = null;
            }

            // Audio/video synchronization offset (video PTS minus audio PTS).
            var avSyncText = report.AvSyncMs.HasValue
                ? $" | A/V sync: {report.AvSyncMs.Value:F0} ms"
                : string.Empty;

            lblSummary.Text = $"Packet size: {report.PacketSize} | total: {report.TotalBitrateKbps:F0} kbps | " +
                              $"packets: {report.TotalPackets} | programs: {report.Programs.Count} | " +
                              $"PAT: {(report.HasPAT ? "yes" : "no")} | transport errors: {report.TransportErrors} | " +
                              $"{pcrText}{svcText}{nullText}{netText}{timeText}{avSyncText}";
        }

        private void UpdateTr101290(TSAnalyzerReport report)
        {
            var lines = new List<string>();

            var tr = report.Tr101290;
            if (tr == null)
            {
                lines.Add("TR 101 290: not evaluated.");
                expTr101290.Background = null;
            }
            else
            {
                lines.Add($"TR 101 290 errors: P1={tr.P1Count}  P2={tr.P2Count}  P3={tr.P3Count}  (total {tr.TotalCount})");

                // List only the checks that fired, grouped by priority.
                var failing = tr.Checks.Where(c => c.Count > 0).OrderBy(c => c.Priority).ThenBy(c => c.Name).ToList();
                foreach (var check in failing)
                {
                    lines.Add($"   P{check.Priority} {check.Name}: {check.Count}");
                }

                // Highlight when any priority group reported an error.
                expTr101290.Background = tr.TotalCount > 0
                    ? new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFF, 0xE0, 0xE0))
                    : null;
            }

            // EPG events, when EPG parsing produced any.
            if (report.Events.Count > 0)
            {
                lines.Add(string.Empty);
                lines.Add($"EPG events ({report.Events.Count}):");
                foreach (var ev in report.Events.Take(20))
                {
                    var start = ev.StartTimeUtc.HasValue ? ev.StartTimeUtc.Value.ToString("yyyy-MM-dd HH:mm") : "?";
                    var name = string.IsNullOrEmpty(ev.Name) ? "(no name)" : ev.Name;
                    lines.Add($"   svc {ev.ServiceId} #{ev.EventId} {start} +{ev.Duration:hh\\:mm\\:ss}  {name}");
                }
            }

            lblTr101290.Text = string.Join(Environment.NewLine, lines);
        }

        private async System.Threading.Tasks.Task StopAsync()
        {
            // Claim the pipeline and disable Stop BEFORE the first await. StopAsync runs
            // on the UI thread but yields at the await; capturing+nulling the field here
            // makes a rapid second Stop click (or a concurrent EOS) a no-op instead of
            // tearing the same pipeline down twice.
            var pipeline = _pipeline;
            if (pipeline == null)
            {
                return;
            }

            _pipeline = null;
            btnStop.IsEnabled = false;

            // Detach the EOS handler before the forced stop so it cannot re-enter
            // StopAsync (the forced stop itself raises OnStop).
            pipeline.OnStop -= Pipeline_OnStop;

            try
            {
                await pipeline.StopAsync(force: true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            if (_analyzer != null)
            {
                _analyzer.OnAnalysisUpdated -= Analyzer_OnAnalysisUpdated;
                _analyzer = null;
            }

            pipeline.Dispose();

            btnAnalyze.IsEnabled = true;
        }
    }

    /// <summary>
    /// Row model bound to the PID grid. Implements <see cref="INotifyPropertyChanged"/> so the
    /// grid refreshes individual cells when a row is updated in place (instead of being cleared
    /// and rebuilt every tick, which caused flicker and lost selection/scroll).
    /// </summary>
    public class PidRow : INotifyPropertyChanged
    {
        private int _pid;
        private string _program;
        private string _kind;
        private string _streamType;
        private string _codec;
        private string _bitrate;
        private string _peakBitrate;
        private string _language;
        private long _packets;
        private long _ccErrors;
        private bool _isPcr;
        private bool _isScrambled;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Pid { get => _pid; set => SetField(ref _pid, value); }

        public string Program { get => _program; set => SetField(ref _program, value); }

        public string Kind { get => _kind; set => SetField(ref _kind, value); }

        public string StreamType { get => _streamType; set => SetField(ref _streamType, value); }

        public string Codec { get => _codec; set => SetField(ref _codec, value); }

        public string Bitrate { get => _bitrate; set => SetField(ref _bitrate, value); }

        public string PeakBitrate { get => _peakBitrate; set => SetField(ref _peakBitrate, value); }

        public string Language { get => _language; set => SetField(ref _language, value); }

        public long Packets { get => _packets; set => SetField(ref _packets, value); }

        public long CcErrors { get => _ccErrors; set => SetField(ref _ccErrors, value); }

        public bool IsPcr { get => _isPcr; set => SetField(ref _isPcr, value); }

        public bool IsScrambled { get => _isScrambled; set => SetField(ref _isScrambled, value); }

        private void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return;
            }

            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
