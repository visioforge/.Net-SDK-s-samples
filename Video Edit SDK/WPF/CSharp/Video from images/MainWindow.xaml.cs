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
using VisioForge.Core.Types.VideoEffects;
using VisioForge.Core.UI.WinForms.Dialogs.OutputFormats;
using VisioForge.Core.UI.WinForms.Dialogs.VideoEffects;
using VisioForge.Core.VideoEdit;

namespace Video_From_Images
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HWEncodersOutputSettingsDialog mp4HWSettingsDialog;
        private MP4SettingsDialog mp4SettingsDialog;
        private AVISettingsDialog aviSettingsDialog;
        private MP3SettingsDialog mp3SettingsDialog;
        private WMVSettingsDialog wmvSettingsDialog;
        private DVSettingsDialog dvSettingsDialog;
        private WebMSettingsDialog webmSettingsDialog;
        private FFMPEGSettingsDialog ffmpegSettingsDialog;
        private FFMPEGEXESettingsDialog ffmpegEXESettingsDialog;
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
                Multiselect = true,
                Filter = "Image files|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif;*.tiff|Audio files|*.wav;*.mp3;*.ogg;*.aac;*.m4a;*.wma|Video files|*.mp4;*.avi;*.wmv;*.mpg;*.mkv;*.mov;*.ts|All files|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                string frameRateText = (cbFrameRate.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "15";
                VideoEdit1.Video_FrameRate = new VideoFrameRate(Convert.ToDouble(frameRateText, CultureInfo.InvariantCulture));

                int customWidth = 0;
                int customHeight = 0;

                if (cbResize.IsChecked == true)
                {
                    customWidth = Convert.ToInt32(edWidth.Text);
                    customHeight = Convert.ToInt32(edHeight.Text);
                }

                foreach (var s in dlg.FileNames)
                {
                    lbFiles.Items.Add(s);

                    if ((string.Compare(GetFileExt(s), ".BMP", StringComparison.OrdinalIgnoreCase) == 0) ||
                       (string.Compare(GetFileExt(s), ".JPG", StringComparison.OrdinalIgnoreCase) == 0) ||
                       (string.Compare(GetFileExt(s), ".JPEG", StringComparison.OrdinalIgnoreCase) == 0) ||
                       (string.Compare(GetFileExt(s), ".GIF", StringComparison.OrdinalIgnoreCase) == 0) ||
                       (string.Compare(GetFileExt(s), ".PNG", StringComparison.OrdinalIgnoreCase) == 0) ||
                       (string.Compare(GetFileExt(s), ".TIF", StringComparison.OrdinalIgnoreCase) == 0) ||
                       (string.Compare(GetFileExt(s), ".TIFF", StringComparison.OrdinalIgnoreCase) == 0))
                    {
                        await VideoEdit1.Input_AddImageFileAsync(s, TimeSpan.FromMilliseconds(2000), null, VideoEditStretchMode.Letterbox, 0, customWidth, customHeight);
                    }
                    else if ((string.Compare(GetFileExt(s), ".WAV", StringComparison.OrdinalIgnoreCase) == 0) ||
                       (string.Compare(GetFileExt(s), ".MP3", StringComparison.OrdinalIgnoreCase) == 0) ||
                       (string.Compare(GetFileExt(s), ".OGG", StringComparison.OrdinalIgnoreCase) == 0) ||
                       (string.Compare(GetFileExt(s), ".AAC", StringComparison.OrdinalIgnoreCase) == 0) ||
                       (string.Compare(GetFileExt(s), ".M4A", StringComparison.OrdinalIgnoreCase) == 0) ||
                       (string.Compare(GetFileExt(s), ".WMA", StringComparison.OrdinalIgnoreCase) == 0))
                    {
                        var audioFile = new AudioSource(s, null, null, string.Empty, 0, 1.0);
                        await VideoEdit1.Input_AddAudioFileAsync(audioFile, null, 0);
                    }
                    else
                    {
                        var audioFile = new AudioSource(s, null, null, s, 0, 1.0);
                        var videoFile = new VideoSource(s, null, null, VideoEditStretchMode.Letterbox, 0, 1.0);

                        await VideoEdit1.Input_AddVideoFileAsync(videoFile, null, 0, customWidth, customHeight);
                        await VideoEdit1.Input_AddAudioFileAsync(audioFile, null, 0);
                    }
                }
            }
        }

        private void btClearList_Click(object sender, RoutedEventArgs e)
        {
            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
        }

        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog { Filter = "All files|*.*" };
            if (dlg.ShowDialog() == true)
            {
                edOutput.Text = dlg.FileName;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();
            Title += $" (SDK v{VideoEdit1.SDK_Version()})";
            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
            VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            cbFrameRate.SelectedIndex = 7;
            cbOutputFormat.SelectedIndex = 7;
        }

        // Set*Output methods
        private void SetMP4Output(ref MP4Output mp4Output) { if (mp4SettingsDialog == null) mp4SettingsDialog = new MP4SettingsDialog(); mp4SettingsDialog.SaveSettings(ref mp4Output); }
        private void SetFFMPEGEXEOutput(ref FFMPEGEXEOutput o) { if (ffmpegEXESettingsDialog == null) ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog(); ffmpegEXESettingsDialog.SaveSettings(ref o); }
        private void SetWMVOutput(ref WMVOutput o) { if (wmvSettingsDialog == null) wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1); wmvSettingsDialog.WMA = false; wmvSettingsDialog.SaveSettings(ref o); }
        private void SetWebMOutput(ref WebMOutput o) { if (webmSettingsDialog == null) webmSettingsDialog = new WebMSettingsDialog(); webmSettingsDialog.SaveSettings(ref o); }
        private void SetFFMPEGOutput(ref FFMPEGOutput o) { if (ffmpegSettingsDialog == null) ffmpegSettingsDialog = new FFMPEGSettingsDialog(); ffmpegSettingsDialog.SaveSettings(ref o); }
        private void SetMP4HWOutput(ref MP4HWOutput o) { if (mp4HWSettingsDialog == null) mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4); mp4HWSettingsDialog.SaveSettings(ref o); }
        private void SetGIFOutput(ref AnimatedGIFOutput o) { if (gifSettingsDialog == null) gifSettingsDialog = new GIFSettingsDialog(); gifSettingsDialog.SaveSettings(ref o); }
        private void SetDVOutput(ref DVOutput o) { if (dvSettingsDialog == null) dvSettingsDialog = new DVSettingsDialog(); dvSettingsDialog.SaveSettings(ref o); }
        private void SetAVIOutput(ref AVIOutput o)
        {
            if (aviSettingsDialog == null) aviSettingsDialog = new AVISettingsDialog(VideoEdit1);
            aviSettingsDialog.SaveSettings(ref o);
            if (o.Audio_UseMP3Encoder) { var mp3 = new MP3Output(); SetMP3Output(ref mp3); o.MP3 = mp3; }
        }
        private void SetMP3Output(ref MP3Output o) { if (mp3SettingsDialog == null) mp3SettingsDialog = new MP3SettingsDialog(); mp3SettingsDialog.SaveSettings(ref o); }
        private void SetMKVOutput(ref MKVv1Output o)
        {
            if (aviSettingsDialog == null) aviSettingsDialog = new AVISettingsDialog(VideoEdit1);
            aviSettingsDialog.SaveSettings(ref o);
            if (o.Audio_UseMP3Encoder) { var mp3 = new MP3Output(); SetMP3Output(ref mp3); o.MP3 = mp3; }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            btStart.IsEnabled = false;
            btStop.IsEnabled = true;

            mmLog.Clear();
            VideoEdit1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoEdit1.Video_Resize = cbResize.IsChecked == true;

            if (VideoEdit1.Video_Resize)
            {
                VideoEdit1.Video_Resize_Width = Convert.ToInt32(edWidth.Text);
                VideoEdit1.Video_Resize_Height = Convert.ToInt32(edHeight.Text);
            }

            string frameRateText = (cbFrameRate.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "15";
            VideoEdit1.Video_FrameRate = new VideoFrameRate(Convert.ToDouble(frameRateText, CultureInfo.InvariantCulture));

            VideoEdit1.Video_Renderer_SetAuto();

            if (rbPreview.IsChecked == true)
            {
                VideoEdit1.Mode = VideoEditMode.Preview;
            }
            else
            {
                VideoEdit1.Mode = VideoEditMode.Convert;
                VideoEdit1.Output_Filename = edOutput.Text;

                switch (cbOutputFormat.SelectedIndex)
                {
                    case 0: { var o = new AVIOutput(); SetAVIOutput(ref o); VideoEdit1.Output_Format = o; break; }
                    case 1: { var o = new MKVv1Output(); SetMKVOutput(ref o); VideoEdit1.Output_Format = o; break; }
                    case 2: { var o = new WMVOutput(); SetWMVOutput(ref o); VideoEdit1.Output_Format = o; break; }
                    case 3: { var o = new DVOutput(); SetDVOutput(ref o); VideoEdit1.Output_Format = o; break; }
                    case 4: { var o = new WebMOutput(); SetWebMOutput(ref o); VideoEdit1.Output_Format = o; break; }
                    case 5: { var o = new FFMPEGOutput(); SetFFMPEGOutput(ref o); VideoEdit1.Output_Format = o; break; }
                    case 6: { var o = new FFMPEGEXEOutput(); SetFFMPEGEXEOutput(ref o); VideoEdit1.Output_Format = o; break; }
                    case 7: { var o = new MP4Output(); SetMP4Output(ref o); VideoEdit1.Output_Format = o; break; }
                    case 8: { var o = new MP4HWOutput(); SetMP4HWOutput(ref o); VideoEdit1.Output_Format = o; break; }
                    case 9: { var o = new AnimatedGIFOutput(); SetGIFOutput(ref o); VideoEdit1.Output_Format = o; break; }
                    case 10:
                    {
                        var enc = new MP4Output(); SetMP4Output(ref enc);
                        enc.Encryption = true;
                        enc.Encryption_Format = EncryptionFormat.MP4_H264_SW_AAC;
                        enc.Encryption_KeyType = EncryptionKeyType.String;
                        // TODO: Replace with a secure key before production use.
                        enc.Encryption_Key = "demo_sample_key";
                        VideoEdit1.Output_Format = enc;
                        break;
                    }
                }
            }

            VideoEdit1.Video_Effects_Enabled = true;
            VideoEdit1.Video_Effects_Clear();
            lbLogos.Items.Clear();
            ConfigureVideoEffects();

            await VideoEdit1.StartAsync();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await VideoEdit1.StopAsync();
            ProgressBar1.Value = 0;
            VideoEdit1.Input_Clear_List();
            lbFiles.Items.Clear();
        }

        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            Dispatcher.Invoke(() => { ProgressBar1.Value = e.Progress; });
        }

        private void VideoEdit1_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                ProgressBar1.Value = 0;
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;

                if (e.Successful)
                    MessageBox.Show(this, "Completed successfully", string.Empty, MessageBoxButton.OK);
                else
                    MessageBox.Show(this, "Stopped with error", string.Empty, MessageBoxButton.OK);
            });
        }

        private void cbOutputFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (edOutput == null) return;
            switch (cbOutputFormat.SelectedIndex)
            {
                case 0: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi"); break;
                case 1: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mkv"); break;
                case 2: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wmv"); break;
                case 3: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi"); break;
                case 4: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".webm"); break;
                case 5: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi"); break;
                case 6: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi"); break;
                case 7: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4"); break;
                case 8: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4"); break;
                case 9: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".gif"); break;
                case 10: edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".enc"); break;
            }
        }

        private void btConfigure_Click(object sender, RoutedEventArgs e)
        {
            switch (cbOutputFormat.SelectedIndex)
            {
                case 0: case 1: if (aviSettingsDialog == null) aviSettingsDialog = new AVISettingsDialog(VideoEdit1); aviSettingsDialog.ShowDialog(); break;
                case 2: if (wmvSettingsDialog == null) wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1); wmvSettingsDialog.WMA = false; wmvSettingsDialog.ShowDialog(); break;
                case 3: if (dvSettingsDialog == null) dvSettingsDialog = new DVSettingsDialog(); dvSettingsDialog.ShowDialog(); break;
                case 4: if (webmSettingsDialog == null) webmSettingsDialog = new WebMSettingsDialog(); webmSettingsDialog.ShowDialog(); break;
                case 5: if (ffmpegSettingsDialog == null) ffmpegSettingsDialog = new FFMPEGSettingsDialog(); ffmpegSettingsDialog.ShowDialog(); break;
                case 6: if (ffmpegEXESettingsDialog == null) ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog(); ffmpegEXESettingsDialog.ShowDialog(); break;
                case 7: case 10: if (mp4SettingsDialog == null) mp4SettingsDialog = new MP4SettingsDialog(); mp4SettingsDialog.ShowDialog(); break;
                case 8: if (mp4HWSettingsDialog == null) mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4); mp4HWSettingsDialog.ShowDialog(); break;
                case 9: if (gifSettingsDialog == null) gifSettingsDialog = new GIFSettingsDialog(); gifSettingsDialog.ShowDialog(); break;
            }
        }

        // Text logo
        private void btTextLogoAdd_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new TextLogoSettingsDialog();
            var name = dlg.GenerateNewEffectName(VideoEdit1);
            var effect = new VideoEffectTextLogo(true, name);
            VideoEdit1.Video_Effects_Add(effect);
            lbLogos.Items.Add(effect.Name);
            dlg.Fill(effect);
            dlg.ShowDialog();
            dlg.Dispose();
        }

        // Image logo
        private void btImageLogoAdd_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ImageLogoSettingsDialog();
            var name = dlg.GenerateNewEffectName(VideoEdit1);
            var effect = new VideoEffectImageLogo(true, name);
            VideoEdit1.Video_Effects_Add(effect);
            lbLogos.Items.Add(effect.Name);
            dlg.Fill(effect);
            dlg.ShowDialog();
            dlg.Dispose();
        }

        private void btLogoRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbLogos.SelectedItem != null)
            {
                VideoEdit1.Video_Effects_Remove((string)lbLogos.SelectedItem);
                lbLogos.Items.Remove(lbLogos.SelectedItem);
            }
        }

        private void btLogoEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lbLogos.SelectedItem != null)
            {
                var effect = VideoEdit1.Video_Effects_Get((string)lbLogos.SelectedItem);
                if (effect == null) return;

                if (effect.GetEffectType() == VideoEffectType.TextLogo)
                {
                    var dlg = new TextLogoSettingsDialog();
                    dlg.Attach(effect);
                    dlg.ShowDialog();
                    dlg.Dispose();
                }
                else if (effect.GetEffectType() == VideoEffectType.ImageLogo)
                {
                    var dlg = new ImageLogoSettingsDialog();
                    dlg.Attach(effect);
                    dlg.ShowDialog();
                    dlg.Dispose();
                }
            }
        }

        // Video effects
        private void tbLightness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoEdit1 == null) return;
            IVideoEffectLightness lightness;
            var effect = VideoEdit1.Video_Effects_Get("Lightness");
            if (effect == null) { lightness = new VideoEffectLightness(true, (int)tbLightness.Value); VideoEdit1.Video_Effects_Add(lightness); }
            else { lightness = effect as IVideoEffectLightness; if (lightness != null) lightness.Value = (int)tbLightness.Value; }
        }

        private void tbSaturation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoEdit1 == null) return;
            IVideoEffectSaturation saturation;
            var effect = VideoEdit1.Video_Effects_Get("Saturation");
            if (effect == null) { saturation = new VideoEffectSaturation((int)tbSaturation.Value); VideoEdit1.Video_Effects_Add(saturation); }
            else { saturation = effect as IVideoEffectSaturation; if (saturation != null) saturation.Value = (int)tbSaturation.Value; }
        }

        private void tbContrast_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoEdit1 == null) return;
            IVideoEffectContrast contrast;
            var effect = VideoEdit1.Video_Effects_Get("Contrast");
            if (effect == null) { contrast = new VideoEffectContrast(true, (int)tbContrast.Value); VideoEdit1.Video_Effects_Add(contrast); }
            else { contrast = effect as IVideoEffectContrast; if (contrast != null) contrast.Value = (int)tbContrast.Value; }
        }

        private void tbDarkness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoEdit1 == null) return;
            IVideoEffectDarkness darkness;
            var effect = VideoEdit1.Video_Effects_Get("Darkness");
            if (effect == null) { darkness = new VideoEffectDarkness(true, (int)tbDarkness.Value); VideoEdit1.Video_Effects_Add(darkness); }
            else { darkness = effect as IVideoEffectDarkness; if (darkness != null) darkness.Value = (int)tbDarkness.Value; }
        }

        private void cbFlipX_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (VideoEdit1 == null) return;
            IVideoEffectFlipDown flip;
            var effect = VideoEdit1.Video_Effects_Get("FlipDown");
            if (effect == null) { flip = new VideoEffectFlipHorizontal(cbFlipX.IsChecked == true); VideoEdit1.Video_Effects_Add(flip); }
            else { flip = effect as IVideoEffectFlipDown; if (flip != null) flip.Enabled = cbFlipX.IsChecked == true; }
        }

        private void cbFlipY_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (VideoEdit1 == null) return;
            IVideoEffectFlipRight flip;
            var effect = VideoEdit1.Video_Effects_Get("FlipRight");
            if (effect == null) { flip = new VideoEffectFlipVertical(cbFlipY.IsChecked == true); VideoEdit1.Video_Effects_Add(flip); }
            else { flip = effect as IVideoEffectFlipRight; if (flip != null) flip.Enabled = cbFlipY.IsChecked == true; }
        }

        private void cbGreyscale_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (VideoEdit1 == null) return;
            IVideoEffectGrayscale grayscale;
            var effect = VideoEdit1.Video_Effects_Get("Grayscale");
            if (effect == null) { grayscale = new VideoEffectGrayscale(cbGreyscale.IsChecked == true); VideoEdit1.Video_Effects_Add(grayscale); }
            else { grayscale = effect as IVideoEffectGrayscale; if (grayscale != null) grayscale.Enabled = cbGreyscale.IsChecked == true; }
        }

        private void cbInvert_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (VideoEdit1 == null) return;
            IVideoEffectInvert invert;
            var effect = VideoEdit1.Video_Effects_Get("Invert");
            if (effect == null) { invert = new VideoEffectInvert(cbInvert.IsChecked == true); VideoEdit1.Video_Effects_Add(invert); }
            else { invert = effect as IVideoEffectInvert; if (invert != null) invert.Enabled = cbInvert.IsChecked == true; }
        }

        private void ConfigureVideoEffects()
        {
            if (tbLightness.Value != 0) tbLightness_ValueChanged(null, null);
            if (tbSaturation.Value != 255) tbSaturation_ValueChanged(null, null);
            if (tbContrast.Value > 0) tbContrast_ValueChanged(null, null);
            if (tbDarkness.Value > 0) tbDarkness_ValueChanged(null, null);
            if (cbGreyscale.IsChecked == true) cbGreyscale_CheckedChanged(null, null);
            if (cbInvert.IsChecked == true) cbInvert_CheckedChanged(null, null);
            if (cbFlipX.IsChecked == true) cbFlipX_CheckedChanged(null, null);
            if (cbFlipY.IsChecked == true) cbFlipY_CheckedChanged(null, null);
        }

        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() => { mmLog.Text += e.Message + Environment.NewLine; });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DestroyEngine();
        }
    }
}
