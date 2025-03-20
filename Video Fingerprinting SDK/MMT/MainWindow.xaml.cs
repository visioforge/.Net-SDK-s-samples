using System.Diagnostics;

namespace VisioForge_MMT
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;

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
        private readonly List<Rect> _ignoredAreas = new List<Rect>();

        private VFPFingerPrintDB _db;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btAddBroadcastFolder_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.FolderBrowserDialog
            {
                SelectedPath = Settings.LastPath
            };

            System.Windows.Forms.DialogResult result = dlg.ShowDialog(this.GetIWin32Window());

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                lbBroadcastFolders.Items.Add(dlg.SelectedPath);
                Settings.LastPath = dlg.SelectedPath;
            }
        }

        private void btAddAdFolder_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.FolderBrowserDialog
            {
                SelectedPath = Settings.LastPath
            };

            System.Windows.Forms.DialogResult result = dlg.ShowDialog(this.GetIWin32Window());

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                lbAdFolders.Items.Add(dlg.SelectedPath);
                Settings.LastPath = dlg.SelectedPath;
            }
        }

        private void btClearAds_Click(object sender, RoutedEventArgs e)
        {
            lbAdFolders.Items.Clear();
        }

        private void btClearBroadcast_Click(object sender, RoutedEventArgs e)
        {
            lbBroadcastFolders.Items.Clear();
        }

        private void errorDelegate(string error)
        {
            MessageBox.Show(error);
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (cbDebug.IsChecked == true)
            {
                VFPAnalyzer.DebugDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\MMT\\";
            }

            btStart.IsEnabled = false;

            results.Clear();
            lvResults.Items.Refresh();

            lbStatus.Content = "Step 1: Searching video files";

            List<string> adList = new List<string>();
            List<string> broadcastList = new List<string>();

            List<VFPFingerPrint> adVFPList = new List<VFPFingerPrint>();
            List<VFPFingerPrint> broadcastVFPList = new List<VFPFingerPrint>();

            foreach (string item in lbAdFolders.Items)
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

            foreach (string item in lbBroadcastFolders.Items)
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

                adVFPList.Add(fp);

                progress += 100 / adList.Count;
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

                progress += 100 / broadcastList.Count;
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

                progress += 100 / broadcastList.Count;
            }

            pbProgress.Value = 0;

            lvResults.Items.Refresh();

            lbStatus.Content = "Step 5: Done. " + foundCount + " ads found.";

            btStart.IsEnabled = true;
        }

        #region List view

        private readonly ObservableCollection<ResultsViewModel> results = new ObservableCollection<ResultsViewModel>();

        public ObservableCollection<ResultsViewModel> Results { get { return this.results; } }

        #endregion

        private void btPlay_Click(object sender, RoutedEventArgs e)
        {
            if (lvResults.SelectedItem == null)
            {
                return;
            }

            if ((string)btPlay.Content == "Play")
            {
                MediaPlayer1.Source = new Uri(((ResultsViewModel)lvResults.SelectedItem).DumpFile);

                MediaPlayer1.Play();

                btPlay.Content = "Stop";
            }
            else
            {
                MediaPlayer1.Stop();

                btPlay.Content = "Play";
            }
        }

        private void btSaveResults_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.SaveFileDialog
            {
                Filter = @"XML file|*.xml|CSV file|*.csv"
            };
            System.Windows.Forms.DialogResult result = dlg.ShowDialog(this.GetIWin32Window());

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string filename = dlg.FileName;

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                if (!File.Exists(filename))
                {
                    if (Path.GetExtension(filename.ToLowerInvariant()) == ".xml")
                    {
                        // XML
                        string xml = XmlUtility.Obj2XmlStr(results);

                        using (StreamWriter sw = File.CreateText(filename))
                        {
                            sw.WriteLine(xml);
                        }
                    }
                    else
                    {
                        // CSV
                        using (var stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
                        {
                            var cs = new CsvSerializer<ResultsViewModel>();
                            cs.Serialize(stream, results);
                        }
                    }
                }
            }
        }

        private void SaveSettings()
        {
            string filename = Settings.SettingsFolder + "settings.xml";

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

        private void LoadSettings()
        {
            string filename = Settings.SettingsFolder + "settings.xml";

            if (File.Exists(filename))
            {
                Settings.Load(typeof(Settings), filename);
            }
        }

        private void AddDBItem(VFPFingerPrint fp)
        {
            var txt = $"{fp.OriginalFilename} [{fp.Width}x{fp.Height}, {fp.OriginalDuration.ToString("g")}]";
            if (fp.IgnoredAreas.Count > 0)
            {
                txt += "(with ignored areas)";
            }

            lbDB.Items.Add(txt);
        }

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

        private void SaveDB()
        {
            var dbFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mmt.db");
            _db.Save(dbFile);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSettings();

            LoadDB();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSettings();

            SaveDB();
        }

        private void slDifference_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbDifference != null)
            {
                lbDifference.Text = ((int)e.NewValue).ToString();
            }
        }

        private void btAddBroadcastFile_Click(Object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.OpenFileDialog
            {
                InitialDirectory = Settings.LastPath,
                Multiselect = true
            };

            System.Windows.Forms.DialogResult result = dlg.ShowDialog(this.GetIWin32Window());

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var name in dlg.FileNames)
                {
                    lbBroadcastFolders.Items.Add(name);
                }

                Settings.LastPath = Path.GetFullPath(dlg.FileNames[0]);
            }
        }

        private void btAddAdFile_Click(Object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.OpenFileDialog
            {
                InitialDirectory = Settings.LastPath,
                Multiselect = true
            };

            System.Windows.Forms.DialogResult result = dlg.ShowDialog(this.GetIWin32Window());

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var name in dlg.FileNames)
                {
                    lbAdFolders.Items.Add(name);
                }

                Settings.LastPath = Path.GetFullPath(dlg.FileNames[0]);
            }
        }

        private void btIgnoredAreaAdd_Click(object sender, RoutedEventArgs e)
        {
            var rect = new Rect()
            {
                Left = Convert.ToInt32(edIgnoredAreaLeft.Text),
                Top = Convert.ToInt32(edIgnoredAreaTop.Text),
                Right = Convert.ToInt32(edIgnoredAreaRight.Text),
                Bottom = Convert.ToInt32(edIgnoredAreaBottom.Text)
            };

            _ignoredAreas.Add(rect);
            lbIgnoredAreas.Items.Add($"Left: {rect.Left}, Top: {rect.Top}, Right: {rect.Right}, Bottom: {rect.Bottom}");
        }

        private void btIgnoredAreasRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            int index = lbIgnoredAreas.SelectedIndex;
            if (index >= 0)
            {
                lbIgnoredAreas.Items.RemoveAt(index);
                _ignoredAreas.RemoveAt(index);
            }
        }

        private void btIgnoredAreasRemoveAll_Click(object sender, RoutedEventArgs e)
        {
            lbIgnoredAreas.Items.Clear();
            _ignoredAreas.Clear();
        }

        private void btDBClear_Click(object sender, RoutedEventArgs e)
        {
            _db.Items.Clear();
            lbDB.Items.Clear();
        }
    }
}
