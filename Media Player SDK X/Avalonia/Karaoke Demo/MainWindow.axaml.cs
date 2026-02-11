using Avalonia;
using Avalonia.Controls;
using Avalonia.Diagnostics;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using VisioForge.Core;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Libs.GStreamer;
using Avalonia.Platform.Storage;

namespace KaraokeDemoAMB;

/// <summary>
/// Main window for the Karaoke Demo application.
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// Timer for updating the UI position.
    /// </summary>
    private System.Timers.Timer _tmPosition;

    /// <summary>
    /// Flag to indicate if the window is initialized.
    /// </summary>
    private bool _initialized;

    /// <summary>
    /// The media player instance.
    /// </summary>
    private MediaPlayerCoreX _player;

    /// <summary>
    /// The current CDG source settings.
    /// </summary>
    private CDGSourceSettings _currentSettings;

    /// <summary>
    /// Flag to prevent recursive timeline updates.
    /// </summary>
    private volatile bool _tbTimelineApplyingValue;

#if WINDOWS
    /// <summary>
    /// The audio output device API.
    /// </summary>
    private AudioOutputDeviceAPI? _audioOutputDeviceAPI = AudioOutputDeviceAPI.DirectSound;
#else
    /// <summary>
    /// The audio output device API.
    /// </summary>
    private AudioOutputDeviceAPI? _audioOutputDeviceAPI = null;
#endif

    /// <summary>
    /// Gets or sets the available audio output devices.
    /// </summary>
    public ObservableCollection<string> AudioOutputDevices { get; set; } = new ObservableCollection<string>();

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();

#if DEBUG
        this.AttachDevTools();
