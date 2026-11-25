using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VisioForge.Core.LiveVideoCompositorV2;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.Sources;

namespace Video_Mixer_Player
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The live video compositor instance.
        /// </summary>
        private LiveVideoCompositor _compositor;

        /// <summary>
        /// The video view output.
        /// </summary>
        private LVCVideoViewOutput _videoRendererOutput;

        /// <summary>
        /// The list of inputs.
        /// </summary>
        private List<LVCInput> _inputs = new List<LVCInput>();

        /// <summary>
        /// The last Start and Stop, awaited by FormClosing before it tears down.
        /// </summary>
        private Task _startTask = Task.CompletedTask;
        private Task _stopTask = Task.CompletedTask;

        /// <summary>
        /// Set once the teardown on close is done and the form may really close.
        /// </summary>
        private bool _closeReady;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form 1 load.
        /// </summary>
        private async void Form1_Load(object sender, System.EventArgs e)
        {
            // We have to initialize the engine on start
            Text += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.Enabled = false;
            await VisioForgeX.InitSDKAsync();
            this.Enabled = true;
            Text = Text.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            Text += $" (SDK v{MediaPlayerCoreX.SDK_Version})";
        }

        /// <summary>
        /// Handles the bt add file click event.
        /// </summary>
        private void btAddFile_Click(object sender, System.EventArgs e)
        {
            using (var openFileDialog1 = new OpenFileDialog())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    lbSourceFiles.Items.Add(openFileDialog1.FileName);
                }
            }
        }

        /// <summary>
        /// Add file source async.
        /// </summary>
        private async Task AddFileSourceAsync(string filename, Rect rect)
        {
            var name = $"File [{filename}]";

            var settings = await UniversalSourceSettings.CreateAsync(filename);
            var info = settings.GetInfo();

            VideoFrameInfoX videoInfo = null;
            if (info.VideoStreams.Count > 0)
            {
                videoInfo = new VideoFrameInfoX(info.VideoStreams[0].Width, info.VideoStreams[0].Height, info.VideoStreams[0].FrameRate);
            }

            AudioInfoX audioInfo = null;
            if (info.AudioStreams.Count > 0)
            {
                audioInfo = new AudioInfoX(AudioFormatX.S16LE, info.AudioStreams[0].SampleRate, info.AudioStreams[0].Channels);
            }


            var src = new LVCVideoAudioInput(name, _compositor, new UniversalSourceBlock(settings), videoInfo, audioInfo, rect, true);
            src.Pipeline.PauseOnStop = true;

            if (await _compositor.Input_AddAsync(src))
            {
                _inputs.Add(src);
            }
            else
            {
                src.Dispose();
            }
        }

        /// <summary>
        /// Get source position async.
        /// </summary>
        private async Task<TimeSpan> GetSourcePositionAsync()
        {
            TimeSpan pos = TimeSpan.Zero;

            foreach (var input in _inputs)
            {
                var p = await input.Pipeline.Position_GetAsync();
                if (p > pos)
                {
                    pos = p;
                }
            }

            return pos;
        }

        /// <summary>
        /// Get source duration async.
        /// </summary>
        private async Task<TimeSpan> GetSourceDurationAsync()
        {
            TimeSpan duration = TimeSpan.Zero;

            foreach (var input in _inputs)
            {
                var d = await input.Pipeline.DurationAsync();
                if (d > duration)
                {
                    duration = d;
                }
            }

            return duration;
        }

        /// <summary>
        /// Set source position async.
        /// </summary>
        private async Task SetSourcePositionAsync(TimeSpan position)
        {
            foreach (var input in _inputs)
            {
                await input.Pipeline.Position_SetAsync(position);
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

            var position = await GetSourcePositionAsync();
            var duration = await GetSourceDurationAsync();

            tbTimeline.Maximum = (int)duration.TotalSeconds;

            lbTimeline.Text = position.ToString("hh\\:mm\\:ss") + " | " + duration.ToString("hh\\:mm\\:ss");

            if (tbTimeline.Maximum >= position.TotalSeconds)
            {
                tbTimeline.Value = (int)position.TotalSeconds;
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, System.EventArgs e)
        {
            if (lbSourceFiles.Items.Count < 2)
            {
                MessageBox.Show("Please add at least 2 files.");
                return;
            }

            // One compositor at a time; Stop, Pause and Resume wait until it has started.
            btStart.Enabled = false;

            _startTask = StartCompositorAsync();
            await _startTask;
        }

        /// <summary>
        /// Builds the compositor with both files and the video view, and starts it.
        /// </summary>
        private async Task StartCompositorAsync()
        {
            try
            {
                _compositor = new LiveVideoCompositor(new LiveVideoCompositorSettings(1920, 1080, VideoFrameRate.FPS_25));

                _compositor.OnError += (senderX, args) =>
                {
                    Debug.WriteLine(args.Message);
                    BeginInvoke(new Action(() => MessageBox.Show(args.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                };

                _compositor.OnRenderStatistics += (senderX, args) =>
                {
                    Debug.WriteLine($"Compositor FPS: actual {args.ActualFps:F1} / configured {args.ConfiguredFps:F1} (frames delivered: {args.FramesDelivered})");
                };

                await AddFileSourceAsync(lbSourceFiles.Items[0].ToString(), new Rect(0, 0, 1920, 1080));
                await AddFileSourceAsync(lbSourceFiles.Items[1].ToString(), new Rect(0, 0, 640, 480));

                // add video renderer
                var name = "[VideoView] Preview";
                _videoRendererOutput = new LVCVideoViewOutput(name, _compositor, videoView1, true);
                await _compositor.Output_AddAsync(_videoRendererOutput);

                if (await _compositor.StartAsync())
                {
                    tmPosition.Start();
                    btPause.Enabled = btResume.Enabled = true;
                }
            }
            finally
            {
                // Also after a failed start, so Stop can dispose the compositor.
                btStop.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, EventArgs e)
        {
            foreach (var input in _inputs)
            {
                await input.PauseAsync();
            }
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, EventArgs e)
        {
            foreach (var input in _inputs)
            {
                await input.ResumeAsync();
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            btStop.Enabled = btPause.Enabled = btResume.Enabled = false;
            try
            {
                _stopTask = StopAsync();
                await _stopTask;
                btStart.Enabled = true;
            }
            catch
            {
                // Stop can be retried; Start stays off while the compositor is still there.
                btStop.Enabled = true;
                throw;
            }
        }

        /// <summary>
        /// Stops the compositor and disposes it with its inputs and output, so Start can build a new one.
        /// </summary>
        private async Task StopAsync()
        {
            tmPosition.Stop();

            if (_compositor != null)
            {
                await _compositor.StopAsync();

                foreach (var input in _inputs)
                {
                    input.Dispose();
                }
                _inputs.Clear();

                _videoRendererOutput?.Dispose();
                _videoRendererOutput = null;

                await _compositor.DisposeAsync();
                _compositor = null;
            }
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
            await SetSourcePositionAsync(TimeSpan.FromSeconds(tbTimeline.Value));
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_closeReady)
            {
                return;
            }

            // Keep the window until the pipelines are torn down, then close it again.
            e.Cancel = true;
            Enabled = false;

            try
            {
                // A Start or Stop still running finishes first; a failure there was already raised by its click handler.
                await Task.WhenAll(_startTask, _stopTask);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            try
            {
                await StopAsync();
            }
            finally
            {
                VisioForgeX.DestroySDK();

                _closeReady = true;
                Close();
            }
        }
    }
}
