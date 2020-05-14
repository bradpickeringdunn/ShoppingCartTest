using ShoppingKart.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingKart.Domain.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IProductService _productService;
        private IOffersService _offersService;

        public CheckoutService(IProductService productService, IOffersService offersService)
        {
            this._productService = productService;
            this._offersService = offersService;
        }

        public async Task<ShoppingBasket> CheckoutItems(List<string> items, CancellationToken cancellationToken)
        {
           
            var products = await _productService.GetProducts(items, cancellationToken).ConfigureAwait(false);

            var result = new ShoppingBasket(products);

            if (products.Count == 0)
            {
                result.Errors.Add($"No products found that matched the SKU's.");
            }

            result.SubTotal = ProcessItems(products);

            result.Savings = await _offersService.ProcessOffers(products, cancellationToken).ConfigureAwait(false);

            return result;
        }

        private decimal ProcessItems(IList<Product> products)
        {
            var total = 0m;

            foreach(var product in products)
            {
                total += product.Price;
            }

            return total;
        }
    }
}
