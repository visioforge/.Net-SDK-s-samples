using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
using ImageComparer.Properties;

using VisioForge.Core.VideoFingerPrinting;

namespace ImageComparer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _similarityThreshold = 0.8;

        public MainWindow()
        {
            InitializeComponent();
        }


        #region List view

        private readonly ObservableCollection<ResultsViewModel> resultList = new ObservableCollection<ResultsViewModel>();

        private readonly ObservableCollection<ResultsViewModel> resultListView = new ObservableCollection<ResultsViewModel>();

        public ObservableCollection<ResultsViewModel> ResultsView
        {
            get
            {
                return resultListView;
            }
        }

        #endregion

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSettings();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSettings();
        }

        private void btSaveResults_Click(object sender, RoutedEventArgs e)
        {
            string xml = XmlUtility.Obj2XmlStr(resultList);

            var dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.Filter = @"XML file|*.xml";
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
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(filename))
                    {
                        sw.WriteLine(xml);
                    }
                }
            }
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btStart.Content == "Stop")
            {
                Thread.Sleep(500);
                
                btStart.Content = "Start";

                lbStatus.Content = string.Empty;
            }
            else
            {
                _similarityThreshold = slSimilarity.Value / 100;

                btStart.IsEnabled = false;
                resultList.Clear();
                resultListView.Clear();

                lbStatus.Content = "Step 1: Searching image files";

                var adList = new List<string>();

                foreach (string item in lbAdFolders.Items)
                {
                    adList.AddRange(FileScanner.SearchImagesInFolder(item));
                }

                lbStatus.Content = "Step 2: Comparing";
                
                if (adList.Count == 0)
                {
                    btStart.Content = "Start";
                    lbStatus.Content = string.Empty;

                    MessageBox.Show("Image list is empty!");
                    
                    btStart.IsEnabled = true;
                    btStart.Content = "Start";

                    return;
                }

                Task.Run(() =>
                {
                    int progress = 0;
                    foreach (string filename1 in adList)
                    {
                        Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                            new Action(delegate ()
                            {
                                imgPreview.Source = new BitmapImage(new Uri(filename1));
                            }));

                        Bitmap bmp1 = new Bitmap(filename1);

                        foreach (var filename2 in adList)
                        {
                            if (filename1 == filename2)
                            {
                                continue;
                            }

                            var exists = resultList.Where((model => (model.FirstFile == filename1 && model.SecondFile == filename2) || (model.FirstFile == filename2 && model.SecondFile == filename1)));
                            if (exists.Any())
                            {
                                continue;
                            }

                            Bitmap bmp2 = new Bitmap(filename2);

                            var result = VFPImageCompare.Compare(bmp1, bmp2);

                            if (result > _similarityThreshold)
                            {
                                resultList.Add(new ResultsViewModel()
                                {
                                    FirstFile = filename1,
                                    SecondFile = filename2,
                                    SimilarityLevel = result.ToString("F3")
                                });

                                Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                                    new Action(delegate ()
                                    {
                                        resultListView.Add(new ResultsViewModel()
                                        {
                                            FirstFile = filename1,
                                            SecondFile = filename2,
                                            SimilarityLevel = result.ToString("F3")
                                        });
                                    }));
                            }

                            bmp2.Dispose();
                        }

                        bmp1.Dispose();

                        progress += 100 / adList.Count;

                        Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                            new Action(delegate ()
                            {
                                pbProgress.Value = progress;
                            }));
                    }

                    Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                        new Action(delegate ()
                        {
                            pbProgress.Value = 0;

                            lbStatus.Content = "Done";

                            lvResults.Items.Refresh();

                            btStart.IsEnabled = true;
                            btStart.Content = "Start";

                            imgPreview.Source = null;
                        }));
                });
            }
        }

        private void slSimilarity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbSimilarity != null)
            {
                lbSimilarity.Text = $"{(int) e.NewValue}%";
            }
        }
    }
}
