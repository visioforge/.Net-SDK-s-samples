using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DVS
{
    /// <summary>
    /// Interaction logic for ResultItem.xaml
    /// </summary>
    public partial class ResultItem 
    {
        public ResultItem()
        {
            InitializeComponent();
        }

        private void StackPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Text.Width = stackPanel.ActualWidth - 100;
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            stackPanel.Width = grid.ActualWidth;
            Text.Width = stackPanel.ActualWidth - 100;

        }
    }
}
