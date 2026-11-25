

namespace Memory_Stream_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using VisioForge.Core;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.UI;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using VisioForge.Core.MediaInfo;
    using System.Threading.Tasks;

    /// <summary>
    /// Memory playback demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The managed stream.
        /// </summary>
        private ManagedIStream _stream;

        /// <summary>
        /// The file stream.
        /// </summary>
        private FileStream _fileStream;

        /// <summary>
        /// The memory stream.
        /// </summary>
        private MemoryStream _memoryStream;

        /// <summary>
        /// The memory source byte array.
        /// </summary>
        private byte[] _memorySource;

        /// <summary>
        /// The media player instance.
        /// </summary>
        private MediaPlayerCore MediaPlayer1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            MediaPlayer1 = new MediaPlayerCore(VideoView1 as IVideoView);
            MediaPlayer1.OnError += MediaPlayer1_OnError;
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.OnError -= MediaPlayer1_OnError;

                MediaPlayer1.Dispose();
                MediaPlayer1 = null;
            }
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
                await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value));
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

                mmError.Text = string.Empty;
                bool videoAvailable;
                bool audioAvailable;

                if (rbSTreamTypeFile.Checked)
                {
                    _fileStream = new FileStream(edFilename.Text, FileMode.Open);
                    _stream = new ManagedIStream(_fileStream);

                    MediaInfoReader.GetStreamAvailabilityFromMemoryStream(MediaPlayer1.GetContext(), _stream, _fileStream.Length, out videoAvailable, out audioAvailable);

                    // specifying settings
                    MediaPlayer1.Source_MemoryStream = new MemoryStreamSource(_stream, videoAvailable, audioAvailable, _fileStream.Length);
                }
                else
                {
                    // WARNING: ReadAllBytes loads the entire file into memory. For large video files, consider using FileStream instead.
                    _memorySource = File.ReadAllBytes(edFilename.Text);
                    _memoryStream = new MemoryStream(_memorySource);
                    _stream = new ManagedIStream(_memoryStream);

                    MediaInfoReader.GetStreamAvailabilityFromMemoryStream(MediaPlayer1.GetContext(), _stream, _memoryStream.Length, out videoAvailable, out audioAvailable);

                    // specifying settings
                    MediaPlayer1.Source_MemoryStream = new MemoryStreamSource(_stream, videoAvailable, audioAvailable, _memoryStream.Length);
                }

                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.Memory_DS;

                if (audioAvailable)
                {
                    MediaPlayer1.Audio_PlayAudio = true;
                    MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device";
                }
                else
                {
                    MediaPlayer1.Audio_PlayAudio = false;
                }

                if (videoAvailable)
                {
                    MediaPlayer1.Video_Renderer_SetAuto();
                }
                else
                {
                    MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.None;
                }

                MediaPlayer1.Debug_Mode = cbDebugMode.Checked;
                await MediaPlayer1.PlayAsync();

                tbTimeline.Maximum = (int)(await MediaPlayer1.Duration_TimeAsync()).TotalSeconds;
                timer1.Enabled = true;
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
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
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

            if (_fileStream != null)
            {
                _fileStream.Dispose();
                _fileStream = null;
            }

            if (_memoryStream != null)
            {
                _memoryStream.Dispose();
                _memoryStream = null;
            }

            _memorySource = null;
            _stream = null;
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

        /// <summary>
        /// Handles the tb speed scroll event.
        /// </summary>
        private async void tbSpeed_Scroll(object sender, EventArgs e)
        {
            try
            {
                await MediaPlayer1.SetSpeedAsync(tbSpeed.Value / 10.0);
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
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);
        }

        /// <summary>
        /// Handles the tb balance 1 scroll event.
        /// </summary>
        private void tbBalance1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
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
        /// Media player 1 on error.
        /// </summary>
        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmError.AppendText(e.Message + Environment.NewLine);
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
