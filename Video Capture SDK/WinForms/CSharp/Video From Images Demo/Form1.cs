namespace Video_From_Images_Demo
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    using VisioForge.Shared.MFP;
    using VisioForge.Types;
    using VisioForge.Types.OutputFormat;
    using VisioForge.Types.Sources;

    public partial class Form1 : Form
    {
        private List<Bitmap> _images = new List<Bitmap>();

        private int _imageWidth;

        private int _imageHeight;

        private Rectangle _imageRect;

        private long _frameDuration;

        private string[] IMAGE_SEARCH_PATTERN = { "*.jpeg", "*.jpg", "*.bmp", "*.png" };

        public Form1()
        {
            InitializeComponent();
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
                                 Mode = VFScreenCaptureMode.Color
                             };
            VideoCapture1.Screen_Capture_Source = source;

            VideoCapture1.Audio_PlayAudio = false;
            VideoCapture1.Audio_RecordAudio = false;

            VideoCapture1.Mode = VFVideoCaptureMode.ScreenCapture;
            VideoCapture1.Output_Format = new VFMP4v8v10Output();
            VideoCapture1.Output_Filename = edOutputFile.Text;

            VideoCapture1.Debug_Mode = cbDebug.Checked;

            await VideoCapture1.StartAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " (SDK v" + VideoCapture1.SDK_Version + ", " + VideoCapture1.SDK_State + ")";
            edOutputFile.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\" + "output.mp4";
            VideoCapture1.Debug_Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\";
        }

        private void VideoCapture1_OnVideoFrameBitmap(object sender, VideoFrameBitmapEventArgs e)
        {
            using (var grf = Graphics.FromImage(e.Frame))
            {
                var dur = e.StartTime.TotalMilliseconds / _frameDuration;
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
    }
}
