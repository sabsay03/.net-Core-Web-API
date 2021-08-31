using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TESODEV_BACKEND_CHALLANGE.Models
{
    public class Address
    {
        public Address(string addressLine, string city, string country, int cityCode)
        {
            AddressLine = addressLine;
            City = city;
            Country = country;
            CityCode = cityCode;
        }

        public int Id { get; set; }

        public string AddressLine { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
        public int  CityCode { get; set; }



        public static Address Create(string addressLine, string city, string country, int cityCode)
        {
            return new Address(addressLine, city, country, cityCode);
        }



        public Address Update(string addressLine, string city, string country, int cityCode) {

            this.AddressLine = addressLine;
            this.City = city;
            this.Country = country;
            this.CityCode = cityCode;

            return this;
        }


    }


}
