using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace MVVMAppie.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Database database;
        private ShoppingListVM _shoppingList;

        private ShoppingListItemVM _selectedShoppingListItem;
        public ShoppingListVM ShoppingList
        {
            get
            {
                return _shoppingList;
            }
        }
<<<<<<< HEAD

        public ObservableCollection<SectionVM> SectionList
        {
            get;
            set;
        }

        private BrandProductVM _selectedBrandProduct;

        private SectionVM _selectedSection;

        public BrandProductVM SelectedBrandProduct
=======
        public ShoppingListItemVM SelectedShoppingListItem
>>>>>>> origin/master
        {
            get
            {
                return _selectedShoppingListItem;
            }

            set{
                _selectedShoppingListItem = value;
                RaisePropertyChanged("SelectedShoppingListItem");
            }
        }

<<<<<<< HEAD
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
            }
        }

        public MainViewModel(Database datab)
        {
            this.database = datab;
            
            //Stap 1. Ophalen van onze data
            List<BrandProduct> brandProducts = database.BrandProductRepository.GetAll().ToList();
            List<Section> sections = database.SectionRepository.GetAll().ToList();

            //stap 2. omzetten van model naar viewmodel
            List<BrandProductVM> brandProductsVM = brandProducts.Select(s => new BrandProductVM(s)).ToList();
            List<SectionVM> sectionVM = sections.Select(s=> new SectionVM(s)).ToList();


            //Stap 3. Toevoegen van del ijst aan de observable collectie
            ShoppingList = new ObservableCollection<BrandProductVM>(brandProductsVM);
            SectionList = new ObservableCollection<SectionVM>(sectionVM);
=======
        private RelayCommand removeProductCommand;
        public RelayCommand RemoveProductCommand
        {
            get
            {
                if (removeProductCommand == null)
                {
                    removeProductCommand = new RelayCommand(() =>
                    {
                        ShoppingList.RemoveProduct(SelectedShoppingListItem);
                    });
                }
                return removeProductCommand;
            }
        }

        public MainViewModel(Database datab, ShoppingListVM shoppingList)
        {
            this.database = datab;
            this._shoppingList = shoppingList;
>>>>>>> origin/master
        }
    }
}