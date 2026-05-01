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
            InitializeComponent();

            VisioForgeX.InitSDK();

            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, EventArgs e)
        {
            if (Interlocked.Exchange(ref _started, 1) != 0)
            {
                return;
            }

            if (Window != null)
            {
                Window.Destroying += Page_Window_Destroying;
            }

            DeviceEnumerator.Shared.NDISourcesChanged += OnNDISourcesChanged;
            DeviceEnumerator.Shared.StartNDISourceWatch();

            _ = RefreshSourcesAsync();
        }

        private async void Page_Window_Destroying(object sender, EventArgs e)
        {
            await ShutdownAsync();
        }

        public async Task ShutdownAsync()
        {
            if (Interlocked.Exchange(ref _shutdownStarted, 1) != 0)
            {
                return;
            }

            _destroyed = true;

            try
            {
                CancelRefresh();

                DeviceEnumerator.Shared.NDISourcesChanged -= OnNDISourcesChanged;

                DeviceEnumerator.Shared.StopNDISourceWatch();

                await StopAsync(updateUi: false).WaitAsync(ShutdownStopTimeout);
            }
            catch (TimeoutException)
            {
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during cleanup: {ex.Message}");
            }
            finally
            {
                VisioForgeX.DestroySDK();
            }
        }

        private async Task RefreshSourcesAsync()
        {
            if (_destroyed)
            {
                return;
            }

            CancelRefresh();
            var cts = new CancellationTokenSource();
            _refreshCts = cts;
            var myVersion = Interlocked.Increment(ref _refreshVersion);

            try
            {
                SetStatus("Discovering NDI sources...");
                UpdateRefreshState(isRefreshing: true);

                var sources = await DeviceEnumerator.Shared.NDISourcesAsync(cts.Token);

                if (cts.IsCancellationRequested || _destroyed || Volatile.Read(ref _refreshVersion) != myVersion)
                {
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"NDI source refresh failed: {ex}");
                SetStatus($"Failed to enumerate NDI sources: {ex.Message}");
            }
            finally
            {
                if (ReferenceEquals(Volatile.Read(ref _refreshCts), cts))
                {
                    Interlocked.CompareExchange(ref _refreshCts, null, cts);
                }

                cts.Dispose();

                if (Volatile.Read(ref _refreshVersion) == myVersion)
                {
                    MainThread.BeginInvokeOnMainThread(() => UpdateRefreshState(isRefreshing: false));
                }
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
            await _pipelineLock.WaitAsync();

            try
            {
                if (_isPlaying)
                {
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
                SetStatus($"Connecting to '{info.Name}'...");

                var settings = await NDISourceSettings.CreateAsync(null, info);
                if (settings == null || !settings.IsValid())
                {
                    SetStatus("Failed to create NDI settings");
                    await DisplayAlertAsync("NDI Player", "Failed to create NDI source settings.", "OK");
                    return;
                }

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;

                _ndiSource = new NDISourceBlock(settings);

                var vv = videoView.GetVideoView();
                _videoRenderer = new VideoRendererBlock(_pipeline, vv)
                {
                    IsLive = true,
                    IsSync = false,
                };

                _pipeline.Connect(_ndiSource.VideoOutput, _videoRenderer.Input);

                if (ShouldConnectAudio(settings))
                {
                    _audioRenderer = new AudioRendererBlock();
                    _pipeline.Connect(_ndiSource.AudioOutput, _audioRenderer.Input);
                }

                await _pipeline.StartAsync();

                _isPlaying = true;
                UpdatePlaybackState();
                SetStatus($"Playing '{info.Name}'");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"NDI start failed: {ex}");
                await StopCoreAsync();
                UpdatePlaybackState();
                SetStatus($"Start failed: {ex.Message}");
                await DisplayAlertAsync("NDI Player", $"Start failed: {ex.Message}", "OK");
            }
            finally
            {
                _pipelineLock.Release();
            }
        }

        private async Task StopAsync(bool updateUi = true)
        {
            await _pipelineLock.WaitAsync();

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
            }
        }

        private async Task StopCoreAsync()
        {
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
                    await pipeline.StopAsync(true);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Pipeline stop failed: {ex.Message}");
                }

                pipeline.Dispose();
            }
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
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (_destroyed)
                {
                    return;
                }

                ApplySourcesUiUpdate(e.Current);
            });
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
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
            var cts = Interlocked.Exchange(ref _refreshCts, null);
            if (cts == null)
            {
                return;
            }

            try
            {
                cts.Cancel();
            }
            catch (Exception)
            {
            }
        }
    }
}
