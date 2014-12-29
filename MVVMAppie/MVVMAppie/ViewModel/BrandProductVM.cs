using GalaSoft.MvvmLight;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class BrandProductVM : ViewModelBase
    {
        private BrandProduct _brandProduct;

        public String Name
        {
            get { return string.Concat(_brandProduct.Product.Name, " - ", _brandProduct.Brand.Name); }
        }

        public double Price
        {
            get { return _brandProduct.Price;  }
        }

        public BrandProductVM(BrandProduct item)
        {
            _brandProduct = item;
        }
    }
}
