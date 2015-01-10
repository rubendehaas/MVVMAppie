using GalaSoft.MvvmLight;
using MVVMAppie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppie.ViewModel
{
    public class ProductsVM : ViewModelBase
    {
        private List<Product> _products;
        private Database database;

        public ObservableCollection<ProductVM> Products
        {
            get
            {
                return new ObservableCollection<ProductVM>(this._products.Select(c => new ProductVM(c)).ToList());
            }
        }
        public ProductsVM(Database datab)
        {
            this.database = datab;
            this._products = datab.ProductRepository.GetAll().ToList();
        }


        public void AddProductCommand(string TextIn, Section section)
        {
            Product product = new Product
            {
                Name = TextIn,
                Section = section
            };

            this.database.ProductRepository.Create(product);
            this.database.Save();

            this._products = this.database.ProductRepository.GetAll().ToList();
        }

        public void DeleteProductCommand(Product product)
        {

            this.database.ProductRepository.Delete(product);
            this.database.Save();

            this._products = this.database.ProductRepository.GetAll().ToList();
        }

        public ObservableCollection<ProductVM> GetPickerProducts(Section section)
        {
            if (section.Products != null)
            {
                return new ObservableCollection<ProductVM>(section.Products.Select(c => new ProductVM(c)).ToList());
            }
            else
            {
                return null;
            }
        }

        public ObservableCollection<ProductVM> GetPickerProducts2(Section section)
        {
            if (section.Products != null)
            {

                return new ObservableCollection<ProductVM>(section.Products.Select(c => new ProductVM(c)).Where(d => d.GetProduct().Section.SectionId == section.SectionId).ToList());
            }
            else
            {
                return null;
            }
        }
    }
}
