namespace VisioForge_MMT
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;

    using Microsoft.Win32;

    using VisioForge.Core.VideoFingerPrinting;

    using Classes;
    using VisioForge.Core.Types;
    using System.Windows;
    using Rect = VisioForge.Core.Types.Rect;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// The ignored areas.
        /// </summary>
        private readonly List<Rect> _ignoredAreas = new List<Rect>();

        /// <summary>
        /// The database.
        /// </summary>
        private VFPFingerPrintDB _db;

        /// <summary>
        /// Indicates whether media is currently playing.
        /// </summary>
        private bool _isPlaying;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the bt add broadcast folder click event.
        /// </summary>
        private void btAddBroadcastFolder_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFolderDialog
            {
                InitialDirectory = Settings.LastPath
            };

            bool? result = dlg.ShowDialog(this);

            if (result == true)
            {
                lbBroadcastFolders.Items.Add(dlg.FolderName);
                Settings.LastPath = dlg.FolderName;
            }
        }

        /// <summary>
        /// Handles the bt add ad folder click event.
        /// </summary>
        private void btAddAdFolder_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFolderDialog
            {
                InitialDirectory = Settings.LastPath
            };

            bool? result = dlg.ShowDialog(this);

            if (result == true)
            {
                lbAdFolders.Items.Add(dlg.FolderName);
                Settings.LastPath = dlg.FolderName;
            }
        }

        /// <summary>
        /// Handles the bt clear ads click event.
        /// </summary>
        private void btClearAds_Click(object sender, RoutedEventArgs e)
        {
            lbAdFolders.Items.Clear();
        }

        /// <summary>
        /// Handles the bt clear broadcast click event.
        /// </summary>
        private void btClearBroadcast_Click(object sender, RoutedEventArgs e)
        {
            lbBroadcastFolders.Items.Clear();
        }

        /// <summary>
        /// Error delegate. Uses Dispatcher to safely show message box from any thread.
        /// </summary>
        private void errorDelegate(string error)
        {
            Dispatcher.Invoke(() =>
            {
                MessageBox.Show(this, error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            });
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (cbDebug.IsChecked == true)
            {
                VFPAnalyzer.DebugDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\MMT\\";
            }

            btStart.IsEnabled = false;

            try
            {
                results.Clear();
                lvResults.Items.Refresh();

                lbStatus.Content = "Step 1: Searching video files";

                List<string> adList = new List<string>();
                List<string> broadcastList = new List<string>();

                List<VFPFingerPrint> adVFPList = new List<VFPFingerPrint>();
                List<VFPFingerPrint> broadcastVFPList = new List<VFPFingerPrint>();

                foreach (string item in lbAdFolders.Items)
                {
                    try
                    {
                        bool isDir = (File.GetAttributes(item) & FileAttributes.Directory) == FileAttributes.Directory;
                        if (isDir)
                        {
                            adList.AddRange(FileScanner.SearchVideoInFolder(item));
                        }
                        else
                        {
                            adList.Add(item);
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show($"Path not found: {item}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    catch (DirectoryNotFoundException)
                    {
                        MessageBox.Show($"Directory not found: {item}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }

                foreach (string item in lbBroadcastFolders.Items)
                {
                    try
                    {
                        bool isDir = (File.GetAttributes(item) & FileAttributes.Directory) == FileAttributes.Directory;
                        if (isDir)
                        {
                            broadcastList.AddRange(FileScanner.SearchVideoInFolder(item));
                        }
                        else
                        {
                            broadcastList.Add(item);
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show($"Path not found: {item}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    catch (DirectoryNotFoundException)
                    {
                        MessageBox.Show($"Directory not found: {item}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }

                lbStatus.Content = "Step 2: Getting fingerprints for ads files";

                int progress = 0;
                foreach (string filename in adList)
                {
                    pbProgress.Value = progress;

                    var source = new VFPFingerprintSource(filename);
                    foreach (var area in _ignoredAreas)
                    {
                        source.IgnoredAreas.Add(area);
                    }

                    VFPFingerPrint fp = _db.GetFingerprint(source);

                    if (fp == null)
                    {
                        fp = await VFPAnalyzer.GetSearchFingerprintForVideoFileAsync(source, errorDelegate);

                        if (fp == null)
                        {
                            MessageBox.Show("Unable to get fingerprint for the video file: " + filename);
                        }
                        else
                        {
                            _db.Items.Add(fp);
                            AddDBItem(fp);
                        }
                    }

                    // Only add non-null fingerprints to avoid NullReferenceException during search
                    if (fp != null)
                    {
                        adVFPList.Add(fp);
                    }

                    progress += adList.Count > 0 ? 100 / adList.Count : 0;
                }

                pbProgress.Value = 100;

                lbStatus.Content = "Step 3: Getting fingerprints for broadcast files";
                progress = 0;
                foreach (string filename in broadcastList)
                {
                    pbProgress.Value = progress;

                    var source = new VFPFingerprintSource(filename);
                    foreach (var area in _ignoredAreas)
                    {
                        source.IgnoredAreas.Add(area);
                    }

                    VFPFingerPrint fp = _db.GetFingerprint(source);
                    if (fp == null)
                    {
                        fp = await VFPAnalyzer.GetSearchFingerprintForVideoFileAsync(source, errorDelegate);
                        if (fp == null)
                        {
                            MessageBox.Show("Unable to get fingerprint for the video file: " + filename);
                            return;
                        }
                        else
                        {
                            _db.Items.Add(fp);
                            AddDBItem(fp);
                        }
                    }

                    broadcastVFPList.Add(fp);

                    progress += broadcastList.Count > 0 ? 100 / broadcastList.Count : 0;
                }

                pbProgress.Value = 100;

                lbStatus.Content = "Step 4: Analyzing data";
                progress = 0;
                int foundCount = 0;
                foreach (var broadcast in broadcastVFPList)
                {
                    pbProgress.Value = progress;

                    foreach (var ad in adVFPList)
                    {
                        var positions = await VFPAnalyzer.SearchAsync(ad, broadcast, ad.Duration, (int)slDifference.Value, true);

                        if (positions.Count > 0)
                        {
                            foreach (var pos in positions)
                            {
                                foundCount++;
                                int minutes = (int)(pos.TotalSeconds / 60);
                                int seconds = (int)(pos.TotalSeconds % 60);

                                results.Add(
                                    new ResultsViewModel()
                                    {
                                        Sample = ad.OriginalFilename,
                                        DumpFile = broadcast.OriginalFilename,
                                        Position = minutes + ":" + seconds
                                    });
                            }
                        }
                    }

                    progress += broadcastList.Count > 0 ? 100 / broadcastList.Count : 0;
                }

                pbProgress.Value = 0;

                lvResults.Items.Refresh();

                lbStatus.Content = "Step 5: Done. " + foundCount + " ads found.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                btStart.IsEnabled = true;
            }
        }

        #region List view

        /// <summary>
        /// The results.
        /// </summary>
        private readonly ObservableCollection<ResultsViewModel> results = new ObservableCollection<ResultsViewModel>();

        /// <summary>
        /// Gets the results.
        /// </summary>
        public ObservableCollection<ResultsViewModel> Results { get { return this.results; } }

        #endregion

        /// <summary>
        /// Handles the bt play click event.
        /// </summary>
        private void btPlay_Click(object sender, RoutedEventArgs e)
        {
            if (lvResults.SelectedItem == null)
            {
                return;
            }

            if (!_isPlaying)
            {
                MediaPlayer1.Source = new Uri(((ResultsViewModel)lvResults.SelectedItem).DumpFile);

                MediaPlayer1.Play();

                _isPlaying = true;
                btPlay.Content = "Stop";
            }
            else
            {
                MediaPlayer1.Stop();

                _isPlaying = false;
                btPlay.Content = "Play";
            }
        }

        /// <summary>
        /// Handles the bt save results click event.
        /// </summary>
        private void btSaveResults_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog
            {
                Filter = "XML file|*.xml|CSV file|*.csv"
            };
            bool? result = dlg.ShowDialog(this);

            if (result == true)
            {
                string filename = dlg.FileName;

                try
                {
                    if (Path.GetExtension(filename.ToLowerInvariant()) == ".xml")
                    {
                        // XML - File.CreateText will overwrite existing files
                        string xml = XmlUtility.Obj2XmlStr(results);

                        using (StreamWriter sw = File.CreateText(filename))
                        {
                            sw.WriteLine(xml);
                        }
                    }
                    else
                    {
                        // CSV - FileMode.Create will overwrite existing files
                        using (var stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
                        {
                            var cs = new CsvSerializer<ResultsViewModel>();
                            cs.Serialize(stream, results);
                        }
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show($"Access denied: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Save settings.
        /// </summary>
        private void SaveSettings()
        {
            string filename = Path.Combine(Settings.SettingsFolder, "settings.xml");

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            if (!Directory.Exists(Settings.SettingsFolder))
            {
                Directory.CreateDirectory(Settings.SettingsFolder);
            }

            Settings.Save(typeof(Settings), filename);
        }

        /// <summary>
        /// Load settings.
        /// </summary>
        private void LoadSettings()
        {
            string filename = Path.Combine(Settings.SettingsFolder, "settings.xml");

            if (File.Exists(filename))
            {
                Settings.Load(typeof(Settings), filename);
            }
        }

        /// <summary>
        /// Add db item.
        /// </summary>
        private void AddDBItem(VFPFingerPrint fp)
        {
            var txt = $"{fp.OriginalFilename} [{fp.Width}x{fp.Height}, {fp.OriginalDuration.ToString("g")}]";
            if (fp.IgnoredAreas.Count > 0)
            {
                txt += "(with ignored areas)";
            }

            lbDB.Items.Add(txt);
        }

        /// <summary>
        /// Load db.
        /// </summary>
        private void LoadDB()
        {
            var dbFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mmt.db");
            lbDBLocation.Content = $"DB file: {dbFile}";
            if (File.Exists(dbFile))
            {
                _db = VFPFingerPrintDB.Load(dbFile);
            }
            else
            {
                _db = new VFPFingerPrintDB();
            }

            foreach (var item in _db.Items)
            {
                AddDBItem(item);
            }
        }

        /// <summary>
        /// Save db.
        /// </summary>
        private void SaveDB()
        {
            var dbFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mmt.db");
            _db.Save(dbFile);
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSettings();

            LoadDB();
        }

        /// <summary>
        /// Window unloaded.
        /// </summary>
        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSettings();

            SaveDB();
        }

        /// <summary>
        /// Sl difference value changed.
        /// </summary>
        private void slDifference_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbDifference != null)
            {
                lbDifference.Text = ((int)e.NewValue).ToString();
            }
        }

        /// <summary>
        /// Handles the bt add broadcast file click event.
        /// </summary>
        private void btAddBroadcastFile_Click(Object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                InitialDirectory = Settings.LastPath,
                Multiselect = true
            };

            bool? result = dlg.ShowDialog(this);

            if (result == true)
            {
                foreach (var name in dlg.FileNames)
                {
                    lbBroadcastFolders.Items.Add(name);
                }

                if (dlg.FileNames.Length > 0)
                {
                    Settings.LastPath = Path.GetDirectoryName(dlg.FileNames[0]) ?? string.Empty;
                }
            }
        }

        /// <summary>
        /// Handles the bt add ad file click event.
        /// </summary>
        private void btAddAdFile_Click(Object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                InitialDirectory = Settings.LastPath,
                Multiselect = true
            };

            bool? result = dlg.ShowDialog(this);

            if (result == true)
            {
                foreach (var name in dlg.FileNames)
                {
                    lbAdFolders.Items.Add(name);
                }

                if (dlg.FileNames.Length > 0)
                {
                    Settings.LastPath = Path.GetDirectoryName(dlg.FileNames[0]) ?? string.Empty;
                }
            }
        }

        /// <summary>
        /// Handles the bt ignored area add click event.
        /// </summary>
        private void btIgnoredAreaAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(edIgnoredAreaLeft.Text, out int left) ||
                !int.TryParse(edIgnoredAreaTop.Text, out int top) ||
                !int.TryParse(edIgnoredAreaRight.Text, out int right) ||
                !int.TryParse(edIgnoredAreaBottom.Text, out int bottom))
            {
                MessageBox.Show("Please enter valid numeric values for all coordinates.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var rect = new Rect()
            {
                Left = left,
                Top = top,
                Right = right,
                Bottom = bottom
            };

            _ignoredAreas.Add(rect);
            lbIgnoredAreas.Items.Add($"Left: {rect.Left}, Top: {rect.Top}, Right: {rect.Right}, Bottom: {rect.Bottom}");
        }

        /// <summary>
        /// Handles the bt ignored areas remove item click event.
        /// </summary>
        private void btIgnoredAreasRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            int index = lbIgnoredAreas.SelectedIndex;
            if (index >= 0)
            {
                lbIgnoredAreas.Items.RemoveAt(index);
                _ignoredAreas.RemoveAt(index);
            }
        }

        /// <summary>
        /// Handles the bt ignored areas remove all click event.
        /// </summary>
        private void btIgnoredAreasRemoveAll_Click(object sender, RoutedEventArgs e)
        {
            lbIgnoredAreas.Items.Clear();
            _ignoredAreas.Clear();
        }

        /// <summary>
        /// Handles the bt db clear click event.
        /// </summary>
        private void btDBClear_Click(object sender, RoutedEventArgs e)
        {
            _db.Items.Clear();
            lbDB.Items.Clear();
        }
    }
}
