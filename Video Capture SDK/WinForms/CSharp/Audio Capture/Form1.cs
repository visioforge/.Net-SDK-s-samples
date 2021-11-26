// ReSharper disable InconsistentNaming
// ReSharper disable StyleCop.SA1600
// ReSharper disable UseObjectOrCollectionInitializer
// ReSharper disable StyleCop.SA1601

using VisioForge.Core.UI;
using VisioForge.Core.UI.WinForms.Dialogs.OutputFormats;
using VisioForge.Core.VideoCapture;
using VisioForge.MediaFramework;

namespace VisioForge_SDK_4_Audio_Capture_CSharp
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using VisioForge.Core;
    using VisioForge.Types;
    using VisioForge.Types.AudioEffects;
    using VisioForge.Types.Events;
    using VisioForge.Types.Output;
    using VisioForge.Types.VideoCapture;

    public partial class Form1 : Form
    {
        private const string AUDIO_EFFECT_ID_AMPLIFY = "amplify";

        private const string AUDIO_EFFECT_ID_EQ = "eq";

        private const string AUDIO_EFFECT_ID_SOUND_3D = "sound3d";

        private const string AUDIO_EFFECT_ID_TRUE_BASS = "true_bass";

        private PCMSettingsDialog pcmSettingsDialog;

        private MP3SettingsDialog mp3SettingsDialog;

        private FLACSettingsDialog flacSettingsDialog;
        
        private OggVorbisSettingsDialog oggVorbisSettingsDialog;

        private SpeexSettingsDialog speexSettingsDialog;

        private M4ASettingsDialog m4aSettingsDialog;

        private WMVSettingsDialog wmvSettingsDialog;

        private VideoCaptureCore VideoCapture1;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        public Form1()
        {
            VideoCapture1 = new VideoCaptureCore();
            VideoCapture1.OnError += VideoCapture1_OnError;
            VideoCapture1.OnLicenseRequired += VideoCapture1_OnLicenseRequired;
            VideoCapture1.OnStop += VideoCapture1_OnStop;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += $" (SDK v{VideoCapture1.SDK_Version})";
            cbMode.SelectedIndex = 0;

            tmRecording.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime();
            };

            foreach (var device in VideoCapture1.Audio_CaptureDevices)
            {
                cbAudioInputDevice.Items.Add(device.Name);
            }

            if (cbAudioInputDevice.Items.Count > 0)
            {
                cbAudioInputDevice.SelectedIndex = 0;
                cbAudioInputDevice_SelectedIndexChanged(null, null);
            }

            cbAudioInputLine.Items.Clear();

            if (!string.IsNullOrEmpty(cbAudioInputDevice.Text))
            {
                var deviceItem = VideoCapture1.Audio_CaptureDevices.FirstOrDefault(device => device.Name == cbAudioInputDevice.Text);
                if (deviceItem != null)
                {
                    foreach (string line in deviceItem.Lines)
                    {
                        cbAudioInputLine.Items.Add(line);
                    }
                }
            }

            if (cbAudioInputLine.Items.Count > 0)
            {
                cbAudioInputLine.SelectedIndex = 0;
            }

            string defaultAudioRenderer = string.Empty;
            foreach (string audioOutputDevice in VideoCapture1.Audio_OutputDevices)
            {
                cbAudioOutputDevice.Items.Add(audioOutputDevice);

                if (audioOutputDevice.Contains("Default DirectSound Device"))
                {
                    defaultAudioRenderer = audioOutputDevice;
                }
            }

            if (cbAudioOutputDevice.Items.Count > 0)
            {
                if (string.IsNullOrEmpty(defaultAudioRenderer))
                {
                    cbAudioOutputDevice.SelectedIndex = 0;
                }
                else
                {
                    cbAudioOutputDevice.Text = defaultAudioRenderer;
                }

                cbAudioOutputDevice_SelectedIndexChanged(null, null);
            }

            foreach (string preset in VideoCapture1.Audio_Effects_Equalizer_Presets())
            {
                cbAudEqualizerPreset.Items.Add(preset);
            }

            cbOutputFormat.SelectedIndex = 1;
            cbAudEqualizerPreset.SelectedIndex = 0;
            cbAudEqualizerPreset_SelectedIndexChanged(null, null);

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp3");
        }

        private void cbAudioInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAudioInputDevice.SelectedIndex != -1)
            {
                cbAudioInputFormat.Items.Clear();

                var deviceItem = VideoCapture1.Audio_CaptureDevices.FirstOrDefault(device => device.Name == cbAudioInputDevice.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var defaultValue = "PCM, 44100 Hz, 16 Bits, 2 Channels";
                var defaultValueExists = false;
                foreach (string format in deviceItem.Formats)
                {
                    cbAudioInputFormat.Items.Add(format);

                    if (defaultValue == format)
                    {
                        defaultValueExists = true;
                    }
                }

                if (cbAudioInputFormat.Items.Count > 0)
                {
                    cbAudioInputFormat.SelectedIndex = 0;

                    if (defaultValueExists)
                    {
                        cbAudioInputFormat.Text = defaultValue;
                    }
                }

                cbAudioInputLine.Items.Clear();

                foreach (string line in deviceItem.Lines)
                {
                    cbAudioInputLine.Items.Add(line);
                }

                if (cbAudioInputLine.Items.Count > 0)
                {
                    cbAudioInputLine.SelectedIndex = 0;
                }

                btAudioInputDeviceSettings.Enabled = deviceItem.DialogDefault;
            }
        }

        private void btAudioInputDeviceSettings_Click(object sender, EventArgs e)
        {
            VideoCapture1.Audio_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbAudioInputDevice.Text);
        }      

        private void cbUseBestAudioInputFormat_CheckedChanged(object sender, EventArgs e)
        {
            cbAudioInputFormat.Enabled = !cbUseBestAudioInputFormat.Checked;
        }

        private void cbAudioOutputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.Text;
        }

        private void tbAudioVolume_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_OutputDevice_Volume_Set(tbAudioVolume.Value);
        }

        private void tbAudioBalance_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_OutputDevice_Balance_Set(tbAudioBalance.Value);
            VideoCapture1.Audio_OutputDevice_Balance_Get();
        }

        private void cbAudAmplifyEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.Checked);
        }

        private void tbAudAmplifyAmp_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Amplify(-1, AUDIO_EFFECT_ID_AMPLIFY, tbAudAmplifyAmp.Value * 10, false);
        }

        private void cbAudEqualizerEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.Checked);
        }

        private void tbAudEq0_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 0, (sbyte)tbAudEq0.Value);
        }

        private void tbAudEq1_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 1, (sbyte)tbAudEq1.Value);
        }

        private void tbAudEq2_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 2, (sbyte)tbAudEq2.Value);
        }

        private void tbAudEq3_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 3, (sbyte)tbAudEq3.Value);
        }

        private void tbAudEq4_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 4, (sbyte)tbAudEq4.Value);
        }

        private void tbAudEq5_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 5, (sbyte)tbAudEq5.Value);
        }

        private void tbAudEq6_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 6, (sbyte)tbAudEq6.Value);
        }

        private void tbAudEq7_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 7, (sbyte)tbAudEq7.Value);
        }

        private void tbAudEq8_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 8, (sbyte)tbAudEq8.Value);
        }

        private void tbAudEq9_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 9, (sbyte)tbAudEq9.Value);
        }

        private void cbAudEqualizerPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Preset_Set(-1, AUDIO_EFFECT_ID_EQ, (EqualizerPreset)cbAudEqualizerPreset.SelectedIndex);
            btAudEqRefresh_Click(sender, e);
        }

        private void btAudEqRefresh_Click(object sender, EventArgs e)
        {
            tbAudEq0.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 0);
            tbAudEq1.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 1);
            tbAudEq2.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 2);
            tbAudEq3.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 3);
            tbAudEq4.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 4);
            tbAudEq5.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 5);
            tbAudEq6.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 6);
            tbAudEq7.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 7);
            tbAudEq8.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 8);
            tbAudEq9.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 9);
        }

        private void cbAudTrueBassEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.Checked);
        }

        private void tbAudTrueBass_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_TrueBass(-1, AUDIO_EFFECT_ID_TRUE_BASS, 200, false, (ushort)tbAudTrueBass.Value);
        }

        private void cbAudSound3DEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_SOUND_3D, cbAudSound3DEnabled.Checked);
        }

        private void tbAud3DSound_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Sound3D(-1, AUDIO_EFFECT_ID_SOUND_3D, (ushort)tbAud3DSound.Value);
        }

        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        private void SetWMAOutput(ref WMAOutput wmaOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(VideoCapture1);
            }

            wmvSettingsDialog.WMA = true;
            wmvSettingsDialog.SaveSettings(ref wmaOutput);
        }

        private void SetACMOutput(ref ACMOutput acmOutput)
        {
            if (pcmSettingsDialog == null)
            {
                pcmSettingsDialog = new PCMSettingsDialog(VideoCapture1.Audio_Codecs.ToArray());
            }

            pcmSettingsDialog.SaveSettings(ref acmOutput);
        }
        
        private void SetMP3Output(ref MP3Output mp3Output)
        {
            if (mp3SettingsDialog == null)
            {
                mp3SettingsDialog = new MP3SettingsDialog();
            }

            mp3SettingsDialog.SaveSettings(ref mp3Output);
        }
        
        private void SetFLACOutput(ref FLACOutput flacOutput)
        {
            if (flacSettingsDialog == null)
            {
                flacSettingsDialog = new FLACSettingsDialog();
            }

            flacSettingsDialog.SaveSettings(ref flacOutput);
        }

        private void SetSpeexOutput(ref SpeexOutput speexOutput)
        {
            if (speexSettingsDialog == null)
            {
                speexSettingsDialog = new SpeexSettingsDialog();
            }

            speexSettingsDialog.SaveSettings(ref speexOutput);
        }

        public void SetM4AOutput(ref M4AOutput m4aOutput)
        {
            if (m4aSettingsDialog == null)
            {
                m4aSettingsDialog = new M4ASettingsDialog();
            }

            m4aSettingsDialog.SaveSettings(ref m4aOutput);
        }

        private void SetOGGOutput(ref OGGVorbisOutput oggVorbisOutput)
        {
            if (oggVorbisSettingsDialog == null)
            {
                oggVorbisSettingsDialog = new OggVorbisSettingsDialog();
            }

            oggVorbisSettingsDialog.SaveSettings(ref oggVorbisOutput);
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmLog.Clear();

            VideoCapture1.Video_Renderer.Zoom_Ratio = 0;
            VideoCapture1.Video_Renderer.Zoom_ShiftX = 0;
            VideoCapture1.Video_Renderer.Zoom_ShiftY = 0;

            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.Text;

            VideoCapture1.Audio_CaptureDevice = new AudioCaptureSource(cbAudioInputDevice.Text);
            VideoCapture1.Audio_CaptureDevice.Format = cbAudioInputFormat.Text;
            VideoCapture1.Audio_CaptureDevice.Format_UseBest = false;
            VideoCapture1.Audio_CaptureDevice.Line = cbAudioInputLine.Text;

            VideoCapture1.Audio_PlayAudio = cbPlayAudio.Checked;
            VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.None;
           
            if (cbMode.SelectedIndex == 0)
            {
                VideoCapture1.Mode = VideoCaptureMode.AudioPreview;
                VideoCapture1.Audio_RecordAudio = true;
            }
            else
            {
                VideoCapture1.Mode = VideoCaptureMode.AudioCapture;
                VideoCapture1.Audio_RecordAudio = true;
                VideoCapture1.Output_Filename = edOutput.Text;

                switch (cbOutputFormat.SelectedIndex)
                {
                    case 0:
                    {
                        var acmOutput = new ACMOutput();
                        SetACMOutput(ref acmOutput);
                        VideoCapture1.Output_Format = acmOutput;

                        break;
                    }
                    case 1:
                    {
                        var mp3Output = new MP3Output();
                        SetMP3Output(ref mp3Output);
                        VideoCapture1.Output_Format = mp3Output;

                        break;
                    }
                    case 2:
                    {
                        var wmaOutput = new WMAOutput();
                        SetWMAOutput(ref wmaOutput);
                        VideoCapture1.Output_Format = wmaOutput;

                        break;
                    }
                    case 3:
                    {
                        var oggVorbisOutput = new OGGVorbisOutput();
                        SetOGGOutput(ref oggVorbisOutput);
                        VideoCapture1.Output_Format = oggVorbisOutput;

                        break;
                    }
                    case 4:
                    {
                        var flacOutput = new FLACOutput();
                        SetFLACOutput(ref flacOutput);
                        VideoCapture1.Output_Format = flacOutput;

                        break;
                    }
                    case 5:
                    {
                        var speexOutput = new SpeexOutput();
                        SetSpeexOutput(ref speexOutput);
                        VideoCapture1.Output_Format = speexOutput;

                        break;
                    }
                    case 6:
                    {
                        var m4aOutput = new M4AOutput();
                        SetM4AOutput(ref m4aOutput);
                        VideoCapture1.Output_Format = m4aOutput;

                        break;
                    }
                }
            }

            // Audio processing
            VideoCapture1.Audio_Effects_Clear(-1);
            VideoCapture1.Audio_Effects_Enabled = true;

            VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.Amplify, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero);
            VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.Equalizer, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero);
            VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.TrueBass, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero);
            VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.Sound3D, AUDIO_EFFECT_ID_SOUND_3D, cbAudSound3DEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero);
  
            await VideoCapture1.StartAsync();

            tcMain.SelectedIndex = 3;
            tmRecording.Start();
        }
        
        private async void btStop_Click(object sender, EventArgs e)
        {
            tmRecording.Stop();

            await VideoCapture1.StopAsync();
        }

        private void llVideoTutorials_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private void Log(string txt)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; }));
            }
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private void VideoCapture1_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            Log("(NOT ERROR) " + e.Message);
        }

        private void cbOutputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg");
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

        private void btOutputConfigure_Click(object sender, EventArgs e)
        {
            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    {
                        if (pcmSettingsDialog == null)
                        {
                            pcmSettingsDialog = new PCMSettingsDialog(VideoCapture1.Audio_Codecs.ToArray());
                        }

                        pcmSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 1:
                    {
                        if (mp3SettingsDialog == null)
                        {
                            mp3SettingsDialog = new MP3SettingsDialog();
                        }

                        mp3SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 2:
                    {
                        if (wmvSettingsDialog == null)
                        {
                            wmvSettingsDialog = new WMVSettingsDialog(VideoCapture1);
                        }

                        wmvSettingsDialog.WMA = true;
                        wmvSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 3:
                    {
                        if (oggVorbisSettingsDialog == null)
                        {
                            oggVorbisSettingsDialog = new OggVorbisSettingsDialog();
                        }

                        oggVorbisSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 4:
                    {
                        if (flacSettingsDialog == null)
                        {
                            flacSettingsDialog = new FLACSettingsDialog();
                        }

                        flacSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 5:
                    {
                        if (speexSettingsDialog == null)
                        {
                            speexSettingsDialog = new SpeexSettingsDialog();
                        }

                        speexSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 6:
                    {
                        if (m4aSettingsDialog == null)
                        {
                            m4aSettingsDialog = new M4ASettingsDialog();
                        }

                        m4aSettingsDialog.ShowDialog(this);

                        break;
                    }
            }
        }

        private void VideoCapture1_OnStop(object sender, EventArgs e)
        {
            BeginInvoke((Action)(() =>
            {
                lbTimestamp.Text = $"Recording time: 00:00:00";
            }));
        }

        private void UpdateRecordingTime()
        {
            if (IsHandleCreated)
            {
                var timestamp = VideoCapture1.Duration_Time();

                if (Math.Abs(timestamp.TotalMilliseconds) < 0.01)
                {
                    return;
                }

                BeginInvoke(
                    (Action)(() =>
                                    {
                                        lbTimestamp.Text = "Recording time: " + timestamp.ToString(@"hh\:mm\:ss");
                                    }));
            }
        }
    }
}

// ReSharper restore InconsistentNaming