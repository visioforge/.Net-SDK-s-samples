// ReSharper disable InconsistentNaming

// ReSharper disable StyleCop.SA1600
// ReSharper disable InlineOutVariableDeclaration

using System.Globalization;

namespace Nvidia_Maxine_Demo
{
    using NvidiaMaxine.VideoEffects.Effects;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.VideoCapture;
    using VisioForge.Core.UI;
    using VisioForge.Core.UI.WPF;
    using VisioForge.Core.VideoCapture;

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : IDisposable
    {    
        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        private VideoCaptureCore VideoCapture1;

        private BaseEffect _videoEffect;

        private int _effectID = 0;

        private string _modelsPath;

        private WriteableBitmap _previewBitmap;

        private AIGSEffectMode _aigsMode;

        private string _aigsBackgroundImage;

        private bool disposedValue;

        public Window1()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();
        }

        private void CreateEngine()
        {
            VideoCapture1 = new VideoCaptureCore();

            VideoCapture1.OnError += VideoCapture1_OnError;
            VideoCapture1.OnVideoFrameBuffer += VideoCapture1_OnVideoFrameBuffer;
        }

        private void VideoCapture1_OnVideoFrameBuffer(object sender, VideoFrameBufferEventArgs e)
        {
            var videoFrame = new NvidiaMaxine.VideoEffects.VideoFrame(e.Frame, false);
            if (_videoEffect == null)
            {
                switch (_effectID)
                {
                    case 0:
                        _videoEffect = null;
                        break;
                    case 1:
                        _videoEffect = new DenoiseEffect(_modelsPath, videoFrame);
                        break;
                    case 2:
                        _videoEffect = new ArtifactReductionEffect(_modelsPath, videoFrame);
                        break;
                    case 3:
                        _videoEffect = new UpscaleEffect(_modelsPath, videoFrame);
                        break;
                    case 4:
                        _videoEffect = new SuperResolutionEffect(_modelsPath, videoFrame);
                        break;
                    case 5:
                        _videoEffect = new AIGSEffect(_modelsPath, videoFrame, _aigsMode);
                        (_videoEffect as AIGSEffect).BackgroundImage = _aigsBackgroundImage;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _videoEffect?.Init(e.Frame.Info.Width, e.Frame.Info.Height);
            }

            if (_videoEffect != null)
            {
                var resFrame = _videoEffect.Process();
                if (resFrame != null)
                {
                    Dispatcher.Invoke(() =>
                    {
                        RenderFrame(resFrame);
                    });
                }
            }
            else
            {
                Dispatcher.Invoke(() =>
                {
                    RenderFrame(videoFrame);
                });
            }
        }

        private void RenderFrame(NvidiaMaxine.VideoEffects.VideoFrame frame)
        {
            if (_previewBitmap == null || _previewBitmap.PixelWidth != frame.Width || _previewBitmap.PixelHeight != frame.Height || pnScreen.Source == null)
            {
                var dpi = VisualTreeHelper.GetDpi(pnScreen);
                _previewBitmap = new WriteableBitmap(frame.Width, frame.Height, dpi.PixelsPerInchX, dpi.PixelsPerInchY, PixelFormats.Bgr24, null);

                pnScreen.BeginInit();
                pnScreen.Source = this._previewBitmap;
                pnScreen.EndInit();
            }

            pnScreen.BeginInit();
            int lineStep = (((frame.Width * 24) + 31) / 32) * 4;
            _previewBitmap.WritePixels(new Int32Rect(0, 0, frame.Width, frame.Height), frame.Data, lineStep * frame.Height, lineStep);
            pnScreen.EndInit();
        }
        
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

        private void btAudioInputDeviceSettings_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Audio_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbAudioInputDevice.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();

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
        }

        private void cbUseBestAudioInputFormat_Checked(object sender, RoutedEventArgs e)
        {
            cbAudioInputFormat.IsEnabled = cbUseBestAudioInputFormat.IsChecked == false;
        }

        private void cbUseBestVideoInputFormat_Checked(object sender, RoutedEventArgs e)
        {
            cbVideoInputFormat.IsEnabled = cbUseBestVideoInputFormat.IsChecked == false;
        }

        private void btVideoCaptureDeviceSettings_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbVideoInputDevice.Text);
        }

        private void Log(string txt)
        {
            Dispatcher.Invoke(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; });
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private void tbAudioVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1?.Audio_OutputDevice_Volume_Set((int)tbAudioVolume.Value);
        }

        private void tbAudioBalance_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_OutputDevice_Balance_Set((int)tbAudioBalance.Value);
        }

        private void lbViewVideoTutorials_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

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

            VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.None;

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

            _modelsPath = edModels.Text;
            _effectID = cbVideoEffect.SelectedIndex;
            _aigsMode = (AIGSEffectMode)cbAIGSMode.SelectedIndex;
            _aigsBackgroundImage = edAIGSBackground.Text;

            await VideoCapture1.StartAsync();

            tcMain.SelectedIndex = 2;
            tmRecording.Start();
        }
        
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.ResumeAsync();
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.PauseAsync();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await VideoCapture1.StopAsync();

            _videoEffect?.Dispose();
            _videoEffect = null;

            pnScreen.BeginInit();
            pnScreen.Source = null;
            pnScreen.EndInit();

            _previewBitmap = null;
        }

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
                        gdAIGS.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 1:
                    {
                        gdDenoise.Visibility = Visibility.Visible;
                        gdArtifactReduction.Visibility = Visibility.Collapsed;
                        gdSuperResolution.Visibility = Visibility.Collapsed;
                        gdUpscale.Visibility = Visibility.Collapsed;
                        gdAIGS.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 2:
                    {
                        gdDenoise.Visibility = Visibility.Collapsed;
                        gdArtifactReduction.Visibility = Visibility.Visible;
                        gdSuperResolution.Visibility = Visibility.Collapsed;
                        gdUpscale.Visibility = Visibility.Collapsed;
                        gdAIGS.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 3:
                    {
                        gdDenoise.Visibility = Visibility.Collapsed;
                        gdArtifactReduction.Visibility = Visibility.Collapsed;
                        gdSuperResolution.Visibility = Visibility.Visible;
                        gdUpscale.Visibility = Visibility.Collapsed;
                        gdAIGS.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 4:
                    {
                        gdDenoise.Visibility = Visibility.Collapsed;
                        gdArtifactReduction.Visibility = Visibility.Collapsed;
                        gdSuperResolution.Visibility = Visibility.Collapsed;
                        gdUpscale.Visibility = Visibility.Visible;
                        gdAIGS.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 5:
                    {
                        gdDenoise.Visibility = Visibility.Collapsed;
                        gdArtifactReduction.Visibility = Visibility.Collapsed;
                        gdSuperResolution.Visibility = Visibility.Collapsed;
                        gdUpscale.Visibility = Visibility.Collapsed;
                        gdAIGS.Visibility = Visibility.Visible;
                    }
                    break;

                default:
                    break;
            }
        }

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

                var videoFormat = deviceItem.VideoFormats.FirstOrDefault(format => format.Name == cbVideoInputFormat.SelectedValue.ToString());
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
        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DestroyEngine();
        }

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

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

// ReSharper restore InconsistentNaming