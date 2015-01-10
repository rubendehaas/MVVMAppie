using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private SectionsVM _sections;
        private SectionVM _selectedSection;
        
        private string _textIn;

        public ProductsVM Products
        {
            get
            {
                return _products;
            }
        }

        public SectionsVM Sections
        {
            get
            {
                return _sections;
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

        public ObservableCollection<ProductVM> PickerProducts
        {
            get
            {
                if (SelectedSection != null)
                {
                    return _products.GetPickerProducts2(SelectedSection.GetSection());
                }
                else
                {
                    return null;
                }

            }
        }

        public SectionVM SelectedSection
        {
            get
            {
                return _selectedSection;
            }

            set
            {
                
                    _selectedSection = value;

                    if (_selectedSection != null)
                    { 
                        GetProductsOfSection(_selectedSection.GetSection());
                    }   

                    RaisePropertyChanged("SelectedSection");
                    RaisePropertyChanged("PickerProducts");
                

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

        public void GetProductsOfSection(Section section)
        {
            Products.GetPickerProducts2(section);
        }

        public RelayCommand AddProductCommand { get; set; }
        public RelayCommand DeleteProductCommand { get; set; }

        private void Add()
        {
            _products.AddProductCommand(TextIn, _selectedSection.GetSection());
            TextIn = "";

            RaisePropertyChanged("PickerProducts");
        }

        private void Delete()
        {
            if(_selectedProduct != null){
                _products.DeleteProductCommand(_selectedProduct.GetProduct());

                RaisePropertyChanged("PickerProducts");
            }
        }

        public ProductManageViewModel(Database datab, ProductsVM Products, SectionsVM Sections)
        {
            this.datab = datab;
            this._products = Products;
            this._sections = Sections;
            this.DeleteProductCommand = new RelayCommand(Delete);
            this.AddProductCommand = new RelayCommand(Add);
        }
    }
}
