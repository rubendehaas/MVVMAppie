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
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        private Database database;
        private ShoppingListViewModel _shoppingList;

        private ShoppingListItemVM _selectedShoppingListItem;
        public ShoppingListViewModel ShoppingList
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
                        this.RemoveProduct();
                    });
                }
                return removeProductCommand;
            }
        }

        private void RemoveProduct()
        {
            _shoppingList.ShoppingList.Remove(SelectedShoppingListItem);
            RaisePropertyChanged("ShoppingList");
        }

        public MainViewModel(Database datab, ShoppingListViewModel shoppingList)
        {
            this.database = datab;
            this._shoppingList = shoppingList;
        }
    }
}