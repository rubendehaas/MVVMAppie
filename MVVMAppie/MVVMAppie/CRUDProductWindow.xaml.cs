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
    /// Interaction logic for CRUDProductWindow.xaml
    /// </summary>
    public partial class CRUDProductWindow : Window
    {
        public CRUDProductWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductAddWindow paw = new ProductAddWindow();
            paw.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductEditWindow pew = new ProductEditWindow();
            pew.Show();
        }
    }
}
