﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TESODEV_BACKEND_CHALLANGE.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string AddressLine { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
        public int  CityCode { get; set; }



    }

}
