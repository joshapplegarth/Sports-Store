﻿using Microsoft.EntityFrameworkCore;

namespace Sports_Store.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet <Product> Products { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData
            (new Product
               {
                   ProductId = 1,
                   Name = "Kayak",
                   Description = "A 1-Person Boat",
                   Category = "Watersports",
                   Price = 275M
               }
            );

            modelBuilder.Entity<Product>().HasData
            (new Product
               {
                   ProductId = 2,
                   Name = "Life Jacket",
                   Description = "Protective AND Fashionable",
                   Category = "Watersports",
                   Price = 48.95M
               }
            );

            modelBuilder.Entity<Product>().HasData
            (new Product
            {
                ProductId = 3,
                Name = "Soccer Ball",
                Description = "FIFA Approved Size And Weight",
                Category = "Soccer",
                Price = 34.95M
            }
            );

            modelBuilder.Entity<Product>().HasData
            (new Product
               {
                   ProductId = 4,
                   Name = "Corner Flags",
                   Description = "Like The Pros",
                   Category = "Soccer",
                   Price = 19.50M
               }
            );

            modelBuilder.Entity<Product>().HasData
            (new Product
               {
                   ProductId = 5,
                   Name = "Running Shoes",
                   Description = "A New Level Of Comfort",
                   Category = "Running",
                   Price = 89.95M
               }
            );

            modelBuilder.Entity<Product>().HasData
            (new Product
               {
                   ProductId = 6,
                   Name = "Football",
                   Description = "Broncos Logo",
                   Category = "Football",
                   Price = 59.95M
               }
            );

            modelBuilder.Entity<Product>().HasData
            (new Product
               {
                   ProductId = 7,
                   Name = "Baseball",
                   Description = "Official Size & Weight",
                   Category = "Baseball",
                   Price = 9.95M
               }
            );

            modelBuilder.Entity<Product>().HasData
            (new Product
               {
                   ProductId = 8,
                   Name = "Baseball Glove",
                   Description = "Genuine Leather",
                   Category = "Baseball",
                   Price = 94.95M
               }
            );

        }
    }
}
