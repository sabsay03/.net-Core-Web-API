using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESODEV_BACKEND_CHALLANGE.Business.Customers;
using TESODEV_BACKEND_CHALLANGE.Models;

namespace TESODEV_BACKEND_CHALLANGE.Business.Orders
{
    public class OrderDto
    {
        public int Quantitiy { get; set; }

        public double Price { get; set; }

        public string Status { get; set; }
        public AddressDto Address { get; set; }
        public ProductDto Product { get; set; }
    }
}
