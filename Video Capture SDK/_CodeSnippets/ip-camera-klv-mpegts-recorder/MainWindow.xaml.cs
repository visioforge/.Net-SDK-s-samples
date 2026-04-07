using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.FFMPEGEXE;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.VideoCapture;

namespace ip_camera_klv_mpegts_recorder
{
    public partial class MainWindow : Window, IDisposable
    {
        private VideoCaptureCore _videoCapture;
        private int _klvPacketCount;

        private bool _disposed;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            edOutput.Text = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
                    "output.ts");

            _videoCapture = await VideoCaptureCore.CreateAsync(VideoView1 as IVideoView);
            _videoCapture.OnError += VideoCapture_OnError;
            _videoCapture.OnDataFrameBuffer += VideoCapture_OnDataFrameBuffer;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            // Configure IP camera source (UDP MPEGTS via FFMPEG engine)
            _videoCapture.IP_Camera_Source = new IPCameraSourceSettings
            {
                URL = new Uri(edURL.Text),
                Type = IPSourceEngine.Auto_FFMPEG,
                AudioCapture = false
            };

            _videoCapture.Audio_PlayAudio = false;
            _videoCapture.Audio_RecordAudio = false;
           
            if (cbOutputMode.SelectedIndex == 0)
            {
                _videoCapture.Mode = VideoCaptureMode.IPCapture;

                // MPEG-TS file output via MF Mux
                _videoCapture.Output_Filename = edOutput.Text;
                _videoCapture.Output_Format = new MPEGTSOutput { KLVEnabled = true };
                _videoCapture.Network_Streaming_Enabled = false;
            }
            else
            {
                _videoCapture.Mode = VideoCaptureMode.IPPreview;

                // UDP streaming via ffmpeg.exe pipe
                _videoCapture.Network_Streaming_Enabled = true;
                _videoCapture.Network_Streaming_Format = NetworkStreamingFormat.UDP_FFMPEG_EXE;
                _videoCapture.Network_Streaming_URL = edOutput.Text;
                _videoCapture.Network_Streaming_Audio_Enabled = false;
                _videoCapture.Network_Streaming_Output = new FFMPEGEXEOutput
                {
                    OutputMuxer = OutputMuxer.MPEGTS,
                    KLVEnabled = true,
                    UsePipe = true,
                    Video = new OpenH264Settings
                    {
                        RateControl = OpenH264RateControl.Bitrate,
                        Bitrate = 2_000_000,
                        Profile = OpenH264Profile.ConstrainedBaseline,
                    },
                };
            }

            tbKLV.Clear();

            await _videoCapture.StartAsync();

            btStart.IsEnabled = false;
            btStop.IsEnabled = true;
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await _videoCapture.StopAsync();

            btStart.IsEnabled = true;
            btStop.IsEnabled = false;
        }

        private void cbOutputMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (edOutput == null)
            {
                return;
            }

            if (cbOutputMode.SelectedIndex == 0)
            {
                edOutput.Text = "output.ts";
            }
            else
            {
                edOutput.Text = "udp://239.1.1.1:5004?pkt_size=1316";
            }
        }

        private void VideoCapture_OnDataFrameBuffer(object sender, DataFrameEventArgs e)
        {
            if (e.Frame.DataType != DataFrameType.KLV)
            {
                return;
            }

            _klvPacketCount++;
            Dispatcher.BeginInvoke(new Action(() =>
            {
                tbKLV.Text = $"KLV packets received: {_klvPacketCount}";
            }));
        }

        private void VideoCapture_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                tbKLV.AppendText($"[ERROR] {e.Message}\n");
                tbKLV.ScrollToEnd();
            }));
        }

        private bool _closing;

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_closing)
            {
                return;
            }

            e.Cancel = true;
            _closing = true;

            if (_videoCapture != null)
            {
                await _videoCapture.StopAsync();
            }

            Dispose();
            Application.Current.Shutdown();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _videoCapture?.Dispose();
                _videoCapture = null;
                _disposed = true;
            }
        }
    }
}
