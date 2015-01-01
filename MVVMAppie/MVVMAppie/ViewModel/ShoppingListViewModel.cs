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
    public class ShoppingListViewModel : ViewModelBase
    {
        private ShoppingList shoppingList;
        public ObservableCollection<ShoppingListItemVM> ShoppingList
        {
            get;
            set;
        }

        public ShoppingListViewModel(Database datab)
        {
            this.shoppingList = new ShoppingList();
            this.shoppingList.ShoppingListItems = new List<ShoppingListItem>();

            //stap 2. omzetten van model naar viewmodel
            List<ShoppingListItemVM> shoppingListItems = this.shoppingList.ShoppingListItems.Select(s => new ShoppingListItemVM(s)).ToList();

            

            //Stap 3. Toevoegen van del ijst aan de observable collectie
            ShoppingList = new ObservableCollection<ShoppingListItemVM>(shoppingListItems);
        }
    }
}
