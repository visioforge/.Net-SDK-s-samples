namespace Multiple_Video_Streams_Demo
{
    using System;
    using System.Threading.Tasks;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using VisioForge.Core.MediaInfo;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
using System.Diagnostics;

    /// <summary>
    /// Multiple video streams demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The media player instance.
        /// </summary>
        private MediaPlayerCore MediaPlayer1;

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            MediaPlayer1 = new MediaPlayerCore(VideoView1 as IVideoView);
            MediaPlayer1.OnError += MediaPlayer1_OnError;
            MediaPlayer1.OnStop += MediaPlayer1_OnStop;
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.OnError -= MediaPlayer1_OnError;
                MediaPlayer1.OnStop -= MediaPlayer1_OnStop;

                MediaPlayer1.Dispose();
                MediaPlayer1 = null;
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
                edFilenameOrURL.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Bug", "S2583:Conditionally executed code should be reachable", Justification = "<Pending>")]
        private async void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(edFilenameOrURL.Text))
                {
                    MessageBox.Show("Please select a file or enter a URL.");
                    return;
                }

                MediaPlayer1.Debug_Mode = cbDebugMode.Checked;

                mmLog.Clear();
                MediaPlayer1.Video_Renderer.Zoom_Ratio = 0;
                MediaPlayer1.Video_Renderer.Zoom_ShiftX = 0;
                MediaPlayer1.Video_Renderer.Zoom_ShiftY = 0;

                var info = new MediaInfoReader
                {
                    Filename = edFilenameOrURL.Text
                };

                info.ReadFileInfo(true);

                MediaPlayer1.Multiple_Video_Streams_Mappings_Clear();
                if (info.VideoStreams.Count > 1)
                {
                    // The main view shows stream 0; the four panels show streams 1 to 4.
                    int count = Math.Min(info.VideoStreams.Count - 1, 4);
                    for (int i = 0; i < count; i++)
                    {
                        Panel panel = null;
                        switch (i)
                        {
                            case 0:
                                panel = pnScreen1;
                                break;
                            case 1:
                                panel = pnScreen2;
                                break;
                            case 2:
                                panel = pnScreen3;
                                break;
                            case 3:
                                panel = pnScreen4;
                                break;
                        }

                        if (panel != null)
                        {
                            MediaPlayer1.Multiple_Video_Streams_Mappings_Add(i + 1, panel.Handle, panel.Width, panel.Height);
                        }
                    }
                }

                MediaPlayer1.Playlist_Clear();
                MediaPlayer1.Playlist_Add(edFilenameOrURL.Text);

                MediaPlayer1.Audio_PlayAudio = true;
                MediaPlayer1.Info_UseLibMediaInfo = true;

                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.File_DS;

                MediaPlayer1.Video_Renderer_SetAuto();

                MediaPlayer1.Video_Sample_Grabber_UseForVideoEffects = false;

                await MediaPlayer1.PlayAsync();

                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Media player 1 on error.
        /// </summary>
        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
                                   }));
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, EventArgs e)
        {
            try
            {
                await MediaPlayer1.ResumeAsync();
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
                await MediaPlayer1.PauseAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Stop async.
        /// </summary>
        private async Task StopAsync()
        {
            await MediaPlayer1.StopAsync();

            timer1.Enabled = false;

            tbTimeline.Value = 0;
            lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum);
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            try
            {
                await StopAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt next frame click event.
        /// </summary>
        private void btNextFrame_Click(object sender, EventArgs e)
        {
            MediaPlayer1.NextFrame();
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
                await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value));
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
                tbTimeline.Maximum = (int)(await MediaPlayer1.Duration_TimeAsync()).TotalSeconds;

                int value = (int)(await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds;

                // Playback has stopped: keep the reset label.
                if (!timer1.Enabled)
                {
                    return;
                }

                if ((value > 0) && (value < tbTimeline.Maximum))
                {
                    tbTimeline.Value = value;
                }

                lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";
        }

        /// <summary>
        /// Media player 1 on stop.
        /// </summary>
        private void MediaPlayer1_OnStop(object sender, StopEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                timer1.Enabled = false;
                tbTimeline.Value = 0;
                lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum);
            }));
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                await StopAsync();

                DestroyEngine();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
