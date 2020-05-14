using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingKart.Domain.Services
{
    public interface IProductService
    {
        Task<IList<Models.Product>> GetProducts(List<string> items, CancellationToken cancellationToken);
    }
}