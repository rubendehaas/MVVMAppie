using MVVMAppie.Model;
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
    /// Interaction logic for ProductAddWindow.xaml
    /// </summary>
    public partial class SectionAddWindow : Window
    {
        Database db = new Database();

        public SectionAddWindow()
        {
            InitializeComponent();
        }

        private void AddSectionBtn_Click(object sender, RoutedEventArgs e)
        {
            string valueName = SectionNameTB.Text;            

            var model = new MVVMAppie.Model.Section
            {
                Name = valueName
            };

            db.SectionRepository.Create(model);
            
            db.Save();
            this.Close();
        }
    }
}
