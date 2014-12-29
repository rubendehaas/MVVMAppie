using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.Model
{
    class Section
    {
        [Key]
        public int SectionId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
        public List<Product> Products
        {
            get;
            set;
        }
    }
}
