using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESODEV_BACKEND_CHALLANGE.Models;

namespace TESODEV_BACKEND_CHALLANGE.Business.Customers
{
    public class CustomerDto
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public int AddressId { get; set; }
    }
}
