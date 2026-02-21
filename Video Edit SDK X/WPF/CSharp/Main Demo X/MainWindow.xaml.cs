namespace VideoEdit_CS_Demo_X
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Windows;

    using VisioForge.Core;
    using VisioForge.Core.Helpers;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.AudioEffects;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.Types.X.VideoEdit;
    using VisioForge.Core.Types.X.VideoEffects;
    using VisioForge.Core.UI;
    using VisioForge.Core.VideoEditX;

    /// <summary>
    /// The main window for the Video Edit SDK X Main Demo WPF.
    /// Provides an interface for configuring video sources, effects, and output formats using the X-engine.
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoEditCoreX VideoEdit1;

        private volatile bool _seekingFlag;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btClearList control.
        /// Clears the input files list and resets the UI appropriately.
        /// </summary>
        private void btClearList_Click(object sender, RoutedEventArgs e)
        {
            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
        }

        /// <summary>
        /// Handles the Click event of the btAddInputFile control.
        /// Opens a file dialog to select and add video, image, or audio files to the project.
        /// </summary>
        private void btAddInputFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "All files|*.*|Video files|*.avi;*.mp4;*.wmv;*.mkv;*.webm;*.ts;*.mpg|Audio files|*.mp3;*.wav;*.ogg;*.wma;*.aac;*.flac;*.m4a|Image files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tiff"
            };

            if (dlg.ShowDialog() == true)
            {
                string s = dlg.FileName;

                lbFiles.Items.Add(s);

                if (cbResize.IsChecked == true && !string.IsNullOrEmpty(edWidth.Text) && !string.IsNullOrEmpty(edHeight.Text))
                {
                    VideoEdit1.Output_VideoSize = new VisioForge.Core.Types.Size(Convert.ToInt32(edWidth.Text), Convert.ToInt32(edHeight.Text));
                }

                var frameRate = Convert.ToInt32(((System.Windows.Controls.ComboBoxItem)cbFrameRate.SelectedItem).Content.ToString(), CultureInfo.InvariantCulture);
                if (frameRate != 0)
                {
                    VideoEdit1.Output_VideoFrameRate = new VideoFrameRate(frameRate);
                }

                if (FilenameHelper.IsImageFile(s))
                {
                    if (cbAddFullFile.IsChecked == true)
                    {
                        if (cbInsertAfterPreviousFile.IsChecked == true)
                        {
                            VideoEdit1.Input_AddImageFile(
                                s,
                                TimeSpan.FromMilliseconds(2000),
                                null);
                        }
                        else
                        {
                            VideoEdit1.Input_AddImageFile(
                                s,
                                TimeSpan.FromMilliseconds(2000),
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)));
                        }
                    }
                    else
                    {
                        if (cbInsertAfterPreviousFile.IsChecked == true)
                        {
                            VideoEdit1.Input_AddImageFile(
                                s,
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text) - Convert.ToInt32(edStartTime.Text)));
                        }
                        else
                        {
                            VideoEdit1.Input_AddImageFile(
                                s,
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text) - Convert.ToInt32(edStartTime.Text)),
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)));
                        }
                    }
                }
                else if (FilenameHelper.IsAudioFile(s))
                {
                    if (cbAddFullFile.IsChecked == true)
                    {
                        var audioFile = new AudioFileSource(s);
                        if (cbInsertAfterPreviousFile.IsChecked == true)
                        {
                            VideoEdit1.Input_AddAudioFile(audioFile, null);
                        }
                        else
                        {
                            VideoEdit1.Input_AddAudioFile(audioFile, insertTime: TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)));
                        }
                    }
                    else
                    {
                        var audioFile = new AudioFileSource(
                            s,
                            TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTime.Text)),
                            TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text)));
                        if (cbInsertAfterPreviousFile.IsChecked == true)
                        {
                            VideoEdit1.Input_AddAudioFile(audioFile, null);
                        }
                        else
                        {
                            VideoEdit1.Input_AddAudioFile(audioFile, insertTime: TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)));
                        }
                    }
                }
                else
                {
                    if (cbAddFullFile.IsChecked == true)
                    {
                        if (cbInsertAfterPreviousFile.IsChecked == true)
                        {
                            VideoEdit1.Input_AddAudioVideoFile(s, null);
                        }
                        else
                        {
                            VideoEdit1.Input_AddAudioVideoFile(s, insertTime: TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)));
                        }
                    }
                    else
                    {
                        if (cbInsertAfterPreviousFile.IsChecked == true)
                        {
                            VideoEdit1.Input_AddAudioVideoFile(
                                s,
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTime.Text)),
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text)),
                                null);
                        }
                        else
                        {
                            VideoEdit1.Input_AddAudioVideoFile(
                                s,
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTime.Text)),
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text)),
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btSelectOutput control.
        /// </summary>
        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "MP4 (*.mp4)|*.mp4|AVI (*.avi)|*.avi|MKV (*.mkv)|*.mkv|All files (*.*)|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                edOutput.Text = dlg.FileName;
            }
        }

        /// <summary>
        /// Creates the video editing engine and subscribes to events.
        /// </summary>
        private void CreateEngine()
        {
            VideoEdit1 = new VideoEditCoreX(VideoView1 as IVideoView);

            VideoEdit1.OnError += VideoEdit1_OnError;
            VideoEdit1.OnStart += VideoEdit1_OnStart;
            VideoEdit1.OnStop += VideoEdit1_OnStop;
            VideoEdit1.OnProgress += VideoEdit1_OnProgress;

            VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        /// <summary>
        /// Destroys the video editing engine and unsubscribes from events to release resources.
        /// </summary>
        private void DestroyEngine()
        {
            if (VideoEdit1 != null)
            {
                VideoEdit1.OnError -= VideoEdit1_OnError;
                VideoEdit1.OnStart -= VideoEdit1_OnStart;
                VideoEdit1.OnStop -= VideoEdit1_OnStop;
                VideoEdit1.OnProgress -= VideoEdit1_OnProgress;

                VideoEdit1.Dispose();
                VideoEdit1 = null;
            }
        }

        /// <summary>
        /// Handles the Loaded event of the Window.
        /// Initializes the SDK engine, sets default UI values, and populates transition lists.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            CreateEngine();

            Title += $" (SDK v{VideoEditCoreX.SDK_Version})";

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");

            cbMode.SelectedIndex = 1;
            cbFrameRate.SelectedIndex = 0;
            cbOutputVideoFormat.SelectedIndex = 0;
            cbRotate.SelectedIndex = 0;

            var transitions = VideoEdit1.Video_Transitions_Names();
            foreach (var item in transitions)
            {
                cbTransitionName.Items.Add(item);
            }

            cbTransitionName.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures the engine with selected output format, effects, and starts the process.
        /// </summary>
        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoEdit1.Debug_Telemetry = cbTelemetry.IsChecked == true;

            mmLog.Clear();

            if (cbCrop.IsChecked == true)
            {
                VideoEdit1.Output_VideoCrop = new CropVideoEffect(
                    Convert.ToInt32(edCropLeft.Text),
                    Convert.ToInt32(edCropTop.Text),
                    Convert.ToInt32(edCropRight.Text),
                    Convert.ToInt32(edCropBottom.Text));
            }
            else
            {
                VideoEdit1.Output_VideoCrop = null;
            }

            //if (cbSubtitlesEnabled.IsChecked == true)
            //{
            //    VideoEdit1.Video_Subtitles = new SubtitlesSettings(edSubtitlesFilename.Text);
            //}
            //else
            //{
            //    VideoEdit1.Video_Subtitles = null;
            //}

            if (cbMode.SelectedIndex == 0)
            {
                switch (cbOutputVideoFormat.SelectedIndex)
                {
                    case 0:
                        {
                            var mp4Output = new MP4Output(edOutput.Text);
                            VideoEdit1.Output_Format = mp4Output;
                            break;
                        }
                    case 1:
                        {
                            var webmOutput = new WebMOutput(edOutput.Text);
                            VideoEdit1.Output_Format = webmOutput;
                            break;
                        }
                    case 2:
                        {
                            var mkvOutput = new MKVOutput(edOutput.Text);
                            VideoEdit1.Output_Format = mkvOutput;
                            break;
                        }
                    case 3:
                        {
                            var wmvOutput = new WMVOutput(edOutput.Text);
                            VideoEdit1.Output_Format = wmvOutput;
                            break;
                        }
                    case 4:
                        {
                            var acmOutput = new WAVOutput(edOutput.Text);
                            VideoEdit1.Output_Format = acmOutput;
                            break;
                        }
                    case 5:
                        {
                            var mp3Output = new MP3Output(edOutput.Text);
                            VideoEdit1.Output_Format = mp3Output;
                            break;
                        }
                    case 6:
                        {
                            var m4aOutput = new M4AOutput(edOutput.Text);
                            VideoEdit1.Output_Format = m4aOutput;
                            break;
                        }
                    case 7:
                        {
                            var wmaOutput = new WMAOutput(edOutput.Text);
                            VideoEdit1.Output_Format = wmaOutput;
                            break;
                        }
                    case 8:
                        {
                            var oggVorbisOutput = new OGGVorbisOutput(edOutput.Text);
                            VideoEdit1.Output_Format = oggVorbisOutput;
                            break;
                        }
                    case 9:
                        {
                            var flacOutput = new FLACOutput(edOutput.Text);
                            VideoEdit1.Output_Format = flacOutput;
                            break;
                        }
                    case 10:
                        {
                            var speexOutput = new SpeexOutput(edOutput.Text);
                            VideoEdit1.Output_Format = speexOutput;
                            break;
                        }
                }
            }
            else
            {
                VideoEdit1.Output_Format = null;
            }

            // Audio effects
            VideoEdit1.Audio_Effects.Clear();

            if (cbAudioEffectsEnabled.IsChecked == true)
            {
                if (cbAudAmplifyEnabled.IsChecked == true)
                {
                    var amplify = new AmplifyAudioEffect(tbAudAmplifyAmp.Value / 100.0);
                    VideoEdit1.Audio_Effects.Add(amplify);
                }

                if (cbAudEqualizerEnabled.IsChecked == true)
                {
                    var levels = new double[] { tbAudEq0.Value, tbAudEq1.Value, tbAudEq2.Value, tbAudEq3.Value, tbAudEq4.Value,
                                                tbAudEq5.Value, tbAudEq6.Value, tbAudEq7.Value, tbAudEq8.Value, tbAudEq9.Value };
                    var eq10 = new Equalizer10AudioEffect(levels);
                    VideoEdit1.Audio_Effects.Add(eq10);
                }
            }

            // Video effects CPU
            VideoEdit1.Video_Effects.Clear();
            VideoEdit1.Video_TextOverlays.Clear();

            AddVideoEffects();

            // video rotation
            switch (cbRotate.SelectedIndex)
            {
                case 0:
                    VideoEdit1.Output_VideoRotateFlip = null;
                    break;
                case 1:
                    VideoEdit1.Output_VideoRotateFlip = new FlipRotateVideoEffect(VideoFlipRotateMethod.Method90R);
                    break;
                case 2:
                    VideoEdit1.Output_VideoRotateFlip = new FlipRotateVideoEffect(VideoFlipRotateMethod.Method180);
                    break;
                case 3:
                    VideoEdit1.Output_VideoRotateFlip = new FlipRotateVideoEffect(VideoFlipRotateMethod.Method90L);
                    break;
            }

            VideoEdit1.Start();
        }

        /// <summary>
        /// Add video effects.
        /// </summary>
        private void AddVideoEffects()
        {
            if (cbEffects.IsChecked != true)
            {
                return;
            }

            // Deinterlace
            if (cbDeinterlace.IsChecked == true)
            {
                var deint = new DeinterlaceVideoEffect();
                VideoEdit1.Video_Effects.Add(deint);
            }

            // Denoise (smooth filter)
            if (cbDenoise.IsChecked == true)
            {
                var denoise = new SmoothVideoEffect();
                VideoEdit1.Video_Effects.Add(denoise);
            }

            // Balance
            if (Math.Abs(tbBrightness.Value) > 0.001 || Math.Abs(tbHue.Value) > 0.001 || Math.Abs(tbContrast.Value - 100) > 0.001 || Math.Abs(tbSaturation.Value - 100) > 0.001)
            {
                var balance = new VideoBalanceVideoEffect();
                balance.Brightness = tbBrightness.Value / 100.0;
                balance.Hue = tbHue.Value / 100.0;
                balance.Saturation = tbSaturation.Value / 100.0;
                balance.Contrast = tbContrast.Value / 100.0;

                VideoEdit1.Video_Effects.Add(balance);
            }

            // Grayscale
            if (cbGreyscale.IsChecked == true)
            {
                var grayscale = new VideoBalanceVideoEffect();
                grayscale.Saturation = 0;

                VideoEdit1.Video_Effects.Add(grayscale);
            }

            // Sepia
            if (cbSepia.IsChecked == true)
            {
                var sepia = new ColorEffectsVideoEffect(ColorEffectsPreset.Sepia);
                VideoEdit1.Video_Effects.Add(sepia);
            }

            // Flip
            if (cbFlipX.IsChecked == true)
            {
                var flipx = new FlipRotateVideoEffect(VideoFlipRotateMethod.MethodHorizontal);
                VideoEdit1.Video_Effects.Add(flipx);
            }

            if (cbFlipY.IsChecked == true)
            {
                var flipy = new FlipRotateVideoEffect(VideoFlipRotateMethod.MethodVertical);
                VideoEdit1.Video_Effects.Add(flipy);
            }

            // Text overlay
            if (cbTextOverlay.IsChecked == true)
            {
                var textOverlay = new TextOverlay("Hello world!");
                VideoEdit1.Video_TextOverlays.Add(textOverlay);
            }

            // Image overlay
            if (cbImageOverlay.IsChecked == true)
            {
                var imageOverlay = new ImageOverlayVideoEffect("logo.png");
                VideoEdit1.Video_Effects.Add(imageOverlay);
            }
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// </summary>
        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Stop();

            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
            ProgressBar1.Value = 0;

            VideoEdit1.Video_Effects.Clear();
        }

        private void btSaveDiagram_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog
            {
                FileName = "pipeline_diagram.png",
                Filter = "PNG Image|*.png"
            };

            if (dlg.ShowDialog() == true)
            {
                using (var image = VideoEdit1.GetDiagramAsImage())
                {
                    if (image != null)
                    {
                        using (var data = image.Encode(SkiaSharp.SKEncodedImageFormat.Png, 100))
                        {
                            using (var stream = File.Create(dlg.FileName))
                            {
                                data.SaveTo(stream);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Closing event of the Window.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VideoEdit1?.Stop();

            DestroyEngine();

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Handles the seeking slider value changed event.
        /// </summary>
        private void tbSeeking_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_seekingFlag && VideoEdit1 != null)
            {
                VideoEdit1.Position_Set(TimeSpan.FromMilliseconds(tbSeeking.Value));
            }
        }

        /// <summary>
        /// Video edit 1 on error.
        /// </summary>
        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + "(" + e.CallSite + ")" + Environment.NewLine;
            });
        }

        /// <summary>
        /// Handles the video edit 1 on start event.
        /// </summary>
        private void VideoEdit1_OnStart(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                _seekingFlag = true;
                tbSeeking.Maximum = (int)VideoEdit1.Duration().TotalMilliseconds;
                _seekingFlag = false;
            });
        }

        /// <summary>
        /// Video edit 1 on progress.
        /// </summary>
        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                ProgressBar1.Value = e.Progress;
            });
        }

        /// <summary>
        /// Video edit 1 on stop.
        /// </summary>
        private void VideoEdit1_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                ProgressBar1.Value = 0;
                lbFiles.Items.Clear();

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

        /// <summary>
        /// Handles the btAddTransition click event.
        /// </summary>
        private void btAddTransition_Click(object sender, RoutedEventArgs e)
        {
            if (cbTransitionName.SelectedItem == null)
            {
                return;
            }

            var transName = cbTransitionName.SelectedItem.ToString();
            var trans = new VideoTransition(
                transName,
                TimeSpan.FromMilliseconds(Convert.ToInt32(edTransStartTime.Text)),
                TimeSpan.FromMilliseconds(Convert.ToInt32(edTransStopTime.Text)));
            VideoEdit1.Video_Transitions.Add(trans);

            // add to list
            lbTransitions.Items.Add(transName +
            " (Start: " + edTransStartTime.Text + ", stop: " + edTransStopTime.Text + ")");
        }

        /// <summary>
        /// Handles the btSubtitlesSelectFile click event.
        /// </summary>
        private void btSubtitlesSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Subtitle files|*.srt;*.sub;*.ass;*.ssa|All files|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                edSubtitlesFilename.Text = dlg.FileName;
            }
        }
    }
}
