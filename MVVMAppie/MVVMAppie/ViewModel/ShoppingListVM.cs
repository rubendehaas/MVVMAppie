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

        public double Discount
        {
            get
            {
                return _shoppingList.Discount;
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
            RaisePriceChanges();
        }

        public void AddShoppingListItem(ShoppingListItemVM item)
        {
            this._shoppingList.ShoppingListItems.Add(item.GetShoppingListItem());
            RaisePropertyChanged("ShoppingList");
            RaisePriceChanges();
        }
        public void IncreaseAmmount(Product product, Brand brand)
        {
            this._shoppingList.ShoppingListItems.Where(s => s.BrandProduct.Brand.Equals(brand) && s.BrandProduct.Product.Equals(product)).First().Amount++;
            RaisePropertyChanged("ShoppingList");
            RaisePriceChanges();
        }
        public ShoppingListVM(Database datab)
        {
            this.database = datab;
            this._shoppingList = new ShoppingList();

        }

        public void RemoveProduct(ShoppingListItemVM SelectedShoppingListItem)
        {
            if (SelectedShoppingListItem != null)
            {
                this._shoppingList.ShoppingListItems.Remove(SelectedShoppingListItem.GetShoppingListItem());
                RaisePropertyChanged("ShoppingList");
                RaisePriceChanges();
            }
        }

        public void RemoveCoupon(CouponVM coupon)
        {
            this._shoppingList.Coupons.Remove(coupon.GetCoupon());
            RaisePriceChanges();
            RaisePropertyChanged("Coupons");
        }

        public String AddCoupon(string TextIn)
        {
            if (database.CouponRepository.GetAll().Where(c => c.Code.Equals(TextIn)).Count() > 0)
            {
                Coupon coupon = database.CouponRepository.GetAll().Where(c => c.Code.Equals(TextIn)).First();
                if (coupon.StartDate <= DateTime.Now && coupon.EndDate >= DateTime.Now)
                {
                    this._shoppingList.Coupons.Add(coupon);
                    RaisePriceChanges();
                    RaisePropertyChanged("Coupons");
                    return null;
                }
                else
                {
                    return "This coupon is not valid today";
                }
                
            }
            else
            {
                return "Coupon not found";
            }
        }

        private void RaisePriceChanges()
        {
            RaisePropertyChanged("TotalPrice");
            RaisePropertyChanged("Discount");
        }
    }
}
