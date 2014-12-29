using GalaSoft.MvvmLight;
using MVVMAppie.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMAppie.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        private Database database;
        public ObservableCollection<BrandProductVM> ShoppingList
        {
            get;
            set;
        }

        private BrandProductVM _selectedBrandProduct;

        public BrandProductVM SelectedBrandProduct
        {
            get
            {
                return _selectedBrandProduct;
            }

            set{
                _selectedBrandProduct = value;
                RaisePropertyChanged("SelectedBrandProducts");
            }
        }

        public MainViewModel(Database datab)
        {
            this.database = datab;
            
            //Stap 1. Ophalen van onze data
            List<BrandProduct> brandProducts = database.BrandProductRepository.GetAll().ToList();

            //stap 2. omzetten van model naar viewmodel
            List<BrandProductVM> brandProductsVM = brandProducts.Select(s => new BrandProductVM(s)).ToList();

            //Stap 3. Toevoegen van del ijst aan de observable collectie
            ShoppingList = new ObservableCollection<BrandProductVM>(brandProductsVM);
        }
    }
}