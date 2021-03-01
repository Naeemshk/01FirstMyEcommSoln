using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommShop.Core.Models
{
    public class CommonClassBaseEntries
    {
        public string ID { get; set; }
        public DateTimeOffset DateTimeStamp { get; set; }

        public CommonClassBaseEntries()
            {
            this.ID = Guid.NewGuid().ToString();
            DateTimeStamp = DateTime.Now;
            }

    }
    
}
