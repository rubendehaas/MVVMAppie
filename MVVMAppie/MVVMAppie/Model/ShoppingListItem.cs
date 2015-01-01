using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.Model
{
    public class ShoppingListItem
    {
        [Key]
        public int ShoppingListItemId
        {
            get;
            set;
        }
        public virtual  BrandProduct BrandProduct
        {
            get;
            set;
        }

        public int Amount
        {
            get;
            set;
        }
    }
}
