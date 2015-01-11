using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class DiscountConnectViewModel : ViewModelBase
    {

        private Database database;
        private CouponsVM _coupons;
        private ProductsVM _productsCollection;
        private BrandsVM _brandsCollection;
        private ProductVM _selectedProduct;
        private CouponVM _selectedCoupon;
        private ProductVM _selectedUnselectedProduct;
        private ProductVM _selectedSelectedProduct;
        private RelayCommand addBrandCommand;
        private RelayCommand removeBrandCommand;
        private string _textIn;


        public CouponsVM Coupons
        {
            get
            {
                return _coupons;
            }
        }

        public ProductsVM ProductsCollection
        {
            get
            {
                return _productsCollection;
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
                RaisePropertyChanged("SelectedCoupon");
            }
        }

        public ProductVM SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }

            set
            {
                _selectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
                RaisePropertyChanged("SelectedUnSelectedProduct");
                RaisePropertyChanged("SelectedSelectedProduct");
            }
        }

        public ProductVM SelectedUnSelectedProduct
        {
            get
            {
                return _selectedUnselectedProduct;
            }

            set
            {
                _selectedUnselectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
                RaisePropertyChanged("SelectedUnSelectedProduct");
                RaisePropertyChanged("SelectedSelectedProduct");
            }
        }

        public ProductVM SelectedSelectedProduct
        {
            get
            {
                return _selectedSelectedProduct;
            }

            set
            {
                _selectedSelectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
                RaisePropertyChanged("SelectedUnSelectedProduct");
                RaisePropertyChanged("SelectedSelectedProduct");
            }
        }

        public DiscountConnectViewModel(Database datab, CouponsVM Coupons)
        {
            this.database = datab;
            this._coupons = Coupons;
        }

    }
}