#endif

        Activated += MainWindow_Activated;
        Closing += MainWindow_Closing;

        DataContext = this;
    }

    /// <summary>
    /// Load CDG plugin manually from application directory (Linux only).
    /// </summary>
    private void LoadCDGPlugin()
    {
#if !WINDOWS && !OSX
        try
        {
            // Check if cdgparse element is already available (from system GStreamer plugins)
            if (VisioForge.Core.GStreamer.Helpers.ElementHelper.IsAvailable("cdgparse"))
            {
                Console.WriteLine("CDG plugin already available from system GStreamer plugins");
                return;
            }

            var appDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            // Detect architecture
            var arch = RuntimeInformation.ProcessArchitecture switch
            {
                Architecture.X64 => "linux-x64",
                Architecture.Arm64 => "linux-arm64",
                _ => null
            };

            if (arch == null)
            {
                Console.WriteLine($"Unsupported architecture: {RuntimeInformation.ProcessArchitecture}");
                return;
            }

            var cdgPluginPath = Path.Combine(appDir, "runtimes", arch, "native", "libgstcdg.so");

            if (File.Exists(cdgPluginPath))
            {
                var plugin = Gst.Plugin.LoadFile(cdgPluginPath);
                if (plugin != null)
                {
                    Console.WriteLine($"CDG plugin loaded successfully from: {cdgPluginPath}");
                }
                else
                {
                    Console.WriteLine($"Failed to load CDG plugin from: {cdgPluginPath}");
                }
            }
            else
            {
                Console.WriteLine($"CDG plugin not found at: {cdgPluginPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading CDG plugin: {ex.Message}");
        }
#endif
    }

    /// <summary>
    /// Initialize controls and wire up events.
    /// </summary>
    private void InitControls()
    {
        rbZipMode.IsCheckedChanged += rbInputMode_CheckedChanged;
        rbSeparateFilesMode.IsCheckedChanged += rbInputMode_CheckedChanged;

        btSelectFile.Click += btSelectFile_Click;
        btSelectAudioFile.Click += btSelectAudioFile_Click;

        tbTimeline.GetObservable(Slider.ValueProperty)
            .Subscribe(value => tbTimeline_Scroll());

        btStart.Click += btStart_Click;
        btResume.Click += btResume_Click;
        btPause.Click += btPause_Click;
        btStop.Click += btStop_Click;

        cbAudioOutputDevice.ItemsSource = AudioOutputDevices;

        tbVolume.GetObservable(Slider.ValueProperty)
            .Subscribe(value => tbVolume_Scroll());

        tbPitch.GetObservable(Slider.ValueProperty)
            .Subscribe(value => tbPitch_Scroll());

        _tmPosition = new System.Timers.Timer(1000);
        _tmPosition.Elapsed += tmPosition_Elapsed;
    }

    /// <summary>
    /// Handles the main window activated event.
    /// </summary>
    private async void MainWindow_Activated(object sender, EventArgs e)
    {
        try
        {
            if (_initialized)
            {
                return;
            }

            _initialized = true;

            InitControls();

            _player = new MediaPlayerCoreX(VideoView1);
            _player.OnError += Player_OnError;
            _player.OnStop += Player_OnStop;

            // Load CDG plugin manually after GStreamer is initialized
            LoadCDGPlugin();

            Title += $" (SDK v{MediaPlayerCoreX.SDK_Version})";
            _player.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            // Populate audio output devices
            var audioOutputs = await _player.Audio_OutputDevicesAsync(_audioOutputDeviceAPI);
            foreach (var item in audioOutputs)
            {
                AudioOutputDevices.Add(item.DisplayName);
            }

            if (AudioOutputDevices.Count > 0)
            {
                cbAudioOutputDevice.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"MainWindow_Activated error: {ex.Message}");
        }
    }

    /// <summary>
    /// Handles input mode radio button changes.
    /// </summary>
    private void rbInputMode_CheckedChanged(object sender, RoutedEventArgs e)
    {
        if (rbZipMode == null || rbSeparateFilesMode == null)
        {
            return;
        }

        if (rbZipMode.IsChecked == true)
        {
            // ZIP mode - disable audio file input
            lbFileLabel.Text = "ZIP File:";
            edAudioFilename.IsEnabled = false;
            btSelectAudioFile.IsEnabled = false;
            lbAudioLabel.Opacity = 0.5;
            edFilename.Text = string.Empty;
        }
        else
        {
            // Separate files mode - enable audio file input
            lbFileLabel.Text = "CDG File:";
            edAudioFilename.IsEnabled = true;
            btSelectAudioFile.IsEnabled = true;
            lbAudioLabel.Opacity = 1.0;
            edFilename.Text = string.Empty;
            edAudioFilename.Text = string.Empty;
        }
    }

    /// <summary>
    /// Handles the select file button click.
    /// </summary>
    private async void btSelectFile_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var fileTypes = new List<FilePickerFileType>();

            if (rbZipMode.IsChecked == true)
            {
                fileTypes.Add(new FilePickerFileType("ZIP archives") { Patterns = new[] { "*.zip" } });
            }
            else
            {
                fileTypes.Add(new FilePickerFileType("CDG files") { Patterns = new[] { "*.cdg" } });
            }
            fileTypes.Add(new FilePickerFileType("All files") { Patterns = new[] { "*" } });

            var files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Select file",
                AllowMultiple = false,
                FileTypeFilter = fileTypes
            });

            if (files != null && files.Count > 0)
            {
                edFilename.Text = files[0].Path.LocalPath;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Select file error: {ex.Message}");
        }
    }

    /// <summary>
    /// Handles the select audio file button click.
    /// </summary>
    private async void btSelectAudioFile_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var fileTypes = new List<FilePickerFileType>
            {
                new FilePickerFileType("Audio files") { Patterns = new[] { "*.mp3", "*.wav", "*.ogg", "*.flac", "*.m4a", "*.aac" } },
                new FilePickerFileType("All files") { Patterns = new[] { "*" } }
            };

            var files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Select audio file",
                AllowMultiple = false,
                FileTypeFilter = fileTypes
            });

            if (files != null && files.Count > 0)
            {
                edAudioFilename.Text = files[0].Path.LocalPath;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Select audio file error: {ex.Message}");
        }
    }

    /// <summary>
    /// Handles the start button click.
    /// </summary>
    private async void btStart_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            mmError.Text = string.Empty;

            _player.Audio_Play = true;

            var audioOutputs = await _player.Audio_OutputDevicesAsync(_audioOutputDeviceAPI);
            var audioOutputDevice = audioOutputs.FirstOrDefault(device => device.DisplayName == cbAudioOutputDevice.SelectedItem?.ToString());
            if (audioOutputDevice != null)
            {
                _player.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);
            }

            _player.Debug_Mode = cbDebugMode.IsChecked == true;

            // Create CDG source settings based on input mode
            if (rbZipMode.IsChecked == true)
            {
                // ZIP archive containing CDG and audio files
                var zipFile = edFilename.Text;
                _currentSettings = new CDGSourceSettings(zipFile);
            }
            else
            {
                // Separate CDG and audio files
                var cdgFile = edFilename.Text;
                var audioFile = edAudioFilename.Text;
                _currentSettings = new CDGSourceSettings(cdgFile, audioFile);
            }

            // Set pitch from slider (semitones) and enable runtime pitch control
            _currentSettings.EnablePitchShifting = true;
            _currentSettings.PitchSemitones = (int)tbPitch.Value;

            await _player.OpenAsync(_currentSettings);
            await _player.PlayAsync();

            _player.Audio_OutputDevice_Volume = tbVolume.Value / 100.0;

            _tmPosition.Start();
        }
        catch (Exception ex)
        {
            mmError.Text += $"Start error: {ex.Message}{Environment.NewLine}";
        }
    }

    /// <summary>
    /// Handles the resume button click.
    /// </summary>
    private async void btResume_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (_player != null)
            {
                await _player.ResumeAsync();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Resume error: {ex.Message}");
        }
    }

    /// <summary>
    /// Handles the pause button click.
    /// </summary>
    private async void btPause_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (_player != null)
            {
                await _player.PauseAsync();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Pause error: {ex.Message}");
        }
    }

    /// <summary>
    /// Handles the stop button click.
    /// </summary>
    private async void btStop_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            _tmPosition.Stop();

            if (_player != null)
            {
                await _player.StopAsync();
            }

            _currentSettings = null;

            tbTimeline.Value = 0;
            lbTime.Text = "00:00:00 | 00:00:00";
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Stop error: {ex.Message}");
        }
    }

    /// <summary>
    /// Handles the timeline slider scroll.
    /// </summary>
    private async void tbTimeline_Scroll()
    {
        try
        {
            if (_tbTimelineApplyingValue && _player != null)
            {
                await _player.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Seek error: {ex.Message}");
        }
    }

    /// <summary>
    /// Handles the volume slider scroll.
    /// </summary>
    private void tbVolume_Scroll()
    {
        if (_player == null)
        {
            return;
        }

        _player.Audio_OutputDevice_Volume = tbVolume.Value / 100.0;
    }

    /// <summary>
    /// Handles the pitch slider scroll.
    /// </summary>
    private void tbPitch_Scroll()
    {
        if (lbPitch == null)
        {
            return;
        }

        var semitones = (int)tbPitch.Value;
        lbPitch.Text = $"Pitch: {semitones:+#;-#;0}";

        // Change pitch during playback
        if (_currentSettings != null)
        {
            _currentSettings.PitchSemitones = semitones;
        }
    }

    /// <summary>
    /// Timer elapsed - update position.
    /// </summary>
    private void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            if (_player == null)
            {
                return;
            }

            var position = _player.Position_Get();
            var duration = _player.Duration();

            tbTimeline.Maximum = (int)duration.TotalSeconds;

            lbTime.Text = position.ToString("hh\\:mm\\:ss", CultureInfo.InvariantCulture) + " | " +
                          duration.ToString("hh\\:mm\\:ss", CultureInfo.InvariantCulture);

            if (tbTimeline.Maximum >= position.TotalSeconds)
            {
                _tbTimelineApplyingValue = false;
                tbTimeline.Value = position.TotalSeconds;
                _tbTimelineApplyingValue = true;
            }
        });
    }

    /// <summary>
    /// Player on error event.
    /// </summary>
    private void Player_OnError(object sender, ErrorsEventArgs e)
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            mmError.Text = mmError.Text + e.Message + Environment.NewLine;
        });
    }

    /// <summary>
    /// Player on stop event.
    /// </summary>
    private void Player_OnStop(object sender, StopEventArgs e)
    {
        _tmPosition.Stop();

        Dispatcher.UIThread.InvokeAsync(() =>
        {
            tbTimeline.Value = 0;
            lbTime.Text = "00:00:00 | 00:00:00";
        });
    }

    /// <summary>
    /// Destroy engine async.
    /// </summary>
    private async Task DestroyEngineAsync()
    {
        if (_player != null)
        {
            _player.OnError -= Player_OnError;
            _player.OnStop -= Player_OnStop;
            await Task.Delay(500);
            await _player.DisposeAsync();
            _player = null;
        }
    }

    /// <summary>
    /// Main window closing.
    /// </summary>
    private async void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        try
        {
            if (_player == null)
            {
                return;
            }

            _tmPosition?.Stop();
            _tmPosition?.Dispose();

            await _player.StopAsync();
            await DestroyEngineAsync();

            VisioForgeX.DestroySDK();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Window closing error: {ex.Message}");
        }
    }
}
