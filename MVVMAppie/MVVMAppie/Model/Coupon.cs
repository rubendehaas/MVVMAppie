using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVVMAppie.Model
{
    public class Coupon
    { 
        [Key]
        public int CouponId
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }

        public string Code
        {
            get;
            set;
        }
        public virtual List<BrandProduct> BrandProduct
        {
            get;
            set;
        }
    }
}
