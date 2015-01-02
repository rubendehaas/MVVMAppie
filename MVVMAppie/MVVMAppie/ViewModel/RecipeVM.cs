using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class RecipeVM
    {
        private Recipe _recipe;

        public String Name
        {
            get
            {
                return _recipe.Name;
            }
        }

        public RecipeVM(Recipe item)
        {
            _recipe = item;
        }
    }
}
