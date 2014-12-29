﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.Model
{
    public class Brand
    {
        [Key]
        public int BrandId
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public virtual List<Product> Products
        {
            get;
            set;
        }
    }
}
