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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class BrandConnectWindow : Window
    {
        public BrandConnectWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SectionAddWindow sectionAddWindow = new SectionAddWindow();
            sectionAddWindow.Show();
        }
    }
}
