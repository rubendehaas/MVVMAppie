using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class CouponManageViewModel : ViewModelBase
    {
        private Database database;
        private ShoppingListVM _shoppingList;
        private List<Coupon> _coupons;
        private CouponVM _selectedCoupon;

        private String _textIn;
        public ShoppingListVM ShoppingList
        {
            get
            {
                return _shoppingList;
            }
        }

        public CouponVM SelectedCoupon
        {
            get
            {
                return _selectedCoupon;
                ;
            }

            set{
                _selectedCoupon = value;
                RaisePropertyChanged("SelectedCoupon");
            }
        }

        public String TextIn
        {
            get
            {
                return _textIn;
                ;
            }

            set
            {
                _textIn = value;
                RaisePropertyChanged("TextIn");
            }
        }

        private RelayCommand removeCouponCommand;
        public RelayCommand RemoveCouponCommand
        {
            get
            {
                if (removeCouponCommand == null)
                {
                    removeCouponCommand = new RelayCommand(() =>
                    {
                        ShoppingList.RemoveCoupon(SelectedCoupon);
                    });
                }
                return removeCouponCommand;
            }
        }
        private RelayCommand addCouponCommand;
        public RelayCommand AddCouponCommand
        {
            get
            {
                if (addCouponCommand == null)
                {
                    addCouponCommand = new RelayCommand(() =>
                    {
                        ShoppingList.AddCoupon(TextIn);
                    });
                }
                return addCouponCommand;
            }
        }

        public CouponManageViewModel(Database datab, ShoppingListVM shoppingList)
        {
            this.database = datab;
            this._shoppingList = shoppingList;

            List<Coupon> coupons = database.CouponRepository.GetAll().ToList();
        }
    }
}
