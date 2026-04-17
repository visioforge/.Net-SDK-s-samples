
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
using SimplePlayerMVVMMB;
using Splat;


#if __ANDROID__
using Android.Content;
using Android.Database;
using Android.Provider;
#endif

namespace Simple_Player_MVVM.ViewModels
{
    /// <summary>
    /// Represents the main view model.
    /// </summary>
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

            // Throttled volume update — avoids flooding audio renderer during drag
            this.WhenAnyValue(x => x.VolumeValue)
                .Throttle(TimeSpan.FromMilliseconds(50))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(v =>
                {
                    if (_audioRenderer != null)
                    {
                        _audioRenderer.Volume = v / 100.0;
                    }
                });

            // Throttled seeking — avoids flooding pipeline with seek commands during drag
            this.WhenAnyValue(x => x.SeekingValue)
                .Throttle(TimeSpan.FromMilliseconds(100))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(v =>
                {
                    if (!_isTimerUpdate && _pipeline != null)
                    {
                        _ = _pipeline.Position_SetAsync(TimeSpan.FromMilliseconds(v));
                    }
                });

            _tmPosition = new System.Timers.Timer(1000);
            _tmPosition.Elapsed += tmPosition_Elapsed;

            VisioForgeX.InitSDK();
        }

        public IVideoView VideoViewIntf { get; set; }

#if __ANDROID__
        public static IAndroidHelper AndroidHelper { get; set; }
#endif

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

        private MediaBlocksPipeline _pipeline;

        private UniversalSourceBlock _source;

        private MediaBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private volatile bool _isTimerUpdate;

        private int _timerBusy;

        private System.Timers.Timer _tmPosition;

        private async Task CreateEngineAsync()
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync(true);
                await _pipeline.DisposeAsync();
            }

            _pipeline = new MediaBlocksPipeline();

            _pipeline.OnError += _player_OnError;
            _pipeline.OnStart += _player_OnStart;

            _audioRenderer = new AudioRendererBlock();

            var sourceSettings = await UniversalSourceSettings.CreateAsync(_Filename);
            _source = new UniversalSourceBlock(sourceSettings);

            _videoRenderer = new VideoRendererBlock(_pipeline, VideoViewIntf);

            _audioRenderer = new AudioRendererBlock();

            _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);
            _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
        }

        private void _player_OnStart(object sender, EventArgs e)
        {
            try
            {
                Dispatcher.UIThread.Post(async () =>
                {
                    if (_pipeline == null)
                    {
                        return;
                    }

                    SeekingMaximum = (await _pipeline.DurationAsync()).TotalMilliseconds;
                });
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        private void OnWindowClosing()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= _player_OnError;
                _pipeline.Stop();

                _pipeline.Dispose();
                _pipeline = null;
            }

            VisioForgeX.DestroySDK();
        }

    private async Task OpenFileAsync()
        {
            await StopAllAsync();

            PlayPauseText = "PLAY";

#if __IOS__ && !__MACCATALYST__

            // get the file name using the document picker
            var filePicker = Locator.Current.GetService<IDocumentPickerService>();
            var res = await filePicker.PickVideoAsync();
            if (res != null)
            {
                Filename = (Foundation.NSUrl)res;
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
                        Filename =
 global::VisioForge.Core.UI.Android.FileDialogHelper.GetFilePathFromUri(AndroidHelper.GetContext(), file.Path);
                    }
#endif
                }
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
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
            if (_pipeline == null || _pipeline.State == PlaybackState.Free)
            {
                await CreateEngineAsync();

                await _pipeline.StartAsync();

                _tmPosition.Start();

                PlayPauseText = "PAUSE";
            }
            else if (_pipeline.State == PlaybackState.Play)
            {
                await _pipeline.PauseAsync();

                PlayPauseText = "PLAY";
            }
            else if (_pipeline.State == PlaybackState.Pause)
            {
                await _pipeline.ResumeAsync();

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
                await _pipeline.Rate_SetAsync(2.0);
            }
            else if (SpeedText == "SPEED: 2X")
            {
                SpeedText = "SPEED: 0.5X";
                await _pipeline.Rate_SetAsync(0.5);
            }
            else if (SpeedText == "SPEED: 0.5X")
            {
                SpeedText = "SPEED: 1X";
                await _pipeline.Rate_SetAsync(1.0);
            }
        }

        private void _player_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private async Task StopAllAsync()
        {
            if (_pipeline == null)
            {
                return;
            }

            _tmPosition.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync(true);
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
                if (_pipeline == null)
                {
                    return;
                }

                var pos = await _pipeline.Position_GetAsync();
                var duration = await _pipeline.DurationAsync();
                var progress = pos.TotalMilliseconds;
                var durationMs = duration.TotalMilliseconds;

                Dispatcher.UIThread.Post(() =>
                {
                    if (_pipeline == null)
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
