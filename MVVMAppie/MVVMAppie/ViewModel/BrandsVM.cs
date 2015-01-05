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
    public class BrandsVM : ViewModelBase
    {
        private List<Brand> _brands;
        private Database database;

        public ObservableCollection<BrandVM> Brands
        {
            get
            {
                //geef een observable collection (soort list) terug van _brands
                return new ObservableCollection<BrandVM>(this._brands.Select(c => new BrandVM(c)).ToList());
            }
        }
        public BrandsVM(Database datab)
        {
            this.database = datab;
            this._brands = datab.BrandRepository.GetAll().ToList();
        }


        public void AddBrand(string TextIn)
        {
            Brand brand = new Brand
            {
                Name = TextIn
            };
            this.database.BrandRepository.Create(brand);
            this.database.Save();
            this._brands = this.database.BrandRepository.GetAll().ToList();
            RaisePropertyChanged("Brands");
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

        public void DeleteBrand(Brand brand)
        {
            this.database.BrandRepository.Delete(brand);
            this.database.Save();

            this._brands = this.database.BrandRepository.GetAll().ToList();
            RaisePropertyChanged("Brands");
        }
    }
}
