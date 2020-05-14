using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingKart.Domain.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public int QuantityRequired { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
    }
}
