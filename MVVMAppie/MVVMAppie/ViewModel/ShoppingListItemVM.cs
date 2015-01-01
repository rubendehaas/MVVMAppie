using GalaSoft.MvvmLight;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class ShoppingListItemVM :   ViewModelBase
    {
        private ShoppingListItem _shoppingListItem;

        public String Name
        {
            get
            {
                return _shoppingListItem.BrandProduct.Product.Name;
            }
        }

        public String Brand
        {
            get
            {
                return _shoppingListItem.BrandProduct.Brand.Name;
            }
        }

        public double Price
        {
            get
            {
                return _shoppingListItem.BrandProduct.Price;
            }
        }

        public int Amount
        {
            get
            {
                return _shoppingListItem.Amount;
            }
            set
            {
                _shoppingListItem.Amount = value;
                RaisePropertyChanged("Amount");
            }
        }

        public ShoppingListItemVM(ShoppingListItem item)
        {
            _shoppingListItem = item;
        }
    }
}
