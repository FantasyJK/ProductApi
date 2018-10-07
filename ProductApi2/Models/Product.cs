using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApi2.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Sale_amount { get; set; }
    }
}