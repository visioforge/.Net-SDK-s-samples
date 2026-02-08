using System;
using System.Collections.Generic;
using System.Drawing;
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
        private HWEncodersOutputSettingsDialog _mp4HWSettingsDialog;
        private MP4SettingsDialog _mp4SettingsDialog;
        private AVISettingsDialog _aviSettingsDialog;
        private MP3SettingsDialog _mp3SettingsDialog;
        private WMVSettingsDialog _wmvSettingsDialog;
        private DVSettingsDialog _dvSettingsDialog;
        private WebMSettingsDialog _webmSettingsDialog;
        private FFMPEGSettingsDialog _ffmpegSettingsDialog;
        private FFMPEGEXESettingsDialog _ffmpegEXESettingsDialog;
        private GIFSettingsDialog _gifSettingsDialog;

        private bool _predefinedImagesUsed;
        private Bitmap _loadedImage;
        private string _loadedImageFilename;
        private string[] _loadedFiles;

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
            VideoEdit1.OnVideoFrameBitmap += VideoEdit1_OnVideoFrameBitmap;
        }

        private void DestroyEngine()
        {
            if (VideoEdit1 != null)
            {
                VideoEdit1.OnError -= VideoEdit1_OnError;
                VideoEdit1.OnStop -= VideoEdit1_OnStop;
                VideoEdit1.OnProgress -= VideoEdit1_OnProgress;
                VideoEdit1.OnVideoFrameBitmap -= VideoEdit1_OnVideoFrameBitmap;
                VideoEdit1.Dispose();
                VideoEdit1 = null;
            }
        }

        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog { Filter = "All files|*.*" };
            if (dlg.ShowDialog() == true)
            {
                edOutput.Text = dlg.FileName;
            }
        }

        private void btSelectImagesFolder_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.FolderBrowserDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                edImagesFolder.Text = dlg.SelectedPath;
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
        private void SetMP4Output(ref MP4Output o) { if (_mp4SettingsDialog == null) _mp4SettingsDialog = new MP4SettingsDialog(); _mp4SettingsDialog.SaveSettings(ref o); }
        private void SetFFMPEGEXEOutput(ref FFMPEGEXEOutput o) { if (_ffmpegEXESettingsDialog == null) _ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog(); _ffmpegEXESettingsDialog.SaveSettings(ref o); }
        private void SetWMVOutput(ref WMVOutput o) { if (_wmvSettingsDialog == null) _wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1); _wmvSettingsDialog.WMA = false; _wmvSettingsDialog.SaveSettings(ref o); }
        private void SetWebMOutput(ref WebMOutput o) { if (_webmSettingsDialog == null) _webmSettingsDialog = new WebMSettingsDialog(); _webmSettingsDialog.SaveSettings(ref o); }
        private void SetFFMPEGOutput(ref FFMPEGOutput o) { if (_ffmpegSettingsDialog == null) _ffmpegSettingsDialog = new FFMPEGSettingsDialog(); _ffmpegSettingsDialog.SaveSettings(ref o); }
        private void SetMP4HWOutput(ref MP4HWOutput o) { if (_mp4HWSettingsDialog == null) _mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4); _mp4HWSettingsDialog.SaveSettings(ref o); }
        private void SetGIFOutput(ref AnimatedGIFOutput o) { if (_gifSettingsDialog == null) _gifSettingsDialog = new GIFSettingsDialog(); _gifSettingsDialog.SaveSettings(ref o); }
        private void SetDVOutput(ref DVOutput o) { if (_dvSettingsDialog == null) _dvSettingsDialog = new DVSettingsDialog(); _dvSettingsDialog.SaveSettings(ref o); }
        private void SetAVIOutput(ref AVIOutput o)
        {
            if (_aviSettingsDialog == null) _aviSettingsDialog = new AVISettingsDialog(VideoEdit1);
            _aviSettingsDialog.SaveSettings(ref o);
            if (o.Audio_UseMP3Encoder) { var mp3 = new MP3Output(); SetMP3Output(ref mp3); o.MP3 = mp3; }
        }
        private void SetMP3Output(ref MP3Output o) { if (_mp3SettingsDialog == null) _mp3SettingsDialog = new MP3SettingsDialog(); _mp3SettingsDialog.SaveSettings(ref o); }
        private void SetMKVOutput(ref MKVv1Output o)
        {
            if (_aviSettingsDialog == null) _aviSettingsDialog = new AVISettingsDialog(VideoEdit1);
            _aviSettingsDialog.SaveSettings(ref o);
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

            VideoEdit1.Input_Clear_List();

            if (rbImagesPredefined.IsChecked == true)
            {
                _predefinedImagesUsed = true;

                await VideoEdit1.Input_AddVideoBlankAsync(
                    TimeSpan.FromMilliseconds(10000),
                    TimeSpan.FromMilliseconds(0),
                    1280,
                    720,
                    Color.Black);
            }
            else
            {
                _predefinedImagesUsed = false;

                if (!Directory.Exists(edImagesFolder.Text))
                {
                    MessageBox.Show(this, "Folder with images doesn't exist!");
                    btStart.IsEnabled = true;
                    btStop.IsEnabled = false;
                    return;
                }

                _loadedFiles = EnumerateImageFiles(edImagesFolder.Text);

                if (_loadedFiles.Length == 0)
                {
                    MessageBox.Show(this, "No image files found in the selected folder!");
                    btStart.IsEnabled = true;
                    btStop.IsEnabled = false;
                    return;
                }

                int width = Convert.ToInt32(edWidth.Text);
                int height = Convert.ToInt32(edHeight.Text);

                _loadedImageFilename = null;
                if (_loadedImage != null)
                {
                    _loadedImage.Dispose();
                    _loadedImage = null;
                }

                await VideoEdit1.Input_AddVideoBlankAsync(
                    TimeSpan.FromSeconds(_loadedFiles.Length * 2),
                    TimeSpan.FromMilliseconds(0),
                    width,
                    height,
                    Color.Black);
            }

            await VideoEdit1.StartAsync();
        }

        private static string[] EnumerateImageFiles(string path)
        {
            var res = new List<string>();
            var exts = new string[] { "*.jpg", "*.jpeg", "*.png", "*.gif", "*.bmp" };
            foreach (var ext in exts)
            {
                var files = Directory.GetFiles(path, ext);
                res.AddRange(files);
            }
            return res.ToArray();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await VideoEdit1.StopAsync();
            ProgressBar1.Value = 0;
        }

        private void VideoEdit1_OnVideoFrameBitmap(object sender, VideoFrameBitmapEventArgs e)
        {
            Bitmap frame;

            if (_predefinedImagesUsed)
            {
                // Load images from embedded resources, caching to avoid
                // per-frame resource loading and bitmap decoding overhead.
                string resourceName;

                if (e.Timestamp.TotalMilliseconds < 2000)
                    resourceName = "Video_From_Images.Images.1.jpg";
                else if (e.Timestamp.TotalMilliseconds < 4000)
                    resourceName = "Video_From_Images.Images.2.jpg";
                else if (e.Timestamp.TotalMilliseconds < 6000)
                    resourceName = "Video_From_Images.Images.3.jpg";
                else if (e.Timestamp.TotalMilliseconds < 8000)
                    resourceName = "Video_From_Images.Images.4.jpg";
                else
                    resourceName = "Video_From_Images.Images.5.jpg";

                if (_loadedImageFilename == resourceName)
                {
                    frame = _loadedImage;
                }
                else
                {
                    var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                    using (var resStream = assembly.GetManifestResourceStream(resourceName))
                    {
                        if (resStream == null)
                        {
                            return;
                        }

                        // The stream must remain open for the lifetime of the Bitmap,
                        // so we copy it to a MemoryStream that we control.
                        var ms = new MemoryStream();
                        resStream.CopyTo(ms);
                        ms.Position = 0;

                        _loadedImage?.Dispose();
                        _loadedImage = new Bitmap(ms);
                        _loadedImageFilename = resourceName;
                        frame = _loadedImage;
                    }
                }
            }
            else
            {
                int index = (int)Math.Truncate(e.Timestamp.TotalMilliseconds / 2000);
                if (_loadedFiles == null || _loadedFiles.Length == 0)
                {
                    return;
                }

                if (index >= _loadedFiles.Length)
                {
                    index = _loadedFiles.Length - 1;
                }

                if (_loadedImageFilename == _loadedFiles[index])
                {
                    frame = _loadedImage;
                }
                else
                {
                    _loadedImageFilename = _loadedFiles[index];
                    _loadedImage?.Dispose();
                    _loadedImage = new Bitmap(_loadedFiles[index]);
                    frame = _loadedImage;
                }
            }

            using (Graphics g = Graphics.FromImage(e.Frame))
            {
                g.DrawImage(frame, new RectangleF(0, 0, e.Frame.Width, e.Frame.Height), new RectangleF(0, 0, frame.Width, frame.Height), GraphicsUnit.Pixel);
                e.UpdateData = true;
            }
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
                case 0: case 1: if (_aviSettingsDialog == null) _aviSettingsDialog = new AVISettingsDialog(VideoEdit1); _aviSettingsDialog.ShowDialog(); break;
                case 2: if (_wmvSettingsDialog == null) _wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1); _wmvSettingsDialog.WMA = false; _wmvSettingsDialog.ShowDialog(); break;
                case 3: if (_dvSettingsDialog == null) _dvSettingsDialog = new DVSettingsDialog(); _dvSettingsDialog.ShowDialog(); break;
                case 4: if (_webmSettingsDialog == null) _webmSettingsDialog = new WebMSettingsDialog(); _webmSettingsDialog.ShowDialog(); break;
                case 5: if (_ffmpegSettingsDialog == null) _ffmpegSettingsDialog = new FFMPEGSettingsDialog(); _ffmpegSettingsDialog.ShowDialog(); break;
                case 6: if (_ffmpegEXESettingsDialog == null) _ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog(); _ffmpegEXESettingsDialog.ShowDialog(); break;
                case 7: case 10: if (_mp4SettingsDialog == null) _mp4SettingsDialog = new MP4SettingsDialog(); _mp4SettingsDialog.ShowDialog(); break;
                case 8: if (_mp4HWSettingsDialog == null) _mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4); _mp4HWSettingsDialog.ShowDialog(); break;
                case 9: if (_gifSettingsDialog == null) _gifSettingsDialog = new GIFSettingsDialog(); _gifSettingsDialog.ShowDialog(); break;
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
            var effect = VideoEdit1.Video_Effects_Get("Lightness");
            if (effect == null) { VideoEdit1.Video_Effects_Add(new VideoEffectLightness(true, (int)tbLightness.Value)); }
            else { var l = effect as IVideoEffectLightness; if (l != null) l.Value = (int)tbLightness.Value; }
        }

        private void tbSaturation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoEdit1 == null) return;
            var effect = VideoEdit1.Video_Effects_Get("Saturation");
            if (effect == null) { VideoEdit1.Video_Effects_Add(new VideoEffectSaturation((int)tbSaturation.Value)); }
            else { var s = effect as IVideoEffectSaturation; if (s != null) s.Value = (int)tbSaturation.Value; }
        }

        private void tbContrast_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoEdit1 == null) return;
            var effect = VideoEdit1.Video_Effects_Get("Contrast");
            if (effect == null) { VideoEdit1.Video_Effects_Add(new VideoEffectContrast(true, (int)tbContrast.Value)); }
            else { var c = effect as IVideoEffectContrast; if (c != null) c.Value = (int)tbContrast.Value; }
        }

        private void tbDarkness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoEdit1 == null) return;
            var effect = VideoEdit1.Video_Effects_Get("Darkness");
            if (effect == null) { VideoEdit1.Video_Effects_Add(new VideoEffectDarkness(true, (int)tbDarkness.Value)); }
            else { var d = effect as IVideoEffectDarkness; if (d != null) d.Value = (int)tbDarkness.Value; }
        }

        private void cbFlipX_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (VideoEdit1 == null) return;
            var effect = VideoEdit1.Video_Effects_Get("FlipDown");
            if (effect == null) { VideoEdit1.Video_Effects_Add(new VideoEffectFlipHorizontal(cbFlipX.IsChecked == true)); }
            else { var f = effect as IVideoEffectFlipDown; if (f != null) f.Enabled = cbFlipX.IsChecked == true; }
        }

        private void cbFlipY_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (VideoEdit1 == null) return;
            var effect = VideoEdit1.Video_Effects_Get("FlipRight");
            if (effect == null) { VideoEdit1.Video_Effects_Add(new VideoEffectFlipVertical(cbFlipY.IsChecked == true)); }
            else { var f = effect as IVideoEffectFlipRight; if (f != null) f.Enabled = cbFlipY.IsChecked == true; }
        }

        private void cbGreyscale_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (VideoEdit1 == null) return;
            var effect = VideoEdit1.Video_Effects_Get("Grayscale");
            if (effect == null) { VideoEdit1.Video_Effects_Add(new VideoEffectGrayscale(cbGreyscale.IsChecked == true)); }
            else { var g = effect as IVideoEffectGrayscale; if (g != null) g.Enabled = cbGreyscale.IsChecked == true; }
        }

        private void cbInvert_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (VideoEdit1 == null) return;
            var effect = VideoEdit1.Video_Effects_Get("Invert");
            if (effect == null) { VideoEdit1.Video_Effects_Add(new VideoEffectInvert(cbInvert.IsChecked == true)); }
            else { var i = effect as IVideoEffectInvert; if (i != null) i.Enabled = cbInvert.IsChecked == true; }
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

            if (_loadedImage != null)
            {
                _loadedImage.Dispose();
                _loadedImage = null;
            }
        }
    }
}
