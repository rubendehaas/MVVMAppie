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

namespace MVVMAppie
{
    /// <summary>
    /// Interaction logic for CRUDSectionWindow.xaml
    /// </summary>
    public partial class CRUDBrandWindow : Window
    {
        public CRUDBrandWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BrandAddWindow brandAddWindow = new BrandAddWindow();
            brandAddWindow.Show();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            BrandEditWindow brandEditWindow = new BrandEditWindow();
            brandEditWindow.Show();
        }
    }
}
