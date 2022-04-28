using System;
using System.Windows.Forms;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    public partial class Form1 : Form
    {
        private RTSPPlayEngine[] _engines = new RTSPPlayEngine[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            cbCameraIndex.SelectedIndex = 0;
        }

        private IVideoView GetVideoViewByIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return videoView1;
                case 1:
                    return videoView2;
                case 2:
                    return videoView3;
                case 3:
                    return videoView4;
                case 4:
                    return videoView5;
                case 5:
                    return videoView6;
                case 6:
                    return videoView7;
                case 7:
                    return videoView8;
                case 8:
                    return videoView9;
                default:
                    return null;
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            int id = cbCameraIndex.SelectedIndex;
            if (_engines[id] != null)
            {
                _engines[id].Stop();
                _engines[id].Dispose();
                _engines[id] = null;
            }

            _engines[id] = new RTSPPlayEngine(edURL.Text, edLogin.Text, edPassword.Text, GetVideoViewByIndex(id), cbAudioEnabled.Checked);
            _engines[id].Start();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            int id = cbCameraIndex.SelectedIndex;
            if (_engines[id] != null)
            {
                _engines[id].Stop();
                _engines[id].Dispose();
                _engines[id] = null;
            }
        }

        private void cbCameraIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = cbCameraIndex.SelectedIndex;
            if (_engines[id] != null)
            {
                edURL.Text = _engines[id].URL;
                edLogin.Text = _engines[id].Login;
                edPassword.Text = _engines[id].Password;
                cbAudioEnabled.Checked = _engines[id].AudioEnabled;
            }
            else
            {
                edURL.Text = "";
                edLogin.Text = "";
                edPassword.Text = "";
                cbAudioEnabled.Checked = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < _engines.Length; i++)
            {
                _engines[i]?.Dispose();
                _engines[i] = null;
            }
        }
    }
}
