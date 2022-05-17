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
using System.Windows.Shapes;

namespace L4
{

    public partial class About : Window
    {

        public About()
        {
            InitializeComponent();
            checkBoxAbout.IsChecked = Properties.Settings.Default.isShowAbout;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.isShowAbout = (bool)checkBoxAbout.IsChecked;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
