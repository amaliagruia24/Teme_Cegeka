using CarDealership.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace WebCarDealership
{
    public class DealershipDbContext : DbContext
    {
        public DealershipDbContext(DbContextOptions<DealershipDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.LogTo(Console.Write);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            //.SelectMany(t => t.GetForeignKeys())
            //.Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            //foreach (var fk in cascadeFKs)
            //    fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Invoice>()
                .HasIndex(c => c.InvoiceNumber)
                .IsUnique();

        }

        public DbSet<CarOffer> CarOffers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        
    }
}
