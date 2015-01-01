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
    public class ShoppingListVM : ViewModelBase
    {
        private ShoppingList _shoppingList;
        public ObservableCollection<ShoppingListItemVM> ShoppingList
        {
            get
            {
                return new ObservableCollection<ShoppingListItemVM>(this._shoppingList.ShoppingListItems.Select(s => new ShoppingListItemVM(s, this)).ToList());
            }
        }
        public double TotalPrice
        {
            get
            {
                return _shoppingList.TotalPrice;
            }
        }
        public void AmountChanged()
        {
            RaisePropertyChanged("TotalPrice");
        }

        public void AddShoppingListItem(ShoppingListItemVM item)
        {
            this._shoppingList.ShoppingListItems.Add(item.GetShoppingListItem());
            RaisePropertyChanged("ShoppingList");
            RaisePropertyChanged("TotalPrice");
        }
        public void IncreaseAmmount(Product product, Brand brand)
        {
            this._shoppingList.ShoppingListItems.Where(s => s.BrandProduct.Brand.Equals(brand) && s.BrandProduct.Product.Equals(product)).First().Amount++;
            RaisePropertyChanged("ShoppingList");
            RaisePropertyChanged("TotalPrice");
        }
        public ShoppingListVM(Database datab)
        {
            this._shoppingList = new ShoppingList();

        }

        public void RemoveProduct(ShoppingListItemVM SelectedShoppingListItem)
        {
            this._shoppingList.ShoppingListItems.Remove(SelectedShoppingListItem.GetShoppingListItem());
            RaisePropertyChanged("ShoppingList");
            RaisePropertyChanged("TotalPrice");
        }
    }
}
