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
    public class RecipePickerViewModel : ViewModelBase
    {
        private Database database;
        private ShoppingListViewModel _shoppingList;
        public ObservableCollection<RecipeVM> Recipes
        {
            get;
            set;
        }

        private RecipeVM _selectedRecipe;

        public RecipeVM SelectedRecipe
        {
            get
            {
                return _selectedRecipe;
            }

            set
            {
                _selectedRecipe = value;
                RaisePropertyChanged("SelectedRecipe");
            }
        }

        private RelayCommand addRecipeCommand;
        public RelayCommand AddRecipeCommand
        {
            get
            {
                if (addRecipeCommand == null)
                {
                    addRecipeCommand = new RelayCommand(() =>
                    {
                        this.AddRecipe();
                    });
                }
                return addRecipeCommand;
            }
        }

        private void AddRecipe()
        {
            Recipe recipe = database.RecipeRepository.GetAll().Where(r => r.Name == SelectedRecipe.Name).First();
            foreach (BrandProduct brandProduct in recipe.BrandProducts)
            {
                if (_shoppingList.ShoppingList.Where(s => s.Name == brandProduct.Product.Name && s.Brand == brandProduct.Brand.Name).Count() == 0)
                {
                    _shoppingList.AddShoppingListItem(new ShoppingListItemVM(new ShoppingListItem
                    {
                        Amount = 1,
                        BrandProduct = brandProduct
                    }));
                }
                else
                {
                    _shoppingList.IncreaseAmmount(brandProduct.Product.Name, brandProduct.Brand.Name);
                }
            }

            
        }


        public RecipePickerViewModel(Database datab, ShoppingListViewModel shoppingList)
        {
            this.database = datab;
            this._shoppingList = shoppingList;
            List<Recipe> recipes = database.RecipeRepository.GetAll().ToList();
            List<RecipeVM> recipeVM = recipes.Select(r => new RecipeVM(r)).ToList();
            Recipes = new ObservableCollection<RecipeVM>(recipeVM);
        }
    }
}
