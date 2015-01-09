using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class ProductManageViewModel : ViewModelBase
    {

        private Database datab;
        private ProductsVM _products;
        private ProductVM _selectedProduct;
        
        private string _textIn;

        public ProductsVM Products
        {
            get
            {
                return _products;
            }
        }

        public String TextIn
        {
            get
            {
                return _textIn;
            }

            set
            {
                _textIn = value;
                RaisePropertyChanged("TextIn");
            }
        }

        public ProductVM SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }

            set
            {
                _selectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
            }
        }

        public RelayCommand AddProductCommand { get; set; }
        public RelayCommand DeleteProductCommand { get; set; }

        private void Add()
        {
            _products.AddProductCommand(TextIn);
            TextIn = "";
        }

        private void Delete()
        {
            if(_selectedProduct != null){
                _products.DeleteProductCommand(_selectedProduct.GetProduct());
            }
        }

        public ProductManageViewModel(Database datab, ProductsVM Products)
        {
            this.datab = datab;
            this._products = Products;
            this.DeleteProductCommand = new RelayCommand(Delete);
            this.AddProductCommand = new RelayCommand(Add);
        }
    }
}
