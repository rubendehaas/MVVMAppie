using MVVMAppie.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.Model
{
    public class Database : IDisposable
    {
        private MyEntityContext context = new MyEntityContext();
        private Repository<Product> productRepository;
        private Repository<BrandProduct> brandProductRepository;
        private Repository<Brand> brandRepository;
        private Repository<Coupon> couponRepository;
        private Repository<Recipe> recipeRepository;
        private Repository<Section> sectionRepository;

        public Repository<Product> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                    this.productRepository = new Repository<Product>(context);
                return productRepository;
            }
        }

        public Repository<BrandProduct> BrandProductRepository
        {
            get
            {
                if (this.brandProductRepository == null)
                    this.brandProductRepository = new Repository<BrandProduct>(context);
                return brandProductRepository;
            }
        }

        public Repository<Brand> BrandRepository
        {
            get
            {
                if (this.brandRepository == null)
                    this.brandRepository = new Repository<Brand>(context);
                return brandRepository;
            }
        }

        public Repository<Coupon> CouponRepository
        {
            get
            {
                if (this.couponRepository == null)
                    this.couponRepository = new Repository<Coupon>(context);
                return couponRepository;
            }
        }

        public Repository<Recipe> RecipeRepository
        {
            get
            {
                if (this.recipeRepository == null)
                    this.recipeRepository = new Repository<Recipe>(context);
                return recipeRepository;
            }
        }

        public Repository<Section> SectionRepository
        {
            get
            {
                if (this.sectionRepository == null)
                    this.sectionRepository = new Repository<Section>(context);
                return sectionRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
