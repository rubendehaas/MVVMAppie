using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.Model
{
    public class ShoppingList
    {
        public virtual List<ShoppingListItem> ShoppingListItems
        {
            get;
            set;
        }

        public virtual List<Coupon> Coupons
        {
            get;
            set;
        }

        public double Discount
        {
            get
            {
                double x = 0;
                foreach (Coupon coupon in Coupons)
                {
                    if (coupon.BrandProduct.Count > 0)
                    {
                        foreach (BrandProduct product in coupon.BrandProduct)
                        {
                            if (ShoppingListItems.Count > 0)
                            {
                                foreach (ShoppingListItem item in ShoppingListItems)
                                {
                                    if (item.BrandProduct.Equals(product))
                                    {
                                        x = x + (item.Amount * coupon.Amount);
                                    }
                                }
                            }
                        }
                    }
                }
                return Math.Round(x, 2);
            }
        }

        public double TotalPrice
        {
            get
            {
                double x = 0;
                foreach (ShoppingListItem i in ShoppingListItems)
                {
                    x = x + (i.Amount * i.BrandProduct.Price);
                }
                x = x - this.Discount;
                return Math.Round(x, 2);
            }
        }

        public ShoppingList()
        {
            this.ShoppingListItems = new List<ShoppingListItem>();
            this.Coupons = new List<Coupon>();
        }
    }
}
