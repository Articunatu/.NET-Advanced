using Microsoft.EntityFrameworkCore;
using AmazingTechnique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazingTechnique.API.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ///Seed Product
            modelBuilder.Entity<Product>().
                HasData(new Product
                {
                    ProductID = 1,
                    ProductName = "Iphone 13",
                    Price = 8500.00m,
                    Category = Category.Phone
                });
            modelBuilder.Entity<Product>().
                HasData(new Product
                {
                    ProductID = 2,
                    ProductName = "Samsung S8",
                    Price = 3799.00m,
                    Category = Category.Tablet
                });
            modelBuilder.Entity<Product>().
                HasData(new Product
                {
                    ProductID = 3,
                    ProductName = "Asus RS6",
                    Price = 7988.00m,
                    Category = Category.Computer
                });
            ///Seed Customer
            modelBuilder.Entity<Customer>().
                HasData(new Customer
                {
                    CustomerID = 1,
                    FirstName = "Anas",
                    LastName = "Qlok",
                    Email = "anas@qlok.se",
                    Address = "Storgatan 55B",
                    PhoneNumber = "07777777"
                });
            modelBuilder.Entity<Customer>().
                HasData(new Customer
                {
                    CustomerID = 2,
                    FirstName = "Reidar",
                    LastName = "Nilsen",
                    Email = "reidar@gmail.com",
                    Address = "Sammagatan 21",
                    PhoneNumber = "0789123456"
                });
            ///Seed Order
            modelBuilder.Entity<Order>().
                HasData(new Order
                { 
                    OrderID = 1,
                    CustomerID = 1,
                    OrderPlaced = new DateTime(2021,06,22)
                });
            modelBuilder.Entity<Order>().
                HasData(new Order
                {
                    OrderID = 2,
                    CustomerID = 2,
                    OrderPlaced = new DateTime(2020, 11, 22)
                });
            modelBuilder.Entity<Order>().
                HasData(new Order
                {
                    OrderID = 3,
                    CustomerID = 2,
                    OrderPlaced = new DateTime(2021, 09, 15)
                });
        }
    }
}
