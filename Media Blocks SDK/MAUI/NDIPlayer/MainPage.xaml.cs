using System.Diagnostics;
using System.Threading;
using Microsoft.Maui.ApplicationModel;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;

namespace NDIPlayer
{
    public partial class MainPage : ContentPage
    {
        private static readonly TimeSpan ShutdownStopTimeout = TimeSpan.FromSeconds(10);

        private readonly SemaphoreSlim _pipelineLock = new(1, 1);

        private MediaBlocksPipeline _pipeline;

        private NDISourceBlock _ndiSource;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private NDISourceInfo[] _availableSources = Array.Empty<NDISourceInfo>();

        private CancellationTokenSource _refreshCts;

        private bool _isPlaying;

        private bool _destroyed;

        private int _refreshVersion;

        private int _started;

        private int _shutdownStarted;

        public MainPage()
        {
            TraceLog("ctor enter");
            InitializeComponent();

            TraceLog("calling VisioForgeX.InitSDK");
            VisioForgeX.InitSDK();
            TraceLog("VisioForgeX.InitSDK returned");

            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;
            TraceLog("ctor exit; Loaded/Unloaded subscribed");
        }

        private void MainPage_Loaded(object sender, EventArgs e)
        {
            TraceLog($"Loaded enter; Window={(Window == null ? "<null>" : Window.GetType().FullName)}");

            if (Interlocked.Exchange(ref _started, 1) != 0)
            {
                TraceLog("Loaded ignored because page is already started");
                return;
            }

            if (Window != null)
            {
                Window.Destroying += Page_Window_Destroying;
                TraceLog("Loaded subscribed page-level Window.Destroying");
            }

            TraceLog("Subscribing DeviceEnumerator.NDISourcesChanged");
            DeviceEnumerator.Shared.NDISourcesChanged += OnNDISourcesChanged;
            TraceLog("Calling DeviceEnumerator.StartNDISourceWatch");
            DeviceEnumerator.Shared.StartNDISourceWatch();
            TraceLog("DeviceEnumerator.StartNDISourceWatch returned");

            TraceLog("Starting initial RefreshSourcesAsync fire-and-forget");
            _ = RefreshSourcesAsync();
            TraceLog("Loaded exit");
        }

        private void MainPage_Unloaded(object sender, EventArgs e)
        {
            TraceLog("Unloaded");
        }

        private async void Page_Window_Destroying(object sender, EventArgs e)
        {
            TraceLog("Page Window_Destroying enter");
            await ShutdownAsync();
            TraceLog("Page Window_Destroying exit");
        }

        public async Task ShutdownAsync()
        {
            TraceLog("ShutdownAsync enter");

            if (Interlocked.Exchange(ref _shutdownStarted, 1) != 0)
            {
                TraceLog("ShutdownAsync ignored because shutdown already started");
                return;
            }

            _destroyed = true;

            try
            {
                TraceLog("ShutdownAsync CancelRefresh enter");
                CancelRefresh();
                TraceLog("ShutdownAsync CancelRefresh exit");

                TraceLog("ShutdownAsync unsubscribe NDISourcesChanged enter");
                DeviceEnumerator.Shared.NDISourcesChanged -= OnNDISourcesChanged;
                TraceLog("ShutdownAsync unsubscribe NDISourcesChanged exit");

                TraceLog("ShutdownAsync StopNDISourceWatch enter");
                DeviceEnumerator.Shared.StopNDISourceWatch();
                TraceLog("ShutdownAsync StopNDISourceWatch exit");

                TraceLog($"ShutdownAsync StopAsync enter; timeout={ShutdownStopTimeout.TotalSeconds}s");
                await StopAsync(updateUi: false).WaitAsync(ShutdownStopTimeout);
                TraceLog("ShutdownAsync StopAsync exit");
            }
            catch (TimeoutException ex)
            {
                TraceLog($"ShutdownAsync StopAsync timed out; DestroySDK will still be called. {ex}");
            }
            catch (Exception ex)
            {
                TraceLog($"ShutdownAsync cleanup failed: {ex}");
                Debug.WriteLine($"Error during cleanup: {ex.Message}");
            }
            finally
            {
                TraceLog("ShutdownAsync DestroySDK enter");
                VisioForgeX.DestroySDK();
                TraceLog("ShutdownAsync DestroySDK exit");
            }

            TraceLog("ShutdownAsync exit");
        }

