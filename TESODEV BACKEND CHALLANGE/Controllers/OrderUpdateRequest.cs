using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TESODEV_BACKEND_CHALLANGE.Controllers
{
    public class OrderUpdateRequest
    {

        public int Quantitiy { get; set; }

        public double Price { get; set; }

        public int ProductId { get; set; }

        public string AddressLine { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
        public int CityCode { get; set; }
    }
}
