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
        public ObservableCollection<SectionVM> Sections
        {
            get;
            set;
        }

        public ObservableCollection<ProductVM> Products
        {
            get;
            set;
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
                this.LoadProducts();
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
                this.LoadBrands();
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

        private void LoadProducts(){
            this.SelectedBrand = null;
            this.SelectedProduct = null;
            List<Product> products = database.ProductRepository.GetAll().Where(p => p.Section.Name == SelectedSection.Name).ToList();
            List<ProductVM> productVM = products.Select(s => new ProductVM(s)).ToList();
            Products = new ObservableCollection<ProductVM>(productVM);
            RaisePropertyChanged("Products");
        }

        private void LoadBrands()
        {
            this.SelectedBrand = null;
            if (this.SelectedProduct != null)
            {
                List<Brand> brands = this.SelectedProduct.GetProduct().Brands.ToList();
                List<BrandVM> brandVM = brands.Select(s => new BrandVM(s)).ToList();
                Brands = new ObservableCollection<BrandVM>(brandVM);
                RaisePropertyChanged("Brands");
            }
            else
            {
                Brands = null;
                RaisePropertyChanged("Brands");
            }
            
        }

        public ProductPickerViewModel(Database datab, ShoppingListVM shoppingList)
        {
            this.database = datab;
            this._shoppingList = shoppingList;
            List<Section> sections = database.SectionRepository.GetAll().ToList();
            List<SectionVM> sectionVM = sections.Select(s => new SectionVM(s)).ToList();
            Sections = new ObservableCollection<SectionVM>(sectionVM);
        }
    }
}