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
        private string _textEdit;
        private bool _sectionPickStatus;
        private bool _productPickStatus;

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

        public String TextEdit
        {
            get
            {
                return _textEdit;
            }

            set
            {
                _textEdit = value;
                RaisePropertyChanged("TextEdit");
            }
        }

        public Boolean ProductPickStatus
        {
            get
            {
                return _productPickStatus;
            }
            set
            {
                _productPickStatus = value;
                RaisePropertyChanged("ProductPickStatus");
            }
        }

        public Boolean SectionPickStatus
        {
            get
            {
                return _sectionPickStatus;
            }
            set
            {
                _sectionPickStatus = value;
                RaisePropertyChanged("SectionPickStatus");
            }
        }

        public ObservableCollection<ProductVM> PickerProducts
        {
            get
            {
                if (SelectedSection != null)
                {
                    return _products.GetPickerProducts(SelectedSection.GetSection());
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
                    SectionPickStatus = true;
                    GetProductsOfSection(_selectedSection.GetSection());
                }
                else
                {
                    SectionPickStatus = false;
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
                if(_selectedProduct != null)
                {
                    ProductPickStatus = true;
                    TextEdit = _selectedProduct.Name;
                }
                else
                {
                    ProductPickStatus = false;

                }

                RaisePropertyChanged("SelectedProduct");
            }
        }

        public void GetProductsOfSection(Section section)
        {
            //TODO CHECK IF NORMAL PICKER WORKS
            Products.GetPickerProducts(section);
        }

        public RelayCommand AddProductCommand { get; set; }
        public RelayCommand EditProductCommand { get; set; }
        public RelayCommand DeleteProductCommand { get; set; }

        private void Add()
        {
            _products.AddProductCommand(TextIn, _selectedSection.GetSection());
            TextIn = "";

            RaisePropertyChanged("PickerProducts");
        }

        private void Edit()
        {
            if (_selectedProduct != null)
            {
                _products.EditProductCommand(TextEdit, _selectedProduct.GetProduct());
                RaisePropertyChanged("PickerProducts");
            }
        }

        private void Delete()
        {
            if(_selectedProduct != null)
            {
                _products.DeleteProductCommand(_selectedProduct.GetProduct());

                RaisePropertyChanged("PickerProducts");
            }
        }

        public ProductManageViewModel(Database datab, ProductsVM Products, SectionsVM Sections)
        {
            this.datab = datab;
            this._products = Products;
            this._sections = Sections;
            this.AddProductCommand = new RelayCommand(Add);
            this.EditProductCommand = new RelayCommand(Edit);
            this.DeleteProductCommand = new RelayCommand(Delete);
        }
    }
}
