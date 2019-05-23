using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManagmentBasket
{
    class OrderManagmentDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerBaskets> CustomerBaskets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server = localhost;Database=ApiOrderManagment; Trusted_Connection = True; ConnectRetryCount = 0;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Basket>();
            modelBuilder.Entity<Product>();
            modelBuilder.Entity<Customer>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<CustomerBaskets>().HasKey(b => new { b.CustomerId, b.BasketId });
        }
    }

    //run in supershell 
    //dotnet ef migrations add initial-create
    //dotnet ef database update
}
