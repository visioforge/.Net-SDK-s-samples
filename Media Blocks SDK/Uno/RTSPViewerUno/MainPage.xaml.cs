using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.ONVIFX;

namespace RTSPViewerUno;

public sealed partial class MainPage : Page
{
    private MediaBlocksPipeline? _pipeline;
    private RTSPSourceBlock? _rtspSource;
    private MediaBlock? _videoRenderer;
    private AudioRendererBlock? _audioRenderer;
    private readonly DispatcherQueue _dispatcherQueue;

    private bool _sdkInitialized;
    private bool _isPlaying;

    public MainPage()
    {
        InitializeComponent();

        _dispatcherQueue = DispatcherQueue.GetForCurrentThread();

        Loaded += MainPage_Loaded;
        Unloaded += MainPage_Unloaded;
    }

        /// <summary>
        /// Main page loaded.
        /// </summary>
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        if (_sdkInitialized)
        {
            return;
        }

        try
        {
            VisioForgeX.InitSDK();
            _sdkInitialized = true;
        }
        catch (Exception ex)
        {
            ShowToast($"SDK init failed: {ex.Message}");
        }
    }

        /// <summary>
        /// Main page unloaded.
        /// </summary>
    private async void MainPage_Unloaded(object sender, RoutedEventArgs e)
    {
        await StopAsync();

        if (_sdkInitialized)
        {
            VisioForgeX.DestroySDK();
            _sdkInitialized = false;
        }
    }

        /// <summary>
        /// Open async.
        /// </summary>
    private async Task<bool> OpenAsync()
    {
        // Clean up any existing pipeline first
        await StopAsync();

        _pipeline = new MediaBlocksPipeline();
        _pipeline.OnError += Pipeline_OnError;
        _pipeline.OnStop += Pipeline_OnStop;

        // Resolve ONVIF -> RTSP if needed
        Uri uri;
        try
        {
            uri = new Uri(edURL.Text);
        }
        catch
        {
            ShowToast("Invalid URL");
            return false;
        }

        if (uri.Scheme == "http" || uri.Scheme == "https")
        {
            using var onvifClient = new ONVIFClientX();
            var result = await onvifClient.ConnectAsync(edURL.Text, edUsername.Text, edPassword.Password);
            if (result)
            {
                var profiles = await onvifClient.GetProfilesAsync();
                if (profiles != null && profiles.Length > 0)
                {
                    var mediaUri = await onvifClient.GetStreamUriAsync(profiles[0]);
                    if (mediaUri != null)
                    {
                        uri = new Uri(mediaUri.Uri);
                    }
                }
                
                // Verify URI was successfully converted to RTSP
                if (uri.Scheme != "rtsp")
                {
                    ShowToast("Unable to get RTSP source info from ONVIF URL.");
                    return false;
                }
            }
            else
            {
                ShowToast("Unable to get RTSP source info from ONVIF URL.");
                return false;
            }
        }
        else if (uri.Scheme != "rtsp")
        {
            ShowToast("Unsupported URL scheme. Must be RTSP or ONVIF HTTP(s).");
            return false;
        }

        var rtsp = await RTSPSourceSettings.CreateAsync(uri, edUsername.Text, edPassword.Password, true);

        if (cbLowLatencyMode.IsChecked == true)
        {
            rtsp.LowLatencyMode = true;
        }

        var info = rtsp.GetInfo();

        if (info == null)
        {
            ShowToast("Unable to get RTSP source info.");
            return false;
        }

        _rtspSource = new RTSPSourceBlock(rtsp);

        _videoRenderer = new VideoRendererBlock(_pipeline, videoView) { IsSync = false };

        _pipeline.Connect(_rtspSource.VideoOutput, _videoRenderer.Input);

        if (info.AudioStreams.Count > 0)
        {
            _audioRenderer = new AudioRendererBlock();
            _pipeline.Connect(_rtspSource.AudioOutput, _audioRenderer.Input);
        }

        await _pipeline.StartAsync();

        return true;
    }

        /// <summary>
        /// Stop async.
        /// </summary>
    private async Task StopAsync()
    {
        if (_pipeline != null)
        {
            try
            {
                await _pipeline.StopAsync();
            }
            catch { }

            try
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;
                await _pipeline.DisposeAsync();
            }
            catch { }
            finally
            {
                _pipeline = null;
                _rtspSource?.Dispose();
                _rtspSource = null;
                _videoRenderer?.Dispose();
                _videoRenderer = null;
                _audioRenderer?.Dispose();
                _audioRenderer = null;
            }
        }
    }

        /// <summary>
        /// Handles the btn play stop click event.
        /// </summary>
    private async void BtnPlayStop_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (!_isPlaying)
            {
                btnPlayStop.IsEnabled = false;
                btnPlayStop.Content = "⏸ Stop";

                var success = await OpenAsync();

                if (success)
                {
                    _isPlaying = true;
                    btnPlayStop.Content = "■ Stop";
                }
                else
                {
                    btnPlayStop.Content = "▶ Play";
                }

                btnPlayStop.IsEnabled = true;
            }
            else
            {
                btnPlayStop.IsEnabled = false;
                await StopAsync();
                _isPlaying = false;
                btnPlayStop.Content = "▶ Play";
                btnPlayStop.IsEnabled = true;
            }
        }
        catch (Exception ex)
        {
            ShowToast($"Error: {ex.Message}");
            btnPlayStop.Content = "▶ Play";
            btnPlayStop.IsEnabled = true;
            _isPlaying = false;
        }
    }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
    private void Pipeline_OnError(object? sender, ErrorsEventArgs e)
    {
        ShowToast($"Error: {e.Message}");
    }

        /// <summary>
        /// Pipeline on stop.
        /// </summary>
    private void Pipeline_OnStop(object? sender, VisioForge.Core.Types.Events.StopEventArgs e)
    {
        _dispatcherQueue.TryEnqueue(() =>
        {
            _isPlaying = false;
            btnPlayStop.Content = "▶ Play";
            btnPlayStop.IsEnabled = true;
        });
    }

        /// <summary>
        /// Show toast.
        /// </summary>
    private void ShowToast(string message)
    {
        System.Diagnostics.Debug.WriteLine(message);

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
                // ignore
            }
        });
    }
}