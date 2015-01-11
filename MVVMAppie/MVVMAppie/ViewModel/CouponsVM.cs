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
    public class CouponsVM : ViewModelBase
    {
        private List<Coupon> _coupons;
        private Database database;

        public ObservableCollection<CouponVM> Coupons
        {
            get
            {
                return new ObservableCollection<CouponVM>(this._coupons.Select(c => new CouponVM(c)).ToList());
            }
        }
        public CouponsVM(Database datab)
        {
            this.database = datab;
            this._coupons = datab.CouponRepository.GetAll().ToList();
        }

        public void AddDiscount(string name, string code, double price, DateTime startDate, DateTime endDate)
        {
            Coupon coupon = new Coupon
            {
                Name = name,
                Code = code,
                Amount = price,
                StartDate = startDate,
                EndDate = endDate
            };

            this.database.CouponRepository.Create(coupon);
            this.database.Save();
            this._coupons = this.database.CouponRepository.GetAll().ToList();
            RaisePropertyChanged("Coupons");
        }

        public void EditDiscount(string name, string code, double price, DateTime startDate, DateTime endDate, Coupon coupon)
        {
            coupon.Name = name;
            coupon.Code = code;
            coupon.Amount = price;
            coupon.StartDate = startDate;
            coupon.EndDate = endDate;

            this.database.CouponRepository.Update(coupon);
            this.database.Save();

            this._coupons = this.database.CouponRepository.GetAll().ToList();
        }

        public void DeleteDiscount(Coupon coupon)
        {
            this.database.CouponRepository.Delete(coupon);
            this.database.Save();

            this._coupons = this.database.CouponRepository.GetAll().ToList();
            RaisePropertyChanged("Coupons");
        }


        public void BindProduct(Brand brand, Product product, double price)
        {
            BrandProduct brandProduct = new BrandProduct
            {
                Brand = brand,
                Product = product,
                Price = price
            };
            product.Brands.Add(brand);
            this.database.ProductRepository.Update(product);
            this.database.BrandProductRepository.Create(brandProduct);
            this.database.Save();

        }

        public void UnbindProduct(Brand brand, Product product)
        {
            this.database.BrandProductRepository.Delete(database.BrandProductRepository.GetAll().Where(b => b.Brand.Equals(brand) && b.Product.Equals(product)).First());
            product.Brands.Remove(brand);
            this.database.ProductRepository.Update(product);
            this.database.Save();
        }

        public ObservableCollection<BrandVM> GetPickerBrands(Product product)
        {
            if (product.Brands != null)
            {
                return new ObservableCollection<BrandVM>(product.Brands.Select(c => new BrandVM(c)).ToList());
            }
            else
            {
                return null;
            }

        }

        public ObservableCollection<BrandVM> GetUnbindedBrands(Product product)
        {
            return new ObservableCollection<BrandVM>(database.BrandRepository.GetAll().Except(product.Brands).Select(c => new BrandVM(c)).ToList());
        }

    }
}
