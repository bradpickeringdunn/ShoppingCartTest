using ShoppingKart.Repository;
using ShoppingKart.Domain.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Entities = ShoppingKart.Repository.Entities;

namespace ShoppingKart.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        public ProductService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IList<Models.Product>> GetProducts(List<string> items, CancellationToken cancellationToken) { 
        
            var dbProducts = repo.GetAll<Entities.Product>(x => x.IsActive == true && items.Contains(x.SKU)).ToList();
            var dbOffers = repo.GetAll<Entities.Offer>(x => items.Contains(x.SKU));

            
            var products = AutoMapConfig.Mapper.Map<List<Entities.Product>, List<Models.Product>>(dbProducts);

            foreach (var product in products)
            {
                if(dbOffers.Any(x => x.SKU == product.SKU))
                {
                    var offer = dbOffers.First(x => x.SKU == product.SKU);
                    product.Offer = AutoMapConfig.Mapper.Map<Models.Offer>(offer);
                }
            }

            return await Task.FromResult(products);
        }
    }
}
