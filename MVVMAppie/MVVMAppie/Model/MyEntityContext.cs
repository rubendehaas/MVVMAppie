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
    } 
}
