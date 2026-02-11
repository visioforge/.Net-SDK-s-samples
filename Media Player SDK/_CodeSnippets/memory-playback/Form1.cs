using System;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core;
using VisioForge.Core.MediaInfo;
using VisioForge.Core.MediaPlayer;
using VisioForge.Core.Types;
using VisioForge.Core.Types.MediaPlayer;
using System.Diagnostics;

namespace memory_playback
{
    /// <summary>
    /// Memory playback demo form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The media player.
        /// </summary>
        MediaPlayerCore _player;

        /// <summary>
        /// The managed stream.
        /// </summary>
        private ManagedIStream _stream;

        /// <summary>
        /// The memory stream.
        /// </summary>
        private MemoryStream _memoryStream;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Select file using dialog, read into byte array and play.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btOpen_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (_player != null)
                    {
                        await _player.StopAsync();
                        _player.Dispose();
                    }

                    _memoryStream?.Dispose();

                    // WARNING: ReadAllBytes loads the entire file into memory. For large video files, consider using FileStream instead.
                    var bytes = File.ReadAllBytes(dlg.FileName);
                    _player = new MediaPlayerCore(videoView1);

                    _memoryStream = new MemoryStream(bytes);
                    _stream = new ManagedIStream(_memoryStream);

                    // read info about file into memory
                    MediaInfoReader.GetStreamAvailabilityFromMemoryStream(_player.GetContext(), _stream, _memoryStream.Length, out var videoAvailable, out var audioAvailable);

                    _player.Source_MemoryStream = new MemoryStreamSource(_stream, _memoryStream.Length);

                    _player.Source_Mode = MediaPlayerSourceMode.Memory_DS;

                    if (audioAvailable)
                    {
                        _player.Audio_PlayAudio = true;
                        _player.Audio_OutputDevice = "Default DirectSound Device";
                    }
                    else
                    {
                        _player.Audio_PlayAudio = false;
                    }

                    if (videoAvailable)
                    {
                        _player.Video_Renderer_SetAuto();
                    }
                    else
                    {
                        _player.Video_Renderer.VideoRenderer = VideoRendererMode.None;
                    }

                    await _player.PlayAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_player != null)
                {
                    await _player.StopAsync();
                    _player.Dispose();
                    _player = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            _memoryStream?.Dispose();
            _memoryStream = null;

            _stream = null;
        }
    }
}
