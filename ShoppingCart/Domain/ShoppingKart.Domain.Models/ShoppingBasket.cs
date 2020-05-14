using System.Collections.Generic;

namespace ShoppingKart.Domain.Models
{
    public class ShoppingBasket
    {
        public ShoppingBasket(IList<Models.Product> products)
        {
            Errors = new List<string>();
            Products = products;
        }

        public IList<Models.Product> Products { get; private set; }
        public decimal Total { get
            {
                return SubTotal - Savings;
            }
        }
        public decimal Savings { get; set; }
        public IList<string> Errors { get; set; }
        public decimal SubTotal { get; set; }
    }
}
