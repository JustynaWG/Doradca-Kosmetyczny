using Microsoft.EntityFrameworkCore;
using CosmeticAdvisor.Models;

namespace CosmeticAdvisor.Data
{
    public class CosmeticAdvisorContext : DbContext
    {
        public CosmeticAdvisorContext(DbContextOptions<CosmeticAdvisorContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cosmetic> Cosmetics { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public string Oily { get; private set; }
        public string Dry { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dodaj dane startowe
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "John Doe", Email = "john.doe@example.com", SkinType = "Oily" },
                new Customer { CustomerId = 2, Name = "Jane Smith", Email = "jane.smith@example.com", SkinType = "Dry" }
            );

            modelBuilder.Entity<Cosmetic>().HasData(
                new Cosmetic { CosmeticId = 1, Name = "Lotion", Brand = "BrandA", Category = "Moisturizer", SkinType = Oily },
                new Cosmetic { CosmeticId = 2, Name = "Face Wash", Brand = "BrandB", Category = "Cleanser", SkinType = Dry }
            );

            modelBuilder.Entity<Recommendation>().HasData(
                new Recommendation { RecommendationId = 1, CustomerId = 1, CosmeticId = 1, Notes = "Use daily for best results" },
                new Recommendation { RecommendationId = 2, CustomerId = 2, CosmeticId = 2, Notes = "Apply twice a day" }
            );
        }
    }
}