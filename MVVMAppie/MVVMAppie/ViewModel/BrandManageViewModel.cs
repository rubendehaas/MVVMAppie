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
    public class BrandManageViewModel : ViewModelBase
    {
        private Database datab;
        private BrandsVM _brands;
        private BrandVM _selectedBrand;

        private string _textIn;

        public BrandsVM Brands
        {
            get
            {
                return _brands;
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

        public BrandVM SelectedBrand
        {
            get
            {
                return _selectedBrand;
            }

            set
            {
                _selectedBrand = value;
                RaisePropertyChanged("SelectedBrand");
            }
        }

        public RelayCommand AddBrandCommand { get; set; }
        public RelayCommand DeleteBrandCommand { get; set; }

        private void Add()
        {
            _brands.AddBrand(TextIn);
            TextIn = "";
        }

        private void Delete()
        {
            if(_selectedBrand != null){
                _brands.DeleteBrand(_selectedBrand.GetBrand());
            }
        }

        public BrandManageViewModel(Database datab, BrandsVM Brands)
        {
            this.datab = datab;
            this._brands = Brands;
            this.DeleteBrandCommand = new RelayCommand(Delete);
            this.AddBrandCommand = new RelayCommand(Add);
        }
    }
}
