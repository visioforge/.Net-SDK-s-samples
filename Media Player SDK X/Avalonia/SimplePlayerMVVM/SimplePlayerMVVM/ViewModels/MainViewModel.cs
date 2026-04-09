using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using ReactiveUI;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.Avalonia;
using SimplePlayerMVVM;
using Splat;
using VisioForge.Core.Helpers;
using VisioForge.Core.MediaPlayerX;


#if ANDROID
using Android.Content;
using Android.Database;
using Android.Provider;
#endif

namespace Simple_Player_MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            OpenFileCommand = ReactiveCommand.Create(OpenFileAsync);
            PlayPauseCommand = ReactiveCommand.CreateFromTask(PlayPauseAsync);
            StopCommand = ReactiveCommand.CreateFromTask(StopAsync);
            SpeedCommand = ReactiveCommand.CreateFromTask(SpeedAsync);
            WindowClosingCommand = ReactiveCommand.Create(OnWindowClosing);

            // Throttled volume update
            this.WhenAnyValue(x => x.VolumeValue)
                .Throttle(TimeSpan.FromMilliseconds(50))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(v =>
                {
                    if (_player != null)
                    {
                        _player.Audio_OutputDevice_Volume = v / 100.0;
                    }
                });

            // Throttled seeking
            this.WhenAnyValue(x => x.SeekingValue)
                .Throttle(TimeSpan.FromMilliseconds(100))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(v =>
                {
                    if (!_isTimerUpdate && _player != null)
                    {
                        _ = _player.Position_SetAsync(TimeSpan.FromMilliseconds(v));
                    }
                });

            _tmPosition = new System.Timers.Timer(1000);
            _tmPosition.Elapsed += tmPosition_Elapsed;

            VisioForgeX.InitSDK();
        }

        /// <summary>
        /// The video view interface.
        /// </summary>
        public IVideoView VideoViewIntf { get; set; }

#if __ANDROID__
        /// <summary>
        /// The Android helper.
        /// </summary>
        public static IAndroidHelper AndroidHelper { get; set; }
#endif

        /// <summary>
        /// The top level window.
        /// </summary>
        public TopLevel TopLevel { get; set; }

        private string _Position = "00:00:00";

        public string Position
        {
            get => _Position;
            set => this.RaiseAndSetIfChanged(ref _Position, value);
        }

#if __IOS__ && !__MACCATALYST__

        private Foundation.NSUrl? _Filename;

        public Foundation.NSUrl? Filename
        {
            get => _Filename;
            set => this.RaiseAndSetIfChanged(ref _Filename, value);
        }

#else

        private string? _Filename;

        public string? Filename
        {
            get => _Filename;
            set => this.RaiseAndSetIfChanged(ref _Filename, value);
        }

