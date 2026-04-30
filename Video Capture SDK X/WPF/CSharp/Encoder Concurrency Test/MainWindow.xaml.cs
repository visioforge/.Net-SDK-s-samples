using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using VisioForge.Core;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoCapture;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Windows;

namespace EncoderConcurrencyTestX
{
    public partial class MainWindow : Window
    {
        private readonly List<PipelineTile> _tiles = new List<PipelineTile>();
        private readonly DispatcherTimer _statusTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };

        private bool _suppressComboEvents;
        private bool _shuttingDown;

        /// <summary>
        /// Result of the most recent webcam-config dialog. Null until the user picks a
        /// camera. Reused for every "Add pipeline" / "Fill to limit" while Source mode
        /// is "Webcam"; cleared when the user reconfigures.
        /// </summary>
        private WebcamSelection _webcam;

        public MainWindow()
        {
            InitializeComponent();
            _statusTimer.Tick += (_, __) => RefreshStatus();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var originalTitle = Title;
            try
            {
                Title = originalTitle + " [initializing SDK...]";
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                Title = originalTitle + $" (SDK v{VideoCaptureCoreX.SDK_Version})";

                PopulateAdapters();
                PopulateEncoderCombo();
                ApplySourceMode();
                _statusTimer.Start();
                RefreshStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SDK init failed: " + ex.Message);
            }
            finally
            {
                if (Title.Contains(" [initializing SDK...]"))
                {
                    Title = originalTitle;
                }

                IsEnabled = true;
            }
        }

        // ================================================================
        //  Source-type selection
        // ================================================================

        private SourceMode SelectedSourceMode() => cbSourceMode.SelectedIndex switch
        {
            1 => SourceMode.Webcam,
            _ => SourceMode.Virtual,
        };

