﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.Model
{
    public class ShoppingList
    {
        [Key]
        public int ShoppingListId
        {
            get;
            set;
        }
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
    }
}
