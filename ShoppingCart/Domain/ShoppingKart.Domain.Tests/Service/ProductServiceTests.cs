using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingKart.Repository;
using ShoppingKart.Domain.Models;
using ShoppingKart.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using entities = ShoppingKart.Repository.Entities;

namespace ShoppingKart.Domain.Tests.Services
{
    [TestClass]
    public class ProductServiceTests
    {
        Mock<IRepository> _repo;

        [TestInitialize]
        public void Initialize()
        {
            _repo = new Mock<IRepository>();
        }


        [TestMethod]
        public async Task Get_Products()
        {
            _repo.Setup(x => x.GetAll<entities.Product>(It.IsAny<Func<entities.Product, bool>>())).Returns(MockRepository.MockProducts.GetProducts());
            _repo.Setup(x => x.GetAll<entities.Offer>(It.IsAny<Func<entities.Offer, bool>>())).Returns(MockRepository.MockOffers.GetOffers());

            var service = new ProductService(_repo.Object);

            IList<Product> result = await service.GetProducts(new List<string>
            {
                "A", "B","C","D"
            }, CancellationToken.None);

            Assert.AreEqual(4, result.Count);
        }

        
    }
}
