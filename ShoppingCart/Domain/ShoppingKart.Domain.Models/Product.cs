using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingKart.Domain.Models
{
    public class Product
    {
        public string SKU { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Offer Offer { get; set; }
    }
}
