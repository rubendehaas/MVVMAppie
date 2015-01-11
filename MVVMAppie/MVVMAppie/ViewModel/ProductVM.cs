using GalaSoft.MvvmLight;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class ProductVM
    {
        private Product _product;

        public String Name
        {
            get
            {
                return _product.Name;
            }
        }

        public ProductVM(Product item)
        {
            _product = item;
        }

        public Product GetProduct()
        {
            return _product;
        }
        
    }
}