        private async Task RefreshSourcesAsync()
        {
            TraceLog("RefreshSourcesAsync enter");

            if (_destroyed)
            {
                TraceLog("RefreshSourcesAsync ignored because page is destroyed");
                return;
            }

            TraceLog("RefreshSourcesAsync CancelRefresh enter");
            CancelRefresh();
            TraceLog("RefreshSourcesAsync CancelRefresh exit");
            var cts = new CancellationTokenSource();
            _refreshCts = cts;
            var myVersion = Interlocked.Increment(ref _refreshVersion);

            try
            {
                TraceLog($"RefreshSourcesAsync v{myVersion} NDISourcesAsync enter");
                SetStatus("Discovering NDI sources...");
                UpdateRefreshState(isRefreshing: true);

                var sources = await DeviceEnumerator.Shared.NDISourcesAsync(cts.Token);
                TraceLog($"RefreshSourcesAsync v{myVersion} NDISourcesAsync exit; count={sources?.Length ?? 0}");

                if (cts.IsCancellationRequested || _destroyed || Volatile.Read(ref _refreshVersion) != myVersion)
                {
                    TraceLog($"RefreshSourcesAsync v{myVersion} result ignored; cancelled={cts.IsCancellationRequested}, destroyed={_destroyed}, currentVersion={Volatile.Read(ref _refreshVersion)}");
                    return;
                }

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    if (cts.IsCancellationRequested || _destroyed || Volatile.Read(ref _refreshVersion) != myVersion)
                    {
                        return;
                    }

                    ApplySourcesUiUpdate(sources);
                });
            }
            catch (OperationCanceledException)
            {
                TraceLog($"RefreshSourcesAsync v{myVersion} cancelled");
            }
            catch (Exception ex)
            {
                TraceLog($"RefreshSourcesAsync v{myVersion} failed: {ex}");
                Debug.WriteLine($"NDI source refresh failed: {ex}");
                SetStatus($"Failed to enumerate NDI sources: {ex.Message}");
            }
            finally
            {
                TraceLog($"RefreshSourcesAsync v{myVersion} finally enter");

                if (ReferenceEquals(Volatile.Read(ref _refreshCts), cts))
                {
                    Interlocked.CompareExchange(ref _refreshCts, null, cts);
                }

                cts.Dispose();

                if (Volatile.Read(ref _refreshVersion) == myVersion)
                {
                    MainThread.BeginInvokeOnMainThread(() => UpdateRefreshState(isRefreshing: false));
                }

                TraceLog($"RefreshSourcesAsync v{myVersion} finally exit");
            }
        }

        private void ApplySourcesUiUpdate(NDISourceInfo[] sources)
        {
            _availableSources = sources ?? Array.Empty<NDISourceInfo>();

            var selectedIndex = cbNDISources.SelectedIndex;
            cbNDISources.Items.Clear();

            foreach (var source in _availableSources)
            {
                cbNDISources.Items.Add(GetSourceDisplayName(source));
            }

            if (_availableSources.Length == 0)
            {
                cbNDISources.SelectedIndex = -1;
                SetStatus("No NDI sources found on the network");
                return;
            }

            cbNDISources.SelectedIndex = selectedIndex >= 0 && selectedIndex < _availableSources.Length
                ? selectedIndex
                : 0;

            SetStatus($"Found {_availableSources.Length} source(s)");
        }

        private static string GetSourceDisplayName(NDISourceInfo source)
        {
            if (source == null)
            {
                return string.Empty;
            }

            if (!string.IsNullOrWhiteSpace(source.Name) && !string.IsNullOrWhiteSpace(source.URL))
            {
                return $"{source.Name} ({source.URL})";
            }

            if (!string.IsNullOrWhiteSpace(source.Name))
            {
                return source.Name;
            }

            return source.URL ?? string.Empty;
        }

        private async Task OpenAsync()
        {
            TraceLog("OpenAsync waiting for pipeline lock");
            await _pipelineLock.WaitAsync();
            TraceLog("OpenAsync acquired pipeline lock");

            try
            {
                if (_isPlaying)
                {
                    TraceLog("OpenAsync ignored because already playing");
                    return;
                }

                var selectedIndex = cbNDISources.SelectedIndex;
                var sourcesSnapshot = _availableSources;
                if (sourcesSnapshot.Length == 0 || selectedIndex < 0 || selectedIndex >= sourcesSnapshot.Length)
                {
                    SetStatus("Select an NDI source first");
                    await DisplayAlertAsync("NDI Player", "Select an NDI source first.", "OK");
                    return;
                }

                var info = sourcesSnapshot[selectedIndex];
                TraceLog($"OpenAsync selected source name='{info?.Name}', url='{info?.URL}'");
                SetStatus($"Connecting to '{info.Name}'...");

                TraceLog("OpenAsync NDISourceSettings.CreateAsync enter");
                var settings = await NDISourceSettings.CreateAsync(null, info);
                TraceLog($"OpenAsync NDISourceSettings.CreateAsync exit; settingsNull={settings == null}, audioStreams={settings?.GetInfo()?.AudioStreams?.Count ?? -1}, videoStreams={settings?.GetInfo()?.VideoStreams?.Count ?? -1}");
                if (settings == null || !settings.IsValid())
                {
                    SetStatus("Failed to create NDI settings");
                    await DisplayAlertAsync("NDI Player", "Failed to create NDI source settings.", "OK");
                    return;
                }

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;
                TraceLog("OpenAsync pipeline created");

                _ndiSource = new NDISourceBlock(settings);
                TraceLog("OpenAsync NDISourceBlock created");

                var vv = videoView.GetVideoView();
                _videoRenderer = new VideoRendererBlock(_pipeline, vv)
                {
                    IsLive = true,
                    IsSync = false,
                };
                TraceLog("OpenAsync VideoRendererBlock created");

                _pipeline.Connect(_ndiSource.VideoOutput, _videoRenderer.Input);
                TraceLog("OpenAsync video connected");

                if (ShouldConnectAudio(settings))
                {
                    _audioRenderer = new AudioRendererBlock();
                    _pipeline.Connect(_ndiSource.AudioOutput, _audioRenderer.Input);
                    TraceLog("OpenAsync audio connected");
                }
                else
                {
                    TraceLog("OpenAsync audio skipped because source has no probed audio stream");
                }

                TraceLog("OpenAsync pipeline StartAsync enter");
                await _pipeline.StartAsync();
                TraceLog("OpenAsync pipeline StartAsync exit");

                _isPlaying = true;
                UpdatePlaybackState();
                SetStatus($"Playing '{info.Name}'");
            }
            catch (Exception ex)
            {
                TraceLog($"OpenAsync failed: {ex}");
                Debug.WriteLine($"NDI start failed: {ex}");
                await StopCoreAsync();
                UpdatePlaybackState();
                SetStatus($"Start failed: {ex.Message}");
                await DisplayAlertAsync("NDI Player", $"Start failed: {ex.Message}", "OK");
            }
            finally
            {
                _pipelineLock.Release();
                TraceLog("OpenAsync released pipeline lock");
            }
        }

        private async Task StopAsync(bool updateUi = true)
        {
            TraceLog($"StopAsync enter; updateUi={updateUi}");
            TraceLog("StopAsync waiting for pipeline lock");
            await _pipelineLock.WaitAsync();
            TraceLog("StopAsync acquired pipeline lock");

            try
            {
                await StopCoreAsync();

                if (updateUi)
                {
                    SetStatus("Stopped");
                    UpdatePlaybackState();
                }
            }
            finally
            {
                _pipelineLock.Release();
                TraceLog("StopAsync released pipeline lock");
            }

            TraceLog("StopAsync exit");
        }

        private async Task StopCoreAsync()
        {
            TraceLog($"StopCoreAsync enter; hasPipeline={_pipeline != null}, hasNdi={_ndiSource != null}, hasVideo={_videoRenderer != null}, hasAudio={_audioRenderer != null}");
            var pipeline = _pipeline;

            _pipeline = null;
            _ndiSource = null;
            _videoRenderer = null;
            _audioRenderer = null;
            _isPlaying = false;

            if (pipeline != null)
            {
                pipeline.OnError -= Pipeline_OnError;

                try
                {
                    TraceLog("StopCoreAsync pipeline StopAsync(true) enter");
                    await pipeline.StopAsync(true);
                    TraceLog("StopCoreAsync pipeline StopAsync(true) exit");
                }
                catch (Exception ex)
                {
                    TraceLog($"StopCoreAsync pipeline StopAsync failed: {ex}");
                    Debug.WriteLine($"Pipeline stop failed: {ex.Message}");
                }

                TraceLog("StopCoreAsync pipeline Dispose enter");
                pipeline.Dispose();
                TraceLog("StopCoreAsync pipeline Dispose exit");
            }

            TraceLog("StopCoreAsync exit");
        }

        private static bool ShouldConnectAudio(NDISourceSettings settings)
        {
            return settings.GetInfo()?.AudioStreams?.Count > 0;
        }

        private async void btPlay_Clicked(object sender, EventArgs e)
        {
            if (_isPlaying)
            {
                await StopAsync();
            }
            else
            {
                await OpenAsync();
            }
        }

        private async void btRefresh_Clicked(object sender, EventArgs e)
        {
            await RefreshSourcesAsync();
        }

        private void OnNDISourcesChanged(object sender, NDISourcesChangedEventArgs e)
        {
            TraceLog($"OnNDISourcesChanged enter; current={e.Current?.Length ?? 0}, added={e.Added?.Length ?? 0}, removed={e.Removed?.Length ?? 0}");
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (_destroyed)
                {
                    TraceLog("OnNDISourcesChanged UI update ignored because page is destroyed");
                    return;
                }

                ApplySourcesUiUpdate(e.Current);
                TraceLog("OnNDISourcesChanged UI update applied");
            });
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            TraceLog($"Pipeline_OnError: {e.Message}");
            Debug.WriteLine(e.Message);
            MainThread.BeginInvokeOnMainThread(() => SetStatus($"Pipeline error: {e.Message}"));
        }

        private void UpdateRefreshState(bool isRefreshing)
        {
            btRefresh.IsEnabled = !isRefreshing && !_isPlaying && !_destroyed;
            btRefresh.Text = isRefreshing ? "..." : "REFRESH";
        }

        private void UpdatePlaybackState()
        {
            btPlay.Text = _isPlaying ? "STOP" : "PLAY";
            btRefresh.IsEnabled = !_isPlaying && !_destroyed;
        }

        private void SetStatus(string message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (!_destroyed)
                {
                    lbStatus.Text = message;
                }
            });
        }

        private void CancelRefresh()
        {
            TraceLog("CancelRefresh enter");
            var cts = Interlocked.Exchange(ref _refreshCts, null);
            if (cts == null)
            {
                TraceLog("CancelRefresh exit; no CTS");
                return;
            }

            try
            {
                cts.Cancel();
                TraceLog("CancelRefresh cts.Cancel complete");
            }
            catch (Exception ex)
            {
                TraceLog($"CancelRefresh cts.Cancel failed: {ex}");
            }

            TraceLog("CancelRefresh exit");
        }

        private static void TraceLog(string message)
        {
            var line = $"[NDIPlayer][MainPage][{DateTime.Now:O}][T{Environment.CurrentManagedThreadId}] {message}";
            Trace.WriteLine(line);
            Debug.WriteLine(line);
        }
    }
}
