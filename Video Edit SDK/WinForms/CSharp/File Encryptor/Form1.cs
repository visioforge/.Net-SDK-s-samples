using System;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core.MediaInfo;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoEdit;
using VisioForge.Core.VideoEdit;

namespace File_Encryptor
{
    public partial class Form1 : Form
    {
        VideoEditCore _videoEdit = new VideoEditCore();

        bool _fastEncrypt = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            Text += $" (SDK v{VideoEditCore.GetVersion()})";

            edOutputFile.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.enc");
            _videoEdit.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            _videoEdit.OnError += _videoEdit_OnError;
            _videoEdit.OnStop += _videoEdit_OnStop;
        }

        private void _videoEdit_OnStop(object sender, VisioForge.Core.Types.Events.StopEventArgs e)
        {
            MessageBox.Show("Complete");
        }

        private void _videoEdit_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
            {
                edLog.Text += e.Message + Environment.NewLine;
            }));
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (!File.Exists(edInputFile.Text))
            {
                MessageBox.Show("Inout file does not exists.");
                return;
            }

            var mediaInfo = new MediaInfoReader();
            mediaInfo.Filename = edInputFile.Text;
            mediaInfo.ReadFileInfo(true);

            // H264 check
            _fastEncrypt = true;
            if (mediaInfo.VideoStreams.Count > 0)
            {
                if (!mediaInfo.VideoStreams[0].Codec.Contains("264"))
                {
                    _fastEncrypt = false;
                }
            }

            // AAC check
            if (mediaInfo.AudioStreams.Count > 0)
            {
                if (!mediaInfo.AudioStreams[0].Codec.ToLowerInvariant().Contains("aac"))
                {
                    _fastEncrypt = false;
                }
            }

            if (cbForceRecompress.Checked)
            {
                _fastEncrypt = false;
            }

            // fast encrypt or reencoding
            if (_fastEncrypt)
            {
                _videoEdit.FastEncrypt_Start(edInputFile.Text, edOutputFile.Text, VisioForge.Core.Types.Output.EncryptionKeyType.String, edKey.Text, true);
            }
            else
            {
                if (mediaInfo.VideoStreams.Count > 0)
                {
                    _videoEdit.Input_AddVideoFile(edInputFile.Text);
                }

                if (mediaInfo.AudioStreams.Count > 0)
                {
                    _videoEdit.Input_AddAudioFile(edInputFile.Text, edInputFile.Text);
                }

                // you can specify settings
                var mp4Output = new MP4Output();
                mp4Output.Encryption = true;
                mp4Output.Encryption_Format = EncryptionFormat.MP4_H264_SW_AAC;
                mp4Output.Encryption_Key = edKey.Text;

                _videoEdit.Output_Format = mp4Output;
                _videoEdit.Output_Filename = edOutputFile.Text;
                _videoEdit.Mode = VideoEditMode.Convert;
                _videoEdit.Audio_Preview_Enabled = false;

                _videoEdit.Video_Renderer.VideoRenderer = VideoRendererMode.None;

                _videoEdit.Start();
            }

            tmProgress.Start();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            tmProgress.Stop();

            if (_fastEncrypt)
            {
                _videoEdit.FastEncrypt_Stop();
            }
            else
            {
                await _videoEdit.StopAsync();
            }
        }

        private void btInputFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edInputFile.Text = openFileDialog1.FileName;
            }
        }

        private void btOutputFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutputFile.Text = saveFileDialog1.FileName;
            }
        }

        private void tmProgress_Tick(object sender, EventArgs e)
        {
            if (_fastEncrypt)
            {
                pbProgress.Value = _videoEdit.FastEncrypt_GetProgress();
            }
            else
            {
                pbProgress.Value = _videoEdit.GetProgress();
            }
        }
    }
}