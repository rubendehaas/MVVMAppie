using GalaSoft.MvvmLight;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class TestViewModel : ViewModelBase
    {
        private Database datab;

        public TestViewModel(Database datab)
        {
            this.datab = datab;
        }
    }
}
