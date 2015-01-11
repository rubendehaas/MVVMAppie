using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class DiscountManageViewModel : ViewModelBase
    {
        private Database datab;
        private CouponsVM _coupons;
        private CouponVM _selectedCoupon;
        private string _textAddName;
        private string _textAddCode;
        private double _price;
        private DateTime _startDate;
        private DateTime _endDate;

        public CouponsVM Coupons
        {
            get
            {
                return _coupons;
            }
        }

        public String TextAddName
        {
            get
            {
                return _textAddName;
                ;
            }

            set
            {
                _textAddName = value;
                RaisePropertyChanged("TextAddName");
            }
        }

        public String TextAddCode
        {
            get
            {
                return _textAddCode;
            }

            set
            {
                _textAddCode = value;
                RaisePropertyChanged("TextAddCode");
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
                RaisePropertyChanged("Price");
            }
        }

        public DateTime TextAddStartDate
        {
            get
            {
                return _startDate;
            }

            set
            {
                _startDate = value;
                RaisePropertyChanged("Price");
            }
        }

        public DateTime TextAddEndDate
        {
            get
            {
                return _endDate;
            }

            set
            {
                _endDate = value;
                RaisePropertyChanged("Price");
            }
        }

        public CouponVM SelectedCoupon
        {
            get
            {
                return _selectedCoupon;
            }

            set
            {
                _selectedCoupon = value;
                if (_selectedCoupon != null)
                {
                    TextAddName = _selectedCoupon.GetCoupon().Name;
                    TextAddCode = _selectedCoupon.GetCoupon().Code;
                    Price = _selectedCoupon.GetCoupon().Amount;
                    TextAddStartDate = _selectedCoupon.GetCoupon().StartDate;
                    TextAddEndDate = _selectedCoupon.GetCoupon().EndDate;
                }
                else {
                    TextAddName = "";
                    TextAddCode = "";
                    Price = 0;
                }
                
                RaisePropertyChanged("SelectedBrand");
            }
        }

        public RelayCommand AddDiscountCommand { get; set; }
        public RelayCommand DeleteDiscountCommand { get; set; }
        public RelayCommand EditDiscountCommand { get; set; }

        private void Add()
        {
            _coupons.AddDiscount(TextAddName, TextAddCode, Price, TextAddStartDate, TextAddEndDate);
            TextAddName = "";
        }

        private void Delete()
        {
            if (_selectedCoupon != null)
            {
                _coupons.DeleteDiscount(_selectedCoupon.GetCoupon());
            }
        }

        private void Edit()
        {
            if (_selectedCoupon != null)
            {
                _coupons.EditDiscount(TextAddName, TextAddCode, Price, TextAddStartDate, TextAddEndDate, _selectedCoupon.GetCoupon());
                RaisePropertyChanged("Coupons");
            }
        }


        public DiscountManageViewModel(Database datab, CouponsVM Coupons)
        {
            this.datab = datab;
            this._coupons = Coupons;
            this.DeleteDiscountCommand = new RelayCommand(Delete);
            this.AddDiscountCommand = new RelayCommand(Add);
            this.EditDiscountCommand = new RelayCommand(Edit);
        }
    }
}
