using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Diagnostics;

using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.X;
using VisioForge.Core.FaceAI;
using VisioForge.Core.UI.WPF.Dialogs.Sources;
using VisioForge.Core;
using System.IO;

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

        /// <summary>
        /// Handles the bt select images known click event.
        /// </summary>
        private void btSelectImagesKnown_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                edImagesKnown.Text = dialog.SelectedPath;
            }
        }

        /// <summary>
        /// Handles the bt select images detect click event.
        /// </summary>
        private void btSelectImagesDetect_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                edImagesToDetect.Text = dialog.SelectedPath;
            }
        }

        /// <summary>
        /// Find known faces in images.
        /// </summary>
        private async Task FindKnownFacesInImages()
        {
            if (!Directory.Exists(edImagesKnown.Text) || !Directory.Exists(edImagesToDetect.Text))
            {
                MessageBox.Show("Please select both folders with images.");
                return;
            }

            _sw = Stopwatch.StartNew();

            // load known faces
            var files = System.IO.Directory.GetFiles(edImagesKnown.Text);
            await _core.AddKnownPersonsAsync(files);

            // load images to detect (JPEG, PNG, BMP)
            var exts = new string[] { ".jpg", ".png", ".bmp", "*.jpeg" };
            files = Directory.GetFiles(edImagesToDetect.Text, "*.*", SearchOption.AllDirectories)
                .Where(s => exts.Contains(Path.GetExtension(s).ToLower())).ToArray();

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

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Find known faces in video file.
        /// </summary>
        private async Task FindKnownFacesInVideoFile()
        {
            if (!Directory.Exists(edImagesKnown.Text) || !Directory.Exists(edImagesToDetect.Text))
            {
                MessageBox.Show("Please select both folders with images.");
                return;
            }

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

        /// <summary>
        /// Handles the video frame source on stop event.
        /// </summary>
        private void _videoFrameSource_OnStop(object sender, EventArgs e)
        {
            _sw.Stop();

            Dispatcher.Invoke(() =>
            {
                lbResults.Items.Add($"Elapsed: {_sw.ElapsedMilliseconds} ms");
            });
        }

        /// <summary>
        /// Video frame source on new frame.
        /// </summary>
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

        /// <summary>
        /// Find known faces in webcam.
        /// </summary>
        private async Task FindKnownFacesInWebcam()
        {
            if (!Directory.Exists(edImagesKnown.Text))
            {
                MessageBox.Show("Please select the folder with images of known persons.");
                return;
            }

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

        /// <summary>
        /// Path to the local face database file.
        /// </summary>
        private static readonly string _dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "faces.bin");

        /// <summary>
        /// Handles the bt test load click event.
        /// </summary>
        private void btTestLoad_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(_dbPath))
            {
                MessageBox.Show("There is no saved database yet. Use Test save to create one.");
                return;
            }

            try
            {
                _db = FaceRecognitionDB.Load(_dbPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot read the database at {_dbPath}: {ex.Message}");
                return;
            }

            foreach (var person in _db.Persons)
            {
                Debug.WriteLine($"Person: {person}");
            }
        }

        /// <summary>
        /// Handles the bt test save click event.
        /// </summary>
        private async void btTestSave_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(edImagesKnown.Text))
            {
                MessageBox.Show("Please select the folder with images of known persons.");
                return;
            }

            var files = Directory.GetFiles(edImagesKnown.Text);
            if (files.Length == 0)
            {
                MessageBox.Show("The selected folder contains no images.");
                return;
            }

            try
            {
                await _core.AddKnownPersonsAsync(files);

                _db.Persons.AddRange(_core.KnownPersons);

                Directory.CreateDirectory(Path.GetDirectoryName(_dbPath));
                _db.Save(_dbPath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // We have to initialize the engine on start
                Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                this.IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                this.IsEnabled = true;
                Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}
