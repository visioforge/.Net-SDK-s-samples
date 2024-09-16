// ReSharper disable StyleCop.SA1600
// ReSharper disable UseObjectOrCollectionInitializer

using System.Linq;

namespace Main_Demo
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;
    using VisioForge.Core.MediaInfoReaderX;
    using VisioForge.Core.MediaPlayerX;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X;
    using VisioForge.Core.Types.X.AudioEffects;
    using VisioForge.Core.Types.X.VideoEffects;
    using VisioForge.Core.Types.VideoProcessing;
    using FontStyle = VisioForge.Core.Types.X.VideoEffects.FontStyle;
    using VisioForge.Core.Helpers;
    using VisioForge.Core.Types.X.MediaPlayer;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.Types.X.Output;
    using System.Threading.Tasks;
    using VisioForge.Core;
    using VisioForge.Core.Types.X.AudioRenderers;

    public partial class Form1 : Form
    {
        private MediaPlayerCoreX _player;

        private volatile bool _closing;

        public Form1()
        {
            InitializeComponent();
        }

        private void AudioEffectUpdateAmplify()
        {
            if (cbAudAmplifyEnabled.Checked)
            {
                var amplify = new AmplifyAudioEffect(tbAudAmplifyAmp.Value / 100.0);
                _player.Audio_Effects_AddOrUpdate(amplify);
            }
        }

        private void AudioEffectUpdateBalance()
        {
            if (cbAudBalanceEnabled.Checked)
            {
                var balance = new BalanceAudioEffect(tbAudBalanceLevel.Value / 10.0);
                _player.Audio_Effects_AddOrUpdate(balance);
            }
        }

        private void AudioEffectUpdateEcho()
        {
            if (cbAudEchoEnabled.Checked)
            {
                var echo = new EchoAudioEffect(TimeSpan.FromMilliseconds(tbAudEchoDelay.Value))
                {
                    Intensity = this.tbAudEchoIntensity.Value / 100.0f,
                    Feedback = this.tbAudEchoFeedback.Value / 100.0f
                };

                _player.Audio_Effects_AddOrUpdate(echo);
            }
        }

        private void AudioEffectUpdateEqualizer()
        {
            if (cbAudEqualizerEnabled.Checked)
            {
                var levels = new double[10];
                levels[0] = tbAudEq0.Value;
                levels[1] = tbAudEq1.Value;
                levels[2] = tbAudEq2.Value;
                levels[3] = tbAudEq3.Value;
                levels[4] = tbAudEq4.Value;
                levels[5] = tbAudEq5.Value;
                levels[6] = tbAudEq6.Value;
                levels[7] = tbAudEq7.Value;
                levels[8] = tbAudEq8.Value;
                levels[9] = tbAudEq9.Value;

                var eq = new Equalizer10AudioEffect(levels);
                _player.Audio_Effects_AddOrUpdate(eq);
            }
        }

        private void AddAudioEffects()
        {
            _player.Audio_Effects_Clear();

            AudioEffectUpdateAmplify();
            AudioEffectUpdateBalance();
            AudioEffectUpdateEcho();
            AudioEffectUpdateEqualizer();
        }

        private async Task AddVideoEffectsAsync()
        {
            if (cbResizeEnabled.Checked)
            {
                var resize = new ResizeVideoEffect(
                    Convert.ToInt32(edResizeWidth.Text),
                    Convert.ToInt32(edResizeHeight.Text))
                {
                    Letterbox = cbResizeLetterbox.Checked,
                    Method = (VideoScaleMethod)cbResizeMethod.SelectedIndex
                };

                await _player.Video_Effects_AddOrUpdateAsync(resize);
            }

            if (cbDeinterlaceEnabled.Checked)
            {
                await UpdateDeinterlaceAsync();
            }

            if (cbVideoBalanceEnabled.Checked)
            {
                await UpdateColorBalanceAsync();
            }

            if (cbColorEffectEnabled.Checked)
            {
                await UpdateColorEffectAsync();
            }

            if (cbFlipRotateEnabled.Checked)
            {
                await UpdateFlipRotateAsync();
            }

            if (cbGaussianBlurEnabled.Checked)
            {
                await UpdateGaussianBlurAsync();
            }

            if (cbFishEyeEnabled.Checked)
            {
                var fishEye = new FishEyeVideoEffect();
                await _player.Video_Effects_AddOrUpdateAsync(fishEye);
            }

            if (cbTextOverlayEnabled.Checked)
            {
                await UpdateTextOverlayAsync();
            }

            if (cbImageOverlayEnabled.Checked)
            {
                await UpdateImageOverlayAsync();
            }
        }

        private async Task UpdateImageOverlayAsync()
        {
            if (cbImageOverlayEnabled.Checked)
            {
                var filename = edImageOverlayFilename.Text;
                if (!File.Exists(filename))
                {
                    MessageBox.Show(this, "Image logo file not found.");
                    return;
                }

                var imageOverlay = new ImageOverlayVideoEffect(filename)
                {
                    Alpha = tbImageOverlayAlpha.Value / 100.0,
                    X = Convert.ToInt32(edImageOverlayX.Text),
                    Y = Convert.ToInt32(edImageOverlayY.Text)
                };

                var bmp = new Bitmap(filename);
                imageOverlay.Width = bmp.Width;
                imageOverlay.Height = bmp.Height;
                bmp.Dispose();

                await _player.Video_Effects_AddOrUpdateAsync(imageOverlay);
            }
            else
            {
                await _player.Video_Effects_RemoveAsync(ImageOverlayVideoEffect.DefaultName);
            }
        }

        private async Task UpdateGaussianBlurAsync()
        {
            if (cbGaussianBlurEnabled.Checked)
            {
                var blur = new GaussianBlurVideoEffect(tbGaussianBlur.Value / 10.0);
                await _player.Video_Effects_AddOrUpdateAsync(blur);
            }
        }

        private async Task UpdateColorBalanceAsync()
        {
            if (cbVideoBalanceEnabled.Checked)
            {
                var colorBalance = new VideoBalanceVideoEffect
                {
                    Brightness = tbVideoBrightness.Value / 100.0,
                    Contrast = tbVideoContrast.Value / 100.0,
                    Saturation = tbVideoSaturation.Value / 100.0,
                    Hue = tbVideoHue.Value / 100.0
                };

                await _player.Video_Effects_AddOrUpdateAsync(colorBalance);
            }
        }

        private async Task UpdateColorEffectAsync()
        {
            if (cbColorEffectEnabled.Checked)
            {
                var colorEffect = new ColorEffectsVideoEffect((ColorEffectsPreset)cbColorEffect.SelectedIndex);
                await _player.Video_Effects_AddOrUpdateAsync(colorEffect);
            }
        }

        private async Task UpdateFlipRotateAsync()
        {
            if (cbFlipRotateEnabled.Checked)
            {
                var flipRotate = new FlipRotateVideoEffect((VideoFlipRotateMethod)cbFlipRotate.SelectedIndex);
                await _player.Video_Effects_AddOrUpdateAsync(flipRotate);
            }
        }

        private async Task UpdateDeinterlaceAsync()
        {
            if (cbDeinterlaceEnabled.Checked)
            {
                var deinterlace = new DeinterlaceVideoEffect
                {
                    DropOrphans = cbDeinterlaceDropOrphans.Checked,
                    IgnoreObscure = cbDeinterlaceIgnoreObscure.Checked,
                    FieldLayout = (DeinterlaceFieldLayout)cbDeinterlaceFieldLayout.SelectedIndex,
                    Fields = (DeinterlaceFields)cbDeinterlaceFields.SelectedIndex,
                    Locking = (DeinterlaceLocking)cbDeinterlaceLocking.SelectedIndex,
                    Method = (DeinterlaceMethods)cbDeinterlaceMethod.SelectedIndex,
                    Mode = (DeinterlaceMode)cbDeinterlaceMode.SelectedIndex
                };

                await _player.Video_Effects_AddOrUpdateAsync(deinterlace);
            }
        }

        private async Task UpdateTextOverlayAsync()
        {
            if (cbTextOverlayEnabled.Checked)
            {
                var textOverlay = new TextOverlayVideoEffect
                {
                    Mode = (TextOverlayMode)cbTextOverlayMode.SelectedIndex,
                    Text = edTextOverlayText.Text,
                    VerticalAlignment = (TextOverlayVAlign)cbTextOverlayVAlign.SelectedIndex,
                    LineAignment = (TextOverlayLineAlign)cbTextOverlayLineAlign.SelectedIndex,
                    WrapMode = (TextOverlayWrapMode)(cbTextOverlayFontWrapMode.SelectedIndex - 1),
                    AutoAjustSize = cbTextOverlayAutosize.Checked,
                    Color = pnTextOverlayColor.BackColor.ToSKColor(),
                    XPos = tbTextOverlayX.Value / 100.0,
                    YPos = tbTextOverlayY.Value / 100.0
                };

                textOverlay.Font = new FontSettings(cbTextOverlayFontName.Text, cbTextOverlayFontFace.Text, Convert.ToInt32(cbTextOverlayFontSize.Text));

                switch (cbTextOverlayHAlign.SelectedIndex)
                {
                    case 0:
                    case 1:
                    case 2:
                        textOverlay.HorizontalAlignment = (TextOverlayHAlign)cbTextOverlayHAlign.SelectedIndex;
                        break;
                    default:
                        textOverlay.HorizontalAlignment = TextOverlayHAlign.Custom;
                        break;
                }

                textOverlay.TimeFormat = "%H:%M";

                await _player.Video_Effects_AddOrUpdateAsync(textOverlay);
            }
            else
            {
                await _player.Video_Effects_RemoveAsync(TextOverlayVideoEffect.DefaultName);
            }
        }

        private void AddMotionDetection()
        {
            _player.OnMotionDetection -= _player_OnMotionDetection;

            if (cbMotionDetection.Checked)
            {
                _player.OnMotionDetection += _player_OnMotionDetection;

                _player.Motion_Detection = new MotionDetectionExSettings
                {
                    ProcessorType = (MotionProcessorType)rbMotionDetectionProcessor.SelectedIndex,
                    DetectorType = (MotionDetectorType)rbMotionDetectionDetector.SelectedIndex
                };
            }
            else
            {
                _player.Motion_Detection = null;
            }
        }

        private void AddBarcodeReader()
        {
            _player.OnBarcodeDetected -= _player_OnBarcodeDetected;

            if (cbBarcodeDetectionEnabled.Checked)
            {
                _player.Barcode_Reader = new BarcodeReaderSettings
                {
                    Enabled = cbBarcodeDetectionEnabled.Checked,
                    Type = (BarcodeType)cbBarcodeType.SelectedIndex
                };

                _player.OnBarcodeDetected += _player_OnBarcodeDetected;
            }
            else
            {
                _player.Barcode_Reader = null;
            }
        }

        private void _player_OnMotionDetection(object sender, MotionDetectionExEventArgs e)
        {
            Invoke((Action)(() =>
            {
                pbAFMotionLevel.Value = (int)(e.Level * 100);
            }));
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmLog.Text = "";

            tbSpeed.Value = 10;
            _player.Debug_Mode = cbDebugMode.Checked;
            _player.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _player.Audio_Play = cbPlayAudio.Checked;
            var audioOutputDevice = (await _player.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound)).FirstOrDefault(device => device.Name == cbAudioOutputDevice.Text);
            _player.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);
            _player.Subtitles_Enabled = cbSubtitlesEnabled.Checked;
            _player.Snapshot_Grabber_Enabled = true;

            AddAudioEffects();
            await AddVideoEffectsAsync();
            AddMotionDetection();
            AddBarcodeReader();

            string source = edFilenameOrURL.Text;
            if (source.Contains("rtsp://"))
            {
                var rtspSource = await RTSPSourceSettings.CreateAsync(new Uri(source), edRTSPUserName.Text, edRTSPPassword.Text, true);
                rtspSource.Latency = TimeSpan.FromMilliseconds(tbRTSPLatency.Value);
                rtspSource.RTPBlockSize = tbRTSPRTPBlockSize.Value * 1024;
                rtspSource.UDPBufferSize = tbRTSPUDPBufferSize.Value * 1024;

                switch (cbRTSPProtocol.SelectedIndex)
                {
                    case 0: break;
                    case 1:
                        rtspSource.AllowedProtocols = RTSPSourceProtocol.TCP;
                        break;
                    case 2:
                        rtspSource.AllowedProtocols = RTSPSourceProtocol.UDP;
                        break;
                    case 3:
                        rtspSource.AllowedProtocols = RTSPSourceProtocol.HTTP;
                        break;
                }

                await _player.OpenAsync(rtspSource);
            }
            else
            {
                var uniSource = await UniversalSourceSettings.CreateAsync(new Uri(source));
                await _player.OpenAsync(uniSource);
            }

            await _player.PlayAsync();

            tmPosition.Start();
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            if (_player == null)
            {
                _player = new MediaPlayerCoreX(videoView1);
                _player.OnStop += _player_OnStop;
                _player.OnAudioVUMeter += _player_OnAudioVUMeter;
                _player.OnError += _player_OnError;
                _player.OnStreamsInfoAvailable += _player_OnStreamsInfoAvailable;

                foreach (var font in _player.Fonts)
                {
                    cbTextOverlayFontName.Items.Add(font.Name);
                }

                if (cbTextOverlayFontName.Items.Count > 0)
                {
                    cbTextOverlayFontName.SelectedIndex = 0;
                }

                foreach (var item in await _player.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound))
                {
                    cbAudioOutputDevice.Items.Add(item.Name);
                }

                if (cbAudioOutputDevice.Items.Count > 0)
                {
                    cbAudioOutputDevice.SelectedIndex = 0;
                }
            }
        }

        private void _player_OnBarcodeDetected(object sender, BarcodeEventArgs e)
        {
            e.DetectorEnabled = false;

            Invoke((Action)(() =>
            {
                edBarcode.Text = e.Value;
                edBarcodeMetadata.Text = string.Empty;
                foreach (var o in e.Metadata)
                {
                    edBarcodeMetadata.Text += o.Key + ": " + o.Value + Environment.NewLine;
                }
            }));
        }

        private void _player_OnStreamsInfoAvailable(object sender, EventArgs e)
        {
            Invoke(
                (Action)(() =>
                {
                    cbAudioStream.Items.Clear();
                    foreach (var item in _player.Audio_Streams)
                    {
                        cbAudioStream.Items.Add(item);
                    }

                    if (cbAudioStream.Items.Count > 0)
                    {
                        cbAudioStream.Tag = 1;
                        cbAudioStream.SelectedIndex = 0;
                        cbAudioStream.Tag = null;
                    }
                }
                ));
        }

        private void _player_OnAudioVUMeter(object sender, VUMeterXEventArgs e)
        {
            Invoke((Action)(() =>
            {
                volumeMeter1.Amplitude = (float)e.MeterData.Peak[0];

                if (e.MeterData.ChannelsCount > 1)
                {
                    volumeMeter2.Amplitude = (float)e.MeterData.Peak[1];
                }
            }));
        }

        private void _player_OnError(object sender, ErrorsEventArgs e)
        {
            BeginInvoke((Action)(() =>
           {
               mmLog.Text += e.Message + Environment.NewLine;
           }));
        }

        private void _player_OnStop(object sender, StopEventArgs e)
        {
            tmPosition.Stop();

            if (_closing)
            {
                return;
            }

            videoView1.Invalidate();

            Invoke((Action)(() =>
            {
                MessageBox.Show(this, "Playback complete.");
            }));
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await _player.PauseAsync();
        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            await _player.ResumeAsync();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            tmPosition.Stop();

            await _player.StopAsync();

            _player.Video_Effects_Clear();

            videoView1.Invalidate();

            volumeMeter1.Clear();
            volumeMeter2.Clear();
        }

        private async void tmPosition_Tick(object sender, EventArgs e)
        {
            var position = await _player.Position_GetAsync();
            var duration = await _player.DurationAsync();

            tbTimeline.Maximum = (int)duration.TotalSeconds;

            lbTimeline.Text = position.ToString("hh\\:mm\\:ss") + " | " + duration.ToString("hh\\:mm\\:ss");

            if (tbTimeline.Maximum >= position.TotalSeconds)
            {
                tbTimeline.Value = (int)position.TotalSeconds;
            }
        }

        private void tbTimeline_Scroll(object sender, EventArgs e)
        {
            _player.Position_Set(TimeSpan.FromSeconds(tbTimeline.Value));
        }

        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilenameOrURL.Text = openFileDialog1.FileName;
            }
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            var speed = tbSpeed.Value / 10.0;
            if (_player.Rate_Set(speed))
            {
                lbSpeed.Text = $"Speed: {speed:F1}";
            }
        }

        private void btNextFrame_Click(object sender, EventArgs e)
        {
            _player.NextFrame(1);

            tbSpeed.Value = (int)(_player.Rate_Get() * 10);
            var speed = tbSpeed.Value / 10.0;
            lbSpeed.Text = $"Speed: {speed:F1}";
        }

        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            _player.Audio_OutputDevice_Volume = tbVolume1.Value / 100.0;
        }

        private void tbAudAmplifyAmp_Scroll(object sender, EventArgs e)
        {
            AudioEffectUpdateAmplify();
        }

        private void tbAudBalanceLevel_Scroll(object sender, EventArgs e)
        {
            AudioEffectUpdateBalance();
        }

        private void tbAudEchoDelay_Scroll(object sender, EventArgs e)
        {
            lbAudEchoDelay.Text = tbAudEchoDelay.Value.ToString();
            AudioEffectUpdateEcho();
        }

        private void tbAudEchoIntensity_Scroll(object sender, EventArgs e)
        {
            lbAudEchoIntensity.Text = (tbAudEchoIntensity.Value / 100.0).ToString("F2");
            AudioEffectUpdateEcho();
        }

        private void tbAudEchoFeedback_Scroll(object sender, EventArgs e)
        {
            lbAudEchoFeedback.Text = (tbAudEchoFeedback.Value / 100.0).ToString("F2");
            AudioEffectUpdateEcho();
        }

        private void btAudEqUpdate_Click(object sender, EventArgs e)
        {
            AudioEffectUpdateEqualizer();
        }

        private async void tbVideoBrightness_Scroll(object sender, EventArgs e)
        {
            await UpdateColorBalanceAsync();
        }

        private async void tbVideoSaturation_Scroll(object sender, EventArgs e)
        {
            await UpdateColorBalanceAsync();
        }

        private async void tbVideoContrast_Scroll(object sender, EventArgs e)
        {
            await UpdateColorBalanceAsync();
        }

        private async void tbVideoHue_Scroll(object sender, EventArgs e)
        {
            await UpdateColorBalanceAsync();
        }

        private async void cbColorEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            await UpdateColorEffectAsync();
        }

        private async void cbFlipRotate_SelectedIndexChanged(object sender, EventArgs e)
        {
            await UpdateFlipRotateAsync();
        }

        private async void tbGaussianBlur_Scroll(object sender, EventArgs e)
        {
            await UpdateGaussianBlurAsync();
        }

        private async void btTextOverlayUpdate_Click(object sender, EventArgs e)
        {
            await UpdateTextOverlayAsync();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // We have to initialize the engine on start
            Text += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            cbBarcodeType.SelectedIndex = 0;
            cbResizeMethod.SelectedIndex = 0;
            cbColorEffect.SelectedIndex = 0;
            cbFlipRotate.SelectedIndex = 0;

            cbDeinterlaceLocking.SelectedIndex = 0;
            cbDeinterlaceMode.SelectedIndex = 0;
            cbDeinterlaceFieldLayout.SelectedIndex = 0;
            cbDeinterlaceFields.SelectedIndex = 3;
            cbDeinterlaceMethod.SelectedIndex = 4;

            cbTextOverlayFontWrapMode.SelectedIndex = 0;
            cbTextOverlayFontFace.SelectedIndex = 0;
            cbTextOverlayHAlign.SelectedIndex = 0;
            cbTextOverlayVAlign.SelectedIndex = 0;
            cbTextOverlayLineAlign.SelectedIndex = 0;
            cbTextOverlayMode.SelectedIndex = 0;
            cbTextOverlayFontSize.SelectedIndex = 14;

            cbRTSPProtocol.SelectedIndex = 0;
            rbMotionDetectionProcessor.SelectedIndex = 1;
            rbMotionDetectionDetector.SelectedIndex = 1;
        }

        private void pnTextOverlayColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnTextOverlayColor.BackColor = colorDialog1.Color;
            }
        }

        private void tbRTSPRTPBlockSize_Scroll(object sender, EventArgs e)
        {
            lbRTSPRTPBlockSize.Text = tbRTSPRTPBlockSize.Value.ToString();
        }

        private void tbRTSPUDPBufferSize_Scroll(object sender, EventArgs e)
        {
            lbRTSPUDPBufferSize.Text = tbRTSPUDPBufferSize.Value.ToString();
        }

        private void tbRTSPLatency_Scroll(object sender, EventArgs e)
        {
            lbRTSPLatency.Text = tbRTSPLatency.Value.ToString();
        }

        private void btReadTags_Click(object sender, EventArgs e)
        {
            var tags = _player.Tags_Read(edFilenameOrURL.Text);

            mmInfo.Text = tags?.ToString();
        }

        private async void btReadInfo_Click(object sender, EventArgs e)
        {
            var infoReader = new MediaInfoReaderX(_player);
            if (await infoReader.OpenAsync(new Uri(edFilenameOrURL.Text)))
            {
                if (infoReader.Info.VideoStreams.Count > 0)
                {
                    mmInfo.Text += "Video streams" + Environment.NewLine;
                    foreach (var video in infoReader.Info.VideoStreams)
                    {
                        mmInfo.Text += $"{video.Width}x{video.Height}, {video.FrameRate:F2} fps, Duration: {video.Duration.ToString()}" + Environment.NewLine;
                    }
                }

                if (infoReader.Info.AudioStreams.Any())
                {
                    mmInfo.Text += "Audio streams" + Environment.NewLine;
                    foreach (var audio in infoReader.Info.AudioStreams)
                    {
                        mmInfo.Text += $"{audio.SampleRate} Hz, {audio.Channels} channels, Duration: {audio.Duration.ToString()}" + Environment.NewLine;
                    }
                }
            }
        }

        private async void btSaveSnapshot_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.FileName = "snap.jpg";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    await _player.Snapshot_SaveAsync(dlg.FileName, SkiaSharp.SKEncodedImageFormat.Jpeg);
                }
            }
        }

        private void cbAudioStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_player.State == PlaybackState.Play && cbAudioStream.Tag == null)
            {
                _player.Audio_Stream_Select(_player.Audio_Streams[cbAudioStream.SelectedIndex]);
            }
        }

        private void cbSubtitlesCustomSettings_CheckedChanged(object sender, EventArgs e)
        {
            var fontSize = Convert.ToInt32(cbTextOverlayFontSize.Text);
            var fontFace = cbTextOverlayFontFace.Text;
            var fontName = cbTextOverlayFontName.Text;
            _player.Subtitles_Settings.Font = new FontSettings(fontName, fontFace, fontSize);

            _player.Subtitles_Settings_Update();
        }

        private void cbSubtitlesEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _player.Subtitles_Settings.Visible = cbSubtitlesEnabled.Checked;

            _player.Subtitles_Settings_Update();
        }

        private void btImageOverlayOpen_Click(object sender, EventArgs e)
        {
            if (dlgOpenImage.ShowDialog(this) == DialogResult.OK)
            {
                edImageOverlayFilename.Text = dlgOpenImage.FileName;
            }
        }

        private void btPrevFrame_Click(object sender, EventArgs e)
        {
            _player.PrevFrame(1);

            tbSpeed.Value = (int)(_player.Rate_Get() * 10);
            var speed = tbSpeed.Value / 10.0;
            lbSpeed.Text = $"Speed: {speed:F1}";
        }

        private async void cbImageOverlayEnabled_Click(object sender, EventArgs e)
        {
            await UpdateImageOverlayAsync();
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _closing = true;

            await _player.StopAsync();
            await _player.DisposeAsync();

            VisioForgeX.DestroySDK();
        }

        private void cbTextOverlayFontName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var font = _player.Fonts.FirstOrDefault(f => f.Name == cbTextOverlayFontName.Text);
            if (font != null)
            {
                cbTextOverlayFontFace.Items.Clear();
                foreach (var face in font.Faces)
                {
                    cbTextOverlayFontFace.Items.Add(face);
                }

                if (cbTextOverlayFontFace.Items.Count > 0)
                {
                    cbTextOverlayFontFace.SelectedIndex = 0;
                }
            }
        }
    }
}
