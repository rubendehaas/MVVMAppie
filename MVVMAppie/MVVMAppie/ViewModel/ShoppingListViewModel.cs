using GalaSoft.MvvmLight;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public double TotalPrice
        {
            get
            {
                double x = 0;
                foreach (ShoppingListItemVM i in ShoppingList)
                {
                    x = x + (i.Amount * i.Price);
                }

                return Math.Round(x, 2);
            }
        }

        public void AddShoppingListItem(ShoppingListItemVM item){
            this.ShoppingList.Add(item);
            item.PropertyChanged += HandleShoppingListChanges;
            RaisePropertyChanged("ShoppingList");
            RaisePropertyChanged("TotalPrice");
        }
        public void IncreaseAmmount(String product, String brand)
        {
            ShoppingList.Where(s => s.Name == product && s.Brand == brand).First().Amount++;
            RaisePropertyChanged("ShoppingList");
            RaisePropertyChanged("TotalPrice");
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
        void HandleShoppingListChanges(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Amount")
                RaisePropertyChanged("TotalPrice");
        }
    }
}
