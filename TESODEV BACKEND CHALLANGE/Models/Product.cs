using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TESODEV_BACKEND_CHALLANGE.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
}
