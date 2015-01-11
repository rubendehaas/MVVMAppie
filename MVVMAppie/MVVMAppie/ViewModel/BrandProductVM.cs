using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class BrandProductVM
    {
        private BrandProduct _product;

        public String Name
        {
            get
            {
                return (_product.Product.Name + " - " + _product.Brand.Name);
            }
        }

        public BrandProductVM(BrandProduct item)
        {
            _product = item;
        }

        public BrandProduct GetProduct()
        {
            return _product;
        }
    }
}
