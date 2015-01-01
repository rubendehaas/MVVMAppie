using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.Model.Repository
{
    public class BrandProductRepository : Repository<BrandProduct>
    {
        public BrandProductRepository(MyEntityContext context)
            : base(context)
        {
        }
        public BrandProduct GetBySelection(Brand brand, Product product)
        {
            BrandProduct test = this.dbSet.Where(b => b.Brand.BrandId == brand.BrandId && b.Product.ProductId == product.ProductId).First();
            return test;
        }
    }
}
