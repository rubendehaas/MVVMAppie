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
        public ShoppingListItemVM SelectedShoppingListItem

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
        }
    }
}