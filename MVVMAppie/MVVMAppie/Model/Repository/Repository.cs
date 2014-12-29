using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.Model.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal MyEntityContext context;
        internal DbSet<T> dbSet;


        public Repository(MyEntityContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual void Create(T entity)
        {
            this.dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = System.Data.Entity.EntityState.Deleted;
        }

        public virtual void Update(T entity)
        {
            var entry = this.context.Entry(entity);
            this.dbSet.Attach(entity);
            entry.State = System.Data.Entity.EntityState.Modified;
        }

        public virtual T Get(long id)
        {
            return this.dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.dbSet;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate);
        }
    }
}
