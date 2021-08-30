using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TESODEV_BACKEND_CHALLANGE.Data;

namespace TESODEV_BACKEND_CHALLANGE.Models.Customers
{
    public class Customer
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public Address address { get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Order> Orders  { get; set; }



        public Customer(string name, string email,int addressId)
        {
 
            Name = name;
            Email = email;
            AddressId = addressId;
            Orders = new List<Order>();
            CreatedAt = DateTime.Today;
        }


        public static Customer Create(string name, string email,int addressId)
        {

            return new Customer(name, email, addressId);
        }


        public Customer Update(string name, string email)
        {

            Name = name;
            Email = email;
            UpdatedAt = DateTime.Today;

            return this;
        }

        //public void Validate() { 


        
        //}

    }
}
