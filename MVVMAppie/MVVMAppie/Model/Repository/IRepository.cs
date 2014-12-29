using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.Model.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(long Id);
        IEnumerable<T> GetAll();
    }
}
