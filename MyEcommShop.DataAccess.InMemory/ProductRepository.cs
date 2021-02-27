using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyEcommShop.Core.Models;

namespace MyEcommShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> MyProduct;
        public ProductRepository()
        {
            MyProduct = cache["MyProduct"] as List<Product>;
            if (MyProduct == null)
            {
                MyProduct = new List<Product>();
            }
        }
        public void Commit()
        {
            cache["MyProduct"] = MyProduct;
        }

        public void Insert(Product product)
        {
            MyProduct.Add(product);
        }

        public void Update(Product product)
        {
            Product productToUpdate = MyProduct.Find(p => p.ID == product.ID );

            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public Product Find(string ID)
        {
            Product product = MyProduct.Find(p => p.ID == ID);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product not found");
            }

        }

        public IQueryable<Product> Collection()
        {
            return MyProduct.AsQueryable();
        }

        public void Delete(string Id)
        {
            Product productToDelete = MyProduct.Find(p => p.ID == Id);

            if (productToDelete != null)
            {
                MyProduct.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
    
}
