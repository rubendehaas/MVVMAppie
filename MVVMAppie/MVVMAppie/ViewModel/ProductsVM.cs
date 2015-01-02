using GalaSoft.MvvmLight;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class ProductsVM : ViewModelBase
    {
        private List<Product> _products;
        private Database database;

        public ObservableCollection<ProductVM> Products
        {
            get
            {
                //geef een observable collection (soort list) terug van _products
                return new ObservableCollection<ProductVM>(this._products.Select(c => new ProductVM(c)).ToList());
            }
        }
        public ProductsVM(Database datab)
        {
            this.database = datab;
            this._products = datab.ProductRepository.GetAll().ToList();
        }


        public void AddProductCommand(string TextIn)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<ProductVM> GetPickerProducts(Section section)
        {
            if (section.Products != null)
            {
                return new ObservableCollection<ProductVM>(section.Products.Select(c => new ProductVM(c)).ToList());
            }
            else
            {
                return null;
            }
            
        }
    }
}
