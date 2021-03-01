using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommShop.Core.Models
{
    public class ProductCatagory :CommonClassBaseEntries
    {
       // public string Id { get; set; }        now inherited from CommonClassBaseEntries
        public string Catagory { get; set; }
        public ProductCatagory()
        {
            this.ID = Guid.NewGuid().ToString();
        }
    }
   
}
