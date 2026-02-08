using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core.Helpers;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoEdit;
using VisioForge.Core.UI.WinForms.Dialogs.OutputFormats;
using VisioForge.Core.VideoEdit;

namespace Video_Join_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HWEncodersOutputSettingsDialog mp4HWSettingsDialog;
        private MP4SettingsDialog mp4SettingsDialog;
        private AVISettingsDialog aviSettingsDialog;
        private WMVSettingsDialog wmvSettingsDialog;
        private DVSettingsDialog dvSettingsDialog;
        private PCMSettingsDialog pcmSettingsDialog;
        private MP3SettingsDialog mp3SettingsDialog;
        private WebMSettingsDialog webmSettingsDialog;
        private FFMPEGSettingsDialog ffmpegSettingsDialog;
        private FFMPEGEXESettingsDialog ffmpegEXESettingsDialog;
        private FLACSettingsDialog flacSettingsDialog;
        private CustomFormatSettingsDialog customFormatSettingsDialog;
        private OggVorbisSettingsDialog oggVorbisSettingsDialog;
        private SpeexSettingsDialog speexSettingsDialog;
        private M4ASettingsDialog m4aSettingsDialog;
        private GIFSettingsDialog gifSettingsDialog;

        private VideoEditCore VideoEdit1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateEngine()
        {
            VideoEdit1 = new VideoEditCore(VideoView1 as IVideoView);
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
            return Path.GetExtension(filename);
        }

        private async void btAddInputFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Video files|*.mp4;*.avi;*.wmv;*.mpg;*.mkv;*.mov;*.ts|Image files|*.bmp;*.jpg;*.jpeg;*.gif;*.png|Audio files|*.wav;*.mp3;*.ogg;*.wma|All files|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                string frameRateText = (cbFrameRate.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "0";
                VideoEdit1.Video_FrameRate = new VideoFrameRate(Convert.ToDouble(frameRateText, CultureInfo.InvariantCulture));

                string s = dlg.FileName;
                lbFiles.Items.Add(s);

                int customWidth = 0;
                int customHeight = 0;

                if (cbResize.IsChecked == true)
                {
                    customWidth = Convert.ToInt32(edWidth.Text);
                    customHeight = Convert.ToInt32(edHeight.Text);
                }

                if ((string.Compare(GetFileExt(s), ".BMP", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".JPG", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".JPEG", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".GIF", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".PNG", StringComparison.OrdinalIgnoreCase) == 0))
                {
                    await VideoEdit1.Input_AddImageFileAsync(s, TimeSpan.FromMilliseconds(2000), null, VideoEditStretchMode.Letterbox, 0, customWidth, customHeight);
                }
                else if ((string.Compare(GetFileExt(s), ".WAV", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".MP3", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".OGG", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".WMA", StringComparison.OrdinalIgnoreCase) == 0))
                {
                    var audioFile = new AudioSource(s, TimeSpan.Zero, TimeSpan.Zero, string.Empty);
                    await VideoEdit1.Input_AddAudioFileAsync(audioFile, null, 0);
                }
                else
                {
                    var videoFile = new VideoSource(s, TimeSpan.Zero, TimeSpan.Zero, VideoEditStretchMode.Letterbox);
                    var audioFile = new AudioSource(s, TimeSpan.Zero, TimeSpan.Zero, string.Empty);

                    await VideoEdit1.Input_AddVideoFileAsync(videoFile, null, 0, customWidth, customHeight);
                    await VideoEdit1.Input_AddAudioFileAsync(audioFile, null, 0);
                }
            }
        }

        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "All files|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                edOutput.Text = dlg.FileName;
            }
        }

        private void btClearList_Click(object sender, RoutedEventArgs e)
        {
            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
        }

        private void btConfigure_Click(object sender, RoutedEventArgs e)
        {
            switch (cbOutputVideoFormat.SelectedIndex)
            {
                case 0:
                case 1:
                    {
                        if (aviSettingsDialog == null)
                        {
                            aviSettingsDialog = new AVISettingsDialog(VideoEdit1);
                        }
                        aviSettingsDialog.ShowDialog();
                        break;
                    }
                case 2:
                    {
                        if (wmvSettingsDialog == null)
                        {
                            wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1);
                        }
                        wmvSettingsDialog.WMA = false;
                        wmvSettingsDialog.ShowDialog();
                        break;
                    }
                case 3:
                    {
                        if (dvSettingsDialog == null)
                        {
                            dvSettingsDialog = new DVSettingsDialog();
                        }
                        dvSettingsDialog.ShowDialog();
                        break;
                    }
                case 4:
                    {
                        if (pcmSettingsDialog == null)
                        {
                            pcmSettingsDialog = new PCMSettingsDialog(VideoEdit1);
                        }
                        pcmSettingsDialog.ShowDialog();
                        break;
                    }
                case 5:
                    {
                        if (mp3SettingsDialog == null)
                        {
                            mp3SettingsDialog = new MP3SettingsDialog();
                        }
                        mp3SettingsDialog.ShowDialog();
                        break;
                    }
                case 6:
                    {
                        if (m4aSettingsDialog == null)
                        {
                            m4aSettingsDialog = new M4ASettingsDialog();
                        }
                        m4aSettingsDialog.ShowDialog();
                        break;
                    }
                case 7:
                    {
                        if (wmvSettingsDialog == null)
                        {
                            wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1);
                        }
                        wmvSettingsDialog.WMA = true;
                        wmvSettingsDialog.ShowDialog();
                        break;
                    }
                case 8:
                    {
                        if (oggVorbisSettingsDialog == null)
                        {
                            oggVorbisSettingsDialog = new OggVorbisSettingsDialog();
                        }
                        oggVorbisSettingsDialog.ShowDialog();
                        break;
                    }
                case 9:
                    {
                        if (flacSettingsDialog == null)
                        {
                            flacSettingsDialog = new FLACSettingsDialog();
                        }
                        flacSettingsDialog.ShowDialog();
                        break;
                    }
                case 10:
                    {
                        if (speexSettingsDialog == null)
                        {
                            speexSettingsDialog = new SpeexSettingsDialog();
                        }
                        speexSettingsDialog.ShowDialog();
                        break;
                    }
                case 11:
                    {
                        if (customFormatSettingsDialog == null)
                        {
                            customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoEdit1);
                        }
                        customFormatSettingsDialog.ShowDialog();
                        break;
                    }
                case 12:
                    {
                        if (webmSettingsDialog == null)
                        {
                            webmSettingsDialog = new WebMSettingsDialog();
                        }
                        webmSettingsDialog.ShowDialog();
                        break;
                    }
                case 13:
                    {
                        if (ffmpegSettingsDialog == null)
                        {
                            ffmpegSettingsDialog = new FFMPEGSettingsDialog();
                        }
                        ffmpegSettingsDialog.ShowDialog();
                        break;
                    }
                case 14:
                    {
                        if (ffmpegEXESettingsDialog == null)
                        {
                            ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
                        }
                        ffmpegEXESettingsDialog.ShowDialog();
                        break;
                    }
                case 15:
                case 18:
                    {
                        if (mp4SettingsDialog == null)
                        {
                            mp4SettingsDialog = new MP4SettingsDialog();
                        }
                        mp4SettingsDialog.ShowDialog();
                        break;
                    }
                case 16:
                    {
                        if (mp4HWSettingsDialog == null)
                        {
                            mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
                        }
                        mp4HWSettingsDialog.ShowDialog();
                        break;
                    }
                case 17:
                    {
                        if (gifSettingsDialog == null)
                        {
                            gifSettingsDialog = new GIFSettingsDialog();
                        }
                        gifSettingsDialog.ShowDialog();
                        break;
                    }
            }
        }

        private void cbOutputVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (edOutput == null)
            {
                return;
            }

            switch (cbOutputVideoFormat.SelectedIndex)
            {
                case 0: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi"); break;
                case 1: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mkv"); break;
                case 2: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wmv"); break;
                case 3: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi"); break;
                case 4: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wav"); break;
                case 5: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp3"); break;
                case 6: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".m4a"); break;
                case 7: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wma"); break;
                case 8: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg"); break;
                case 9: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".flac"); break;
                case 10: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg"); break;
                case 11: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi"); break;
                case 12: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".webm"); break;
                case 13: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi"); break;
                case 14: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi"); break;
                case 15: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4"); break;
                case 16: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4"); break;
                case 17: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".gif"); break;
                case 18: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".enc"); break;
            }
        }

        private void SetMP3Output(ref MP3Output mp3Output)
        {
            if (mp3SettingsDialog == null) { mp3SettingsDialog = new MP3SettingsDialog(); }
            mp3SettingsDialog.SaveSettings(ref mp3Output);
        }

        private void SetMP4Output(ref MP4Output mp4Output)
        {
            if (mp4SettingsDialog == null) { mp4SettingsDialog = new MP4SettingsDialog(); }
            mp4SettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetFFMPEGEXEOutput(ref FFMPEGEXEOutput ffmpegOutput)
        {
            if (ffmpegEXESettingsDialog == null) { ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog(); }
            ffmpegEXESettingsDialog.SaveSettings(ref ffmpegOutput);
        }

        private void SetWMVOutput(ref WMVOutput wmvOutput)
        {
            if (wmvSettingsDialog == null) { wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1); }
            wmvSettingsDialog.WMA = false;
            wmvSettingsDialog.SaveSettings(ref wmvOutput);
        }

        private void SetWMAOutput(ref WMAOutput wmaOutput)
        {
            if (wmvSettingsDialog == null) { wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1); }
            wmvSettingsDialog.WMA = true;
            wmvSettingsDialog.SaveSettings(ref wmaOutput);
        }

        private void SetACMOutput(ref ACMOutput acmOutput)
        {
            if (pcmSettingsDialog == null) { pcmSettingsDialog = new PCMSettingsDialog(VideoEdit1); }
            pcmSettingsDialog.SaveSettings(ref acmOutput);
        }

        private void SetWebMOutput(ref WebMOutput webmOutput)
        {
            if (webmSettingsDialog == null) { webmSettingsDialog = new WebMSettingsDialog(); }
            webmSettingsDialog.SaveSettings(ref webmOutput);
        }

        private void SetFFMPEGOutput(ref FFMPEGOutput ffmpegOutput)
        {
            if (ffmpegSettingsDialog == null) { ffmpegSettingsDialog = new FFMPEGSettingsDialog(); }
            ffmpegSettingsDialog.SaveSettings(ref ffmpegOutput);
        }

        private void SetFLACOutput(ref FLACOutput flacOutput)
        {
            if (flacSettingsDialog == null) { flacSettingsDialog = new FLACSettingsDialog(); }
            flacSettingsDialog.SaveSettings(ref flacOutput);
        }

        private void SetMP4HWOutput(ref MP4HWOutput mp4Output)
        {
            if (mp4HWSettingsDialog == null) { mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4); }
            mp4HWSettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetSpeexOutput(ref SpeexOutput speexOutput)
        {
            if (speexSettingsDialog == null) { speexSettingsDialog = new SpeexSettingsDialog(); }
            speexSettingsDialog.SaveSettings(ref speexOutput);
        }

        private void SetM4AOutput(ref M4AOutput m4aOutput)
        {
            if (m4aSettingsDialog == null) { m4aSettingsDialog = new M4ASettingsDialog(); }
            m4aSettingsDialog.SaveSettings(ref m4aOutput);
        }

        private void SetGIFOutput(ref AnimatedGIFOutput gifOutput)
        {
            if (gifSettingsDialog == null) { gifSettingsDialog = new GIFSettingsDialog(); }
            gifSettingsDialog.SaveSettings(ref gifOutput);
        }

        private void SetCustomOutput(ref CustomOutput customOutput)
        {
            if (customFormatSettingsDialog == null) { customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoEdit1); }
            customFormatSettingsDialog.SaveSettings(ref customOutput);
        }

        private void SetDVOutput(ref DVOutput dvOutput)
        {
            if (dvSettingsDialog == null) { dvSettingsDialog = new DVSettingsDialog(); }
            dvSettingsDialog.SaveSettings(ref dvOutput);
        }

        private void SetAVIOutput(ref AVIOutput aviOutput)
        {
            if (aviSettingsDialog == null) { aviSettingsDialog = new AVISettingsDialog(VideoEdit1); }
            aviSettingsDialog.SaveSettings(ref aviOutput);
            if (aviOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new MP3Output();
                SetMP3Output(ref mp3Output);
                aviOutput.MP3 = mp3Output;
            }
        }

        private void SetMKVOutput(ref MKVv1Output mkvOutput)
        {
            if (aviSettingsDialog == null) { aviSettingsDialog = new AVISettingsDialog(VideoEdit1); }
            aviSettingsDialog.SaveSettings(ref mkvOutput);
            if (mkvOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new MP3Output();
                SetMP3Output(ref mp3Output);
                mkvOutput.MP3 = mp3Output;
            }
        }

        private void SetOGGOutput(ref OGGVorbisOutput oggVorbisOutput)
        {
            if (oggVorbisSettingsDialog == null) { oggVorbisSettingsDialog = new OggVorbisSettingsDialog(); }
            oggVorbisSettingsDialog.SaveSettings(ref oggVorbisOutput);
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            btStart.IsEnabled = false;
            btStop.IsEnabled = true;

            VideoEdit1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoEdit1.Debug_Telemetry = cbTelemetry.IsChecked == true;

            mmLog.Clear();

            VideoEdit1.Mode = VideoEditMode.Convert;
            VideoEdit1.Video_Effects_Clear();
            VideoEdit1.Video_Resize = cbResize.IsChecked == true;

            if (VideoEdit1.Video_Resize)
            {
                if (!int.TryParse(edWidth.Text, out int width) || width <= 0)
                {
                    MessageBox.Show(this, "Please enter a valid positive width value.");
                    btStart.IsEnabled = true;
                    btStop.IsEnabled = false;
                    return;
                }

                if (!int.TryParse(edHeight.Text, out int height) || height <= 0)
                {
                    MessageBox.Show(this, "Please enter a valid positive height value.");
                    btStart.IsEnabled = true;
                    btStop.IsEnabled = false;
                    return;
                }

                VideoEdit1.Video_Resize_Width = width;
                VideoEdit1.Video_Resize_Height = height;
            }

            string frameRateText = (cbFrameRate.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "0";
            if (!double.TryParse(frameRateText, NumberStyles.Any, CultureInfo.InvariantCulture, out double frameRate) || frameRate <= 0)
            {
                MessageBox.Show(this, "Please enter a valid positive frame rate.");
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
                return;
            }

            VideoEdit1.Video_FrameRate = new VideoFrameRate(frameRate);
            VideoEdit1.Output_Filename = edOutput.Text;

            switch (cbOutputVideoFormat.SelectedIndex)
            {
                case 0: { var o = new AVIOutput(); SetAVIOutput(ref o); VideoEdit1.Output_Format = o; break; }
                case 1: { var o = new MKVv1Output(); SetMKVOutput(ref o); VideoEdit1.Output_Format = o; break; }
                case 2: { var o = new WMVOutput(); SetWMVOutput(ref o); VideoEdit1.Output_Format = o; break; }
                case 3: { var o = new DVOutput(); SetDVOutput(ref o); VideoEdit1.Output_Format = o; break; }
                case 4: { var o = new ACMOutput(); SetACMOutput(ref o); VideoEdit1.Output_Format = o; break; }
                case 5: { var o = new MP3Output(); SetMP3Output(ref o); VideoEdit1.Output_Format = o; break; }
                case 6: { var o = new M4AOutput(); SetM4AOutput(ref o); VideoEdit1.Output_Format = o; break; }
                case 7: { var o = new WMAOutput(); SetWMAOutput(ref o); VideoEdit1.Output_Format = o; break; }
                case 8: { var o = new OGGVorbisOutput(); SetOGGOutput(ref o); VideoEdit1.Output_Format = o; break; }
                case 9: { var o = new FLACOutput(); SetFLACOutput(ref o); VideoEdit1.Output_Format = o; break; }
                case 10: { var o = new SpeexOutput(); SetSpeexOutput(ref o); VideoEdit1.Output_Format = o; break; }
                case 11: { var o = new CustomOutput(); SetCustomOutput(ref o); VideoEdit1.Output_Format = o; break; }
                case 12: { var o = new WebMOutput(); SetWebMOutput(ref o); VideoEdit1.Output_Format = o; break; }
                case 13: { var o = new FFMPEGOutput(); SetFFMPEGOutput(ref o); VideoEdit1.Output_Format = o; break; }
                case 14: { var o = new FFMPEGEXEOutput(); SetFFMPEGEXEOutput(ref o); VideoEdit1.Output_Format = o; break; }
                case 15: { var o = new MP4Output(); SetMP4Output(ref o); VideoEdit1.Output_Format = o; break; }
                case 16: { var o = new MP4HWOutput(); SetMP4HWOutput(ref o); VideoEdit1.Output_Format = o; break; }
                case 17: { var o = new AnimatedGIFOutput(); SetGIFOutput(ref o); VideoEdit1.Output_Format = o; break; }
                case 18:
                    MessageBox.Show(this, "Please use Main Demo to create encrypted files.");
                    btStart.IsEnabled = true;
                    btStop.IsEnabled = false;
                    return;
            }

            VideoEdit1.Audio_Preview_Enabled = true;
            await VideoEdit1.StartAsync();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await VideoEdit1.StopAsync();
            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
            ProgressBar1.Value = 0;
        }

        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + "(" + e.CallSite + ")" + Environment.NewLine;
            });
        }

        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            Dispatcher.Invoke(() => { ProgressBar1.Value = e.Progress; });
        }

        private void VideoEdit1_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
                ProgressBar1.Value = 0;
                lbFiles.Items.Clear();
                VideoEdit1.Input_Clear_List();
                VideoEdit1.Video_Transition_Clear();

                if (e.Successful)
                {
                    MessageBox.Show(this, "Completed successfully", string.Empty, MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show(this, "Stopped with error", string.Empty, MessageBoxButton.OK);
                }
            });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();
            Title += $" (SDK v{VideoEdit1.SDK_Version()})";
            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
            VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            cbFrameRate.SelectedIndex = 3;
            cbOutputVideoFormat.SelectedIndex = 15;
            btStop.IsEnabled = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DestroyEngine();
        }
    }
}
