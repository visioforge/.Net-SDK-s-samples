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

            VolumeValueChangedCommand = ReactiveCommand.Create(OnVolumeValueChanged);

            this.WhenAnyValue(x => x.VolumeValue).Subscribe(_ => VolumeValueChangedCommand.Execute().Subscribe());

            SeekingValueChangedCommand = ReactiveCommand.CreateFromTask(OnSeekingValueChanged);

            this.WhenAnyValue(x => x.SeekingValue).Subscribe(_ => SeekingValueChangedCommand.Execute().Subscribe());

            WindowClosingCommand = ReactiveCommand.Create(OnWindowClosing);

            _tmPosition = new System.Timers.Timer(1000);
            _tmPosition.Elapsed += tmPosition_Elapsed;

            VisioForgeX.InitSDK();
        }

        /// <summary>
        /// Command to handle volume value changes.
        /// </summary>
        public ReactiveCommand<Unit, Unit> VolumeValueChangedCommand { get; }

        /// <summary>
        /// Command to handle seeking value changes.
        /// </summary>
        public ReactiveCommand<Unit, Unit> SeekingValueChangedCommand { get; }

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

        /// <summary>
        /// Backing field for Position property.
        /// </summary>
        private string? _Position = "00:00:00";

        /// <summary>
        /// Gets or sets the current position string.
        /// </summary>
        public string? Position
        {
            get => _Position;
            set => this.RaiseAndSetIfChanged(ref _Position, value);
        }

#if __IOS__ && !__MACCATALYST__

        /// <summary>
        /// Backing field for Filename property.
        /// </summary>
        private Foundation.NSUrl? _Filename;
        
        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        public Foundation.NSUrl? Filename
        {
            get => _Filename;
            set => this.RaiseAndSetIfChanged(ref _Filename, value);
        }
        
#else
        
        /// <summary>
        /// Backing field for Filename property.
        /// </summary>
        private string? _Filename = "File name";

        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        public string? Filename
        {
            get => _Filename;
            set => this.RaiseAndSetIfChanged(ref _Filename, value);
        }
        
#endif

        /// <summary>
        /// Backing field for SampleText property.
        /// </summary>
        private string? _SampleText = "SAMPLE";

        /// <summary>
        /// Gets or sets the sample text.
        /// </summary>
        public string? SampleText
        {
            get => _SampleText;
            set => this.RaiseAndSetIfChanged(ref _SampleText, value);
        }

        /// <summary>
        /// Backing field for Duration property.
        /// </summary>
        private string? _Duration = "00:00:00";

        /// <summary>
        /// Gets or sets the duration string.
        /// </summary>
        public string? Duration
        {
            get => _Duration;
            set => this.RaiseAndSetIfChanged(ref _Duration, value);
        }

        /// <summary>
        /// Backing field for Volume property.
        /// </summary>
        private string? _Volume;

        /// <summary>
        /// Gets or sets the volume string.
        /// </summary>
        public string? Volume
        {
            get => _Volume;
            set => this.RaiseAndSetIfChanged(ref _Volume, value);
        }

        /// <summary>
        /// Backing field for VolumeValue property.
        /// </summary>
        private double? _VolumeValue = 0;

        /// <summary>
        /// Gets or sets the volume value.
        /// </summary>
        public double? VolumeValue
        {
            get => _VolumeValue;
            set => this.RaiseAndSetIfChanged(ref _VolumeValue, value);
        }

        /// <summary>
        /// Command to open a file.
        /// </summary>
        public ICommand OpenFileCommand { get; }

        /// <summary>
        /// Command to toggle play/pause.
        /// </summary>
        public ICommand PlayPauseCommand { get; }

        /// <summary>
        /// Backing field for PlayPauseText property.
        /// </summary>
        private string? _PlayPauseText = "PLAY";

        /// <summary>
        /// Gets or sets the play/pause button text.
        /// </summary>
        public string? PlayPauseText
        {
            get => _PlayPauseText;
            set => this.RaiseAndSetIfChanged(ref _PlayPauseText, value);
        }

        /// <summary>
        /// Backing field for SpeedText property.
        /// </summary>
        private string? _SpeedText = "SPEED: 1X";

        /// <summary>
        /// Gets or sets the speed button text.
        /// </summary>
        public string? SpeedText
        {
            get => _SpeedText;
            set => this.RaiseAndSetIfChanged(ref _SpeedText, value);
        }

        /// <summary>
        /// Command to stop playback.
        /// </summary>
        public ICommand StopCommand { get; }

        /// <summary>
        /// Command to change playback speed.
        /// </summary>
        public ICommand SpeedCommand { get; }

        /// <summary>
        /// Backing field for SeekingValue property.
        /// </summary>
        private double? _SeekingValue = 0;

        /// <summary>
        /// Gets or sets the seeking value.
        /// </summary>
        public double? SeekingValue
        {
            get => _SeekingValue;
            set => this.RaiseAndSetIfChanged(ref _SeekingValue, value);
        }

        /// <summary>
        /// Backing field for SeekingMaximum property.
        /// </summary>
        private double? _SeekingMaximum = null;

        /// <summary>
        /// Gets or sets the maximum seeking value.
        /// </summary>
        public double? SeekingMaximum
        {
            get => _SeekingMaximum;
            set => this.RaiseAndSetIfChanged(ref _SeekingMaximum, value);
        }

        /// <summary>
        /// Command to handle window closing.
        /// </summary>
        public ReactiveCommand<Unit, Unit> WindowClosingCommand { get; }

        /// <summary>
        /// The media player instance.
        /// </summary>
        private MediaPlayerCoreX _player;
        
        /// <summary>
        /// The seeking flag.
        /// </summary>
        private volatile bool _isTimerUpdate;

        /// <summary>
        /// The position timer.
        /// </summary>
        private System.Timers.Timer _tmPosition;

        /// <summary>
        /// Create engine async.
        /// </summary>
        private async Task CreateEngineAsync()
        {
            if (_player != null)
            {
                await _player.StopAsync();
                await _player.DisposeAsync();
            }

            if (string.IsNullOrWhiteSpace(_Filename))
            {
                Console.WriteLine("No file selected.");
                return;
            }

            _player = new MediaPlayerCoreX(VideoViewIntf);

            _player.OnError += _player_OnError;

            _player.Audio_Play = true;

            var sourceSettings = await UniversalSourceSettings.CreateAsync(_Filename);
            await _player.OpenAsync(sourceSettings);
        }

        /// <summary>
        /// On window closing.
        /// </summary>
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

        /// <summary>
        /// Open file async.
        /// </summary>
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
                
                // check file access
                var access = IOSHelper.CheckFileAccess(Filename);
                if (!access)
                {
                    // error toast
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
                // The user canceled or something went wrong
                Debug.WriteLine($"Error opening file: {ex.Message}");
            }
            
