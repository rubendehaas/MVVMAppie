using GalaSoft.MvvmLight;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
=======
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> origin/master

namespace MVVMAppie.ViewModel
{
    public class SectionVM
    {
<<<<<<< HEAD
        
        public String Name
        {
            get { return _Section.Name; }
            set { _Section.Name = value; }
        }

        private Section _Section;

        public SectionVM()
        {
            _Section = new Section();
=======
        private Section _section;

        public String Name
        {
            get
            {
                return _section.Name;
            }
>>>>>>> origin/master
        }

        public SectionVM(Section item)
        {
<<<<<<< HEAD
            _Section = item;
=======
            _section = item;
>>>>>>> origin/master
        }
    }
}
