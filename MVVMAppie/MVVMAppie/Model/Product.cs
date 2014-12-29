using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.Model
{
    class Product
    {
        [Key]
        public int ProductId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public virtual List<Brand> Brands
        {
            get;
            set;
        }

        public virtual List<Coupon> Coupons
        {
            get;
            set;
        }

        public virtual Section Section
        {
            get;
            set;
        }
    }
}
