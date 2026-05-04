using VisioForge.Core;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.VideoCaptureX;

using Android;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using Activity = Android.App.Activity;

namespace NDIPlayer
{
    [Activity(
        Label = "@string/app_name",
        MainLauncher = true,
        Theme = "@android:style/Theme.NoTitleBar.Fullscreen",
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class MainActivity : Activity
    {
        private const string TAG = "NDIPlayer";

        private static class StatusStrings
        {
            public const string DiscoveringSources = "Discovering NDI sources...";
            public const string NoSourcesFound = "No NDI sources found on the network";
            public const string EnumerationFailed = "Failed to enumerate NDI sources";
            public const string SelectSourceFirst = "Select an NDI source first";
            public const string SelectedSourceInvalid = "Selected source is invalid — refresh and pick again";
            public const string FailedCreateSettings = "Failed to create NDI settings";
            public const string Stopped = "Stopped";
            public const string PermissionsDenied = "Permissions denied — NDI discovery may not work";
            public const string PermissionsToast = "Network permissions are required for NDI discovery";
        }

        private const int REQUEST_PERMISSIONS = 1004;
        private const string STATE_SELECTED_SOURCE_LABEL = "NDIPlayer.SelectedSourceLabel";
        private const string STATE_STATUS_TEXT = "NDIPlayer.StatusText";

        private VisioForge.Core.UI.Android.VideoViewGL videoView = null!;
        private Spinner spSources = null!;
        private ImageButton btRefresh = null!;
        private ImageButton btStart = null!;
        private ImageButton btStop = null!;
        private TextView lbStatus = null!;
        private View? _panelView;

        private int _panelPaddingLeft;
        private int _panelPaddingTop;
        private int _panelPaddingRight;
        private int _panelPaddingBottom;

        private VideoCaptureCoreX? _core;
        private NDISourceInfo[] _availableSources = Array.Empty<NDISourceInfo>();

        private int _refreshVersion;
        private volatile bool _destroyed;
        private bool _isPlaying;

        private readonly System.Threading.SemaphoreSlim _lock = new(1, 1);

        private System.Threading.CancellationTokenSource? _refreshCts;

        private SystemInsetsListener? _systemInsetsListener;
        private int _appliedInsetLeft;
        private int _appliedInsetRight;
        private int _appliedInsetBottom;
        private string? _pendingRestoreSourceLabel;
        private string _lastStatusText = string.Empty;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            var requiredPermissions = new[]
            {
                Manifest.Permission.Internet,
                Manifest.Permission.AccessNetworkState,
                Manifest.Permission.AccessWifiState,
                Manifest.Permission.ChangeWifiMulticastState,
            };

            var needed = requiredPermissions
                .Where(p => CheckSelfPermission(p) != Permission.Granted)
                .ToArray();

            if (needed.Length > 0)
            {
                RequestPermissions(needed, REQUEST_PERMISSIONS);
            }

            videoView = FindViewById<VisioForge.Core.UI.Android.VideoViewGL>(Resource.Id.videoView);
            spSources = FindViewById<Spinner>(Resource.Id.spSources);
            btRefresh = FindViewById<ImageButton>(Resource.Id.btRefresh);
            btStart = FindViewById<ImageButton>(Resource.Id.btStart);
            btStop = FindViewById<ImageButton>(Resource.Id.btStop);
            lbStatus = FindViewById<TextView>(Resource.Id.lbStatus);
            _panelView = FindViewById<View>(Resource.Id.panel);

            if (savedInstanceState != null)
            {
                _pendingRestoreSourceLabel = savedInstanceState.GetString(STATE_SELECTED_SOURCE_LABEL);
                var restoredStatus = savedInstanceState.GetString(STATE_STATUS_TEXT);
                if (!string.IsNullOrEmpty(restoredStatus))
                {
                    _lastStatusText = restoredStatus;
                    lbStatus.Text = restoredStatus;
                }
            }

            btRefresh.Click += BtRefresh_Click;
            btStart.Click += BtStart_Click;
            btStop.Click += BtStop_Click;

            UpdateButtons(isPlaying: false, isRefreshing: false);

            ConfigureSystemInsets();

            _refreshCts = new System.Threading.CancellationTokenSource();
            _ = RefreshSourcesAsync(_refreshCts.Token);

            DeviceEnumerator.Shared.NDISourcesChanged += OnNDISourcesChanged;
            DeviceEnumerator.Shared.StartNDISourceWatch();
        }

        private async Task RefreshSourcesAsync(System.Threading.CancellationToken cancellationToken = default)
        {
            var myVersion = System.Threading.Interlocked.Increment(ref _refreshVersion);

            try
            {
                SetStatus(StatusStrings.DiscoveringSources);

                var sources = await DeviceEnumerator.Shared.NDISourcesAsync(cancellationToken);

                if (System.Threading.Volatile.Read(ref _refreshVersion) != myVersion)
                {
                    return;
                }

                if (cancellationToken.IsCancellationRequested || IsFinishing || IsDestroyed)
                {
                    return;
                }

                _availableSources = sources ?? Array.Empty<NDISourceInfo>();

                RunOnUiThread(() =>
                {
                    if (cancellationToken.IsCancellationRequested || IsFinishing || IsDestroyed)
                    {
                        return;
                    }

                    if (System.Threading.Volatile.Read(ref _refreshVersion) != myVersion)
                    {
                        return;
                    }

                    var statusText = sources.Length == 0
                        ? StatusStrings.NoSourcesFound
                        : $"Found {sources.Length} source(s)";
                    ApplySourcesUiUpdate(sources, statusText, fromWatcher: false);
                });
            }
            catch (System.OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                Log.Error(TAG, $"RefreshSourcesAsync failed: {ex}");
                if (!IsFinishing && !IsDestroyed)
                {
                    SetStatus(StatusStrings.EnumerationFailed);
                }
            }
        }

        private void ApplySourcesUiUpdate(NDISourceInfo[] sources, string statusText, bool fromWatcher)
        {
            if (IsFinishing || IsDestroyed)
            {
                return;
            }

            _availableSources = sources ?? Array.Empty<NDISourceInfo>();

            if (fromWatcher)
            {
                System.Threading.Interlocked.Increment(ref _refreshVersion);
            }

            try
            {
                var previousLabel = _pendingRestoreSourceLabel ?? spSources?.SelectedItem?.ToString();
                _pendingRestoreSourceLabel = null;

                var labels = _availableSources.Length == 0
                    ? new[] { "(no sources found)" }
                    : _availableSources.Select(s => string.IsNullOrEmpty(s.URL)
                        ? s.Name
                        : $"{s.Name} ({s.URL})").ToArray();

                var adapter = new ArrayAdapter<string>(this,
                    global::Android.Resource.Layout.SimpleSpinnerItem, labels);
                adapter.SetDropDownViewResource(global::Android.Resource.Layout.SimpleSpinnerDropDownItem);
                spSources.Adapter = adapter;

                if (!string.IsNullOrEmpty(previousLabel) && _availableSources.Length > 0)
                {
                    var restoredIndex = Array.IndexOf(labels, previousLabel);
                    if (restoredIndex >= 0)
                    {
                        spSources.SetSelection(restoredIndex);
                    }
                }

                SetStatus(statusText);
            }
            catch (Java.Lang.IllegalStateException ise)
            {
                Log.Warn(TAG, $"ApplySourcesUiUpdate skipped: {ise.Message}");
            }
            catch (ObjectDisposedException ode)
            {
                Log.Warn(TAG, $"ApplySourcesUiUpdate on disposed object: {ode.Message}");
            }
        }

        private void OnNDISourcesChanged(object? sender, NDISourcesChangedEventArgs e)
        {
            if (_destroyed || e == null)
            {
                return;
            }

            string statusText;
            if (e.Added.Length > 0 && e.Removed.Length == 0)
            {
                statusText = e.Added.Length == 1
                    ? $"+ {e.Added[0].Name}"
                    : $"+ {e.Added.Length} new source(s)";
            }
            else if (e.Removed.Length > 0 && e.Added.Length == 0)
            {
                statusText = e.Removed.Length == 1
                    ? $"– {e.Removed[0].Name} went offline"
                    : $"– {e.Removed.Length} source(s) went offline";
            }
            else if (e.Added.Length > 0 && e.Removed.Length > 0)
            {
                statusText = $"+{e.Added.Length} / –{e.Removed.Length} sources";
            }
            else
            {
                statusText = e.Current.Length == 0
                    ? StatusStrings.NoSourcesFound
                    : $"Found {e.Current.Length} source(s)";
            }

            RunOnUiThread(() =>
            {
                if (_destroyed)
                {
                    return;
                }
                ApplySourcesUiUpdate(e.Current, statusText, fromWatcher: true);
            });
        }

        private async void BtRefresh_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_isPlaying)
                {
                    return;
                }
                await RefreshSourcesAsync(EnsureRefreshToken());
            }
            catch (Exception ex)
            {
                Log.Error(TAG, $"BtRefresh_Click failed: {ex}");
            }
        }

        private async void BtStart_Click(object? sender, EventArgs e)
        {
            try
            {
                await BtStartClickAsync();
            }
            catch (Exception ex)
            {
                Log.Error(TAG, $"BtStart_Click failed: {ex}");
                await StopCoreAsync();
                UpdateButtons(isPlaying: false, isRefreshing: false);
            }
        }

        private async Task BtStartClickAsync()
        {
            await _lock.WaitAsync();

            try
            {
                if (_isPlaying)
                {
                    return;
                }

                var sourcesSnapshot = _availableSources;
                var selectedIndex = spSources?.SelectedItemPosition ?? -1;
                if (sourcesSnapshot.Length == 0 || selectedIndex < 0 || selectedIndex >= sourcesSnapshot.Length)
                {
                    SetStatus(StatusStrings.SelectSourceFirst);
                    return;
                }

                var info = sourcesSnapshot[selectedIndex];
                if (info == null)
                {
                    SetStatus(StatusStrings.SelectedSourceInvalid);
                    return;
                }

                Log.Info(TAG, $"Starting NDI source '{info.Name}'");
                SetStatus($"Connecting to '{info.Name}'...");
                UpdateButtons(isPlaying: false, isRefreshing: false);

                var settings = await NDISourceSettings.CreateAsync(null, info);
                if (settings == null)
                {
                    SetStatus(StatusStrings.FailedCreateSettings);
                    return;
                }

                _core = new VideoCaptureCoreX(videoView);
                _core.OnError += Core_OnError;
                _core.Video_Source = settings;
                _core.Audio_Play = settings.GetInfo()?.AudioStreams?.Count > 0;

                await _core.StartAsync();

                _isPlaying = true;
                UpdateButtons(isPlaying: true, isRefreshing: false);
                SetStatus($"Playing '{info.Name}'");
            }
            catch (Exception ex)
            {
                Log.Error(TAG, $"BtStartClickAsync failed: {ex}");
                await StopCoreAsync();
                SetStatus($"Start failed: {ex.Message}");
                UpdateButtons(isPlaying: false, isRefreshing: false);
            }
            finally
            {
                _lock.Release();
            }
        }

        private async void BtStop_Click(object? sender, EventArgs e)
        {
            try
            {
                await StopCoreAsync();
                SetStatus(StatusStrings.Stopped);
                UpdateButtons(isPlaying: false, isRefreshing: false);
            }
            catch (Exception ex)
            {
                Log.Error(TAG, $"BtStop_Click failed: {ex}");
            }
        }

        private async Task StopCoreAsync()
        {
            await _lock.WaitAsync();

            try
            {
                _isPlaying = false;
                var core = _core;
                _core = null;

                if (core != null)
                {
                    core.OnError -= Core_OnError;

                    try
                    {
                        await core.StopAsync();
                    }
                    catch (Exception ex)
                    {
                        Log.Warn(TAG, $"Core StopAsync failed: {ex.Message}");
                    }

                    try
                    {
                        await core.DisposeAsync();
                    }
                    catch (Exception ex)
                    {
                        Log.Error(TAG, $"Core DisposeAsync failed: {ex}");
                    }
                }
            }
            finally
            {
                _lock.Release();
            }
        }

        private void Core_OnError(object? sender, ErrorsEventArgs e)
        {
            if (_destroyed)
            {
                return;
            }

            Log.Error(TAG, $"Pipeline error: {e.Message}");
            RunOnUiThread(() =>
            {
                if (!_destroyed)
                {
                    SetStatus($"Pipeline error: {e.Message}");
                }
            });
        }

        private void UpdateButtons(bool isPlaying, bool isRefreshing)
        {
            void Apply()
            {
                if (_destroyed || IsFinishing || IsDestroyed)
                {
                    return;
                }

                try
                {
                    btStart.Enabled = !isPlaying && !isRefreshing;
                    btStop.Enabled = isPlaying;
                    btRefresh.Enabled = !isPlaying;
                }
                catch (ObjectDisposedException ode)
                {
                    Log.Warn(TAG, $"UpdateButtons skipped: {ode.Message}");
                }
                catch (Java.Lang.IllegalStateException ise)
                {
                    Log.Warn(TAG, $"UpdateButtons skipped: {ise.Message}");
                }
            }

            if (Looper.MainLooper == Looper.MyLooper())
            {
                Apply();
            }
            else
            {
                RunOnUiThread(Apply);
            }
        }

        private void SetStatus(string text)
        {
            _lastStatusText = text;

            void Apply()
            {
                if (_destroyed || IsFinishing || IsDestroyed)
                {
                    return;
                }

                try
                {
                    lbStatus.Text = text;
                }
                catch (ObjectDisposedException ode)
                {
                    Log.Warn(TAG, $"SetStatus skipped: {ode.Message}");
                }
                catch (Java.Lang.IllegalStateException ise)
                {
                    Log.Warn(TAG, $"SetStatus skipped: {ise.Message}");
                }
            }

            if (Looper.MainLooper == Looper.MyLooper())
            {
                Apply();
            }
            else
            {
                RunOnUiThread(Apply);
            }
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);

            try
            {
                var selectedLabel = spSources?.SelectedItem?.ToString() ?? _pendingRestoreSourceLabel;
                if (!string.IsNullOrEmpty(selectedLabel))
                {
                    outState.PutString(STATE_SELECTED_SOURCE_LABEL, selectedLabel);
                }

                if (!string.IsNullOrEmpty(_lastStatusText))
                {
                    outState.PutString(STATE_STATUS_TEXT, _lastStatusText);
                }
            }
            catch (Exception ex)
            {
                Log.Warn(TAG, $"OnSaveInstanceState skipped: {ex.Message}");
            }
        }

        protected override async void OnDestroy()
        {
            _destroyed = true;

            try { btRefresh.Click -= BtRefresh_Click; } catch (Exception ex) { Log.Warn(TAG, $"OnDestroy: refresh click detach failed: {ex.Message}"); }
            try { btStart.Click -= BtStart_Click; } catch (Exception ex) { Log.Warn(TAG, $"OnDestroy: start click detach failed: {ex.Message}"); }
            try { btStop.Click -= BtStop_Click; } catch (Exception ex) { Log.Warn(TAG, $"OnDestroy: stop click detach failed: {ex.Message}"); }

            try { DeviceEnumerator.Shared.NDISourcesChanged -= OnNDISourcesChanged; } catch (Exception ex) { Log.Warn(TAG, $"OnDestroy: NDI watcher detach failed: {ex.Message}"); }

            try
            {
                _systemInsetsListener?.Dispose();
                _systemInsetsListener = null;
            }
            catch (Exception ex)
            {
                Log.Warn(TAG, $"OnDestroy: insets listener dispose failed: {ex.Message}");
            }

            try
            {
                _refreshCts?.Cancel();
            }
            catch (Exception ex)
            {
                Log.Warn(TAG, $"OnDestroy: refresh cancel failed: {ex.Message}");
            }

            try
            {
                await StopCoreAsync();
            }
            catch (Exception ex)
            {
                Log.Error(TAG, $"OnDestroy teardown failed: {ex}");
            }

            System.Threading.Volatile.Write(ref _refreshCts, null);

            try
            {
                _lock.Dispose();
            }
            catch (Exception ex)
            {
                Log.Warn(TAG, $"OnDestroy: lock dispose failed: {ex.Message}");
            }

            try
            {
                base.OnDestroy();
            }
            catch (Exception ex)
            {
                Log.Error(TAG, $"base.OnDestroy failed: {ex}");
            }
        }

        private System.Threading.CancellationToken EnsureRefreshToken()
        {
            while (true)
            {
                var cts = System.Threading.Volatile.Read(ref _refreshCts);
                var needsReplacement = cts == null;

                if (cts != null)
                {
                    try
                    {
                        needsReplacement = cts.IsCancellationRequested;
                    }
                    catch (ObjectDisposedException)
                    {
                    }
                }

                if (!needsReplacement && cts != null)
                {
                    try
                    {
                        return cts.Token;
                    }
                    catch (ObjectDisposedException)
                    {
                        needsReplacement = true;
                    }
                }

                var replacement = new System.Threading.CancellationTokenSource();
                var prior = System.Threading.Interlocked.CompareExchange(ref _refreshCts, replacement, cts);
                if (ReferenceEquals(prior, cts))
                {
                    return replacement.Token;
                }

                try { replacement.Dispose(); }
                catch (Exception ex) { Log.Warn(TAG, $"EnsureRefreshToken: unused CTS dispose failed: {ex.Message}"); }
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            _ = EnsureRefreshToken();
        }

        protected override void OnPause()
        {
            try
            {
                _refreshCts?.Cancel();
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                Log.Warn(TAG, $"OnPause: refresh cancel failed: {ex.Message}");
            }

            base.OnPause();
        }

        protected override async void OnStop()
        {
            base.OnStop();

            if (_destroyed)
            {
                return;
            }

            try
            {
                if (_isPlaying)
                {
                    await StopCoreAsync();
                    UpdateButtons(isPlaying: false, isRefreshing: false);
                }
            }
            catch (Exception ex)
            {
                Log.Error(TAG, $"OnStop pipeline stop failed: {ex}");
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode != REQUEST_PERMISSIONS)
            {
                return;
            }

            bool allGranted = grantResults != null
                              && grantResults.Length == permissions.Length
                              && grantResults.All(r => r == Permission.Granted);

            if (allGranted)
            {
                Log.Info(TAG, "Permissions granted; refreshing NDI sources");
                _ = RefreshSourcesAsync(EnsureRefreshToken());
            }
            else
            {
                Log.Warn(TAG, "Permissions denied — NDI discovery may produce empty list");
                if (!IsFinishing && !IsDestroyed)
                {
                    try
                    {
                        Toast.MakeText(this, StatusStrings.PermissionsToast, ToastLength.Long).Show();
                    }
                    catch (Exception ex)
                    {
                        Log.Warn(TAG, $"Permission toast skipped: {ex.Message}");
                    }

                    SetStatus(StatusStrings.PermissionsDenied);
                }
            }
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            RunOnUiThread(() =>
            {
                _panelView = FindViewById<View>(Resource.Id.panel);
                ConfigureSystemInsets();
                RequestSystemInsets();
                videoView?.InvokeVideoRendererUpdate();
            });
        }

        private void ConfigureSystemInsets()
        {
            var contentView = FindViewById<ViewGroup>(global::Android.Resource.Id.Content)?.GetChildAt(0);
            if (contentView == null || _panelView == null)
            {
                return;
            }

            _systemInsetsListener?.Dispose();
            _systemInsetsListener = null;

            _panelPaddingLeft = _panelView.PaddingLeft - _appliedInsetLeft;
            _panelPaddingTop = _panelView.PaddingTop;
            _panelPaddingRight = _panelView.PaddingRight - _appliedInsetRight;
            _panelPaddingBottom = _panelView.PaddingBottom - _appliedInsetBottom;

            _systemInsetsListener = new SystemInsetsListener(this);
            contentView.SetOnApplyWindowInsetsListener(_systemInsetsListener);
            contentView.RequestApplyInsets();
        }

        private void ApplySystemInsets(WindowInsets insets)
        {
            if (_panelView == null || insets == null)
            {
                return;
            }

            int leftInset, rightInset, bottomInset;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.R)
            {
                var systemBars = insets.GetInsets(WindowInsets.Type.SystemBars());
                leftInset = systemBars.Left;
                rightInset = systemBars.Right;
                bottomInset = systemBars.Bottom;
            }
            else
            {
#pragma warning disable CA1422
                leftInset = insets.SystemWindowInsetLeft;
                rightInset = insets.SystemWindowInsetRight;
                bottomInset = insets.SystemWindowInsetBottom;
#pragma warning restore CA1422
            }

            _appliedInsetLeft = leftInset;
            _appliedInsetRight = rightInset;
            _appliedInsetBottom = bottomInset;

            _panelView.SetPadding(
                _panelPaddingLeft + leftInset,
                _panelPaddingTop,
                _panelPaddingRight + rightInset,
                _panelPaddingBottom + bottomInset);
        }

        private void RequestSystemInsets()
        {
            var contentView = FindViewById<ViewGroup>(global::Android.Resource.Id.Content)?.GetChildAt(0);
            contentView?.RequestApplyInsets();
        }

        private sealed class SystemInsetsListener : Java.Lang.Object, View.IOnApplyWindowInsetsListener
        {
            private readonly MainActivity _activity;

            public SystemInsetsListener(MainActivity activity)
            {
                _activity = activity;
            }

            public WindowInsets OnApplyWindowInsets(View view, WindowInsets insets)
            {
                _activity.ApplySystemInsets(insets);
                return view.OnApplyWindowInsets(insets);
            }
        }
    }
}
