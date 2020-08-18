using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Multiple_IP_Cameras_Demo_WPF
{
    using System.IO;

    using VisioForge.Controls.UI.WPF;
    using VisioForge.Types;
    using VisioForge.Types.OutputFormat;
    using VisioForge.Types.Sources;

    using Path = System.Windows.Shapes.Path;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VFMP4v8v10Output mp4Output = new VFMP4v8v10Output();

        public MainWindow()
        {
            InitializeComponent();
        }

        private Task StartCamera(string url, bool preview, VideoCapture videoCapture, int index)
        {
            // source
            videoCapture.IP_Camera_Source = new IPCameraSourceSettings { URL = url };

            switch (cbEngine.SelectedIndex)
            {
                case 0:
                    videoCapture.IP_Camera_Source.Type = VFIPSource.Auto_VLC;
                    break;
                case 1:
                    videoCapture.IP_Camera_Source.Type = VFIPSource.Auto_FFMPEG;
                    break;
                case 2:
                    videoCapture.IP_Camera_Source.Type = VFIPSource.Auto_LAV;
                    videoCapture.IP_Camera_Source.LAV_GPU_Use = false;
                    break;
                case 3:
                    videoCapture.IP_Camera_Source.Type = VFIPSource.Auto_LAV;
                    videoCapture.IP_Camera_Source.LAV_GPU_Use = true;
                    videoCapture.IP_Camera_Source.LAV_GPU_Mode = VFMediaPlayerSourceGPUDecoder.DXVA2Native;
                    break;
                case 4:
                    videoCapture.IP_Camera_Source.Type = VFIPSource.RTSP_Live555;
                    break;
                case 5:
                    videoCapture.IP_Camera_Source.Type = VFIPSource.HTTP_FFMPEG;
                    break;
                case 6:
                    videoCapture.IP_Camera_Source.Type = VFIPSource.MMS_WMV;
                    break;
                case 7:
                    videoCapture.IP_Camera_Source.Type = VFIPSource.RTSP_UDP_FFMPEG;
                    break;
                case 8:
                    videoCapture.IP_Camera_Source.Type = VFIPSource.RTSP_TCP_FFMPEG;
                    break;
                case 9:
                    videoCapture.IP_Camera_Source.Type = VFIPSource.RTSP_HTTP_FFMPEG;
                    break;
                case 10:
                    videoCapture.IP_Camera_Source.Type = VFIPSource.HTTP_MJPEG_LowLatency;
                    break;
                case 11:
                    videoCapture.IP_Camera_Source.Type = VFIPSource.RTSP_LowLatency;
                    videoCapture.IP_Camera_Source.RTSP_LowLatency_UseUDP = false;
                    break;
                case 12:
                    videoCapture.IP_Camera_Source.Type = VFIPSource.RTSP_LowLatency;
                    videoCapture.IP_Camera_Source.RTSP_LowLatency_UseUDP = true;
                    break;
            }

            videoCapture.Audio_RecordAudio = false;
            videoCapture.Audio_PlayAudio = false;

            if (preview)
            {
                videoCapture.Mode = VFVideoCaptureMode.IPPreview;
            }
            else
            {
                videoCapture.Mode = VFVideoCaptureMode.IPCapture;

                videoCapture.Output_Filename = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), $@"VisioForge\output_{DateTime.Now:yy-MM-dd hh_mm_ss}_{index}.mp4"); 
                videoCapture.Output_Format = mp4Output;
            }

            videoCapture.Debug_Mode = cbDebug.IsChecked == true;
            if (cbDebug.IsChecked == true)
            {
                videoCapture.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $@"VisioForge\cam_{index}\");
            }

            return videoCapture.StartAsync();
        }

        private async void btStart1_Click(object sender, RoutedEventArgs e)
        {
            await StartCamera(edURL1.Text, rbPreview1.IsChecked == true, videoCapture1, 1);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title += " (SDK v" + videoCapture1.SDK_Version + ", " + videoCapture1.SDK_State + ")";
        }

        private async void btStop1_Click(object sender, RoutedEventArgs e)
        {
            await videoCapture1.StopAsync();
        }

        private void videoCapture_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
                                                   {
                                                       edLog.Text += e.Message + Environment.NewLine;
                                                   }));
        }

        private async void btStart2_Click(object sender, RoutedEventArgs e)
        {
            await StartCamera(edURL2.Text, rbPreview2.IsChecked == true, videoCapture2, 2);
        }

        private async void btStop2_Click(object sender, RoutedEventArgs e)
        {
            await videoCapture2.StopAsync();
        }

        private async void btStart3_Click(object sender, RoutedEventArgs e)
        {
            await StartCamera(edURL3.Text, rbPreview3.IsChecked == true, videoCapture3, 3);
        }

        private async void btStop3_Click(object sender, RoutedEventArgs e)
        {
            await videoCapture3.StopAsync();
        }

        private async void btStart4_Click(object sender, RoutedEventArgs e)
        {
            await StartCamera(edURL4.Text, rbPreview4.IsChecked == true, videoCapture4, 4);
        }

        private async void btStop4_Click(object sender, RoutedEventArgs e)
        {
            await videoCapture4.StopAsync();
        }
    }
}
