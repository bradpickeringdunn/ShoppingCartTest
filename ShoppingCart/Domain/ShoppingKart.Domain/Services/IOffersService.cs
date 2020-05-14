using ShoppingKart.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingKart.Domain.Services
{
    public interface IOffersService
    {
        Task<decimal> ProcessOffers(IList<Product> products, CancellationToken cancellationToken);
    }
}