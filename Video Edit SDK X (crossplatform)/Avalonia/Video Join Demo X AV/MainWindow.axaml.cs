using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using VisioForge.Core.Helpers;
using VisioForge.Core.MediaInfoGST;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.VideoEditX;

namespace Video_Join_Demo_X_AV
{
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

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VideoEdit1.Stop();

            DestroyEngine();
        }

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

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");

            VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

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
            FrameRates.Add("0");
            FrameRates.Add("5");
            FrameRates.Add("10");
            FrameRates.Add("15");
            FrameRates.Add("25");
            FrameRates.Add("30");

            cbOutputFormat = this.FindControl<ComboBox>("cbOutputFormat");
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

            pbProgress = this.FindControl<ProgressBar>("pbProgress");

            cbFrameRate.SelectedIndex = 0;
            cbOutputFormat.SelectedIndex = 0;
        }

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

        private void CreateEngine()
        {
            VideoEdit1 = new VideoEditCoreX();

            VideoEdit1.OnError += VideoEdit1_OnError;
            VideoEdit1.OnStop += VideoEdit1_OnStop;
            VideoEdit1.OnProgress += VideoEdit1_OnProgress;
        }

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

        private static string GetFileExt(string filename)
        {
            int k = filename.LastIndexOf('.');
            return filename.Substring(k, filename.Length - k);
        }

        private async void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new SaveFileDialog();
            string file = await ofd.ShowAsync(this);
            if (string.IsNullOrEmpty(file))
            {
                edOutput.Text = file;
            }
        }

        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Stop();

            InputFiles.Clear();
            VideoEdit1.Input_Clear_List();
            pbProgress.Value = 0;
        }

        private void btClearFiles_Click(object sender, RoutedEventArgs e)
        {
            InputFiles.Clear();
            VideoEdit1.Input_Clear_List();
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoEdit1.Debug_Telemetry = cbTelemetry.IsChecked == true;

            Log.Clear();

            VideoEdit1.Output_Filename = edOutput.Text;

            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    {
                        var mp4Output = new MP4Output();
                        VideoEdit1.Output_Format = mp4Output;
                        break;
                    }
                case 1:
                    {
                        var webmOutput = new WebMOutput();
                        VideoEdit1.Output_Format = webmOutput;
                        break;
                    }
                case 2:
                    {
                        var aviOutput = new AVIOutput();
                        VideoEdit1.Output_Format = aviOutput;
                        break;
                    }
                case 3:
                    {
                        var mkvOutput = new MKVOutput();
                        VideoEdit1.Output_Format = mkvOutput;
                        break;
                    }
                case 4:
                    {
                        var wmvOutput = new WMV1Output();
                        VideoEdit1.Output_Format = wmvOutput;
                        break;
                    }
                case 5:
                    {
                        var dvOutput = new DVOutput();
                        VideoEdit1.Output_Format = dvOutput;
                        break;
                    }
                case 6:
                    {
                        var acmOutput = new WAVOutput();
                        VideoEdit1.Output_Format = acmOutput;
                        break;
                    }
                case 7:
                    {
                        var mp3Output = new MP3Output();
                        VideoEdit1.Output_Format = mp3Output;
                        break;
                    }
                case 8:
                    {
                        var m4aOutput = new M4AOutput();
                        VideoEdit1.Output_Format = m4aOutput;
                        break;
                    }
                case 9:
                    {
                        var wmaOutput = new WMA1Output();
                        VideoEdit1.Output_Format = wmaOutput;
                        break;
                    }
                case 10:
                    {
                        var oggVorbisOutput = new OGGVorbisOutput();
                        VideoEdit1.Output_Format = oggVorbisOutput;
                        break;
                    }
                case 11:
                    {
                        var flacOutput = new FLACOutput();
                        VideoEdit1.Output_Format = flacOutput;
                        break;
                    }
                case 12:
                    {
                        var speexOutput = new SpeexOutput();
                        VideoEdit1.Output_Format = speexOutput;
                        break;
                    }
            }

            VideoEdit1.Start();
        }

        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Log.Add(e.Message);
        }

        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                pbProgress.Value = e.Progress;
            });
        }

        private void VideoEdit1_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                pbProgress.Value = 0;
                InputFiles.Clear();

                if (e.Successful)
                {
                    ShowMessage("Completed successfully");
                }
                else
                {
                    ShowMessage("Stopped with error");
                }
            });
        }

        private void ShowMessage(string message)
        {
            var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Message", message);

            messageBoxStandardWindow.Show(this);
        }
    }
}
