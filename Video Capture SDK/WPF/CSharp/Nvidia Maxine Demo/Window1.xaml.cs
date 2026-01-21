




using System.Globalization;

namespace Nvidia_Maxine_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.VideoCapture;
    using VisioForge.Core.Types.VideoEffects;
    using VisioForge.Core.Types.VideoEffects.NvidiaMaxine;
    using VisioForge.Core.UI;
    using VisioForge.Core.UI.WPF;
    using VisioForge.Core.VideoCapture;

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : IDisposable
    {    
        /// <summary>
        /// The tm recording.
        /// </summary>
        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        /// <summary>
        /// The video capture 1.
        /// </summary>
        private VideoCaptureCore VideoCapture1;

        /// <summary>
        /// The disposed value.
        /// </summary>
        private bool disposedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Create engine async.
        /// </summary>
        private async Task CreateEngineAsync()
        {
            VideoCapture1 = await VideoCaptureCore.CreateAsync(VideoView1);

            VideoCapture1.OnError += VideoCapture1_OnError;
            VideoCapture1.OnVideoFrameBuffer += VideoCapture1_OnVideoFrameBuffer;
        }

        /// <summary>
        /// Video capture 1 on video frame buffer.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="VideoFrameBufferEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnVideoFrameBuffer(object sender, VideoFrameBufferEventArgs e)
        {
            //var videoFrame = new NvidiaMaxine.VideoEffects.VideoFrame(e.Frame, false);
            //if (_videoEffect == null)
            //{
            //    switch (_effectID)
            //    {
            //        case 0:
            //            _videoEffect = null;
            //            break;
            //        case 1:
            //            _videoEffect = new DenoiseEffect(_modelsPath, videoFrame);
            //            break;
            //        case 2:
            //            _videoEffect = new ArtifactReductionEffect(_modelsPath, videoFrame);
            //            break;
            //        case 3:
            //            _videoEffect = new UpscaleEffect(_modelsPath, videoFrame);
            //            break;
            //        case 4:
            //            _videoEffect = new SuperResolutionEffect(_modelsPath, videoFrame);
            //            break;
            //        case 5:
            //            _videoEffect = new AIGSEffect(_modelsPath, videoFrame, _aigsMode);
            //            (_videoEffect as AIGSEffect).BackgroundImage = _aigsBackgroundImage;
            //            break;
            //        default:
            //            throw new ArgumentOutOfRangeException();
            //    }

            //    _videoEffect?.Init(e.Frame.Info.Width, e.Frame.Info.Height);
            //}

            //if (_videoEffect != null)
            //{
            //    var resFrame = _videoEffect.Process();
            //    if (resFrame != null)
            //    {
            //        Dispatcher.Invoke(() =>
            //        {
            //            RenderFrame(resFrame);
            //        });
            //    }
            //}
            //else
            //{
            //    Dispatcher.Invoke(() =>
            //    {
            //        RenderFrame(videoFrame);
            //    });
            //}

            //Dispatcher.Invoke(() =>
            //{
            //    RenderFrame(e.Frame);
            //});
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;
                VideoCapture1.OnVideoFrameBuffer -= VideoCapture1_OnVideoFrameBuffer;

                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }
        }

        /// <summary>
        /// Handles the bt audio input device settings click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btAudioInputDeviceSettings_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Audio_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbAudioInputDevice.Text);
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await CreateEngineAsync();

            Title += $" (SDK v{VideoCapture1.SDK_Version()})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

            foreach (var device in VideoCapture1.Video_CaptureDevices())
            {
                cbVideoInputDevice.Items.Add(device.Name);
            }

            if (cbVideoInputDevice.Items.Count > 0)
            {
                cbVideoInputDevice.SelectedIndex = 0;
            }

            cbVideoInputDevice_SelectionChanged(null, null);

            foreach (var device in VideoCapture1.Audio_CaptureDevices())
            {
                cbAudioInputDevice.Items.Add(device.Name);
            }

            if (cbAudioInputDevice.Items.Count > 0)
            {
                cbAudioInputDevice.SelectedIndex = 0;
                cbAudioInputDevice_SelectionChanged(null, null);
            }

            cbAudioInputLine.Items.Clear();

            if (!string.IsNullOrEmpty(cbAudioInputDevice.Text))
            {
                var deviceItem =
                    VideoCapture1.Audio_CaptureDevices().FirstOrDefault(device => device.Name == cbAudioInputDevice.Text);
                if (deviceItem != null)
                {
                    foreach (var line in deviceItem.Lines)
                    {
                        cbAudioInputLine.Items.Add(line);
                    }

                    if (cbAudioInputLine.Items.Count > 0)
                    {
                        cbAudioInputLine.SelectedIndex = 0;
                    }
                }
            }

            string defaultAudioRenderer = string.Empty;
            foreach (string audioOutputDevice in VideoCapture1.Audio_OutputDevices())
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
            }

            cbVideoEffect.SelectedIndex = 0;
            cbVideoEffect_SelectionChanged(null, null);
        }

        /// <summary>
        /// Cb use best audio input format checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbUseBestAudioInputFormat_Checked(object sender, RoutedEventArgs e)
        {
            cbAudioInputFormat.IsEnabled = cbUseBestAudioInputFormat.IsChecked == false;
        }

        /// <summary>
        /// Cb use best video input format checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbUseBestVideoInputFormat_Checked(object sender, RoutedEventArgs e)
        {
            cbVideoInputFormat.IsEnabled = cbUseBestVideoInputFormat.IsChecked == false;
        }

        /// <summary>
        /// Handles the bt video capture device settings click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btVideoCaptureDeviceSettings_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbVideoInputDevice.Text);
        }

        /// <summary>
        /// Log.
        /// </summary>
        /// <param name="txt">The text.</param>
        private void Log(string txt)
        {
            Dispatcher.Invoke(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; });
        }

        /// <summary>
        /// Video capture 1 on error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        /// <summary>
        /// Tb audio volume value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudioVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1?.Audio_OutputDevice_Volume_Set((int)tbAudioVolume.Value);
        }

        /// <summary>
        /// Tb audio balance value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudioBalance_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_OutputDevice_Balance_Set((int)tbAudioBalance.Value);
        }

        /// <summary>
        /// Lb view video tutorials mouse left button down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void lbViewVideoTutorials_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Cb video input device selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbVideoInputDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbVideoInputDevice.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                cbVideoInputFormat.Items.Clear();

                var deviceItem =
                    VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == e.AddedItems[0].ToString());
                if (deviceItem == null)
                {
                    return;
                }

                foreach (var format in deviceItem.VideoFormats)
                {
                    cbVideoInputFormat.Items.Add(format);
                }

                if (cbVideoInputFormat.Items.Count > 0)
                {
                    cbVideoInputFormat.SelectedIndex = 0;
                    cbVideoInputFormat_SelectionChanged(null, null);
                }

                btVideoCaptureDeviceSettings.IsEnabled = deviceItem.DialogDefault;
            }
        }

        /// <summary>
        /// Cb audio input device selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbAudioInputDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAudioInputDevice.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                cbAudioInputFormat.Items.Clear();

                var deviceItem = VideoCapture1.Audio_CaptureDevices().FirstOrDefault(device => device.Name == e.AddedItems[0].ToString());
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

                foreach (var line in deviceItem.Lines)
                {
                    cbAudioInputLine.Items.Add(line);
                }

                if (cbAudioInputLine.Items.Count > 0)
                {
                    cbAudioInputLine.SelectedIndex = 0;
                }

                btAudioInputDeviceSettings.IsEnabled = deviceItem.DialogDefault;
            }
        }
        
        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();

            VideoCapture1.Video_Sample_Grabber_Enabled = true;

            VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            VideoCapture1.Audio_OutputDevice = "Default DirectSound Device";

            if (cbRecordAudio.IsChecked == true)
            {
                VideoCapture1.Audio_RecordAudio = true;
                VideoCapture1.Audio_PlayAudio = true;
            }
            else
            {
                VideoCapture1.Audio_RecordAudio = false;
                VideoCapture1.Audio_PlayAudio = false;
            }

            VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.Text;

            // apply capture params
            VideoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbVideoInputDevice.Text);
            VideoCapture1.Video_CaptureDevice.Format = cbVideoInputFormat.Text;
            VideoCapture1.Video_CaptureDevice.Format_UseBest = cbUseBestVideoInputFormat.IsChecked == true;

            VideoCapture1.Audio_CaptureDevice = new AudioCaptureSource(cbAudioInputDevice.Text);
            VideoCapture1.Audio_CaptureDevice.Format = cbAudioInputFormat.Text;
            VideoCapture1.Audio_CaptureDevice.Format_UseBest = cbUseBestAudioInputFormat.IsChecked == true;

            if (cbVideoInputFrameRate.SelectedIndex != -1)
            {
                VideoCapture1.Video_CaptureDevice.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoInputFrameRate.Text));
            }
            
            VideoCapture1.Mode = VideoCaptureMode.VideoPreview;

            // add effects
            VideoCapture1.Video_Effects_Clear();
            VideoCapture1.Video_Resize = null;
            VideoCapture1.Video_ResizeOrCrop_Enabled = false;
            
            switch (cbVideoEffect.SelectedIndex)
            {
                case 0:                    
                    break;
                case 1:
                    {
                        var videoEffect = new MaxineDenoiseVideoEffect(
                            edModels.Text, 
                            strength: (float)(slDenoiseStrength.Value / 10.0f));
                        VideoCapture1.Video_Effects_Add(videoEffect);
                    }

                    break;
                case 2:
                    {
                        var videoEffect = new MaxineArtifactReductionVideoEffect(
                            edModels.Text, 
                            mode: (MaxineArtifactReductionEffectMode)cbArtifactReductionMode.SelectedIndex);
                        VideoCapture1.Video_Effects_Add(videoEffect);
                    }

                    break;
                case 3:
                    {
                        VideoCapture1.Video_Resize = new MaxineUpscaleSettings(
                            edModels.Text, 
                            height: Convert.ToInt32(edUpscaleHeight.Text),
                            strength: (float)(slUpscaleStrength.Value / 10.0f));
                        VideoCapture1.Video_ResizeOrCrop_Enabled = true;
                    }

                    break;
                case 4:
                    VideoCapture1.Video_Resize = new MaxineSuperResSettings(
                            edModels.Text,
                            height: Convert.ToInt32(edSuperResolutionHeight.Text));
                    VideoCapture1.Video_ResizeOrCrop_Enabled = true;

                    break;
                //case 5:
                //    _videoEffect = new AIGSVideoEffect(mode: (AIGSEffectMode)cbAIGSMode.SelectedIndex, backgroundImage: edAIGSBackground.Text);
                //    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            await VideoCapture1.StartAsync();

            tcMain.SelectedIndex = 2;
            tmRecording.Start();
        }
        
        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.ResumeAsync();
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.PauseAsync();
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await VideoCapture1.StopAsync();        }

        /// <summary>
        /// Cb video effect selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbVideoEffect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gdDenoise == null)
            {
                return;
            }

            switch (cbVideoEffect.SelectedIndex)
            {
                case 0:
                    {
                        gdDenoise.Visibility = Visibility.Collapsed;
                        gdArtifactReduction.Visibility = Visibility.Collapsed;
                        gdSuperResolution.Visibility = Visibility.Collapsed;
                        gdUpscale.Visibility = Visibility.Collapsed;
                        // gdAIGS.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 1:
                    {
                        gdDenoise.Visibility = Visibility.Visible;
                        gdArtifactReduction.Visibility = Visibility.Collapsed;
                        gdSuperResolution.Visibility = Visibility.Collapsed;
                        gdUpscale.Visibility = Visibility.Collapsed;
                        // gdAIGS.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 2:
                    {
                        gdDenoise.Visibility = Visibility.Collapsed;
                        gdArtifactReduction.Visibility = Visibility.Visible;
                        gdSuperResolution.Visibility = Visibility.Collapsed;
                        gdUpscale.Visibility = Visibility.Collapsed;
                       // gdAIGS.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 3:
                    {
                        gdDenoise.Visibility = Visibility.Collapsed;
                        gdArtifactReduction.Visibility = Visibility.Collapsed;
                        gdSuperResolution.Visibility = Visibility.Visible;
                        gdUpscale.Visibility = Visibility.Collapsed;
                        // gdAIGS.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 4:
                    {
                        gdDenoise.Visibility = Visibility.Collapsed;
                        gdArtifactReduction.Visibility = Visibility.Collapsed;
                        gdSuperResolution.Visibility = Visibility.Collapsed;
                        gdUpscale.Visibility = Visibility.Visible;
                        // gdAIGS.Visibility = Visibility.Collapsed;
                    }
                    break;
                //case 5:
                //    {
                //        gdDenoise.Visibility = Visibility.Collapsed;
                //        gdArtifactReduction.Visibility = Visibility.Collapsed;
                //        gdSuperResolution.Visibility = Visibility.Collapsed;
                //        gdUpscale.Visibility = Visibility.Collapsed;
                //        // gdAIGS.Visibility = Visibility.Visible;
                //    }
                //    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Cb video input format selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbVideoInputFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoInputFormat.SelectedValue?.ToString()) || string.IsNullOrEmpty(cbVideoInputDevice.SelectedValue.ToString()))
            {
                return;
            }

            if (cbVideoInputDevice.SelectedIndex != -1)
            {
                var deviceItem = VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbVideoInputDevice.SelectedValue.ToString());
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.Find(format => format.Name == cbVideoInputFormat.SelectedValue.ToString());
                if (videoFormat == null)
                {
                    return;
                }

                cbVideoInputFrameRate.Items.Clear();
                foreach (var frameRate in videoFormat.FrameRates)
                {
                    cbVideoInputFrameRate.Items.Add(frameRate.ToString(CultureInfo.CurrentCulture));
                }

                if (cbVideoInputFrameRate.Items.Count > 0)
                {
                    cbVideoInputFrameRate.SelectedIndex = 0;
                }
            }
        }
        
        /// <summary>
        /// Update recording time.
        /// </summary>
        private void UpdateRecordingTime()
        {
            var ts = VideoCapture1.Duration_Time();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            Dispatcher.BeginInvoke((Action)(() =>
            {
                lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
            }));
        }
        
        /// <summary>
        /// Window closing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DestroyEngine();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    tmRecording?.Dispose();
                    tmRecording = null;

                    VideoCapture1?.Dispose();
                    VideoCapture1 = null;
                }

                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Window1()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

