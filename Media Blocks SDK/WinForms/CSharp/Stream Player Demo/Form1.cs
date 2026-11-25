

namespace MediaBlocks_Memory_Player_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.AudioRendering;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.VideoRendering;
    using VisioForge.Core.MediaInfoReaderX;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.UI;
    using VisioForge.Core.MediaBlocks.Special;
    using System.Threading.Tasks;
    using VisioForge.Core;

    /// <summary>
    /// The main form of the application.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private VideoRendererBlock _videoRenderer;

        /// <summary>
        /// The audio renderer.
        /// </summary>
        private AudioRendererBlock _audioRenderer;

        /// <summary>
        /// The stream source.
        /// </summary>
        private StreamSourceBlock _source;

        /// <summary>
        /// The source stream.
        /// </summary>
        private Stream _sourceStream;

        /// <summary>
        /// The duration of the current file, shown in the time label after playback stops.
        /// </summary>
        private TimeSpan _duration;

        /// <summary>
        /// The decode bin.
        /// </summary>
        private DecodeBinBlock _decodeBin;

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
        }

        /// <summary>
        /// Destroy engine async.
        /// </summary>
        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the bt select file click event.
        /// </summary>
        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Link label 1 link clicked.
        /// </summary>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private const int TbmGetChannelRect = 0x041A;
        private const int TbmGetThumbRect = 0x0419;

        private bool _timelineThumbDrag;

        private bool _timelinePageStep;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref RECT lParam);

        /// <summary>
        /// The channel and thumb rectangles of a track bar, in client coordinates.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        /// <summary>
        /// Moves the thumb to the clicked point.
        /// </summary>
        private void ClickToPosition(MouseEventArgs e)
        {
            var thumb = new RECT();
            SendMessage(tbTimeline.Handle, TbmGetThumbRect, IntPtr.Zero, ref thumb);

            var channel = new RECT();
            SendMessage(tbTimeline.Handle, TbmGetChannelRect, IntPtr.Zero, ref channel);

            // The thumb centre travels from the channel's left edge to its right edge minus the thumb.
            var thumbWidth = thumb.Right - thumb.Left;
            var value = tbTimeline.Minimum + (int)Math.Round((e.X - (channel.Left + thumbWidth / 2.0)) * (tbTimeline.Maximum - tbTimeline.Minimum) / (channel.Right - channel.Left - thumbWidth));
            tbTimeline.Value = Math.Max(tbTimeline.Minimum, Math.Min(tbTimeline.Maximum, value));
        }

        /// <summary>
        /// A click on the track seeks to the clicked point; a press on the thumb is a drag.
        /// </summary>
        private async void tbTimeline_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || tbTimeline.Maximum <= tbTimeline.Minimum)
            {
                return;
            }

            // A page step means the native control took the press on the channel: a click.
            if (!_timelinePageStep)
            {
                var thumb = new RECT();
                SendMessage(tbTimeline.Handle, TbmGetThumbRect, IntPtr.Zero, ref thumb);

                if (e.X >= thumb.Left && e.X < thumb.Right)
                {
                    _timelineThumbDrag = true;
                    return;
                }
            }

            _timelinePageStep = false;
            ClickToPosition(e);

            await SeekToTimelineAsync();
        }

        /// <summary>
        /// Ends a thumb drag.
        /// </summary>
        private void tbTimeline_MouseUp(object sender, MouseEventArgs e)
        {
            _timelinePageStep = false;
            _timelineThumbDrag = false;
        }

        /// <summary>
        /// Handles the Scroll event of the tbTimeline control.
        /// </summary>
        private async void tbTimeline_Scroll(object sender, EventArgs e)
        {
            // The page step of a click arrives before MouseDown, which reads it to tell a click from a thumb press.
            if (MouseButtons == MouseButtons.Left && !_timelineThumbDrag)
            {
                _timelinePageStep = true;
                return;
            }

            await SeekToTimelineAsync();
        }

        /// <summary>
        /// Seeks to the timeline value.
        /// </summary>
        private async Task SeekToTimelineAsync()
        {
            try
            {
                await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(edFilename.Text))
                {
                    MessageBox.Show("Please select a video file.");
                    return;
                }

                mmError.Clear();

                CreateEngine();

                _pipeline.Debug_Mode = cbDebugMode.Checked;

                var mediaInfo = new MediaInfoReaderX();
                bool videoStream = true;
                bool audioStream = true;
                if (await mediaInfo.OpenAsync(new Uri(edFilename.Text)))
                {
                    if (mediaInfo.Info.VideoStreams.Count == 0)
                    {
                        videoStream = false;
                    }

                    if (mediaInfo.Info.AudioStreams.Count == 0)
                    {
                        audioStream = false;
                    }
                }

                _sourceStream = new FileStream(edFilename.Text, FileMode.Open, FileAccess.Read);
                _source = new StreamSourceBlock(_sourceStream);

                _decodeBin = new DecodeBinBlock(renderVideo: videoStream, renderAudio: audioStream);

                _pipeline.Connect(_source.Output, _decodeBin.Input);

                if (videoStream)
                {
                    _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);
                    _pipeline.Connect(_decodeBin.VideoOutput, _videoRenderer.Input);
                }

                if (audioStream)
                {
                    _audioRenderer = new AudioRendererBlock();
                    _pipeline.Connect(_decodeBin.AudioOutput, _audioRenderer.Input);
                }

                await _pipeline.StartAsync();

                // set audio volume for each stream
                // _pipeline.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
                // _pipeline.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);

                _duration = TimeSpan.Zero;
                _tmPosition.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            try
            {
                _tmPosition.Stop();

                if (_pipeline != null)
                {
                    await _pipeline.StopAsync(true);
                }

                tbTimeline.Value = 0;
                lbTime.Text = "00:00:00 | " + _duration.ToString("hh\\:mm\\:ss");

                VideoView1.Invalidate();

                await DestroyEngineAsync();

                _sourceStream?.Dispose();
                _sourceStream = null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, EventArgs e)
        {
            try
            {
                await _pipeline.PauseAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, EventArgs e)
        {
            try
            {
                await _pipeline.ResumeAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the tb volume 1 scroll event.
        /// </summary>
        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            _audioRenderer.Volume = tbVolume1.Value / 100.0;
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // We have to initialize the engine on start
                Text += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                this.Enabled = false;
                await VisioForgeX.InitSDKAsync();
                this.Enabled = true;
                Text = Text.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

                Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the tm position tick event.
        /// </summary>
        private async void tmPosition_Tick(object sender, EventArgs e)
        {
            // Leave the timeline alone while the user holds it: a range change recreates its handle and ends the drag.
            if (tbTimeline.Capture)
            {
                return;
            }

            try
            {

                var position = await _pipeline.Position_GetAsync();
                var duration = await _pipeline.DurationAsync();

                // Playback has stopped: keep the reset label.
                if (!_tmPosition.Enabled)
                {
                    return;
                }

                // At the end of the file the pipeline may already report 0: keep the last real duration.
                if (duration > TimeSpan.Zero)
                {
                    _duration = duration;
                }

                tbTimeline.Maximum = (int)duration.TotalSeconds;

                lbTime.Text = position.ToString("hh\\:mm\\:ss") + " | " + duration.ToString("hh\\:mm\\:ss");

                if (tbTimeline.Maximum >= position.TotalSeconds)
                {
                    tbTimeline.Value = (int)position.TotalSeconds;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmError.Text = mmError.Text + e.Message + Environment.NewLine;
                                   }));
        }

        /// <summary>
        /// Pipeline on stop.
        /// </summary>
        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       _tmPosition.Stop();
                                       tbTimeline.Value = 0;
                                       lbTime.Text = "00:00:00 | " + _duration.ToString("hh\\:mm\\:ss");
                                   }));
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _tmPosition.Stop();

                if (_pipeline != null)
                {
                    await _pipeline.StopAsync(true);
                }

                await DestroyEngineAsync();

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}


