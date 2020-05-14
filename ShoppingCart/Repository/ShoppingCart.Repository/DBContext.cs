using Microsoft.EntityFrameworkCore;
using ShoppingCart.MockRepository;
using ShoppingCart.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Repository
{
    public class ShopDBContext : DbContext
    {
        public ShopDBContext(DbContextOptions<ShopDBContext> options)
            : base(options)
        {
        }

        public DbSet<Entities.Product> SKUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Product>().HasData(
                MockRepository.MockProducts.GetProducts()
             );
        }
    }
}
