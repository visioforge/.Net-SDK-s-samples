namespace Video_From_Images_Demo
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using VisioForge.Core.VideoCapture;
    using VisioForge.Core.DirectShow.Helpers;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.Output;
    using VisioForge.Core.Types.VideoCapture;
    using VisioForge.Core.Helpers;

    public partial class Form1 : Form
    {
        private List<Bitmap> _images = new List<Bitmap>();

        private int _imageWidth;

        private int _imageHeight;

        private Rectangle _imageRect;

        private long _frameDuration;

        private string[] IMAGE_SEARCH_PATTERN = { "*.jpeg", "*.jpg", "*.bmp", "*.png" };

        private VideoCaptureCore VideoCapture1;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateEngine()
        {
            VideoCapture1 = new VideoCaptureCore(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
            VideoCapture1.OnVideoFrameBitmap += VideoCapture1_OnVideoFrameBitmap;
        }

        private void DestroyEngine()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;
                VideoCapture1.OnVideoFrameBitmap -= VideoCapture1_OnVideoFrameBitmap;

                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }
        }

        private bool LoadImages()
        {
            if (!Directory.Exists(edInputFolder.Text))
            {
                MessageBox.Show(this, "Folder with images does not exists!");
                return false;
            }

            var files = new List<string>();
            foreach (var ext in this.IMAGE_SEARCH_PATTERN)
            {
                var lst = Directory.GetFiles(edInputFolder.Text, ext);
                if (lst.Length > 0)
                {
                    files.AddRange(lst);
                }
            }

            if (files.Count == 0)
            {
                MessageBox.Show(this, "Images not found!");
                return false;
            }

            _images.Clear();
            _imageWidth = Convert.ToInt32(edVideoWidth.Text);
            _imageHeight = Convert.ToInt32(edVideoHeight.Text);
            _imageRect = new Rectangle(0, 0, _imageWidth, _imageHeight);
            _frameDuration = Convert.ToInt64(edImageDuration.Text);

            foreach (var file in files)
            {
                var bmp = new Bitmap(file);
                var res = bmp.ResizeImage(_imageWidth, _imageHeight);
                bmp.Dispose();

                _images.Add(res);
            }

            return true;
        }

        private void btSelectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                edInputFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btSelectOutputFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                edOutputFile.Text = saveFileDialog1.FileName;
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            edLog.Text = string.Empty;

            if (!LoadImages())
            {
                return;
            }

            var source = new ScreenCaptureSourceSettings
            {
                Left = 0,
                Right = _imageWidth,
                Top = 0,
                Bottom = _imageHeight,
                FrameRate = Convert.ToInt32(edVideoFrameRate.Text),
                Mode = ScreenCaptureMode.Color
            };
            VideoCapture1.Screen_Capture_Source = source;

            VideoCapture1.Audio_PlayAudio = false;
            VideoCapture1.Audio_RecordAudio = false;

            VideoCapture1.Mode = VideoCaptureMode.ScreenCapture;
            VideoCapture1.Output_Format = new MP4Output();
            VideoCapture1.Output_Filename = edOutputFile.Text;

            VideoCapture1.Debug_Mode = cbDebug.Checked;

            await VideoCapture1.StartAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{VideoCapture1.SDK_Version()})";
            edOutputFile.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        private void VideoCapture1_OnVideoFrameBitmap(object sender, VideoFrameBitmapEventArgs e)
        {
            using (var grf = Graphics.FromImage(e.Frame))
            {
                var dur = e.Timestamp.TotalMilliseconds / _frameDuration;
                var idx = dur % _images.Count;

                grf.DrawImage(_images[(int)idx], _imageRect, _imageRect, GraphicsUnit.Pixel);
                e.UpdateData = true;
            }
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await VideoCapture1.StopAsync();
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       edLog.Text += e.Message;
                                   }));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }
    }
}
