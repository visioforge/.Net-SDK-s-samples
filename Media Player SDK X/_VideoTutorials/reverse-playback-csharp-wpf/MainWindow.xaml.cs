using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Win32;
using VisioForge.Core;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;

namespace ReversePlaybackWpf;

public partial class MainWindow : Window
{
    private MediaPlayerCoreX _player;

    private readonly DispatcherTimer _timer = new() { Interval = TimeSpan.FromMilliseconds(250) };

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await VisioForgeX.InitSDKAsync();

        _player = new MediaPlayerCoreX(VideoView1);
        _player.OnError += (_, args) => Dispatcher.InvokeAsync(() => edLog.AppendText(args.Message + Environment.NewLine));

        // Raised by StopAsync and when playback reaches the start (reverse) or the end (forward) of the file
        _player.OnStop += (_, _) => Dispatcher.InvokeAsync(() =>
        {
            if (btStop.IsEnabled && _player.State == PlaybackState.Free) Stopped();
        });

        _timer.Tick += Timer_Tick;
        btPlay.IsEnabled = true;
    }

    private void btOpen_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Video files|*.mp4;*.mkv;*.avi;*.mov;*.wmv;*.webm;*.ts|All files|*.*"
        };

        if (dialog.ShowDialog() == true) edFilename.Text = dialog.FileName;
    }

    private async void btPlay_Click(object sender, RoutedEventArgs e)
    {
        ShowBusy();
        edLog.Clear();

        if (await _player.OpenAsync(edFilename.Text)) await _player.PlayAsync();

        // Free: the file did not open or play (the reason is in the log), or it has already ended
        if (_player.State == PlaybackState.Free)
        {
            Stopped();
            return;
        }

        ShowPlaying(true);
        _timer.Start();
    }

    // Backwards from the current position to the start of the file
    private async void btReverse_Click(object sender, RoutedEventArgs e)
    {
        await _player.Rate_SetAsync(-slSpeed.Value);
    }

    private async void btForward_Click(object sender, RoutedEventArgs e)
    {
        await _player.Rate_SetAsync(slSpeed.Value);
    }

    // The whole file backwards: with the reverse rate on, a seek to the end plays back to the start
    private async void btFromEnd_Click(object sender, RoutedEventArgs e)
    {
        if (await _player.Rate_SetAsync(-slSpeed.Value))
            await _player.Position_SetAsync(await _player.DurationAsync());
    }

    // One frame back, then paused: PrevFrame steps against the playback direction, NextFrame along it
    private async void btStepBack_Click(object sender, RoutedEventArgs e)
    {
        if (await _player.Rate_GetAsync() > 0)
        {
            // PrevFrame resets a forward rate to 1.0: back to the chosen speed
            if (await Task.Run(_player.PrevFrame) && slSpeed.Value != 1) await _player.Rate_SetAsync(slSpeed.Value);
        }
        else
            await Task.Run(_player.NextFrame);
    }

    private async void btPause_Click(object sender, RoutedEventArgs e)
    {
        await _player.PauseAsync();
    }

    private async void btResume_Click(object sender, RoutedEventArgs e)
    {
        await _player.ResumeAsync();
    }

    private async void btStop_Click(object sender, RoutedEventArgs e)
    {
        _timer.Stop();
        ShowBusy();
        await _player.StopAsync();
        Stopped();
    }

    // A new speed keeps the direction
    private async void slSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (!btStop.IsEnabled) return;

        var reverse = await _player.Rate_GetAsync() < 0;
        await _player.Rate_SetAsync(reverse ? -slSpeed.Value : slSpeed.Value);
    }

    private async void Timer_Tick(object sender, EventArgs e)
    {
        var position = await _player.Position_GetAsync();
        var duration = await _player.DurationAsync();
        var rate = await _player.Rate_GetAsync();
        if (!_timer.IsEnabled) return; // stopped meanwhile

        lbTime.Text = $"{position:hh\\:mm\\:ss\\.ff} / {duration:hh\\:mm\\:ss}";
        lbDirection.Text = rate < 0 ? $"Reverse x{-rate}" : $"Forward x{rate}";
    }

    private void ShowBusy()
    {
        btPlay.IsEnabled = false;
        ShowControls(false);
    }

    private void ShowPlaying(bool playing)
    {
        btPlay.IsEnabled = !playing;
        ShowControls(playing);
    }

    private void ShowControls(bool enabled)
    {
        btPause.IsEnabled = btResume.IsEnabled = btStop.IsEnabled = enabled;
        btReverse.IsEnabled = btForward.IsEnabled = btFromEnd.IsEnabled = btStepBack.IsEnabled = enabled;
    }

    private void Stopped()
    {
        _timer.Stop();
        ShowPlaying(false);
        lbTime.Text = "00:00:00.00 / 00:00:00";
        lbDirection.Text = string.Empty;
    }

    private void Window_Closing(object sender, CancelEventArgs e)
    {
        if (!btPlay.IsEnabled && !btStop.IsEnabled)
        {
            e.Cancel = true; // still loading the SDK, opening a file or stopping
            return;
        }

        _timer.Stop();
        _player.Dispose(); // stops playback first
        VisioForgeX.DestroySDK();
    }
}
