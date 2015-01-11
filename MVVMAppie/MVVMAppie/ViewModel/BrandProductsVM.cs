using GalaSoft.MvvmLight;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class BrandProductsVM : ViewModelBase
    {
        private List<BrandProduct> _products;
        private Database database;

        public ObservableCollection<BrandProductVM> Products
        {
            get
            {
                return new ObservableCollection<BrandProductVM>(this._products.Select(c => new BrandProductVM(c)).ToList());
            }
        }

        public ObservableCollection<BrandProductVM> GetBindedBrandProducts(Coupon coupon)
        {
            if (coupon != null)
            {
                return new ObservableCollection<BrandProductVM>(coupon.BrandProduct.Select(c => new BrandProductVM(c)).ToList());
            }
            else
            {
                return null;
            }

        }

        public ObservableCollection<BrandProductVM> GetUnbindedBrandProducts(Coupon coupon)
        {
            if (coupon != null)
            {
                return new ObservableCollection<BrandProductVM>(database.BrandProductRepository.GetAll().Except(coupon.BrandProduct).Select(c => new BrandProductVM(c)).ToList());
            }
            else
            {
                return null;
            }
        }

        public BrandProductsVM(Database datab)
        {
            this.database = datab;
            this._products = datab.BrandProductRepository.GetAll().ToList();
        }

        public void BindProduct(BrandProduct brandProduct, Coupon coupon)
        {
            coupon.BrandProduct.Add(brandProduct);
            this.database.CouponRepository.Update(coupon);
            database.Save();
            this._products = database.BrandProductRepository.GetAll().ToList();
        }

        public void UnbindProduct(BrandProduct brandProduct, Coupon coupon)
        {
            coupon.BrandProduct.Remove(brandProduct);
            this.database.CouponRepository.Update(coupon);
            database.Save();
            this._products = database.BrandProductRepository.GetAll().ToList();
        }
    }
}
