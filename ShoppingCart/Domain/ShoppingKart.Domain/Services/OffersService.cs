using ShoppingCart.Repository;
using Entities = ShoppingCart.Repository.Entities;
using ShoppingKart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using ShoppingKart.Domain.Mapping;

namespace ShoppingKart.Domain.Services
{
    public class OffersService : IOffersService
    {
        private readonly IRepository _repo;

        public OffersService(IRepository repo)
        {
            this._repo = repo;
        }
               
        public Task<decimal> ProcessOffers(IList<Product> products, CancellationToken cancellationToken)
        {
            var skus = products.Select(x => x.SKU).ToList();
            var offers = _repo.GetAll<Entities.Offer>(x => x.IsActive == true && skus.Contains(x.SKU)).ToList();

            return Task.FromResult(ApplyOffer(AutoMapConfig.Mapper.Map<List<Models.Offer>>(offers), products));
        }

        private decimal ApplyOffer(IList<Offer> offers, IList<Models.Product> products)
        {
            var savings = 0m;

            foreach (var offer in offers)
            {
                var productOffers = products.Where(x => x.SKU == offer.SKU).ToList();
                decimal appliedOffers = (productOffers.Count / offer.QuantityRequired);
                appliedOffers = Math.Floor(appliedOffers);

                if (appliedOffers > 0)
                {
                    var totalCost = ((appliedOffers * offer.QuantityRequired) * productOffers.First().Price);
                    savings += totalCost - (appliedOffers * offer.Price);
                }
            }

            return savings;
        }
    }
}
