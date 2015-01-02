/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MVVMAppie"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MVVMAppie.Model;

namespace MVVMAppie.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            
            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    // Create design time view services and models
            //    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            //}
            //else
            //{
            //    // Create run time view services and models
            //    SimpleIoc.Default.Register<IDataService, DataService>();
            //}
            SimpleIoc.Default.Register<Database>();
            SimpleIoc.Default.Register<ShoppingListVM>();
            SimpleIoc.Default.Register<SectionsVM>();
            SimpleIoc.Default.Register<ProductsVM>();
            SimpleIoc.Default.Register<BrandsVM>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ProductPickerViewModel>();
            SimpleIoc.Default.Register<RecipePickerViewModel>();
            SimpleIoc.Default.Register<CouponManageViewModel>();

            //Maak een section manager
            SimpleIoc.Default.Register<SectionManageViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ProductPickerViewModel ProductPicker
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProductPickerViewModel>();
            }
        }

        public RecipePickerViewModel RecipePicker
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RecipePickerViewModel>();
            }
        }

        public CouponManageViewModel CouponManager
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CouponManageViewModel>();
            }
        }

        //Nodig om een Viewmodel te openen
        public SectionManageViewModel SectionManager
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SectionManageViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}