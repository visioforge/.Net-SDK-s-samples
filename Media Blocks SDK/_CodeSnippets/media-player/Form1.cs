using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;


using VisioForge.Core;

using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using System.Linq;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.AudioRendering;
using System.Diagnostics;

namespace media_player
{
    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(edFilename.Text))
                {
                    MessageBox.Show("Please select a file.");
                    return;
                }

                // Create MediaBlocks pipeline
                _pipeline = new MediaBlocksPipeline();

                // Add file source
                var fileSourceSettings = await UniversalSourceSettings.CreateAsync(edFilename.Text);
                var videoStreamAvailable = fileSourceSettings.GetInfo().VideoStreams.Count > 0;
                var audioStreamAvailable = fileSourceSettings.GetInfo().AudioStreams.Count > 0;

                var fileSource = new UniversalSourceBlock(fileSourceSettings);

                // Add video renderer
                if (videoStreamAvailable)
                {
                    var videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);
                    _pipeline.Connect(fileSource, videoRenderer);
                }

                // Add audio output
                if (audioStreamAvailable)
                {
                    var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound))[0];
                    var audioOutput = new AudioRendererBlock(new AudioRendererSettings(audioOutputDevice));
                    _pipeline.Connect(fileSource, audioOutput);
                }

                // Start playback
                await _pipeline.StartAsync();

                timer1.Start();
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
                timer1.Stop();

                await _pipeline.StopAsync(force: true);

                await _pipeline.DisposeAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // We have to initialize the engine on start
                Text += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                this.Enabled = false;
                await VisioForgeX.InitSDKAsync();
                this.Enabled = true;
                Text = Text.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Handles the bt open file click event.
        /// </summary>
        private void btOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = openFileDialog1.FileName;
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
        /// Handles the timer 1 tick event.
        /// </summary>
        private async void timer1_Tick(object sender, EventArgs e)
        {
            // Leave the timeline alone while the user holds it: a range change recreates its handle and ends the drag.
            if (tbTimeline.Capture)
            {
                return;
            }

            try
            {
                tbTimeline.Maximum = (int)(await _pipeline.DurationAsync()).TotalSeconds;

                int value = (int)(await _pipeline.Position_GetAsync()).TotalSeconds;
                if ((value > 0) && (value < tbTimeline.Maximum))
                {
                    tbTimeline.Value = value;
                }

                lbTime.Text = TimeSpan.FromSeconds(tbTimeline.Value).ToString("hh\\:mm\\:ss") + "/" + TimeSpan.FromSeconds(tbTimeline.Maximum).ToString("hh\\:mm\\:ss");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
