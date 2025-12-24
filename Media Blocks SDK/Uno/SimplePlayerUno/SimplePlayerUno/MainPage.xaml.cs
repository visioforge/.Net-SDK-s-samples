using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using System;
using System.IO;
using System.Threading.Tasks;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
#if __IOS__ && !__MACCATALYST__
using Foundation;
#endif
#if __ANDROID__
using Android.Widget;
#endif
using DebugLogger = System.Diagnostics.Debug;

namespace SimplePlayerUno.Template;

public sealed partial class MainPage : Page
{
    private MediaBlocksPipeline? _pipeline;
    private UniversalSourceBlock? _source;
    private VideoRendererBlock? _renderer;

    private readonly DispatcherTimer _positionTimer;
    private readonly DispatcherQueue _dispatcherQueue;

    private volatile bool _isTimerUpdate;
    private bool _mediaPrepared;
    private bool _sdkInitialized;
    private bool _isPlaying;

    public MainPage()
    {
        InitializeComponent();

        _dispatcherQueue = DispatcherQueue.GetForCurrentThread();

        _positionTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(500)
        };
        _positionTimer.Tick += PositionTimer_Tick;

        Loaded += MainPage_Loaded;
        Unloaded += MainPage_Unloaded;
    }

    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        if (_sdkInitialized)
        {
            return;
        }

        try
        {
            VisioForge.Core.VisioForgeX.InitSDK();
            _sdkInitialized = true;
        }
        catch (Exception ex)
        {
            ShowToast($"SDK init failed: {ex.Message}");
        }
    }

    private async void MainPage_Unloaded(object sender, RoutedEventArgs e)
    {
        await CleanupPipelineAsync();

        if (_sdkInitialized)
        {
            VisioForge.Core.VisioForgeX.DestroySDK();
            _sdkInitialized = false;
        }
    }

    private async void BtnPlayStop_Click(object sender, RoutedEventArgs e)
    {
        if (_isPlaying)
        {
            // Stop playback
            await StopPlaybackAsync();
        }
        else if (_mediaPrepared)
        {
            // Resume
            await ResumeAsync();
        }
        else
        {
            // Load and play
            await LoadAndPlayAsync();
        }
    }

    private async Task LoadAndPlayAsync()
    {
        try
        {
            await CleanupPipelineAsync();

            if (string.IsNullOrWhiteSpace(txtMediaUrl.Text))
            {
                ShowToast("Please enter a media URL or file path.");
                return;
            }

            var inputPath = txtMediaUrl.Text.Trim();
            DebugLogger.WriteLine($"Loading media: {inputPath}");

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;

            UniversalSourceSettings sourceSettings;
            try
            {
                sourceSettings = await CreateSourceSettingsAsync(inputPath);
            }
            catch (Exception ex)
            {
                ShowToast($"Failed to open media: {ex.Message}");
                DebugLogger.WriteLine($"CreateSourceSettingsAsync error: {ex}");
                await CleanupPipelineAsync();
                return;
            }

            _source = new UniversalSourceBlock(sourceSettings);
            _renderer = new VideoRendererBlock(_pipeline, videoView);

            _pipeline.Connect(_source.VideoOutput, _renderer.Input);

            ResetTimeline();

            // Start playback immediately
            await _pipeline.StartAsync();
            
            _mediaPrepared = true;
            _positionTimer.Start();
            timelineSlider.IsEnabled = true;
            _isPlaying = true;
            btnPlayStop.Content = "\u25a0"; // Stop symbol
        }
        catch (Exception ex)
        {
            ShowToast($"Failed: {ex.Message}");
            DebugLogger.WriteLine($"LoadAndPlayAsync error: {ex}");
            
            // Clean up on failure
            await CleanupPipelineAsync();
        }
    }

    private async Task ResumeAsync()
    {
        if (_pipeline == null || !_mediaPrepared)
        {
            return;
        }

        try
        {
            await _pipeline.ResumeAsync();
            _positionTimer.Start();
            _isPlaying = true;
            btnPlayStop.Content = "\u25a0"; // Stop symbol
        }
        catch (Exception ex)
        {
            ShowToast($"Resume failed: {ex.Message}");
        }
    }

    private async Task StopPlaybackAsync()
    {
        if (_pipeline == null)
        {
            ResetTimeline();
            return;
        }

        try
        {
            _positionTimer.Stop();
            await _pipeline.StopAsync(true);
            ResetTimeline();
            _isPlaying = false;
            _mediaPrepared = false;
            btnPlayStop.Content = "\u25b6"; // Play symbol
        }
        catch (Exception ex)
        {
            ShowToast($"Stop failed: {ex.Message}");
        }
    }

    private async Task CleanupPipelineAsync()
    {
        var pipeline = _pipeline;
        if (pipeline == null)
        {
            return;
        }

        try
        {
            _positionTimer.Stop();
            pipeline.OnError -= Pipeline_OnError;
            pipeline.OnStop -= Pipeline_OnStop;

            try
            {
                await pipeline.StopAsync(true);
            }
            catch (Exception stopEx)
            {
                DebugLogger.WriteLine($"Pipeline stop warning: {stopEx.Message}");
            }

            await pipeline.DisposeAsync();
        }
        catch (Exception ex)
        {
            DebugLogger.WriteLine($"Pipeline cleanup warning: {ex.Message}");
        }
        finally
        {
            _pipeline = null;
            _source?.Dispose();
            _source = null;
            _renderer?.Dispose();
            _renderer = null;
            _mediaPrepared = false;
            ResetTimeline();
        }
    }

    private static async Task<UniversalSourceSettings> CreateSourceSettingsAsync(string input)
    {
        DebugLogger.WriteLine($"CreateSourceSettingsAsync: input = {input}");
        
#if __IOS__ && !__MACCATALYST__
        NSUrl ResolveNsUrl(string value)
        {
            if (Uri.TryCreate(value, UriKind.Absolute, out var httpUri) && !httpUri.IsFile)
            {
                return NSUrl.FromString(value);
            }

            var path = value;
            if (!Path.IsPathRooted(path))
            {
                path = Path.GetFullPath(path);
            }

            return NSUrl.CreateFileUrl(path, null);
        }

        var nsUrl = ResolveNsUrl(input);
        return await UniversalSourceSettings.CreateAsync(nsUrl);
#else
        // Check if it's a URL
        if (Uri.TryCreate(input, UriKind.Absolute, out var uri) && !uri.IsFile)
        {
            DebugLogger.WriteLine($"CreateSourceSettingsAsync: treating as URL: {uri}");
            return await UniversalSourceSettings.CreateAsync(uri);
        }

        // It's a file path - check if file exists
        var filePath = input;
        if (!Path.IsPathRooted(filePath))
        {
            filePath = Path.GetFullPath(filePath);
        }

        DebugLogger.WriteLine($"CreateSourceSettingsAsync: file path = {filePath}, exists = {File.Exists(filePath)}");
        
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }

        return await UniversalSourceSettings.CreateAsync(filePath);
