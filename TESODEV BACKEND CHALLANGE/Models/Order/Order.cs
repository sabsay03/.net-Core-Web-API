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

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime? CreatedAt { get; set; }
        public  DateTime? UpdatedAt { get; set; }


        private Order() { 
        
        }

        public Order(int customerId, int quantitiy, double price, string status, int productId,int addressId)
        {

            CustomerId = customerId;
            Quantitiy = quantitiy;
            Price = price;
            Status = status;
            AddressId = addressId;
            ProductId = productId;
            CreatedAt = DateTime.Today;
        }


        public static Order Create( int customerId,  int quantitiy, double price, string status, int productId, int addressId)
        {

            return new Order(customerId, quantitiy, price, status, productId,addressId);
        }

        public  Order Update(int quantitiy, double price, int productId) {

            Quantitiy = quantitiy;
            Price = price;
            ProductId = productId;
            UpdatedAt = DateTime.Today;

            return this;
        }

        public void ChangeStatus(string status)
        {
            Status = status;
        }

    }
}
