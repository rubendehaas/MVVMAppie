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
    /// Interaction logic for CRUD.xaml
    /// </summary>
    public partial class CRUDWindow : Window
    {
        public CRUDWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CRUDSectionWindow crudSectionWindow = new CRUDSectionWindow();
            crudSectionWindow.Show();
        }
    }
}
