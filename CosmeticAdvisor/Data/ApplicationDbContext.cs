using Microsoft.EntityFrameworkCore;
using CosmeticAdvisor.Models;

namespace CosmeticAdvisor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cosmetic> Cosmetics { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
    }
}

