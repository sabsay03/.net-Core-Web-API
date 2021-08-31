using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TESODEV_BACKEND_CHALLANGE.Business
{
    public class AddressDto
    {
        public string AddressLine { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
        public int CityCode { get; set; }
    }
}
