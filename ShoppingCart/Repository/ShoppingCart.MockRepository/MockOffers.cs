using ShoppingCart.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.MockRepository
{
    public static class MockOffers
    {
        public static IList<Offer> GetOffers()
        {
            return new List<Offer>
            {
                new Offer
                {
                    Id = 1,
                    IsActive = true,
                    Price = 13,
                    QuantityRequired = 3,
                    DateCreated = DateTime.Now,
                    SKU = "A"
                },
                new Offer
                {
                    Id = 2,
                    IsActive = true,
                    Price = 4.5m,
                    QuantityRequired = 2,
                    DateCreated = DateTime.Now,
                    SKU = "B"
                }
            };
        }
    }
}
