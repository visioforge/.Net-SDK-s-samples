using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoEdit;
using VisioForge.Core.UI.WPF;
using VisioForge.Core.VideoEdit;

namespace Multiple_Audio_Tracks_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoEditCore VideoEdit1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btOpenVideoFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Video Files(*.AVI;*.MP4;*.MKV;*.WMV)|*.AVI;*.MP4;*.MKV;*.WMV|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == true)
            {
                this.edVideoFile.Text = openFileDialog.FileName;
            }
        }

        private void btOpenAudioFile1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "WAV Files (*.wav)|*.wav|MP3 Files (*.mp3)|*.mp3|All Files (*.*)|*.*";
            dlg.CheckFileExists = true;
            dlg.Multiselect = false;
            dlg.Title = "Open Audio File 1";

            if (dlg.ShowDialog() == true)
            {
                edAudioFile1.Text = dlg.FileName;
            }
        }

        private void btOpenAudioFile2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "WAV Files (*.wav)|*.wav|MP3 Files (*.mp3)|*.mp3|All Files (*.*)|*.*";
            dlg.CheckFileExists = true;
            dlg.Multiselect = false;
            dlg.Title = "Open Audio File 2";

            if (dlg.ShowDialog() == true)
            {
                edAudioFile2.Text = dlg.FileName;
            }
        }

        private void btSelectOutputFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = ".mp4";
            dlg.Filter = "MP4 files (*.mp4)|*.mp4|All files (*.*)|*.*";
            if (dlg.ShowDialog() ?? false)
            {
                edOutputFile.Text = dlg.FileName;
            }
        }

        private void CreateEngine()
        {
            VideoEdit1 = new VideoEditCore(videoView);

            VideoEdit1.OnError += VideoEdit1_OnError;
            VideoEdit1.OnStop += VideoEdit1_OnStop;
            VideoEdit1.OnProgress += VideoEdit1_OnProgress;
        }

        private void VideoEdit1_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher?.Invoke(() => {
                pbProgress.Value = 0;
                if (e.Successful)
                {
                    MessageBox.Show(this, "Completed successfully");
                }
                else
                {
                    MessageBox.Show(this, "Stopped with error");
                }

                VideoEdit1.Input_Clear_List();
            });            
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

        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            Dispatcher?.Invoke(() => { pbProgress.Value = e.Progress; });
        }

        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher?.Invoke(() => { 
                edLog.Text = edLog.Text + e.Message + Environment.NewLine;
            });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();
            Title += $" (SDK v{VideoEdit1.SDK_Version()})";

            edOutputFile.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
            VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(edVideoFile.Text))
            {
                MessageBox.Show("Please select video file.");
                return;
            }

            if (!File.Exists(edAudioFile1.Text))
            {
                MessageBox.Show("Please select audio file 1.");
                return;
            }

            if (!File.Exists(edAudioFile2.Text))
            {
                MessageBox.Show("Please select audio file 2.");
                return;
            }

            var videoFile = new VideoSource(edVideoFile.Text, null, null, VideoEditStretchMode.Letterbox);
            await VideoEdit1.Input_AddVideoFileAsync(videoFile, null);

            var audioFile1 = new AudioSource(edAudioFile1.Text);
            await VideoEdit1.Input_AddAudioFileAsync(audioFile1, null, targetStreamIndex: 0);

            var audioFile2 = new AudioSource(edAudioFile2.Text);
            await VideoEdit1.Input_AddAudioFileAsync(audioFile2, null, targetStreamIndex: 1);

            VideoEdit1.Output_Filename = edOutputFile.Text;
            VideoEdit1.Output_Format = new MP4Output();

            await VideoEdit1.StartAsync();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await VideoEdit1.StopAsync();
        }
    }
}
