using System;
using System.Collections.Generic;

namespace ShoppingCart.MockRepository
{
    public static class MockProducts
    {
        public static IList<Repository.Entities.Product> GetProducts()
        {
            return new List<Repository.Entities.Product>
            {
                new Repository.Entities.Product
                {
                    SKU = "A",
                    Name = "Wraps",
                    Id = 1,
                    DateCreated = new System.DateTime(2020, 05, 08),
                    IsActive = true,
                    Price = 5m
                },
                new Repository.Entities.Product
                {
                    SKU = "B",
                    Name = "Wraps",
                    Id = 2,
                    DateCreated = new System.DateTime(2020, 05, 08),
                    IsActive = true,
                    Price = 3m
                },
                new Repository.Entities.Product
                {
                    SKU = "C",
                    Name = "Wraps",
                    Id = 3,
                    DateCreated = new System.DateTime(2020, 05, 08),
                    IsActive = true,
                    Price = 2m
                },
                new Repository.Entities.Product
                {
                    SKU = "D",
                    Name = "Wraps",
                    Id = 4,
                    DateCreated = new System.DateTime(2020, 05, 08),
                    IsActive = true,
                    Price = 1m
                }
            };
        }

    }
}
