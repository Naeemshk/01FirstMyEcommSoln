using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyEcommShop.Core.Models;

namespace MyEcommShop.DataAccess.InMemory
{
    public class ProductCatagoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCatagory> MyProductCatagory;
        public ProductCatagoryRepository()
        {
            MyProductCatagory = cache["MyProductCatagory"] as List<ProductCatagory>;
            if (MyProductCatagory == null)
            {
                MyProductCatagory = new List<ProductCatagory>();
            }
        }
        public void Commit()
        {
            cache["MyProductCatagory"] = MyProductCatagory;
        }

        public void Insert(ProductCatagory  productcatagory)
        {
            MyProductCatagory.Add(productcatagory);
        }

        public void Update(ProductCatagory  productcatagory)
        {
            ProductCatagory productCatagToUpdate = MyProductCatagory.Find(p => p.Id == productcatagory.Id );

            if (productCatagToUpdate != null)
            {
                productCatagToUpdate = productcatagory ;
            }
            else
            {
                throw new Exception("Product Catagory not found");
            }
        }

        public ProductCatagory Find(string Id)
        {
            ProductCatagory  productcatag = MyProductCatagory.Find(p => p.Id == Id);

            if (productcatag != null)
            {
                return productcatag;
            }
            else
            {
                throw new Exception("Product Catagory not found");
            }

        }

        public IQueryable<ProductCatagory> Collection()
        {
            return MyProductCatagory.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCatagory  productcatagToDelete = MyProductCatagory.Find(p => p.Id == Id);

            if (productcatagToDelete != null)
            {
                MyProductCatagory.Remove(productcatagToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
    
}
