using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using Microsoft.Win32;
using VisioForge.Core;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.AudioEffects;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;

namespace AudioEffectsWpf;

public partial class MainWindow : Window
{
    private MediaPlayerCoreX _player;

    private AudioOutputDeviceInfo[] _speakers;

    private readonly DispatcherTimer _timer = new() { Interval = TimeSpan.FromMilliseconds(500) };

    private bool _timerMovesSlider; // true while the timer, not the user, moves the timeline

    // One instance per effect, set to the sliders' starting values: the checkbox adds or removes it,
    // and a property changed by a slider applies to the playing effect at once
    private readonly Equalizer10AudioEffect _equalizer = new(new double[10]);
    private readonly EchoAudioEffect _echo = new(TimeSpan.FromMilliseconds(300)) { Intensity = 0.5f, Feedback = 0.3f };
    private readonly ReverberationAudioEffect _reverb = new() { RoomSize = 0.8f };
    private readonly PitchAudioEffect _pitch = new() { PitchSemitones = 4 };

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
            Filter = "Media files|*.mp4;*.mkv;*.avi;*.mov;*.wmv;*.webm;*.ts;*.mp3;*.wav;*.flac;*.m4a|All files|*.*"
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
            // Effects last for one playback, so every Play adds the checked ones again
            if (cbEqualizer.IsChecked == true) _player.Audio_Effects_AddOrUpdate(_equalizer);
            if (cbEcho.IsChecked == true) _player.Audio_Effects_AddOrUpdate(_echo);
            if (cbReverb.IsChecked == true) _player.Audio_Effects_AddOrUpdate(_reverb);
            if (cbPitch.IsChecked == true) _player.Audio_Effects_AddOrUpdate(_pitch);

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

    // While playing: checking an effect adds it, unchecking removes it
    private void ApplyEffect(CheckBox box, BaseAudioEffect effect)
    {
        if (!btStop.IsEnabled) return; // not playing: Play adds the checked effects

        if (box.IsChecked == true) _player.Audio_Effects_AddOrUpdate(effect);
        else _player.Audio_Effects_Remove(effect);
    }

    private void cbEqualizer_Changed(object sender, RoutedEventArgs e) => ApplyEffect(cbEqualizer, _equalizer);

    private void slBand_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _equalizer.SetLevel(int.Parse((string)((Slider)sender).Tag), e.NewValue);
    }

    private void cbEcho_Changed(object sender, RoutedEventArgs e) => ApplyEffect(cbEcho, _echo);

    private void slEchoDelay_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _echo.Delay = TimeSpan.FromMilliseconds(e.NewValue);
    }

    private void slEchoIntensity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _echo.Intensity = (float)e.NewValue;
    }

    private void cbReverb_Changed(object sender, RoutedEventArgs e) => ApplyEffect(cbReverb, _reverb);

    private void slReverbRoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _reverb.RoomSize = (float)e.NewValue;
    }

    private void slReverbLevel_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _reverb.Level = (float)e.NewValue;
    }

    private void cbPitch_Changed(object sender, RoutedEventArgs e) => ApplyEffect(cbPitch, _pitch);

    private void slPitch_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _pitch.PitchSemitones = e.NewValue;
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
