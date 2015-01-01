using GalaSoft.MvvmLight;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class SectionVM
    {
        private Section _section;

        public String Name
        {
            get
            {
                return _section.Name;
            }
        }

        public SectionVM(Section item)
        {
            _section = item;
        }
    }
}
