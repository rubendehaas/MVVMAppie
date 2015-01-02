using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.Model
{
    public class BrandProduct
    {
        [Key]
        public int BrandProductId
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }

        public virtual Product Product
        {
            get;
            set;
        }

        public virtual Brand Brand
        {
            get;
            set;
        }

        public virtual List<Recipe> Recipes
        {
            get;
            set;
        }

        public virtual List<Coupon> Coupons
        {
            get;
            set;
        }
    }
}
