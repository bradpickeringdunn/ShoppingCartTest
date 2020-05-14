using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCart.MockRepository;
using ShoppingCart.Repository;
using ShoppingKart.Domain.Mapping;
using ShoppingKart.Domain.Models;
using ShoppingKart.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Entities = ShoppingCart.Repository.Entities;

namespace ShoppingKart.Domain.Tests.Services
{
    [TestClass]
    public class OffersServiceTests
    {
        Mock<IRepository> _repo;

        [TestInitialize]
        public void Initialize()
        {
            _repo = new Mock<IRepository>();
        }

        [TestMethod]
        public async Task Ensure_Offers_Can_Be_Applied()
        {
            _repo.Setup(x => x.GetAll<Entities.Offer>(It.IsAny<Func<Entities.Offer, bool>>())).Returns(ShoppingCart.MockRepository.MockOffers.GetOffers());

            var dbProducts = MockProducts.GetProducts();
            var products = new List<Models.Product>
            {
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[0]),
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[0]),
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[0]),
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[0]),
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[0]),
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[3]),
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[1]),
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[1]),
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[1]),
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[2]),
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[0])
            };

            var service = new OffersService(_repo.Object);

            var savings = await service.ProcessOffers(products, CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(5.5m, savings);
            _repo.Verify(x => x.GetAll<Entities.Offer>(It.IsAny<Func<Entities.Offer, bool>>()), Times.Once());
        }

        [TestMethod]
        public async Task Ensure_If_No_Offers_N0_Savings_Applied()
        {
            _repo.Setup(x => x.GetAll<Entities.Offer>(It.IsAny<Func<Entities.Offer, bool>>())).Returns(ShoppingCart.MockRepository.MockOffers.GetOffers());

            var dbProducts = MockProducts.GetProducts();
            var products = new List<Models.Product>
            {
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[0]),
                AutoMapConfig.Mapper.Map<Models.Product>(dbProducts[0]),
            };

            var service = new OffersService(_repo.Object);

            var savings = await service.ProcessOffers(products, CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(0m, savings);
            _repo.Verify(x => x.GetAll<Entities.Offer>(It.IsAny<Func<Entities.Offer, bool>>()), Times.Once());

        }
    }
}
