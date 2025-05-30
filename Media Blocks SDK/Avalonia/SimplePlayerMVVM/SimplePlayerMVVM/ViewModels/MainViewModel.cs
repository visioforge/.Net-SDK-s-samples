﻿
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
using SimplePlayerMVVMMB;
using Splat;


#if __ANDROID__
using Android.Content;
using Android.Database;
using Android.Provider;
#endif

namespace Simple_Player_MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
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

        public ReactiveCommand<Unit, Unit> VolumeValueChangedCommand { get; }

        public ReactiveCommand<Unit, Unit> SeekingValueChangedCommand { get; }

        public IVideoView VideoViewIntf { get; set; }

#if __ANDROID__
        public static IAndroidHelper AndroidHelper { get; set; }
#endif 

        public TopLevel TopLevel { get; set; }

        private string? _Position = "00:00:00";

        public string? Position
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
        
        private string? _Filename = "File name";

        public string? Filename
        {
            get => _Filename;
            set => this.RaiseAndSetIfChanged(ref _Filename, value);
        }
        
        #endif

        private string? _SampleText = "SAMPLE";

        public string? SampleText
        {
            get => _SampleText;
            set => this.RaiseAndSetIfChanged(ref _SampleText, value);
        }

        private string? _Duration = "00:00:00";

        public string? Duration
        {
            get => _Duration;
            set => this.RaiseAndSetIfChanged(ref _Duration, value);
        }

        private string? _Volume;

        public string? Volume
        {
            get => _Volume;
            set => this.RaiseAndSetIfChanged(ref _Volume, value);
        }

        private double? _VolumeValue = 0;

        public double? VolumeValue
        {
            get => _VolumeValue;
            set => this.RaiseAndSetIfChanged(ref _VolumeValue, value);
        }

        public ICommand OpenFileCommand { get; }

        public ICommand PlayPauseCommand { get; }

        private string? _PlayPauseText = "PLAY";

        public string? PlayPauseText
        {
            get => _PlayPauseText;
            set => this.RaiseAndSetIfChanged(ref _PlayPauseText, value);
        }

        private string? _SpeedText = "SPEED: 1X";

        public string? SpeedText
        {
            get => _SpeedText;
            set => this.RaiseAndSetIfChanged(ref _SpeedText, value);
        }

        public ICommand StopCommand { get; }

        public ICommand SpeedCommand { get; }

        public double? _SeekingValue = 0;

        public double? SeekingValue
        {
            get => _SeekingValue;
            set => this.RaiseAndSetIfChanged(ref _SeekingValue, value);
        }

        public double? _SeekingMaximum = null;

        public double? SeekingMaximum
        {
            get => _SeekingMaximum;
            set => this.RaiseAndSetIfChanged(ref _SeekingMaximum, value);
        }

        public ReactiveCommand<Unit, Unit> WindowClosingCommand { get; }

        private MediaBlocksPipeline _pipeline;

        private UniversalSourceBlock _source;

        private MediaBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        /// <summary>
        /// The seeking flag.
        /// </summary>
        private volatile bool _isTimerUpdate;

        /// <summary>
        /// The position timer.
        /// </summary>
        private System.Timers.Timer _tmPosition = new System.Timers.Timer(500);

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
                Dispatcher.UIThread.InvokeAsync(async () =>
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
            var pipeline = _pipeline.Debug_GetPipeline();

            await StopAllAsync();

            SpeedText = "SPEED: 1X";
            PlayPauseText = "PLAY";
        }

        private async Task SpeedAsync()
        {
            if (SpeedText == "SPEED: 1X")
            {
                // set 2x
                SpeedText = "SPEED: 2X";
                await _pipeline.Rate_SetAsync(2.0);
            }
            else if (SpeedText == "SPEED: 2X")
            {
                // set 0.5x
                SpeedText = "SPEED: 0.5X";
                await _pipeline.Rate_SetAsync(0.5);
            }
            else if (SpeedText == "SPEED: 0.5X")
            {
                // set 1x
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

            SeekingMaximum = null;
        }

        /// <summary>
        /// Handles the Elapsed event of the tmPosition control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private async void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_pipeline == null)
            {
                return;
            }

            var pos = await _pipeline.Position_GetAsync();
            var progress = (int)pos.TotalMilliseconds;

            try
            {
                await Dispatcher.UIThread.InvokeAsync(async () =>
                {
                    if (_pipeline == null)
                    {
                        return;
                    }

                    if (SeekingMaximum == null)
                    {
                        SeekingMaximum = (await _pipeline.DurationAsync()).TotalMilliseconds;
                    }

                    _isTimerUpdate = true;

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
                    Duration = $"{(await _pipeline.DurationAsync()).ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";

                    _isTimerUpdate = false;
                });
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        private async Task OnSeekingValueChanged()
        {
            if (!_isTimerUpdate && _pipeline != null && SeekingValue.HasValue)
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromMilliseconds(SeekingValue.Value));
            }
        }

        private void OnVolumeValueChanged()
        {
            if (_pipeline != null && VolumeValue.HasValue)
            {
                _audioRenderer.Volume = VolumeValue.Value / 100.0;
            }
        }
    }
}
