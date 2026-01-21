using SkiaSharp;
using System;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core;
using VisioForge.Core.MediaInfo;
using VisioForge.Core.MediaPlayer;
using VisioForge.Core.Types;
using VisioForge.Core.Types.MediaPlayer;

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
        /// Handles the form 1 load event.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Select file using dialog, read into byte array and play.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btOpen_Click(object sender, EventArgs e)
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
    }
}