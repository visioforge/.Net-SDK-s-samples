using NvidiaMaxine.VideoEffects.Effects;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using VisioForge.Core.MediaPlayer;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types;
using VisioForge.Core.Types.MediaPlayer;
using System.Windows.Threading;

namespace Nvidia_Maxine_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private MediaPlayerCore MediaPlayer1;

        private BaseEffect _videoEffect;

        private int _effectID = 0;

        private string _modelsPath;

        private AIGSEffectMode _aigsMode;

        private string _aigsBackgroundImage;

        private readonly DispatcherTimer _timer = new DispatcherTimer();

        private WriteableBitmap _previewBitmap;

        private void CreateEngine()
        {
            MediaPlayer1 = new MediaPlayerCore();
            MediaPlayer1.OnVideoFrameBuffer += MediaPlayer1_OnVideoFrameBuffer;
            MediaPlayer1.OnError += MediaPlayer1_OnError;
            MediaPlayer1.OnStop += MediaPlayer1_OnStop;
        }

        private void MediaPlayer1_OnVideoFrameBuffer(object sender, VideoFrameBufferEventArgs e)
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
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.OnError -= MediaPlayer1_OnError;
                MediaPlayer1.OnStop -= MediaPlayer1_OnStop;
                MediaPlayer1.OnVideoFrameBuffer -= MediaPlayer1_OnVideoFrameBuffer;
                
                MediaPlayer1.Dispose();
                MediaPlayer1 = null;
            }
        }

        private async void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Convert.ToInt32(_timer.Tag) == 0)
            {
                await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            edLog.Clear();

            MediaPlayer1.Source_Mode = MediaPlayerSourceMode.LAV;

            MediaPlayer1.Playlist_Clear();
            MediaPlayer1.Playlist_Add(edFilename.Text);

            MediaPlayer1.Loop = cbLoop.IsChecked == true;
            MediaPlayer1.Audio_PlayAudio = true;
            MediaPlayer1.Info_UseLibMediaInfo = true;
            MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device";

            MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.None;

            MediaPlayer1.Debug_Mode = cbDebug.IsChecked == true;

            _effectID = cbVideoEffect.SelectedIndex;
            _modelsPath = edModels.Text;
            _aigsMode = (AIGSEffectMode)cbAIGSMode.SelectedIndex;
            _aigsBackgroundImage = edAIGSBackground.Text;
            
            await MediaPlayer1.PlayAsync();

            _timer.Start();
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await MediaPlayer1.PauseAsync();
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await MediaPlayer1.ResumeAsync();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            await MediaPlayer1.StopAsync();

            _videoEffect?.Dispose();
            _videoEffect = null;

            tbTimeline.Value = 0;

            pnScreen.BeginInit();
            pnScreen.Source = null;
            pnScreen.EndInit();

            _previewBitmap = null;
        }

        private void btOpenFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                edFilename.Text = dlg.FileName;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            this.Title += $" (SDK v{MediaPlayer1.SDK_Version()})";
            MediaPlayer1.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            cbVideoEffect.SelectedIndex = 0;
            cbVideoEffect_SelectionChanged(null, null);

            _timer.Interval = TimeSpan.FromMilliseconds(500);
            _timer.Tick +=
                async delegate (object s, EventArgs a)
                {
                    await timer1_Tick();
                };
        }

        private async Task timer1_Tick()
        {
            _timer.Tag = 1;
            tbTimeline.Maximum = (int)(await MediaPlayer1.Duration_TimeAsync()).TotalSeconds;

            int value = (int)(await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds;
            if ((value > 0) && (value < tbTimeline.Maximum))
            {
                tbTimeline.Value = value;
            }

            lbTime.Content = MediaPlayer1.Helpful_SecondsToTimeFormatted((int)tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted((int)tbTimeline.Maximum);

            _timer.Tag = 0;
        }

        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                edLog.Text = edLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private void MediaPlayer1_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                tbTimeline.Value = 0;
            }));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btStop_Click(null, null);

            DestroyEngine();
        }

        private void cbVideoEffect_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
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
    }
}
