using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class BrandConnectViewModel : ViewModelBase
    {
        private Database database;
        private SectionsVM _sectionsCollection;
        private ProductsVM _productsCollection;
        private BrandsVM _brandsCollection;
        private SectionVM _selectedSection;
        private ProductVM _selectedProduct;
        private BrandVM _selectedUnselectedBrand;
        private BrandVM _selectedSelectedBrand;
        private RelayCommand addBrandCommand;
        private RelayCommand removeBrandCommand;
        private string _textIn;

        public SectionsVM SectionsCollection
        {
            get
            {
                return _sectionsCollection;
            }
        }

        public ProductsVM ProductsCollection
        {
            get
            {
                return _productsCollection;
            }
        }

        public BrandsVM BrandsCollection
        {
            get
            {
                return _brandsCollection;
            }
        }

        public ObservableCollection<ProductVM> PickerProducts
        {
            get
            {
                if (SelectedSection != null)
                {
                    return _productsCollection.GetPickerProducts(SelectedSection.GetSection());
                }
                else
                {
                    return null;
                }

            }
        }

        public ObservableCollection<BrandVM> UnselectedBrands
        {
            get
            {
                if (SelectedProduct != null && SelectedSection != null)
                {
                    return _brandsCollection.GetUnbindedBrands(SelectedProduct.GetProduct());
                }
                else
                {
                    return null;
                }
            }
        }

        public ObservableCollection<BrandVM> SelectedBrands
        {
            get
            {
                if (SelectedProduct != null && SelectedSection != null)
                {
                    return _brandsCollection.GetPickerBrands(SelectedProduct.GetProduct());
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
                RaisePropertyChanged("UnselectedBrands");
                RaisePropertyChanged("SelectedBrands");
            }
        }

        public BrandVM SelectedUnselectedBrand
        {
            get
            {
                return _selectedUnselectedBrand;
            }

            set
            {
                _selectedUnselectedBrand = value;
                RaisePropertyChanged("SelectedUnselectedBrand");
            }
        }

        public BrandVM SelectedSelectedBrand
        {
            get
            {
                return _selectedSelectedBrand;
            }

            set
            {
                _selectedSelectedBrand = value;
                RaisePropertyChanged("SelectedSelectedBrand");
            }
        }

        public RelayCommand AddBrandCommand
        {
            get
            {
                if (addBrandCommand == null)
                {
                    addBrandCommand = new RelayCommand(() =>
                    {
                        this.AddBrand();
                    });
                }
                return addBrandCommand;
            }
        }

        public RelayCommand RemoveBrandCommand
        {
            get
            {
                if (removeBrandCommand == null)
                {
                    removeBrandCommand = new RelayCommand(() =>
                    {
                        this.RemoveBrand();
                    });
                }
                return removeBrandCommand;
            }
        }
        public String TextIn
        {
            get
            {
                return _textIn;
                ;
            }

            set
            {
                _textIn = value;
                RaisePropertyChanged("TextIn");
            }
        }

        private void AddBrand()
        {
            if (this.SelectedUnselectedBrand != null && this.SelectedProduct != null)
            {
                this.BrandsCollection.BindProduct(this.SelectedUnselectedBrand.GetBrand(), this.SelectedProduct.GetProduct(), Double.Parse(TextIn, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo));
                this.SelectedUnselectedBrand = null;
                this.TextIn = "";
                this.RaisePropertyChanged("SelectedBrands");
                this.RaisePropertyChanged("UnselectedBrands");
            }
        }

        private void RemoveBrand()
        {
            if (this.SelectedSelectedBrand != null && this.SelectedProduct != null)
            {
                this.BrandsCollection.UnbindProduct(this.SelectedSelectedBrand.GetBrand(), this.SelectedProduct.GetProduct());
                this.SelectedSelectedBrand = null;
                this.RaisePropertyChanged("SelectedBrands");
                this.RaisePropertyChanged("UnselectedBrands");
            }
        }
        public BrandConnectViewModel(Database datab, SectionsVM sections, ProductsVM products, BrandsVM brands)
        {
            this.database = datab;
            this._sectionsCollection = sections;
            this._productsCollection = products;
            this._brandsCollection = brands;
        }
    }
}
