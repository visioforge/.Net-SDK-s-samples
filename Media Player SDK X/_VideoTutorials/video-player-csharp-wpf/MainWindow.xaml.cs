using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using Microsoft.Win32;
using VisioForge.Core;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;

namespace VideoPlayerWpf;

public partial class MainWindow : Window
{
    private MediaPlayerCoreX _player;

    private AudioOutputDeviceInfo[] _speakers;

    private readonly DispatcherTimer _timer = new() { Interval = TimeSpan.FromMilliseconds(500) };

    private bool _timerMovesSlider; // true while the timer, not the user, moves the timeline

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await VisioForgeX.InitSDKAsync();

        _player = new MediaPlayerCoreX(VideoView1);
        _player.OnError += (_, args) => Dispatcher.InvokeAsync(() => edLog.AppendText(args.Message + Environment.NewLine));

        // Raised by StopAsync and at the end of the file; acted on only for the end of the file
        // (Stop is enabled), not for a late stop of the previous file (State is no longer Free)
        _player.OnStop += (_, _) => Dispatcher.InvokeAsync(() =>
        {
            if (btStop.IsEnabled && _player.State == PlaybackState.Free) Stopped();
        });

        _speakers = await _player.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound);
        foreach (var device in _speakers)
            cbSpeakers.Items.Add(device.Name);

        if (cbSpeakers.Items.Count > 0) cbSpeakers.SelectedIndex = 0;

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

        if (cbSpeakers.SelectedIndex >= 0)
            _player.Audio_OutputDevice = new AudioRendererSettings(_speakers[cbSpeakers.SelectedIndex]);
        _player.Audio_OutputDevice_Volume = slVolume.Value / 100;

        if (await _player.OpenAsync(edFilename.Text))
        {
            await _player.Rate_SetAsync(slSpeed.Value); // a newly opened file starts at 1.0
            await _player.PlayAsync();
        }

        // Free: the file did not open or play (the reason is in the log), or it has already ended
        if (_player.State == PlaybackState.Free)
        {
            Stopped();
            return;
        }

        ShowPlaying(true);
        _timer.Start();
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

    private void ShowBusy()
    {
        btPlay.IsEnabled = btPause.IsEnabled = btResume.IsEnabled = btStop.IsEnabled = false;
    }

    private void ShowPlaying(bool playing)
    {
        btPlay.IsEnabled = !playing;
        btPause.IsEnabled = btResume.IsEnabled = btStop.IsEnabled = playing;
    }

    private void Stopped()
    {
        _timer.Stop();
        ShowPlaying(false);

        lbTime.Text = "00:00:00 / 00:00:00";
        _timerMovesSlider = true;
        slTimeline.Value = 0;
        _timerMovesSlider = false;
    }

    private async void Timer_Tick(object sender, EventArgs e)
    {
        var position = await _player.Position_GetAsync();
        var duration = await _player.DurationAsync();
        if (!_timer.IsEnabled || slTimeline.IsMouseCaptureWithin) return; // stopped, or the user drags

        lbTime.Text = $"{position:hh\\:mm\\:ss} / {duration:hh\\:mm\\:ss}";

        _timerMovesSlider = true;
        slTimeline.Maximum = duration.TotalSeconds;
        slTimeline.Value = position.TotalSeconds;
        _timerMovesSlider = false;
    }

    // A click on the track seeks at once, a drag seeks once when it ends
    private async void slTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (!_timerMovesSlider && !slTimeline.IsMouseCaptureWithin) await SeekAsync();
    }

    private async void slTimeline_DragCompleted(object sender, DragCompletedEventArgs e)
    {
        if (!e.Canceled && e.HorizontalChange != 0) await SeekAsync(); // not a press without a move
    }

    private async Task SeekAsync()
    {
        if (btStop.IsEnabled) await _player.Position_SetAsync(TimeSpan.FromSeconds(slTimeline.Value));
    }

    private void slVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (_player != null) _player.Audio_OutputDevice_Volume = slVolume.Value / 100;
    }

    private async void slSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (btStop.IsEnabled) await _player.Rate_SetAsync(slSpeed.Value); // Play applies it otherwise
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
