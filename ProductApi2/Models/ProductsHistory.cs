using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApi2.Models
{
    public class ProductsHistory
    {
   
        public string Id { get; set; }
        public DateTime timestamp { get; set; }
        public Product Product { get; set; }
    }
}