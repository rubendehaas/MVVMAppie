using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MVVMAppie.ViewModel
{
    public class ProductPickerViewModel : ViewModelBase
    {

        private Database database;
        private ShoppingListVM _shoppingList;
        private SectionsVM _sectionsCollection;
        private ProductsVM _productsCollection;
        private BrandsVM _brandsCollection;
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
                if (SelectedSection !=null)
                {
                    return _productsCollection.GetPickerProducts(SelectedSection.GetSection());
                }
                else
                {
                    return null;
                }

            }
        }

        public ObservableCollection<BrandVM> PickerBrands
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

        public ObservableCollection<BrandVM> Brands
        {
            get;
            set;
        }

        private SectionVM _selectedSection;
        private ProductVM _selectedProduct;
        private BrandVM _selectedBrand;

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
                RaisePropertyChanged("PickerBrands");
            }
        }

        public BrandVM SelectedBrand
        {
            get
            {
                return _selectedBrand;
            }

            set
            {
                _selectedBrand = value;
                RaisePropertyChanged("SelectedBrand");
            }
        }
        private RelayCommand addProductCommand;

        public RelayCommand AddProductCommand
        {
            get
            {
                if (addProductCommand == null)
                {
                    addProductCommand = new RelayCommand(() =>
                    {
                        this.AddProduct();
                    });
                }
                return addProductCommand;
            }
        }

        private void AddProduct()
        {
            if (this.SelectedBrand != null && this.SelectedProduct != null)
            {
                if (_shoppingList.ShoppingList.Where(s => s.Name == this.SelectedProduct.Name && s.Brand == this.SelectedBrand.Name).Count() == 0)
                {
                    _shoppingList.AddShoppingListItem(new ShoppingListItemVM(new ShoppingListItem
                    {
                        Amount = 1,
                        BrandProduct = database.BrandProductRepository.GetBySelection(this.SelectedBrand.GetBrand(), this.SelectedProduct.GetProduct())
                    }, _shoppingList));
                }
                else
                {
                    _shoppingList.IncreaseAmmount(this.SelectedProduct.GetProduct(), this.SelectedBrand.GetBrand());
                }
            }
        }

        public ProductPickerViewModel(Database datab, ShoppingListVM shoppingList, SectionsVM sections, ProductsVM products, BrandsVM brands)
        {
            this.database = datab;
            this._shoppingList = shoppingList;
            this._sectionsCollection = sections;
            this._productsCollection = products;
            this._brandsCollection = brands;
        }
    }
}