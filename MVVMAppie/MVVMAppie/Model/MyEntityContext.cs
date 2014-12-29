using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.Model
{
    public class MyEntityContext : DbContext
    {
        public MyEntityContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Product> Product
        {
            get;
            set;
        }

        public DbSet<BrandProduct> BrandProduct
        {
            get;
            set;
        }

        public DbSet<Brand> Brand
        {
            get;
            set;
        }

        public DbSet<Coupon> Coupon
        {
            get;
            set;
        }

        public DbSet<Recipe> Recipe
        {
            get;
            set;
        }

        public DbSet<Section> Section
        {
            get;
            set;
        }
        public DbSet<ShoppingList> ShoppingList
        {
            get;
            set;
        }
    } 
}
