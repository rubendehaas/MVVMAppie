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
        private BrandProductsVM _productsCollection;
        private CouponVM _selectedCoupon;
        private BrandProductVM _selectedUnselectedProduct;
        private BrandProductVM _selectedSelectedProduct;
        private RelayCommand addDiscountCommand;
        private RelayCommand removeDiscountCommand;


        public CouponsVM Coupons
        {
            get
            {
                return _coupons;
            }
        }

        public BrandProductsVM ProductsCollection
        {
            get
            {
                return _productsCollection;
            }
        }

        public ObservableCollection<BrandProductVM> UnselectedProducts
        {
            get
            {
                if (this.SelectedCoupon != null)
                {
                    return ProductsCollection.GetUnbindedBrandProducts(this.SelectedCoupon.GetCoupon());
                }
                else
                {
                    return null;
                }
            }
        }

        public ObservableCollection<BrandProductVM> SelectedProducts
        {
            get
            {
                if (this.SelectedCoupon != null)
                {
                    return ProductsCollection.GetBindedBrandProducts(this.SelectedCoupon.GetCoupon());
                }
                else
                {
                    return null;
                }
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
                RaisePropertyChanged("SelectedProducts");
                RaisePropertyChanged("UnselectedProducts");
            }
        }

        public BrandProductVM SelectedUnSelectedProduct
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

        public BrandProductVM SelectedSelectedProduct
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

        public RelayCommand AddDiscountCommand
        {
            get
            {
                if (addDiscountCommand == null)
                {
                    addDiscountCommand = new RelayCommand(() =>
                    {
                        this.AddDiscount();
                    });
                }
                return addDiscountCommand;
            }
        }

        private void AddDiscount()
        {
            if (this.SelectedUnSelectedProduct != null && this.SelectedCoupon != null)
            {
                this.ProductsCollection.BindProduct(this.SelectedUnSelectedProduct.GetProduct(), this.SelectedCoupon.GetCoupon());
                this.SelectedUnSelectedProduct = null;
                this.RaisePropertyChanged("SelectedProducts");
                this.RaisePropertyChanged("UnselectedProducts");
            }
        }

        public RelayCommand RemoveDiscountCommand
        {
            get
            {
                if (removeDiscountCommand == null)
                {
                    removeDiscountCommand = new RelayCommand(() =>
                    {
                        this.RemoveDiscount();
                    });
                }
                return removeDiscountCommand;
            }
        }

        private void RemoveDiscount()
        {
            if (this.SelectedSelectedProduct != null && this.SelectedCoupon != null)
            {
                this.ProductsCollection.UnbindProduct(this.SelectedUnSelectedProduct.GetProduct(), this.SelectedCoupon.GetCoupon());
                this.SelectedUnSelectedProduct = null;
                this.RaisePropertyChanged("SelectedProducts");
                this.RaisePropertyChanged("UnselectedProducts");
            }
        }

        public DiscountConnectViewModel(Database datab, CouponsVM Coupons, BrandProductsVM products)
        {
            this.database = datab;
            this._coupons = Coupons;
            this._productsCollection = products;
        }

    }
}