#endif

        private string _Duration = "00:00:00";

        public string Duration
        {
            get => _Duration;
            set => this.RaiseAndSetIfChanged(ref _Duration, value);
        }

        private double _VolumeValue = 25;

        public double VolumeValue
        {
            get => _VolumeValue;
            set => this.RaiseAndSetIfChanged(ref _VolumeValue, value);
        }

        public ICommand OpenFileCommand { get; }

        public ICommand PlayPauseCommand { get; }

        private string _PlayPauseText = "PLAY";

        public string PlayPauseText
        {
            get => _PlayPauseText;
            set => this.RaiseAndSetIfChanged(ref _PlayPauseText, value);
        }

        private string _SpeedText = "SPEED: 1X";

        public string SpeedText
        {
            get => _SpeedText;
            set => this.RaiseAndSetIfChanged(ref _SpeedText, value);
        }

        public ICommand StopCommand { get; }

        public ICommand SpeedCommand { get; }

        private double _SeekingValue;

        public double SeekingValue
        {
            get => _SeekingValue;
            set => this.RaiseAndSetIfChanged(ref _SeekingValue, value);
        }

        private double _SeekingMaximum = 1;

        public double SeekingMaximum
        {
            get => _SeekingMaximum;
            set => this.RaiseAndSetIfChanged(ref _SeekingMaximum, value);
        }

        public ReactiveCommand<Unit, Unit> WindowClosingCommand { get; }

        private MediaPlayerCoreX _player;

        private volatile bool _isTimerUpdate;

        private int _timerBusy;

        private System.Timers.Timer _tmPosition;

        private async Task CreateEngineAsync()
        {
            if (_player != null)
            {
                await _player.StopAsync();
                await _player.DisposeAsync();
            }

#if __IOS__ && !__MACCATALYST__
            if (_Filename == null)
            {
                return;
            }
#else
            if (string.IsNullOrWhiteSpace(_Filename))
            {
                return;
            }
#endif

            _player = new MediaPlayerCoreX(VideoViewIntf);

            _player.OnError += _player_OnError;

            _player.Audio_Play = true;

            var sourceSettings = await UniversalSourceSettings.CreateAsync(_Filename);
            await _player.OpenAsync(sourceSettings);
        }

        private void OnWindowClosing()
        {
            if (_player != null)
            {
                _player.OnError -= _player_OnError;
                _player.Stop();

                _player.Dispose();
                _player = null;
            }

            VisioForgeX.DestroySDK();
        }

        private async Task OpenFileAsync()
        {
            await StopAllAsync();

            PlayPauseText = "PLAY";

#if __IOS__ && !__MACCATALYST__

            var filePicker = Locator.Current.GetService<IDocumentPickerService>();
            var res = await filePicker.PickVideoAsync();
            if (res != null)
            {
                Filename = (Foundation.NSUrl)res;

                var access = IOSHelper.CheckFileAccess(Filename);
                if (!access)
                {
                    IOSHelper.ShowToast("File access error");
                    return;
                }
            }

#else

            try
            {
                var files = await TopLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
                {
                    Title = "Open video file",
                    AllowMultiple = false
                });

                if (files.Count >= 1)
                {
                    var file = files[0];
                    Filename = file.Path.AbsoluteUri;

#if __ANDROID__
                    if (!Filename.StartsWith('/'))
                    {
                        Filename = global::VisioForge.Core.UI.Android.FileDialogHelper.GetFilePathFromUri(AndroidHelper.GetContext(), file.Path);
                    }
#endif
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error opening file: {ex.Message}");
            }

#endif
        }

        private async Task PlayPauseAsync()
        {
#if !__IOS__ && !__MACCATALYST__
            if (string.IsNullOrEmpty(_Filename))
            {
                return;
            }
#endif

            // START
            if (_player == null || _player.State == PlaybackState.Free)
            {
                await CreateEngineAsync();

                await _player.PlayAsync();

                _tmPosition.Start();

                PlayPauseText = "PAUSE";
            }
            else if (_player.State == PlaybackState.Play)
            {
                await _player.PauseAsync();

                PlayPauseText = "PLAY";
            }
            else if (_player.State == PlaybackState.Pause)
            {
                await _player.ResumeAsync();

                PlayPauseText = "PAUSE";
            }
        }

        private async Task StopAsync()
        {
            await StopAllAsync();

            SpeedText = "SPEED: 1X";
            PlayPauseText = "PLAY";
        }

        private async Task SpeedAsync()
        {
            if (SpeedText == "SPEED: 1X")
            {
                SpeedText = "SPEED: 2X";
                await _player.Rate_SetAsync(2.0);
            }
            else if (SpeedText == "SPEED: 2X")
            {
                SpeedText = "SPEED: 0.5X";
                await _player.Rate_SetAsync(0.5);
            }
            else if (SpeedText == "SPEED: 0.5X")
            {
                SpeedText = "SPEED: 1X";
                await _player.Rate_SetAsync(1.0);
            }
        }

        private void _player_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private async Task StopAllAsync()
        {
            if (_player == null)
            {
                return;
            }

            _tmPosition.Stop();

            if (_player != null)
            {
                await _player.StopAsync();
            }

            await Task.Delay(300);

            SeekingValue = 0;
            SeekingMaximum = 1;
        }

        private async void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Interlocked.CompareExchange(ref _timerBusy, 1, 0) != 0) return;
            try
            {
                if (_player == null)
                {
                    return;
                }

                var pos = await _player.Position_GetAsync();
                var duration = await _player.DurationAsync();
                var progress = pos.TotalMilliseconds;
                var durationMs = duration.TotalMilliseconds;

                Dispatcher.UIThread.Post(() =>
                {
                    if (_player == null)
                    {
                        return;
                    }

                    _isTimerUpdate = true;

                    if (durationMs > 0)
                    {
                        SeekingMaximum = durationMs;
                    }

                    SeekingValue = progress > SeekingMaximum ? SeekingMaximum : progress;

                    Position = pos.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture);
                    Duration = duration.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture);

                    _isTimerUpdate = false;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                Interlocked.Exchange(ref _timerBusy, 0);
            }
        }
    }
}
