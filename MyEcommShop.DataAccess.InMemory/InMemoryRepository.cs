using MyEcommShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommShop.DataAccess.InMemory
{
    // this is Generic class showing T is any type we recieved
    // if T type is product then Product list will be created
    // if T type is ProductCatagory then Product Catagory Liist will be created
    public class InMemoryRepository<T> where T: CommonClassBaseEntries
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> MyItemList;
        string RecvdObjectTypeName ;
        public InMemoryRepository()
        {
            RecvdObjectTypeName = typeof(T).Name; // will return eaither Product or ProductCatagory
            MyItemList = cache[RecvdObjectTypeName] as List<T>;
            if(MyItemList == null)
            {
                MyItemList = new List<T>();
            }

        }
        public void Commit()
        {
            cache[RecvdObjectTypeName] = MyItemList;
        }
        public void Insert(T t)
        {
            MyItemList.Add(t);
        }
        public void Update(T t)
        {
            T tToUpdate = MyItemList.Find(x => x.ID == t.ID);
            if (tToUpdate != null)
            {
                tToUpdate = t;
            }
            else
            {
                throw new Exception("Product Catagory not found");
            }
        }
        public T Find(string ID)
        {
            T t = MyItemList.Find(x => x.ID == ID);
            if(t != null)
            {
                return t;
            }
            else
            {
                throw new Exception("Product Catagory not found");
            }
        }
        public IQueryable<T> Collection()
        {
            return MyItemList.AsQueryable();
        }
        public void Delete(string ID)
        {
            T tToDelet = MyItemList.Find(x => x.ID == ID);
            if(tToDelet != null)
            {
                MyItemList.Remove(tToDelet);
            }
            else
            {
                throw new Exception("Product Catagory not found");
            }
        }


    }
}
