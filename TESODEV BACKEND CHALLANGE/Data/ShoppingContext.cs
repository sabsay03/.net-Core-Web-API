using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESODEV_BACKEND_CHALLANGE.Models;
using TESODEV_BACKEND_CHALLANGE.Models.Customers;

namespace TESODEV_BACKEND_CHALLANGE.Data
{
    public class ShoppingContext:DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> opt) : base(opt) { 
        
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }





    }
}
