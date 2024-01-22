using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaInfoReaderX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.MediaPlayer;
using System.Linq;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    public partial class Form1 : Form
    {
        private IPlayEngine[] _playEngines = new IPlayEngine[9];

        private RTSPRecordEngine[] _recordEngines = new RTSPRecordEngine[9];

        private List<Tuple<string, string>> _customDecoders;

        public Form1()
        {
            InitializeComponent();

            // We have to initialize the engine on start
            VisioForgeX.InitSDK();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            cbCameraIndex.SelectedIndex = 0;
            edURL.Text = "rtsp://admin:dancer23@192.168.50.64:554/Streaming/Channels/101?transportmode=unicast&profile=Profile_1";
            edFilename.Text = @"c:\vf\outputxx.ts";

            // HW decoders
            cbGPUDecoder.Items.Add("None");

            var hwDecoders = MediaBlocksPipeline.GetHardwareDecoders(new[] { "H264", "H265", "HEVC", "H.264", "H.265" });
            var swH264Decoders = MediaBlocksPipeline.GetSoftwareH264Decoders();
            var swH265Decoders = MediaBlocksPipeline.GetSoftwareH265Decoders();

            _customDecoders = new List<Tuple<string, string>>();
            _customDecoders.AddRange(hwDecoders);
            _customDecoders.AddRange(swH264Decoders);
            _customDecoders.AddRange(swH265Decoders);

            foreach (var item in _customDecoders)
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
            if (_playEngines[id] != null)
            {
                await _playEngines[id].StopAsync();
                await _playEngines[id].DisposeAsync();
                _playEngines[id] = null;
            }

            if (cbUseMJPEG.Checked)
            {
                _playEngines[id] = new HTTPPlayEngine();
                await ((HTTPPlayEngine)_playEngines[id]).CreateAsync(edURL.Text, edLogin.Text, edPassword.Text, GetVideoViewByIndex(id), cbAudioEnabled.Checked);
            }
            else
            {
                var rtspSettings = new RTSPSourceSettings(new Uri(edURL.Text), cbAudioEnabled.Checked)
                {
                    Login = edLogin.Text,
                    Password = edPassword.Text,
                    UseGPUDecoder = cbUseGPU.Checked,
                    CompatibilityMode = cbCompatibilityMode.Checked,
                    EnableRAWVideoAudioEvents = cbRAWEvents.Checked
                };

                if (cbGPUDecoder.SelectedIndex > 0)
                {
                    rtspSettings.CustomVideoDecoder = _customDecoders[cbGPUDecoder.SelectedIndex - 1].Item1;
                }

                var engine = new RTSPPlayEngine(rtspSettings, GetVideoViewByIndex(id));
                _playEngines[id] = engine;

                if (rtspSettings.EnableRAWVideoAudioEvents)
                {
                    engine.OnAudioRAWFrame += Engine_OnAudioRAWFrame;
                    engine.OnVideoRAWFrame += Engine_OnVideoRAWFrame;
                }
            }

            _playEngines[id].OnError += Engine_OnError;

            _rawVideoFrameReceived = false;
            _rawAudioFrameReceived = false;

            await _playEngines[id].StartAsync();
        }

        bool _rawVideoFrameReceived;

        bool _rawAudioFrameReceived;

        private void Engine_OnVideoRAWFrame(object sender, VisioForge.Core.Types.Events.DataFrameEventArgs e)
        {
            if (_rawVideoFrameReceived)
            {
                return;
            }

            Invoke((Action)(() =>
            {
                edLog.Text += $"RAW video frame received" + Environment.NewLine;
                _rawVideoFrameReceived = true;
            }));
        }

        private void Engine_OnAudioRAWFrame(object sender, VisioForge.Core.Types.Events.DataFrameEventArgs e)
        {
            if (_rawAudioFrameReceived)
            {
                return;
            }

            Invoke((Action)(() =>
            {
                edLog.Text += $"RAW audio frame received" + Environment.NewLine;
                _rawAudioFrameReceived = true;
            }));
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
            if (_playEngines[id] != null)
            {
                await _playEngines[id].StopAsync();

                _playEngines[id].OnError -= Engine_OnError;
                await _playEngines[id].DisposeAsync();
                _playEngines[id] = null;
            }

            GetVideoViewByIndex(id).CallRefresh();
        }

        private void cbCameraIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = cbCameraIndex.SelectedIndex;
            if (_playEngines[id] != null)
            {
                edURL.Text = _playEngines[id].URL;
                edLogin.Text = _playEngines[id].Login;
                edPassword.Text = _playEngines[id].Password;
                cbAudioEnabled.Checked = _playEngines[id].AudioEnabled;
                edFilename.Text = _recordEngines[id].Filename;
                cbReencodeAudio.Checked = _recordEngines[id].ReencodeAudio;
            }
            else
            {
                edURL.Text = "";
                edLogin.Text = "";
                edPassword.Text = "";
                cbAudioEnabled.Checked = false;
                edFilename.Text = "";
                cbReencodeAudio.Checked = true;
            }
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < _playEngines.Length; i++)
            {
                if (_playEngines[i] != null)
                {
                    await _playEngines[i].DisposeAsync();
                    _playEngines[i] = null;
                }
            }

            VisioForgeX.DestroySDK();
        }

        private async void btReadInfo_Click(object sender, EventArgs e)
        {
            var infoReader = new MediaInfoReaderX();

            var uriBuilder = new UriBuilder(edURL.Text);
            if (!string.IsNullOrEmpty(edLogin.Text) && !string.IsNullOrEmpty(edPassword.Text))
            {
                uriBuilder.UserName = edLogin.Text;
                uriBuilder.Password = edPassword.Text;
            }

            var res = await infoReader.OpenAsync(uriBuilder.Uri);
            if (res)
            {
                if (infoReader.Info.VideoStreams.Count > 0)
                {
                    edLog.Text += "Video streams: " + Environment.NewLine;
                    foreach (var item in infoReader.Info.VideoStreams)
                    {
                        edLog.Text += $"  {item.Codec} {item.Width}x{item.Height}" + Environment.NewLine;
                    }
                }

                edLog.Text += Environment.NewLine;

                if (infoReader.Info.AudioStreams.Count > 0)
                {
                    edLog.Text += "Audio streams: " + Environment.NewLine;
                    foreach (var item in infoReader.Info.AudioStreams)
                    {
                        edLog.Text += $"  {item.Codec} {item.Channels} ch {item.SampleRate} Hz" + Environment.NewLine;
                    }
                }
            }
        }

        private async void btStartRecord_Click(object sender, EventArgs e)
        {
            edLog.Text = string.Empty;

            int id = cbCameraIndex.SelectedIndex;

            if (_recordEngines[id] != null)
            {
                await _recordEngines[id].StopAsync();
                await _recordEngines[id].DisposeAsync();
                _recordEngines[id] = null;
            }

            var rtspSettings = new RTSPRAWSourceSettings(new Uri(edURL.Text), cbAudioEnabled.Checked)
            {
                Login = edLogin.Text,
                Password = edPassword.Text,
            };

            _recordEngines[id] = new RTSPRecordEngine();
            _recordEngines[id].OnError += Engine_OnError;
            _recordEngines[id].Filename = edFilename.Text;
            _recordEngines[id].ReencodeAudio = cbReencodeAudio.Checked;
            _recordEngines[id].MP4 = rbMP4Output.Checked;

            await _recordEngines[id].StartAsync(rtspSettings);
        }

        private async void btStopRecord_Click(object sender, EventArgs e)
        {
            int id = cbCameraIndex.SelectedIndex;

            if (_recordEngines[id] != null)
            {
                await _recordEngines[id].StopAsync();

                _recordEngines[id].OnError -= Engine_OnError;
                await _recordEngines[id].DisposeAsync();
                _recordEngines[id] = null;
            }
        }

        private void btONVIF_Click(object sender, EventArgs e)
        {
            var disc = new ONVIFDiscovery();
            disc.ShowDialog();
            disc.Dispose();
        }
    }
}
