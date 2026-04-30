using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEncoders;

namespace EncoderConcurrencyTest
{
    public partial class MainWindow : Window
    {
        private readonly List<PipelineTile> _tiles = new List<PipelineTile>();
        private readonly DispatcherTimer _statusTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };

        /// <summary>
        /// True while repopulating the encoder/decoder combos in response to a codec
        /// change. Suppresses side effects from SelectionChanged while we swap items.
        /// </summary>
        private bool _suppressComboEvents;

        /// <summary>
        /// Set once by <see cref="Window_Closing"/> to serialise the cancel/reissue
        /// pattern — the first close is cancelled, teardown runs, then we close for real.
        /// </summary>
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
                Title = originalTitle + $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                PopulateEncoderDecoderCombos();
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
                // Always restore a usable window — if init failed the user gets an
                // error MessageBox but the window must not be stuck disabled with
                // a "[initializing SDK...]" title suffix.
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

        private void BtConfigureWebcam_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new WebcamConfigDialog(_webcam) { Owner = this };
            if (dlg.ShowDialog() == true && dlg.Result != null)
            {
                _webcam = dlg.Result;
                lbWebcamSummary.Text = _webcam.Summary;
                lbWebcamSummary.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        /// <summary>
        /// Builds a fresh source block for the next tile. Each tile gets its own block
        /// instance — sharing source blocks across pipelines is not supported.
        /// Returns the block, its output pad and the (W, H, FPS) triple used by the tile
        /// for header text and bitrate computation.
        /// </summary>
        private async Task<(MediaBlock block, MediaBlockPad output, int width, int height, int fps)>
            BuildSourceAsync()
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

                    var camBlock = new SystemVideoSourceBlock(camSettings);
                    return (camBlock, camBlock.Output,
                            _webcam.Width, _webcam.Height,
                            (int)Math.Round(_webcam.FrameRate <= 0 ? 30 : _webcam.FrameRate));

                case SourceMode.Virtual:
                default:
                    var (w, h) = SelectedVirtualResolution();
                    var fps = SelectedVirtualFrameRate();
                    var virtSettings = new VirtualVideoSourceSettings(w, h, new VideoFrameRate(fps, 1));
                    var virtBlock = new VirtualVideoSourceBlock(virtSettings);
                    return (virtBlock, virtBlock.Output, w, h, fps);
            }
        }

        private string SourceLabel() => SelectedSourceMode() switch
        {
            SourceMode.Webcam => $"cam:{_webcam?.DeviceName ?? "?"}",
            _ => "virtual",
        };

        /// <summary>
        /// Rebuilds the encoder and decoder combos for the currently selected codec.
        /// The Auto entry is always first so existing muscle memory keeps working.
        /// </summary>
        private void PopulateEncoderDecoderCombos()
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

                cbDecoder.Items.Clear();
                foreach (var label in DecoderOptions(codec))
                {
                    cbDecoder.Items.Add(new ComboBoxItem { Content = label });
                }
                cbDecoder.SelectedIndex = 0;
            }
            finally
            {
                _suppressComboEvents = false;
            }
        }

        private void CbCodec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Fires during InitializeComponent before Loaded has run, so guard against
            // repopulating combos the SDK hasn't seen yet.
            if (!IsLoaded) return;
            if (_suppressComboEvents) return;

            PopulateEncoderDecoderCombos();
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

        private static IEnumerable<string> DecoderOptions(CodecChoice codec)
        {
            switch (codec)
            {
                case CodecChoice.HEVC:
                    yield return "Auto (HW if available)";
                    yield return "NVIDIA (NVDEC)";
                    yield return "AMD (AMF)";
                    yield return "Intel (QSV)";
                    yield return "D3D11 / DXVA";
                    yield return "FFmpeg (CPU)";
                    yield break;

                case CodecChoice.AV1:
                    yield return "Auto (HW if available)";
                    yield return "NVIDIA (NVDEC)";
                    yield return "dav1d (CPU)";
                    yield break;

                case CodecChoice.H264:
                default:
                    yield return "Auto (HW if available)";
                    yield return "NVIDIA (NVDEC)";
                    yield return "AMD (AMF)";
                    yield return "Intel (QSV)";
                    yield return "D3D11 / DXVA";
                    yield return "FFmpeg (CPU)";
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

        /// <summary>
        /// Maps the Encoder combo index to a concrete <see cref="EncoderChoice"/> in
        /// the context of the selected codec. Indices vary per codec because each
        /// codec has a slightly different list of available runtimes.
        /// </summary>
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

        private DecoderChoice SelectedDecoder()
        {
            var idx = cbDecoder.SelectedIndex;
            if (idx < 0) return DecoderChoice.Auto;

            switch (SelectedCodec())
            {
                case CodecChoice.HEVC:
                    return idx switch
                    {
                        1 => DecoderChoice.NVENC_NVDEC,
                        2 => DecoderChoice.AMF,
                        3 => DecoderChoice.QSV,
                        4 => DecoderChoice.D3D11,
                        5 => DecoderChoice.FFmpeg,
                        _ => DecoderChoice.Auto,
                    };

                case CodecChoice.AV1:
                    return idx switch
                    {
                        1 => DecoderChoice.NVENC_NVDEC,
                        2 => DecoderChoice.Dav1d,
                        _ => DecoderChoice.Auto,
                    };

                case CodecChoice.H264:
                default:
                    return idx switch
                    {
                        1 => DecoderChoice.NVENC_NVDEC,
                        2 => DecoderChoice.AMF,
                        3 => DecoderChoice.QSV,
                        4 => DecoderChoice.D3D11,
                        5 => DecoderChoice.FFmpeg,
                        6 => DecoderChoice.OpenH264,
                        _ => DecoderChoice.Auto,
                    };
            }
        }

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
            // BuildSourceAsync may throw (e.g. webcam not configured) — do that BEFORE
            // creating the tile so we don't leave a half-initialised UserControl behind.
            var (sourceBlock, sourceOutput, w, h, fps) = await BuildSourceAsync();

            var tile = new PipelineTile();
            _tiles.Add(tile);
            tilesPanel.Children.Add(tile);
            RefreshStatus();

            try
            {
                await tile.StartAsync(
                    pipelineIndex: _tiles.Count,
                    sourceBlock: sourceBlock,
                    sourceOutput: sourceOutput,
                    sourceLabel: SourceLabel(),
                    width: w,
                    height: h,
                    fps: fps,
                    codec: SelectedCodec(),
                    encoder: SelectedEncoder(),
                    decoder: SelectedDecoder());
            }
            catch
            {
                // Don't leave a half-initialised tile stranded in the UI.
                _tiles.Remove(tile);
                tilesPanel.Children.Remove(tile);
                try { tile.Dispose(); } catch { }
                RefreshStatus();
                throw;
            }

            RefreshStatus();
            return tile;
        }

        private async void BtFillToLimit_Click(object sender, RoutedEventArgs e)
        {
            // Hard safety ceiling so a runaway loop cannot flood memory if every runtime
            // keeps reporting success (e.g., a patched NVENC driver with no cap).
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

                    // Let the pipeline stabilize before queuing the next one — slot probes
                    // rely on the previous encoder actually reaching PLAYING.
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

            // Tile is already unreachable via _tiles / UI — if StopAsync throws
            // we still have to dispose it, otherwise the native pipeline leaks
            // for the rest of the session.
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
                // Per-tile try/finally — an exception tearing down tile N must not
                // abort the loop or we leak every remaining tile's GPU session.
                try { await t.StopAsync(); }
                catch (Exception ex) { Debug.WriteLine(ex); }
                finally { try { t.Dispose(); } catch { } }
            }

            RefreshStatus();
        }

        private void RefreshStatus()
        {
            // Count tiles by their actual resolved encoder type. This is independent of
            // EncoderRuntimeTracker (which only sees sessions routed through Auto*
            // settings) — we want a live count that works for the explicit-runtime
            // picks the demo now uses exclusively.
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
            // after the first `await` below — every subsequent line then runs against a
            // dead dispatcher and DestroySDK is typically skipped, orphaning native
            // pipelines. Cancel the first pass, run full teardown, then reissue Close().
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
                    // Per-tile try/finally — an exception on tile N must not abort
                    // teardown of the remaining tiles.
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

    /// <summary>
    /// Source kind the tile is built around — drives which source block the main
    /// window passes to the tile.
    /// </summary>
    public enum SourceMode
    {
        Virtual,
        Webcam,
    }

    /// <summary>
    /// Codec family the tile encodes with. Drives which encoder / decoder block
    /// classes the tile instantiates.
    /// </summary>
    public enum CodecChoice
    {
        H264,
        HEVC,
        AV1,
    }

    /// <summary>
    /// Encoder selection exposed in the top-bar combo. Not every value is valid for
    /// every codec — the tile's encoder-builder switches on <see cref="CodecChoice"/>
    /// and rejects combinations that have no implementation (e.g., MediaFoundation
    /// for AV1, OpenH264 for HEVC).
    /// </summary>
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

    /// <summary>
    /// Decoder selection. NVDEC/AMF/QSV are hardware and have their own session caps;
    /// FFmpeg, OpenH264, and dav1d run on CPU with no GPU session pressure.
    /// </summary>
    public enum DecoderChoice
    {
        Auto,
        NVENC_NVDEC,
        AMF,
        QSV,
        D3D11,
        FFmpeg,
        OpenH264,
        Dav1d,
    }
}
