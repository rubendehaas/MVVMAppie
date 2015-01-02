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
        private Database database;
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

        public ObservableCollection<CouponVM> Coupons
        {
            get
            {
                return new ObservableCollection<CouponVM>(this._shoppingList.Coupons.Select(c => new CouponVM(c, this)).ToList());
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
            this.database = datab;
            this._shoppingList = new ShoppingList();

        }

        public void RemoveProduct(ShoppingListItemVM SelectedShoppingListItem)
        {
            this._shoppingList.ShoppingListItems.Remove(SelectedShoppingListItem.GetShoppingListItem());
            RaisePropertyChanged("ShoppingList");
            RaisePropertyChanged("TotalPrice");
        }

        public void RemoveCoupon(CouponVM SelectedCoupon)
        {
            throw new NotImplementedException();
        }

        public void AddCoupon(string TextIn)
        {
            Coupon coupon = database.CouponRepository.GetAll().Where(c => c.Code.Equals(TextIn)).FirstOrDefault();
            this._shoppingList.Coupons.Add(coupon);
            RaisePropertyChanged("Coupons");
        }
    }
}
