using Microsoft.EntityFrameworkCore;

namespace ShoppingKart.Repository
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