#endif
    }

    private void ResetTimeline()
    {
        _isTimerUpdate = true;
        timelineSlider.IsEnabled = false;
        timelineSlider.Value = 0;
        timelineSlider.Maximum = 1;
        txtCurrentPosition.Text = "00:00";
        txtTotalDuration.Text = "00:00";
        _isTimerUpdate = false;
    }

    private void PositionTimer_Tick(object? sender, object e)
    {
        if (_pipeline == null)
        {
            return;
        }

        _ = UpdatePositionAsync();
    }

    private async Task UpdatePositionAsync()
    {
        if (_pipeline == null)
        {
            return;
        }

        try
        {
            var position = await _pipeline.Position_GetAsync();
            var duration = await _pipeline.DurationAsync();

            _dispatcherQueue.TryEnqueue(() =>
            {
                if (_pipeline == null)
                {
                    return;
                }

                _isTimerUpdate = true;

                if (duration > TimeSpan.Zero)
                {
                    var maxSeconds = duration.TotalSeconds;
                    if (timelineSlider.Maximum != maxSeconds)
                    {
                        timelineSlider.Maximum = maxSeconds;
                    }
                    txtTotalDuration.Text = FormatTime(duration);
                }

                var posSeconds = position.TotalSeconds;
                if (posSeconds > timelineSlider.Maximum)
                {
                    timelineSlider.Value = timelineSlider.Maximum;
                }
                else
                {
                    timelineSlider.Value = posSeconds;
                }

                txtCurrentPosition.Text = FormatTime(position);

                _isTimerUpdate = false;
            });
        }
        catch (Exception ex)
        {
            DebugLogger.WriteLine($"Timeline update failed: {ex.Message}");
        }
    }

    private static string FormatTime(TimeSpan value)
    {
        return value.TotalHours >= 1 ? value.ToString("hh\\:mm\\:ss") : value.ToString("mm\\:ss");
    }

    private async void TimelineSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        try
        {
            if (!_isTimerUpdate && _pipeline != null)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(e.NewValue));
            }
        }
        catch (Exception ex)
        {
            DebugLogger.WriteLine($"Seek failed: {ex.Message}");
        }
    }

    private void TimelineSlider_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        // No longer needed - kept for XAML compatibility
    }

    private void TimelineSlider_PointerReleased(object sender, PointerRoutedEventArgs e)
    {
        // No longer needed - kept for XAML compatibility
    }

    private void TimelineSlider_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
    {
        // No longer needed - kept for XAML compatibility
    }

    private void Pipeline_OnError(object? sender, ErrorsEventArgs e)
    {
        ShowToast($"Error: {e.Message}");
    }

    private void Pipeline_OnStop(object? sender, StopEventArgs e)
    {
        _dispatcherQueue.TryEnqueue(() =>
        {
            _positionTimer.Stop();
            ResetTimeline();
            _isPlaying = false;
            _mediaPrepared = false;
            btnPlayStop.Content = "\u25b6"; // Play symbol
        });
    }

    private void ShowToast(string message)
    {
        DebugLogger.WriteLine(message);

#if __ANDROID__
        _dispatcherQueue.TryEnqueue(() =>
        {
            var context = Android.App.Application.Context;
            if (context != null)
            {
                Toast.MakeText(context, message, ToastLength.Short)?.Show();
            }
        });
#elif __IOS__ && !__MACCATALYST__
        _dispatcherQueue.TryEnqueue(() =>
        {
            // Use a simple alert for iOS
            var alert = UIKit.UIAlertController.Create("", message, UIKit.UIAlertControllerStyle.Alert);
            alert.AddAction(UIKit.UIAlertAction.Create("OK", UIKit.UIAlertActionStyle.Default, null));
            
            var rootViewController = UIKit.UIApplication.SharedApplication?.KeyWindow?.RootViewController;
            if (rootViewController != null)
            {
                // Auto-dismiss after 1.5 seconds
                _ = Task.Delay(1500).ContinueWith(_ =>
                {
                    _dispatcherQueue.TryEnqueue(() => alert.DismissViewController(true, null));
                });
                rootViewController.PresentViewController(alert, true, null);
            }
        });
#else
        // For Windows/other platforms, use a simple flyout or debug output
        _dispatcherQueue.TryEnqueue(async () =>
        {
            try
            {
                var dialog = new ContentDialog
                {
                    Content = message,
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };
                
                // Auto-close after 2 seconds
                _ = Task.Delay(2000).ContinueWith(_ =>
                {
                    _dispatcherQueue.TryEnqueue(() => dialog.Hide());
                });
                
                await dialog.ShowAsync();
            }
            catch
            {
                // Ignore if dialog fails
            }
        });
#endif
    }
}
