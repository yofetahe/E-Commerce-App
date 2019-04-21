using System;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Models
{
    public class ECommerceContext: DbContext
    {
       public ECommerceContext(DbContextOptions options): base(options){}

       public DbSet<Product> Products { get; set; }
       public DbSet<Customer> Customers { get; set; }
       public DbSet<Order> Orders { get; set; }
       public DbSet<ProductType> ProductTypes { get; set; }
       public DbSet<Stock> Stocks { get; set; }
    }
}