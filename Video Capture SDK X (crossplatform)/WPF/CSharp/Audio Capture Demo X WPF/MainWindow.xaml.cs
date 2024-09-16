using VisioForge.Core.UI;

namespace Audio_Capture_Demo_X_WPF
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using VisioForge.Core.Helpers;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.VideoCaptureX;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.UI.WPF.Dialogs.OutputFormats;
    using VisioForge.Core;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.Types.X.VideoCapture;
    using VisioForge.Core.Types.X.AudioRenderers;

    public partial class MainWindow : Window
    {
        private readonly Microsoft.Win32.SaveFileDialog saveFileDialog1 = new Microsoft.Win32.SaveFileDialog();

        private UniversalOutputDialog pcmSettingsDialog;

        private UniversalOutputDialog mp3SettingsDialog;

        private UniversalOutputDialog flacSettingsDialog;

        private UniversalOutputDialog oggVorbisSettingsDialog;

        private UniversalOutputDialog speexSettingsDialog;

        private UniversalOutputDialog m4aSettingsDialog;

        private UniversalOutputDialog wmaSettingsDialog;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        private bool disposedValue;

        private VideoCaptureCoreX VideoCapture1;

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();
        }
           
        private async void Form1_Load(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

            VideoCapture1 = new VideoCaptureCoreX();
            VideoCapture1.OnError += VideoCapture1_OnError;
            VideoCapture1.OnStop += VideoCapture1_OnStop;

            Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";
            cbMode.SelectedIndex = 0;

            // enumerate audio sources
            var audioSources = await DeviceEnumerator.Shared.AudioSourcesAsync();

            foreach (var source in audioSources)
            {
                cbAudioInputDevice.Items.Add(source.DisplayName);

                if (cbAudioInputDevice.Items.Count == 1)
                {
                    cbAudioInputDevice.SelectedIndex = 0;
                }
            }

            // enumerate audio sinks
            var audioSinks = await DeviceEnumerator.Shared.AudioOutputsAsync();
            foreach (var sink in audioSinks)
            {
                cbAudioOutputDevice.Items.Add(sink.DisplayName);

                if (cbAudioOutputDevice.Items.Count == 1)
                {
                    cbAudioOutputDevice.SelectedIndex = 0;
                }

                if (sink.API == AudioOutputDeviceAPI.WASAPI2)
                {
                    cbAudioLoopbackDevice.Items.Add(sink.Name);

                    if (cbAudioLoopbackDevice.Items.Count == 1)
                    {
                        cbAudioLoopbackDevice.SelectedIndex = 0;
                    }
                }
            }

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp3");
        }

        private async void cbAudioInputDevice_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAudioInputDevice.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                cbAudioInputFormat.Items.Clear();

                var deviceItem = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(device => device.DisplayName == e.AddedItems[0].ToString());
                if (deviceItem == null)
                {
                    return;
                }
             
                foreach (var format in deviceItem.Formats)
                {
                    cbAudioInputFormat.Items.Add(format.Name);
                }

                if (cbAudioInputFormat.Items.Count > 0)
                {
                    cbAudioInputFormat.SelectedIndex = 0;
                }
            }
        }

        private void tbAudioVolume_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            VideoCapture1.Audio_OutputDevice_Volume = tbAudioVolume.Value / 100.0;
        }

        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == true)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();

            VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            // audio output
            var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync()).Where(device => device.DisplayName == cbAudioOutputDevice.Text).First();
            VideoCapture1.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);

            // audio input
            IVideoCaptureBaseAudioSourceSettings audioSource = null;
            if (rbSystemAudio.IsChecked == true)
            {
                var deviceItem = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(device => device.DisplayName == cbAudioInputDevice.Text);
                if (deviceItem == null)
                {
                    return;
                }

                AudioCaptureDeviceFormat format = null;
                var formats = deviceItem.Formats.Where(fmt => fmt.Name == cbAudioInputFormat.Text).ToList();
                if (formats.Count > 0)
                {
                    format = formats[0].ToFormat();
                }

                audioSource = deviceItem.CreateSourceSettingsVC(format);
            }
            else
            {
                var deviceItem = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.WASAPI2)).FirstOrDefault(device => device.Name == cbAudioLoopbackDevice.Text);
                if (deviceItem == null)
                {
                    return;
                }

                audioSource = new LoopbackAudioCaptureDeviceSourceSettings(deviceItem);
            }

            VideoCapture1.Audio_Source = audioSource;

            VideoCapture1.Audio_Play = cbPlayAudio.IsChecked == true;
            VideoCapture1.Audio_Record = false;

            VideoCapture1.Outputs_Clear();

            if (cbMode.SelectedIndex == 0)
            {
            }
            else
            {
                VideoCapture1.Audio_Record = true;

                switch (cbOutputFormat.SelectedIndex)
                {
                    case 0:
                        {
                            if (pcmSettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new WAVOutput(edOutput.Text), true);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(pcmSettingsDialog.GetOutputVC(), true);
                            }

                            break;
                        }
                    case 1:
                        {
                            if (mp3SettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new MP3Output(edOutput.Text), true);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(mp3SettingsDialog.GetOutputVC(), true);
                            }

                            break;
                        }
                    case 2:
                        {
                            if (wmaSettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new WMA1Output(edOutput.Text), true);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(wmaSettingsDialog.GetOutputVC(), true);
                            }

                            break;
                        }
                    case 3:
                        {
                            if (oggVorbisSettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new OGGVorbisOutput(edOutput.Text), true);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(oggVorbisSettingsDialog.GetOutputVC(), true);
                            }

                            break;
                        }
                    case 4:
                        {
                            if (flacSettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new FLACOutput(edOutput.Text), true);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(flacSettingsDialog.GetOutputVC(), true);
                            }

                            break;
                        }
                    case 5:
                        {
                            if (speexSettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new SpeexOutput(edOutput.Text), true);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(speexSettingsDialog.GetOutputVC(), true);
                            }

                            break;
                        }
                    case 6:
                        {
                            if (m4aSettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new M4AOutput(edOutput.Text), true);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(m4aSettingsDialog.GetOutputVC(), true);
                            }

                            break;
                        }
                }
            }

            await VideoCapture1.StartAsync();

            tmRecording.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await VideoCapture1.StopAsync();
        }

        private void UpdateRecordingTime()
        {
            var ts = VideoCapture1.Duration();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            Dispatcher.BeginInvoke((Action)(() =>
            {
                lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
            }));
        }

        private void llVideoTutorials_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private void Log(string txt)
        {
            Dispatcher.Invoke((Action)(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; }));
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private void btOutputConfigure_Click(object sender, RoutedEventArgs e)
        {
            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    {
                        WAVOutput wav;
                        if (pcmSettingsDialog == null)
                        {
                            wav = new WAVOutput(edOutput.Text);
                        }
                        else
                        {
                            wav = (WAVOutput)pcmSettingsDialog.GetOutput();
                        }

                        pcmSettingsDialog = new UniversalOutputDialog(wav);
                        pcmSettingsDialog.ShowDialog();

                        break;
                    }
                case 1:
                    {
                        MP3Output mp3;
                        if (mp3SettingsDialog == null)
                        {
                            mp3 = new MP3Output(edOutput.Text);
                        }
                        else
                        {
                            mp3 = (MP3Output)mp3SettingsDialog.GetOutput();
                        }

                        mp3SettingsDialog = new UniversalOutputDialog(mp3);
                        mp3SettingsDialog.ShowDialog();

                        break;
                    }
                case 2:
                    {
                        WMA1Output wma1;
                        if (wmaSettingsDialog == null)
                        {
                            wma1 = new WMA1Output(edOutput.Text);
                        }
                        else
                        {
                            wma1 = (WMA1Output)wmaSettingsDialog.GetOutput();
                        }

                        wmaSettingsDialog = new UniversalOutputDialog(wma1);
                        wmaSettingsDialog.ShowDialog();

                        break;
                    }
                case 3:
                    {
                        OGGVorbisOutput vorbis;
                        if (oggVorbisSettingsDialog == null)
                        {
                            vorbis = new OGGVorbisOutput(edOutput.Text);
                        }
                        else
                        {
                            vorbis = (OGGVorbisOutput)oggVorbisSettingsDialog.GetOutput();
                        }

                        oggVorbisSettingsDialog = new UniversalOutputDialog(vorbis);
                        oggVorbisSettingsDialog.ShowDialog();

                        break;
                    }
                case 4:
                    {
                        FLACOutput flac;
                        if (flacSettingsDialog == null)
                        {
                            flac = new FLACOutput(edOutput.Text);
                        }
                        else
                        {
                            flac = (FLACOutput)flacSettingsDialog.GetOutput();
                        }

                        flacSettingsDialog = new UniversalOutputDialog(flac);
                        flacSettingsDialog.ShowDialog();

                        break;
                    }
                case 5:
                    {
                        SpeexOutput speex;
                        if (speexSettingsDialog == null)
                        {
                            speex = new SpeexOutput(edOutput.Text);
                        }
                        else
                        {
                            speex = (SpeexOutput)speexSettingsDialog.GetOutput();
                        }

                        speexSettingsDialog = new UniversalOutputDialog(speex);
                        speexSettingsDialog.ShowDialog();

                        break;
                    }
                case 6:
                    {
                        M4AOutput m4a;
                        if (m4aSettingsDialog == null)
                        {
                            m4a = new M4AOutput(edOutput.Text);
                        }
                        else
                        {
                            m4a = (M4AOutput)m4aSettingsDialog.GetOutput();
                        }

                        m4aSettingsDialog = new UniversalOutputDialog(m4a);
                        m4aSettingsDialog.ShowDialog();

                        break;
                    }
            }
        }

        private void cbOutputFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (edOutput == null)
            {
                return;
            }

            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wav");
                        break;
                    }
                case 1:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp3");
                        break;
                    }
                case 2:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wma");
                        break;
                    }
                case 3:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg"); //-V3139
                        break;
                    }
                case 4:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".flac");
                        break;
                    }
                case 5:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg");
                        break;
                    }
                case 6:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".m4a");
                        break;
                    }
            }
        }

        private void VideoCapture1_OnStop(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                lbTimestamp.Text = "Recording time: 00:00:00";
            }));
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (VideoCapture1 != null)
            {
                await VideoCapture1.DisposeAsync();
                VideoCapture1 = null;
            }

            VisioForgeX.DestroySDK();
        }
    }
}

// ReSharper restore InconsistentNaming