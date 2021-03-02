using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommShop.Core.Models
{
    public class Product : CommonClassBaseEntries
    {
       // public string ID { get; set; } //now inherited from CommonClassBaseEntries
        [StringLength(20)]
        [Display(Name="Product Name")]
        public String Name { get; set; }
        public String Description { get; set; }
        [Range(0,10000)]
        public decimal Price { get; set; }
        public String Catagory { get; set; }
        public String Image { get; set; }
        public Product()
        {
            this.ID = Guid.NewGuid().ToString();
        }
    }
    
}
