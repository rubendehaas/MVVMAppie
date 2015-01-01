using GalaSoft.MvvmLight;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class BrandVM
    {
        private Brand _brand;

        public String Name
        {
            get
            {
                return _brand.Name;
            }
        }

        public BrandVM(Brand item)
        {
            _brand = item;
        }

        public Brand GetBrand()
        {
            return _brand;
        }
    }
}
