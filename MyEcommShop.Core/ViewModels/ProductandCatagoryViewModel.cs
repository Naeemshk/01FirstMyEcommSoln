using MyEcommShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommShop.Core.ViewModels
{
    public class ProductandCatagoryViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<ProductCatagory> ProductCatagories { get; set; }
    }
}
