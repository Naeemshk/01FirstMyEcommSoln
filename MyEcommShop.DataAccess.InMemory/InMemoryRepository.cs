using MyEcommShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommShop.DataAccess.InMemory
{
    public class InMemoryRepository<T> where T: CommonClassBaseEntries
    {
        ObjectCache cache = MemoryCache.Default;

    }
}
