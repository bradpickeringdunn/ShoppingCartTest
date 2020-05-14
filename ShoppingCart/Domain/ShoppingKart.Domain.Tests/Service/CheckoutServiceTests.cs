using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCart.MockRepository;
using ShoppingKart.Domain.Mapping;
using ShoppingKart.Domain.Models;
using ShoppingKart.Domain.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingKart.Domain.Tests.Services
{
    [TestClass]
    public class CheckoutServiceTests
    {

        [TestMethod]
        public async Task Ensure_Can_Add_Up_Basket()
        {
            var dbProducts = MockProducts.GetProducts();
            var products = new List<Models.Product>
            {
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[0]),
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[3]),
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[1]),
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[1]),
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[2]),
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[0])
            };

            var offersService = new Mock<IOffersService>();
            var productService = new Mock<IProductService>();
            productService.Setup(x => x.GetProducts(It.IsAny<List<string>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult < IList<Models.Product>>(
                    products
                ));

            offersService.Setup(x => x.ProcessOffers(It.IsAny<List<Models.Product>>(), CancellationToken.None)).Returns(Task.FromResult(2m));

            var service = new CheckoutService(productService.Object, offersService.Object);
            var items = new List<string> {"A", "A", "B", "C", "B"};

            ShoppingBasket basket = await service.CheckoutItems(items, CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(18, basket.Total);
        }
    }
}
