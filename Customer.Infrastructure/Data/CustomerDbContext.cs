using Microsoft.EntityFrameworkCore;
using CustomerMicroservice.Contracts.Data.Entities;

namespace CustomerMicroservice.Infrastructure.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
