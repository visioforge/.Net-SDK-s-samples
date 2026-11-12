using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using Microsoft.Win32;
using VisioForge.Core;
using VisioForge.Core.MediaPlayer;
using VisioForge.Core.Types;
using VisioForge.Core.Types.MediaPlayer;

namespace MemoryPlaybackWpf;

public partial class MainWindow : Window
{
    private MediaPlayerCore _player;

    private Stream _source; // the player reads it while it plays: closed only after the stop

    private readonly DispatcherTimer _timer = new() { Interval = TimeSpan.FromMilliseconds(500) };

    private bool _timerMovesSlider; // true while the timer, not the user, moves the timeline

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        _player = new MediaPlayerCore(VideoView1);
        _player.OnError += (_, args) => Dispatcher.InvokeAsync(() => edLog.AppendText(args.Message + Environment.NewLine));

        // Raised by StopAsync and at the end of the file; acted on only for the end of the file
        // (Stop is enabled), not for a late stop of the previous file (State is no longer Free)
        _player.OnStop += (_, _) => Dispatcher.InvokeAsync(() =>
        {
            if (btStop.IsEnabled && _player.State() == PlaybackState.Free) Stopped();
        });

        _timer.Tick += Timer_Tick;
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

        try
        {
            _source = rbByteArray.IsChecked == true
                ? new MemoryStream(await File.ReadAllBytesAsync(edFilename.Text)) // the whole file in memory
                : new FileStream(edFilename.Text, FileMode.Open, FileAccess.Read);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or ArgumentException)
        {
            edLog.AppendText(ex.Message + Environment.NewLine);
            ShowPlaying(false);
            return;
        }

        // A seekable .NET stream, wrapped as the COM IStream the player reads; the LAV splitter
        // finds the video and audio in it
        _player.Source_MemoryStream = new MemoryStreamSource(new ManagedIStream(_source), _source.Length);
        _player.Source_Mode = MediaPlayerSourceMode.Memory_DS;

        if (!await _player.PlayAsync() || _player.State() == PlaybackState.Free)
        {
            Stopped(); // did not play (the reason is in the log), or has already ended
            return;
        }

        slTimeline.Maximum = (await _player.Duration_TimeAsync()).TotalSeconds;
        ShowPlaying(true);
        _timer.Start();
    }

    private async void btPause_Click(object sender, RoutedEventArgs e)
    {
        btPause.IsEnabled = false;
        var paused = await _player.PauseAsync();
        if (!btStop.IsEnabled) return; // stopped meanwhile
        btResume.IsEnabled = paused;
        btPause.IsEnabled = !paused;
    }

    private async void btResume_Click(object sender, RoutedEventArgs e)
    {
        btResume.IsEnabled = false;
        var resumed = await _player.ResumeAsync();
        if (!btStop.IsEnabled) return; // stopped meanwhile
        btPause.IsEnabled = resumed;
        btResume.IsEnabled = !resumed;
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
        btPause.IsEnabled = btStop.IsEnabled = playing;
        btResume.IsEnabled = false;
    }

    private void Stopped()
    {
        _timer.Stop();
        ShowPlaying(false);

        _source?.Dispose(); // the player has let go of it
        _source = null;

        lbTime.Text = "00:00:00 / 00:00:00";
        _timerMovesSlider = true;
        slTimeline.Value = 0;
        _timerMovesSlider = false;
    }

    private async void Timer_Tick(object sender, EventArgs e)
    {
        var position = await _player.Position_Get_TimeAsync();
        if (!_timer.IsEnabled || slTimeline.IsMouseCaptureWithin) return; // stopped, or the user drags

        var duration = TimeSpan.FromSeconds(slTimeline.Maximum); // read once, after PlayAsync
        lbTime.Text = $"{position:hh\\:mm\\:ss} / {duration:hh\\:mm\\:ss}";

        _timerMovesSlider = true;
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
        if (btStop.IsEnabled) await _player.Position_Set_TimeAsync(TimeSpan.FromSeconds(slTimeline.Value));
    }

    private void Window_Closing(object sender, CancelEventArgs e)
    {
        _timer.Stop();
        _player.Dispose(); // stops playback; Stopped() then closes the stream, or the app's exit does
    }
}
