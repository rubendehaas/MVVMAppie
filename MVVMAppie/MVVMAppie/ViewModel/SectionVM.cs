using GalaSoft.MvvmLight;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMAppie.ViewModel
{
    public class SectionVM
    {
        
        public String Name
        {
            get { return _Section.Name; }
            set { _Section.Name = value; }
        }

        private Section _Section;

        public SectionVM()
        {
            _Section = new Section();
        }

        public SectionVM(Section item)
        {
            _Section = item;
        }
    }
}
