﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.Model
{
    public class Recipe
    {
        [Key]
        public int RecipeId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public virtual List<BrandProduct> BrandProducts
        {
            get;
            set;
        }
    }
}
