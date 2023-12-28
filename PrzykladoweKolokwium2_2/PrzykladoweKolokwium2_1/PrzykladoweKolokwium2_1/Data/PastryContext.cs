using Microsoft.EntityFrameworkCore;
using PrzykladoweKolokwium2_1.Configurations;
using PrzykladoweKolokwium2_1.Models;

namespace PrzykladoweKolokwium2_1.Data
{
    public class PastryContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Pastry> Pastries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPastry> OrderPastries { get; set; }

        public PastryContext(DbContextOptions options) : base(options)
        {
        }

        protected PastryContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new PastryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderPastryConfiguration());
        }
    }
}