#endif
        }

        /// <summary>
        /// Play pause async.
        /// </summary>
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

        /// <summary>
        /// Stop async.
        /// </summary>
        private async Task StopAsync()
        {
            await StopAllAsync();

            SpeedText = "SPEED: 1X";
            PlayPauseText = "PLAY";
        }

        /// <summary>
        /// Speed async.
        /// </summary>
        private async Task SpeedAsync()
        {
            if (SpeedText == "SPEED: 1X")
            {
                // set 2x
                SpeedText = "SPEED: 2X";
                await _player.Rate_SetAsync(2.0);
            }
            else if (SpeedText == "SPEED: 2X")
            {
                // set 0.5x
                SpeedText = "SPEED: 0.5X";
                await _player.Rate_SetAsync(0.5);
            }
            else if (SpeedText == "SPEED: 0.5X")
            {
                // set 1x
                SpeedText = "SPEED: 1X";
                await _player.Rate_SetAsync(1.0);
            }
        }

        /// <summary>
        /// Player on error.
        /// </summary>
        private void _player_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        /// <summary>
        /// Stop all async.
        /// </summary>
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

            SeekingMaximum = null;
        }

        /// <summary>
        /// Handles the Elapsed event of the tmPosition control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private async void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_player == null)
            {
                return;
            }

            var pos = await _player.Position_GetAsync();
            var progress = (int)pos.TotalMilliseconds;

            try
            {
                await Dispatcher.UIThread.InvokeAsync(async () =>
                {
                    if (_player == null)
                    {
                        return;
                    }

                    _isTimerUpdate = true;

                    // Set the maximum value of the seeking slider
                    if (SeekingMaximum == null)
                    {
                        SeekingMaximum = (int)(await _player.DurationAsync()).TotalMilliseconds;
                    }

                    if (progress > SeekingMaximum)
                    {
                        SeekingValue = SeekingMaximum;
                    }
                    else
                    {
                        SeekingValue = progress;
                    }

                    // This is where the received data is passed
                    Position = $"{pos.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";
                    Duration = $"{(await _player.DurationAsync()).ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";

                    _isTimerUpdate = false;
                });
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        /// <summary>
        /// On seeking value changed.
        /// </summary>
        private async Task OnSeekingValueChanged()
        {
            if (!_isTimerUpdate && _player != null && SeekingValue.HasValue)
            {
                await _player.Position_SetAsync(TimeSpan.FromMilliseconds(SeekingValue.Value));
            }
        }

        /// <summary>
        /// On volume value changed.
        /// </summary>
        private void OnVolumeValueChanged()
        {
            if (_player != null && VolumeValue.HasValue)
            {
                _player.Audio_OutputDevice_Volume = VolumeValue.Value / 100.0;
            }
        }
    }
}
