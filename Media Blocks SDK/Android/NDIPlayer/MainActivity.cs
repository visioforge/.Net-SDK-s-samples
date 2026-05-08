using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;

using Android;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using Activity = Android.App.Activity;
using OperationCanceledException = Android.OS.OperationCanceledException;

namespace NDIPlayer
{
    /// <summary>
    /// NDI receiver demo built on top of the VisioForge MediaBlocks SDK and the official NDI Advanced SDK for Android.
    /// </summary>
    [Activity(
        Label = "@string/app_name",
        MainLauncher = true,
        Theme = "@android:style/Theme.NoTitleBar.Fullscreen",
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class MainActivity : Activity
    {
        private const string TAG = "NDIPlayer";

        // TODO (issue #80): localise user-visible status strings via
        // Resources/values/strings.xml + Resources.GetString(Resource.String.xxx).
        // Static (non-interpolated) literals are grouped in StatusStrings below
        // so a future localisation pass only has to update the resource lookups
        // in one place. Interpolated strings (Connecting to '{name}', Playing
        // '{name}', "Pipeline error: {msg}") still inline at their call sites
        // because format placeholders need per-locale ordering — defer those
        // to the strings.xml pass with formatted resources.
        private static class StatusStrings
        {
            public const string DiscoveringSources = "Discovering NDI sources...";
            public const string NoSourcesFound = "No NDI sources found on the network";
            public const string EnumerationFailed = "Failed to enumerate NDI sources";
            public const string RefreshDisabledActive = "Refresh disabled while pipeline is active";
            public const string SelectSourceFirst = "Select an NDI source first";
            public const string SelectedSourceInvalid = "Selected source is invalid — refresh and pick again";
            public const string FailedCreateSettings = "Failed to create NDI settings";
            public const string ConnectionTimedOut = "Connection timed out";
            public const string Cancelled = "Cancelled";
            public const string Stopped = "Stopped";
            public const string CancellingStart = "Cancelling start...";
            public const string PermissionsDenied = "Permissions denied — NDI discovery may not work";
            public const string PermissionsToast = "Network permissions are required for NDI discovery";
        }

        // Permission request code for the network/multicast permissions requested in
        // OnCreate. Must match the value passed to RequestPermissions and checked in
        // OnRequestPermissionsResult.
        private const int REQUEST_PERMISSIONS = 1004;
        private const string STATE_SELECTED_SOURCE_LABEL = "NDIPlayer.SelectedSourceLabel";
        private const string STATE_STATUS_TEXT = "NDIPlayer.StatusText";

        // View fields are populated synchronously in OnCreate via FindViewById and
        // remain non-null for the activity lifetime. The `null!` initialiser
        // suppresses CS8618 (uninitialised non-nullable) — the alternative would be
        // sprinkling `[MemberNotNull]` attributes across OnCreate, which is noisier
        // for no semantic gain. Callers must still null-check defensively in code
        // that runs after OnDestroy (e.g. async continuations).
        private VisioForge.Core.UI.Android.VideoViewTX videoView = null!;

        private Spinner spSources = null!;
        private ImageButton btRefresh = null!;
        private ImageButton btStart = null!;
        private ImageButton btStop = null!;
        private TextView lbStatus = null!;
        // _panelView is intentionally nullable: the layout may not have a `panel`
        // view in all configurations (e.g. landscape vs portrait), and inset
        // application code already null-checks defensively. Marking it `null!`
        // would make those guards into unreachable dead code per nullable analysis.
        private View? _panelView;

        // NOTE: panel padding values are captured ONCE on first window-insets
        // delivery (see ConfigureSystemInsets) and assumed not to change at
        // runtime. The inset apply path adds the current system insets to these
        // baselines, so any code that mutates _panelView.SetPadding(...) directly
        // after capture will be silently overwritten on the next inset event.
        // If the panel ever needs dynamic padding, replace these with a
        // re-read-on-apply or expose an UpdateBasePadding(int,int,int,int)
        // method that callers must invoke after each mutation.
        private int _panelPaddingLeft;
        private int _panelPaddingTop;
        private int _panelPaddingRight;
        private int _panelPaddingBottom;

        // Pipeline + block fields are nullable: created in BtStart_Click, set back
        // to null by DestroyPipelineAsync. Every read site must null-check (or use
        // ?. for cheap calls).
        private MediaBlocksPipeline? _pipeline;
        private VideoRendererBlock? _videoRenderer;
        private AudioRendererBlock? _audioRenderer;
        private NDISourceBlock? _ndiSource;

        private NDISourceInfo[] _availableSources = Array.Empty<NDISourceInfo>();

        // Monotonic refresh-attempt counter. Each call to RefreshSourcesAsync
        // increments and snapshots a local copy; if a newer attempt has bumped the
        // counter past the snapshot by the time the network call returns, the older
        // attempt's UI update is suppressed. Without this, OnCreate's initial refresh
        // racing with OnRequestPermissionsResult's re-run can have the slower call
        // overwrite the faster call's result, leaving _availableSources out of sync
        // with the spinner's adapter and corrupting BtStart_Click index lookups.
        private int _refreshVersion;

        /// <summary>
        /// Tri-state lifecycle for the receive pipeline. The Starting state covers the
        /// asynchronous probe + StartAsync window so that a Stop tap during connect can
        /// still tear down a half-built pipeline (rather than orphaning it).
        /// </summary>
        private enum LifecycleState
        {
            Idle,
            Starting,
            Playing,
            Stopping,
        }

        // ALWAYS read/written under _lifecycleLock — see TryTransitionAsync /
        // SetStateAsync / GetStateAsync. Cannot mark `volatile` because
        // LifecycleState is a struct-typed enum (volatile only legal on
        // primitive scalars / references in C#). The semaphore-mediated
        // happens-before is what guarantees memory visibility across threads,
        // so do NOT add a "fast path" read that bypasses the lock.
        private LifecycleState _state = LifecycleState.Idle;
        private readonly System.Threading.SemaphoreSlim _lifecycleLock = new System.Threading.SemaphoreSlim(1, 1);
        private int _stateVersion;

        // Set true at the very top of OnDestroy. All callbacks that touch UI / pipeline /
        // _lifecycleLock check this flag first so they bail before hitting a disposed
        // resource. Volatile because it's written from OnDestroy (UI thread) and read
        // from arbitrary continuations (UI + thread-pool).
        private volatile bool _destroyed;

        // Cancellation source for in-flight RefreshSourcesAsync work. Cancelled in
        // OnDestroy so the RunOnUiThread callback bails out cleanly if NDI discovery
        // is still in flight when the activity tears down — without this, the lambda
        // executes against a destroyed activity and IllegalStateException / NRE
        // crashes the process during navigation. Nullable because OnDestroy disposes
        // it and a callback that runs *after* destroy would otherwise see a stale
        // disposed reference.
        private System.Threading.CancellationTokenSource? _refreshCts;

        // Cancellation source for the in-flight BtStart_Click pipeline-build path.
        // Cancelled by BtStop_Click and OnDestroy so the user can cancel a slow NDI
        // probe (up to ~10s) without waiting for the timeout. A separate CTS from
        // _refreshCts because Start and Refresh can be cancelled independently.
        // Nullable: only non-null while a start attempt is in flight.
        private System.Threading.CancellationTokenSource? _startCts;

        // Per-start completion signal. BtStart_Click installs a fresh TCS on entry and
        // completes it in its finally block (success, failure, or cancellation). BtStop_Click
        // awaits this when it transitions Starting -> Stopping so the UI status only flips
        // to "Stopped" after Start has actually wound down its pipeline. Using a TCS rather
        // than the CTS avoids the race where Stop's Cancel + status update beat Start's
        // finally block (Start would then overwrite status with "Start failed" later).
        // Nullable: only non-null while a start attempt is in flight.
        private System.Threading.Tasks.TaskCompletionSource<bool>? _startCompletion;

        // Maximum time BtStop_Click will wait for an in-flight Start to complete its
        // teardown before giving up and updating the UI itself. Has to be longer than
        // a normal cancellation latency (sub-second) but short enough that an actually
        // hung Start doesn't block Stop's handler indefinitely.
        private static readonly TimeSpan StartCancelWait = TimeSpan.FromSeconds(2);

        // Upper bound on how long BtStart_Click will wait on StartAsync before
        // giving up, tearing down, and returning the UI to Idle. Set slightly
        // longer than NDISourceBlock's 10s probe deadline so a successful probe
        // that finishes near the limit still has room to flip the pipeline to
        // PLAYING before we declare timeout.
        private static readonly TimeSpan StartTimeout = TimeSpan.FromSeconds(12);

        // Process-wide gate that serialises pipeline lifecycle actions across
        // activity instances. async-void OnDestroy returns to Android at the first
        // await, so a fast orientation change (or rapid app exit/relaunch) can have
        // the FRAMEWORK call a fresh OnCreate and BtStart_Click on a new
        // MainActivity instance while the previous instance's DisposeAsync is still
        // tearing down GStreamer state. Both instances would then race on the same
        // shared GStreamer plugin/registry state, occasionally crashing the
        // streaming task with "element is in NULL state but is being added to a
        // parent" or similar. Holding this gate around OnDestroy's teardown AND
        // around BtStart_Click's pipeline construction enforces a strict
        // happens-before so the new instance only constructs after the old one is
        // fully disposed. Static so it survives across instances.
        private static readonly System.Threading.SemaphoreSlim _pipelineGate = new System.Threading.SemaphoreSlim(1, 1);
        private readonly System.Threading.SemaphoreSlim _destroyPipelineLock = new System.Threading.SemaphoreSlim(1, 1);
        private int _pipelineErrorsEnabled;

        // Cap the wait on _pipelineGate in BtStart_Click so a hung previous
        // teardown doesn't permanently jam Start. Longer than the OnDestroy
        // teardown wait (5s) so the normal case always completes; if we exceed
        // it we proceed anyway and surface a status message.
        private static readonly TimeSpan PipelineGateWait = TimeSpan.FromSeconds(8);

        private SystemInsetsListener? _systemInsetsListener;
        private int _appliedInsetLeft;
        private int _appliedInsetRight;
        private int _appliedInsetBottom;
        private string? _pendingRestoreSourceLabel;
        private string _lastStatusText = string.Empty;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Process-level restore keeps the last selected source label and
            // status text. The pipeline itself is intentionally not restarted:
            // NDI connection remains an explicit user action.
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            // Only prompt for permissions that aren't already granted. On a warm
            // start (or after the user has already accepted once) every permission
            // here is typically Granted, and calling RequestPermissions
            // unconditionally re-runs Android's grant flow, which on some OEM
            // builds re-shows the dialog briefly and ALWAYS triggers
            // OnRequestPermissionsResult — that callback then re-runs
            // RefreshSourcesAsync on top of the OnCreate refresh below, racing the
            // _refreshVersion guard for no benefit. If everything is already
            // granted we kick off discovery on the same code path the
            // post-permissions callback would, and skip the redundant prompt.
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

            videoView = FindViewById<VisioForge.Core.UI.Android.VideoViewTX>(Resource.Id.videoView);

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

            // Initial button state: Start enabled, Stop disabled (Idle).
            UpdateButtons(LifecycleState.Idle);

            ConfigureSystemInsets();

            // Discover sources at startup so the spinner is populated without a manual refresh tap.
            _refreshCts = new System.Threading.CancellationTokenSource();
            _ = RefreshSourcesAsync(_refreshCts.Token);

            // Subscribe to live NDI source-list changes. The watcher fires on
            // any add / remove (libndi mDNS heartbeat detection takes ~5–10 s
            // for removals — that's the SDK contract, not configurable). The
            // event arrives on a background thread; OnNDISourcesChanged marshals
            // to the UI looper. StartNDISourceWatch is idempotent and a no-op
            // on platforms that don't ship the watcher implementation, so it's
            // safe to call unconditionally here.
            DeviceEnumerator.Shared.NDISourcesChanged += OnNDISourcesChanged;
            DeviceEnumerator.Shared.StartNDISourceWatch();
        }

        private async Task RefreshSourcesAsync(System.Threading.CancellationToken cancellationToken = default)
        {
            // Claim a refresh-attempt id. Any concurrent caller (OnCreate + the post-
            // permission re-run, or two BtRefresh taps in quick succession) bumps this
            // past our snapshot; if our network call returns AFTER a newer attempt has
            // already published its results, we skip the UI mutation so the spinner and
            // _availableSources stay coherent with whichever discovery completed last.
            var myVersion = System.Threading.Interlocked.Increment(ref _refreshVersion);

            try
            {
                SetStatus(StatusStrings.DiscoveringSources);

                // DeviceEnumerator.NDISourcesAsync has no CancellationToken-accepting
                // overload (it owns a multi-second mDNS discovery loop internally and
                // can't be interrupted mid-flight). Race the call against the token
                // so OnDestroy / OnPause / a newer BtRefresh tap can short-circuit
                // the await without waiting for the natural ~5s completion. The
                // discovery task is left running in the background — it'll finish
                // and observe its own result; we just stop waiting on it. The
                // subsequent IsCancellationRequested check below already gates the
                // UI mutation, so an orphaned completion won't touch a torn-down view.
                var enumTask = DeviceEnumerator.Shared.NDISourcesAsync();
                _ = enumTask.ContinueWith(
                    t => Log.Warn(TAG, $"RefreshSourcesAsync: late discovery fault observed: {t.Exception?.GetBaseException().Message}"),
                    System.Threading.Tasks.TaskContinuationOptions.OnlyOnFaulted | System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously);

                NDISourceInfo[] sources;
                if (cancellationToken.CanBeCanceled)
                {
                    var winner = await Task.WhenAny(enumTask, Task.Delay(System.Threading.Timeout.Infinite, cancellationToken));
                    if (winner != enumTask)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                }
                sources = await enumTask;

                // A newer refresh attempt has started while we were awaiting the network
                // call — abandon this one so the newer attempt's results aren't clobbered.
                if (System.Threading.Volatile.Read(ref _refreshVersion) != myVersion)
                {
                    Log.Info(TAG, $"RefreshSourcesAsync v{myVersion}: superseded by newer refresh; skipping UI update");
                    return;
                }

                // Bail out if the activity is gone before we touch the UI — the
                // continuation may resume seconds after OnDestroy on a slow network.
                if (cancellationToken.IsCancellationRequested || IsFinishing || IsDestroyed)
                {
                    Log.Info(TAG, "RefreshSourcesAsync: activity torn down before continuation; skipping UI update");
                    return;
                }

                _availableSources = sources ?? Array.Empty<NDISourceInfo>();

                RunOnUiThread(() =>
                {
                    // Re-check after the RunOnUiThread hop — OnDestroy may have run
                    // between scheduling and the main-looper picking up the work, OR a
                    // newer refresh may have completed and published its labels.
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
                // Cancellation is the normal exit path during teardown — don't log as error.
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

        /// <summary>
        /// UI-thread spinner update shared between the manual refresh path and
        /// the background NDI watcher. Builds labels from <paramref name="sources"/>,
        /// swaps the spinner adapter, and re-applies the previously-selected
        /// source label if it's still in the new list. Caller is responsible
        /// for being on the UI thread.
        /// </summary>
        /// <param name="sources">New full source list to publish.</param>
        /// <param name="statusText">Status line text to show under the spinner.</param>
        /// <param name="fromWatcher">
        /// <see langword="true"/> when invoked from the <c>NDISourcesChanged</c>
        /// event — bumps <c>_refreshVersion</c> so any in-flight
        /// <c>RefreshSourcesAsync</c> continuation skips its UI update (the
        /// watcher's data is the freshest available).
        /// </param>
        private void ApplySourcesUiUpdate(NDISourceInfo[] sources, string statusText, bool fromWatcher)
        {
            if (IsFinishing || IsDestroyed)
            {
                return;
            }

            _availableSources = sources ?? Array.Empty<NDISourceInfo>();

            if (fromWatcher)
            {
                // Invalidate any in-flight RefreshSourcesAsync — its post-await
                // RunOnUiThread guard checks _refreshVersion and will now bail,
                // preventing a slower manual refresh from clobbering the watcher's
                // fresher snapshot moments later.
                System.Threading.Interlocked.Increment(ref _refreshVersion);
            }

            try
            {
                // Capture the previously selected label BEFORE swapping the adapter —
                // Android resets the spinner's selection to position 0 on Adapter
                // assignment, which silently re-targets BtStart_Click to whatever
                // source happens to be first in the new list.
                var previousLabel = _pendingRestoreSourceLabel ?? spSources?.SelectedItem?.ToString();
                _pendingRestoreSourceLabel = null;

                // Compose the spinner label from Name + URL so duplicate-Name
                // entries (two senders with the same friendly name on different
                // machines is common — e.g. two "OBS Studio (Main)" instances)
                // stay distinguishable. BtStart_Click uses SelectedItemPosition
                // into _availableSources, so the format here is purely cosmetic.
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

        /// <summary>
        /// Handles <see cref="DeviceEnumerator.NDISourcesChanged"/>. Marshals
        /// the watcher payload onto the UI thread and applies it via
        /// <see cref="ApplySourcesUiUpdate"/>. Status text is composed from the
        /// Added / Removed diff so the user gets immediate feedback when a
        /// sender appears or drops off the network — without needing to tap
        /// Refresh.
        /// </summary>
        private void OnNDISourcesChanged(object? sender, NDISourcesChangedEventArgs e)
        {
            if (_destroyed || e == null)
            {
                return;
            }

            // Compose a short status string. Prioritise the diff over the raw
            // count so something like "ROMAN-UNO went offline" is visible
            // briefly even when the list is otherwise stable — the count keeps
            // showing in the spinner itself.
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
                await BtRefreshClickAsync();
            }
            catch (Exception ex)
            {
                Log.Error(TAG, $"BtRefresh_Click failed: {ex}");
            }
        }

        private async Task BtRefreshClickAsync()
        {
            // Refresh is only valid in Idle: replacing _availableSources while a
            // pipeline is Starting/Playing would race BtStart_Click's selectedLabel
            // lookup (it could resolve to a stale or wrong info entry) and the new
            // adapter swap also resets the spinner selection visually. UpdateButtons
            // already disables btRefresh outside Idle so this branch should be unreachable
            // from the UI; it is defence in depth against programmatic clicks and against
            // future state additions that forget to extend UpdateButtons.
            var current = await GetStateAsync();
            if (current != LifecycleState.Idle)
            {
                SetStatus(StatusStrings.RefreshDisabledActive);
                return;
            }

            // Ensure a live token before refresh. OnPause cancels the previous CTS;
            // OnResume normally recreates it, but a direct/programmatic refresh can
            // also arrive first.
            await RefreshSourcesAsync(EnsureRefreshToken());
        }

        /// <summary>
        /// Atomically transition from one of <paramref name="from"/> to <paramref name="to"/>.
        /// Returns the previous state if the transition succeeded, or null if the current
        /// state was not in the allowed-from set.
        /// </summary>
        private async Task<LifecycleState?> TryTransitionAsync(LifecycleState[] from, LifecycleState to)
        {
            // Activity is gone — no further transitions are meaningful and the
            // semaphore may already be disposed. Bail before WaitAsync would throw.
            if (_destroyed)
            {
                return null;
            }

            LifecycleState? prev;
            int version;
            try
            {
                await _lifecycleLock.WaitAsync();
            }
            catch (ObjectDisposedException)
            {
                // OnDestroy disposed the lock between the _destroyed check and here.
                return null;
            }

            try
            {
                if (Array.IndexOf(from, _state) < 0)
                {
                    return null;
                }

                prev = _state;
                _state = to;
                version = System.Threading.Interlocked.Increment(ref _stateVersion);
            }
            finally
            {
                try { _lifecycleLock.Release(); }
                catch (ObjectDisposedException) { /* destroyed during await */ }
            }

            UpdateButtons(to, version);
            return prev;
        }

        private async Task SetStateAsync(LifecycleState to)
        {
            if (_destroyed)
            {
                return;
            }

            int version;
            try
            {
                await _lifecycleLock.WaitAsync();
            }
            catch (ObjectDisposedException)
            {
                return;
            }

            try
            {
                _state = to;
                version = System.Threading.Interlocked.Increment(ref _stateVersion);
            }
            finally
            {
                try { _lifecycleLock.Release(); }
                catch (ObjectDisposedException) { /* destroyed during await */ }
            }

            UpdateButtons(to, version);
        }

        /// <summary>
        /// Reads <see cref="_state"/> under the lifecycle lock. Returns the current state
        /// or null if the activity has been destroyed and the lock is no longer usable.
        /// </summary>
        private async Task<LifecycleState?> GetStateAsync()
        {
            if (_destroyed)
            {
                return null;
            }

            try
            {
                await _lifecycleLock.WaitAsync();
            }
            catch (ObjectDisposedException)
            {
                return null;
            }

            try
            {
                return _state;
            }
            finally
            {
                try { _lifecycleLock.Release(); }
                catch (ObjectDisposedException) { /* destroyed during await */ }
            }
        }

        /// <summary>
        /// Reflects lifecycle state in the Start/Stop button enabled flags. Called from
        /// every state transition so the user can never double-tap Start while a connect
        /// is in flight (which would otherwise leak the first pipeline by overwriting
        /// the field references).
        /// </summary>
        private void UpdateButtons(LifecycleState state, int expectedVersion = -1)
        {
            void Apply()
            {
                // Activity may have been destroyed between the post and now (or even
                // before, if a synchronous caller raced OnDestroy). Touching Enabled on
                // a detached/disposed view crashes with IllegalStateException or
                // ObjectDisposedException; the lifecycle peer needs the activity alive.
                if (_destroyed || IsFinishing || IsDestroyed)
                {
                    return;
                }

                try
                {
                    if (expectedVersion >= 0 && System.Threading.Volatile.Read(ref _stateVersion) != expectedVersion)
                    {
                        return;
                    }

                    bool startEnabled = state == LifecycleState.Idle;
                    bool stopEnabled = state == LifecycleState.Starting || state == LifecycleState.Playing;
                    // Refresh is gated on Idle alongside Start: reshuffling _availableSources
                    // while the pipeline is alive would corrupt BtStart_Click's selection
                    // lookup (see BtRefresh_Click guard) and visually reset the spinner.
                    bool refreshEnabled = state == LifecycleState.Idle;
                    // btStart / btStop / btRefresh are non-null after OnCreate (null! initialiser).
                    btStart.Enabled = startEnabled;
                    btStop.Enabled = stopEnabled;
                    btRefresh.Enabled = refreshEnabled;
                }
                catch (ObjectDisposedException ode)
                {
                    // Java peer collected — activity is gone.
                    Log.Warn(TAG, $"UpdateButtons skipped: {ode.Message}");
                }
                catch (Java.Lang.IllegalStateException ise)
                {
                    // View detached from window mid-update.
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

        private async void BtStart_Click(object? sender, EventArgs e)
        {
            try
            {
                await BtStartClickAsync();
            }
            catch (Exception ex)
            {
                Log.Error(TAG, $"BtStart_Click unhandled failure: {ex}");
                try { await DestroyPipelineAsync(); } catch (Exception destroyEx) { Log.Error(TAG, $"BtStart_Click cleanup failed: {destroyEx}"); }
                try { await SetStateAsync(LifecycleState.Idle); } catch (Exception stateEx) { Log.Warn(TAG, $"BtStart_Click state reset failed: {stateEx.Message}"); }
            }
        }

        private async Task BtStartClickAsync()
        {
            // Publish the start-completion TCS BEFORE any await that could block — gate
            // wait, lock acquisition, TryTransitionAsync — so a Stop tap during the
            // gate-wait can observe a non-stale TCS to await on. If a prior start
            // attempt left an unsignalled TCS in the field, complete it with false
            // here so any waiter on the stale TCS unblocks immediately. RunContinuations-
            // Asynchronously so a BtStop_Click awaiter doesn't continue inline on
            // whatever thread completes the source.
            var startCompletion = new System.Threading.Tasks.TaskCompletionSource<bool>(
                System.Threading.Tasks.TaskCreationOptions.RunContinuationsAsynchronously);
            var priorCompletion = System.Threading.Interlocked.Exchange(ref _startCompletion, startCompletion);
            priorCompletion?.TrySetResult(false);

            // Claim the Idle -> Starting transition atomically. If we don't get it,
            // someone else is already starting/playing/stopping — bail out. Complete
            // our just-published TCS so any racing Stop awaiter unblocks immediately.
            var claimed = await TryTransitionAsync(new[] { LifecycleState.Idle }, LifecycleState.Starting);
            if (claimed == null)
            {
                System.Threading.Interlocked.CompareExchange(ref _startCompletion, null, startCompletion);
                startCompletion.TrySetResult(false);
                return;
            }

            // Snapshot the array AND the selected index in one shot so the lookup is
            // self-consistent even if a refresh races us mid-method. _availableSources is
            // a reference assignment so the local snapshot is immune to a later replacement.
            // Using the spinner index (rather than matching by Name/label) is critical:
            // multiple NDI senders publishing the same friendly Name is common (two OBS
            // instances, multiple cameras with default names) and a Name-based lookup
            // would silently bind to the wrong source. UpdateButtons gates Refresh on
            // Idle so the adapter cannot swap between this read and the snapshot, but the
            // snapshot+index pair is still the correct invariant to enforce.
            var sourcesSnapshot = _availableSources;
            var selectedIndex = spSources?.SelectedItemPosition ?? -1;
            if (sourcesSnapshot.Length == 0 || selectedIndex < 0 || selectedIndex >= sourcesSnapshot.Length)
            {
                SetStatus(StatusStrings.SelectSourceFirst);
                System.Threading.Interlocked.CompareExchange(ref _startCompletion, null, startCompletion);
                startCompletion.TrySetResult(false);
                await SetStateAsync(LifecycleState.Idle);
                return;
            }

            var info = sourcesSnapshot[selectedIndex];
            if (info == null)
            {
                Log.Warn(TAG, $"BtStart_Click: selected source at index {selectedIndex} is null");
                SetStatus(StatusStrings.SelectedSourceInvalid);
                System.Threading.Interlocked.CompareExchange(ref _startCompletion, null, startCompletion);
                startCompletion.TrySetResult(false);
                await SetStateAsync(LifecycleState.Idle);
                return;
            }

            // Log only the friendly source name at Info level. The URL embeds LAN
            // topology details (host/IP/port), so keep it out of routine bug-report logs.
            Log.Info(TAG, $"BtStart_Click: starting NDI source '{info.Name}'");
            SetStatus($"Connecting to '{info.Name}'...");

            // Fresh CTS per start attempt — a previous failed/cancelled run may have
            // left the previous instance in a cancelled state. BtStop_Click and
            // OnDestroy cancel via a snapshot so the swap here is safe.
            var startCts = new System.Threading.CancellationTokenSource();
            _startCts = startCts;

            // Wait (bounded) for any in-flight teardown on a previous activity
            // instance. async-void OnDestroy yields to Android before its
            // DisposeAsync finishes, so on a fast orientation change the new
            // instance can land here while the old instance still holds GStreamer
            // resources. The gate is process-static so it serializes across
            // instances. Bounded so a hung previous teardown can't permanently
            // jam Start — we proceed anyway and surface a status note.
            //
            // _startCompletion is already published above (before the transition / any
            // await) so a Stop tap during this gate wait can observe and await our TCS;
            // the finally block at the end always TrySetResult(true) regardless of
            // success/exception, ensuring no Stop awaiter waits forever.
            bool gateAcquired = false;
            try
            {
                gateAcquired = await _pipelineGate.WaitAsync(PipelineGateWait);
            }
            catch (Exception ex)
            {
                Log.Warn(TAG, $"BtStart_Click: pipeline gate wait failed: {ex.Message}");
            }

            if (!gateAcquired)
            {
                Log.Warn(TAG, $"BtStart_Click: pipeline gate not acquired within {PipelineGateWait.TotalSeconds:F0}s — proceeding anyway");
            }

            MediaBlocksPipeline? pipelineLocal = null;
            NDISourceBlock? ndiLocal = null;
            VideoRendererBlock? videoRendererLocal = null;
            AudioRendererBlock? audioRendererLocal = null;
            bool localsPublished = false;

            try
            {
                var settings = await NDISourceSettings.CreateAsync(null, info);
                if (settings == null)
                {
                    SetStatus(StatusStrings.FailedCreateSettings);
                    await DestroyPipelineAsync();
                    await SetStateAsync(LifecycleState.Idle);
                    return;
                }

                // This sample should show the source at its native cadence.
                // NDISourceSettings defaults to a 30 fps Android pull cap for
                // phone-friendly playback; opt out here while profiling renderer
                // throughput.
                settings.MaxPullFps = 0;

                // Build the pipeline + blocks into LOCAL variables first; only
                // publish to instance fields after Connect succeeds. Previously
                // we assigned _pipeline / _ndiSource / _videoRenderer / _audioRenderer
                // line-by-line as they were constructed — which meant a Connect()
                // throwing partway left BtStop_Click visible to a half-built
                // _pipeline (with one block hooked, the other still null), and a
                // concurrent BtStop_Click handler would NRE inside DestroyPipelineAsync
                // when DisposeAsync iterated a pipeline whose connect graph was
                // partially built. Local-then-publish ensures the fields move
                // atomically from "all null" to "fully constructed".
                pipelineLocal = new MediaBlocksPipeline();

                ndiLocal = new NDISourceBlock(settings);

                // No explicit resize / rate-limiter blocks here. The sample keeps
                // the NDI receiver uncapped and does not opt into VideoRendererBlock's
                // optional Android resize or frame-rate limiter path.
                videoRendererLocal = new VideoRendererBlock(pipelineLocal, videoView)
                {
                    // NDI on Android pushes frames from a live capture thread via appsrc.
                    // The renderer's appsink must skip preroll (async=false) so the pipeline
                    // can transition PAUSED → PLAYING without waiting for a buffer that a
                    // live source will never deliver.
                    IsLive = true,

                    // This demo is a live preview, so prefer newest-frame rendering over
                    // clock-synchronized playback pacing on the managed Android view path.
                    IsSync = false,
                };
                audioRendererLocal = new AudioRendererBlock();

                pipelineLocal.Connect(ndiLocal.VideoOutput, videoRendererLocal.Input);

                // NDI sources can be video-only. ndiLocal.AudioOutput is a
                // wrapper pad created unconditionally in NDISourceBlock's
                // constructor (so it's always non-null), but its internal
                // GstPad is only wired when the source actually has an audio
                // stream — checked here via the probed MediaFileInfo. Calling
                // Connect on a wrapper whose internal pad never gets wired
                // raises PadConnector errors and blocks the PAUSED → PLAYING
                // state transition for an otherwise-fine video-only source.
                var probedInfo = settings.GetInfo();
                bool hasAudio = probedInfo?.AudioStreams != null && probedInfo.AudioStreams.Count > 0;
                if (hasAudio)
                {
                    pipelineLocal.Connect(ndiLocal.AudioOutput, audioRendererLocal.Input);
                }
                else
                {
                    Log.Info(TAG, "BtStart_Click: NDI source has no audio stream — audio renderer left disconnected");
                }
                pipelineLocal.OnError += Pipeline_OnError;

                // Publish atomically under the lifecycle lock so BtStop_Click cannot
                // observe a half-populated set of fields. _destroyed check guards
                // against OnDestroy racing with this publish — if the activity is
                // gone, dispose the locals here and return Idle.
                if (_destroyed)
                {
                    await DisposeUnpublishedPipelineAsync(pipelineLocal, ndiLocal, videoRendererLocal, audioRendererLocal);
                    pipelineLocal = null;
                    ndiLocal = null;
                    videoRendererLocal = null;
                    audioRendererLocal = null;
                    await SetStateAsync(LifecycleState.Idle);
                    return;
                }

                try
                {
                    await _lifecycleLock.WaitAsync();
                }
                catch (ObjectDisposedException)
                {
                    // OnDestroy disposed the lock while we were building. Tear the
                    // locals down and bail.
                    await DisposeUnpublishedPipelineAsync(pipelineLocal, ndiLocal, videoRendererLocal, audioRendererLocal);
                    pipelineLocal = null;
                    ndiLocal = null;
                    videoRendererLocal = null;
                    audioRendererLocal = null;
                    return;
                }

                try
                {
                    if (_state != LifecycleState.Starting)
                    {
                        throw new OperationCanceledException("Start was cancelled before the pipeline was published.");
                    }

                    _pipeline = pipelineLocal;
                    _ndiSource = ndiLocal;
                    _videoRenderer = videoRendererLocal;
                    _audioRenderer = audioRendererLocal;
                    System.Threading.Volatile.Write(ref _pipelineErrorsEnabled, 1);
                    localsPublished = true;
                    pipelineLocal = null;
                    ndiLocal = null;
                    videoRendererLocal = null;
                    audioRendererLocal = null;
                }
                finally
                {
                    try { _lifecycleLock.Release(); }
                    catch (ObjectDisposedException) { /* destroyed during await */ }
                }

                // Race StartAsync against a hard timeout AND the cancellation token so
                // a slow NDI probe (up to ~10s by NDISourceBlock contract) can't strand
                // the UI in "Connecting…" if the source goes silent mid-handshake.
                // BtStop_Click flips _state to Stopping and cancels _startCts, which
                // unblocks the Task.Delay arm and lets us tear down the half-built
                // pipeline below. On timeout we cancel the CTS ourselves so any other
                // cancellation observers see consistent state.
                var startTask = _pipeline.StartAsync();
                var timeoutTask = Task.Delay(StartTimeout, startCts.Token);
                var winner = await Task.WhenAny(startTask, timeoutTask);

                if (winner != startTask)
                {
                    // Either the user pressed Stop (token cancelled) or we hit the timeout.
                    // Cancel our own CTS so the Task.Delay completes before we proceed.
                    if (!startCts.IsCancellationRequested)
                    {
                        Log.Warn(TAG, $"BtStart_Click: StartAsync exceeded {StartTimeout.TotalSeconds:F0}s budget — aborting");
                        SetStatus(StatusStrings.ConnectionTimedOut);
                        try { startCts.Cancel(); } catch (Exception) { /* already disposed/cancelled */ }
                    }
                    else
                    {
                        Log.Info(TAG, "BtStart_Click: cancelled by user during StartAsync");
                        SetStatus(StatusStrings.Cancelled);
                    }

                    // Best-effort: observe the still-running StartAsync so its eventual
                    // exception (if any) doesn't surface as an UnobservedTaskException.
                    // We don't await it here — that would just re-introduce the very
                    // wait we're trying to escape. The pipeline disposal below will
                    // tear down whatever state StartAsync leaves behind.
                    _ = startTask.ContinueWith(
                        t => Log.Warn(TAG, $"BtStart_Click: late StartAsync result observed: {t.Exception?.GetBaseException().Message ?? "ok"}"),
                        System.Threading.Tasks.TaskScheduler.Default);

                    await DestroyPipelineAsync();
                    await SetStateAsync(LifecycleState.Idle);
                    return;
                }

                // StartAsync completed — propagate any exception it captured.
                await startTask;

                // BtStop_Click may have transitioned us to Stopping while we were
                // awaiting the (potentially multi-second) NDI probe + StartAsync. If so,
                // tear down the half-built pipeline that Stop couldn't see.
                var promoted = await TryTransitionAsync(new[] { LifecycleState.Starting }, LifecycleState.Playing);
                if (promoted == null)
                {
                    await DestroyPipelineAsync();
                    await SetStateAsync(LifecycleState.Idle);
                    SetStatus(StatusStrings.Stopped);
                    return;
                }

                SetStatus($"Playing '{info.Name}'");
            }
            catch (Exception ex)
            {
                Log.Error(TAG, $"BtStart_Click failed: {ex}");
                if (!localsPublished)
                {
                    await DisposeUnpublishedPipelineAsync(pipelineLocal, ndiLocal, videoRendererLocal, audioRendererLocal);
                    pipelineLocal = null;
                    ndiLocal = null;
                    videoRendererLocal = null;
                    audioRendererLocal = null;
                }

                // If Stop already flipped us to Stopping, the user explicitly
                // cancelled — don't show "Start failed: <cancellation message>"
                // which is misleading. Stop owns the final status update for that
                // path (it awaits our completion TCS and writes "Stopped").
                var current = await GetStateAsync();
                if (current == LifecycleState.Stopping)
                {
                    Log.Info(TAG, "BtStart_Click: cancelled by user during Start; suppressing failure status");
                }
                else if (!_destroyed)
                {
                    SetStatus($"Start failed: {ex.Message}");
                }

                await DestroyPipelineAsync();
                await SetStateAsync(LifecycleState.Idle);
            }
            finally
            {
                // Drop the CTS reference and dispose only if it's still ours — Stop or
                // OnDestroy may have already snapshotted and replaced it during the
                // await chain above.
                if (System.Threading.Interlocked.CompareExchange(ref _startCts, null, startCts) == startCts)
                {
                    try { startCts.Dispose(); } catch (Exception) { /* already disposed */ }
                }

                // Same swap-then-clear pattern for the completion signal. Set the
                // result AFTER clearing the field so any awaiter sees a consistent
                // "no in-flight start" state once it observes the completion.
                System.Threading.Interlocked.CompareExchange(ref _startCompletion, null, startCompletion);
                startCompletion.TrySetResult(true);

                // Release the pipeline gate ONLY if we actually acquired it.
                // Releasing without an acquire would corrupt the semaphore count.
                if (gateAcquired)
                {
                    try { _pipelineGate.Release(); }
                    catch (Exception ex) { Log.Warn(TAG, $"BtStart_Click: pipeline gate release failed: {ex.Message}"); }
                }
            }
        }

        private async void BtStop_Click(object? sender, EventArgs e)
        {
            try
            {
                await BtStopClickAsync();
            }
            catch (Exception ex)
            {
                Log.Error(TAG, $"BtStop_Click unhandled failure: {ex}");
                try { await SetStateAsync(LifecycleState.Idle); } catch (Exception stateEx) { Log.Warn(TAG, $"BtStop_Click state reset failed: {stateEx.Message}"); }
            }
        }

        private async Task BtStopClickAsync()
        {
            // Accept Stop in both Starting and Playing states so a tap during the NDI
            // probe (up to ~10s) can still cancel a half-built pipeline. The Starting ->
            // Stopping transition is what BtStart_Click checks for after StartAsync
            // returns; if it sees Stopping it disposes and returns to Idle itself.
            var claimed = await TryTransitionAsync(
                new[] { LifecycleState.Starting, LifecycleState.Playing },
                LifecycleState.Stopping);

            if (claimed == null)
            {
                return;
            }

            if (claimed == LifecycleState.Starting)
            {
                // BtStart_Click owns the in-flight pipeline and will tear it down when
                // StartAsync returns and it sees Stopping. Don't race it — but DO
                // cancel its CTS so the Task.WhenAny race exits immediately instead of
                // waiting up to 12s for the StartTimeout. Snapshot to a local first so
                // a concurrent BtStart_Click finally-block can't dispose under us.
                var ctsSnapshot = System.Threading.Volatile.Read(ref _startCts);
                if (ctsSnapshot != null)
                {
                    try { ctsSnapshot.Cancel(); }
                    catch (ObjectDisposedException) { /* CTS already cleaned up */ }
                    catch (Exception ex) { Log.Warn(TAG, $"BtStop_Click: start CTS cancel failed: {ex.Message}"); }
                }

                SetStatus(StatusStrings.CancellingStart);

                // Wait (bounded) for BtStart_Click's finally block to complete its
                // own teardown. Without this, Stop's "Cancelling start..." status
                // would be immediately overwritten by Start's catch block writing
                // "Start failed: ...", confusing the user. The TCS snapshot is safe
                // even if Start's finally clears _startCompletion — we hold the local.
                var completionSnapshot = System.Threading.Volatile.Read(ref _startCompletion);
                if (completionSnapshot != null)
                {
                    try
                    {
                        await Task.WhenAny(completionSnapshot.Task, Task.Delay(StartCancelWait));
                    }
                    catch (Exception ex)
                    {
                        Log.Warn(TAG, $"BtStop_Click: wait on start completion failed: {ex.Message}");
                    }
                }

                if (!_destroyed)
                {
                    SetStatus(StatusStrings.Stopped);
                }
                return;
            }

            try
            {
                await DestroyPipelineAsync();
                SetStatus(StatusStrings.Stopped);
            }
            catch (Exception ex)
            {
                Log.Error(TAG, $"BtStop_Click failed: {ex}");
            }
            finally
            {
                await SetStateAsync(LifecycleState.Idle);
            }
        }

        private async Task DestroyPipelineAsync()
        {
            MediaBlocksPipeline? pipelineSnapshot;
            NDISourceBlock? ndiSnapshot;
            VideoRendererBlock? videoSnapshot;
            AudioRendererBlock? audioSnapshot;

            try
            {
                await _destroyPipelineLock.WaitAsync();
            }
            catch (ObjectDisposedException)
            {
                return;
            }

            try
            {
                System.Threading.Volatile.Write(ref _pipelineErrorsEnabled, 0);

                pipelineSnapshot = _pipeline;
                ndiSnapshot = _ndiSource;
                videoSnapshot = _videoRenderer;
                audioSnapshot = _audioRenderer;

                _pipeline = null;
                _ndiSource = null;
                _videoRenderer = null;
                _audioRenderer = null;
            }
            finally
            {
                try { _destroyPipelineLock.Release(); }
                catch (ObjectDisposedException) { /* destroyed during teardown */ }
            }

            if (pipelineSnapshot != null)
            {
                pipelineSnapshot.OnError -= Pipeline_OnError;

                // Stop FIRST so the renderer transitions to NULL while its surface
                // (videoView) is still attached. DisposeAsync alone tears the bin
                // down without an explicit state transition, which can crash the
                // native renderer on Android when the underlying SurfaceView is
                // about to go away under us during OnDestroy. Only swallow the
                // "already stopped" InvalidOperationException — every other
                // exception (e.g. native crash, assertion failure surfacing as a
                // different type) indicates a real teardown problem and must
                // propagate to the outer catch so it gets logged at Error level
                // and visible in the bug report. Previously we caught Exception
                // wholesale and demoted real failures to a Warn line that was
                // easy to miss in the noise.
                try
                {
                    await pipelineSnapshot.StopAsync();
                }
                catch (InvalidOperationException ex)
                {
                    Log.Warn(TAG, $"Pipeline StopAsync — likely already stopped: {ex.Message}");
                }

                try
                {
                    await pipelineSnapshot.DisposeAsync();
                }
                catch (Exception ex)
                {
                    Log.Error(TAG, $"Pipeline DisposeAsync failed: {ex}");
                }
            }

            // Dispose any block fields that were created but never connected to the
            // pipeline (e.g. construction threw between block creation and Connect).
            // Pipeline.DisposeAsync only owns blocks that were successfully Connect'd,
            // so unconnected blocks would otherwise leak native handles.
            DisposeIndividualBlocks(ndiSnapshot, videoSnapshot, audioSnapshot);
        }

        /// <summary>
        /// Defensively dispose and null every block field. Safe to call when the
        /// pipeline has already disposed them (a second Dispose is a no-op for our
        /// blocks) and necessary when blocks were created but never connected.
        /// </summary>
        private void DisposeIndividualBlocks(NDISourceBlock? ndiSource, VideoRendererBlock? videoRenderer, AudioRendererBlock? audioRenderer)
        {
            try { ndiSource?.Dispose(); }
            catch (Exception ex) { Log.Error(TAG, $"NDISource Dispose failed: {ex}"); }

            try { videoRenderer?.Dispose(); }
            catch (Exception ex) { Log.Error(TAG, $"VideoRenderer Dispose failed: {ex}"); }

            try { audioRenderer?.Dispose(); }
            catch (Exception ex) { Log.Error(TAG, $"AudioRenderer Dispose failed: {ex}"); }
        }

        private async Task DisposeUnpublishedPipelineAsync(
            MediaBlocksPipeline? pipeline,
            NDISourceBlock? ndiSource,
            VideoRendererBlock? videoRenderer,
            AudioRendererBlock? audioRenderer)
        {
            if (pipeline != null)
            {
                try { pipeline.OnError -= Pipeline_OnError; }
                catch (Exception ex) { Log.Warn(TAG, $"DisposeUnpublishedPipelineAsync: OnError detach failed: {ex.Message}"); }

                try { await pipeline.DisposeAsync(); }
                catch (Exception ex) { Log.Error(TAG, $"Unpublished pipeline DisposeAsync failed: {ex}"); }
            }

            DisposeIndividualBlocks(ndiSource, videoRenderer, audioRenderer);
        }

        private void Pipeline_OnError(object? sender, ErrorsEventArgs e)
        {
            // OnDestroy may have set _destroyed and already detached us, but a pipeline
            // error event already in flight can still resurface here (the bus thread is
            // independent of the activity lifecycle). Bail before we marshal to a UI
            // thread that no longer has a view to update.
            var pipelineSnapshot = System.Threading.Volatile.Read(ref _pipeline);
            if (_destroyed ||
                System.Threading.Volatile.Read(ref _pipelineErrorsEnabled) == 0 ||
                pipelineSnapshot == null ||
                !ReferenceEquals(sender, pipelineSnapshot))
            {
                return;
            }

            Log.Error(TAG, $"Pipeline error: {e.Message}");
            RunOnUiThread(() =>
            {
                var currentPipeline = System.Threading.Volatile.Read(ref _pipeline);
                if (_destroyed ||
                    System.Threading.Volatile.Read(ref _pipelineErrorsEnabled) == 0 ||
                    currentPipeline == null ||
                    !ReferenceEquals(sender, currentPipeline))
                {
                    return;
                }

                SetStatus($"Pipeline error: {e.Message}");
            });
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
                Log.Warn(TAG, $"OnSaveInstanceState skipped state save: {ex.Message}");
            }
        }

        // NOTE: async void OnDestroy returns to Android at the first await; the continuation
        // (and base.OnDestroy below) still runs on a possibly-detached activity. We bound
        // the teardown wait and swallow exceptions so a slow/failing dispose can't crash
        // the process during activity destruction.
        protected override async void OnDestroy()
        {
            // Mark destroyed FIRST so every callback that checks _destroyed bails before
            // touching the lifecycle lock or UI. Subsequent disposal of _lifecycleLock at
            // the end of this method depends on this gate to avoid ObjectDisposedException
            // from latent continuations.
            _destroyed = true;

            try { btRefresh.Click -= BtRefresh_Click; } catch (Exception ex) { Log.Warn(TAG, $"OnDestroy: refresh click detach failed: {ex.Message}"); }
            try { btStart.Click -= BtStart_Click; } catch (Exception ex) { Log.Warn(TAG, $"OnDestroy: start click detach failed: {ex.Message}"); }
            try { btStop.Click -= BtStop_Click; } catch (Exception ex) { Log.Warn(TAG, $"OnDestroy: stop click detach failed: {ex.Message}"); }

            // Unsubscribe from the NDI watcher BEFORE asking it to stop —
            // detaching first means a final in-flight notification on the
            // watcher thread won't fire OnNDISourcesChanged against an
            // activity already mid-tear-down (we set _destroyed=true above as
            // a second guard, but unsubscribe is the cleaner contract).
            try { DeviceEnumerator.Shared.NDISourcesChanged -= OnNDISourcesChanged; } catch (Exception ex) { Log.Warn(TAG, $"OnDestroy: NDI watcher detach failed: {ex.Message}"); }
            // Do NOT call DeviceEnumerator.Shared.StopNDISourceWatch() here —
            // DeviceEnumerator.Shared is a process-wide singleton that may
            // outlive this activity (e.g. another Activity in the same app
            // would lose its watcher). DeviceEnumerator.Dispose() stops it
            // when the singleton itself goes away.

            try
            {
                _systemInsetsListener?.Dispose();
                _systemInsetsListener = null;
            }
            catch (Exception ex)
            {
                Log.Warn(TAG, $"OnDestroy: insets listener dispose failed: {ex.Message}");
            }

            // Acquire the process-wide pipeline gate around the entire teardown.
            // Pairs with BtStart_Click's gate acquisition so a fresh activity
            // instance constructed during a fast orientation change cannot start
            // building a new pipeline while this instance is still tearing the old
            // one down. Bounded WaitAsync so a hung peer can't permanently block
            // OnDestroy (which would leak the activity). If we don't acquire, we
            // proceed with teardown anyway — releasing only when we did acquire.
            bool gateAcquired = false;
            try
            {
                gateAcquired = await _pipelineGate.WaitAsync(PipelineGateWait);
                if (!gateAcquired)
                {
                    Log.Warn(TAG, $"OnDestroy: pipeline gate not acquired within {PipelineGateWait.TotalSeconds:F0}s — proceeding anyway");
                }
            }
            catch (Exception ex)
            {
                Log.Warn(TAG, $"OnDestroy: pipeline gate wait failed: {ex.Message}");
            }

            try
            {
                // Cancel any in-flight RefreshSourcesAsync so its RunOnUiThread continuation
                // bails out instead of mutating views on a destroyed activity. Cancel BEFORE
                // pipeline teardown so the cancellation observation has a chance to fire while
                // we are awaiting DestroyPipelineAsync below.
                try
                {
                    _refreshCts?.Cancel();
                }
                catch (Exception ex)
                {
                    Log.Warn(TAG, $"OnDestroy: refresh cancel failed: {ex.Message}");
                }

                // Cancel any in-flight start so the Task.WhenAny in BtStart_Click bails
                // immediately rather than waiting up to 12s on StartTimeout while the
                // activity is being torn down.
                try
                {
                    System.Threading.Volatile.Read(ref _startCts)?.Cancel();
                }
                catch (ObjectDisposedException)
                {
                    // Race with BtStart_Click finally — already disposed; nothing to do.
                }
                catch (Exception ex)
                {
                    Log.Warn(TAG, $"OnDestroy: start cancel failed: {ex.Message}");
                }

                try
                {
                    var teardown = DestroyPipelineAsync();
                    var done = await Task.WhenAny(teardown, Task.Delay(TimeSpan.FromSeconds(5)));
                    if (done != teardown)
                    {
                        Log.Warn(TAG, "Pipeline teardown exceeded 5s budget");

                        // Teardown is still running but we're abandoning the wait. The
                        // pipeline's OnError handler still strong-refs `this` via
                        // Pipeline_OnError, which would keep the activity alive past
                        // OnDestroy if we just walked away. Detach defensively — a
                        // late teardown may also detach again, but -= on an absent
                        // delegate is a safe no-op.
                        var pipelineSnapshot = _pipeline;
                        if (pipelineSnapshot != null)
                        {
                            try
                            {
                                pipelineSnapshot.OnError -= Pipeline_OnError;
                            }
                            catch (Exception detachEx)
                            {
                                Log.Warn(TAG, $"OnDestroy: defensive OnError detach failed: {detachEx.Message}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(TAG, $"OnDestroy teardown failed: {ex}");
                }

                // Intentionally do NOT dispose _refreshCts here. RefreshSourcesAsync's
                // RunOnUiThread continuation may still observe the token after OnDestroy
                // returns (the lambda is queued to the main looper), and reading
                // CancellationToken on a disposed source throws ObjectDisposedException.
                // Cancellation is enough to make the continuation bail; GC will reclaim
                // the CTS once all references (the queued lambda, the field) settle.
                // Null the field so post-OnDestroy callers see "no token" rather than
                // a stale (but still alive) cancelled source.
                System.Threading.Volatile.Write(ref _refreshCts, null);

                // NOTE: DestroySDK is process-wide — do not call from per-activity OnDestroy. Process kill handles cleanup.

                // Dispose the lifecycle lock now that the teardown wait has resolved. Any
                // late callback (RefreshSourcesAsync continuation, Pipeline_OnError marshaled
                // to UI) is gated by _destroyed checks above, so they won't try to acquire
                // a disposed semaphore.
                try
                {
                    _lifecycleLock.Dispose();
                }
                catch (Exception ex)
                {
                    Log.Warn(TAG, $"OnDestroy: lifecycle lock dispose failed: {ex.Message}");
                }

                try
                {
                    _destroyPipelineLock.Dispose();
                }
                catch (Exception ex)
                {
                    Log.Warn(TAG, $"OnDestroy: destroy-pipeline lock dispose failed: {ex.Message}");
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
            finally
            {
                if (gateAcquired)
                {
                    try { _pipelineGate.Release(); }
                    catch (Exception ex) { Log.Warn(TAG, $"OnDestroy: pipeline gate release failed: {ex.Message}"); }
                }
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
                        // Replace below.
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
            // Cancel any in-flight NDI discovery so its mDNS query loop and the
            // RunOnUiThread continuation stop burning radio + CPU while the activity
            // is backgrounded. Do NOT dispose the CTS here: OnResume recreates it
            // before the next refresh. The pipeline is stopped in OnStop, where the
            // SurfaceView can be destroyed by the framework.
            try
            {
                _refreshCts?.Cancel();
            }
            catch (ObjectDisposedException)
            {
                // Already disposed by OnDestroy racing with OnPause — nothing to cancel.
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
                var state = await GetStateAsync();
                if (state == LifecycleState.Starting || state == LifecycleState.Playing)
                {
                    await BtStopClickAsync();
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

            // grantResults is empty when the request was cancelled (e.g. activity
            // recreated mid-dialog). Treat empty as denied so the UI surfaces a clear
            // message rather than silently re-running discovery against a permission
            // we never actually have.
            bool allGranted = grantResults != null
                              && grantResults.Length == permissions.Length
                              && grantResults.All(r => r == Permission.Granted);

            if (allGranted)
            {
                Log.Info(TAG, "Permissions granted; refreshing NDI sources");
                // Re-run discovery now that ChangeWifiMulticastState (the one critical
                // for NDI mDNS resolution) is actually granted. The OnCreate refresh ran
                // before the user tapped through the dialog, so on cold start without a
                // re-run the spinner shows "(no sources found)" forever even when
                // sources are present on the network.
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
                // Although ConfigChanges.Orientation|ScreenSize prevents activity recreation,
                // the framework still re-inflates resource-qualified layouts (layout-land vs
                // layout-port) under us, which destroys and re-creates the panel view. The
                // _panelView field would then point at the old instance, ApplySystemInsets
                // would mutate a detached view, and the new on-screen panel would never
                // receive padding adjustments. Re-resolve the field and re-attach the inset
                // listener so insets continue to apply to the live view tree.
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

            if (global::Android.OS.Build.VERSION.SdkInt >= global::Android.OS.BuildVersionCodes.R)
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
