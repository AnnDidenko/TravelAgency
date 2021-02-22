using DALnew.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DALnew.Context
{
    public class OrderContext: DbContext
    {
        public DbSet<Tour> Tours { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tour>().HasData(
                new Tour[]
                {
                    new Tour{Id = 1, Amount = 10, Category = "sightseeing", Country = "Germany", DepartureDate = new DateTime(2020, 8, 15, 18, 0, 0), DeparturePlace = "Kiev", Duration = 5, Price = 5000},
                    new Tour{Id = 2, Amount = 5, Category = "burning", Country = "Turkey", DepartureDate = new DateTime(2020, 6, 20, 12, 30, 0), DeparturePlace = "Kiev", Duration = 10, Price = 7000},
                    new Tour{Id = 3, Amount = 17, Category = "sightseeing", Country = "Georgia", DepartureDate = new DateTime(2020, 9, 1, 6, 0, 0), DeparturePlace = "Kiev", Duration = 5, Price = 5000},
                });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Ann",
                    Surname = "Didenko",
                    Username = "Hannah",
                    Role = "admin",
                    Age = 19,
                    Email = "ann.didenko8@gmail.com",
                    PhoneNumber = "0508116770",
                    Password = "10000.5SaZ0kE5nup5hhOCEnuVAA==.YlxU3SSYI/RNCvopTIH5VDFtzMVf4oKOb93G0dNVhX0="
                }
                );
        }
    }
}
