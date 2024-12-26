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

using System.Diagnostics;

using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.X;
using VisioForge.Core.FaceAI;
using VisioForge.Core.UI.WPF.Dialogs.Sources;
using VisioForge.Core;

namespace Face_AI_MB_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FaceRecognitionCore _core;

        private Stopwatch _sw;

        private VideoFrameSource _videoFrameSource;

        public MainWindow()
        {
            InitializeComponent();

            _core = new FaceRecognitionCore(System.AppDomain.CurrentDomain.BaseDirectory);
        }

        private void btSelectImagesKnown_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                edImagesKnown.Text = dialog.SelectedPath;
            }
        }

        private void btSelectImagesDetect_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                edImagesToDetect.Text = dialog.SelectedPath;
            }
        }

        private async Task FindKnownFacesInImages()
        {
            _sw = Stopwatch.StartNew();

            // load known faces
            var files = System.IO.Directory.GetFiles(edImagesKnown.Text);
            await _core.AddKnownPersonsAsync(files);

            // load images to detect
            files = System.IO.Directory.GetFiles(edImagesToDetect.Text);
            var unknownPersons = new List<Person>();
            foreach (var file in files)
            {
                var persons = await Person.LoadFromImageFileAsync(_core, file);
                if (persons != null)
                {
                    unknownPersons.AddRange(persons);
                }
            }

            // detect
            foreach (var person in unknownPersons)
            {
                var knownPerson = await _core.DetectAsync(person);
                if (knownPerson != null)
                {
                    lbResults.Items.Add($"{person.Name} is {knownPerson.Name}");
                }
                else
                {
                    lbResults.Items.Add($"{person.Name} is unknown");
                }
            }

            _sw.Stop();

            lbResults.Items.Add($"Elapsed: {_sw.ElapsedMilliseconds} ms");
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            // clear
            lbResults.Items.Clear();
            _core.Clear();

            switch (cbMode.SelectedIndex)
            {
                case 0:
                    await FindKnownFacesInImages();
                    break;
                case 1:
                    await FindKnownFacesInVideoFile();
                    break;
                case 2:
                    await FindKnownFacesInWebcam();
                    break;
            }
        }

        private async Task FindKnownFacesInVideoFile()
        {
            _sw = Stopwatch.StartNew();

            // load known faces
            var files = System.IO.Directory.GetFiles(edImagesKnown.Text);
            await _core.AddKnownPersonsAsync(files);

            // process video file
            files = System.IO.Directory.GetFiles(edImagesToDetect.Text, "*.mp4");
            if (files.Length == 0)
            {
                MessageBox.Show("No MP4 video files found.");
                return;
            }

            _videoFrameSource?.Dispose();
            _videoFrameSource = new VideoFrameSource();
            _videoFrameSource.OnNewFrame += _videoFrameSource_OnNewFrame;
            _videoFrameSource.OnStop += _videoFrameSource_OnStop;
            _videoFrameSource.FramesToSkip = 24;

            await _videoFrameSource.StartAsync(files[0], VideoFormatX.RGB, new VisioForge.Core.Types.Size(320, 180));      
        }

        private void _videoFrameSource_OnStop(object sender, EventArgs e)
        {
            _sw.Stop();

            Dispatcher.Invoke(() =>
            {
                lbResults.Items.Add($"Elapsed: {_sw.ElapsedMilliseconds} ms");
            });
        }

        private void _videoFrameSource_OnNewFrame(object sender, VideoFrameX e)
        {
            var sw = Stopwatch.StartNew();

            var knownPersons = _core.Detect(e);
            if (knownPersons != null && knownPersons.Length > 0)
            {
                foreach (var person in knownPersons)
                {
                    Debug.WriteLine($"Person found: {person.Name}. Timestamp: {e.Timestamp}.");
                }
            }
            else
            {
                Debug.WriteLine($"Person is unknown. Timestamp: {e.Timestamp}.");
            }

            sw.Stop();

            Debug.WriteLine($"Frame processing time: {sw.ElapsedMilliseconds} ms");
        }

        private async Task FindKnownFacesInWebcam()
        {
            _sw = Stopwatch.StartNew();

            // load known faces
            var files = System.IO.Directory.GetFiles(edImagesKnown.Text);
            await _core.AddKnownPersonsAsync(files);

            // select camera
            var dlg = new VideoCaptureSourceDialog();
            if (dlg.ShowDialog() != true)
            {
                MessageBox.Show("No camera selected.");
                return;
            }

            // process    
            _videoFrameSource?.Dispose();
            _videoFrameSource = new VideoFrameSource();
            _videoFrameSource.OnNewFrame += _videoFrameSource_OnNewFrame;
            _videoFrameSource.OnStop += _videoFrameSource_OnStop;
            _videoFrameSource.FramesToSkip = 24;

            await _videoFrameSource.StartAsync(videoView1, await dlg.GetDeviceSettingsAsync(), VideoFormatX.RGB, new VisioForge.Core.Types.Size(320, 180));
        }

        FaceRecognitionDB _db = new FaceRecognitionDB();

        private void btTestLoad_Click(object sender, RoutedEventArgs e)
        {
            _db = FaceRecognitionDB.Load("c:\\Samples\\FaceAI\\faces.bin");

            foreach (var person in _db.Persons)
            {
                Debug.WriteLine($"Person: {person}");
            }
        }

        private async void btTestSave_Click(object sender, RoutedEventArgs e)
        {
            // load known faces
            var files = System.IO.Directory.GetFiles(edImagesKnown.Text);
            await _core.AddKnownPersonsAsync(files);

            _db.Persons.AddRange(_core.KnownPersons);

            _db.Save("c:\\Samples\\FaceAI\\faces.bin");
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}