        private void CbSourceMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsLoaded) return;
            ApplySourceMode();
        }

        private void ApplySourceMode()
        {
            var mode = SelectedSourceMode();
            pnVirtualSource.Visibility = mode == SourceMode.Virtual ? Visibility.Visible : Visibility.Collapsed;
            pnWebcamSource.Visibility  = mode == SourceMode.Webcam  ? Visibility.Visible : Visibility.Collapsed;
        }

        private async void BtConfigureWebcam_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new WebcamConfigDialog(_webcam) { Owner = this };
            if (dlg.ShowDialog() == true && dlg.Result != null)
            {
                _webcam = dlg.Result;
                lbWebcamSummary.Text = _webcam.Summary;
                lbWebcamSummary.Foreground = System.Windows.Media.Brushes.Black;
            }
            await Task.CompletedTask;
        }

        // ================================================================
        //  Adapters / encoders
        // ================================================================

        private void PopulateAdapters()
        {
            cbAdapter.Items.Clear();
            cbAdapter.Items.Add("Any");

            foreach (var a in EncoderAdapters())
            {
                cbAdapter.Items.Add(FormatAdapterLabel(a));
            }

            cbAdapter.SelectedIndex = 0;
        }

        private static IEnumerable<EncoderAdapterInfo> EncoderAdapters()
        {
            foreach (var a in DXGIAdapterEnumerator.Enumerate())
            {
                if (a.IsSoftware) continue;

                // VendorId 0x1414 = Microsoft (WARP, Basic Render Driver, IDD shims).
                if (a.VendorId == 0x1414) continue;

                yield return a;
            }
        }

        private static string FormatAdapterLabel(EncoderAdapterInfo a)
        {
            var vendor = a.VendorId switch
            {
                0x10DE => "NVIDIA",
                0x1002 => "AMD",
                0x8086 => "Intel",
                0x1414 => "Microsoft",
                _ => $"0x{a.VendorId:X4}",
            };

            var vram = a.DedicatedVideoMemory > 0
                ? $"{a.DedicatedVideoMemory / (1024 * 1024)} MB"
                : "UMA";

            return $"{vendor}: {a.Description} ({vram}, LUID {a.Luid})";
        }

        private void PopulateEncoderCombo()
        {
            _suppressComboEvents = true;
            try
            {
                var codec = SelectedCodec();

                cbEncoder.Items.Clear();
                foreach (var label in EncoderOptions(codec))
                {
                    cbEncoder.Items.Add(new ComboBoxItem { Content = label });
                }
                cbEncoder.SelectedIndex = 0;
            }
            finally
            {
                _suppressComboEvents = false;
            }
        }

        private void CbCodec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsLoaded) return;
            if (_suppressComboEvents) return;

            PopulateEncoderCombo();
        }

        private static IEnumerable<string> EncoderOptions(CodecChoice codec)
        {
            switch (codec)
            {
                case CodecChoice.HEVC:
                    yield return "AMD (AMF)";
                    yield return "NVIDIA (NVENC)";
                    yield return "Intel (QSV)";
                    yield return "Media Foundation";
                    yield return "D3D12";
                    yield break;

                case CodecChoice.AV1:
                    yield return "AMD (AMF)";
                    yield return "NVIDIA (NVENC)";
                    yield return "Intel (QSV)";
                    yield return "SVT-AV1 (CPU)";
                    yield return "rav1e (CPU)";
                    yield return "AOM AV1 (CPU)";
                    yield break;

                case CodecChoice.H264:
                default:
                    yield return "AMD (AMF)";
                    yield return "NVIDIA (NVENC)";
                    yield return "Intel (QSV)";
                    yield return "Media Foundation";
                    yield return "D3D12";
                    yield return "OpenH264 (CPU)";
                    yield break;
            }
        }

        private (int width, int height) SelectedVirtualResolution()
        {
            return cbResolution.SelectedIndex switch
            {
                0 => (3840, 2160),
                2 => (1280, 720),
                3 => (854, 480),
                _ => (1920, 1080),
            };
        }

        private int SelectedVirtualFrameRate() => cbFrameRate.SelectedIndex switch
        {
            1 => 30,
            2 => 25,
            _ => 60,
        };

        private CodecChoice SelectedCodec() => cbCodec.SelectedIndex switch
        {
            1 => CodecChoice.HEVC,
            2 => CodecChoice.AV1,
            _ => CodecChoice.H264,
        };

        private EncoderChoice SelectedEncoder()
        {
            var idx = cbEncoder.SelectedIndex;
            if (idx < 0) idx = 0;

            switch (SelectedCodec())
            {
                case CodecChoice.HEVC:
                    return idx switch
                    {
                        1 => EncoderChoice.NVENC,
                        2 => EncoderChoice.QSV,
                        3 => EncoderChoice.MediaFoundation,
                        4 => EncoderChoice.D3D12,
                        _ => EncoderChoice.AMF,
                    };

                case CodecChoice.AV1:
                    return idx switch
                    {
                        1 => EncoderChoice.NVENC,
                        2 => EncoderChoice.QSV,
                        3 => EncoderChoice.SVTAV1,
                        4 => EncoderChoice.RAV1E,
                        5 => EncoderChoice.AOM,
                        _ => EncoderChoice.AMF,
                    };

                case CodecChoice.H264:
                default:
                    return idx switch
                    {
                        1 => EncoderChoice.NVENC,
                        2 => EncoderChoice.QSV,
                        3 => EncoderChoice.MediaFoundation,
                        4 => EncoderChoice.D3D12,
                        5 => EncoderChoice.OpenH264,
                        _ => EncoderChoice.AMF,
                    };
            }
        }

        private long? SelectedAdapterLuid()
        {
            if (cbAdapter.SelectedIndex <= 0) return null;
            var adapters = EncoderAdapters().ToList();
            var idx = cbAdapter.SelectedIndex - 1;
            if (idx < 0 || idx >= adapters.Count) return null;
            return adapters[idx].Luid;
        }

        // ================================================================
        //  Source-settings construction
        // ================================================================

        /// <summary>
        /// Builds a fresh source-settings instance for the next tile. Each tile gets its
        /// own object — sharing one settings instance across multiple cores has caused
        /// odd state-bleed in the past.
        /// </summary>
        private async Task<(IVideoCaptureBaseVideoSourceSettings settings, int width, int height, int fps)>
            BuildSourceSettingsAsync()
        {
            switch (SelectedSourceMode())
            {
                case SourceMode.Webcam:
                    if (_webcam == null)
                    {
                        throw new InvalidOperationException("No webcam configured. Click \"Configure webcam...\" first.");
                    }

                    var device = (await DeviceEnumerator.Shared.VideoSourcesAsync())
                        .FirstOrDefault(d => d.DisplayName == _webcam.DeviceName);
                    if (device == null)
                    {
                        throw new InvalidOperationException(
                            $"Camera \"{_webcam.DeviceName}\" is no longer available. Reconfigure.");
                    }

                    var formatItem = device.VideoFormats.FirstOrDefault(f => f.Name == _webcam.FormatName);
                    if (formatItem == null)
                    {
                        throw new InvalidOperationException(
                            $"Format \"{_webcam.FormatName}\" is no longer available. Reconfigure.");
                    }

                    var camSettings = new VideoCaptureDeviceSourceSettings(device)
                    {
                        Format = formatItem.ToFormat()
                    };
                    if (!string.IsNullOrEmpty(_webcam.FrameRateText))
                    {
                        camSettings.Format.FrameRate = new VideoFrameRate(_webcam.FrameRate);
                    }

                    return (camSettings,
                            _webcam.Width,
                            _webcam.Height,
                            (int)Math.Round(_webcam.FrameRate <= 0 ? 30 : _webcam.FrameRate));

                case SourceMode.Virtual:
                default:
                    var (w, h) = SelectedVirtualResolution();
                    var fps = SelectedVirtualFrameRate();
                    var virt = new VirtualVideoSourceSettings(w, h, new VideoFrameRate(fps, 1));
                    return (virt, w, h, fps);
            }
        }

        // ================================================================
        //  Tile management
        // ================================================================

        private async void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await AddTileAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Failed to add pipeline: " + ex.Message);
            }
        }

        private async Task<PipelineTile> AddTileAsync()
        {
            var (sourceSettings, w, h, fps) = await BuildSourceSettingsAsync();

            var tile = new PipelineTile();
            _tiles.Add(tile);
            tilesPanel.Children.Add(tile);
            RefreshStatus();

            try
            {
                await tile.StartAsync(
                    pipelineIndex: _tiles.Count,
                    sourceSettings: sourceSettings,
                    sourceLabel: SourceLabel(),
                    width: w,
                    height: h,
                    fps: fps,
                    codec: SelectedCodec(),
                    encoder: SelectedEncoder(),
                    adapterLuid: SelectedAdapterLuid());
            }
            catch
            {
                _tiles.Remove(tile);
                tilesPanel.Children.Remove(tile);
                try { tile.Dispose(); } catch { }
                RefreshStatus();
                throw;
            }

            RefreshStatus();
            return tile;
        }

        private string SourceLabel() => SelectedSourceMode() switch
        {
            SourceMode.Webcam => $"cam:{_webcam?.DeviceName ?? "?"}",
            _ => "virtual",
        };

        private async void BtFillToLimit_Click(object sender, RoutedEventArgs e)
        {
            const int hardCeiling = 32;

            SetButtonsEnabled(false);
            try
            {
                var startCount = _tiles.Count;
                while (_tiles.Count < startCount + hardCeiling)
                {
                    PipelineTile tile;
                    try
                    {
                        tile = await AddTileAsync();
                    }
                    catch (Exception ex)
                    {
                        lbStatus.Text = $"Fill stopped after {_tiles.Count - startCount} tiles: {ex.Message}";
                        return;
                    }

                    if (tile.StartFailed)
                    {
                        lbStatus.Text =
                            $"Fill hit limit after {_tiles.Count - startCount - 1} successful tiles. " +
                            $"Last error: {tile.LastStatus}";
                        return;
                    }

                    await Task.Delay(300);
                }

                lbStatus.Text = $"Fill ceiling reached ({hardCeiling} tiles). No runtime refused.";
            }
            finally
            {
                SetButtonsEnabled(true);
                RefreshStatus();
            }
        }

        private void SetButtonsEnabled(bool enabled)
        {
            btAdd.IsEnabled = enabled;
            btFillToLimit.IsEnabled = enabled;
            btRemoveLast.IsEnabled = enabled;
            btStopAll.IsEnabled = enabled;
            btConfigureWebcam.IsEnabled = enabled;
        }

        private async void BtRemoveLast_Click(object sender, RoutedEventArgs e)
        {
            if (_tiles.Count == 0) return;
            var tile = _tiles[_tiles.Count - 1];
            _tiles.RemoveAt(_tiles.Count - 1);
            tilesPanel.Children.Remove(tile);

            try { await tile.StopAsync(); }
            catch (Exception ex) { Debug.WriteLine(ex); }
            finally { try { tile.Dispose(); } catch { } }

            RefreshStatus();
        }

        private async void BtStopAll_Click(object sender, RoutedEventArgs e)
        {
            var tiles = _tiles.ToArray();
            _tiles.Clear();
            tilesPanel.Children.Clear();

            foreach (var t in tiles)
            {
                try { await t.StopAsync(); }
                catch (Exception ex) { Debug.WriteLine(ex); }
                finally { try { t.Dispose(); } catch { } }
            }

            RefreshStatus();
        }

        private void RefreshStatus()
        {
            var counts = new Dictionary<string, int>();
            foreach (var tile in _tiles)
            {
                if (string.IsNullOrEmpty(tile.ResolvedRuntimeLabel)) continue;
                counts.TryGetValue(tile.ResolvedRuntimeLabel, out var c);
                counts[tile.ResolvedRuntimeLabel] = c + 1;
            }

            var parts = new List<string>();
            foreach (var kv in counts.OrderBy(kv => kv.Key))
            {
                parts.Add($"{kv.Key}={kv.Value}");
            }

            lbStatus.Text = $"Pipelines: {_tiles.Count}. " +
                (parts.Count == 0 ? "No running tiles." : string.Join("  ", parts));
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Without cancelling the first close, WPF tears the window down immediately
            // after the first await — every subsequent line then runs against a dead
            // dispatcher and DestroySDK is typically skipped, orphaning native pipelines.
            if (_shuttingDown) return;
            _shuttingDown = true;
            e.Cancel = true;

            try
            {
                _statusTimer.Stop();

                var tiles = _tiles.ToArray();
                _tiles.Clear();
                foreach (var t in tiles)
                {
                    try { await t.StopAsync(); }
                    catch (Exception ex) { Debug.WriteLine(ex); }
                    finally { try { t.Dispose(); } catch { } }
                }

                await Task.Delay(300);

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                Close();
            }
        }
    }

    public enum SourceMode
    {
        Virtual,
        Webcam,
    }

    public enum CodecChoice
    {
        H264,
        HEVC,
        AV1,
    }

    public enum EncoderChoice
    {
        AMF,
        NVENC,
        QSV,
        MediaFoundation,
        D3D12,
        OpenH264,
        SVTAV1,
        RAV1E,
        AOM,
    }
}
