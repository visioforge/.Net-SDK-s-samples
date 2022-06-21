using System;
using System.Windows.Forms;
using VisioForge.Core.GStreamer.Helpers;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaInfoGST;
using VisioForge.Core.Types;
using VisioForge.Core.Types.MediaPlayer.GST;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    public partial class Form1 : Form
    {
        private IPlayEngine[] _engines = new IPlayEngine[9];

        private Tuple<string, string>[] _hwDecoders;

        public Form1()
        {
            InitializeComponent();

            // We have to initialize the engine on start
            MediaBlocksPipeline.Init();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            cbCameraIndex.SelectedIndex = 0;
            edURL.Text = "rtsp://192.168.50.64:554/Streaming/Channels/101?transportmode=unicast&profile=Profile_1";

            // HW decoders
            cbGPUDecoder.Items.Add("None");

            _hwDecoders = MediaBlocksPipeline.GetHardwareDecoders(new[] { "H264", "H265", "HEVC", "H.264", "H.265" });
            foreach (var item in _hwDecoders)
            {
                cbGPUDecoder.Items.Add(item.Item2.Replace("Direct3D11/DXVA", ""));
            }

            cbGPUDecoder.SelectedIndex = 0;

            if (cbGPUDecoder.Items.Count > 1)
            {
                cbGPUDecoder.Enabled = true;
                cbUseGPU.Enabled = true;
            }
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

        private async void btStart_Click(object sender, EventArgs e)
        {
            edLog.Text = string.Empty;

            int id = cbCameraIndex.SelectedIndex;
            if (_engines[id] != null)
            {
                await _engines[id].StopAsync();
                _engines[id].Dispose();
                _engines[id] = null;
            }

            if (cbUseMJPEG.Checked)
            {
                _engines[id] = new HTTPPlayEngine(edURL.Text, edLogin.Text, edPassword.Text, GetVideoViewByIndex(id), cbAudioEnabled.Checked);
            }
            else
            {
                var rtspSettings = new RTSPSourceSettings(new Uri(edURL.Text), cbAudioEnabled.Checked)
                {
                    Login = edLogin.Text,
                    Password = edPassword.Text,
                    UseGPUDecoder = cbUseGPU.Checked,
                    CompatibilityMode = cbCompatibilityMode.Checked
                };

                if (cbGPUDecoder.SelectedIndex > 0)
                {
                    rtspSettings.CustomVideoDecoder = _hwDecoders[cbGPUDecoder.SelectedIndex - 1].Item1;
                }

                _engines[id] = new RTSPPlayEngine(rtspSettings, GetVideoViewByIndex(id));
            }

            _engines[id].OnError += Engine_OnError;

            await _engines[id].StartAsync();
        }

        private void Engine_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
            {
                edLog.Text += e.Message + Environment.NewLine;
            }));
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            int id = cbCameraIndex.SelectedIndex;
            if (_engines[id] != null)
            {
                await _engines[id].StopAsync();

                _engines[id].OnError -= Engine_OnError;
                _engines[id].Dispose();
                _engines[id] = null;
            }

            GetVideoViewByIndex(id).CallRefresh();
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
