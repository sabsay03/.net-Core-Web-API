using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TESODEV_BACKEND_CHALLANGE.Models.Customers;

namespace TESODEV_BACKEND_CHALLANGE.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer customer { get; set; }

        public int Quantitiy { get; set; }

        public double Price { get; set; }

        public string Status { get; set; }
        public Address Address { get; set; }
        public Product Product { get; set; }
        public DateTime CreatedAt { get; set; }
        public  DateTime UpdatedAt { get; set; }


        private Order() { 
        
        }

        public Order(int ıd, int customerId, Customer customer, int quantitiy, double price, string status, Address address, Product product)
        {
            Id = ıd;
            CustomerId = customerId;
            Quantitiy = quantitiy;
            Price = price;
            Status = status;
            Address = address;
            Product = product;
            CreatedAt = DateTime.Today;
        }


        public static Order Create(int ıd, int customerId, Customer customer, int quantitiy, double price, string status, Address address, Product product)
        {

            return new Order(ıd, customerId, customer, quantitiy, price, status, address, product);
        }

        public  Order Update(int quantitiy, double price, Address address, Product product) {

            Quantitiy = quantitiy;
            Price = price;
            Address = address;
            Product = product;
            UpdatedAt = DateTime.Today;

            return this;
        }

        public void ChangeStatus(string status)
        {
            Status = status;
        }

    }
}
