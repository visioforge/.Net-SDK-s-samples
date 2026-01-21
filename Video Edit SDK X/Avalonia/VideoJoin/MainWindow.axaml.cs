using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

using VisioForge.Core;
using VisioForge.Core.Helpers;
using VisioForge.Core.MediaInfoReaderX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.VideoEditX;

namespace VideoJoin;
/// <summary>
/// The main window for the Avalonia VideoJoin demo.
/// Demonstrates joining multiple files into a single output using the VideoEditCoreX engine in an Avalonia environment.
/// </summary>
public partial class MainWindow : Window
{
    private bool _initialized;

    private VideoEditCoreX VideoEdit1;

    public ObservableCollection<string> InputFiles { get; set; } = new ObservableCollection<string>();

    public ObservableCollection<string> FrameRates { get; set; } = new ObservableCollection<string>();

    public ObservableCollection<string> OutputFormats { get; set; } = new ObservableCollection<string>();

    public ObservableCollection<string> Log { get; set; } = new ObservableCollection<string>();

    public MainWindow()
    {
#if DEBUG
        this.AttachDevTools();
#endif

        Activated += MainWindow_Activated;
        Closing += MainWindow_Closing;

        DataContext = this;

        InitializeComponent();
    }

    /// <summary>
    /// Handles the Closing event of the MainWindow.
    /// Stops the engine and releases SDK resources.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
    private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        VideoEdit1.Stop();

        DestroyEngine();

