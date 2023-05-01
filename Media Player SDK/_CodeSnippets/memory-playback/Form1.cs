using SkiaSharp;
using System;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core;
using VisioForge.Core.MediaPlayer;
using VisioForge.Core.Types;
using VisioForge.Core.Types.MediaPlayer;

namespace memory_playback
{
    public partial class Form1 : Form
    {
        MediaPlayerCore _player;

        private ManagedIStream _stream;

        private MemoryStream _memoryStream;

        public Form1()
        {
            InitializeComponent();
        }

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

                // specifying settings
                bool video = rbVideoAudio.Checked || rbVideoNoAudio.Checked;
                bool audio = rbVideoAudio.Checked || rbAudio.Checked;
                _player.Source_MemoryStream = new MemoryStreamSource(_stream, video, audio, _memoryStream.Length);

                _player.Source_Mode = MediaPlayerSourceMode.Memory_DS;

                if (audio)
                {
                    _player.Audio_PlayAudio = true;
                    _player.Audio_OutputDevice = "Default DirectSound Device";
                }
                else
                {
                    _player.Audio_PlayAudio = false;
                }

                if (video)
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