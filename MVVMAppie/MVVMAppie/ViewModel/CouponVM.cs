using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMAppie.ViewModel
{
    public class CouponVM
    {

        private Coupon _coupon;
        private ShoppingListVM _shoppingList;

        public String Name
        {
            get
            {
                return _coupon.Name;
            }
        }

        public CouponVM(Coupon item, ShoppingListVM shoppingList)
        {
            this._coupon = item;
            this._shoppingList = shoppingList;
        }
    }
}