        VisioForgeX.DestroySDK();
    }

    /// <summary>
    /// Handles the Activated event of the MainWindow.
    /// Initializes controls and the engine upon first activation.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void MainWindow_Activated(object sender, EventArgs e)
    {
        if (_initialized)
        {
            return;
        }

        _initialized = true;

        InitControls();

        CreateEngine();

        Title += $" (SDK v{VideoEditCoreX.SDK_Version})";

        edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");

        VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
    }

    /// <summary>
    /// Initializes and configures the UI controls and their initial values.
    /// </summary>
    private void InitControls()
    {
        //VideoView1 = this.FindControl<VideoView>("VideoView1");

        btSelectFile = this.FindControl<Button>("btSelectFile");
        btSelectFile.Click += btSelectFile_Click;

        edOutput = this.FindControl<TextBox>("edOutput");

        btStart = this.FindControl<Button>("btStart");
        btStart.Click += btStart_Click;

        btStop = this.FindControl<Button>("btStop");
        btStop.Click += btStop_Click;

        btAddFile = this.FindControl<Button>("btAddFile");
        btAddFile.Click += btAddFile_Click;

        btClearFiles = this.FindControl<Button>("btClearFiles");
        btClearFiles.Click += btClearFiles_Click;

        cbDebugMode = this.FindControl<CheckBox>("cbDebugMode");
        cbTelemetry = this.FindControl<CheckBox>("cbTelemetry");
        cbLicensing = this.FindControl<CheckBox>("cbLicensing");

        cbResize = this.FindControl<CheckBox>("cbResize");

        cbFrameRate = this.FindControl<ComboBox>("cbFrameRate");
        cbFrameRate.ItemsSource = FrameRates;
        FrameRates.Add("0");
        FrameRates.Add("5");
        FrameRates.Add("10");
        FrameRates.Add("15");
        FrameRates.Add("25");
        FrameRates.Add("30");

        cbOutputFormat = this.FindControl<ComboBox>("cbOutputFormat");
        cbOutputFormat.ItemsSource = OutputFormats;
        OutputFormats.Add("MP4");
        OutputFormats.Add("WebM");
        OutputFormats.Add("AVI");
        OutputFormats.Add("MKV(Matroska)");
        OutputFormats.Add("WMV(Windows Media Video)");
        OutputFormats.Add("PCM");
        OutputFormats.Add("MP3");
        OutputFormats.Add("M4A(AAC)");
        OutputFormats.Add("WMA(Windows Media Audio)");
        OutputFormats.Add("Ogg Vorbis");
        OutputFormats.Add("FLAC");
        OutputFormats.Add("Speex");

        lbInputFiles = this.FindControl<ListBox>("lbInputFiles");
        lbInputFiles.ItemsSource = InputFiles;

        pbProgress = this.FindControl<ProgressBar>("pbProgress");

        cbFrameRate.SelectedIndex = 0;
        cbOutputFormat.SelectedIndex = 0;

        mmLog = this.FindControl<ListBox>("mmLog");
        mmLog.ItemsSource = Log;
    }

    /// <summary>
    /// Handles the Click event of the btAddFile control.
    /// Opens a file dialog and adds the selected file to the engine's input list.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private async void btAddFile_Click(object sender, RoutedEventArgs e)
    {
        var ofd = new OpenFileDialog();
        string[] files = await ofd.ShowAsync(this);
        if (files?.Length > 0)
        {
            string filename = files[0];

            // if resolution and output format not set we should set it the same as in added file
            if (cbResize.IsChecked == true)
            {
                VideoEdit1.Output_VideoSize = new VisioForge.Core.Types.Size(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text));
            }

            var frameRate = Convert.ToInt32((string)cbFrameRate.SelectedItem, CultureInfo.InvariantCulture);
            if (frameRate != 0)
            {
                VideoEdit1.Output_VideoFrameRate = new VideoFrameRate(frameRate);
            }

            InputFiles.Add(filename);

            if (FilenameHelper.IsImageFile(filename))
            {
                VideoEdit1.Input_AddImageFile(filename, TimeSpan.FromMilliseconds(2000));
            }
            else if (FilenameHelper.IsAudioFile(filename))
            {
                VideoEdit1.Input_AddAudioFile(filename);
            }
            else
            {
                VideoEdit1.Input_AddAudioVideoFile(filename);
            }
        }
    }

    /// <summary>
    /// Creates the VideoEditCoreX engine and subscribes to its events.
    /// </summary>
    private void CreateEngine()
    {
        VideoEdit1 = new VideoEditCoreX();

        VideoEdit1.OnError += VideoEdit1_OnError;
        VideoEdit1.OnStop += VideoEdit1_OnStop;
        VideoEdit1.OnProgress += VideoEdit1_OnProgress;
    }

    /// <summary>
    /// Destroys the VideoEditCoreX engine and unsubscribes from events.
    /// </summary>
    private void DestroyEngine()
    {
        if (VideoEdit1 != null)
        {
            VideoEdit1.OnError -= VideoEdit1_OnError;
            VideoEdit1.OnStop -= VideoEdit1_OnStop;
            VideoEdit1.OnProgress -= VideoEdit1_OnProgress;

            VideoEdit1.Dispose();
            VideoEdit1 = null;
        }
    }

    /// <summary>
    /// Gets the file extension from the specified filename.
    /// </summary>
    /// <param name="filename">The filename.</param>
    /// <returns>The file extension including the dot.</returns>
    private static string GetFileExt(string filename)
    {
        int k = filename.LastIndexOf('.');
        return filename.Substring(k, filename.Length - k);
    }

    /// <summary>
    /// Handles the Click event of the btSelectFile control.
    /// Opens a dialog to select the output file path.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private async void btSelectFile_Click(object sender, RoutedEventArgs e)
    {
        var ofd = new SaveFileDialog();
        string file = await ofd.ShowAsync(this);
        if (string.IsNullOrEmpty(file))
        {
            edOutput.Text = file;
        }
    }

    /// <summary>
    /// Handles the Click event of the btStop control.
    /// Stops the joining process and clears the project state.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btStop_Click(object sender, RoutedEventArgs e)
    {
        VideoEdit1.Stop();

        InputFiles.Clear();
        VideoEdit1.Input_Clear_List();
        pbProgress.Value = 0;
    }

    /// <summary>
    /// Handles the Click event of the btClearFiles control.
    /// Clears the input files list.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btClearFiles_Click(object sender, RoutedEventArgs e)
    {
        InputFiles.Clear();
        VideoEdit1.Input_Clear_List();
    }

    /// <summary>
    /// Handles the Click event of the btStart control.
    /// Configures the engine and starts the join operation.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btStart_Click(object sender, RoutedEventArgs e)
    {
        VideoEdit1.Debug_Mode = cbDebugMode.IsChecked == true;
        VideoEdit1.Debug_Telemetry = cbTelemetry.IsChecked == true;

        Log.Clear();

        switch (cbOutputFormat.SelectedIndex)
        {
            case 0:
                {
                    var mp4Output = new MP4Output(edOutput.Text);
                    VideoEdit1.Output_Format = mp4Output;
                    break;
                }
            case 1:
                {
                    var webmOutput = new WebMOutput(edOutput.Text);
                    VideoEdit1.Output_Format = webmOutput;
                    break;
                }
            case 2:
                {
                    var aviOutput = new AVIOutput(edOutput.Text);
                    VideoEdit1.Output_Format = aviOutput;
                    break;
                }
            case 3:
                {
                    var mkvOutput = new MKVOutput(edOutput.Text);
                    VideoEdit1.Output_Format = mkvOutput;
                    break;
                }
            case 4:
                {
                    var wmvOutput = new WMVOutput(edOutput.Text);
                    VideoEdit1.Output_Format = wmvOutput;
                    break;
                }
            case 5:
                {
                    var dvOutput = new DVOutput(edOutput.Text);
                    VideoEdit1.Output_Format = dvOutput;
                    break;
                }
            case 6:
                {
                    var acmOutput = new WAVOutput(edOutput.Text);
                    VideoEdit1.Output_Format = acmOutput;
                    break;
                }
            case 7:
                {
                    var mp3Output = new MP3Output(edOutput.Text);
                    VideoEdit1.Output_Format = mp3Output;
                    break;
                }
            case 8:
                {
                    var m4aOutput = new M4AOutput(edOutput.Text);
                    VideoEdit1.Output_Format = m4aOutput;
                    break;
                }
            case 9:
                {
                    var wmaOutput = new WMAOutput(edOutput.Text);
                    VideoEdit1.Output_Format = wmaOutput;
                    break;
                }
            case 10:
                {
                    var oggVorbisOutput = new OGGVorbisOutput(edOutput.Text);
                    VideoEdit1.Output_Format = oggVorbisOutput;
                    break;
                }
            case 11:
                {
                    var flacOutput = new FLACOutput(edOutput.Text);
                    VideoEdit1.Output_Format = flacOutput;
                    break;
                }
            case 12:
                {
                    var speexOutput = new SpeexOutput(edOutput.Text);
                    VideoEdit1.Output_Format = speexOutput;
                    break;
                }
        }

        VideoEdit1.Start();
    }

        /// <summary>
        /// Video edit 1 on error.
        /// </summary>
    private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
    {
        Log.Add(e.Message);
    }

        /// <summary>
        /// Video edit 1 on progress.
        /// </summary>
    private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            pbProgress.Value = e.Progress;
        });
    }

        /// <summary>
        /// Video edit 1 on stop.
        /// </summary>
    private void VideoEdit1_OnStop(object sender, StopEventArgs e)
    {
        Dispatcher.UIThread.InvokeAsync(async () =>
        {
            pbProgress.Value = 0;
            InputFiles.Clear();

            if (e.Successful)
            {
                await ShowMessageAsync("Completed successfully");
            }
            else
            {
                await ShowMessageAsync("Stopped with error");
            }
        });
    }

    /// <summary>
    /// Displays a message box with the specified text.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private async Task ShowMessageAsync(string message)
    {
        var messageBoxStandardWindow = MsBox.Avalonia.MessageBoxManager.GetMessageBoxStandard("Message", message);

        await messageBoxStandardWindow.ShowAsync();
    }
}
